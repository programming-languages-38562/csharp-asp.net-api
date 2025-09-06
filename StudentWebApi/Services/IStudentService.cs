using StudentWebApi.Models;

namespace StudentWebApi.Service
{
     public interface IStudentService 
    {
        List<Student> GetAllStudents();

        Student? GetStudentById(long id);
        Student AddStudent(Student student);

        Student UpdateStudent(long id, Student student);

        Boolean DeleteStudent(long id);
    }
}