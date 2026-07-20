// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the FirewallPolicy data model.
    /// FirewallPolicy Resource.
    /// </summary>
    public partial class FirewallPolicyData : NetworkTrackedResourceData
    {
        /// <summary> List of private IP addresses/IP address ranges to not be SNAT. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> SnatPrivateRanges
        {
            get
            {
                if (Snat is null)
                    Snat = new FirewallPolicySnat();
                return Snat.PrivateRanges;
            }
        }
    }
}
