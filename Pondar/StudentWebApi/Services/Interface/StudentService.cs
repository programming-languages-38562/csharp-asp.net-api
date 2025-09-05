using StudentWebApi.Models;
using StudentWebApi.Services;

public class StudentService : IStudentService
{
    private Dictionary<long, Student> studentDB = new Dictionary<long, Student>();
    private long studentCount = 1;
 
    public Student addStudent(Student student)
    {
        if (student.PkStudentID == 0)
        {
            student.PkStudentID = studentCount++;
        }

        if (studentDB.ContainsKey(student.PkStudentID))
        {
            throw new ArgumentException("Student ID already exists");
        }

        studentDB.Add(student.PkStudentID, student);
        return student;
    }
    public List<Student> getAllStudents()
    {
        return studentDB.Values.ToList();
    }

    public bool deleteStudent(long id)
    {
        return studentDB.Remove(id);
    }

    public Student? getStudentById(long id)
    {
        return studentDB.TryGetValue(id, out Student? student) ? student : null;

        // Student? foundStudentID;
        // if (studentDB.TryGetValue(id, out Student? student))
        // {
        //     foundStudentID = student;
        // }
        // else
        // {
        //     foundStudentID = null;
        // }
    }

    public Student? updateStudent(long id, Student student)
    {
        long studentID = student.PkStudentID;

        if (studentDB.ContainsKey(studentID))
        {
            studentDB[studentID].Name = student.Name;
            studentDB[studentID].Course = student.Course;

            return studentDB[id];

        }
        else
        {
            return null;
        }
    }
}