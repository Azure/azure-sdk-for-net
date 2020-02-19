// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task Peek()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;

                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt);
                await sender.SendRangeAsync(sentMessages);

                await using var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);

                Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body));
                }
                IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekRangeAsync(
                    maxMessages: messageCt);

                var ct = 0;
                await foreach (ServiceBusMessage peekedMessage in peekedMessages)
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body);
                    //var sentText = sentMessageIdToLabel[peekedMessage.MessageId];

                    //sentMessageIdToLabel.Remove(peekedMessage.MessageId);
                    //Assert.AreEqual(sentText, peekedText);

                    TestContext.Progress.WriteLine($"{peekedMessage.Label}: {peekedText}");
                    ct++;
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    Assert.AreEqual(item.SystemProperties.DeliveryCount, 1);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                messageEnum.Reset();
                IAsyncEnumerable<ServiceBusMessage> peekMessages = receiver.PeekRangeAsync(messageCount);
                await foreach (var item in peekMessages)
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var clientOptions = new QueueReceiverClientOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, clientOptions);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    receivedMessageCount++;
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Receive_Event(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var sender = new QueueSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                await sender.SendRangeAsync(GetMessages(numThreads * 2));
                await using var receiver = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                int messageCt = 0;

                receiver.ProcessMessageAsync += ProcessMessage;

                var options = new MessageHandlerOptions(ExceptionHandler)
                {
                    MaxConcurrentCalls = numThreads
                };

                await receiver.StartProcessingAsync(options);

                // Allow 5s to be sure there is enough time for a message to be processed per thread.
                await Task.Delay(1000 * 5);

                async Task ProcessMessage(ServiceBusMessage message)
                {
                    TestContext.Progress.WriteLine(message.SessionId + " " + message.MessageId);
                    await receiver.CompleteAsync(message.SystemProperties.LockToken);
                    TestContext.Progress.WriteLine(Process.GetCurrentProcess().Threads.Count);
                    Interlocked.Increment(ref messageCt);
                    await Task.Delay(1000 * 5);
                }

                // we only give each thread enough time to process one message, so the total number of messages
                // processed should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(30)]
        public async Task Receive_StopProcessing(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var sender = new QueueSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                int numMessages = 50;
                await sender.SendRangeAsync(GetMessages(numMessages));

                await using var receiver = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                int messageProcessedCt = 0;

                // stop processing halfway through
                int stopAfterMessagesCt = numMessages / 2;

                receiver.ProcessMessageAsync += ProcessMessage;

                var options = new MessageHandlerOptions(ExceptionHandler)
                {
                    MaxConcurrentCalls = numThreads
                };

                await receiver.StartProcessingAsync(options);

                // Allow enough time for messages to be processed
                await Task.Delay(1000 * 10);

                async Task ProcessMessage(ServiceBusMessage message)
                {
                    await receiver.CompleteAsync(message.SystemProperties.LockToken);
                    Interlocked.Increment(ref messageProcessedCt);
                    if (messageProcessedCt == stopAfterMessagesCt)
                    {
                        await receiver.StopProcessingAsync();
                    }
                }

                // can't assert on the exact amount processed due to threads that
                // are already in flight when calling StopProcessingAsync
                Assert.IsTrue(
                    stopAfterMessagesCt <= messageProcessedCt &&
                    messageProcessedCt < numMessages);
            }
        }
    }
}
