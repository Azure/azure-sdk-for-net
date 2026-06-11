// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class BastionHostData
    {
        public global::System.Nullable<global::System.Boolean> EnableIPConnect
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.BastionHostIPConfiguration> IPConfigurations => IpConfigurations;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.BastionHostIPRule> NetworkAclsIPRules => default;
    }
}
