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
    // AsyncPageable<NetAppVolumeResource>. SnapshotPolicies.listVolumes is modeled as a
    // resource action, so the generator does not emit the GA pageable resource-returning
    // shape even though the REST operation still returns value[].
    public partial class SnapshotPolicyResource
    {
        /// <summary> Get volumes associated with snapshot policy. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetAppVolumeResource> GetVolumesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _snapshotPoliciesRestClient.CreateGetVolumesRequest(
                Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, new RequestContext { CancellationToken = cancellationToken });
            return PageableHelpers.CreateAsyncPageable(
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
            return PageableHelpers.CreatePageable(
                FirstPageRequest, null,
                e => new NetAppVolumeResource(Client, ResourceIdentifier.Parse(e.GetProperty("id").GetString())),
                _snapshotPoliciesClientDiagnostics, Pipeline,
                "SnapshotPolicyResource.GetVolumes", "value", null, cancellationToken);
        }
    }
}
