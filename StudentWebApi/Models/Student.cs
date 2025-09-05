namespace StudentWebApi.Models {
    public class Student {
        public long StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;

        public Student() { }

        public Student(long studentId, string name, string course) {
            StudentId = studentId;
            Name = name;
            Course = course;
        }
    }
}
