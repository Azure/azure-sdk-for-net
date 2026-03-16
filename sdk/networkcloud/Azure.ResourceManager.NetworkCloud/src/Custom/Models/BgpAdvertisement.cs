// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class BgpAdvertisement
    {
        /// <summary> The names of the IP address pools associated with this announcement. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> IPAddressPools => IpAddressPools;
    }
}
