// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A Class representing a NetworkCloudStorageAppliance along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NetworkCloudStorageApplianceResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNetworkCloudStorageApplianceResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetNetworkCloudStorageAppliance method.
    /// </summary>
    public partial class NetworkCloudStorageApplianceResource : ArmResource
    {
        /// <summary>
        /// Update properties of the provided storage appliance, or update tags associated with the storage appliance Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAppliances_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudStorageApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudStorageApplianceResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudStorageAppliancePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update properties of the provided storage appliance, or update tags associated with the storage appliance Properties and tag updates can be done independently.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAppliances_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudStorageApplianceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudStorageApplianceResource> Update(WaitUntil waitUntil, NetworkCloudStorageAppliancePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, null, cancellationToken);
    }
}
