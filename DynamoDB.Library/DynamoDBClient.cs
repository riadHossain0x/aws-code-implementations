using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;

namespace DynamoDB.Library
{
    public class DynamoDBClient<TEntity> : IDynamoDBClient<TEntity> where TEntity : class
    {
        private static AmazonDynamoDBClient _client;
        private DynamoDBContext _context;
        public DynamoDBClient()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.SaveAsync(entity);
        }
        public async Task<TEntity> GetAsync(int id)
        {
            var Items = await _context.LoadAsync<TEntity>(id);
            return Items;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _context.DeleteAsync<TEntity>(id);
            var isDelete = await _context.LoadAsync<TEntity>(id, new DynamoDBContextConfig
            {
                ConsistentRead = true
            });
            if (isDelete == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}