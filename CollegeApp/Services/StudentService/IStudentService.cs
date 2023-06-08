using CollegeApp.Models;

namespace CollegeApp.Services.StudentService;

public interface IStudentService
{
    IEnumerable<Student> GetAll();

    Student GetById(int Id);

    Student GetByName(string Name);
    Student Insert(Student student);
    
    void Update(Student student);
    
    void Delete(int id);
}