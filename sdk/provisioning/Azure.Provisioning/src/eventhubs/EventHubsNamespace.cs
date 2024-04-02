// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;

namespace Azure.Provisioning.EventHubs
{
    /// <summary>
    /// Represents an EventHubsNamespace.
    /// </summary>
    public class EventHubsNamespace : Resource<EventHubsNamespaceData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.eventhub/2021-11-01/namespaces?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.EventHub/namespaces";
        // https://github.com/Azure/azure-sdk-for-net/blob/Azure.ResourceManager.EventHubs_1.0.1/sdk/eventhub/Azure.ResourceManager.EventHubs/src/Generated/RestOperations/NamespacesRestOperations.cs#L36C42-L36C52
        internal const string DefaultVersion = "2021-11-01";

        private static EventHubsNamespaceData Empty(string name) => ArmEventHubsModelFactory.EventHubsNamespaceData();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHubsNamespace"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public EventHubsNamespace(
            IConstruct scope,
            EventHubsSku? sku = default,
            ResourceGroup? parent = null,
            string name = "eh",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmEventHubsModelFactory.EventHubsNamespaceData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: sku ?? new EventHubsSku(EventHubsSkuName.Standard)))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private EventHubsNamespace(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            bool isExisting = false,
            Func<string, EventHubsNamespaceData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EventHubsNamespace"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static EventHubsNamespace FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new EventHubsNamespace(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
