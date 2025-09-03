using Models;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Student AddStudent(Student student);
        List<Student> GetAllStudents();
        Student? GetStudentById(long id);
        Student UpdateStudent(long id, Student student);
        bool DeleteStudent(long id);
    }
}