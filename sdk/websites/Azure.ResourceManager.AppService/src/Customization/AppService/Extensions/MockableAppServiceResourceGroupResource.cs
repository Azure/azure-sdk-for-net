// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
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
                using var scope = ResourceHealthMetadataNonResourceOperationGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = ResourceHealthMetadataNonResourceOperationGroupRestClient.CreateGetAllResourceHealthMetadataDataRequest(Id.ResourceGroupName, Guid.Parse(Id.SubscriptionId), context);
                    var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    ResourceHealthMetadataListResult result = ResourceHealthMetadataListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResourceHealthMetadataData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ResourceHealthMetadataNonResourceOperationGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = ResourceHealthMetadataNonResourceOperationGroupRestClient.CreateNextGetAllResourceHealthMetadataDataRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Id.ResourceGroupName, Guid.Parse(Id.SubscriptionId), context);
                    var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    ResourceHealthMetadataListResult result = ResourceHealthMetadataListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
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
                using var scope = ResourceHealthMetadataNonResourceOperationGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = ResourceHealthMetadataNonResourceOperationGroupRestClient.CreateGetAllResourceHealthMetadataDataRequest(Id.ResourceGroupName, Guid.Parse(Id.SubscriptionId), context);
                    var response = Pipeline.ProcessMessage(message, context);
                    ResourceHealthMetadataListResult result = ResourceHealthMetadataListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResourceHealthMetadataData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ResourceHealthMetadataNonResourceOperationGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = ResourceHealthMetadataNonResourceOperationGroupRestClient.CreateNextGetAllResourceHealthMetadataDataRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Id.ResourceGroupName, Guid.Parse(Id.SubscriptionId), context);
                    var response = Pipeline.ProcessMessage(message, context);
                    ResourceHealthMetadataListResult result = ResourceHealthMetadataListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
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
