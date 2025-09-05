using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Services;
using System.Collections.Generic;

namespace StudentWebApi.Controllers
{
    [ApiController] // automatic features like request validation ans proper response formatting
    [Route("api/[controller]")] // define the base URL api/student     
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        // Constructor injection
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /api/student
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            if (students.Count == 0)
                return NotFound("No students found.");
            return Ok(students);
        }

        // GET: /api/student/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(long id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");
            return Ok(student);
        }

        // POST: /api/student
        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Invalid student data.");

            var addedStudent = _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById),
                                   new { id = addedStudent.StudentId },
                                   addedStudent);
        }

        // PUT: /api/student/{id}
        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(long id, [FromBody] Student student)
        {
            var updated = _studentService.UpdateStudent(id, student);
            if (updated == null)
                return NotFound($"Student with ID {id} not found.");
            return Ok(updated);
        }

        // DELETE: /api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            var deleted = _studentService.DeleteStudent(id);
            if (!deleted)
                return NotFound($"Student with ID {id} not found.");
            return NoContent();
        }
    }
}
