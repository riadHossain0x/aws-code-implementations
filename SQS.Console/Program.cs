using SQS.Library;

namespace SQS.Console
{ 
    public class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://sqs.us-east-1.amazonaws.com/847888492411/riad_SQS";
            var sqsOperation = new SQSOperations(new SQSClient(), url);

            // Insert Operation
            var messageList = new List<string>
            {
                "Response1", "Response2", "Response3", "Response4", "Response5",
                "Response6", "Response7", "Response8", "Response9", "Response10"
            };
            var addResponse = await sqsOperation.AddMessageAsync(messageList);
            addResponse.ForEach(x =>
            {
                System.Console.WriteLine(x);
            });

            // Read Operation
            var receiveResponse = await sqsOperation.ReceiveMessageAsync(4);
            receiveResponse.ForEach(x =>
            {
                System.Console.WriteLine(x);
            });

            // Delete Operation
            var deleteResponse = await sqsOperation.DeleteMessageAsync(4);
            deleteResponse.ForEach(x =>
            {
                System.Console.WriteLine(x);
            });

        }
    }
}