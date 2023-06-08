using CollegeApp.Models;
using CollegeApp.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CollegeApp.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var student = await _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{name:alpha}")]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var student = await _studentService.GetByName(name);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> AddStudent([FromBody] Student model)
        {
            var result = await _studentService.Insert(model);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            var result = await _studentService.Update(student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var result = await _studentService.Delete(id);
            return Ok(result);
        }
    }
}
