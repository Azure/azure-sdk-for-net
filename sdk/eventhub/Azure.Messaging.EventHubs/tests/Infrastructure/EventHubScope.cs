// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;

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
        /// <summary>The manager for common live test resource operations.</summary>
        private static readonly LiveResourceManager ResourceManager = new LiveResourceManager();

        /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
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
            EventHubName = eventHubHame;
            ConsumerGroups = consumerGroups;
        }

        /// <summary>
        ///   Performs the tasks needed to remove the dynamically created
        ///   Event Hub.
        /// </summary>
        ///
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var eventHubNamespace = TestEnvironment.EventHubsNamespace;
            var token = await ResourceManager.AquireManagementTokenAsync();
            var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestEnvironment.EventHubsSubscription };

            try
            {
                await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.EventHubs.DeleteAsync(resourceGroup, eventHubNamespace, EventHubName));
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
        /// <param name="consumerGroups">The set of consumer groups to create and associate with the Event Hub; the default consumer group should not be included, as it is implicitly created.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The <see cref="EventHubScope" /> in which the test should be executed.</returns>
        ///
        public static async Task<EventHubScope> CreateAsync(int partitionCount,
                                                            IEnumerable<string> consumerGroups,
                                                            [CallerMemberName] string caller = "")
        {
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var groups = (consumerGroups ?? Enumerable.Empty<string>()).ToList();
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var eventHubNamespace = TestEnvironment.EventHubsNamespace;
            var token = await ResourceManager.AquireManagementTokenAsync();

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = TestEnvironment.EventHubsSubscription })
            {
                var eventHub = new Eventhub(partitionCount: partitionCount);
                eventHub = await ResourceManager.CreateRetryPolicy<Eventhub>().ExecuteAsync(() => client.EventHubs.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, CreateName(), eventHub));

                Polly.IAsyncPolicy<ConsumerGroup> consumerPolicy = ResourceManager.CreateRetryPolicy<ConsumerGroup>();

                await Task.WhenAll
                (
                    consumerGroups.Select(groupName =>
                    {
                        var group = new ConsumerGroup(name: groupName);
                        return consumerPolicy.ExecuteAsync(() => client.ConsumerGroups.CreateOrUpdateAsync(resourceGroup, eventHubNamespace, eventHub.Name, groupName, group));
                    })
                );

                return new EventHubScope(eventHub.Name, groups);
            }
        }

        /// <summary>
        ///   Performs the tasks needed to create a new Event Hubs namespace within a resource group, intended to be used as
        ///   an ephemeral container for the Event Hub instances used in a given test run.
        /// </summary>
        ///
        /// <returns>The key attributes for identifying and accessing a dynamically created Event Hubs namespace.</returns>
        ///
        public static async Task<NamespaceProperties> CreateNamespaceAsync()
        {
            var subscription = TestEnvironment.EventHubsSubscription;
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var token = await ResourceManager.AquireManagementTokenAsync();

            string CreateName() => $"net-eventhubs-{ Guid.NewGuid().ToString("D") }";

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                var location = await ResourceManager.QueryResourceGroupLocationAsync(token, resourceGroup, subscription);

                var eventHubsNamespace = new EHNamespace(sku: new Sku("Standard", "Standard", 12), tags: ResourceManager.GenerateTags(), isAutoInflateEnabled: true, maximumThroughputUnits: 20, location: location);
                eventHubsNamespace = await ResourceManager.CreateRetryPolicy<EHNamespace>().ExecuteAsync(() => client.Namespaces.CreateOrUpdateAsync(resourceGroup, CreateName(), eventHubsNamespace));

                AccessKeys accessKey = await ResourceManager.CreateRetryPolicy<AccessKeys>().ExecuteAsync(() => client.Namespaces.ListKeysAsync(resourceGroup, eventHubsNamespace.Name, TestEnvironment.EventHubsDefaultSharedAccessKey));
                return new NamespaceProperties(eventHubsNamespace.Name, accessKey.PrimaryConnectionString);
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
            var subscription = TestEnvironment.EventHubsSubscription;
            var resourceGroup = TestEnvironment.EventHubsResourceGroup;
            var token = await ResourceManager.AquireManagementTokenAsync();

            using (var client = new EventHubManagementClient(new TokenCredentials(token)) { SubscriptionId = subscription })
            {
                await ResourceManager.CreateRetryPolicy().ExecuteAsync(() => client.Namespaces.DeleteAsync(resourceGroup, namespaceName));
            }
        }

        /// <summary>
        ///   The key attributes for identifying and accessing a dynamically created Event Hubs namespace,
        ///   intended to serve as an ephemeral container for the Event Hub instances used during a test run.
        /// </summary>
        ///
        public struct NamespaceProperties
        {
            /// <summary>The name of the Event Hubs namespace that was dynamically created.</summary>
            public readonly string Name;

            /// <summary>The connection string to use for accessing the dynamically created namespace.</summary>
            public readonly string ConnectionString;

            /// <summary>
            ///   Initializes a new instance of the <see cref="NamespaceProperties"/> struct.
            /// </summary>
            ///
            /// <param name="name">The name of the namespace.</param>
            /// <param name="connectionString">The connection string to use for accessing the namespace.</param>
            ///
            internal NamespaceProperties(string name,
                                         string connectionString)
            {
                Name = name;
                ConnectionString = connectionString;
            }
        }
    }
}
