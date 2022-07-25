using DynamoDB.Library;

namespace DynamoDB.Console
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            
            var studentService = new StudentService();

            var student = new Student
            {
                Id = 1,
                Name = "Riad",
                Age = 21,
                Department = "Computer Science"
            };
            var list = Students();
            // Add Student
            //await studentService.AddStudentAsync(student);
            await studentService.AddStudentsAsync(list);

            // Get Student
            //var riad = await studentService.GetStudentAsync(1);

            // Get by Ids
            var studentIds = new[] {1,2,3,4,5,6,7,8,9,10};
            var studentList = await studentService.GetByIdsAsync(studentIds);

            // Delete Operation
            //var isDelete = await studentService.DeleteStudentAsync(1);
        }
        public static List<Student> Students()
        {
            var list = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Riad",
                    Age = 21,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 2,
                    Name = "Jihad",
                    Age = 26,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 3,
                    Name = "Rakib",
                    Age = 25,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 4,
                    Name = "Roman",
                    Age = 21,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 5,
                    Name = "Arif",
                    Age = 21,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 6,
                    Name = "Riad",
                    Age = 21,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 7,
                    Name = "Jihad",
                    Age = 26,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 8,
                    Name = "Rakib",
                    Age = 25,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 9,
                    Name = "Roman",
                    Age = 21,
                    Department = "Computer Science"
                },
                new Student
                {
                    Id = 10,
                    Name = "Arif",
                    Age = 21,
                    Department = "Computer Science"
                }
            };
            return list;
        }
    }
}