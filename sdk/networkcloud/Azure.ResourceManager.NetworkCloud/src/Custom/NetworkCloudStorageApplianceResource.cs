// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudStorageApplianceResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudStorageAppliancePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, cancellationToken).ConfigureAwait(false);

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudStorageApplianceResource> Update(WaitUntil waitUntil, NetworkCloudStorageAppliancePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, cancellationToken);

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
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudStorageApplianceResource> Update(WaitUntil waitUntil, NetworkCloudStorageAppliancePatch patch, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(waitUntil, patch, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);

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
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudStorageApplianceResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudStorageAppliancePatch patch, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, patch, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);
    }
}
