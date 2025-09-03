using Models;
using Services.Interfaces;

public class StudentService : IStudentService
{
    // In-memory db
    private readonly Dictionary<long, Student> studentsDB = new Dictionary<long, Student>();

    long studentCount = 1;


    public Student AddStudent(Student student)
    {
        if (student.StudentId == 0)
        {
            student.StudentId = studentCount++;
        }

        studentsDB.Add(student.StudentId, student);

        return student; 
    }

    public List<Student> GetAllStudents()
    {
        return studentsDB.Values.ToList();
    }

    public Student? GetStudentById(long id)
    {
        Student? foundStudent = studentsDB.TryGetValue(id, out Student? student) ? student : null;

        if (foundStudent == null)
        {
            return null;
        }

        return foundStudent;
    }

    public Student? UpdateStudent(Student student)
    {
        long studentId = student.StudentId;


        if (!studentsDB.ContainsKey(studentId)) 
        { 
            return null; 
        }

        studentsDB[studentId].Name = student.Name;
        studentsDB[studentId].Course = student.Course;

        return studentsDB[studentId];
    }

    public bool DeleteStudent(long id)
    {
        return studentsDB.Remove(id);
    }
}