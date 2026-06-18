// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the AdminRuleGroupData type. </summary>
    public partial class AdminRuleGroupData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ETag> ETag => default;
    }
}
