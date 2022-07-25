
using Amazon.SQS.Model;

namespace SQS.Library
{
    public interface ISQSClient
    {
        Task<List<string>> AddMessageAsync(string url, List<string> messages);
        Task<ReceiveMessageResponse> ReceiveMessageAsync(string url);
        Task<DeleteMessageResponse> DeleteMessageAsync(string url, ReceiveMessageResponse receiveResponse);
    }
}