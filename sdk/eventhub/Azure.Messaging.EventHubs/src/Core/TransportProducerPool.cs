// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   A pool of <see cref="TransportProducer" /> instances that automatically expire after a period of inactivity.
    /// </summary>
    ///
    internal class TransportProducerPool
    {
        /// <summary>The period after which <see cref="CreateExpirationTimerCallback" /> is run.</summary>
        private static readonly TimeSpan DefaultPerformExpirationPeriod = TimeSpan.FromMinutes(10);

        /// <summary>
        ///   The set of active Event Hub transport-specific producers specific to a given partition;
        ///   intended to perform delegated operations.
        /// </summary>
        ///
        private ConcurrentDictionary<string, PoolItem> Pool { get; }

        /// <summary>
        ///   An abstracted Event Hub transport-specific producer that is associated with the
        ///   Event Hub gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        public TransportProducer EventHubProducer { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to a transport-aware producer.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   A reference to a <see cref="Timer" /> periodically checking every <see cref="DefaultPerformExpirationPeriod" />
        ///   the <see cref="TransportProducer" /> that are in use and those that can be closed.
        /// </summary>
        ///
        private Timer ExpirationTimer { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TransportProducerPool" /> class.
        /// </summary>
        ///
        internal TransportProducerPool()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TransportProducerPool" /> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="retryPolicy">The policy to use for determining retry behavior for when an operation fails.</param>
        /// <param name="pool">The pool of <see cref="PoolItem" /> that is going to be used to store the partition specific <see cref="TransportProducer" />.</param>
        /// <param name="performExpirationPeriod">The period after which <see cref="CreateExpirationTimerCallback" /> is run. Overrides <see cref="DefaultPerformExpirationPeriod" />.</param>
        /// <param name="eventHubProducer">An abstracted Event Hub transport-specific producer that is associated with the Event Hub gateway rather than a specific partition.</param>
        ///
        public TransportProducerPool(EventHubConnection connection,
                                     EventHubsRetryPolicy retryPolicy,
                                     ConcurrentDictionary<string, PoolItem> pool = default,
                                     TimeSpan? performExpirationPeriod = default,
                                     TransportProducer eventHubProducer = default)
        {
            Connection = connection;
            RetryPolicy = retryPolicy;
            Pool = pool ?? new ConcurrentDictionary<string, PoolItem>();
            performExpirationPeriod ??= DefaultPerformExpirationPeriod;
            EventHubProducer = eventHubProducer ?? connection.CreateTransportProducer(null, retryPolicy);

            ExpirationTimer = new Timer(CreateExpirationTimerCallback(),
                                        null,
                                        performExpirationPeriod.Value,
                                        performExpirationPeriod.Value);
        }

        /// <summary>
        ///   Retrieves a <see cref="PooledProducer" /> for the requested partition,
        ///   creating one if needed or extending the expiration for an existing instance.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="removeAfterDuration">The period of inactivity after which a <see cref="PoolItem" /> will become eligible for eviction. Overrides <see cref="PoolItem.DefaultRemoveAfterDuration" />.</param>
        ///
        /// <returns>A <see cref="PooledProducer" /> mapping to the partition id passed in as parameter.</returns>
        ///
        /// <remarks>
        ///   There is a slight probability that the returned producer may be closed at any time
        ///   after it is returned and the caller may want to handle that scenario.
        /// </remarks>
        ///
        public virtual PooledProducer GetPooledProducer(string partitionId,
                                                        TimeSpan? removeAfterDuration = default)
        {
            if (string.IsNullOrEmpty(partitionId))
            {
                return new PooledProducer(EventHubProducer);
            }

            var identifier = Guid.NewGuid().ToString();

            var item = Pool.GetOrAdd(partitionId, id => new PoolItem(partitionId, Connection.CreateTransportProducer(id, RetryPolicy), removeAfterDuration));

            // A race condition at this point may end with CloseAsync called on
            // the returned PoolItem if it had expired. The probability is very low and
            // possible exceptions should be handled by the invoking methods.

            if (item.PartitionProducer.IsClosed || !item.ActiveInstances.TryAdd(identifier, 0))
            {
                identifier = Guid.NewGuid().ToString();
                item = Pool.GetOrAdd(partitionId, id => new PoolItem(partitionId, Connection.CreateTransportProducer(id, RetryPolicy), removeAfterDuration));
                item.ActiveInstances.TryAdd(identifier, 0);
            }

            item.ExtendRemoveAfter(removeAfterDuration);

            return new PooledProducer(item.PartitionProducer, cleanUp: producer =>
            {
                Argument.AssertNotNull(producer, nameof(producer));

                if (Pool.TryGetValue(partitionId, out PoolItem pooledItem))
                {
                    pooledItem.ExtendRemoveAfter(removeAfterDuration);
                }

                // If TryRemove returned false the PoolItem would not be closed deterministically
                // and the ExpirationTimer callback would eventually remove it from the
                // Pool leaving to the Garbage Collector the responsability of closing
                // the TransportProducer and the AMQP link.

                item.ActiveInstances.TryRemove(identifier, out _);

                // The second TryGetValue runs after the extension would have been seen, so it
                // is intended to be sure that the item wasn't removed in the meantime.

                if (!Pool.TryGetValue(partitionId, out _) && !item.ActiveInstances.Any())
                {
                    return producer.CloseAsync(CancellationToken.None);
                }

                return Task.CompletedTask;
            });
        }

        /// <summary>
        ///   Closes the producers in the pool and performs any cleanup necessary
        ///   for resources used by the <see cref="TransportProducerPool" />.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                ExpirationTimer.Dispose();
            }
            catch (Exception)
            {
            }

            var pendingCloses = new List<Task>();

            pendingCloses.Add(EventHubProducer.CloseAsync(cancellationToken));

            foreach (var poolItem in Pool.Values)
            {
                pendingCloses.Add(poolItem.PartitionProducer.CloseAsync(cancellationToken));
            }

            Pool.Clear();

            await Task.WhenAll(pendingCloses).ConfigureAwait(false);
        }

        /// <summary>
        ///   Returns a <see cref="TimerCallback" /> that will search for all the expired <see cref="PoolItem" />
        ///   in the <see cref="Pool" /> and will try to close those that have expired.
        /// </summary>
        ///
        /// <returns>A <see cref="TimerCallback" /> that is periodically run every <see cref="DefaultPerformExpirationPeriod" />.</returns>
        ///
        private TimerCallback CreateExpirationTimerCallback()
        {
            return _ =>
            {
                // Capture the timestamp to use a consistent value.
                var now = DateTimeOffset.UtcNow;

                foreach (var key in Pool.Keys.ToList())
                {
                    if (Pool.TryGetValue(key, out var poolItem))
                    {
                        if (poolItem.RemoveAfter <= now)
                        {
                            if (Pool.TryRemove(key, out var _) && !poolItem.ActiveInstances.Any())
                            {
                                // At this point the pool item may have been closed already
                                // if there was a context switch between the if conditions
                                // and the pool item clean up kicked in.

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                                poolItem.PartitionProducer.CloseAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        ///   An item of the pool, adding tracking information to a <see cref="TransportProducer" />.
        /// </summary>
        ///
        internal class PoolItem
        {
            /// <summary>The period of inactivity after which an item would be removed from the pool.</summary>
            internal static readonly TimeSpan DefaultRemoveAfterDuration = TimeSpan.FromMinutes(10);

            /// <summary>
            ///   An abstracted Event Hub transport-specific <see cref="TransportProducer" /> that is associated with a specific partition.
            /// </summary>
            ///
            public TransportProducer PartitionProducer { get; private set; }

            /// <summary>
            ///   The unique identifier of a partition associated with the Event Hub.
            /// </summary>
            ///
            public string PartitionId { get; private set; }

            /// <summary>
            ///   A set of unique identifiers used to track which instances of a <see cref="PoolItem" /> are active.
            /// </summary>
            ///
            public ConcurrentDictionary<string, byte> ActiveInstances { get; } = new ConcurrentDictionary<string, byte>();

            /// <summary>
            ///   The UTC date and time when a <see cref="PoolItem" /> will become eligible for eviction.
            /// </summary>
            ///
            public DateTimeOffset RemoveAfter { get; set; }

            /// <summary>
            ///   Extends the UTC date and time when <see cref="PoolItem" /> will become eligible for eviction.
            /// </summary>
            ///
            /// <param name="removeAfterDuration">The period of inactivity after which a <see cref="PoolItem" /> will become eligible for eviction.</param>
            ///
            public void ExtendRemoveAfter(TimeSpan? removeAfterDuration)
            {
                RemoveAfter = DateTimeOffset.UtcNow.Add(removeAfterDuration ?? DefaultRemoveAfterDuration);
            }

            /// <summary>
            ///   Initializes a new instance of the <see cref="PoolItem" /> class with a default timespan of <see cref="DefaultRemoveAfterDuration" />.
            /// </summary>
            ///
            /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
            /// <param name="partitionProducer">An Event Hub transport-specific producer specific to a given partition.</param>
            /// <param name="removeAfterDuration">The interval after which a <see cref="PoolItem" /> will become eligible for eviction. Overrides <see cref="DefaultRemoveAfterDuration" />.</param>
            /// <param name="removeAfter">The UTC date and time when a <see cref="PoolItem" /> will become eligible for eviction.</param>
            ///
            public PoolItem(string partitionId,
                            TransportProducer partitionProducer,
                            TimeSpan? removeAfterDuration = default,
                            DateTimeOffset? removeAfter = default)
            {
                Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
                Argument.AssertNotNull(partitionProducer, nameof(partitionProducer));

                PartitionProducer = partitionProducer;
                PartitionId = partitionId;

                if (removeAfter == default)
                {
                    ExtendRemoveAfter(removeAfterDuration);
                }
                else
                {
                    RemoveAfter = removeAfter.Value;
                }
            }
        }

        /// <summary>
        ///   A class wrapping a <see cref="Core.TransportProducer" />, triggering a clean-up when the object is disposed.
        /// </summary>
        ///
        internal class PooledProducer: IAsyncDisposable
        {
            /// <summary>
            ///   A function responsible of cleaning up the resources in use.
            /// </summary>
            ///
            private Func<TransportProducer, Task> CleanUp { get; }

            /// <summary>
            ///   An abstracted Event Hub transport-specific producer that is associated with the
            ///   Event Hub gateway or a specific partition.
            /// </summary>
            ///
            public TransportProducer TransportProducer { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="PooledProducer" /> class.
            /// </summary>
            ///
            /// <param name="transportProducer">An abstracted Event Hub transport-specific producer that is associated with the Event Hub gateway or a specific partition.</param>
            /// <param name="cleanUp">The function responsible of cleaning up the resources in use.</param>
            ///
            public PooledProducer(TransportProducer transportProducer,
                                  Func<TransportProducer, Task> cleanUp = default)
            {
                Argument.AssertNotNull(transportProducer, nameof(transportProducer));

                TransportProducer = transportProducer;
                CleanUp = cleanUp;
            }

            /// <summary>
            ///   Performs the task needed to clean up resources used by the <see cref="PooledProducer" />.
            /// </summary>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public virtual ValueTask DisposeAsync()
            {
                if (CleanUp != default)
                {
                    return new ValueTask(CleanUp(TransportProducer));
                }

                return new ValueTask(Task.CompletedTask);
            }
        }
    }
}
