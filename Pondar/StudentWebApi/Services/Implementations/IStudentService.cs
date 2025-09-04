using StudentWebApi.Models;

namespace StudentWebApi.Services
{
    public interface IStudentService
    {
        Student addStudent(Student student);
        List<Student> getAllStudents();
        Student? getStudentById(long id);
        Student? updateStudent(long id, Student student);
        bool deleteStudent(long id);
    }
}