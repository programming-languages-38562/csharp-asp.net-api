using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Service;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet]
        public ActionResult<Student> GetAllStudent()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<Student?> GetStudentById(long id)
        {
            return Ok(_studentService.GetStudentById(id));
        }

        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            Student createdStudent = _studentService.AddStudent(student);
            return createdStudent;
        }

        [HttpPut("{id}")]
        public ActionResult<Student?> UpdateStudent(long id, [FromBody] Student student)
        {
            return _studentService.UpdateStudent(id, student);
        }

        [HttpDelete("{id}")]
        public ActionResult<Boolean> DeleteStudent(long id)
        {
            return Ok(_studentService.DeleteStudent(id));
        }
    }
}