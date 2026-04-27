// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// Backward-compat shims for SnapshotPolicyResource that re-expose GetVolumes /
    /// GetVolumesAsync with the legacy <see cref="AsyncPageable{NetAppVolumeResource}"/> /
    /// <see cref="Pageable{NetAppVolumeResource}"/> signatures used by callers prior to the
    /// TypeSpec migration.
    /// </summary>
    // Why a custom shim instead of just `@@markAsPageable` in client.tsp:
    //
    // 1. Pageability: The spec defines `SnapshotPolicies.listVolumes` with `ArmResourceActionSync`
    //    (an action template), not a list template. The .NET mgmt emitter only auto-emits
    //    `Pageable<T>` for canonical list operations, so the operation is emitted as a single-call
    //    `Response<SnapshotPolicyVolumeList>` even though the response contains `value[]` +
    //    `nextLink`. `@@markAsPageable` could restore pageability here.
    //
    // 2. Element type: The old Swagger generator wrapped each `value[i]` as the corresponding ARM
    //    resource (NetAppVolumeResource) by recognizing the resource schema/path. The TypeSpec
    //    mgmt emitter only performs that resource-wrapping for standard list-by-parent operations
    //    on a resource's collection — not for arbitrary actions whose array element happens to
    //    match a known resource. There is no decorator today for "wrap each element as resource X."
    //    So even with `@@markAsPageable`, the result would be `Pageable<VolumeData>` (the data
    //    model), not `Pageable<NetAppVolumeResource>`.
    //
    // This shim closes both gaps: it pages the action response and constructs a
    // NetAppVolumeResource for each item using the `id` in the payload.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetVolumes", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetVolumesAsync", typeof(CancellationToken))]
    public partial class SnapshotPolicyResource
    {
        /// <summary> Get volumes associated with snapshot policy. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetAppVolumeResource> GetVolumesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _snapshotPoliciesRestClient.CreateGetVolumesRequest(
                Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, new RequestContext { CancellationToken = cancellationToken });
            return GeneratorPageableHelpers.CreateAsyncPageable(
                FirstPageRequest, null,
                e => new NetAppVolumeResource(Client, ResourceIdentifier.Parse(e.GetProperty("id").GetString())),
                _snapshotPoliciesClientDiagnostics, Pipeline,
                "SnapshotPolicyResource.GetVolumes", "value", null, cancellationToken);
        }

        /// <summary> Get volumes associated with snapshot policy. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<NetAppVolumeResource> GetVolumes(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _snapshotPoliciesRestClient.CreateGetVolumesRequest(
                Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, new RequestContext { CancellationToken = cancellationToken });
            return GeneratorPageableHelpers.CreatePageable(
                FirstPageRequest, null,
                e => new NetAppVolumeResource(Client, ResourceIdentifier.Parse(e.GetProperty("id").GetString())),
                _snapshotPoliciesClientDiagnostics, Pipeline,
                "SnapshotPolicyResource.GetVolumes", "value", null, cancellationToken);
        }
    }
}
