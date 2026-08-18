// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

#pragma warning disable CS1591 // Missing XML comment for publicly visible compatibility members
#pragma warning disable SA1402 // Keep backward-compatible Network types together.

namespace Azure.Provisioning.Network
{
    public enum ConnectionMonitorType
    {
        MultiEndpoint = 0,
        SingleSourceDestination = 1,
    }

    public enum DdosCustomPolicyTriggerSensitivityOverride
    {
        Relaxed = 0,
        Low = 1,
        Default = 2,
        High = 3,
    }

    public enum DdosSettingsProtectionMode
    {
        VirtualNetworkInherited = 0,
        Enabled = 1,
        Disabled = 2,
    }

    public enum DdosTrafficType
    {
        Tcp = 0,
        Udp = 1,
        TcpSyn = 2,
    }

    public partial class ProtocolCustomSettings : ProvisionableConstruct
    {
        public ProtocolCustomSettings()
        {
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
        }
    }

    public partial class RoutingConfigurationNfvSubResource : ProvisionableConstruct
    {
        public RoutingConfigurationNfvSubResource()
        {
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
        }
    }

    public partial class PropagatedRouteTable : ProvisionableConstruct
    {
        private BicepList<WritableSubResource> _ids;
        private BicepList<string> _labels;

        public PropagatedRouteTable()
        {
        }

        public BicepList<WritableSubResource> Ids
        {
            get { Initialize(); return _ids; }
            set { Initialize(); _ids.Assign(value); }
        }

        public BicepList<string> Labels
        {
            get { Initialize(); return _labels; }
            set { Initialize(); _labels.Assign(value); }
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _ids = DefineListProperty<WritableSubResource>(nameof(Ids), new string[] { "ids" });
            _labels = DefineListProperty<string>(nameof(Labels), new string[] { "labels" });
        }
    }

    public partial class RoutingConfiguration : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _associatedRouteTableId;
        private BicepValue<ResourceIdentifier> _inboundRouteMapId;
        private BicepValue<ResourceIdentifier> _outboundRouteMapId;
        private PropagatedRouteTable _propagatedRouteTables;
        private VnetRoute _vnetRoutes;

        public RoutingConfiguration()
        {
        }

        public BicepValue<ResourceIdentifier> AssociatedRouteTableId
        {
            get { Initialize(); return _associatedRouteTableId; }
            set { Initialize(); _associatedRouteTableId.Assign(value); }
        }

        public BicepValue<ResourceIdentifier> InboundRouteMapId
        {
            get { Initialize(); return _inboundRouteMapId; }
            set { Initialize(); _inboundRouteMapId.Assign(value); }
        }

        public BicepValue<ResourceIdentifier> OutboundRouteMapId
        {
            get { Initialize(); return _outboundRouteMapId; }
            set { Initialize(); _outboundRouteMapId.Assign(value); }
        }

        public PropagatedRouteTable PropagatedRouteTables
        {
            get { Initialize(); return _propagatedRouteTables; }
            set { Initialize(); AssignOrReplace(ref _propagatedRouteTables, value); }
        }

