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
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _teacherService.GetAll();
        return Ok(teachers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var teacher = await _teacherService.GetById(id);
        if (teacher == null)
        {
            return NotFound();
        }

        return Ok(teacher);
    }

    [HttpGet("{name:alpha}")]
    public async Task<IActionResult> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest();
        }

        var teacher = await _teacherService.GetByName(name);
        if (teacher == null)
        {
            return NotFound();
        }

        return Ok(teacher);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> AddTeacher([FromBody] Teacher model)
    {
        var result = await _teacherService.Insert(model);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateTeacher([FromBody] Teacher teacher)
    {
        var result = await _teacherService.Update(teacher);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var result = await _teacherService.Delete(id);
        return Ok(result);
    }
    
}