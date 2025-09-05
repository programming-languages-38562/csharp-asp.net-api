using StudentWebApi.Models;
using System.Collections.Generic;

namespace StudentWebApi.Services {
    public interface IStudentService {
        Student AddStudent(Student student);
        List<Student> GetAllStudents();
        Student? GetStudentById(long id);
        Student? UpdateStudent(Student student);
        bool DeleteStudent(long id);
    }
}
