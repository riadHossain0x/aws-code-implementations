using DynamoDB.Library;

namespace DynamoDB.Console
{
    public class StudentService
    {
        private readonly IDynamoDBClient<Student> _dynamoDBClient;

        public StudentService()
        {
            _dynamoDBClient = new DynamoDBClient<Student>();
        }
        public async Task AddStudentAsync(Student student)
        {
            await _dynamoDBClient.AddAsync(student);
        }
        public async Task AddStudentsAsync(List<Student> students)
        {
            foreach (var student in students)
            {
                await _dynamoDBClient.AddAsync(student);
            }

        }
        public async Task<Student> GetStudentAsync(int id)
        {
            var student = await _dynamoDBClient.GetAsync(id);
            return student;
        }
        public async Task<List<Student>> GetByIdsAsync(int[] ids)
        {
            var studentList = new List<Student>();
            for (int i = 0; i < ids.Length; i++)
            {
                var student = await _dynamoDBClient.GetAsync(ids[i]);
                studentList.Add(student);
            }
            return studentList;
        }
        public async Task<bool> DeleteStudentAsync(int id) => await _dynamoDBClient.DeleteAsync(id);
    }
}