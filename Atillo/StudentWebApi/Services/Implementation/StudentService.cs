using StudentWebApi.Models;
using Services.Interfaces;

namespace StudentWebApi.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private Dictionary<long, Student> _students = new Dictionary<long, Student>();
        private long _idCounter = 1L;
        
        public Student AddStudent(Student student)
        {
            if (student.StudentId == 0)
            {
                student.StudentId = _idCounter++;
            }
            
            return _students.TryAdd(student.StudentId, student) ? student : null;
        }

        public List<Student> GetAllStudents()
        {
            return [.. _students.Values];
        }
        
        public Student? GetStudentById(long id)
        {
            return _students.GetValueOrDefault(id);
        }

        public Student UpdateStudent(long id, Student student)
        {
            if (!_students.TryGetValue(id, out var studentToUpdate))
            {
                return null!; // Student not found
            }
            
            if (!string.IsNullOrEmpty(student.Name)) studentToUpdate.Name = student.Name;

            if(string.IsNullOrEmpty(student.Course)) studentToUpdate.Course = student.Course;
            
            return studentToUpdate;
        }
        
        public bool DeleteStudent(long id)
        {
            return _students.Remove(id);
        }
    }
}