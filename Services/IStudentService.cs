using System.Collections.Generic;
using StudentWebApi.Models;

namespace StudentWebApi.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(long id);
        Student AddStudent(Student student);
        Student UpdateStudent(long id, Student student);
        bool DeleteStudent(long id);
    }
}