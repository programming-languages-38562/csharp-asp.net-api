using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Services;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(long id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Student data is null");

            var addedStudent = _studentService.AddStudent(student);
            return Ok(addedStudent);
        }

        
[HttpPut]
public IActionResult UpdateStudent([FromBody] Student student)
{
    if (student == null)
        return BadRequest("Student data is null");

    var updatedStudent = _studentService.UpdateStudent(student);
    if (updatedStudent == null)
        return NotFound();

    return Ok(updatedStudent);
}


    
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            var success = _studentService.DeleteStudent(id);
            if (!success)
                return NotFound();

            return Ok($"Student with ID {id} deleted.");
        }
    }
}
