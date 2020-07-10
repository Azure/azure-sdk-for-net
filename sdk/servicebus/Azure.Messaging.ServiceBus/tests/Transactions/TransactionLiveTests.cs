// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Transactions
{
    public class TransactionLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task TransactionalSendCommit(bool partitioned, bool sessionEnabled)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: sessionEnabled))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = GetMessage(
                    sessionEnabled ? "sessionId" : null,
                    partitioned ? "sessionId" : null);
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message);
                    ts.Complete();
                }

                ServiceBusReceiver receiver = sessionEnabled ? await client.CreateSessionReceiverAsync(scope.QueueName) : client.CreateReceiver(scope.QueueName);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message.Body.ToString(), receivedMessage.Body.ToString());
                await receiver.CompleteMessageAsync(receivedMessage);
            };
        }

        [Test]
        public async Task TransactionalSendMultipleSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message1 = GetMessage("session1");
                ServiceBusMessage message2 = GetMessage("session2");
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message1);
                    await sender.ScheduleMessageAsync(message2, DateTimeOffset.UtcNow);
                    ts.Complete();
                }

                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(scope.QueueName);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message1.Body.ToString(), receivedMessage.Body.ToString());
                await receiver.CompleteMessageAsync(receivedMessage);

                receiver = await client.CreateSessionReceiverAsync(scope.QueueName);
                receivedMessage = await receiver.ReceiveMessageAsync();

                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message2.Body.ToString(), receivedMessage.Body.ToString());
                await receiver.CompleteMessageAsync(receivedMessage);
            };
        }

        [Test]
        public async Task TransactionalSendMultipleSessionsRollback()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var options = new ServiceBusClientOptions();
                options.RetryOptions.TryTimeout = TimeSpan.FromSeconds(5);
                options.RetryOptions.MaxRetries = 0;

                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message1 = GetMessage("session1");
                ServiceBusMessage message2 = GetMessage("session2");
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message1);
                    await sender.ScheduleMessageAsync(message2, DateTimeOffset.UtcNow.AddMinutes(1));
                }
                Assert.That(
                    async () =>
                    await client.CreateSessionReceiverAsync(scope.QueueName), Throws.InstanceOf<ServiceBusException>()
                    .And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusException.FailureReason.ServiceTimeout));
            };
        }

        [Test]
        public async Task TransactionalCancelScheduleRollback()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                options.RetryOptions.TryTimeout = TimeSpan.FromSeconds(5);
                options.RetryOptions.MaxRetries = 0;

                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = GetMessage();
                long seq = await sender.ScheduleMessageAsync(message, DateTimeOffset.UtcNow.AddMinutes(1));
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.CancelScheduledMessageAsync(seq);
                }
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync();
                Assert.NotNull(msg);
            };
        }

        [Test]
        public async Task TransactionalSendAndReceiveSubscription()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.TopicName);

                ServiceBusMessage message = GetMessage();
                await sender.SendMessageAsync(message);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.TopicName, scope.SubscriptionNames.First());
                ServiceBusReceivedMessage received = await receiver.ReceiveMessageAsync();
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(GetMessage());
                    await receiver.CompleteMessageAsync(received);
                    ts.Complete();
                }

                received = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));

                Assert.NotNull(received);
                await receiver.CompleteMessageAsync(received);
            };
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task TransactionalSendRollback(bool partitioned, bool sessionEnabled)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: sessionEnabled))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = GetMessage(
                    sessionEnabled ? "sessionId" : null,
                    partitioned ? "sessionId" : null);
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message);
                    // not completing the transaction
                }

                ServiceBusReceiver receiver = sessionEnabled ?
                    await client.CreateSessionReceiverAsync(
                        scope.QueueName,
                        new ServiceBusSessionReceiverOptions
                        {
                            SessionId = "sessionId"
                        })
                    : client.CreateReceiver(scope.QueueName);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));

                Assert.IsNull(receivedMessage);
            };
        }

        [Test]
        [TestCase(false, false, true)]
        [TestCase(false, true, true)]
        [TestCase(true, false, false)]
        [TestCase(true, true, false)]
        public async Task TransactionalCompleteRollback(bool partitioned, bool sessionEnabled, bool completeInTransactionAfterRollback)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: sessionEnabled))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                string body = Guid.NewGuid().ToString("N");
                ServiceBusMessage message = GetMessage(
                    sessionEnabled ? "sessionId" : null,
                    partitioned ? "sessionId" : null);
                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver = sessionEnabled ? await client.CreateSessionReceiverAsync(scope.QueueName) : client.CreateReceiver(scope.QueueName);

                var receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(
                    message.Body.ToString(),
                    receivedMessage.Body.ToString());
                var sequenceNumber = receivedMessage.SequenceNumber;
                await receiver.DeferMessageAsync(receivedMessage);

                ServiceBusReceivedMessage deferredMessage = await receiver.ReceiveDeferredMessageAsync(sequenceNumber);

                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(deferredMessage);
                }

                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                // Operating on the same message should not be done.
                await Task.Delay(TimeSpan.FromSeconds(2));

                if (completeInTransactionAfterRollback)
                {
                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteMessageAsync(deferredMessage);
                        ts.Complete();
                    }
                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
                else
                {
                    await receiver.CompleteMessageAsync(deferredMessage);
                }

                Assert.That(
                    async () =>
                    await receiver.CompleteMessageAsync(deferredMessage), Throws.InstanceOf<ServiceBusException>()
                    .And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusException.FailureReason.MessageLockLost));
            }
        }

        [Test]
        public async Task TransactionThrowsWhenOperationsOfDifferentPartitionsAreInSameTransaction()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);

                string body = Guid.NewGuid().ToString("N");
                ServiceBusMessage message1 = GetMessage(partitionKey: "1");
                ServiceBusMessage message2 = GetMessage(partitionKey: "2");

                // Two send operations to different partitions.
                var transaction = new CommittableTransaction();
                using (TransactionScope ts = new TransactionScope(transaction, TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message1);
                    Assert.ThrowsAsync<InvalidOperationException>(
                        async () => await sender.SendMessageAsync(message2));
                    ts.Complete();
                }

                transaction.Rollback();

                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                // Operating on the same message should not be done.
                await Task.Delay(TimeSpan.FromSeconds(2));

                // Two complete operations to different partitions.
                await sender.SendMessageAsync(message1);
                await sender.SendMessageAsync(message2);

                ServiceBusReceivedMessage receivedMessage1 = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage1);
                ServiceBusReceivedMessage receivedMessage2 = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage2);

                transaction = new CommittableTransaction();
                using (TransactionScope ts = new TransactionScope(transaction, TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(receivedMessage1);

                    Assert.ThrowsAsync<InvalidOperationException>(
                        async () => await receiver.CompleteMessageAsync(receivedMessage2));
                    ts.Complete();
                }

                transaction.Rollback();

                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                // Operating on the same message should not be done.
                await Task.Delay(TimeSpan.FromSeconds(2));

                await receiver.CompleteMessageAsync(receivedMessage1);

                // the service seems to abandon the message that
                // triggered the InvalidOperationException
                // in the transaction
                Assert.That(
                    async () =>
                    await receiver.CompleteMessageAsync(receivedMessage2), Throws.InstanceOf<ServiceBusException>()
                    .And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusException.FailureReason.MessageLockLost));
            }
        }

        [Test]
        public async Task TransactionCommitWorksUsingSendersAndReceiversFromSameClients()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);

                ServiceBusMessage message1 = GetMessage();
                ServiceBusMessage message2 = GetMessage();
                await sender.SendMessageAsync(message1);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message1.Body.ToString(), receivedMessage.Body.ToString());

                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(receivedMessage);
                    await sender.SendMessageAsync(message2);
                    ts.Complete();
                }

                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                // Operating on the same message should not be done.
                await Task.Delay(TimeSpan.FromSeconds(2));

                // Assert that complete did succeed
                Assert.That(
                    async () =>
                    await receiver.CompleteMessageAsync(receivedMessage), Throws.InstanceOf<ServiceBusException>()
                    .And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusException.FailureReason.MessageLockLost));

                // Assert that send did succeed
                receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message2.Body.ToString(), receivedMessage.Body.ToString());
                await receiver.CompleteMessageAsync(receivedMessage);
            }
        }

        [Test]
        public async Task TransactionCommitThrowsUsingDifferentClientsToSameEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client1 = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client1.CreateSender(scope.QueueName);
                var client2 = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusReceiver receiver = client2.CreateReceiver(scope.QueueName);

                ServiceBusMessage message1 = GetMessage();
                ServiceBusMessage message2 = GetMessage();
                await sender.SendMessageAsync(message1);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message1.Body.ToString(), receivedMessage.Body.ToString());

                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(receivedMessage);

                    Assert.That(
                        async () =>
                        await sender.SendMessageAsync(message2), Throws.InstanceOf<ServiceBusException>());
                    ts.Complete();
                }
            }
        }

        [Test]
        public async Task TransactionRollbackWorksAcrossClientsUsingSameConnectionToSameEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);

                ServiceBusMessage message1 = GetMessage();
                ServiceBusMessage message2 = GetMessage();
                await sender.SendMessageAsync(message1);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message1.Body.ToString(), receivedMessage.Body.ToString());

                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(receivedMessage.LockToken);
                    await sender.SendMessageAsync(message2);
                }

                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                // Operating on the same message should not be done.
                await Task.Delay(TimeSpan.FromSeconds(2));

                // Following should succeed without exceptions
                await receiver.CompleteMessageAsync(receivedMessage.LockToken);

                // Assert that send failed
                receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                Assert.Null(receivedMessage);
            }
        }

        [Test]
        public async Task TransactionalSendViaCommitTest()
        {
            var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
            await using var intermediateQueue = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false);
            await using var destination1 = await ServiceBusScope.CreateWithTopic(enablePartitioning: true, enableSession: false);
            await using var destination2 = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false);
            var intermediateSender = client.CreateSender(intermediateQueue.QueueName);
            var intermediateReceiver = client.CreateReceiver(intermediateQueue.QueueName);
            var destination1Sender = client.CreateSender(destination1.TopicName);
            var destination1ViaSender = client.CreateSender(destination1.TopicName, new ServiceBusSenderOptions
            {
                ViaQueueOrTopicName = intermediateQueue.QueueName
            });
            var destination2ViaSender = client.CreateSender(destination2.QueueName, new ServiceBusSenderOptions
            {
                ViaQueueOrTopicName = intermediateQueue.QueueName
            });
            var destination1Receiver = client.CreateReceiver(destination1.TopicName, destination1.SubscriptionNames.First());
            var destination2Receiver = client.CreateReceiver(destination2.QueueName);

            var body = Encoding.Default.GetBytes(Guid.NewGuid().ToString("N"));
            var message1 = new ServiceBusMessage(body) { MessageId = "1", PartitionKey = "pk1" };
            var message2 = new ServiceBusMessage(body) { MessageId = "2", PartitionKey = "pk2", ViaPartitionKey = "pk1" };
            var message3 = new ServiceBusMessage(body) { MessageId = "3", PartitionKey = "pk3", ViaPartitionKey = "pk1" };

            await intermediateSender.SendMessageAsync(message1).ConfigureAwait(false);
            var receivedMessage = await intermediateReceiver.ReceiveMessageAsync();
            Assert.NotNull(receivedMessage);
            Assert.AreEqual("pk1", receivedMessage.PartitionKey);

            // If the transaction succeeds, then all the operations occurred on the same partition.
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await intermediateReceiver.CompleteMessageAsync(receivedMessage);
                await destination1ViaSender.SendMessageAsync(message2);
                await destination2ViaSender.SendMessageAsync(message3);
                ts.Complete();
            }

            // Assert that first message indeed completed.
            receivedMessage = await intermediateReceiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
            Assert.Null(receivedMessage);

            // Assert that second message reached its destination.
            var receivedMessage1 = await destination1Receiver.ReceiveMessageAsync();
            Assert.NotNull(receivedMessage1);
            Assert.AreEqual("pk2", receivedMessage1.PartitionKey);

            // Assert destination1 message actually used partitionKey in the destination entity.
            var destination1Message = new ServiceBusMessage(body)
            {
                PartitionKey = "pk2"
            };
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await destination1Receiver.CompleteMessageAsync(receivedMessage1);
                await destination1Sender.SendMessageAsync(destination1Message);
                ts.Complete();
            }

            // Assert that third message reached its destination.
            var receivedMessage2 = await destination2Receiver.ReceiveMessageAsync();
            Assert.NotNull(receivedMessage2);
            Assert.AreEqual("pk3", receivedMessage2.PartitionKey);
            await destination2Receiver.CompleteMessageAsync(receivedMessage2);

            // Cleanup
            receivedMessage1 = await destination1Receiver.ReceiveMessageAsync();
            await destination1Receiver.CompleteMessageAsync(receivedMessage1);

        }
    }
}
