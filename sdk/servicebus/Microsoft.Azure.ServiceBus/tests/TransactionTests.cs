// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;
    using Core;
    using Xunit;

    public class TransactionTests
    {
        static readonly string ConnectionString = TestUtility.NamespaceConnectionString;
        static readonly TimeSpan ReceiveTimeout = TimeSpan.FromSeconds(5);

        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedQueue, useSessionQueue }
            new object[] { false, false },
            new object[] { true, false }
        };

        public static IEnumerable<object[]> SessionTestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedQueue, useSessionQueue }
            new object[] { false, true },
            new object[] { true, true }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalSendCommitTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var receiver = new MessageReceiver(ConnectionString, queueName);

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message = new Message(body.GetBytes()) {PartitionKey = "pk"};
                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await sender.SendAsync(message).ConfigureAwait(false);
                        ts.Complete();
                    }

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);

                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body, receivedMessage.Body.GetString());
                    await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalSendRollbackTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var receiver = new MessageReceiver(ConnectionString, queueName);

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message = new Message(body.GetBytes()) { PartitionKey = "pk" };
                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await sender.SendAsync(message).ConfigureAwait(false);
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.Null(receivedMessage);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalCompleteCommitTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var receiver = new MessageReceiver(ConnectionString, queueName);

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message = new Message(body.GetBytes());
                    await sender.SendAsync(message).ConfigureAwait(false);

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body, receivedMessage.Body.GetString());

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                        ts.Complete();
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await Assert.ThrowsAsync<MessageLockLostException>(async () => await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken));
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalCompleteRollbackTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var receiver = new MessageReceiver(ConnectionString, queueName);

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message = new Message(body.GetBytes());
                    await sender.SendAsync(message).ConfigureAwait(false);

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body, receivedMessage.Body.GetString());

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(SessionTestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalSessionDispositionTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var sessionClient = new SessionClient(ConnectionString, queueName);
                IMessageSession receiver = null;

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message = new Message(body.GetBytes())
                    {
                        SessionId = body
                    };
                    await sender.SendAsync(message).ConfigureAwait(false);

                    receiver = await sessionClient.AcceptMessageSessionAsync(body);

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body, receivedMessage.Body.GetString());

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                        ts.Complete();
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await Assert.ThrowsAsync<SessionLockLostException>(async () => await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken));
                }
                finally
                {
                    await sender.CloseAsync();
                    await sessionClient.CloseAsync();
                    await receiver?.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalRequestResponseDispositionTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var receiver = new MessageReceiver(ConnectionString, queueName);

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message = new Message(body.GetBytes());
                    await sender.SendAsync(message).ConfigureAwait(false);

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body, receivedMessage.Body.GetString());
                    var sequenceNumber = receivedMessage.SystemProperties.SequenceNumber;
                    await receiver.DeferAsync(receivedMessage.SystemProperties.LockToken);

                    var deferredMessage = await receiver.ReceiveDeferredMessageAsync(sequenceNumber);

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(deferredMessage.SystemProperties.LockToken);
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(deferredMessage.SystemProperties.LockToken);
                        ts.Complete();
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await Assert.ThrowsAsync<MessageLockLostException>(async () => await receiver.CompleteAsync(deferredMessage.SystemProperties.LockToken));
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionThrowsWhenOperationsOfDifferentPartitionsAreInSameTransaction()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(ConnectionString, queueName);
                var receiver = new MessageReceiver(ConnectionString, queueName);

                try
                {
                    string body = Guid.NewGuid().ToString("N");
                    var message1 = new Message((body + "1").GetBytes())
                    {
                        PartitionKey = "1"
                    };
                    var message2 = new Message((body + "2").GetBytes())
                    {
                        PartitionKey = "2"
                    };

                    // Two send operations to different partitions.
                    var transaction = new CommittableTransaction();
                    using (TransactionScope ts = new TransactionScope(transaction, TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await sender.SendAsync(message1);

                        await Assert.ThrowsAsync<InvalidOperationException>(
                            async () => await sender.SendAsync(message2));
                        ts.Complete();
                    }

                    transaction.Rollback();

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    // Two complete operations to different partitions.
                    await sender.SendAsync(message1);
                    await sender.SendAsync(message2);

                    var receivedMessage1 = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage1);
                    var receivedMessage2 = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage2);

                    transaction = new CommittableTransaction();
                    using (TransactionScope ts = new TransactionScope(transaction, TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage1.SystemProperties.LockToken);

                        await Assert.ThrowsAsync<InvalidOperationException>(
                            async () => await receiver.CompleteAsync(receivedMessage2.SystemProperties.LockToken));
                        ts.Complete();
                    }

                    transaction.Rollback();

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await receiver.CompleteAsync(receivedMessage1.SystemProperties.LockToken);
                    await receiver.CompleteAsync(receivedMessage2.SystemProperties.LockToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionCommitWorksAcrossClientsUsingSameConnectionToSameEntity()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var connection = new ServiceBusConnection(ConnectionString);
                var sender = new MessageSender(connection, queueName);
                var receiver = new MessageReceiver(connection, queueName);

                try
                {
                    string body1 = Guid.NewGuid().ToString("N");
                    string body2 = Guid.NewGuid().ToString("N");
                    var message = new Message(body1.GetBytes());
                    var message2 = new Message(body2.GetBytes());
                    await sender.SendAsync(message).ConfigureAwait(false);

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body1, receivedMessage.Body.GetString());

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                        await sender.SendAsync(message2).ConfigureAwait(false);
                        ts.Complete();
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    // Assert that complete did succeed
                    await Assert.ThrowsAsync<MessageLockLostException>(async () => await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken));

                    // Assert that send did succeed
                    receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body2, receivedMessage.Body.GetString());
                    await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                    await connection.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionRollbackWorksAcrossClientsUsingSameConnectionToSameEntity()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var connection = new ServiceBusConnection(ConnectionString);
                var sender = new MessageSender(connection, queueName);
                var receiver = new MessageReceiver(connection, queueName);

                try
                {
                    string body1 = Guid.NewGuid().ToString("N");
                    string body2 = Guid.NewGuid().ToString("N");
                    var message = new Message(body1.GetBytes());
                    var message2 = new Message(body2.GetBytes());
                    await sender.SendAsync(message).ConfigureAwait(false);

                    var receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.NotNull(receivedMessage);
                    Assert.Equal(body1, receivedMessage.Body.GetString());

                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                        await sender.SendAsync(message2).ConfigureAwait(false);
                    }

                    // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                    // Operating on the same message should not be done.
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    // Following should succeed without exceptions
                    await receiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);

                    // Assert that send failed
                    receivedMessage = await receiver.ReceiveAsync(ReceiveTimeout);
                    Assert.Null(receivedMessage);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                    await connection.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TransactionalSendViaCommitTest()
        {
            var connection = new ServiceBusConnection(ConnectionString);

            var intermediateQueue = default(ServiceBusScope.QueueScope);
            var destination1 = default(ServiceBusScope.TopicScope);
            var destination2 = default(ServiceBusScope.QueueScope);
            var intermediateSender = default(MessageSender);
            var intermediateReceiver = default(MessageReceiver);
            var destination1Sender = default(MessageSender);
            var destination1ViaSender = default(MessageSender);
            var destination2ViaSender = default(MessageSender);
            var destination1Receiver = default(MessageReceiver);
            var destination2Receiver = default(MessageReceiver);

            try
            {
                intermediateQueue = await ServiceBusScope.CreateQueueAsync(partitioned: true, sessionEnabled: false);
                destination1 = await ServiceBusScope.CreateTopicAsync(partitioned: true, sessionEnabled: false);
                destination2 = await ServiceBusScope.CreateQueueAsync(partitioned: false, sessionEnabled: false);

                var intermediateQueueName = intermediateQueue.Name;
                var destination1Name = destination1.TopicName;
                var destination1ReceiverName = EntityNameHelper.FormatSubscriptionPath(destination1.TopicName, destination1.SubscriptionName);
                var destination2Name = destination2.Name;
                var destination2ReceiverName = destination2.Name;

                intermediateSender = new MessageSender(connection, intermediateQueueName);
                intermediateReceiver = new MessageReceiver(connection, intermediateQueueName);
                destination1Sender = new MessageSender(connection, destination1Name);
                destination1ViaSender = new MessageSender(connection, destination1Name, intermediateQueueName);
                destination2ViaSender = new MessageSender(connection, destination2Name, intermediateQueueName);
                destination1Receiver = new MessageReceiver(connection, destination1ReceiverName);
                destination2Receiver = new MessageReceiver(connection, destination2ReceiverName);

                var body = Guid.NewGuid().ToString("N");
                var message1 = new Message(body.GetBytes()) { MessageId = "1", PartitionKey = "pk1" };
                var message2 = new Message(body.GetBytes()) { MessageId = "2", PartitionKey = "pk2", ViaPartitionKey = "pk1" };
                var message3 = new Message(body.GetBytes()) { MessageId = "3", PartitionKey = "pk3", ViaPartitionKey = "pk1" };

                await intermediateSender.SendAsync(message1).ConfigureAwait(false);
                var receivedMessage = await intermediateReceiver.ReceiveAsync();
                Assert.NotNull(receivedMessage);
                Assert.Equal("pk1", receivedMessage.PartitionKey);

                // If the transaction succeeds, then all the operations occurred on the same partition.
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await intermediateReceiver.CompleteAsync(receivedMessage.SystemProperties.LockToken);
                    await destination1ViaSender.SendAsync(message2);
                    await destination2ViaSender.SendAsync(message3);
                    ts.Complete();
                }

                // Assert that first message indeed completed.
                receivedMessage = await intermediateReceiver.ReceiveAsync(ReceiveTimeout);
                Assert.Null(receivedMessage);

                // Assert that second message reached its destination.
                var receivedMessage1 = await destination1Receiver.ReceiveAsync();
                Assert.NotNull(receivedMessage1);
                Assert.Equal("pk2", receivedMessage1.PartitionKey);

                // Assert destination1 message actually used partitionKey in the destination entity.
                var destination1Message = new Message(body.GetBytes())
                {
                    PartitionKey = "pk2"
                };
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await destination1Receiver.CompleteAsync(receivedMessage1.SystemProperties.LockToken);
                    await destination1Sender.SendAsync(destination1Message);
                    ts.Complete();
                }

                // Assert that third message reached its destination.
                var receivedMessage2 = await destination2Receiver.ReceiveAsync();
                Assert.NotNull(receivedMessage2);
                Assert.Equal("pk3", receivedMessage2.PartitionKey);
                await destination2Receiver.CompleteAsync(receivedMessage2.SystemProperties.LockToken);

                // Cleanup
                receivedMessage1 = await destination1Receiver.ReceiveAsync();
                await destination1Receiver.CompleteAsync(receivedMessage1.SystemProperties.LockToken);
            }
            finally
            {
                // The cleanup methods will not throw and are safe to call outside of a try/catch.  They
                // also have no dependencies on execution order, so allowing them to run in parallel is fine.
                await Task.WhenAll(
                    SafeCloseAllAsync(intermediateSender, intermediateReceiver, destination1Sender, destination1ViaSender, destination2ViaSender, destination1Receiver, destination2Receiver),
                    intermediateQueue?.CleanupAsync(),
                    destination1?.CleanupAsync(),
                    destination2?.CleanupAsync());
            }
        }

        private Task SafeCloseAllAsync(params IClientEntity[] clientEntities)
        {
            async Task closeEntity(IClientEntity entity)
            {
                try { await entity.CloseAsync(); }  catch {}
            };

            return Task.WhenAll(clientEntities.Select(entity => closeEntity(entity)));
        }
    }
}
