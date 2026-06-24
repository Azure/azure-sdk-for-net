// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ApplicationGatewayData type. </summary>
    public partial class ApplicationGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> AvailabilityZones { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.ApplicationGatewayEntraJwtValidationConfig> EntraJwtValidationConfigs { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.ApplicationGatewayEntraJwtValidationConfig>();
    }
}
