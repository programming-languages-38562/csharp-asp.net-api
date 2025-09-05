namespace StudentWebApi.Models
{
    public class Student
    {
        public long PkStudentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;

        public Student() { }
        
        public Student(long pkStudentID, string name, string course)
        {
            PkStudentID = pkStudentID;
            Name = name;
            Course = course;
        }
    }
}