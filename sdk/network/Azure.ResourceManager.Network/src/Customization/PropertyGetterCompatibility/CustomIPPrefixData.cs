// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CustomIPPrefixData type. </summary>
    public partial class CustomIPPrefixData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> ChildCustomIPPrefixList => default;
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.CustomIPPrefixData> ChildCustomIPPrefixes => default;
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public global::Azure.ResourceManager.Network.CustomIPPrefixData CustomIPPrefixParent
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixes => default;
    }
}
