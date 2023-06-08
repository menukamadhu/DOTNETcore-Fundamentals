using CollegeApp.Models;

namespace CollegeApp.Services.StudentService;

public interface IStudentService
{
    Task<List<Student>> GetAll();

    Task<Student> GetById(int id);

    Task<Student> GetByName(string name);
    Task<bool> Insert(Student student);
    
    Task<Student> Update(Student student);
    
    Task<bool> Delete(int id);
}