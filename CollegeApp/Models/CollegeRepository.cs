namespace CollegeApp.Models;

public class CollegeRepository
{
    public static List<Teacher> Teachers { get; set; } = new List<Teacher>()
    {
        new Teacher
        {
            Id = 1,
            TeacherName = "Teacher 01",
            Email = "studentemail1@gmail.com",
            Address = "Colombo, Sri Lanka"
        },
        new Teacher
        {
            Id = 1,
            TeacherName = "Teacher 02",
            Email = "studentemail1@gmail.com",
            Address = "Colombo, Sri Lanka"
        }
    };
}