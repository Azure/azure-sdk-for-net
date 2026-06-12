// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591
#pragma warning disable SA1402

namespace Azure.ResourceManager.Network
{
    public partial class BackendAddressPoolData
    {
        public System.Nullable<Azure.Core.AzureLocation> Location
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ExpressRouteConnectionData
    {
        public Azure.ResourceManager.Network.Models.RoutingConfiguration RoutingConfiguration
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ExpressRouteProviderPortData
    {
        public System.Nullable<System.Int32> OverprovisionFactor
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String PeeringLocation
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Int32> PortBandwidthInMbps
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Int32> RemainingBandwidthInMbps
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Int32> UsedBandwidthInMbps
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class HubVirtualNetworkConnectionData
    {
        public Azure.ResourceManager.Network.Models.RoutingConfiguration RoutingConfiguration
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class LoadBalancingRuleData
    {
        private Azure.ResourceManager.Network.Models.LoadBalancingRuleProperties _properties;

        public Azure.ResourceManager.Network.Models.LoadBalancingRuleProperties Properties
        {
            get => _properties;
            set => _properties = value;
        }
    }

    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkSecurityPerimeterLinkStatus> Status
        {
            get => Properties is null ? default : Properties.Status;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class PeerExpressRouteCircuitConnectionData
    {
        public System.String AddressPrefix
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Guid> AuthResourceGuid
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String ConnectionName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.Core.ResourceIdentifier ExpressRouteCircuitPeeringId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.Core.ResourceIdentifier PeerExpressRouteCircuitPeeringId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class RouteData
    {
        public System.Nullable<System.Boolean> HasBgpOverride
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class RouteFilterRuleData
    {
        public System.Nullable<Azure.Core.AzureLocation> Location
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class VirtualNetworkApplianceData
    {
        public System.String BandwidthInGbps
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class VpnConnectionData
    {
        public Azure.ResourceManager.Network.Models.RoutingConfiguration RoutingConfiguration
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayFirewallRule
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.ApplicationGatewayWafRuleActionType> Action
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String Description
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Int32 RuleId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String RuleIdString
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.ApplicationGatewayWafRuleSensitivityType> Sensitivity
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.ApplicationGatewayWafRuleStateType> State
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ApplicationGatewayFirewallRuleGroup
    {
        public System.String Description
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String RuleGroupName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ApplicationGatewayFirewallRuleSet
    {
        public System.String RuleSetType
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String RuleSetVersion
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class BgpServiceCommunity
    {
        public System.String ServiceName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ContainerNetworkInterface
    {
        public Azure.Core.ResourceIdentifier ContainerId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ExpressRouteServiceProviderBandwidthsOffered
    {
        public System.String OfferName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Int32> ValueInMbps
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class IpamPoolProperties
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkProvisioningState> ProvisioningState
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class LoadBalancerInboundNatPool
    {
        private Azure.ResourceManager.Network.Models.LoadBalancerInboundNatPoolProperties _properties;

        public Azure.ResourceManager.Network.Models.LoadBalancerInboundNatPoolProperties Properties
        {
            get => _properties;
            set => _properties = value;
        }
    }

    public partial class NetworkIPConfiguration
    {
        public System.String PrivateIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkIPAllocationMethod> PrivateIPAllocationMethod
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.ResourceManager.Network.PublicIPAddressData PublicIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.ResourceManager.Network.SubnetData Subnet
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class NetworkVerifierWorkspaceProperties
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkProvisioningState> ProvisioningState
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class P2SConnectionConfiguration
    {
        public Azure.ResourceManager.Network.Models.RoutingConfiguration RoutingConfiguration
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class PrivateEndpointIPConfiguration
    {
        public System.Net.IPAddress PrivateIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ReachabilityAnalysisIntentProperties
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkProvisioningState> ProvisioningState
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ReachabilityAnalysisRunProperties
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkProvisioningState> ProvisioningState
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ResourceNavigationLink
    {
        public Azure.Core.ResourceIdentifier Link
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.Core.ResourceType> LinkedResourceType
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class ServiceAssociationLink
    {
        public System.Nullable<System.Boolean> AllowDelete
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.Core.ResourceIdentifier Link
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.Core.ResourceType> LinkedResourceType
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class StaticCidrProperties
    {
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkProvisioningState> ProvisioningState
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class VirtualNetworkApplianceIPConfiguration
    {
        public System.Nullable<System.Boolean> Primary
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String PrivateIPAddress
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkIPVersion> PrivateIPAddressVersion
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkIPAllocationMethod> PrivateIPAllocationMethod
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }

    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        public System.String AuthorizationKey
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionMode> ConnectionMode
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionProtocol> ConnectionProtocol
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.ResourceManager.Network.Models.VirtualNetworkGatewayConnectionType ConnectionType
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Boolean> EnableBgp
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Boolean> EnablePrivateLinkFastPath
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Boolean> ExpressRouteGatewayBypass
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.Core.ResourceIdentifier LocalNetworkGateway2Id
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.Core.ResourceIdentifier PeerId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Int32> RoutingWeight
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.String SharedKey
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public System.Nullable<System.Boolean> UsePolicyBasedTrafficSelectors
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        public Azure.Core.ResourceIdentifier VirtualNetworkGateway1Id
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

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

#pragma warning restore SA1402
#pragma warning restore CS1591
