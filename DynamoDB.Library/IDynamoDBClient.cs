
namespace DynamoDB.Library
{
    public interface IDynamoDBClient<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity> GetAsync(int id);
    }
}