using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Library
{
    public class SQSClient : ISQSClient
    {
        private AmazonSQSClient _client;
        public SQSClient()
        {
            _client = new AmazonSQSClient();
        }

        public async Task<List<string>> AddMessageAsync(string url, List<string> messages)
        {
            List<string> responses = new List<string>();
            int count = 0;
            foreach (var message in messages)
            {
                count++;
                SendMessageRequest request = new SendMessageRequest(url, message);
                var response = await _client.SendMessageAsync(request);
                responses.Add($"Response {count} : {response.HttpStatusCode}");
            }
            return responses;
        }

        public async Task<ReceiveMessageResponse> ReceiveMessageAsync(string url)
        {
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = url,
                AttributeNames = { "SentTimestamp" },
                MaxNumberOfMessages = 1,
                MessageAttributeNames = { "All" }
            };

            var receiveResponse = await _client.ReceiveMessageAsync(receiveMessageRequest);

            return receiveResponse;
        }
        public async Task<DeleteMessageResponse> DeleteMessageAsync(string url, ReceiveMessageResponse receiveResponse)
        {
            var deleteRequest = new DeleteMessageRequest
            {
                QueueUrl = url,
                ReceiptHandle = receiveResponse.Messages.FirstOrDefault()!.ReceiptHandle
            };

            var response = await _client.DeleteMessageAsync(deleteRequest);
            return response;
        }
    }
}