// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core.Adapters;
using Azure.ResourceManager.Core.Resources;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

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
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<GenericResource> ListAtContext(
            ResourceGroupOperations resourceGroup,
            ResourceFilterCollection resourceFilters = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternal(
                resourceGroup,
                resourceGroup.Id.Name,
                resourceFilters,
                top,
                cancellationToken);
        }

        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns>An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GenericResource> ListAtContextAsync(
            ResourceGroupOperations resourceGroup,
            ResourceFilterCollection resourceFilters = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternalAsync(
                resourceGroup,
                resourceGroup.Id.Name,
                resourceFilters,
                top,
                cancellationToken);
        }

        /// <summary>
        /// List resources under a subscription
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<GenericResource> ListAtContext(
            SubscriptionOperations subscription,
            ResourceFilterCollection resourceFilters = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternal(
                subscription,
                null,
                resourceFilters,
                top,
                cancellationToken);
        }

        /// <summary>
        /// List resources under the a resource context
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations"/> instance to use for the list. </param>
        /// <param name="resourceFilters"> Optional filters for results. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GenericResource> ListAtContextAsync(
            SubscriptionOperations subscription,
            ResourceFilterCollection resourceFilters = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            return ListAtContextInternalAsync(
                subscription,
                null,
                resourceFilters,
                top,
                cancellationToken);
        }

        private static ResourcesManagementClient GetResourcesClient(ResourceOperationsBase resourceOperations)
        {
            var subscription = resourceOperations.Id as SubscriptionResourceIdentifier;
            return new ResourcesManagementClient(resourceOperations.BaseUri, subscription?.SubscriptionId, resourceOperations.Credential);
        }

        private static AsyncPageable<GenericResource> ListAtContextInternalAsync(
            ResourceOperationsBase resourceOperations,
            string scopeFilter,
            ResourceFilterCollection resourceFilters = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            var armOperations = GetResourcesClient(resourceOperations).Resources;
            AsyncPageable<GenericResourceExpanded> result;
            if (scopeFilter == null)
            {
                result = armOperations.ListAsync(resourceFilters?.ToString(), null, top, cancellationToken);
            }
            else
            {
                result = armOperations.ListByResourceGroupAsync(
                    scopeFilter,
                    resourceFilters?.ToString(),
                    null,
                    top,
                    cancellationToken);
            }

            return ConvertResultsAsync(result, resourceOperations);
        }

        private static Pageable<GenericResource> ListAtContextInternal(
            ResourceOperationsBase resourceOperations,
            string scopeFilter = null,
            ResourceFilterCollection resourceFilters = null,
            int? top = null,
            CancellationToken cancellationToken = default)
        {
            var armOperations = GetResourcesClient(resourceOperations).Resources;
            Pageable<GenericResourceExpanded> result;
            if (scopeFilter == null)
            {
                result = armOperations.List(resourceFilters?.ToString(), null, top, cancellationToken);
            }
            else
            {
                result = armOperations.ListByResourceGroup(
                    scopeFilter,
                    resourceFilters?.ToString(),
                    null,
                    top,
                    cancellationToken);
            }

            return ConvertResults(result, resourceOperations);
        }

        private static Pageable<GenericResource> ConvertResults(
            Pageable<GenericResourceExpanded> result,
            ResourceOperationsBase resourceOperations)
        {
            return new PhWrappingPageable<GenericResourceExpanded, GenericResource>(
                result,
                CreateResourceConverter(resourceOperations));
        }

        private static AsyncPageable<GenericResource> ConvertResultsAsync(
            AsyncPageable<GenericResourceExpanded> result,
            ResourceOperationsBase resourceOperations)
        {
            return new PhWrappingAsyncPageable<GenericResourceExpanded, GenericResource>(
                result,
                CreateResourceConverter(resourceOperations));
        }

        private static Func<GenericResourceExpanded, GenericResource> CreateResourceConverter(ResourceOperationsBase resourceOperations)
        {
            return s =>
            {
                var args = new object[]
                {
                    resourceOperations,
                    Activator.CreateInstance(typeof(GenericResourceData), s as ResourceManager.Resources.Models.GenericResource) as GenericResourceData,
                };

                return Activator.CreateInstance(
                    typeof(GenericResource),
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    args,
                    CultureInfo.InvariantCulture) as GenericResource;
            };
        }
    }
}
