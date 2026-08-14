// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudStorageApplianceCollection : ArmCollection, IEnumerable<NetworkCloudStorageApplianceResource>, IAsyncEnumerable<NetworkCloudStorageApplianceResource>
    {
        /// <summary>
        /// Get a list of storage appliances in the provided resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAppliances_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudStorageApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkCloudStorageApplianceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudStorageApplianceResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// Get a list of storage appliances in the provided resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAppliances_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudStorageApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkCloudStorageApplianceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudStorageApplianceResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);
    }
}
