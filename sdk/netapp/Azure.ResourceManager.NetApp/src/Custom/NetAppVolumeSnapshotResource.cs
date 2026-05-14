// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppVolumeSnapshotResource
    {
        // Backward-compat only: v1.15 exposed Update overloads accepting NetAppVolumeSnapshotData
        // before the service added a distinct PATCH operation. Preserve those overloads by
        // sending the same PUT request shape as the original generated Update implementation.
        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeSnapshotResource> Update(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _snapshotsClientDiagnostics.CreateScope("NetAppVolumeSnapshotResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _snapshotsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, NetAppVolumeSnapshotData.ToRequestContent(data), context);
                Response response = Pipeline.ProcessMessage(message, context);
                NetAppArmOperation<NetAppVolumeSnapshotResource> operation = new NetAppArmOperation<NetAppVolumeSnapshotResource>(
                    new NetAppVolumeSnapshotOperationSource(Client),
                    _snapshotsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update a snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeSnapshotResource>> UpdateAsync(WaitUntil waitUntil, NetAppVolumeSnapshotData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _snapshotsClientDiagnostics.CreateScope("NetAppVolumeSnapshotResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _snapshotsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, NetAppVolumeSnapshotData.ToRequestContent(data), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetAppArmOperation<NetAppVolumeSnapshotResource> operation = new NetAppArmOperation<NetAppVolumeSnapshotResource>(
                    new NetAppVolumeSnapshotOperationSource(Client),
                    _snapshotsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
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
