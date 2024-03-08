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
    /// Represents a Service Bus queue.
    /// </summary>
    public class ServiceBusQueue : Resource<ServiceBusQueueData>
    {
        private const string ResourceTypeName = "Microsoft.ServiceBus/namespaces/queues";
        private static readonly Func<string, ServiceBusQueueData> Empty = (name) => ArmServiceBusModelFactory.ServiceBusQueueData();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusQueue"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="requiresSession">Whether to use sessions.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public ServiceBusQueue(IConstruct scope, bool? requiresSession = default, ServiceBusNamespace? parent = null, string name = "sbqueue", string version = ServiceBusNamespace.DefaultVersion, AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmServiceBusModelFactory.ServiceBusQueueData(
                name: name,
                requiresSession: requiresSession,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        private ServiceBusQueue(IConstruct scope, ServiceBusNamespace? parent = null, string name = "sbqueue", string version = ServiceBusNamespace.DefaultVersion, bool isExisting = true, Func<string, ServiceBusQueueData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, ServiceBusNamespace.DefaultVersion, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceBusQueue"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static ServiceBusQueue FromExisting(IConstruct scope, string name, ServiceBusNamespace parent)
            => new ServiceBusQueue(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<ServiceBusNamespace>() ?? new ServiceBusNamespace(scope);
        }
    }
}
