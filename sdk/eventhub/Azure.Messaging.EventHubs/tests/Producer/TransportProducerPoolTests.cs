// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TransportProducerPool" /> class.
    /// </summary>
    ///
    [TestFixture]
    public class TransportProducerPoolTests
    {
        /// <summary>
        ///   The pool periodically removes and closes expired items.
        /// </summary>
        ///
        [Test]
        public void TransportProducerPoolRemovesExpiredItems()
        {
            var transportProducer = new ObservableTransportProducerMock();
            DateTimeOffset oneMinuteAgo = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1));
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                // An expired item in the pool
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer, removeAfter: oneMinuteAgo),
                ["1"] = new TransportProducerPool.PoolItem("0", transportProducer),
                ["2"] = new TransportProducerPool.PoolItem("0", transportProducer),
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(transportProducer, startingPool);

            GetExpirationCallBack(transportProducerPool).Invoke(null);

            Assert.IsFalse(startingPool.TryGetValue("0", out _), "PerformExpiration should remove an expired producer from the pool.");
            Assert.AreEqual(transportProducer.CloseCallCount, 1, "PerformExpiration should close an expired producer.");
            Assert.IsTrue(startingPool.TryGetValue("1", out _), "PerformExpiration should not remove valid producers.");
            Assert.IsTrue(startingPool.TryGetValue("2", out _), "PerformExpiration should not remove valid producers.");
        }

        /// <summary>
        ///   When a <see cref="TransportProducerPool.PoolItem" /> is requested
        ///   its <see cref="TransportProducerPool.PoolItem.RemoveAfter" /> will be increased.
        /// </summary>
        ///
        [Test]
        public void TransportProducerPoolRefreshesAccessedItems()
        {
            DateTimeOffset oneMinuteAgo = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1));
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                // An expired item in the pool
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer, removeAfter: oneMinuteAgo)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(transportProducer, startingPool);

            // This call should refresh the timespan associated to the item
            _ = transportProducerPool.GetPooledProducer("0", connection, retryPolicy);

            // The expiration call back should not remove the item
            GetExpirationCallBack(transportProducerPool).Invoke(null);

            Assert.IsTrue(startingPool.TryGetValue("0", out _), "The item in the pool should be refreshed and not have been removed.");
        }

        /// <summary>
        ///   When a <see cref="TransportProducerPool.PooledProducer" /> is disposed, the <see cref="TimeSpan"/>
        ///   of the associated <see cref="TransportProducerPool.PoolItem" /> is increased.
        /// </summary>
        ///
        [Test]
        public async Task PoolItemsAreRefreshedOnDisposal()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(transportProducer);
            var connection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var expectedTime = DateTimeOffset.UtcNow.AddMinutes(10);
            var expectedRemoveAfter = Is.InRange(expectedTime.AddMinutes(-1), expectedTime.AddMinutes(1));

            await using var pooledProducer = transportProducerPool.GetPooledProducer("0", connection, retryPolicy);

            // This call should refresh the timespan associated to an item in the pool
            await pooledProducer.DisposeAsync();

            Assert.That(startingPool["0"].RemoveAfter, expectedRemoveAfter, $"The remove after of a pool item should be extended.");
        }

        /// <summary>
        ///   When a partition producer is requested its expiration time will be increased.
        /// </summary>
        ///
        [Test]
        public async Task TransportProducerPoolTracksAProducerUsage()
        {
            DateTimeOffset oneMinuteAgo = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1));
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                // An expired item in the pool
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer, removeAfter: oneMinuteAgo)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(transportProducer, startingPool);

            var pooledProducer = transportProducerPool.GetPooledProducer("0", connection, retryPolicy);
            startingPool.TryGetValue("0", out var poolItem);

            await using (pooledProducer)
            {
                Assert.IsTrue(poolItem.ActiveInstances.Count == 1, "The usage of a transport producer should be tracked.");
            }

            Assert.IsTrue(poolItem.ActiveInstances.Count == 0, "After usage an active instance should be removed from the pool.");
        }

        /// <summary>
        ///   It is possible to configure how long a <see cref="TransportProducerPool.PoolItem" /> should sit in memory.
        /// </summary>
        ///
        [Test]
        public async Task TransportProducerPoolAllowsConfiguringRemoveAfter()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(transportProducer, startingPool);

            var pooledProducer = transportProducerPool.GetPooledProducer("0", connection, retryPolicy, TimeSpan.FromMinutes(-1));

            await using (var _ = pooledProducer.ConfigureAwait(false))
            {
            };

            GetExpirationCallBack(transportProducerPool).Invoke(null);

            Assert.That(transportProducer.CloseCallCount == 1);
        }

        /// <summary>
        ///   The <see cref="TransportProducerPool"/> returns the right <see cref="TransportProducer" />
        ///   matching the righ partition id.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("0")]
        public void TransportProducerPoolAllowsTakingTheRightTransportProducer(string partitionId)
        {
            var transportProducer = new ObservableTransportProducerMock(partitionId);
            var partitionProducer = new ObservableTransportProducerMock(partitionId);
            var connection = new MockConnection(() => partitionProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", partitionProducer)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(transportProducer, startingPool);

            var returnedProducer = transportProducerPool.GetTransportProducer(partitionId) as ObservableTransportProducerMock;

            Assert.That(returnedProducer.PartitionId == partitionId);
        }

        /// <summary>
        ///   Gets the routine responsible of finding expired producers.
        /// </summary>
        ///
        private static TimerCallback GetExpirationCallBack(TransportProducerPool pool) =>
            (TimerCallback)
                typeof(TransportProducerPool)
                    .GetMethod("PerformExpiration", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(pool, null);

        /// <summary>
        ///   Serves as a non-functional connection for testing producer functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public EventHubsRetryPolicy GetPropertiesInvokedWith = null;
            public EventHubsRetryPolicy GetPartitionIdsInvokedWith = null;
            public EventHubsRetryPolicy GetPartitionPropertiesInvokedWith = null;
            public Func<TransportProducer> TransportProducerFactory = () => Mock.Of<TransportProducer>();

            public bool WasClosed = false;

            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net").Object)
            {
            }

            public MockConnection(Func<TransportProducer> transportProducerFactory,
                                  string namespaceName,
                                  string eventHubName) : this(namespaceName, eventHubName)
            {
                TransportProducerFactory = transportProducerFactory;
            }

            public MockConnection(Func<TransportProducer> transportProducerFactory) : this(transportProducerFactory, "fakeNamespace", "fakeEventHub")
            {
            }

            internal override Task<EventHubProperties> GetPropertiesAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(new EventHubProperties(EventHubName, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), new string[] { "0", "1" }));
            }

            internal async override Task<string[]> GetPartitionIdsAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPartitionIdsInvokedWith = retryPolicy;
                return await base.GetPartitionIdsAsync(retryPolicy, cancellationToken);
            }

            internal override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    EventHubsRetryPolicy retryPolicy,
                                                                                    CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(default(PartitionProperties));
            }

            internal override TransportProducer CreateTransportProducer(string partitionId,
                                                                        EventHubsRetryPolicy retryPolicy) => TransportProducerFactory();

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, EventHubTokenCredential credential, EventHubConnectionOptions options)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace }.com/{ eventHubName }"));

                return client.Object;
            }
        }

        private class DelayedObservableTransportProducerMock : ObservableTransportProducerMock
        {
            public override async Task SendAsync(IEnumerable<EventData> events, SendEventOptions sendOptions, CancellationToken cancellationToken)
            {
                await Task.Delay(3000);

                await base.SendAsync(events, sendOptions, cancellationToken);
            }

            public override async Task SendAsync(EventDataBatch batch, CancellationToken cancellationToken)
            {
                await Task.Delay(3000);

                await base.SendAsync(batch, cancellationToken);
            }
        }

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportProducerMock : TransportProducer
        {
            public int CloseCallCount = 0;
            public bool WasCloseCalled = false;
            public (IEnumerable<EventData>, SendEventOptions) SendCalledWith;
            public EventDataBatch SendBatchCalledWith;
            public CreateBatchOptions CreateBatchCalledWith;
            public string PartitionId { get; set; }

            public ObservableTransportProducerMock(string partitionId = default)
            {
                PartitionId = partitionId;
            }

            public override Task SendAsync(IEnumerable<EventData> events,
                                           SendEventOptions sendOptions,
                                           CancellationToken cancellationToken)
            {
                SendCalledWith = (events, sendOptions);
                return Task.CompletedTask;
            }

            public override Task SendAsync(EventDataBatch batch,
                                           CancellationToken cancellationToken)
            {
                SendBatchCalledWith = batch;
                return Task.CompletedTask;
            }

            public override ValueTask<TransportEventBatch> CreateBatchAsync(CreateBatchOptions options,
                                                                            CancellationToken cancellationToken)
            {
                CreateBatchCalledWith = options;
                return new ValueTask<TransportEventBatch>(Task.FromResult((TransportEventBatch)new MockTransportBatch()));
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                ++CloseCallCount;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        ///   Serves as a non-functional transport event batch for satisfying the
        ///   non-null constraints of the <see cref="EventDataBatch" /> created by
        ///   the producer being tested.
        /// </summary>
        ///
        private class MockTransportBatch : TransportEventBatch
        {
            public override long MaximumSizeInBytes { get; }
            public override long SizeInBytes { get; }
            public override int Count { get; }
            public override bool TryAdd(EventData eventData) => throw new NotImplementedException();
            public override IEnumerable<T> AsEnumerable<T>() => throw new NotImplementedException();
            public override void Dispose() => throw new NotImplementedException();
        }
    }
}
