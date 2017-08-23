// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WebSocketsEnd2EndTests
    {
        static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

        [Fact]
        async Task SendAndReceiveWithWebSocketsTest()
        {
            var taskCompletionSource = new TaskCompletionSource<Message>();
            var queueClient = new QueueClient(TestUtility.WebSocketsNamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                var random = new Random();
                byte[] content = new byte[8];
                random.NextBytes(content);

                queueClient.RegisterMessageHandler((message, token) =>
                    {
                        taskCompletionSource.SetResult(message);
                        return Task.CompletedTask;
                    },
                    exceptionReceivedArgs =>
                    {
                        taskCompletionSource.SetException(exceptionReceivedArgs.Exception);
                        return Task.CompletedTask;
                    });
                await queueClient.SendAsync(new Message(content));

                var timeoutTask = Task.Delay(Timeout);
                var receiveTask = taskCompletionSource.Task;

                if (await Task.WhenAny(timeoutTask, receiveTask).ConfigureAwait(false) == timeoutTask)
                {
                    throw new TimeoutException();
                }

                var receivedMessage = receiveTask.Result;
                Assert.Equal(content, receivedMessage.Body);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}
