// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewaySslProfile type. </summary>
    public partial class ApplicationGatewaySslProfile
    {
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public global::System.Nullable<global::System.Boolean> VerifyClientCertIssuerDN
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
