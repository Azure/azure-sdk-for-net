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
        /// <param name="resourceGroup"> The <see cref="ResourceGroup"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GenericResource> GetAtContext(
            ResourceGroup resourceGroup,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetGenericResources(resourceFilters?.ToString(), expand, top, cancellationToken);
        }

        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GenericResource> GetAtContextAsync(
            ResourceGroup resourceGroup,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetGenericResourcesAsync(resourceFilters?.ToString(), expand, top, cancellationToken);
        }

        /// <summary>
        /// List resources under a subscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GenericResource> GetAtContext(
            Subscription subscription,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return subscription.GetGenericResources(resourceFilters?.ToString(), expand, top, cancellationToken);
        }

        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. For example, `$expand=createdTime,changedTime`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GenericResource> GetAtContextAsync(
            Subscription subscription,
            ResourceFilterCollection resourceFilters = null,
            string expand = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return subscription.GetGenericResourcesAsync(resourceFilters?.ToString(), expand, top, cancellationToken);
        }
    }
}
