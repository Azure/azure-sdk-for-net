// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionListEntity type. </summary>
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary> Gets or sets the AuthorizationKey compatibility property. </summary>
        public System.String AuthorizationKey { get; set; }

        /// <summary> Gets or sets the ConnectionMode compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionMode> ConnectionMode { get; set; }

        /// <summary> Gets or sets the ConnectionProtocol compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionProtocol> ConnectionProtocol { get; set; }

        /// <summary> Gets or sets the ConnectionType compatibility property. </summary>
        public Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionType ConnectionType { get; set; }

        /// <summary> Gets or sets the EnableBgp compatibility property. </summary>
        public System.Nullable<System.Boolean> EnableBgp { get; set; }

        /// <summary> Gets or sets the EnablePrivateLinkFastPath compatibility property. </summary>
        public System.Nullable<System.Boolean> EnablePrivateLinkFastPath { get; set; }

        /// <summary> Gets or sets the ExpressRouteGatewayBypass compatibility property. </summary>
        public System.Nullable<System.Boolean> ExpressRouteGatewayBypass { get; set; }

        /// <summary> Gets or sets the LocalNetworkGateway2Id compatibility property. </summary>
        public Azure.Core.ResourceIdentifier LocalNetworkGateway2Id { get; set; }

        /// <summary> Gets or sets the PeerId compatibility property. </summary>
        public Azure.Core.ResourceIdentifier PeerId { get; set; }

        /// <summary> Gets or sets the RoutingWeight compatibility property. </summary>
        public System.Nullable<System.Int32> RoutingWeight { get; set; }

        /// <summary> Gets or sets the SharedKey compatibility property. </summary>
        public System.String SharedKey { get; set; }

        /// <summary> Gets or sets the UsePolicyBasedTrafficSelectors compatibility property. </summary>
        public System.Nullable<System.Boolean> UsePolicyBasedTrafficSelectors { get; set; }

        /// <summary> Gets or sets the VirtualNetworkGateway1Id compatibility property. </summary>
        public Azure.Core.ResourceIdentifier VirtualNetworkGateway1Id { get; set; }

        /// <summary> Gets or sets the VirtualNetworkGateway2Id compatibility property. </summary>
        public Azure.Core.ResourceIdentifier VirtualNetworkGateway2Id { get; set; }
    }
}
