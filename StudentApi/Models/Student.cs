namespace Models;

public class Student
{
    public long StudentId { get; set; }
    public string Name { get; set; } = null!;
    public string Course { get; set; } = null!;

    // Default constructor
    public Student()
    {
    }

    // Constructor with parameters
    public Student(long studentId, string name, string course)
    {
        StudentId = studentId;
        Name = name;
        Course = course;
    }

}
