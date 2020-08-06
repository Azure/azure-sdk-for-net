// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;

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

        /// <summary>The location of the Azure Resource Manager for the active cloud environment.</summary>
        private static readonly Uri AzureResourceManagerUri = new Uri(EventHubsTestEnvironment.Instance.ResourceManagerUrl);

        /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
        private bool _disposed = false;

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

            var resourceGroup = EventHubsTestEnvironment.Instance.ResourceGroup;
            var eventHubNamespace = EventHubsTestEnvironment.Instance.EventHubsNamespace;
            var token = await ResourceManager.AquireManagementTokenAsync().ConfigureAwait(false);
            var client = new EventHubManagementClient(AzureResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = EventHubsTestEnvironment.Instance.SubscriptionId };

            try
            {
                await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.EventHubs.DeleteAsync(resourceGroup, eventHubNamespace, EventHubName)).ConfigureAwait(false);
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
            finally
            {
                client?.Dispose();
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
        ///   Performs the tasks needed to create a new Event Hubs namespace within a resource group, intended to be used as
        ///   an ephemeral container for the Event Hub instances used in a given test run.
        /// </summary>
        ///
        /// <returns>The key attributes for identifying and accessing a dynamically created Event Hubs namespace.</returns>
        ///
        public static async Task<EventHubsTestEnvironment.NamespaceProperties> CreateNamespaceAsync()
        {
            var subscription = EventHubsTestEnvironment.Instance.SubscriptionId;
            var resourceGroup = EventHubsTestEnvironment.Instance.ResourceGroup;
            var token = await ResourceManager.AquireManagementTokenAsync().ConfigureAwait(false);

            string CreateName() => $"net-eventhubs-{ Guid.NewGuid().ToString("D") }";

            using (var client = new EventHubManagementClient(AzureResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                var location = await ResourceManager.QueryResourceGroupLocationAsync(token, resourceGroup, subscription).ConfigureAwait(false);

                var eventHubsNamespace = new EHNamespace(sku: new Sku("Standard", "Standard", 12), tags: ResourceManager.GenerateTags(), isAutoInflateEnabled: true, maximumThroughputUnits: 20, location: location);
                eventHubsNamespace = await ResourceManager.CreateRetryPolicy<EHNamespace>().ExecuteAsync(() => client.Namespaces.CreateOrUpdateAsync(resourceGroup, CreateName(), eventHubsNamespace)).ConfigureAwait(false);

                var accessKey = await ResourceManager.CreateRetryPolicy<AccessKeys>().ExecuteAsync(() => client.Namespaces.ListKeysAsync(resourceGroup, eventHubsNamespace.Name, EventHubsTestEnvironment.EventHubsDefaultSharedAccessKey)).ConfigureAwait(false);
                return new EventHubsTestEnvironment.NamespaceProperties(eventHubsNamespace.Name, accessKey.PrimaryConnectionString, shouldRemoveAtCompletion: true);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to remove an ephemeral Event Hubs namespace used as a container for Event Hub instances
        ///   for a specific test run.
        /// </summary>
        ///
        /// <param name="namespaceName">The name of the namespace to delete.</param>
        ///
        public static async Task DeleteNamespaceAsync(string namespaceName)
        {
            var subscription = EventHubsTestEnvironment.Instance.SubscriptionId;
            var resourceGroup = EventHubsTestEnvironment.Instance.ResourceGroup;
            var token = await ResourceManager.AquireManagementTokenAsync().ConfigureAwait(false);

            using (var client = new EventHubManagementClient(AzureResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.Namespaces.DeleteAsync(resourceGroup, namespaceName)).ConfigureAwait(false);
            }
        }

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
        private static async Task<EventHubScope> BuildScopeFromExistingEventHub()
        {
            var token = await ResourceManager.AquireManagementTokenAsync().ConfigureAwait(false);

            using (var client = new EventHubManagementClient(AzureResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = EventHubsTestEnvironment.Instance.SubscriptionId })
            {
                var consumerGroups = client.ConsumerGroups.ListByEventHub
                (
                    EventHubsTestEnvironment.Instance.ResourceGroup,
                    EventHubsTestEnvironment.Instance.EventHubsNamespace,
                    EventHubsTestEnvironment.Instance.EventHubNameOverride
                 );

                return new EventHubScope(EventHubsTestEnvironment.Instance.EventHubNameOverride, consumerGroups.Select(c => c.Name).ToList(), shouldRemoveEventHubAtScopeCompletion: false);
            }
        }

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
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var groups = (consumerGroups ?? Enumerable.Empty<string>()).ToList();
            var resourceGroup = EventHubsTestEnvironment.Instance.ResourceGroup;
            var eventHubNamespace = EventHubsTestEnvironment.Instance.EventHubsNamespace;
            var token = await ResourceManager.AquireManagementTokenAsync().ConfigureAwait(false);

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            using (var client = new EventHubManagementClient(AzureResourceManagerUri, new TokenCredentials(token)) { SubscriptionId = EventHubsTestEnvironment.Instance.SubscriptionId })
            {
                var eventHub = new Eventhub(partitionCount: partitionCount);
                eventHub = await ResourceManager.CreateRetryPolicy<Eventhub>().ExecuteAsync(() => client.EventHubs.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, CreateName(), eventHub)).ConfigureAwait(false);

                var consumerPolicy = ResourceManager.CreateRetryPolicy<ConsumerGroup>();

                await Task.WhenAll
                (
                    consumerGroups.Select(groupName =>
                    {
                        var group = new ConsumerGroup(name: groupName);
                        return consumerPolicy.ExecuteAsync(() => client.ConsumerGroups.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, eventHub.Name, groupName, group));
                    })
                ).ConfigureAwait(false);

                groups.Insert(0, EventHubConsumerClient.DefaultConsumerGroupName);
                return new EventHubScope(eventHub.Name, groups, shouldRemoveEventHubAtScopeCompletion: true);
            }
        }
    }
}
