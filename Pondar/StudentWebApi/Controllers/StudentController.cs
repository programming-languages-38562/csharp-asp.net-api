using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Services;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult AddStudent([FromBody] Student student)
    {
        Student? studentToAdd = _studentService.addStudent(student);

        if (studentToAdd != null)
        {
            return Ok(studentToAdd); // Return the result, not the input
        }
        else
        {
            return BadRequest("ID is already taken!");
        }
    }

    [HttpGet]
    public ActionResult<List<Student>> GetAllStudent()
    {
        return Ok(_studentService.getAllStudents());
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetStudentById(long id)
    {

        var student = _studentService.getStudentById(id);

        if (student == null)
        {
            return NotFound($"Student with ID {id} not found.");
        }
        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(long id, [FromBody] Student student)
    {
        Student? studentToUpdate = _studentService.updateStudent(id, student);

        if (studentToUpdate != null)
        {
            return Ok(student);
        }
        else
        {
            return NotFound($"Student not found");
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteStudent(long id)
    {
        return _studentService.deleteStudent(id) ? Ok($"Student is removed successfully") : NotFound($"Student ID not found");
    }
    
}