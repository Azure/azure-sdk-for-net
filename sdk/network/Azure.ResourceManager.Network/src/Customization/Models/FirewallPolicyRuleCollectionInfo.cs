// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public abstract partial class FirewallPolicyRuleCollectionInfo
    {
        /// <summary> Initializes a new instance of the FirewallPolicyRuleCollectionInfo class. </summary>
        protected FirewallPolicyRuleCollectionInfo()
        {
        }

        // Absent in 1.15.0, but shipped in 1.17.0. Preserve the released subclass constructor signature.
        /// <summary> Initializes a new instance of the FirewallPolicyRuleCollectionInfo class. </summary>
        protected FirewallPolicyRuleCollectionInfo(bool _) { }
    }
}
