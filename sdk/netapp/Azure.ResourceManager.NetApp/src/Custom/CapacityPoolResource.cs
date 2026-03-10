// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> A class representing a CapacityPool along with backward compat operations. </summary>
    public partial class CapacityPoolResource : ArmResource
    {
        /// <summary> Gets a collection of NetAppVolumeResources in the CapacityPool. </summary>
        /// <returns> An object representing collection of NetAppVolumeResources and their operations over a NetAppVolumeResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeCollection GetNetAppVolumes()
        {
            return GetCachedClient(client => new NetAppVolumeCollection(client, Id));
        }

        /// <summary> Gets a specific volume. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeResource>> GetNetAppVolumeAsync(string volumeName, CancellationToken cancellationToken = default)
        {
            var collection = GetNetAppVolumes();
            var result = await GetVolumes().GetAsync(volumeName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new NetAppVolumeResource(Client, result.Value.Data.Id), result.GetRawResponse());
        }

        /// <summary> Gets a specific volume. </summary>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeResource> GetNetAppVolume(string volumeName, CancellationToken cancellationToken = default)
        {
            var result = GetVolumes().Get(volumeName, cancellationToken);
            return Response.FromValue(new NetAppVolumeResource(Client, result.Value.Data.Id), result.GetRawResponse());
        }
    }
}
