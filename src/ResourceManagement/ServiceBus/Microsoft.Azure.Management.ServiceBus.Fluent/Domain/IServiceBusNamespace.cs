// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ServiceBusNamespace.Update;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Service Bus namespace.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IServiceBusNamespace  :
        IGroupableResource<ServiceBus.Fluent.IServiceBusManager, Management.Fluent.ServiceBus.Models.NamespaceModelInner>,
        IRefreshable<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        IUpdatable<ServiceBusNamespace.Update.IUpdate>
    {
        /// <summary>
        /// Gets time the namespace was created.
        /// </summary>
        System.DateTime CreatedAt { get; }

        /// <summary>
        /// Gets fully qualified domain name (FQDN) of the Service Bus namespace.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets entry point to manage queue entities in the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.IQueues Queues { get; }

        /// <summary>
        /// Gets entry point to manage topics entities in the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.ITopics Topics { get; }

        /// <summary>
        /// Gets the relative DNS name of the Service Bus namespace.
        /// </summary>
        string DnsLabel { get; }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets sku value.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.NamespaceSku Sku { get; }

        /// <summary>
        /// Gets time the namespace was updated.
        /// </summary>
        System.DateTime UpdatedAt { get; }
    }
}