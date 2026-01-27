// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;
using System.Security.Cryptography;
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
        private readonly ClientDiagnostics _elasticSanClientClientDiagnostics;
        private readonly ElasticSanRestOperations _elasticSanClientRestClient;

        /// <summary> Initializes a new instance of the <see cref="ElasticSanVolumeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ElasticSanVolumeResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string elasticSanVolumeApiVersion);
            _volumesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ElasticSan", ResourceType.Namespace, Diagnostics);
            _volumesRestClient = new Volumes(_volumesClientDiagnostics, Pipeline, Endpoint, elasticSanVolumeApiVersion ?? "2025-09-01");
            _elasticSanClientClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ElasticSan", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _elasticSanClientRestClient = new ElasticSanRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            ValidateResourceId(id);
        }

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

        /// <summary>
        /// Delete an Volume.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volume_Delete</description>
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
        /// <param name="deleteSnapshots"> Optional, used to delete snapshots under volume. Allowed value are only true or false. Default value is false. </param>
        /// <param name="forceDelete"> Optional, used to delete volume if active sessions present. Allowed value are only true or false. Default value is false. </param>
        /// <param name="deleteType"> Optional. Specifies that the delete operation should be a permanent delete for the soft deleted volume. The value of deleteType can only be 'permanent'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, ElasticSanDeleteSnapshotsUnderVolume? deleteSnapshots = null, ElasticSanForceDeleteVolume? forceDelete = null, ElasticSanDeleteType? deleteType = null, CancellationToken cancellationToken = default)
            => await DeleteAsync(waitUntil,deleteSnapshots,forceDelete,cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete an Volume.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volume_Delete</description>
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
        /// <param name="deleteSnapshots"> Optional, used to delete snapshots under volume. Allowed value are only true or false. Default value is false. </param>
        /// <param name="forceDelete"> Optional, used to delete volume if active sessions present. Allowed value are only true or false. Default value is false. </param>
        /// <param name="deleteType"> Optional. Specifies that the delete operation should be a permanent delete for the soft deleted volume. The value of deleteType can only be 'permanent'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, ElasticSanDeleteSnapshotsUnderVolume? deleteSnapshots = null, ElasticSanForceDeleteVolume? forceDelete = null, ElasticSanDeleteType? deleteType = null, CancellationToken cancellationToken = default)
            => Delete(waitUntil,deleteSnapshots,forceDelete,cancellationToken);

        /// <summary>
        /// Restore Soft Deleted Volumes. The volume name is obtained by using the API to list soft deleted volumes by volume group
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}/restore</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ElasticSan_RestoreVolume</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ElasticSanVolumeResource>> RestoreVolumeAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _elasticSanClientClientDiagnostics.CreateScope("ElasticSanVolumeResource.RestoreVolume");
            scope.Start();
            try
            {
                var response = await _elasticSanClientRestClient.RestoreVolumeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ElasticSanArmOperation<ElasticSanVolumeResource>(new ElasticSanVolumeOperationSource(Client), _elasticSanClientClientDiagnostics, Pipeline, _elasticSanClientRestClient.CreateRestoreVolumeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restore Soft Deleted Volumes. The volume name is obtained by using the API to list soft deleted volumes by volume group
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}/restore</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ElasticSan_RestoreVolume</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ElasticSanVolumeResource> RestoreVolume(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _elasticSanClientClientDiagnostics.CreateScope("ElasticSanVolumeResource.RestoreVolume");
            scope.Start();
            try
            {
                var response = _elasticSanClientRestClient.RestoreVolume(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new ElasticSanArmOperation<ElasticSanVolumeResource>(new ElasticSanVolumeOperationSource(Client), _elasticSanClientClientDiagnostics, Pipeline, _elasticSanClientRestClient.CreateRestoreVolumeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
