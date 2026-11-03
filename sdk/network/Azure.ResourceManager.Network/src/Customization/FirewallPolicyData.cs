// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class FirewallPolicyData
    {
        // Preserve the 1.15 compatibility facade over the native change-tracking list.
        /// <summary> Gets the private IP addresses/IP address ranges to which traffic will not be SNAT. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> SnatPrivateRanges
        {
            get
            {
                Snat ??= new FirewallPolicySnat();
                return Snat.PrivateRanges;
            }
        }
    }
}
