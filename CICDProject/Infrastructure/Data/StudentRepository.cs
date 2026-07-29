using CICDProject.Models;

namespace CICDProject.Data
{
    public static class StudentRepository
    {
        public static List<Student> Students { get; private set; } = new();

        static StudentRepository()
        {
            Reset();
        }

        public static void Reset()
        {
            Students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "John",
                Age = 20,
                City = "New York"
            },
            new Student
            {
                Id = 2,
                Name = "David",
                Age = 22,
                City = "Chicago"
            },
            new Student
            {
                Id = 3,
                Name = "Steve",
                Age = 24,
                City = "Dallas"
            }
        };
        }
    }
}