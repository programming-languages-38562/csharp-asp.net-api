using StudentWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentWebApi.Services {
    public class StudentService : IStudentService {
        private readonly Dictionary<long, Student> _students = new();

        public Student AddStudent(Student student) {
            _students[student.StudentId] = student;
            return student;
        }

        public List<Student> GetAllStudents() {
            return _students.Values.ToList();
        }

        public Student? GetStudentById(long id) {
            if (_students.ContainsKey(id)) {
                return _students[id];
            }
            else {
                return null;
            }
        }

        public Student? UpdateStudent(Student student) {
            if (_students.ContainsKey(student.StudentId)) {
                _students[student.StudentId] = student;
                return student;
            }
            else {
                return null;
            }
        }

        public bool DeleteStudent(long id) {
            return _students.Remove(id);
        }
    }
}
