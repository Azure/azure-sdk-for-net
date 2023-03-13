// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Mock
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        /// <summary>
        /// Description for List all ResourceHealthMetadata for all sites in the resource group in the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceHealthMetadata_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataDataAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceHealthMetadataRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResourceHealthMetadataRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ResourceHealthMetadataData.DeserializeResourceHealthMetadataData, ResourceHealthMetadataClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for List all ResourceHealthMetadata for all sites in the resource group in the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceHealthMetadata_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataData(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceHealthMetadataRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResourceHealthMetadataRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ResourceHealthMetadataData.DeserializeResourceHealthMetadataData, ResourceHealthMetadataClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAllResourceHealthMetadataData", "value", "nextLink", cancellationToken);
        }
    }
}
