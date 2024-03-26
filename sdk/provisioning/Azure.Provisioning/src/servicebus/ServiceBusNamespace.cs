// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Storage;
using Azure.ResourceManager.ServiceBus;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.Provisioning.ServiceBus
{
    /// <summary>
    /// Represents a Service Bus namespace.
    /// </summary>
    public class ServiceBusNamespace : Resource<ServiceBusNamespaceData>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.servicebus/2021-11-01/namespaces?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.ServiceBus/namespaces";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/servicebus/Azure.ResourceManager.ServiceBus/src/Generated/RestOperations/NamespacesRestOperations.cs#L36
        internal const string DefaultVersion = "2021-11-01";

        private static ServiceBusNamespaceData Empty(string name) => ArmServiceBusModelFactory.ServiceBusNamespaceData();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusNamespace"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public ServiceBusNamespace(IConstruct scope,
            ServiceBusSku? sku = default,
            ResourceGroup? parent = null,
            string name = "sb",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, (name) => ArmServiceBusModelFactory.ServiceBusNamespaceData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                sku: sku ?? new ServiceBusSku(ServiceBusSkuName.Standard)))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private ServiceBusNamespace(IConstruct scope,
            ResourceGroup? parent = null,
            string name = "sb",
            string version = DefaultVersion,
            Func<string, ServiceBusNamespaceData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceBusNamespace"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static ServiceBusNamespace FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new ServiceBusNamespace(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
