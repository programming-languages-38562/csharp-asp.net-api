using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Services;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase {
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService) {
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult AddStudent([FromBody] Student student) {
        var studentToAdd = _studentService.AddStudent(student);

        if (studentToAdd != null) {
            return Ok(studentToAdd);
        }
        return BadRequest("ID is already taken!");
    }

    [HttpGet]
    public ActionResult<List<Student>> GetAllStudents() {
        return Ok(_studentService.GetAllStudents());
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetStudentById(long id) {
        var student = _studentService.GetStudentById(id);

        if (student == null) {
            return NotFound($"Student with ID {id} not found.");
        }
        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(long id, [FromBody] Student student) {
        var studentToUpdate = _studentService.UpdateStudent(student);

        if (studentToUpdate != null) {
            return Ok(studentToUpdate);
        }
        return NotFound("Student not found");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(long id) {
        if (_studentService.DeleteStudent(id)) {
            return Ok("Student removed successfully");
        }
        return NotFound("Student ID not found");
    }
}
