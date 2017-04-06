// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using ServiceBusNamespace.Definition;
    using Microsoft.Rest;
    using ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using ServiceBus.Fluent;
    using Management.Fluent.ServiceBus;

    /// <summary>
    /// Entry point to Service Bus namespace API in Azure.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IServiceBusNamespaces  :
        ISupportsCreating<ServiceBusNamespace.Definition.IBlank>,
        ISupportsBatchCreation<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ISupportsBatchDeletion,
        ISupportsListing<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ISupportsGettingById<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        IHasManager<IServiceBusManager>,
        IHasInner<INamespacesOperations>
    {
        /// <summary>
        /// Checks if namespace name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The namespace name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Task<Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks if namespace name is valid and is not in use.
        /// </summary>
        /// <param name="name">The account name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult CheckNameAvailability(string name);
    }
}