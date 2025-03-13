// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Tests;
using Azure.Messaging.ServiceBus.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Sender
{
    [NonParallelizable]
    public class ServiceBusMessageBatchLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanSendLargeMessageBatch(bool enableTracing)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: true))
            {
                ClientDiagnosticListener listener = null;
                if (enableTracing)
                {
                    listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
                }
                try
                {
                    await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                    ServiceBusSender sender = client.CreateSender(scope.QueueName);
                    using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

                    await AddAndSendMessages();

                    batch.Clear();
                    Assert.AreEqual(0, batch.Count);
                    Assert.AreEqual(0, batch.SizeInBytes);

                    await AddAndSendMessages();

                    async Task AddAndSendMessages()
                    {
                        // service limits to 4500 messages but we have not added this to our client validation yet
                        while (batch.Count < 4500 && batch.TryAddMessage(
                            new ServiceBusMessage(new byte[50])
                            {
                                MessageId = "new message ID that takes up some space",
                                SessionId = "sessionId",
                                PartitionKey = "sessionId",
                                ApplicationProperties = { { "key", "value" } }
                            }))
                        {
                        }

                        if (batch.Count < 4500)
                        {
                            var diff = batch.MaxSizeInBytes - batch.SizeInBytes;
                            // the difference in size from the max allowable size should be less than the size of a single
                            // instrumented message
                            Assert.IsTrue(diff < 250, diff.ToString());
                        }
                        Assert.Greater(batch.Count, 0);
                        await sender.SendMessagesAsync(batch);
                    }
                }
                finally
                {
                    listener?.Dispose();
                }
            }
        }
    }
}
