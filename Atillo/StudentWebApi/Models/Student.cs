namespace Models
{
    public class Student
    {
        private long _studentId;
        private string _name;
        private string _course;

        public long StudentId { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }

        public Student() { }

        public Student(long studentId, string name, string course)
        {
            StudentId = studentId;
            Name = name;
            Course = course;
        }
    }
}