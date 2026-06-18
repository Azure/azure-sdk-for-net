// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayPrivateLinkConfiguration type. </summary>
    public partial class ApplicationGatewayPrivateLinkConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.ApplicationGatewayPrivateLinkIPConfiguration> IPConfigurations => default;
    }
}
