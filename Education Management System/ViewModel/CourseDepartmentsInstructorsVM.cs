using Education_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Education_Management_System.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Education_Management_System.ViewModel
{
    public class CourseDepartmentsInstructorsVM
    {
        DB_Context _context;
        public CourseDepartmentsInstructorsVM()
        {
            _context = new DB_Context();
            getData();
        }
        public int ID { set; get; }
        [Required(ErrorMessage = "Course Name Must Be more Than 3 letters ")]
        [Unique]
        [StringLength(maximumLength:10 ,ErrorMessage ="Course Name Must Be more Than 3 letters",MinimumLength =3)]
        [Display(Name = "Course Name")]
        public string Name { set; get; }
        [Display(Name = "Course Degree")]
        [Range(50,100,ErrorMessage ="Course Degree Must Be In 50 To 100")]
        public int Degree { set; get; }
        [Display(Name = "Course Min Degree")]
        [Remote("CheckMinDegree", "Courses",ErrorMessage ="Min Degree Must Be Less Than Degree" ,AdditionalFields = "Degree")]
        public int MinDegree { set; get; }
        [Display(Name="Department")]
        public int DepID { set; get; }
        //[Display(Name = "Instructor")]
        //public int InstID { set; get; }
        //public List<Instructor> Instructors { set; get; } = new List<Instructor>();
        public List<Department>? Departments { get; set; } = new List<Department>();

        void getData()
        {
            List<Department>? departments = _context.Departments.ToList();
            //var instructors = _context.Instructors.ToList();
            #region Instrctor Data
            //foreach (var item in instructors)
            //{
            //    this.Instructors.Add(new Instructor()
            //    {
            //        Address = item.Address,
            //        Course = item.Course,
            //        CourseID = item.CourseID,
            //        Department = item.Department,
            //        DepID = item.DepID,
            //        ID = item.ID,
            //        ImageUrl = item.ImageUrl,
            //        Name = item.Name,
            //        Salary = item.Salary
            //    });
            //}
            #endregion
            foreach (var item in departments)
            {
                this.Departments.Add(new Department()
                {
                    Name = item.Name,
                    Courses = item.Courses,
                    ID = item.ID,
                    Instructors = item.Instructors,
                    Manager = item.Manager,
                    Trainees = item.Trainees,
                });
            }

        }
    }
}
