namespace StudentWebApi.Models
{
    public class Student
    {
        public Student() { }


        public Student(long studentId, string name, string course)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Course = course;
        }

        public long StudentId { get; set; }
        public required string Name { get; set; }
        public required string Course { get; set; }

    }
}