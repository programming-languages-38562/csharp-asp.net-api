namespace StudentWebApi.Models
{
    public class Student
    {
        // Properties (private fields with get;set;)
        public long StudentId { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }

        // Default constructor
        public Student() { }

        // Parameterized constructor
        public Student(long studentId, string name, string course)
        {
            StudentId = studentId;
            Name = name;
            Course = course;
        }
    }
}