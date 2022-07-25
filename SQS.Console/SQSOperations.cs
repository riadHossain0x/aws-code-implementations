using SQS.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQS.Console
{
    internal class SQSOperations
    {
        private readonly ISQSClient _client;
        private readonly string _url;

        public SQSOperations(ISQSClient client, string url)
        {
            _client = client;
            _url = url;
        }
        public async Task<List<string>> AddMessageAsync(List<string> messages) =>
            await _client.AddMessageAsync(_url, messages);
        public async Task<List<string>> ReceiveMessageAsync(int numOfMsgs)
        {
            var messages = new List<string>();
            for (int i = 0; i < numOfMsgs; i++)
            {
                var response = await _client.ReceiveMessageAsync(_url);
                messages.Add($"Recive Message: {response.Messages.FirstOrDefault()!.Body}");
            }
            return messages;
        }
        public async Task<List<string>> DeleteMessageAsync(int numOfMsgs)
        {
            var messages = new List<string>();
            for (int i = 0; i < numOfMsgs; i++)
            {
                // Receive Message
                var receiveResponse = await _client.ReceiveMessageAsync(_url);

                // Delete message
                var response = await _client.DeleteMessageAsync(_url, receiveResponse);
                messages.Add($"Deleting {receiveResponse.Messages.FirstOrDefault()!.Body}:" +
                    $" {response.HttpStatusCode}");
            }
            return messages;
        }
    }
}
