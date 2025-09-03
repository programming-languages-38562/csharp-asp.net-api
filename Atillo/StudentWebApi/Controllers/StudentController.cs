using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using StudentWebApi.Models;

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
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            Student? student = _studentService.GetStudentById(id);

            return student == null ? NotFound("Student not found") : Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            Student? studentToBeAdded = _studentService.AddStudent(student);
            return studentToBeAdded != null? Ok(student): BadRequest("Id already taken.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            Student? studentToUpdate = _studentService.UpdateStudent(id, student);

            return studentToUpdate == null ? NotFound("Student not found") : Ok(studentToUpdate);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteStudent(long id)
        {
            return _studentService.DeleteStudent(id)? Ok($"Removed {id} successfully") : NotFound($"Couldn't find id: {id}");
        }
    }
}