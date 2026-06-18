// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionListEntity type. </summary>
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary> Gets or sets the AuthorizationKey compatibility property. </summary>
        public System.String AuthorizationKey
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ConnectionMode compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionMode> ConnectionMode
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ConnectionProtocol compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionProtocol> ConnectionProtocol
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ConnectionType compatibility property. </summary>
        public Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionType ConnectionType
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the EnableBgp compatibility property. </summary>
        public System.Nullable<System.Boolean> EnableBgp
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the EnablePrivateLinkFastPath compatibility property. </summary>
        public System.Nullable<System.Boolean> EnablePrivateLinkFastPath
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the ExpressRouteGatewayBypass compatibility property. </summary>
        public System.Nullable<System.Boolean> ExpressRouteGatewayBypass
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the LocalNetworkGateway2Id compatibility property. </summary>
        public Azure.Core.ResourceIdentifier LocalNetworkGateway2Id
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the PeerId compatibility property. </summary>
        public Azure.Core.ResourceIdentifier PeerId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the RoutingWeight compatibility property. </summary>
        public System.Nullable<System.Int32> RoutingWeight
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the SharedKey compatibility property. </summary>
        public System.String SharedKey
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the UsePolicyBasedTrafficSelectors compatibility property. </summary>
        public System.Nullable<System.Boolean> UsePolicyBasedTrafficSelectors
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the VirtualNetworkGateway1Id compatibility property. </summary>
        public Azure.Core.ResourceIdentifier VirtualNetworkGateway1Id
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the VirtualNetworkGateway2Id compatibility property. </summary>
        public Azure.Core.ResourceIdentifier VirtualNetworkGateway2Id
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
