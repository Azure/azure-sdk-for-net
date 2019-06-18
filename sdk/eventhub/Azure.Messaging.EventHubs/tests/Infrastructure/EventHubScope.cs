// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Tests.Infrastructure
{
    /// <summary>
    ///  Provides a dynamically created Event Hub instance which exists only in the context
    ///  of the scope; disposal removes the instance.
    /// </summary>
    ///
    /// <seealso cref="System.IAsyncDisposable" />
    ///
    public sealed class EventHubScope : IAsyncDisposable
    {
        /// <summary>Serves as a sentinal flag to denote when the instance has been disposed.</summary>
        private bool _disposed = false;

        /// <summary>
        ///  The name of the Event Hub that was created.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The consumer groups created and associated with the Event Hub, not including
        ///   the default consumer group which is created implicitly.
        /// </summary>
        ///
        public IReadOnlyList<string> ConsumerGroups { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubScope"/> class.
        /// </summary>
        ///
        /// <param name="eventHubHame">The name of the Event Hub that was created.</param>
        /// <param name="consumerGroups">The set of consumer groups associated with the Event Hub; the default consumer group is not included, as it is implicitly created.</param>
        ///
        private EventHubScope(string eventHubHame,
                              IReadOnlyList<string> consumerGroups)
        {
            //TODO: Constructor needs to take the state needed to tear down the Event Hub.
            EventHubName = eventHubHame;
            ConsumerGroups = consumerGroups;
        }

        /// <summary>
        ///   Performs the tasks needed to remove the dynamically created
        ///   Event Hub.
        /// </summary>
        ///
        public ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return new ValueTask();
            }

            //TODO: Perform the needed actions to tear down the Event Hub.
            _disposed = true;
            return new ValueTask();
        }

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, Enumerable.Empty<string>(), caller);

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroup">The name of a consumer group to create and associate with the Event Hub; the default consumer group should not be specified, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      string consumerGroup,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, new[] { consumerGroup }, caller);

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroups">The set of consumer groups to create and associate with the Event Hub; the default consumer group should not be included, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      IEnumerable<string> consumerGroups,
                                                      [CallerMemberName] string caller = "")
        {
            var name = $"{ caller }-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";
            var groups = (consumerGroups ?? Enumerable.Empty<string>()).ToList();

            //TODO: These are temporary until the actual dynamic creation is in place.
            name = "eventhubs-sdk-test-hub";
            groups = new List<string> { "sdk-test-consumer" };

            //TODO: Create/Invoke a management client to dynamically create the Event Hub.  There should be some minimal retries on this; consider Polly if we have nothing in Core to help.
            //TODO: Create the consumer groups requested, if anything exists in the set.

            //TODO: Set state as appropriate for cleaning things up and pass to the constructor.
            return Task.FromResult(new EventHubScope(name, groups));
        }
    }
}
