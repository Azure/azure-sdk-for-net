// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageSync.Models;

// This customization will be removed once we have support for new pageable decorator https://github.com/Azure/typespec-azure/issues/3650
namespace Azure.ResourceManager.StorageSync
{
    /// <summary>
    /// A class representing a StorageSyncService along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="StorageSyncServiceResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetStorageSyncServices method.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("StorageSyncServiceResource")]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByStorageSyncService", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByStorageSyncServiceAsync", typeof(CancellationToken))]
    public partial class StorageSyncServiceResource : ArmResource
    {
        /// <summary>
        /// Gets the private link resources that need to be created for a storage sync service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageSync/storageSyncServices/{storageSyncServiceName}/privateLinkResources. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> StorageSyncServices_ListByStorageSyncService. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="StorageSyncServiceResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageSyncPrivateLinkResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StorageSyncPrivateLinkResource> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new StorageSyncServicesGetByStorageSyncServiceAsyncCollectionResultOfT(_storageSyncServicesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary>
        /// Gets the private link resources that need to be created for a storage sync service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageSync/storageSyncServices/{storageSyncServiceName}/privateLinkResources. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> StorageSyncServices_ListByStorageSyncService. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="StorageSyncServiceResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageSyncPrivateLinkResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StorageSyncPrivateLinkResource> GetPrivateLinkResources(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new StorageSyncServicesGetByStorageSyncServiceCollectionResultOfT(_storageSyncServicesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
        }
    }
}
