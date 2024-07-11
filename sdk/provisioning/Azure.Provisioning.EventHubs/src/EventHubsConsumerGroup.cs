// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;

namespace Azure.Provisioning.EventHubs
{
    /// <summary>
    /// Represents an Event Hub consumer group.
    /// </summary>
    public class EventHubsConsumerGroup : Resource<EventHubsConsumerGroupData>
    {
        private const string ResourceTypeName = "Microsoft.EventHub/namespaces/eventhubs/consumergroups";
        private static EventHubsConsumerGroupData Empty(string name) => ArmEventHubsModelFactory.EventHubsConsumerGroupData();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHub"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public EventHubsConsumerGroup(IConstruct scope,
            EventHub? parent = null,
            string name = "cg",
            string version = EventHubsNamespace.DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, (name) => ArmEventHubsModelFactory.EventHubsConsumerGroupData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        private EventHubsConsumerGroup(IConstruct scope,
            EventHub? parent,
            string name,
            string version = EventHubsNamespace.DefaultVersion,
            Func<string, EventHubsConsumerGroupData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EventHub"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static EventHubsConsumerGroup FromExisting(IConstruct scope, string name, EventHub parent)
            => new EventHubsConsumerGroup(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<EventHub>() ?? new EventHub(scope);
        }
    }
}
