// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;

namespace Azure.Provisioning.EventHubs
{
    /// <summary>
    /// Represents an Event Hub.
    /// </summary>
    public class EventHub : Resource<EventHubData>
    {
        private const string ResourceTypeName = "Microsoft.EventHub/namespaces/eventhubs";
        private static readonly Func<string, EventHubData> Empty = (name) => ArmEventHubsModelFactory.EventHubData();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHub"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public EventHub(IConstruct scope, EventHubsNamespace? parent = null, string name = "hub", string version = EventHubsNamespace.DefaultVersion, AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmEventHubsModelFactory.EventHubData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        private EventHub(IConstruct scope, EventHubsNamespace? parent, string name, string version = EventHubsNamespace.DefaultVersion, bool isExisting = true, Func<string, EventHubData>? creator = null)
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
        public static EventHub FromExisting(IConstruct scope, string name, EventHubsNamespace parent)
            => new EventHub(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<EventHubsNamespace>() ?? new EventHubsNamespace(scope);
        }
    }
}
