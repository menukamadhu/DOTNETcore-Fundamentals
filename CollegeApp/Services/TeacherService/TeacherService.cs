using CollegeApp.Models;

namespace CollegeApp.Services.TeacherService;

public class TeacherService : ITeacherService
{
    private readonly List<Teacher> _teachers;

    public TeacherService()
    {
        _teachers = CollegeRepository.Teachers;
    }
    
    public IEnumerable<Teacher> GetAll()
    {
        return _teachers.ToList();
    }

    public Teacher GetById(int Id)
    {
        return _teachers.FirstOrDefault(n => n.Id == Id);
    }

    public Teacher GetByName(string Name)
    {
        return _teachers.FirstOrDefault(n => n.TeacherName == Name);
    }

    public Teacher Insert(Teacher teacher)
    {
        int NewId = _teachers.Any() ? _teachers.Max(n => n.Id) + 1 : 1;

        Teacher NewTeacher = new Teacher
        {
            Id = NewId,
            TeacherName = teacher.TeacherName,
            Email = teacher.Email,
            Address = teacher.Address
        };
        
        _teachers.Add(NewTeacher);
        return NewTeacher;
    }

    public void Update(Teacher teacher)
    {
        var ExistingTeacher = _teachers.FirstOrDefault(n => n.Id == teacher.Id);
        if (ExistingTeacher == null)
        {
            throw new ArgumentException("Teacher not Found");
        }

        ExistingTeacher.TeacherName = teacher.TeacherName;
        ExistingTeacher.Email = teacher.Email;
        ExistingTeacher.Address = teacher.Address;
    }

    public void Delete(int Id)
    {
        var teacher = _teachers.FirstOrDefault(n => n.Id == Id);
        if (teacher == null)
        {
            throw new ArgumentException("Teacher not Found");
        }

        _teachers.Remove(teacher);
    }
}