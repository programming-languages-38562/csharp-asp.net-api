using System.Collections.Generic;
using StudentWebApi.Models;

namespace StudentWebApi.Services
{
    public class StudentService : IStudentService
    {
        // Simulated database (Dictionary like HashMap in Java)
        private readonly Dictionary<long, Student> _studentDB = new();

        public List<Student> GetAllStudents()
        {
            return new List<Student>(_studentDB.Values);
        }

        public Student GetStudentById(long id)
        {
            _studentDB.TryGetValue(id, out var student);
            return student; // returns null if not found
        }

        public Student AddStudent(Student student)
        {
            _studentDB[student.StudentId] = student;
            return student;
        }

        public Student UpdateStudent(long id, Student updatedStudent)
        {
            if (_studentDB.ContainsKey(id))
            {
                var student = _studentDB[id];

                // Partial update support
                if (!string.IsNullOrEmpty(updatedStudent.Name))
                    student.Name = updatedStudent.Name;

                if (!string.IsNullOrEmpty(updatedStudent.Course))
                    student.Course = updatedStudent.Course;

                _studentDB[id] = student;
                return student;
            }
            return null;
        }

        public bool DeleteStudent(long id)
        {
            return _studentDB.Remove(id);
        }
    }
}
