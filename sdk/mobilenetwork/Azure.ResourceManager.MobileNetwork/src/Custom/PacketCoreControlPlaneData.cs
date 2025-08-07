// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MobileNetwork
{
    /// <summary>
    /// A class representing the PacketCoreControlPlane data model.
    /// Packet core control plane resource.
    /// </summary>
    public partial class PacketCoreControlPlaneData : TrackedResourceData
    {
        /// <summary> The MTU (in bytes) signaled to the UE. The same MTU is set on the user plane data links for all data networks. The MTU set on the user plane access link is calculated to be 60 bytes greater than this value to allow for GTP encapsulation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? UeMtu { get => UEMtu; set => UEMtu = value; }

        /// <summary> The macro network's MME group ID. This is where unknown UEs are sent to via NAS reroute. </summary>
        public int? NasRerouteMacroMmeGroupId { get => Signaling.NasRerouteMacroMmeGroupId; set => Signaling.NasRerouteMacroMmeGroupId = value; }
    }
}
