// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ClusterPeerCommandResult
    {
        /// <summary>
        /// Gets the cluster peering command to run to accept the cluster peer.
        /// Returns an empty string when the service payload does not include the command.
        /// </summary>
        public string ClusterPeeringCommand => Properties?.ClusterPeeringCommand ?? string.Empty;

        /// <summary>
        /// Gets the cluster peer accept command.
        /// This is a backward-compatible alias of <see cref="ClusterPeeringCommand"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PeerAcceptCommand => ClusterPeeringCommand;
    }
}
