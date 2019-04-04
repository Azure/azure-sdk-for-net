// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WebSocketsEnd2EndTests
    {
        static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

        [Fact]
        [LiveTest]
        async Task SendAndReceiveWithWebSocketsTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var taskCompletionSource = new TaskCompletionSource<Message>();
                var queueClient = new QueueClient(TestUtility.WebSocketsNamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                
                try
                {
                    var random = new Random();
                    var contentAsBytes = new byte[8];
                    random.NextBytes(contentAsBytes);

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
                    await queueClient.SendAsync(new Message(contentAsBytes));

                    var receiveTask = taskCompletionSource.Task;

                    if (receiveTask.IsCompleted || Debugger.IsAttached)
                    {
                        await receiveTask;
                    }
                    else
                    {
                        var cancelletionSource = new CancellationTokenSource();

                        if (receiveTask == (await Task.WhenAny(receiveTask, Task.Delay(Timeout, cancelletionSource.Token))))
                        {
                            cancelletionSource.Cancel();
                            await receiveTask;
                        }
                        else
                        {
                            throw new TimeoutException();
                        }
                    }
                    
                    var receivedMessage = receiveTask.Result;
                    Assert.Equal(contentAsBytes, receivedMessage.Body);
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }
    }
}
