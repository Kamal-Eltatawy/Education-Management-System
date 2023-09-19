using Education_Management_System.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Education_Management_System.Models.Validation
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? name = value?.ToString();
            CourseDepartmentsInstructorsVM? CoursVM = 
                validationContext.ObjectInstance as CourseDepartmentsInstructorsVM;
            DB_Context _context = new DB_Context();
            if (name != null
                && CoursVM != null
                && !_context.Courses.Any(c => c.Name == name && c.DepID == CoursVM.DepID))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("This Name Is Already Exist");
            }
        }
    }
}
