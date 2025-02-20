// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage(
                    sessionEnabled ? "sessionId" : null,
                    partitioned ? "sessionId" : null);
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message);
                    ts.Complete();
                }

                ServiceBusReceiver receiver = sessionEnabled ? await client.AcceptNextSessionAsync(scope.QueueName) : client.CreateReceiver(scope.QueueName);

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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message1 = ServiceBusTestUtilities.GetMessage("session1");
                ServiceBusMessage message2 = ServiceBusTestUtilities.GetMessage("session2");
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message1);
                    await sender.ScheduleMessageAsync(message2, DateTimeOffset.UtcNow);
                    ts.Complete();
                }

                ServiceBusReceiver receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message1.Body.ToString(), receivedMessage.Body.ToString());
                await receiver.CompleteMessageAsync(receivedMessage);

                receiver = await client.AcceptNextSessionAsync(scope.QueueName);
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message1 = ServiceBusTestUtilities.GetMessage("session1");
                ServiceBusMessage message2 = ServiceBusTestUtilities.GetMessage("session2");
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message1);
                    await sender.ScheduleMessageAsync(message2, DateTimeOffset.UtcNow.AddMinutes(1));
                }
                Assert.That(
                    async () =>
                    await CreateNoRetryClient().AcceptNextSessionAsync(scope.QueueName), Throws.InstanceOf<ServiceBusException>()
                    .And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.ServiceTimeout));
            };
        }

        [Test]
        public async Task TransactionalCancelScheduleRollback()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage();
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.TopicName);

                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage();
                await sender.SendMessageAsync(message);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.TopicName, scope.SubscriptionNames.First());
                ServiceBusReceivedMessage received = await receiver.ReceiveMessageAsync();
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage(
                    sessionEnabled ? "sessionId" : null,
                    partitioned ? "sessionId" : null);
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message);
                    // not completing the transaction
                }

                ServiceBusReceiver receiver = sessionEnabled ?
                    await client.AcceptSessionAsync(
                        scope.QueueName,
                        "sessionId")
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                string body = Guid.NewGuid().ToString("N");
                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage(
                    sessionEnabled ? "sessionId" : null,
                    partitioned ? "sessionId" : null);
                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver = sessionEnabled ? await client.AcceptNextSessionAsync(scope.QueueName) : client.CreateReceiver(scope.QueueName);

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
                    .EqualTo(ServiceBusFailureReason.MessageLockLost));
            }
        }

        [Test]
        public async Task TransactionThrowsWhenOperationsOfDifferentPartitionsAreInSameTransaction()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);

                string body = Guid.NewGuid().ToString("N");
                ServiceBusMessage message1 = ServiceBusTestUtilities.GetMessage(partitionKey: "1");
                ServiceBusMessage message2 = ServiceBusTestUtilities.GetMessage(partitionKey: "2");

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

                await receiver.CompleteMessageAsync(receivedMessage2);
            }
        }

        [Test]
        public async Task TransactionCommitWorksUsingSendersAndReceiversFromSameClients()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);

                ServiceBusMessage message1 = ServiceBusTestUtilities.GetMessage();
                ServiceBusMessage message2 = ServiceBusTestUtilities.GetMessage();
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
                    .EqualTo(ServiceBusFailureReason.MessageLockLost));

                // Assert that send did succeed
                receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message2.Body.ToString(), receivedMessage.Body.ToString());
                await receiver.CompleteMessageAsync(receivedMessage);

                // validate that the Local transaction cannot span multiple entities error is not thrown when outside of a transaction
                await using var scope2 = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
                ServiceBusReceiver receiver2 = client.CreateReceiver(scope2.QueueName);
                await receiver2.ReceiveMessageAsync(TimeSpan.FromSeconds(2));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanUseSameSenderBothWithinAndOutsideTransactionSimultaneously(bool transactionFirst)
        {
            await using (var scope1 = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                ServiceBusSender sender1 = client.CreateSender(scope1.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope1.QueueName);

                await using var scope2 = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
                ServiceBusSender sender2 = client.CreateSender(scope2.QueueName);

                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage();
                await sender1.SendMessageAsync(message);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);

                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                Task transactionTask = SendWithTransactionAsync();
                Task noTransactionTask = SendWithoutTransactionAsync();

                async Task SendWithTransactionAsync()
                {
                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        if (!transactionFirst)
                        {
                            await tcs.Task;
                        }
                        await receiver.CompleteMessageAsync(receivedMessage).ConfigureAwait(false);
                        if (transactionFirst)
                        {
                            tcs.SetResult(true);
                        }

                        await sender1.SendMessageAsync(message).ConfigureAwait(false);
                        await sender1.SendMessageAsync(message).ConfigureAwait(false);
                        ts.Complete();
                    }
                }

                async Task SendWithoutTransactionAsync()
                {
                    // await the TCS so that we can attempt to call Send from both inside the txn and outside at the same time
                    if (transactionFirst)
                    {
                        await tcs.Task;
                    }
                    Assert.IsNull(Transaction.Current);
                    await sender1.SendMessageAsync(message).ConfigureAwait(false);
                    if (!transactionFirst)
                    {
                        tcs.SetResult(true);
                    }
                    Assert.IsNull(Transaction.Current);
                    await sender2.SendMessageAsync(message).ConfigureAwait(false);
                }

                // make sure tasks are completed to surface any exceptions
                await noTransactionTask;
                await transactionTask;
            }
        }

        [Test]
        public async Task TransactionCommitThrowsUsingDifferentClientsToSameEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client1 = CreateClient();
                ServiceBusSender sender = client1.CreateSender(scope.QueueName);
                await using var client2 = CreateClient();
                ServiceBusReceiver receiver = client2.CreateReceiver(scope.QueueName);

                ServiceBusMessage message1 = ServiceBusTestUtilities.GetMessage();
                ServiceBusMessage message2 = ServiceBusTestUtilities.GetMessage();
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
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);

                ServiceBusMessage message1 = ServiceBusTestUtilities.GetMessage();
                ServiceBusMessage message2 = ServiceBusTestUtilities.GetMessage();
                await sender.SendMessageAsync(message1);

                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.NotNull(receivedMessage);
                Assert.AreEqual(message1.Body.ToString(), receivedMessage.Body.ToString());

                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(receivedMessage);
                    await sender.SendMessageAsync(message2);
                }

                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                // Operating on the same message should not be done.
                await Task.Delay(TimeSpan.FromSeconds(2));

                // Following should succeed without exceptions
                await receiver.CompleteMessageAsync(receivedMessage);

                // Assert that send failed
                receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                Assert.Null(receivedMessage);
            }
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        public async Task CrossEntityTransactionReceivesFirst(bool partitioned, bool enableSessions)
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: enableSessions);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: enableSessions);
            await using var topicC = await ServiceBusScope.CreateWithTopic(enablePartitioning: partitioned, enableSession: enableSessions);

            await using var noTxClient = CreateClient();
            var senderA = noTxClient.CreateSender(queueA.QueueName);

            ServiceBusReceiver receiverA = null;
            if (!enableSessions)
            {
                receiverA = client.CreateReceiver(queueA.QueueName);
            }
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(topicC.TopicName);

            var message = new ServiceBusMessage
            {
                SessionId = enableSessions ? "sessionId" : null,
                TransactionPartitionKey = partitioned ? "sessionId" : null
            };

            await senderA.SendMessageAsync(message);

            if (enableSessions)
            {
                receiverA = await client.AcceptNextSessionAsync(queueA.QueueName);
            }

            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            // If the transaction succeeds, then all the operations occurred on the same partition.
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }

            receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNull(receivedMessage);
        }

       [Test]
        public async Task CrossEntityTransactionReceivesFirstRollbackSubscription()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var topicA = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var noTxClient = CreateClient();
            var senderA = noTxClient.CreateSender(topicA.TopicName);
            var receiverA = client.CreateReceiver(topicA.TopicName, topicA.SubscriptionNames.First());
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);

            var message = new ServiceBusMessage();

            await senderA.SendMessageAsync(message);
            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
            }
            await receiverA.AbandonMessageAsync(receivedMessage);

            // transaction wasn't committed - verify that it was rolled back
            receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
            await receiverA.AbandonMessageAsync(receivedMessage);

            var receiverB = noTxClient.CreateReceiver(queueB.QueueName);

            receivedMessage = await receiverB.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            Assert.IsNull(receivedMessage);

            var receiverC = noTxClient.CreateReceiver(queueC.QueueName);
            receivedMessage = await receiverC.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            Assert.IsNull(receivedMessage);

            receivedMessage = await receiverA.ReceiveMessageAsync();

            // now commit the transaction
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }
            receivedMessage = await receiverA.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            Assert.IsNull(receivedMessage);
            receivedMessage = await receiverB.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
            receivedMessage = await receiverC.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
        }

        [Test]
        public async Task CrossEntityTransactionReceivesFirstRollback()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var topicC = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false);
            await using var noTxClient = CreateClient();
            var senderA = noTxClient.CreateSender(queueA.QueueName);
            var receiverA = client.CreateReceiver(queueA.QueueName);
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(topicC.TopicName);

            var message = new ServiceBusMessage();

            await senderA.SendMessageAsync(message);
            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
            }
            await receiverA.AbandonMessageAsync(receivedMessage);

            // transaction wasn't committed - verify that it was rolled back
            receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
            await receiverA.AbandonMessageAsync(receivedMessage);

            var receiverB = noTxClient.CreateReceiver(queueB.QueueName);

            receivedMessage = await receiverB.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            Assert.IsNull(receivedMessage);

            var receiverC = noTxClient.CreateReceiver(topicC.TopicName, topicC.SubscriptionNames.First());
            receivedMessage = await receiverC.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            Assert.IsNull(receivedMessage);

            receivedMessage = await receiverA.ReceiveMessageAsync();

            // now commit the transaction
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }
            receivedMessage = await receiverA.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            Assert.IsNull(receivedMessage);
            receivedMessage = await receiverB.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
            receivedMessage = await receiverC.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
        }

        [Test]
        public async Task CrossEntityTransactionFirstOperationTransacted()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            var senderA = client.CreateSender(queueA.QueueName);
            var senderB = client.CreateSender(queueB.QueueName);

            var message = new ServiceBusMessage();

            // the first operation on any link is part of a transaction
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await senderA.SendMessageAsync(message);
                await senderB.SendMessageAsync(message);
            }
        }

        [Test]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public async Task CrossEntityTransactionSendsFirst(bool partitioned, bool enableSessions)
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: enableSessions);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: enableSessions);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: partitioned, enableSession: enableSessions);

            await using var noTxClient = CreateClient();

            var senderA = noTxClient.CreateSender(queueA.QueueName);
            ServiceBusReceiver receiverA = null;
            ServiceBusReceiver receiverB = null;
            ServiceBusReceiver receiverC = null;

            if (!enableSessions)
            {
                receiverA = client.CreateReceiver(queueA.QueueName);
                receiverB = client.CreateReceiver(queueB.QueueName);
                receiverC = noTxClient.CreateReceiver(queueC.QueueName);
            }
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);

            var message = new ServiceBusMessage
            {
                SessionId = enableSessions ? "sessionId" : null,
                TransactionPartitionKey = partitioned ? "sessionId" : null
            };

            // B is the send via entity since it is first
            await senderB.SendMessageAsync(message);
            await senderA.SendMessageAsync(message);

            if (enableSessions)
            {
                // you can't use a receiver after a sender (for a different entity) when using a Transaction Group because it would be
                // saying that you want to receive via the sender entity which isn't possible

                Assert.ThrowsAsync<InvalidOperationException>(
                    async () =>
                    await client.AcceptNextSessionAsync(queueA.QueueName));

                receiverB = await client.AcceptNextSessionAsync(queueB.QueueName);
            }
            else
            {
                Assert.ThrowsAsync<InvalidOperationException>(async () => await receiverA.ReceiveMessageAsync());
            }
            // After the above throws, the session gets closed by the AMQP lib, so we are testing whether the fault tolerant session/controller
            // objects get re-created correctly.

            ServiceBusReceivedMessage receivedMessageB = await receiverB.ReceiveMessageAsync();

            // If the transaction succeeds, then all the operations occurred on the same partition.
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // this is allowed because it is on B
                await receiverB.CompleteMessageAsync(receivedMessageB);

                // send to C via B - this is allowed because we are sending
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }

            if (enableSessions)
            {
                receiverC = await noTxClient.AcceptNextSessionAsync(queueC.QueueName);
            }

            var receivedMessageC = await receiverC.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessageC);

            receivedMessageB = await receiverB.ReceiveMessageAsync();
            Assert.IsNull(receivedMessageB);

            await senderB.SendMessageAsync(message);
            // If the transaction succeeds, then all the operations occurred on the same partition.
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                receivedMessageB = await receiverB.ReceiveMessageAsync();
                // this is allowed because it is on B
                await receiverB.CompleteMessageAsync(receivedMessageB);

                // this will fail because it is not part of txn group
                Assert.ThrowsAsync<ServiceBusException>(async () => await senderA.SendMessageAsync(message));

                ts.Complete();
            }
        }

        [Test]
        public async Task CrossEntityTransactionSendsFirstRollback()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var noTxClient = CreateClient();
            var senderA = noTxClient.CreateSender(queueA.QueueName);
            var receiverA = client.CreateReceiver(queueA.QueueName);
            var receiverB = client.CreateReceiver(queueB.QueueName);
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);
            var receiverC = noTxClient.CreateReceiver(queueC.QueueName);

            var message = new ServiceBusMessage();

            // B is the send via entity since it is first
            await senderB.SendMessageAsync(message);
            await senderA.SendMessageAsync(message);

            // you can't use a receiver after a sender (for a different entity) when using a Transaction Group because it would be
            // saying that you want to receive via the sender entity which isn't possible

            Assert.ThrowsAsync<InvalidOperationException>(async () => await receiverA.ReceiveMessageAsync());

            // After the above throws, the session gets closed by the AMQP lib, so we are testing whether the fault tolerant session/controller
            // objects get re-created correctly.

            ServiceBusReceivedMessage receivedMessageB = await receiverB.ReceiveMessageAsync();

            // If the transaction succeeds, then all the operations occurred on the same partition.
            var transaction = new CommittableTransaction();

            using (var ts = new TransactionScope(transaction, TransactionScopeAsyncFlowOption.Enabled))
            {
                // this is allowed because it is on B
                await receiverB.CompleteMessageAsync(receivedMessageB);

                // send to C via B - this is allowed because we are sending
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }
            transaction.Rollback();
            // Adding delay since transaction Commit/Rollback is an asynchronous operation.
            await Task.Delay(TimeSpan.FromSeconds(2));
            await receiverB.AbandonMessageAsync(receivedMessageB);
            receivedMessageB = await receiverB.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessageB);
            await receiverB.AbandonMessageAsync(receivedMessageB);

            var receivedMessageC = await receiverC.ReceiveMessageAsync();
            Assert.IsNull(receivedMessageC);

            // If the transaction succeeds, then all the operations occurred on the same partition.
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                receivedMessageB = await receiverB.ReceiveMessageAsync();
                // this is allowed because it is on B
                await receiverB.CompleteMessageAsync(receivedMessageB);

                // this will fail because it is not part of txn group
                Assert.ThrowsAsync<ServiceBusException>(async () => await senderA.SendMessageAsync(message));

                ts.Complete();
            }

            receivedMessageB = await receiverB.ReceiveMessageAsync();
            Assert.IsNull(receivedMessageB);
        }

        [Test]
        public async Task CrossEntityTransactionProcessorRollback()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            var senderA = client.CreateSender(queueA.QueueName);
            await using var processorA = client.CreateProcessor(queueA.QueueName);

            var receiverA = client.CreateReceiver(queueA.QueueName);
            var receiverB = client.CreateReceiver(queueB.QueueName);
            var receiverC = client.CreateReceiver(queueC.QueueName);

            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);

            var message = new ServiceBusMessage();

            await senderA.SendMessageAsync(message);

            processorA.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

            var tcs = new TaskCompletionSource<bool>();
            processorA.ProcessMessageAsync += async args =>
            {
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await args.CompleteMessageAsync(args.Message);
                    await senderB.SendMessageAsync(message);
                    await senderC.SendMessageAsync(message);
                }
                await args.AbandonMessageAsync(args.Message);
                tcs.TrySetResult(true);
            };

            await processorA.StartProcessingAsync();
            await tcs.Task;
            await processorA.StopProcessingAsync();

            // transaction wasn't committed - verify that it was rolled back
            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
        }

        [Test]
        public async Task CrossEntityTransactionProcessor()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var noTxClient = CreateClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            var senderA = noTxClient.CreateSender(queueA.QueueName);
            await using var processorA = client.CreateProcessor(queueA.QueueName);

            var receiverA = noTxClient.CreateReceiver(queueA.QueueName);
            var receiverB = noTxClient.CreateReceiver(queueB.QueueName);
            var receiverC = noTxClient.CreateReceiver(queueC.QueueName);

            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);

            var message = new ServiceBusMessage();

            await senderA.SendMessageAsync(message);

            processorA.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

            var tcs = new TaskCompletionSource<bool>();
            processorA.ProcessMessageAsync += async args =>
            {
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await args.CompleteMessageAsync(args.Message);
                    await senderB.SendMessageAsync(message);
                    await senderC.SendMessageAsync(message);
                    ts.Complete();
                }
                tcs.TrySetResult(true);
            };

            await processorA.StartProcessingAsync();
            await tcs.Task;
            await processorA.StopProcessingAsync();

            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNull(receivedMessage);

            receivedMessage = await receiverB.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);

            receivedMessage = await receiverC.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
        }

        [Test]
        public async Task CrossEntityTransactionSessionProcessorRollback()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            var senderA = client.CreateSender(queueA.QueueName);
            await using var processorA = client.CreateSessionProcessor(queueA.QueueName);
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);

            var message = new ServiceBusMessage
            {
                SessionId = "sessionId"
            };

            await senderA.SendMessageAsync(message);

            processorA.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

            var tcs = new TaskCompletionSource<bool>();
            processorA.ProcessMessageAsync += async args =>
            {
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await args.CompleteMessageAsync(args.Message);
                    await senderB.SendMessageAsync(message);
                    await senderC.SendMessageAsync(message);
                }
                tcs.TrySetResult(true);
            };

            await processorA.StartProcessingAsync();
            await tcs.Task;
            // close rather than just stop because we want the session link to be closed
            await processorA.CloseAsync();

            // transaction wasn't committed - verify that it was rolled back
            ServiceBusSessionReceiver receiverA = await client.AcceptNextSessionAsync(queueA.QueueName);
            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNotNull(receivedMessage);
        }

        [Test]
        public async Task CrossEntityTransactionSessionProcessor()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            await using var queueC = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            await using var noTxClient = CreateNoRetryClient();
            var senderA = noTxClient.CreateSender(queueA.QueueName);

            await using var processorA = client.CreateSessionProcessor(queueA.QueueName);
            var senderB = client.CreateSender(queueB.QueueName);
            var senderC = client.CreateSender(queueC.QueueName);

            var message = new ServiceBusMessage
            {
                SessionId = "sessionId"
            };

            await senderA.SendMessageAsync(message);

            processorA.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;

            var tcs = new TaskCompletionSource<bool>();
            processorA.ProcessMessageAsync += async args =>
            {
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await args.CompleteMessageAsync(args.Message);
                    await senderB.SendMessageAsync(message);
                    await senderC.SendMessageAsync(message);
                    ts.Complete();
                }
                tcs.TrySetResult(true);
            };

            await processorA.StartProcessingAsync();
            await tcs.Task;
            // close rather than just stop because we want the session link to be closed
            await processorA.CloseAsync();

            // this should timeout as the session message was completed
            Assert.ThrowsAsync<ServiceBusException>(
                async () => await noTxClient.AcceptNextSessionAsync(queueA.QueueName));

            // should not throw
            _ = await noTxClient.AcceptNextSessionAsync(queueB.QueueName);
            _ = await noTxClient.AcceptNextSessionAsync(queueC.QueueName);
        }

        [Test]
        public async Task CrossEntityTransactionConnectionDropped()
        {
            await using var client = CreateCrossEntityTxnClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);

            await using var noTxClient = CreateNoRetryClient();
            var senderA = noTxClient.CreateSender(queueA.QueueName);
            await senderA.SendMessageAsync(new ServiceBusMessage());

            var receiverA = client.CreateReceiver(queueA.QueueName);
            var senderB = client.CreateSender(queueB.QueueName);

            var receivedMessage = await receiverA.ReceiveMessageAsync();
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);

                SimulateNetworkFailure(client);
                Assert.That(
                    async () => await senderB.SendMessageAsync(new ServiceBusMessage()),
                    Throws.InstanceOf<InvalidOperationException>());
            }

            // allow enough time for the service to discard the transaction
            receivedMessage = await receiverA.ReceiveMessageAsync(TimeSpan.FromSeconds(200));
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(new ServiceBusMessage());
                ts.Complete();
            }

            var receiverB = noTxClient.CreateReceiver(queueB.QueueName);
            Assert.IsNotNull(await receiverB.ReceiveMessageAsync());
        }

        private ServiceBusClient CreateCrossEntityTxnClient() =>
            new ServiceBusClient(
                TestEnvironment.FullyQualifiedNamespace,
                TestEnvironment.Credential,
                new ServiceBusClientOptions
                {
                    EnableCrossEntityTransactions = true,
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(15)
                    }
                });
    }
}
