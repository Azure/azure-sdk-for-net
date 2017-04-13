// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Management.Fluent.ServiceBus.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update;
    using ServiceBus.Fluent;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Service Bus namespace.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IServiceBusNamespace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IServiceBusManager, NamespaceModelInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ServiceBusNamespace.Update.IUpdate>
    {
        /// <summary>
        /// Gets time the namespace was updated.
        /// </summary>
        System.DateTime UpdatedAt { get; }

        /// <summary>
        /// Gets entry point to manage topics entities in the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.ITopics Topics { get; }

        /// <summary>
        /// Gets the relative DNS name of the Service Bus namespace.
        /// </summary>
        string DnsLabel { get; }

        /// <summary>
        /// Gets time the namespace was created.
        /// </summary>
        System.DateTime CreatedAt { get; }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets entry point to manage queue entities in the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IQueues Queues { get; }

        /// <summary>
        /// Gets sku value.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceSku Sku { get; }

        /// <summary>
        /// Gets fully qualified domain name (FQDN) of the Service Bus namespace.
        /// </summary>
        string Fqdn { get; }
    }
}