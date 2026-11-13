// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

/// <summary> The legacy data model for a VPN site link connection. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use VpnSiteLinkConnection instead.")]
public partial class VpnSiteLinkConnectionData : ProvisionableConstruct
{
    private BicepValue<ETag> _eTag;
    private BicepValue<ResourceIdentifier> _vpnSiteLinkId;
    private BicepValue<int> _routingWeight;
    private BicepValue<VpnLinkConnectionMode> _vpnLinkConnectionMode;
    private BicepValue<VpnConnectionStatus> _connectionStatus;
    private BicepValue<VirtualNetworkGatewayConnectionProtocol> _vpnConnectionProtocolType;
    private BicepValue<long> _ingressBytesTransferred;
    private BicepValue<long> _egressBytesTransferred;
    private BicepValue<int> _connectionBandwidth;
    private BicepValue<string> _sharedKey;
    private BicepValue<bool> _enableBgp;
    private BicepList<GatewayCustomBgpIPAddressIPConfiguration> _vpnGatewayCustomBgpAddresses;
    private BicepValue<bool> _usePolicyBasedTrafficSelectors;
    private BicepList<IPsecPolicy> _iPsecPolicies;
    private BicepValue<bool> _enableRateLimiting;
    private BicepValue<bool> _useLocalAzureIPAddress;
    private BicepValue<NetworkProvisioningState> _provisioningState;
    private BicepList<WritableSubResource> _ingressNatRules;
    private BicepList<WritableSubResource> _egressNatRules;
    private BicepValue<int> _dpdTimeoutSeconds;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private BicepValue<ResourceType> _resourceType;

