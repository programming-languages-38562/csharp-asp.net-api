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

        long studentId = student.StudentId;
        studentsDB[studentId] = student;

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

        if (string.IsNullOrWhiteSpace(student.Name) || string.IsNullOrWhiteSpace(student.Course))
        {
            return null;
        }

        studentsDB[studentId] = student;
        return student;
    }

    public bool DeleteStudent(long id)
    {
        return studentsDB.Remove(id);
    }
}