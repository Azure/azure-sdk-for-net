// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CustomIPPrefixData type. </summary>
    public partial class CustomIPPrefixData
    {
        /// <summary> The Parent CustomIpPrefix for IPv6 /64 CustomIpPrefix. </summary>
        [WirePath("properties.customIpPrefixParent")]
        public ResourceIdentifier ParentCustomIPPrefixId
        {
            get => Properties is null ? default : Properties.CustomIPPrefixParent;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
