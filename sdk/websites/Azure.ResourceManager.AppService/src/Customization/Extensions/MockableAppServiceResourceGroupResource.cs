// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableAppServiceResourceGroupResource : ArmResource
    {
        /// <summary>
        /// Description for List all ResourceHealthMetadata for all sites in the resource group in the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata
        /// Operation Id: ResourceHealthMetadata_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceHealthMetadataData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ResourceHealthMetadataClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    var response = await ResourceHealthMetadataRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResourceHealthMetadataData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ResourceHealthMetadataClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    var response = await ResourceHealthMetadataRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for List all ResourceHealthMetadata for all sites in the resource group in the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata
        /// Operation Id: ResourceHealthMetadata_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataData(CancellationToken cancellationToken = default)
        {
            Page<ResourceHealthMetadataData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ResourceHealthMetadataClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    var response = ResourceHealthMetadataRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResourceHealthMetadataData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ResourceHealthMetadataClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    var response = ResourceHealthMetadataRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
