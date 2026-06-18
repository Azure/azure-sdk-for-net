// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualApplianceAdditionalNicProperties type. </summary>
    public partial class VirtualApplianceAdditionalNicProperties
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> HasPublicIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
