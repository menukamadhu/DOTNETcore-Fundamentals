using CollegeApp.Models;
using CollegeApp.Services.DatabaseService;

namespace CollegeApp.Services.TeacherService;

public class TeacherService : ITeacherService
{
    private readonly IDbService _dbService ;

    public TeacherService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<List<Teacher>> GetAll()
    {
        var teachers = await _dbService.GetAll<Teacher>("SELECT * FROM public.teacher", new { });
        return teachers;
    }

    public async Task<Teacher> GetById(int id)
    {
        var teacher = await _dbService.GetAsync<Teacher>("SELECT * FROM public.teacher WHERE id=@id", new { id });
        return teacher;
    }

    public async Task<Teacher> GetByName(string name)
    {
        var teacher = await _dbService.GetAsync<Teacher>("SELECT * FROM public.teacher WHERE name=@name", new { name });
        return teacher;
    }

    public async Task<bool> Insert(Teacher teacher)
    {
        var result = await _dbService.EditData(
            "INSERT INTO public.teacher (id,name,email,address) VALUES (@Id, @Name, @Email, @Address)",
            teacher
        );
        return true;
    }

    public async Task<Teacher> Update(Teacher teacher)
    {
        var updateTeacher = await _dbService.EditData(
            "UPDATE public.teacher SET name=@Name, email=@Email, address=@Address WHERE id=@Id",
            teacher
        );
        return teacher;
    }

    public async Task<bool> Delete(int id)
    {
        var deleteTeacher = await _dbService.EditData("DELETE FROM public.teacher WHERE id=@id",new {id});
        return true;
    }
}