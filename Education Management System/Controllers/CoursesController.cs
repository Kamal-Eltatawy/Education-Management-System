using Education_Management_System.Models;
using Education_Management_System.Models.Validation;
using Education_Management_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_Management_System.Controllers
{
    public class CoursesController : Controller
    {
        DB_Context context;
        public IActionResult Index()
        {
            context = new DB_Context();
            var courses = context.Courses.ToList();
            return View(courses);
        }
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var courseDepartmentsInstructorsVM = new CourseDepartmentsInstructorsVM();
            context = new DB_Context();
            var course = context.Courses.FirstOrDefault(i => i.ID == id);
            if (course == null)
            {
                return View("Error");
            }
            else
            {
                courseDepartmentsInstructorsVM.ID = course.ID;
                courseDepartmentsInstructorsVM.Name = course.Name;
                courseDepartmentsInstructorsVM.Degree = course.Degree;
                courseDepartmentsInstructorsVM.MinDegree = course.MinDegree;
                courseDepartmentsInstructorsVM.DepID = course.DepID;
            }
            return View(courseDepartmentsInstructorsVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(CourseDepartmentsInstructorsVM courseDepartments)
        {
            if (courseDepartments != null
                            && Validation.CheckCourseName(courseDepartments.Name)
                            && Validation.CheckDegree(courseDepartments.Degree, courseDepartments.MinDegree)
                            && Validation.CheckDeparttmentID(courseDepartments.DepID)
                            )
            {
                context = new DB_Context();
                var newCourse = new Course()
                {
                    ID = courseDepartments.ID,
                    Name = courseDepartments.Name,
                    Degree = courseDepartments.Degree,
                    MinDegree = courseDepartments.MinDegree,
                    DepID = courseDepartments.DepID,
                };
                context.Courses.Update(newCourse);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseDepartments);
        }
        public IActionResult ShowResult(int crsid)
        {
            DB_Context context = new DB_Context();
            List<CrsResult>? courses = context.CrsResult.Where(i => i.CourseID == crsid)
                                .Include(i => i.Course)
                                .Include(i => i.Trainee).ToList();
            var courseData = new AllStudentDegreeCourseNameColor();

            if (courses != null)
            {
                courseData.CourseName = courses[0].Course.Name;
                foreach (var item in courses)
                {
                    courseData.students.Add(new StudentWithDegreeWithCourseName
                    {
                        StudentName = item.Trainee.Name,
                        StudentDegree = item.Degree,
                        StudentID = item.TraineeID,
                        Color = item.Course.MinDegree > item.Degree ? "red" : "blue"
                    });
                }
            }
            return View("ShowResult", courseData);
        }
        [HttpGet]
        public IActionResult New()
        {
            var courseDepartmentsInstructorsVM = new CourseDepartmentsInstructorsVM();
            
            return View(courseDepartmentsInstructorsVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New( CourseDepartmentsInstructorsVM courseDepaInstReq )
        {
            //if (courseDepaInstReq != null 
            //    && Validation.CheckCourseName(courseDepaInstReq.Name)
            //    && Validation.CheckDegree(courseDepaInstReq.Degree,courseDepaInstReq.MinDegree)
            //    && Validation.CheckDeparttmentID(courseDepaInstReq.DepID)
            //    ) 
            if(ModelState.IsValid)
            {
                context=new DB_Context();
                var newCourse = new Course()
                {
                    Name = courseDepaInstReq.Name,
                    Degree = courseDepaInstReq.Degree,
                    MinDegree= courseDepaInstReq.MinDegree,
                    DepID = courseDepaInstReq.DepID,
                };
                context.Courses.Add(newCourse);
                context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(courseDepaInstReq);
        }
        public IActionResult CheckMinDegree(int MinDegree , int Degree)
        {
            if(Degree>MinDegree)
            return Json(true);
            return Json(false);
        }
    }
}
