// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Replication properties. </summary>
    public partial class NetAppReplicationObject
    {
        /// <summary> Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ReplicationId { get; set; }

        /// <param name="remoteVolumeResourceId">
        /// The resource ID of the remote volume.
        /// Serialized Name: ReplicationObject.remoteVolumeResourceId
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="remoteVolumeResourceId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppReplicationObject(ResourceIdentifier remoteVolumeResourceId)
        {
            RemoteVolumeResourceId = remoteVolumeResourceId;
        }

        /// <summary> Indicates whether the local volume is the source or destination for the Volume Replication. </summary>
        public NetAppEndpointType? EndpointType
        {
            get;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set;
        }
    }
}
