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
    ///   A pool of <see cref="TransportProducer" />.
    ///   It periodically checks if the producers are active and if not it disposes them.
    /// </summary>
    ///
    internal class TransportProducerPool : IAsyncDisposable
    {
        /// <summary>The period in minutes after which <see cref="PerformExpiration"/> is run.</summary>
        private const int PerformExpirationPeriodAsMinutes = 10;

        /// <summary>
        ///   The set of active Event Hub transport-specific producers specific to a given partition;
        ///   intended to perform delegated operations.
        /// </summary>
        ///
        private ConcurrentDictionary<string, PoolItem> Pool { get; }

        /// <summary>
        ///   A reference to a <see cref="Timer"/> periodically checking the <see cref="TransportProducer"/> that
        ///   are in use and those that can be closed.
        /// </summary>
        ///
        private Timer ExpirationTimer { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TransportProducerPool"/> class.
        /// </summary>
        ///
        /// <param name="pool">The pool of <see cref="PoolItem"/> that is going to be used to store the partition specific <see cref="TransportProducer"/>.</param>
        /// <param name="expirationInterval">The period after which <see cref="PerformExpiration"/> is run.</param>
        ///
        public TransportProducerPool(ConcurrentDictionary<string, PoolItem> pool = default,
                                     TimeSpan? expirationInterval = default)
        {
            expirationInterval ??= TimeSpan.FromMinutes(PerformExpirationPeriodAsMinutes);
            Pool = pool ?? new ConcurrentDictionary<string, PoolItem>();

            ExpirationTimer = new Timer(PerformExpiration(),
                                        null,
                                        expirationInterval.Value,
                                        expirationInterval.Value);
        }

        /// <summary>
        ///   Retrieves a <see cref="PooledProducer" /> for the requested partition,
        ///   creating one if needed or extending the expiration for an existing instance.
        /// </summary>
        ///
        /// <param name="partitionId">The zero-based unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="connection">The <see cref="EventHubConnection"/> to use as the basis for delegation of client-type operations.</param>
        /// <param name="retryPolicy">The <see cref="EventHubsRetryPolicy"/> to use as the basis for retrieving the information.</param>
        /// <param name="removeAfterDuration">The <see cref="TimeSpan"/> to use as the basis for retrieving the information.</param>
        ///
        /// <returns>A <see cref="PooledProducer"/> corresponding to the partitionId passed in as parameter.</returns>
        ///
        /// <remarks>
        ///   There is a slight probability that the returned producer may be closed at any time
        ///   after it is returned and the caller may want to handle that scenario.
        /// </remarks>
        ///
        public virtual PooledProducer GetPartitionProducer(string partitionId,
                                                           EventHubConnection connection,
                                                           EventHubsRetryPolicy retryPolicy,
                                                           TimeSpan? removeAfterDuration = default)
        {
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            var identifier = Guid.NewGuid().ToString();

            var item = Pool.GetOrAdd(partitionId, id => new PoolItem(connection.CreateTransportProducer(id, retryPolicy), removeAfterDuration));

            // A race condition at this point may end with an CloseAsync called on
            // the returned PoolItem if it had expired. The probability is very low and
            // possible exceptions should be handled by the invoking methods.

            if (!item.ActiveInstances.TryAdd(identifier, 0) || item.Producer.IsClosed)
            {
                identifier = Guid.NewGuid().ToString();
                item = Pool.GetOrAdd(partitionId, id => new PoolItem(connection.CreateTransportProducer(id, retryPolicy), removeAfterDuration));
                item.ActiveInstances.TryAdd(identifier, 0);
            }

            item.ExtendRemoveAfter(removeAfterDuration);

            return new PooledProducer(item.Producer, cleanUp: producer =>
            {
                if (Pool.TryGetValue(partitionId, out PoolItem pooledItem))
                {
                    pooledItem.ExtendRemoveAfter(removeAfterDuration);
                }

                // If TryRemove returned false the PoolItem would not be closed deterministically
                // and the ExpirationTimer callback would eventually remove it from the
                // Pool leaving to the Garbage Collector the responsability of closing
                // the TransportProducer and the AMQP link.

                item.ActiveInstances.TryRemove(identifier, out _);

                // The second TryGet runs after the extension would have been seen, so it
                // is intended to be sure that the item wasn't removed in the meantime.

                if (!Pool.TryGetValue(partitionId, out _) && !item.ActiveInstances.Any())
                {
                    return producer.CloseAsync(CancellationToken.None);
                }

                return Task.CompletedTask;
            });
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="TransportProducerPool" />.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Closes the producers in the pool and performs any cleanup necessary
        ///   for resources used by the <see cref="TransportProducerPool" />.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task CloseAsync()
        {
            var pendingCloses = new List<Task>();

            foreach (var producer in Pool.Values)
            {
                pendingCloses.Add(producer.Producer.CloseAsync(CancellationToken.None));
            }

            Pool.Clear();
            ExpirationTimer.Dispose();

            await Task.WhenAll(pendingCloses).ConfigureAwait(false);
        }

        /// <summary>
        ///   It returns a <see cref="TimerCallback" /> that will search for all the expired <see cref="PoolItem"/>
        ///   in the <see cref="Pool"/> and will try to close those that have expired.
        /// </summary>
        ///
        internal TimerCallback PerformExpiration()
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
                                // and the pool item clean up kicked in

                                poolItem.Producer.CloseAsync(CancellationToken.None).GetAwaiter().GetResult();
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        ///   An item of the pool, adding tracking information to a <see cref="TransportProducer"/>.
        /// </summary>
        ///
        internal class PoolItem
        {
            /// <summary>The period of inactivity after which an item would be removed from the pool.</summary>
            public static readonly TimeSpan DefaultRemoveAfterDuration = TimeSpan.FromMinutes(10);

            /// <summary>
            ///   A <see cref="TransportProducer"/> assigned to a partition.
            /// </summary>
            ///
            public TransportProducer Producer { get; }

            /// <summary>
            ///   A set of unique identifiers used to track which instances of a <see cref="PoolItem"/> are active.
            /// </summary>
            ///
            public ConcurrentDictionary<string, byte> ActiveInstances { get; } = new ConcurrentDictionary<string, byte>();

            /// <summary>
            ///   The UTC date and time when a <see cref="PoolItem"/> will become eligible for eviction.
            /// </summary>
            ///
            public DateTimeOffset RemoveAfter { get; set; }

            /// <summary>
            ///   It allows to extend the time a <see cref="PoolItem"/> will sit in the pool.
            /// </summary>
            ///
            /// <param name="removeAfterDuration">How long a dedicated transport producer would sit in memory before the <see cref="TransportProducerPool"/> would remove and close it.</param>
            ///
            public void ExtendRemoveAfter(TimeSpan? removeAfterDuration)
            {
                RemoveAfter = DateTimeOffset.UtcNow.Add(removeAfterDuration ?? DefaultRemoveAfterDuration);
            }

            /// <summary>
            ///   Initializes a new instance of the <see cref="PoolItem"/> class with a default timespan of one minute.
            /// </summary>
            ///
            /// <param name="producer">An Event Hub transport-specific producer specific to a given partition.</param>
            /// <param name="removeAfterDuration">How long a dedicated transport producer would sit in memory before its pool would remove and close it.</param>
            /// <param name="removeAfter">The UTC date and time when a <see cref="PoolItem"/> will become eligible for eviction.</param>
            ///
            public PoolItem(TransportProducer producer,
                            TimeSpan? removeAfterDuration = default,
                            DateTimeOffset? removeAfter = default)
            {
                Argument.AssertNotNull(producer, nameof(producer));

                Producer = producer;

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
        ///   A class wrapping a <see cref="TransportProducer"/>, triggering a clean-up when the object
        ///   is disposed.
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
            ///   A <see cref="TransportProducer"/> assigned to a partition.
            /// </summary>
            ///
            public TransportProducer Item { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="PooledProducer"/> class.
            /// </summary>
            ///
            /// <param name="producer">An Event Hub transport-specific producer specific to a given partition.</param>
            /// <param name="cleanUp">The function responsible of cleaning up the resources in use.</param>
            ///
            public PooledProducer(TransportProducer producer,
                                  Func<TransportProducer, Task> cleanUp)
            {
                Argument.AssertNotNull(producer, nameof(producer));
                Argument.AssertNotNull(cleanUp, nameof(cleanUp));

                Item = producer;
                CleanUp = cleanUp;
            }

            /// <summary>
            ///   Performs the task needed to clean up resources used by the <see cref="PooledProducer" />.
            /// </summary>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public virtual ValueTask DisposeAsync() => new ValueTask(CleanUp(Item));
        }
    }
}
