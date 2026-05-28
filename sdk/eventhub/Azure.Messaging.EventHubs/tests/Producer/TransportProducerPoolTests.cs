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
            var connection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            DateTimeOffset oneMinuteAgo = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1));
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                // An expired item in the pool
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer, removeAfter: oneMinuteAgo),
                ["1"] = new TransportProducerPool.PoolItem("0", transportProducer),
                ["2"] = new TransportProducerPool.PoolItem("0", transportProducer),
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), startingPool);

            GetExpirationCallBack(transportProducerPool).Invoke(null);

            Assert.That(startingPool.TryGetValue("0", out _), Is.False, "PerformExpiration should remove an expired producer from the pool.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(1), "PerformExpiration should close an expired producer.");
            Assert.That(startingPool.TryGetValue("1", out _), Is.True, "PerformExpiration should not remove valid producers.");
            Assert.That(startingPool.TryGetValue("2", out _), Is.True, "PerformExpiration should not remove valid producers.");
        }

        /// <summary>
        ///   The pool periodically removes and closes expired items.
        /// </summary>
        ///
        [Test]
        public async Task ExpireRemovesTheRequestedItem()
        {
            var wasFactoryCalled = false;
            var transportProducer = new ObservableTransportProducerMock();

            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer),
                ["1"] = new TransportProducerPool.PoolItem("1", transportProducer),
                ["2"] = new TransportProducerPool.PoolItem("2", transportProducer),
            };

            Func<string, TransportProducer> producerFactory = partition =>
            {
                wasFactoryCalled = true;
                return transportProducer;
            };

            var transportProducerPool = new TransportProducerPool(producerFactory, pool: startingPool, eventHubProducer: transportProducer);

            // Validate the initial state.

            Assert.That(startingPool.TryGetValue("0", out _), Is.True, "The requested partition should appear in the pool.");
            Assert.That(wasFactoryCalled, Is.False, "No producer should not have been created.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(0), "The producer should not have been closed.");

            // Expire the producer and validate the removal state.

            await transportProducerPool.ExpirePooledProducerAsync("0");

            Assert.That(startingPool.TryGetValue("0", out _), Is.False, "The requested partition should have been removed.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(1), "The producer should have been closed.");
            Assert.That(wasFactoryCalled, Is.False, "The requested partition should not have been created.");

            // Request the producer again and validate a new producer is created.

            Assert.That(transportProducerPool.GetPooledProducer("0"), Is.Not.Null, "The requested partition should be available.");
            Assert.That(wasFactoryCalled, Is.True, "A new producer for the requested partition should have been created.");
        }

        /// <summary>
        ///   The pool periodically removes and closes expired items.
        /// </summary>
        ///
        [Test]
        public async Task ExpireCloseNotCloseTheRemovedItemWhenInUse()
        {
            var transportProducer = new ObservableTransportProducerMock();

            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer),
                ["1"] = new TransportProducerPool.PoolItem("1", transportProducer),
                ["2"] = new TransportProducerPool.PoolItem("2", transportProducer),
            };

            var transportProducerPool = new TransportProducerPool(partition => transportProducer, pool: startingPool, eventHubProducer: transportProducer);

            // Validate the initial state.

            Assert.That(startingPool.TryGetValue("0", out _), Is.True, "The requested partition should appear in the pool.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(0), "The producer should not have been closed.");

            // Request the producer and hold the reference to ensure that it is flagged as being in use.

            await using var poolItem = transportProducerPool.GetPooledProducer("0");

            // Expire the producer and validate the removal state.

            await transportProducerPool.ExpirePooledProducerAsync("0", forceClose: false);

            Assert.That(startingPool.TryGetValue("0", out _), Is.False, "The requested partition should have been removed.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(0), "The producer should not have been closed.");
        }

        /// <summary>
        ///   The pool periodically removes and closes expired items.
        /// </summary>
        ///
        [Test]
        public async Task ExpireClosesTheRemovedItemWhenForced()
        {
            var transportProducer = new ObservableTransportProducerMock();

            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", transportProducer),
                ["1"] = new TransportProducerPool.PoolItem("1", transportProducer),
                ["2"] = new TransportProducerPool.PoolItem("2", transportProducer),
            };

            var transportProducerPool = new TransportProducerPool(partition => transportProducer, pool: startingPool, eventHubProducer: transportProducer);

            // Validate the initial state.

            Assert.That(startingPool.TryGetValue("0", out _), Is.True, "The requested partition should appear in the pool.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(0), "The producer should not have been closed.");

            // Request the producer and hold the reference to ensure that it is flagged as being in use.

            await using var poolItem = transportProducerPool.GetPooledProducer("0");

            // Expire the producer and validate the removal state.

            await transportProducerPool.ExpirePooledProducerAsync("0", forceClose: true);

            Assert.That(startingPool.TryGetValue("0", out _), Is.False, "The requested partition should have been removed.");
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(1), "The producer should have been closed.");
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
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), startingPool);

            // This call should refresh the timespan associated to the item
            _ = transportProducerPool.GetPooledProducer("0");

            // The expiration call back should not remove the item
            GetExpirationCallBack(transportProducerPool).Invoke(null);

            Assert.That(startingPool.TryGetValue("0", out _), Is.True, "The item in the pool should be refreshed and not have been removed.");
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
            var connection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy));
            var expectedTime = DateTimeOffset.UtcNow.AddMinutes(10);

            await using var pooledProducer = transportProducerPool.GetPooledProducer("0");

            // This call should refresh the timespan associated to an item in the pool
            await pooledProducer.DisposeAsync();

            Assert.That(startingPool["0"].RemoveAfter, Is.InRange(expectedTime.AddMinutes(-1), expectedTime.AddMinutes(1)), $"The remove after of a pool item should be extended.");
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
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), startingPool);

            var pooledProducer = transportProducerPool.GetPooledProducer("0");
            startingPool.TryGetValue("0", out var poolItem);

            await using (pooledProducer)
            {
                Assert.That(poolItem.ActiveInstances.Count, Is.EqualTo(1), "The usage of a transport producer should be tracked.");
            }

            Assert.That(poolItem.ActiveInstances.Count, Is.EqualTo(0), "After usage an active instance should be removed from the pool.");
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
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), startingPool);

            var pooledProducer = transportProducerPool.GetPooledProducer("0", TimeSpan.FromMinutes(-1));

            await using (var _ = pooledProducer.ConfigureAwait(false))
            {
            };

            GetExpirationCallBack(transportProducerPool).Invoke(null);

            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(1));
        }

        /// <summary>
        ///   The <see cref="TransportProducerPool"/> returns the <see cref="TransportProducer" />
        ///   matching the right partition id.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("0")]
        public void TransportProducerPoolAllowsTakingTheRightTransportProducer(string partitionId)
        {
            var transportProducer = new ObservableTransportProducerMock();
            var partitionProducer = new ObservableTransportProducerMock(partitionId);
            var connection = new MockConnection(() => partitionProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", partitionProducer)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), eventHubProducer: transportProducer);

            var returnedProducer = transportProducerPool.GetPooledProducer(partitionId).TransportProducer as ObservableTransportProducerMock;

            Assert.That(returnedProducer.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TransportProducerPool.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseAsyncSurfacesExceptionsForTransportProducer()
        {
            var transportProducer = new Mock<TransportProducer>();
            var partitionProducer = new Mock<TransportProducer>();
            var connection = new MockConnection(() => partitionProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", partitionProducer.Object)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), eventHubProducer: transportProducer.Object);

            transportProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new InvalidCastException()));

            var _ = transportProducerPool.GetPooledProducer(null).TransportProducer as ObservableTransportProducerMock;

            Assert.That(async () => await transportProducerPool.CloseAsync(), Throws.InstanceOf<InvalidCastException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TransportProducerPool.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseAsyncSurfacesExceptionsForPartitionTransportProducer()
        {
            var transportProducer = new Mock<TransportProducer>();
            var partitionProducer = new Mock<TransportProducer>();
            var connection = new MockConnection(() => partitionProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var startingPool = new ConcurrentDictionary<string, TransportProducerPool.PoolItem>
            {
                ["0"] = new TransportProducerPool.PoolItem("0", partitionProducer.Object)
            };
            TransportProducerPool transportProducerPool = new TransportProducerPool(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), eventHubProducer: transportProducer.Object);

            partitionProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new InvalidCastException()));

            var _ = transportProducerPool.GetPooledProducer("0");

            Assert.That(async () => await transportProducerPool.CloseAsync(), Throws.InstanceOf<InvalidCastException>());
        }

        /// <summary>
        ///   Gets the routine responsible of finding expired producers.
        /// </summary>
        ///
        private static TimerCallback GetExpirationCallBack(TransportProducerPool pool) =>
            (TimerCallback)
                typeof(TransportProducerPool)
                    .GetMethod("CreateExpirationTimerCallback", BindingFlags.NonPublic | BindingFlags.Instance)
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
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>()).Object)
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
                return Task.FromResult(new EventHubProperties(EventHubName, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), new string[] { "0", "1" }, false));
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
                                                                        string producerIdentifier,
                                                                        TransportProducerFeatures requestedFeatures,
                                                                        PartitionPublishingOptions partitionOptions,
                                                                        EventHubsRetryPolicy retryPolicy) => TransportProducerFactory();

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                                    string eventHubName,
                                                                    TimeSpan operationTimeout,
                                                                    EventHubTokenCredential credential,
                                                                    EventHubConnectionOptions options,
                                                                    bool useTls = true)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace }.com/{ eventHubName }"));

                return client.Object;
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

            public override Task SendAsync(IReadOnlyCollection<EventData> events,
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

            public override ValueTask<PartitionPublishingProperties> ReadInitializationPublishingPropertiesAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

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
            public override int? StartingSequenceNumber => throw new NotImplementedException();
            public override TransportProducerFeatures ActiveFeatures { get; }
            public override bool TryAdd(EventData eventData) => throw new NotImplementedException();
            public override IReadOnlyCollection<T> AsReadOnlyCollection<T>() => throw new NotImplementedException();
            public override void Dispose() => throw new NotImplementedException();
            public override void Clear() => throw new NotImplementedException();
            public override int ApplyBatchSequencing(int lastSequenceNumber, long? producerGroupId, short? ownerLevel) => throw new NotImplementedException();
            public override void ResetBatchSequencing() => throw new NotImplementedException();
        }
    }
}
