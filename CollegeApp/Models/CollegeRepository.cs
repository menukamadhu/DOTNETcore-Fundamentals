namespace CollegeApp.Models;

public class CollegeRepository
{
    public static List<Student> Students { get; set; } = new List<Student>(){ 
        new Student
        {
            Id = 1,
            StudentName = "Student 01",
            Email = "studentemail1@gmail.com",
            Address = "Colombo, Sri Lanka"
        },
        new Student
        {
            Id = 2,
            StudentName = "Student 02",
            Email = "studentemail2@gmail.com",
            Address = "Colombo, Sri Lanka"
        }
    };

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