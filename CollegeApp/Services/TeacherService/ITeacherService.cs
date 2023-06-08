using CollegeApp.Models;

namespace CollegeApp.Services.TeacherService;

public interface ITeacherService
{
    Task<List<Teacher>> GetAll();
    Task<Teacher> GetById(int id);
    Task<Teacher> GetByName(string name);
    Task<bool> Insert(Teacher teacher);
    Task<Teacher> Update(Teacher teacher);
    Task<bool> Delete(int id);
}