    /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
    public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }

    /// <summary> Gets or sets the VPN site link resource ID. </summary>
    public BicepValue<ResourceIdentifier> VpnSiteLinkId
    {
        get { Initialize(); return _vpnSiteLinkId; }
        set { Initialize(); _vpnSiteLinkId.Assign(value); }
    }

    /// <summary> Routing weight for the VPN connection. </summary>
    public BicepValue<int> RoutingWeight
    {
        get { Initialize(); return _routingWeight; }
        set { Initialize(); _routingWeight.Assign(value); }
    }

    /// <summary> VPN link connection mode. </summary>
    public BicepValue<VpnLinkConnectionMode> VpnLinkConnectionMode
    {
        get { Initialize(); return _vpnLinkConnectionMode; }
        set { Initialize(); _vpnLinkConnectionMode.Assign(value); }
    }

    /// <summary> The connection status. </summary>
    public BicepValue<VpnConnectionStatus> ConnectionStatus { get { Initialize(); return _connectionStatus; } }

    /// <summary> Connection protocol used for this connection. </summary>
    public BicepValue<VirtualNetworkGatewayConnectionProtocol> VpnConnectionProtocolType
    {
        get { Initialize(); return _vpnConnectionProtocolType; }
        set { Initialize(); _vpnConnectionProtocolType.Assign(value); }
    }

    /// <summary> Ingress bytes transferred. </summary>
    public BicepValue<long> IngressBytesTransferred { get { Initialize(); return _ingressBytesTransferred; } }

    /// <summary> Egress bytes transferred. </summary>
    public BicepValue<long> EgressBytesTransferred { get { Initialize(); return _egressBytesTransferred; } }

    /// <summary> Expected bandwidth in MBPS. </summary>
    public BicepValue<int> ConnectionBandwidth
    {
        get { Initialize(); return _connectionBandwidth; }
        set { Initialize(); _connectionBandwidth.Assign(value); }
    }

    /// <summary> Shared key for the VPN link connection. </summary>
    public BicepValue<string> SharedKey
    {
        get { Initialize(); return _sharedKey; }
        set { Initialize(); _sharedKey.Assign(value); }
    }

    /// <summary> Gets or sets whether BGP is enabled. </summary>
    public BicepValue<bool> EnableBgp
    {
        get { Initialize(); return _enableBgp; }
        set { Initialize(); _enableBgp.Assign(value); }
    }

    /// <summary> VPN gateway custom BGP addresses used by this connection. </summary>
    public BicepList<GatewayCustomBgpIPAddressIPConfiguration> VpnGatewayCustomBgpAddresses
    {
        get { Initialize(); return _vpnGatewayCustomBgpAddresses; }
        set { Initialize(); _vpnGatewayCustomBgpAddresses.Assign(value); }
    }

    /// <summary> Gets or sets whether policy-based traffic selectors are used. </summary>
    public BicepValue<bool> UsePolicyBasedTrafficSelectors
    {
        get { Initialize(); return _usePolicyBasedTrafficSelectors; }
        set { Initialize(); _usePolicyBasedTrafficSelectors.Assign(value); }
    }

    /// <summary> The IPsec policies used by this connection. </summary>
    public BicepList<IPsecPolicy> IPsecPolicies
    {
        get { Initialize(); return _iPsecPolicies; }
        set { Initialize(); _iPsecPolicies.Assign(value); }
    }

    /// <summary> Gets or sets whether rate limiting is enabled. </summary>
    public BicepValue<bool> EnableRateLimiting
    {
        get { Initialize(); return _enableRateLimiting; }
        set { Initialize(); _enableRateLimiting.Assign(value); }
    }

    /// <summary> Gets or sets whether a local Azure IP address initiates the connection. </summary>
    public BicepValue<bool> UseLocalAzureIPAddress
    {
        get { Initialize(); return _useLocalAzureIPAddress; }
        set { Initialize(); _useLocalAzureIPAddress.Assign(value); }
    }

    /// <summary> The provisioning state of the VPN site link connection. </summary>
    public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }

    /// <summary> The ingress NAT rules. </summary>
    public BicepList<WritableSubResource> IngressNatRules
    {
        get { Initialize(); return _ingressNatRules; }
        set { Initialize(); _ingressNatRules.Assign(value); }
    }

    /// <summary> The egress NAT rules. </summary>
    public BicepList<WritableSubResource> EgressNatRules
    {
        get { Initialize(); return _egressNatRules; }
        set { Initialize(); _egressNatRules.Assign(value); }
    }

    /// <summary> Dead Peer Detection timeout in seconds. </summary>
    public BicepValue<int> DpdTimeoutSeconds
    {
        get { Initialize(); return _dpdTimeoutSeconds; }
        set { Initialize(); _dpdTimeoutSeconds.Assign(value); }
    }

    /// <summary> Resource ID. </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id; }
        set { Initialize(); _id.Assign(value); }
    }

    /// <summary> Resource name. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary> Resource type. </summary>
    public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }

    /// <summary> Creates a new VpnSiteLinkConnectionData. </summary>
    public VpnSiteLinkConnectionData()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
        _vpnSiteLinkId = DefineProperty<ResourceIdentifier>(nameof(VpnSiteLinkId), new string[] { "properties", "vpnSiteLink", "id" });
        _routingWeight = DefineProperty<int>(nameof(RoutingWeight), new string[] { "properties", "routingWeight" });
        _vpnLinkConnectionMode = DefineProperty<VpnLinkConnectionMode>(nameof(VpnLinkConnectionMode), new string[] { "properties", "vpnLinkConnectionMode" });
        _connectionStatus = DefineProperty<VpnConnectionStatus>(nameof(ConnectionStatus), new string[] { "properties", "connectionStatus" }, isOutput: true);
        _vpnConnectionProtocolType = DefineProperty<VirtualNetworkGatewayConnectionProtocol>(nameof(VpnConnectionProtocolType), new string[] { "properties", "vpnConnectionProtocolType" });
        _ingressBytesTransferred = DefineProperty<long>(nameof(IngressBytesTransferred), new string[] { "properties", "ingressBytesTransferred" }, isOutput: true);
        _egressBytesTransferred = DefineProperty<long>(nameof(EgressBytesTransferred), new string[] { "properties", "egressBytesTransferred" }, isOutput: true);
        _connectionBandwidth = DefineProperty<int>(nameof(ConnectionBandwidth), new string[] { "properties", "connectionBandwidth" });
        _sharedKey = DefineProperty<string>(nameof(SharedKey), new string[] { "properties", "sharedKey" });
        _enableBgp = DefineProperty<bool>(nameof(EnableBgp), new string[] { "properties", "enableBgp" });
        _vpnGatewayCustomBgpAddresses = DefineListProperty<GatewayCustomBgpIPAddressIPConfiguration>(nameof(VpnGatewayCustomBgpAddresses), new string[] { "properties", "vpnGatewayCustomBgpAddresses" });
        _usePolicyBasedTrafficSelectors = DefineProperty<bool>(nameof(UsePolicyBasedTrafficSelectors), new string[] { "properties", "usePolicyBasedTrafficSelectors" });
        _iPsecPolicies = DefineListProperty<IPsecPolicy>(nameof(IPsecPolicies), new string[] { "properties", "ipsecPolicies" });
        _enableRateLimiting = DefineProperty<bool>(nameof(EnableRateLimiting), new string[] { "properties", "enableRateLimiting" });
        _useLocalAzureIPAddress = DefineProperty<bool>(nameof(UseLocalAzureIPAddress), new string[] { "properties", "useLocalAzureIpAddress" });
        _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        _ingressNatRules = DefineListProperty<WritableSubResource>(nameof(IngressNatRules), new string[] { "properties", "ingressNatRules" });
        _egressNatRules = DefineListProperty<WritableSubResource>(nameof(EgressNatRules), new string[] { "properties", "egressNatRules" });
        _dpdTimeoutSeconds = DefineProperty<int>(nameof(DpdTimeoutSeconds), new string[] { "properties", "dpdTimeoutSeconds" });
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
