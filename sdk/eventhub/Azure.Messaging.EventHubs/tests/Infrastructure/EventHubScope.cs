// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        ///   Initializes a new instance of the <see cref="EventHubScope"/> class.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        private EventHubScope(string eventHubHame)
        {
            //TODO: Constructor needs to take the state needed to tear down the Event Hub.
            EventHubName = eventHubHame;
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
                                                      [CallerMemberName] string caller = "")
        {
            var name = $"{ caller }-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";

            //TODO: This is temporary until the actual dynamic creation is in place.
            name = "eventhubs-sdk-test-hub";

            //TODO: Create/Invoke a management client to dynamically create the Event Hub.  There should be some minimal retries on this; consider Polly if we have nothing in Core to help.
            //TODO: Set state as appropriate for cleaning things up and pass to the constructor.
            return Task.FromResult(new EventHubScope(name));
        }
    }
}