        public VnetRoute VnetRoutes
        {
            get { Initialize(); return _vnetRoutes; }
            set { Initialize(); AssignOrReplace(ref _vnetRoutes, value); }
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _associatedRouteTableId = DefineProperty<ResourceIdentifier>(nameof(AssociatedRouteTableId), new string[] { "associatedRouteTable", "id" });
            _inboundRouteMapId = DefineProperty<ResourceIdentifier>(nameof(InboundRouteMapId), new string[] { "inboundRouteMap", "id" });
            _outboundRouteMapId = DefineProperty<ResourceIdentifier>(nameof(OutboundRouteMapId), new string[] { "outboundRouteMap", "id" });
            _propagatedRouteTables = DefineModelProperty<PropagatedRouteTable>(nameof(PropagatedRouteTables), new string[] { "propagatedRouteTables" });
            _vnetRoutes = DefineModelProperty<VnetRoute>(nameof(VnetRoutes), new string[] { "vnetRoutes" });
        }
    }

    public partial class ExpressRouteLinkData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private BicepValue<ResourceType> _resourceType;
        private BicepValue<ETag> _eTag;
        private BicepValue<ExpressRouteLinkAdminState> _adminState;
        private BicepValue<string> _coloLocation;
        private BicepValue<ExpressRouteLinkConnectorType> _connectorType;
        private BicepValue<string> _interfaceName;
        private ExpressRouteLinkMacSecConfig _macSecConfig;
        private BicepValue<string> _patchPanelId;
        private BicepValue<NetworkProvisioningState> _provisioningState;
        private BicepValue<string> _rackId;
        private BicepValue<string> _routerName;

        public ExpressRouteLinkData()
        {
        }

        public BicepValue<ExpressRouteLinkAdminState> AdminState { get { Initialize(); return _adminState; } set { Initialize(); _adminState.Assign(value); } }
        public BicepValue<string> ColoLocation { get { Initialize(); return _coloLocation; } }
        public BicepValue<ExpressRouteLinkConnectorType> ConnectorType { get { Initialize(); return _connectorType; } }
        public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }
        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } set { Initialize(); _id.Assign(value); } }
        public BicepValue<string> InterfaceName { get { Initialize(); return _interfaceName; } }
        public ExpressRouteLinkMacSecConfig MacSecConfig { get { Initialize(); return _macSecConfig; } set { Initialize(); AssignOrReplace(ref _macSecConfig, value); } }
        public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
        public BicepValue<string> PatchPanelId { get { Initialize(); return _patchPanelId; } }
        public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }
        public BicepValue<string> RackId { get { Initialize(); return _rackId; } }
        public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }
        public BicepValue<string> RouterName { get { Initialize(); return _routerName; } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
            _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
            _adminState = DefineProperty<ExpressRouteLinkAdminState>(nameof(AdminState), new string[] { "properties", "adminState" });
            _coloLocation = DefineProperty<string>(nameof(ColoLocation), new string[] { "properties", "coloLocation" }, isOutput: true);
            _connectorType = DefineProperty<ExpressRouteLinkConnectorType>(nameof(ConnectorType), new string[] { "properties", "connectorType" }, isOutput: true);
            _interfaceName = DefineProperty<string>(nameof(InterfaceName), new string[] { "properties", "interfaceName" }, isOutput: true);
            _macSecConfig = DefineModelProperty<ExpressRouteLinkMacSecConfig>(nameof(MacSecConfig), new string[] { "properties", "macSecConfig" });
            _patchPanelId = DefineProperty<string>(nameof(PatchPanelId), new string[] { "properties", "patchPanelId" }, isOutput: true);
            _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
            _rackId = DefineProperty<string>(nameof(RackId), new string[] { "properties", "rackId" }, isOutput: true);
            _routerName = DefineProperty<string>(nameof(RouterName), new string[] { "properties", "routerName" }, isOutput: true);
        }
    }

    public partial class PeerExpressRouteCircuitConnectionData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private BicepValue<ResourceType> _resourceType;
        private BicepValue<ETag> _eTag;
        private BicepValue<string> _addressPrefix;
        private BicepValue<Guid> _authResourceGuid;
        private BicepValue<CircuitConnectionStatus> _circuitConnectionStatus;
        private BicepValue<string> _connectionName;
        private BicepValue<ResourceIdentifier> _expressRouteCircuitPeeringId;
        private BicepValue<ResourceIdentifier> _peerExpressRouteCircuitPeeringId;
        private BicepValue<NetworkProvisioningState> _provisioningState;

        public PeerExpressRouteCircuitConnectionData()
        {
        }

        public BicepValue<string> AddressPrefix { get { Initialize(); return _addressPrefix; } set { Initialize(); _addressPrefix.Assign(value); } }
        public BicepValue<Guid> AuthResourceGuid { get { Initialize(); return _authResourceGuid; } set { Initialize(); _authResourceGuid.Assign(value); } }
        public BicepValue<CircuitConnectionStatus> CircuitConnectionStatus { get { Initialize(); return _circuitConnectionStatus; } }
        public BicepValue<string> ConnectionName { get { Initialize(); return _connectionName; } set { Initialize(); _connectionName.Assign(value); } }
        public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }
        public BicepValue<ResourceIdentifier> ExpressRouteCircuitPeeringId { get { Initialize(); return _expressRouteCircuitPeeringId; } set { Initialize(); _expressRouteCircuitPeeringId.Assign(value); } }
        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } set { Initialize(); _id.Assign(value); } }
        public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
        public BicepValue<ResourceIdentifier> PeerExpressRouteCircuitPeeringId { get { Initialize(); return _peerExpressRouteCircuitPeeringId; } set { Initialize(); _peerExpressRouteCircuitPeeringId.Assign(value); } }
        public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }
        public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
            _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
            _addressPrefix = DefineProperty<string>(nameof(AddressPrefix), new string[] { "properties", "addressPrefix" });
            _authResourceGuid = DefineProperty<Guid>(nameof(AuthResourceGuid), new string[] { "properties", "authResourceGuid" });
            _circuitConnectionStatus = DefineProperty<CircuitConnectionStatus>(nameof(CircuitConnectionStatus), new string[] { "properties", "circuitConnectionStatus" }, isOutput: true);
            _connectionName = DefineProperty<string>(nameof(ConnectionName), new string[] { "properties", "connectionName" });
            _expressRouteCircuitPeeringId = DefineProperty<ResourceIdentifier>(nameof(ExpressRouteCircuitPeeringId), new string[] { "properties", "expressRouteCircuitPeering", "id" });
            _peerExpressRouteCircuitPeeringId = DefineProperty<ResourceIdentifier>(nameof(PeerExpressRouteCircuitPeeringId), new string[] { "properties", "peerExpressRouteCircuitPeering", "id" });
            _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        }
    }

    public partial class VpnSiteLinkData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private BicepValue<ResourceType> _resourceType;
        private BicepValue<ETag> _eTag;
        private VpnLinkBgpSettings _bgpProperties;
        private BicepValue<string> _fqdn;
        private BicepValue<string> _ipAddress;
        private VpnLinkProviderProperties _linkProperties;
        private BicepValue<NetworkProvisioningState> _provisioningState;

        public VpnSiteLinkData()
        {
        }

        public VpnLinkBgpSettings BgpProperties { get { Initialize(); return _bgpProperties; } set { Initialize(); AssignOrReplace(ref _bgpProperties, value); } }
        public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }
        public BicepValue<string> Fqdn { get { Initialize(); return _fqdn; } set { Initialize(); _fqdn.Assign(value); } }
        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } set { Initialize(); _id.Assign(value); } }
        public BicepValue<string> IPAddress { get { Initialize(); return _ipAddress; } set { Initialize(); _ipAddress.Assign(value); } }
        public VpnLinkProviderProperties LinkProperties { get { Initialize(); return _linkProperties; } set { Initialize(); AssignOrReplace(ref _linkProperties, value); } }
        public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
        public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }
        public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
            _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
            _bgpProperties = DefineModelProperty<VpnLinkBgpSettings>(nameof(BgpProperties), new string[] { "properties", "bgpProperties" });
            _fqdn = DefineProperty<string>(nameof(Fqdn), new string[] { "properties", "fqdn" });
            _ipAddress = DefineProperty<string>(nameof(IPAddress), new string[] { "properties", "ipAddress" });
            _linkProperties = DefineModelProperty<VpnLinkProviderProperties>(nameof(LinkProperties), new string[] { "properties", "linkProperties" });
            _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        }
    }

    public partial class VpnSiteLinkConnectionData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private BicepValue<ResourceType> _resourceType;
        private BicepValue<ETag> _eTag;
        private BicepValue<int> _connectionBandwidth;
        private BicepValue<VpnConnectionStatus> _connectionStatus;
        private BicepValue<int> _dpdTimeoutSeconds;
        private BicepValue<long> _egressBytesTransferred;
        private BicepList<WritableSubResource> _egressNatRules;
        private BicepValue<bool> _enableBgp;
        private BicepValue<bool> _enableRateLimiting;
        private BicepValue<long> _ingressBytesTransferred;
        private BicepList<WritableSubResource> _ingressNatRules;
        private BicepList<IPsecPolicy> _ipsecPolicies;
        private BicepValue<NetworkProvisioningState> _provisioningState;
        private BicepValue<int> _routingWeight;
        private BicepValue<string> _sharedKey;
        private BicepValue<bool> _useLocalAzureIPAddress;
        private BicepValue<bool> _usePolicyBasedTrafficSelectors;
        private BicepValue<VirtualNetworkGatewayConnectionProtocol> _vpnConnectionProtocolType;
        private BicepList<GatewayCustomBgpIPAddressIPConfiguration> _vpnGatewayCustomBgpAddresses;
        private BicepValue<VpnLinkConnectionMode> _vpnLinkConnectionMode;
        private BicepValue<ResourceIdentifier> _vpnSiteLinkId;

        public VpnSiteLinkConnectionData()
        {
        }

        public BicepValue<int> ConnectionBandwidth { get { Initialize(); return _connectionBandwidth; } set { Initialize(); _connectionBandwidth.Assign(value); } }
        public BicepValue<VpnConnectionStatus> ConnectionStatus { get { Initialize(); return _connectionStatus; } }
        public BicepValue<int> DpdTimeoutSeconds { get { Initialize(); return _dpdTimeoutSeconds; } set { Initialize(); _dpdTimeoutSeconds.Assign(value); } }
        public BicepValue<long> EgressBytesTransferred { get { Initialize(); return _egressBytesTransferred; } }
        public BicepList<WritableSubResource> EgressNatRules { get { Initialize(); return _egressNatRules; } set { Initialize(); _egressNatRules.Assign(value); } }
        public BicepValue<bool> EnableBgp { get { Initialize(); return _enableBgp; } set { Initialize(); _enableBgp.Assign(value); } }
        public BicepValue<bool> EnableRateLimiting { get { Initialize(); return _enableRateLimiting; } set { Initialize(); _enableRateLimiting.Assign(value); } }
        public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }
        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } set { Initialize(); _id.Assign(value); } }
        public BicepValue<long> IngressBytesTransferred { get { Initialize(); return _ingressBytesTransferred; } }
        public BicepList<WritableSubResource> IngressNatRules { get { Initialize(); return _ingressNatRules; } set { Initialize(); _ingressNatRules.Assign(value); } }
        public BicepList<IPsecPolicy> IPsecPolicies { get { Initialize(); return _ipsecPolicies; } set { Initialize(); _ipsecPolicies.Assign(value); } }
        public BicepValue<string> Name { get { Initialize(); return _name; } set { Initialize(); _name.Assign(value); } }
        public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }
        public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }
        public BicepValue<int> RoutingWeight { get { Initialize(); return _routingWeight; } set { Initialize(); _routingWeight.Assign(value); } }
        public BicepValue<string> SharedKey { get { Initialize(); return _sharedKey; } set { Initialize(); _sharedKey.Assign(value); } }
        public BicepValue<bool> UseLocalAzureIPAddress { get { Initialize(); return _useLocalAzureIPAddress; } set { Initialize(); _useLocalAzureIPAddress.Assign(value); } }
        public BicepValue<bool> UsePolicyBasedTrafficSelectors { get { Initialize(); return _usePolicyBasedTrafficSelectors; } set { Initialize(); _usePolicyBasedTrafficSelectors.Assign(value); } }
        public BicepValue<VirtualNetworkGatewayConnectionProtocol> VpnConnectionProtocolType { get { Initialize(); return _vpnConnectionProtocolType; } set { Initialize(); _vpnConnectionProtocolType.Assign(value); } }
        public BicepList<GatewayCustomBgpIPAddressIPConfiguration> VpnGatewayCustomBgpAddresses { get { Initialize(); return _vpnGatewayCustomBgpAddresses; } set { Initialize(); _vpnGatewayCustomBgpAddresses.Assign(value); } }
        public BicepValue<VpnLinkConnectionMode> VpnLinkConnectionMode { get { Initialize(); return _vpnLinkConnectionMode; } set { Initialize(); _vpnLinkConnectionMode.Assign(value); } }
        public BicepValue<ResourceIdentifier> VpnSiteLinkId { get { Initialize(); return _vpnSiteLinkId; } set { Initialize(); _vpnSiteLinkId.Assign(value); } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
            _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
            _connectionBandwidth = DefineProperty<int>(nameof(ConnectionBandwidth), new string[] { "properties", "connectionBandwidth" });
            _connectionStatus = DefineProperty<VpnConnectionStatus>(nameof(ConnectionStatus), new string[] { "properties", "connectionStatus" }, isOutput: true);
            _dpdTimeoutSeconds = DefineProperty<int>(nameof(DpdTimeoutSeconds), new string[] { "properties", "dpdTimeoutSeconds" });
            _egressBytesTransferred = DefineProperty<long>(nameof(EgressBytesTransferred), new string[] { "properties", "egressBytesTransferred" }, isOutput: true);
            _egressNatRules = DefineListProperty<WritableSubResource>(nameof(EgressNatRules), new string[] { "properties", "egressNatRules" });
            _enableBgp = DefineProperty<bool>(nameof(EnableBgp), new string[] { "properties", "enableBgp" });
            _enableRateLimiting = DefineProperty<bool>(nameof(EnableRateLimiting), new string[] { "properties", "enableRateLimiting" });
            _ingressBytesTransferred = DefineProperty<long>(nameof(IngressBytesTransferred), new string[] { "properties", "ingressBytesTransferred" }, isOutput: true);
            _ingressNatRules = DefineListProperty<WritableSubResource>(nameof(IngressNatRules), new string[] { "properties", "ingressNatRules" });
            _ipsecPolicies = DefineListProperty<IPsecPolicy>(nameof(IPsecPolicies), new string[] { "properties", "ipsecPolicies" });
            _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
            _routingWeight = DefineProperty<int>(nameof(RoutingWeight), new string[] { "properties", "routingWeight" });
            _sharedKey = DefineProperty<string>(nameof(SharedKey), new string[] { "properties", "sharedKey" });
            _useLocalAzureIPAddress = DefineProperty<bool>(nameof(UseLocalAzureIPAddress), new string[] { "properties", "useLocalAzureIpAddress" });
            _usePolicyBasedTrafficSelectors = DefineProperty<bool>(nameof(UsePolicyBasedTrafficSelectors), new string[] { "properties", "usePolicyBasedTrafficSelectors" });
            _vpnConnectionProtocolType = DefineProperty<VirtualNetworkGatewayConnectionProtocol>(nameof(VpnConnectionProtocolType), new string[] { "properties", "vpnConnectionProtocolType" });
            _vpnGatewayCustomBgpAddresses = DefineListProperty<GatewayCustomBgpIPAddressIPConfiguration>(nameof(VpnGatewayCustomBgpAddresses), new string[] { "properties", "vpnGatewayCustomBgpAddresses" });
            _vpnLinkConnectionMode = DefineProperty<VpnLinkConnectionMode>(nameof(VpnLinkConnectionMode), new string[] { "properties", "vpnLinkConnectionMode" });
            _vpnSiteLinkId = DefineProperty<ResourceIdentifier>(nameof(VpnSiteLinkId), new string[] { "properties", "vpnSiteLink", "id" });
        }
    }
}
