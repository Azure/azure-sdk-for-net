// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class AzureFirewallData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.AzureFirewallIPConfiguration> IPConfigurations => IpConfigurations;
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.AzureFirewallIPGroups> IPGroups => default;
        public global::Azure.ResourceManager.Network.Models.AzureFirewallIPConfiguration ManagementIPConfiguration
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
