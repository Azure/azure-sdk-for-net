// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CustomIPPrefixData type. </summary>
    [CodeGenSuppress("ChildCustomIPPrefixes")]
    [CodeGenSuppress("CustomIPPrefixParent")]
    [CodeGenSuppress("PublicIPPrefixes")]
    public partial class CustomIPPrefixData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> ChildCustomIPPrefixList { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.CustomIPPrefixData> ChildCustomIPPrefixes { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.CustomIPPrefixData>();
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public global::Azure.ResourceManager.Network.CustomIPPrefixData CustomIPPrefixParent { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixes { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
    }
}
