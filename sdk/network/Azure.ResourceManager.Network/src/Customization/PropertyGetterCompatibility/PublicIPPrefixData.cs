// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PublicIPPrefixData type. </summary>
    public partial class PublicIPPrefixData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String IPPrefix => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPTag> IPTags => default;
    }
}
