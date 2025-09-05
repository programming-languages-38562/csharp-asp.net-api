namespace StudentWebApi.Models
{
    public class Student
    {

        private long _studentId;
        private string _name;
        private string _course;


        public long StudentId
        {
            get
            {
                return _studentId;
            }
            
            set
            {
                _studentId = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Course
        {
            get
            {
                return _course;
            }

            set
            {
                _course = value;
            }
        }

        public Student()
        {
            // Parameterless constructor for serialization or initialization
        }


        public Student(long studentId, string name, string course)
        {
            _studentId = studentId;
            _name = name;
            _course = course;


        }
        
    }
}
