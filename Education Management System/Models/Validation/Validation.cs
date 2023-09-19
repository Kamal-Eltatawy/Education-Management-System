using System.Linq;

namespace Education_Management_System.Models.Validation
{
    public static class Validation
    {
        public static bool CheckName(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length >= 3)
            return true;
            return false;
        }
        public static bool CheckCourseName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return true;
            return false;
        }
        public static bool CheckDegree(int degree,int minDegree )
        {
            if (degree>10 && minDegree>0&&minDegree<degree)
                return true;
                return false;
        }
        public static bool CheckDeparttmentID(int depID)
        {
            DB_Context context = new DB_Context();
            return context.Departments.Any(i=>i.ID==depID);
        }
        public static bool CheckInstructorID(int instID)
        {
            DB_Context context = new DB_Context();
            return context.Instructors.Any(i => i.ID == instID);
        }

    }
}
