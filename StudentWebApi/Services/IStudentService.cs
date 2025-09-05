using System.Collections.Generic;
using StudentWebApi.Models;

namespace StudentWebApi.Services
{
    public interface IStudentService
    {
        // no implementation

        Student AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(long id);
        Student UpdateStudent(Student student);
        bool DeleteStudent(long id);
    }
}
