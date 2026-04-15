// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class PeerClusterForVolumeMigrationContent
    {
        /// <summary> A list of IC-LIF IPs that can be used to connect to the On-prem cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> PeerIPAddresses => PeerIpAddresses;
    }
}
