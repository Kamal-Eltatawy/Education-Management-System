using Education_Management_System.Models;
using Education_Management_System.Models.Validation;
using Education_Management_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_Management_System.Controllers
{
    public class InstructorController : Controller
    {
        DB_Context context;
        public IActionResult Index()
        {
            context = new DB_Context();
            var Instructors = context.Instructors.Include(i => i.Course).ThenInclude(i => i.Department).ToList();
            return View("Index", Instructors);
        }
        public IActionResult Detail(int id)
        {
            context = new DB_Context();
            var Instructors = context.Instructors.Where(i => i.ID == id).Include(i => i.Course).Include(i => i.Department).FirstOrDefault();
            List<Department> Departments = context.Departments.ToList();
            List<Course> Courses = context.Courses.ToList();
            ViewData["Departments"] = Departments;
            ViewData["Courses"] = Courses;
            return View("Detail", Instructors);
        }
        [HttpPost]
        public IActionResult Edite(int id, Instructor instructorRequst)
        {
            context = new DB_Context();
            if (id != 0 && Validation.CheckName(instructorRequst.Name)
                && Validation.CheckName(instructorRequst.Address)
                && instructorRequst.Salary < 40000 
                && !String.IsNullOrEmpty(instructorRequst.ImageUrl)
                )
            {
                var Instructor = context.Instructors.FirstOrDefault(i => i.ID == id);
                if (Instructor != null)
                {
                    Instructor.Name = instructorRequst.Name;
                    Instructor.Address = instructorRequst.Address;
                    Instructor.Salary = instructorRequst.Salary;
                    Instructor.DepID = instructorRequst.DepID;
                    Instructor.CourseID = instructorRequst.CourseID;
                    Instructor.ImageUrl = instructorRequst.ImageUrl;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            List<Department> Departments = context.Departments.ToList();
            List<Course> Courses = context.Courses.ToList();
            ViewData["Departments"] = Departments;
            ViewData["Courses"] = Courses;
            return View("Detail", instructorRequst);
        }
        public IActionResult New ()
        {
            DipartmentsCoursesVM departmentsCoursesVM = new DipartmentsCoursesVM();
            context = new DB_Context();
            var departments = context.Departments.ToList();
            var courses = context.Courses.ToList();
            foreach (Department item in departments )
            {
                departmentsCoursesVM.Departments.Add(new Department()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Courses = item.Courses,
                    Instructors = item.Instructors,
                    Manager = item.Manager,
                    Trainees = item.Trainees
                });
                
            }
            foreach (Course item in courses)
            {
                departmentsCoursesVM.courses.Add(new Course()
                {
                    ID = item.ID,
                    Name = item.Name,
                     crsResults=item.crsResults,
                     Degree=item.Degree,
                     Department=item.Department,
                     DepID = item.DepID ,
                     Instructors = item.Instructors,
                     MinDegree= item.MinDegree
                });

            }
            return View(departmentsCoursesVM);
        }
        [HttpPost]
        public IActionResult Create( Instructor newInstructor)
        {
            context = new DB_Context();
            if (Validation.CheckName(newInstructor.Name)
                && Validation.CheckName(newInstructor.Address)
                && newInstructor.Salary < 40000
                && !String.IsNullOrEmpty(newInstructor.ImageUrl)
                )
            {
                context.Add(newInstructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("New");
        }

    }
}
