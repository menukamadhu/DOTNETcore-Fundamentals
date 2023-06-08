using CollegeApp.Models;

namespace CollegeApp.Services.TeacherService;

public interface ITeacherService
{
    IEnumerable<Teacher> GetAll();
    Teacher GetById(int Id);
    Teacher GetByName(string Name);
    Teacher Insert(Teacher teacher);
    void Update(Teacher teacher);
    void Delete(int Id);
}