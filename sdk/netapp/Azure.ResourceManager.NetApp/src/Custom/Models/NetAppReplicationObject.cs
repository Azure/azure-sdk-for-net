// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility:
    //   1. v1.15.0 had a public NetAppReplicationObject(ResourceIdentifier remoteVolumeResourceId)
    //      ctor; the generated code only emits the parameterless ctor (and an internal full ctor).
    //   2. v1.15.0 exposed `EndpointType` and `ReplicationId` as { get; set; }. The spec marks
    //      them @visibility(Lifecycle.Read), so the generated public surface lacks them — but the
    //      generated internal full ctor still assigns to them. The partial declarations below
    //      satisfy that assignment AND restore the v1.15 settable surface.
    public partial class NetAppReplicationObject
    {
        /// <summary> Initializes a new instance of <see cref="NetAppReplicationObject"/>. </summary>
        /// <param name="remoteVolumeResourceId"> The resource ID of the remote volume. </param>
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
