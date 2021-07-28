// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    ///  Generic list operations class. This can be extended if a specific RP has more list operations.
    /// </summary>
    public static class ResourceListOperations
    {
        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GenericResourceExpanded> GetAtContext(
            ResourceGroupOperations resourceGroup,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternal(
                resourceGroup,
                resourceGroup.Id.Name,
                resourceFilters,
                expand,
                top,
                cancellationToken);
        }

        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GenericResourceExpanded> GetAtContextAsync(
            ResourceGroupOperations resourceGroup,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternalAsync(
                resourceGroup,
                resourceGroup.Id.Name,
                resourceFilters,
                expand,
                top,
                cancellationToken);
        }

        /// <summary>
        /// List resources under a subscription
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GenericResourceExpanded> GetAtContext(
            SubscriptionOperations subscription,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternal(
                subscription,
                null,
                resourceFilters,
                expand,
                top,
                cancellationToken);
        }

        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GenericResourceExpanded> GetAtContextAsync(
            SubscriptionOperations subscription,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternalAsync(
                subscription,
                null,
                resourceFilters,
                expand,
                top,
                cancellationToken);
        }

        private static GenericResourceContainer GetGenericResourceContainer(ResourceOperations resourceOperations)
        {
            return new GenericResourceContainer(new ClientContext(resourceOperations.ClientOptions, resourceOperations.Credential, resourceOperations.BaseUri, resourceOperations.Pipeline), resourceOperations.Id);
        }

        private static AsyncPageable<GenericResourceExpanded> ListAtContextInternalAsync(
            ResourceOperations resourceOperations,
            string scopeFilter,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            var restClient = GetGenericResourceContainer(resourceOperations);
            AsyncPageable<GenericResourceExpanded> result;
            if (scopeFilter == null)
            {
                result = restClient.GetAllAsync(resourceFilters?.ToString(), expand, top, cancellationToken);
            }
            else
            {
                result = restClient.GetByResourceGroupAsync(
                    scopeFilter,
                    resourceFilters?.ToString(),
                    expand,
                    top,
                    cancellationToken);
            }

            return result;
        }

        private static Pageable<GenericResourceExpanded> ListAtContextInternal(
            ResourceOperations resourceOperations,
            string scopeFilter = null,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            var restClient = GetGenericResourceContainer(resourceOperations);
            Pageable<GenericResourceExpanded> result;
            if (scopeFilter == null)
            {
                result = restClient.GetAll(resourceFilters?.ToString(), expand, top, cancellationToken);
            }
            else
            {
                result = restClient.GetByResourceGroup(
                    scopeFilter,
                    resourceFilters?.ToString(),
                    expand,
                    top,
                    cancellationToken);
            }

            return result;
        }
    }
}
