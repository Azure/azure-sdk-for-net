// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WebSocketsEnd2EndTests
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

        [Fact]
        [LiveTest]
        public async Task SendAndReceiveWithWebSocketsTest()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var tcs = new TaskCompletionSource<Message>(TaskCreationOptions.RunContinuationsAsynchronously);
                var queueClient = new QueueClient(TestUtility.WebSocketsNamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                try
                {
                    var random = new Random();
                    var contentAsBytes = new byte[8];
                    random.NextBytes(contentAsBytes);

                    queueClient.RegisterMessageHandler((message, token) =>
                    {
                        tcs.TrySetResult(message);
                        return Task.CompletedTask;
                    },
                    exceptionReceivedArgs =>
                    {
                        tcs.TrySetException(exceptionReceivedArgs.Exception);
                        return Task.CompletedTask;
                    });

                    await queueClient.SendAsync(new Message(contentAsBytes));

                    var receivedMessage = await tcs.Task.WithTimeout(Timeout);
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
