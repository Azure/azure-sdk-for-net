// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The IP Extended Communities patch resource definition. </summary>
    public partial class NetworkFabricIPExtendedCommunityPatch
    {
        /// <summary> List of IP Extended Community Rules. </summary>
        public IList<IPExtendedCommunityRule> IPExtendedCommunityRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new IpExtendedCommunityPatchProperties();
                }
                return Properties.IpExtendedCommunityRules;
            }
        }
    }
}
