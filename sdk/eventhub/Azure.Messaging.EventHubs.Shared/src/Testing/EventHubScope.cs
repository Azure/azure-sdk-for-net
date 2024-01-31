// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Tests
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
        /// <summary>The manager for common live test resource operations.</summary>
        private static readonly LiveResourceManager ResourceManager = new LiveResourceManager();

        /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
        private volatile bool _disposed = false;

        /// <summary>
        ///   The name of the Event Hub that was created.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   Indicates whether the Event Hub should be removed when the current scope
        ///   is completed.
        /// </summary>
        ///
        public bool ShouldRemoveEventHubAtScopeCompletion { get; }

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
        /// <param name="shouldRemoveEventHubAtScopeCompletion">Indicates whether the Event Hub should be removed when the current scope is completed.</param>
        ///
        private EventHubScope(string eventHubHame,
                              IReadOnlyList<string> consumerGroups,
                              bool shouldRemoveEventHubAtScopeCompletion)
        {
            EventHubName = eventHubHame;
            ConsumerGroups = consumerGroups;
            ShouldRemoveEventHubAtScopeCompletion = shouldRemoveEventHubAtScopeCompletion;
        }

        /// <summary>
        ///   Performs the tasks needed to remove the dynamically created
        ///   Event Hub.
        /// </summary>
        ///
        public async ValueTask DisposeAsync()
        {
            if (!ShouldRemoveEventHubAtScopeCompletion)
            {
                _disposed = true;
            }

            if (_disposed)
            {
                return;
            }

            try
            {
                await ResourceManager.DeleteEventHubAsync(EventHubName).ConfigureAwait(false);
            }
            catch
            {
                // This should not be considered a critical failure that results in a test failure.  Due
                // to ARM being temperamental, some management operations may be rejected.  Throwing here
                // does not help to ensure resource cleanup only flags the test itself as a failure.
                //
                // If an Event Hub fails to be deleted, removing of the associated namespace at the end of the
                // test run will also remove the orphan.
            }

            _disposed = true;
        }

        /// <summary>
        ///   Performs the tasks needed to get or create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      [CallerMemberName] string caller = "") => CreateAsync(partitionCount, Enumerable.Empty<string>(), caller);

        /// <summary>
        ///   Performs the tasks needed to get or create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroups">The set of consumer groups to create and associate with the Event Hub; the default consumer group should not be included, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        public static Task<EventHubScope> CreateAsync(int partitionCount,
                                                      IEnumerable<string> consumerGroups,
                                                      [CallerMemberName] string caller = "") => BuildScope(partitionCount, consumerGroups, caller);

        /// <summary>
        ///   Builds a new scope based on the Event Hub that is named using <see cref="EventHubsTestEnvironment.Instance.EventHubName" />, if specified.  If not,
        ///   a new EventHub is created for the scope.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroups">The set of consumer groups to create and associate with the Event Hub; the default consumer group should not be included, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The <see cref="EventHubScope" /> that will be used in a given test run.</returns>
        ///
        /// <remarks>
        ///   This method assumes responsibility of tearing down any Azure resources that it directly creates.
        /// </remarks>
        ///
        private static Task<EventHubScope> BuildScope(int partitionCount,
                                                      IEnumerable<string> consumerGroups,
                                                      [CallerMemberName] string caller = "")
        {
            if (!string.IsNullOrEmpty(EventHubsTestEnvironment.Instance.EventHubNameOverride))
            {
                return BuildScopeFromExistingEventHub();
            }

            return BuildScopeWithNewEventHub(partitionCount, consumerGroups, caller);
        }

        /// <summary>
        ///   It returns a scope after instantiating a management client
        ///   and querying the consumer groups from the portal.
        /// </summary>
        ///
        /// <returns>The <see cref="EventHubScope" /> that will be used in a given test run.</returns>
        ///
        private static Task<EventHubScope> BuildScopeFromExistingEventHub() => Task.FromResult(
            new EventHubScope(
                EventHubsTestEnvironment.Instance.EventHubNameOverride,
                ResourceManager.QueryEventHubConsumerGroupNames(EventHubsTestEnvironment.Instance.EventHubNameOverride),
                shouldRemoveEventHubAtScopeCompletion: false));

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hub instance with the requested
        ///   partition count and a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="partitionCount">The number of partitions that the Event Hub should be configured with.</param>
        /// <param name="consumerGroups">The set of consumer groups to create and associate with the Event Hub; the default consumer group should not be included, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The <see cref="EventHubScope" /> in which the test should be executed.</returns>
        ///
        private static async Task<EventHubScope> BuildScopeWithNewEventHub(int partitionCount,
                                                                           IEnumerable<string> consumerGroups,
                                                                           [CallerMemberName] string caller = "")
        {
            // Use the name of the test along with some randomization as the name of the ephemeral Event Hub.  This
            // allows us to identify which test is associated with it, while preventing test run failures when cleanup
            // fails.

            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var eventHubName = $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";
            var groups = consumerGroups?.ToList() ?? new List<string>();
            var eventHub = await ResourceManager.CreateEventHubAsync(eventHubName, partitionCount, groups).ConfigureAwait(false);

            // There is a race condition in which ARM has created the new Event Hub but it is not yet visible to the Event Hubs
            // service.  Introduce a short delay to allow for the service to get access to the new resource.

            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            // The default consumer group is always present; include it as part of the scope.

            groups.Insert(0, EventHubConsumerClient.DefaultConsumerGroupName);

            return new EventHubScope(
                eventHubName,
                groups,
                shouldRemoveEventHubAtScopeCompletion: true);
        }
    }
}
