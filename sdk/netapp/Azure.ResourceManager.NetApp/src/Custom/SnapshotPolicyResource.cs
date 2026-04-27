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
    // Backward-compat: re-expose GetVolumes / GetVolumesAsync as Pageable<NetAppVolumeResource> /
    // AsyncPageable<NetAppVolumeResource>. Two pieces are missing from the new mgmt emitter that
    // the old Swagger generator handled automatically:
    //   1. Pageability: SnapshotPolicies.listVolumes is modelled as ArmResourceActionSync (an action
    //      template), not a list template. The .NET mgmt emitter only auto-emits Pageable<T> for
    //      canonical list operations, so the action is emitted as a single-call
    //      Response<SnapshotPolicyVolumeList> even though the response carries value[] + nextLink.
    //   2. Element wrapping: even with @@markAsPageable, the element type would be the data model
    //      (VolumeData), not the ARM resource (NetAppVolumeResource). There is no decorator today
    //      for "wrap each element as resource X" on non-list operations.
    // This shim closes both gaps: it pages the action response and constructs a
    // NetAppVolumeResource for each element using the id in the payload.
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
