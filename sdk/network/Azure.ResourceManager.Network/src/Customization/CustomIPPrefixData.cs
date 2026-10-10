// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CustomIPPrefixData type. </summary>
    [CodeGenSuppress("ChildCustomIPPrefixes")]
    [CodeGenSuppress("PublicIPPrefixes")]
    public partial class CustomIPPrefixData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> ChildCustomIPPrefixList { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.CustomIPPrefixData> ChildCustomIPPrefixes { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.CustomIPPrefixData>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixes { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();

        // Preserve the released model-valued alias while forwarding its resource identifier.
        /// <inheritdoc cref="ParentCustomIPPrefixId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [WirePath("properties.customIpPrefixParent")]
        public CustomIPPrefixData CustomIPPrefixParent
        {
            get => ParentCustomIPPrefixId is null ? null : new CustomIPPrefixData { Id = ParentCustomIPPrefixId };
            set => ParentCustomIPPrefixId = value?.Id;
        }
    }
}
