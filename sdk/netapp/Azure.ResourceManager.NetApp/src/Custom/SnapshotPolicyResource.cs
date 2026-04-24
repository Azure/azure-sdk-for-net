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
    /// Backward-compat shims for SnapshotPolicyResource.
    /// Suppresses the generated GetVolumes/GetVolumesAsync (which return Response&lt;SnapshotPolicyVolumeList&gt;)
    /// and re-exposes them with the legacy AsyncPageable&lt;NetAppVolumeResource&gt; / Pageable&lt;NetAppVolumeResource&gt;
    /// signatures used by callers prior to the TypeSpec migration.
    /// </summary>
    /// <remarks>
    /// Why a custom shim instead of just <c>@@markAsPageable</c> in client.tsp:
    ///
    /// 1. Pageability: The spec defines <c>SnapshotPolicies.listVolumes</c> with
    ///    <c>ArmResourceActionSync</c> (an action template), not a list template. The .NET mgmt
    ///    emitter only auto-emits <c>Pageable&lt;T&gt;</c> for canonical list operations, so the
    ///    operation is emitted as a single-call <c>Response&lt;SnapshotPolicyVolumeList&gt;</c> even
    ///    though the response contains <c>value[]</c> + <c>nextLink</c>.
    ///    <c>@@markAsPageable</c> could restore pageability here.
    ///
    /// 2. Element type: The old Swagger generator wrapped each <c>value[i]</c> as the
    ///    corresponding ARM resource (<c>NetAppVolumeResource</c>) by recognizing the resource
    ///    schema/path. The TypeSpec mgmt emitter only performs that resource-wrapping for
    ///    standard list-by-parent operations on a resource's collection — not for arbitrary
    ///    actions whose array element happens to match a known resource. There is no
    ///    decorator today for "wrap each element as resource X." So even with
    ///    <c>@@markAsPageable</c>, the result would be <c>Pageable&lt;VolumeData&gt;</c> (the data
    ///    model), not <c>Pageable&lt;NetAppVolumeResource&gt;</c>.
    ///
    /// This shim closes both gaps: it pages the action response and constructs a
    /// <c>NetAppVolumeResource</c> for each item using the <c>id</c> in the payload.
    /// </remarks>
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
