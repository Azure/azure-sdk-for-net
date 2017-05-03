// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to Service Bus namespace API in Azure.
    /// </summary>
    public interface IServiceBusNamespaces  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ServiceBusNamespace.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ServiceBus.Fluent.INamespacesOperations>
    {
        /// <summary>
        /// Checks if namespace name is valid and is not in use asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The namespace name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Task<Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks if namespace name is valid and is not in use.
        /// </summary>
        /// <param name="name">The account name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ICheckNameAvailabilityResult CheckNameAvailability(string name);
    }
}