// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed `PeerIPAddresses` (all-caps); the spec field `peerIpAddresses`
    // generates `PeerIpAddresses`. @@clientName could rename it to "PeerIPAddresses" but that
    // would *break* GA users still calling `PeerIpAddresses` — keep both names by aliasing here.
    //
    // TODO: tracked by https://github.com/Azure/azure-sdk-for-net/issues/58989 — once the
    // spec is updated to type IP fields as Azure.Core.ipV4Address (so the generator emits
    // `System.Net.IPAddress` directly), revisit whether this casing shim is still needed.
    public partial class PeerClusterForVolumeMigrationContent
    {
        /// <summary> A list of IC-LIF IPs that can be used to connect to the on-prem cluster (legacy alias for <see cref="PeerIpAddresses"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> PeerIPAddresses => PeerIpAddresses;
    }
}
