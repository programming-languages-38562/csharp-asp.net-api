using AMAYA.Models;

namespace AMAYA.Services
{
    public class StudentService : IStudentService
    {
        private static Dictionary<long, Student> students = new Dictionary<long, Student>();
        private static long id = 1;
        public Student AddStudent(Student student)
        {
            if (student.StudentId == 0)
            {
                student.StudentId = id++;
            }

            students.Add(student.StudentId, student);
            return student;
        }

        public bool DeleteStudent(long id)
        {
            if (students.ContainsKey(id))
            {
                students.Remove(id);
                return true;
            }

            return false;
        }

        public List<Student> GetAllStudents()
        {
            return students.Values.ToList();
        }

        public Student? GetStudentById(long id)
        {
            if (students.ContainsKey(id))
            {
                return students[id];
            }

            return null;
        }

        public Student? UpdateStudent(long id, Student student)
        {
            if (students.ContainsKey(id))
            {
                Student currStudent = students[id];

                currStudent.Name = student.Name;

                currStudent.Course = student.Course;

                return currStudent;
            }

            return null;
        }
    }
}