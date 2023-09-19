using Education_Management_System.Models;
using Education_Management_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education_Management_System.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult ShowResult(int sid, int crsid)
        {
            DB_Context context = new DB_Context();
          CrsResult? StudentData=  context.CrsResult.Where(i => i.TraineeID == sid && i.CourseID == crsid)
                             .Include(i => i.Trainee)
                             .Include(i => i.Course).FirstOrDefault();
            var studentVM = new StudentWithDegreeWithCourseNameWithColor();
            if (StudentData != null)
            {
                studentVM.StudentID = StudentData.TraineeID;
                studentVM.StudentName = StudentData.Trainee.Name;
                studentVM.StudentDegree = StudentData.Degree;
                studentVM.CourseName = StudentData.Course.Name;
                if(StudentData.Course.MinDegree > studentVM.StudentDegree)
                {
                    studentVM.Color = "Red";
                }
                else
                {
                    studentVM.Color = "Blue";
                }
            }
            return View("ShowResult", studentVM);
        }
        public IActionResult ShowStudentResult(int sid)
        {
            DB_Context context = new DB_Context();
            List<CrsResult>? courses = context.CrsResult.Where(i => i.TraineeID == sid)
                                .Include(i => i.Course)
                                .Include(i => i.Trainee).ToList();
            var studentData = new StudentDegreeNameColorCourses();
            if (studentData != null)
            {
                studentData.StudentName= courses[0].Trainee.Name;
                studentData.StudentID = courses[0].Trainee.ID;
            
            foreach (var item in courses)
            {
                    studentData.courses.Add(new CoursesVM
                    {
                        CourseID = item.CourseID,
                        CourseName= item.Course.Name,
                        degree=item.Degree,
                        color = item.Course.MinDegree > item.Degree ? "Red":"Blue"
                    });
                };
            }
            return View("ShowStudentResult", studentData);
            }

        }
    }

