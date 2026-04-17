// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Adds setter for EndpointType and ReplicationId which are
// read-only in the generated code due to @visibility(Lifecycle.Read) in the spec.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Replication properties. </summary>
    public partial class NetAppReplicationObject
    {
        /// <param name="remoteVolumeResourceId">
        /// The resource ID of the remote volume.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppReplicationObject(ResourceIdentifier remoteVolumeResourceId)
        {
            RemoteVolumeResourceId = remoteVolumeResourceId;
        }

        /// <summary> Id. </summary>
        public string ReplicationId
        {
            get => _replicationId;
            set => _replicationId = value;
        }
        private string _replicationId;

        /// <summary> Indicates whether the local volume is the source or destination for the Volume Replication. </summary>
        public NetAppEndpointType? EndpointType
        {
            get => _endpointType;
            set => _endpointType = value;
        }
        private NetAppEndpointType? _endpointType;
    }
}
