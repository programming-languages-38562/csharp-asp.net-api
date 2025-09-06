using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/student
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var allStudents = _studentService.GetAllStudents();

        if (allStudents == null || allStudents.Count == 0)
        {
            return NotFound("No Student Found");
        }

        return Ok(allStudents);
    }

    // GET: api/student/{id}
    [HttpGet("{id}")]
    public IActionResult GetStudentById(long id)
    {
        var foundStudent = _studentService.GetStudentById(id);

        if (foundStudent == null)
        {
            return NotFound($"Student {id} is not found");
        }

        return Ok(foundStudent);
    }

    // POST: api/student
    [HttpPost]
    public IActionResult AddStudent([FromBody] Student student)
    {
        if (string.IsNullOrWhiteSpace(student.Name) || string.IsNullOrWhiteSpace(student.Course))
        {
            return BadRequest("Name and course are required");
        }

        Student savedStudent = _studentService.AddStudent(student);
        return Ok(savedStudent);
    }

    // PUT: api/student/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(long id, [FromBody] Student student)
    {
        if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.Course))
            return BadRequest("Incomplete Fields!");

        student.StudentId = id;
        

        var updatedStudent = _studentService.UpdateStudent(student);

        if (updatedStudent == null)
        {
            return NotFound($"Student {id} not found");
        }

        return Ok(updatedStudent);
    }

    // DELETE: api/student/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(long id)
    {
        var deleted = _studentService.DeleteStudent(id);

        if (!deleted)
        {
            return NotFound($"Student {id} is not found");
        }

        return NoContent();
    }
}
