// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.ServiceBus;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.Provisioning.ServiceBus
{
    /// <summary>
    /// Represents a Service Bus topic.
    /// </summary>
    public class ServiceBusTopic : Resource<ServiceBusTopicData>
    {
        private const string ResourceTypeName = "Microsoft.ServiceBus/namespaces/topics";
        private static ServiceBusTopicData Empty(string name) => ArmServiceBusModelFactory.ServiceBusTopicData();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusTopic"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="location">The location.</param>
        public ServiceBusTopic(IConstruct scope,
            ServiceBusNamespace? parent = null,
            string name = "topic",
            string version = ServiceBusNamespace.DefaultVersion,
            AzureLocation? location = default)
            : this(scope, parent, name, version, (name) => ArmServiceBusModelFactory.ServiceBusTopicData(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
        }

        private ServiceBusTopic(IConstruct scope,
            ServiceBusNamespace? parent = null,
            string name = "topic",
            string version = ServiceBusNamespace.DefaultVersion,
            Func<string, ServiceBusTopicData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceBusTopic"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static ServiceBusTopic FromExisting(IConstruct scope, string name, ServiceBusNamespace parent)
            => new ServiceBusTopic(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<ServiceBusNamespace>() ?? new ServiceBusNamespace(scope);
        }
    }
}
