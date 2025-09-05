using System.Collections.Generic;
using StudentWebApi.Models;

namespace StudentWebApi.Services
{
    public class StudentService : IStudentService
    {
        
        private readonly Dictionary<long, Student> _students = new();

      
        public List<Student> GetAllStudents()
        {
            return new List<Student>(_students.Values);
        }

        public Student? GetStudentById(long id)
        {
            return _students.ContainsKey(id) ? _students[id] : null;
        }

        
        public Student AddStudent(Student student)
        {
            _students[student.StudentId] = student;
            return student;
        }

       
        public Student? UpdateStudent(Student student)
    {
    if (_students.ContainsKey(student.StudentId))
    {
        _students[student.StudentId] = student;
        return student;
    }
    return null;
    }

        
        public bool DeleteStudent(long id)
        {
            return _students.Remove(id);
        }
    }
}
