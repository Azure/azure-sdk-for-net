// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ElasticSan.Models;

namespace Azure.ResourceManager.ElasticSan
{
    /// <summary>
    /// A Class representing an ElasticSanVolume along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="ElasticSanVolumeResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetElasticSanVolumeResource method.
    /// Otherwise you can get one from its parent resource <see cref="ElasticSanVolumeGroupResource"/> using the GetElasticSanVolume method.
    /// </summary>
    public partial class ElasticSanVolumeResource : ArmResource
    {
        /// <summary>
        /// Delete an Volume.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volumes_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ElasticSanVolumeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="xmsDeleteSnapshots"> Optional, used to delete snapshots under volume. Allowed value are only true or false. Default value is false. </param>
        /// <param name="xmsForceDelete"> Optional, used to delete volume if active sessions present. Allowed value are only true or false. Default value is false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, XmsDeleteSnapshot? xmsDeleteSnapshots, XmsForceDelete? xmsForceDelete, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, xmsDeleteSnapshots.ToString(), xmsForceDelete.ToString(), null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete an Volume.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volumes_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ElasticSanVolumeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="xmsDeleteSnapshots"> Optional, used to delete snapshots under volume. Allowed value are only true or false. Default value is false. </param>
        /// <param name="xmsForceDelete"> Optional, used to delete volume if active sessions present. Allowed value are only true or false. Default value is false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, XmsDeleteSnapshot? xmsDeleteSnapshots, XmsForceDelete? xmsForceDelete, CancellationToken cancellationToken)
            => Delete(waitUntil, xmsDeleteSnapshots.ToString(), xmsForceDelete.ToString(), null, cancellationToken);
    }
}
