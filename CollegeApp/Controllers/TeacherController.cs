using CollegeApp.Models;
using CollegeApp.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers;

[ApiController]
[Route("api/teachers")]

public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Teacher>> GetAll()
    {
        var teachers = _teacherService.GetAll();
        return Ok(teachers);
    }

    [HttpGet("{Id:int}")]
    public ActionResult<Teacher> GetById(int Id)
    {
        if (Id <= 0)
        {
            return BadRequest();
        }

        var teacher = _teacherService.GetById(Id);
        if (teacher == null)
        {
            return NotFound();
        }

        return Ok(teacher);
    }

    [HttpGet("{Name:alpha}")]
    public ActionResult<Teacher> GetByName(string Name)
    {
        if (string.IsNullOrEmpty(Name))
        {
            return BadRequest();
        }

        var teacher = _teacherService.GetByName(Name);
        if (teacher == null)
        {
            return NotFound();
        }

        return Ok(teacher);
    }

    [HttpPost("insert")]
    public ActionResult<Teacher> CreateTeacher(Teacher model)
    {
        var teacher = _teacherService.Insert(model);
        return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
    }

    [HttpPut("update/{Id}")]
    public ActionResult UpdateTeacher(int Id, Teacher teacher)
    {
        if (Id != teacher.Id)
        {
            return BadRequest("Teacher ID mismatch.");
        }
        
        try
        {
            _teacherService.Update(teacher);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("{Id}")]
    public ActionResult<bool> DeleteStudent(int Id)
    {
        if (Id <= 0)
        {
            return BadRequest();
        }

        try
        {
            _teacherService.Delete(Id);
            return Ok();
        }
        catch
        {
            return NotFound();
        }
    }
    
    
}