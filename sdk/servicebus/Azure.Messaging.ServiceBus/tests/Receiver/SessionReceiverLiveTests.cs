// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class SessionReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1, null)]
        [TestCase(1, "key")]
        [TestCase(10000, null)]
        [TestCase(null, null)]
        public async Task Peek_Session(long? sequenceNumber, string partitionKey)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();

                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = AddMessages(batch, messageCt, sessionId, partitionKey).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToMsg.Add(message.MessageId, message);
                }

                var receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId);

                sequenceNumber ??= 1;

                // verify peeked == send
                var ct = 0;
                foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekBatchBySequenceAsync(
                    fromSequenceNumber: (long)sequenceNumber,
                    maxMessages: messageCt))
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body.ToArray());
                    var sentMsg = sentMessageIdToMsg[peekedMessage.MessageId];

                    sentMessageIdToMsg.Remove(peekedMessage.MessageId);
                    Assert.AreEqual(Encoding.Default.GetString(sentMsg.Body.ToArray()), peekedText);
                    Assert.AreEqual(sentMsg.PartitionKey, peekedMessage.PartitionKey);
                    Assert.IsTrue(peekedMessage.SequenceNumber >= sequenceNumber);
                    TestContext.Progress.WriteLine($"{peekedMessage.Label}: {peekedText}");
                    ct++;
                }
                if (sequenceNumber == 1)
                {
                    Assert.AreEqual(messageCt, ct);
                }
            }
        }

        [Test]
        public async Task Lock_Same_Session_Should_Throw()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                int messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageCt, sessionId);

                await sender.SendBatchAsync(messageBatch);
                var options = new ServiceBusReceiverOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(5),
                        MaximumRetries = 0
                    }
                };
                ServiceBusReceiver receiver1 = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId,
                    options);
                Assert.That(
                    async () =>
                    await client.GetSessionReceiverAsync(
                        scope.QueueName,
                        sessionId,
                        options),
                    Throws.Exception);
            }
        }

        [Test]
        [TestCase(10, 2)]
        [TestCase(10, 5)]
        [TestCase(50, 1)]
        [TestCase(50, 10)]
        public async Task PeekRange_IncrementsSequenceNumber(int messageCt, int peekCt)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messagebatch = AddMessages(batch, messageCt, sessionId);

                await sender.SendBatchAsync(messagebatch);
                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(scope.QueueName);

                long seq = 0;
                for (int i = 0; i < messageCt / peekCt; i++)
                {
                    foreach (ServiceBusReceivedMessage msg in await receiver.PeekBatchAsync(
                        maxMessages: peekCt))
                    {
                        Assert.IsTrue(msg.SequenceNumber > seq);
                        if (seq > 0)
                        {
                            Assert.IsTrue(msg.SequenceNumber == seq + 1);
                        }
                        seq = msg.SequenceNumber;
                    }
                }
            }
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        public async Task Peek_IncrementsSequenceNmber(int messageCt)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messagebatch = AddMessages(batch, messageCt, sessionId);

                await sender.SendBatchAsync(messagebatch);

                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(scope.QueueName);

                long seq = 0;
                for (int i = 0; i < messageCt; i++)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekAsync();
                    Assert.IsTrue(msg.SequenceNumber > seq);
                    if (seq > 0)
                    {
                        Assert.IsTrue(msg.SequenceNumber == seq + 1);
                    }
                    seq = msg.SequenceNumber;
                }
            }
        }

        [Test]
        public async Task RoundRobinSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCt = 10;
                HashSet<string> sessions = new HashSet<string>() { "1", "2", "3" };
                // send the messages
                foreach (string session in sessions)
                {
                    using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                    ServiceBusMessageBatch messageBatch = AddMessages(batch, messageCt, session);
                    await sender.SendBatchAsync(messageBatch);
                }

                // create receiver not scoped to a specific session
                for (int i = 0; i < 10; i++)
                {
                    ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(scope.QueueName);

                    foreach (ServiceBusMessage peekedMessage in await receiver.PeekBatchBySequenceAsync(
                        fromSequenceNumber: 1,
                        maxMessages: 10))
                    {
                        var sessionId = receiver.SessionManager.SessionId;
                        Assert.AreEqual(sessionId, peekedMessage.SessionId);
                    }

                    // Close the receiver client when we are done with it. Since the sessionClient doesn't own the underlying connection, the connection remains open, but the session link will be closed.
                    await receiver.CloseAsync();
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(scope.QueueName);

                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    Assert.AreEqual(item.DeliveryCount, 1);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                messageEnum.Reset();
                foreach (var item in await receiver.PeekBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete
                };

                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId,
                    clientOptions);

                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    receivedMessageCount++;
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CompleteMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    await receiver.CompleteAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AbandonMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: useSpecificSession ? sessionId : null);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    await receiver.AbandonAsync(item);
                    Assert.AreEqual(item.DeliveryCount, 1);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                messageEnum.Reset();
                receivedMessageCount = 0;
                foreach (var item in await receiver.PeekBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeadLetterMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: useSpecificSession ? sessionId : null);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    await receiver.DeadLetterAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);

                // TODO: System.InvalidOperationException : Cannot create a MessageSession for a sub-queue.

                // messageEnum.Reset();
                // receivedMessageCount = 0;
                // string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                // var deadLetterReceiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, deadLetterQueuePath, sessionOptions);

                // foreach (var item in await deadLetterReceiver.ReceiveBatchAsync(messageCount))
                // {
                //    receivedMessageCount++;
                //    messageEnum.MoveNext();
                //    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                //    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                //    await deadLetterReceiver.CompleteAsync(item.SystemProperties.LockToken);
                // }
                // Assert.AreEqual(messageCount, receivedMessageCount);

                // var deadLetterMessage = deadLetterReceiver.PeekAsync();
                // Assert.IsNull(deadLetterMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeferMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: useSpecificSession ? sessionId : null);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();
                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    sequenceNumbers.Add(item.SequenceNumber);
                    await receiver.DeferAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);
                IList<ServiceBusReceivedMessage> deferedMessages = await receiver.ReceiveDeferredMessageBatchAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferedMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferedMessages[i].MessageId);
                }
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenewSessionLock(bool isSessionSpecified)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                var messageCount = 1;
                var sessionId1 = "sessionId1";
                ServiceBusMessage message = GetMessage(sessionId1);

                // send another session message before the one we are interested in to make sure that when isSessionSpecified=true, it is being respected
                await sender.SendAsync(GetMessage("sessionId2"));
                await sender.SendAsync(message);

                ServiceBusReceiver receiver = await client.GetSessionReceiverAsync(scope.QueueName, sessionId: isSessionSpecified ? sessionId1 : null);
                if (isSessionSpecified)
                {
                    Assert.AreEqual(sessionId1, receiver.SessionManager.SessionId);
                }
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveBatchAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receiver.SessionManager.LockedUntilUtc;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.SessionManager.RenewSessionLockAsync();

                Assert.True(receiver.SessionManager.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

                // Complete Messages
                await receiver.CompleteAsync(receivedMessage);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                if (isSessionSpecified)
                {
                    Assert.AreEqual(message.MessageId, receivedMessage.MessageId);
                }

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Process_Event(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                var processor = client.GetProcessor(scope.QueueName);
                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();

                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.MaxConcurrentCalls = numThreads;
                processor.UseSessions = true;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var message = args.Message;
                        var receiver = args.Receiver;
                        await receiver.CompleteAsync(message);
                        Interlocked.Increment(ref messageCt);
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, receiver.SessionManager.SessionId);
                        Assert.IsNotNull(receiver.SessionManager.LockedUntilUtc);
                    }
                    finally
                    {
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        completionSources[setIndex].SetResult(true);
                    }
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();

                // we only give each thread enough time to process one message, so the total number of messages
                // processed should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Process_Event_Consumes_All_Messages(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                int messageCt = 0;

                TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                await using var processor = client.GetProcessor(scope.QueueName);

                processor.UseSessions = true;
                processor.RetryOptions = new ServiceBusRetryOptions()
                {
                    // to prevent the receive batch from taking a long time when we
                    // expect it to fail
                    MaximumRetries = 0,
                    TryTimeout = TimeSpan.FromSeconds(5)
                };

                processor.MaxConcurrentCalls = numThreads;
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var receiver = args.Receiver;
                        var message = args.Message;
                        await receiver.CompleteAsync(message);
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(message.SessionId, receiver.SessionManager.SessionId);
                        Assert.IsNotNull(receiver.SessionManager.LockedUntilUtc);
                    }
                    finally
                    {
                        var ct = Interlocked.Increment(ref messageCt);
                        if (ct == numThreads)
                        {
                            taskCompletionSource.SetResult(true);
                        }
                    }
                }
                await taskCompletionSource.Task;
                await processor.StopProcessingAsync();


                // we only give each thread enough time to process one message, so the total number of messages
                // processed should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);

                // try receiving to verify empty
                // since all the messages are gone and we are using sessions, we won't actually
                // be able to open the Receive link
                Assert.That(async () => await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    options: new ServiceBusReceiverOptions
                    {
                        RetryOptions = new ServiceBusRetryOptions
                        {
                            TryTimeout = TimeSpan.FromSeconds(5),
                            MaximumRetries = 0
                        }
                    }), Throws.Exception);
            }
        }


        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Process_Event_SessionId(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                string sessionId = null;
                for (int i = 0; i < numThreads; i++)
                {
                    sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                int messageCt = 0;

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                await using var processor = client.GetProcessor(
                    scope.QueueName);
                processor.UseSessions = true;
                processor.SessionId = sessionId;
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                processor.MaxConcurrentCalls = numThreads;
                await processor.StartProcessingAsync();

                async Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    try
                    {
                        var receiver = args.Receiver;
                        var message = args.Message;
                        await receiver.CompleteAsync(message);
                        Interlocked.Increment(ref messageCt);
                        sessions.TryRemove(message.SessionId, out bool _);
                        Assert.AreEqual(sessionId, message.SessionId);
                        Assert.AreEqual(sessionId, receiver.SessionManager.SessionId);
                        Assert.IsNotNull(receiver.SessionManager.LockedUntilUtc);
                    }
                    finally
                    {
                        var setIndex = Interlocked.Increment(ref completionSourceIndex);
                        completionSources[setIndex].SetResult(true);
                    }
                }
                await Task.WhenAny(completionSources.Select(source => source.Task));
                await processor.StopProcessingAsync();
                // although we are allowing concurrent calls,
                // since we are specifying a specific session, the
                // concurrency won't really work as only one receiver can be linked to the session; TODO may want to add validation for this
                Assert.AreEqual(1, messageCt);

                // we should have received messages from only the specified session
                Assert.AreEqual(numThreads - 1, sessions.Count);
            }
        }
    }
}
