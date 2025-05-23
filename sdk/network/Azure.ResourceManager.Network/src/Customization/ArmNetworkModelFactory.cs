// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmNetworkModelFactory
    {
        /// <summary> Initializes a new instance of ApplicationGatewayFrontendIPConfiguration. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="privateIPAddress"> PrivateIPAddress of the network interface IP Configuration. </param>
        /// <param name="privateIPAllocationMethod"> The private IP address allocation method. </param>
        /// <param name="subnetId"> Reference to the subnet resource. </param>
        /// <param name="publicIPAddressId"> Reference to the PublicIP resource. </param>
        /// <param name="privateLinkConfigurationId"> Reference to the application gateway private link configuration. </param>
        /// <param name="provisioningState"> The provisioning state of the frontend IP configuration resource. </param>
        /// <returns> A new <see cref="Models.ApplicationGatewayFrontendIPConfiguration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ApplicationGatewayFrontendIPConfiguration ApplicationGatewayFrontendIPConfiguration(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, string privateIPAddress, NetworkIPAllocationMethod? privateIPAllocationMethod, ResourceIdentifier subnetId, ResourceIdentifier publicIPAddressId, ResourceIdentifier privateLinkConfigurationId, NetworkProvisioningState? provisioningState)
            => ApplicationGatewayFrontendIPConfiguration(id, name, resourceType, etag, privateIPAddress, privateIPAllocationMethod, subnetId, publicIPAddressId, privateLinkConfigurationId, provisioningState);

        /// <summary> Initializes a new instance of VirtualNetworkGatewayData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="extendedLocation"> The extended location of type local virtual network gateway. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="ipConfigurations"> IP configurations for virtual network gateway. </param>
        /// <param name="gatewayType"> The type of this virtual network gateway. </param>
        /// <param name="vpnType"> The type of this virtual network gateway. </param>
        /// <param name="vpnGatewayGeneration"> The generation for this VirtualNetworkGateway. Must be None if gatewayType is not VPN. </param>
        /// <param name="enableBgp"> Whether BGP is enabled for this virtual network gateway or not. </param>
        /// <param name="enablePrivateIPAddress"> Whether private IP needs to be enabled on this gateway for connections or not. </param>
        /// <param name="active"> ActiveActive flag. </param>
        /// <param name="disableIPSecReplayProtection"> disableIPSecReplayProtection flag. </param>
        /// <param name="gatewayDefaultSiteId"> The reference to the LocalNetworkGateway resource which represents local network site having default routes. Assign Null value in case of removing existing default site setting. </param>
        /// <param name="sku"> The reference to the VirtualNetworkGatewaySku resource which represents the SKU selected for Virtual network gateway. </param>
        /// <param name="vpnClientConfiguration"> The reference to the VpnClientConfiguration resource which represents the P2S VpnClient configurations. </param>
        /// <param name="virtualNetworkGatewayPolicyGroups"> The reference to the VirtualNetworkGatewayPolicyGroup resource which represents the available VirtualNetworkGatewayPolicyGroup for the gateway. </param>
        /// <param name="bgpSettings"> Virtual network gateway's BGP speaker settings. </param>
        /// <param name="customRoutesAddressPrefixes"> The reference to the address space resource which represents the custom routes address space specified by the customer for virtual network gateway and VpnClient. </param>
        /// <param name="resourceGuid"> The resource GUID property of the virtual network gateway resource. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network gateway resource. </param>
        /// <param name="enableDnsForwarding"> Whether dns forwarding is enabled or not. </param>
        /// <param name="inboundDnsForwardingEndpoint"> The IP address allocated by the gateway to which dns requests can be sent. </param>
        /// <param name="vNetExtendedLocationResourceId"> Customer vnet resource id. VirtualNetworkGateway of type local gateway is associated with the customer vnet. </param>
        /// <param name="natRules"> NatRules for virtual network gateway. </param>
        /// <param name="enableBgpRouteTranslationForNat"> EnableBgpRouteTranslationForNat flag. </param>
        /// <param name="allowVirtualWanTraffic"> Configures this gateway to accept traffic from remote Virtual WAN networks. </param>
        /// <param name="allowRemoteVnetTraffic"> Configure this gateway to accept traffic from other Azure Virtual Networks. This configuration does not support connectivity to Azure Virtual WAN. </param>
        /// <param name="adminState"> Property to indicate if the Express Route Gateway serves traffic when there are multiple Express Route Gateways in the vnet. </param>
        /// <returns> A new <see cref="Network.VirtualNetworkGatewayData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, IEnumerable<string> customRoutesAddressPrefixes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState)
            => VirtualNetworkGatewayData(id, name, resourceType, location, tags, extendedLocation, etag, ipConfigurations, gatewayType, vpnType, vpnGatewayGeneration, enableBgp, enablePrivateIPAddress, active, disableIPSecReplayProtection, gatewayDefaultSiteId, sku, vpnClientConfiguration, virtualNetworkGatewayPolicyGroups, bgpSettings, customRoutesAddressPrefixes, resourceGuid, provisioningState, enableDnsForwarding, inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId, natRules, enableBgpRouteTranslationForNat, allowVirtualWanTraffic, allowRemoteVnetTraffic, adminState);

        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkGatewayData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="extendedLocation"> The extended location of type local virtual network gateway. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="identity"> The identity of the virtual network gateway, if configured. </param>
        /// <param name="autoScaleBounds"> Autoscale configuration for virutal network gateway. </param>
        /// <param name="ipConfigurations"> IP configurations for virtual network gateway. </param>
        /// <param name="gatewayType"> The type of this virtual network gateway. </param>
        /// <param name="vpnType"> The type of this virtual network gateway. </param>
        /// <param name="vpnGatewayGeneration"> The generation for this VirtualNetworkGateway. Must be None if gatewayType is not VPN. </param>
        /// <param name="enableBgp"> Whether BGP is enabled for this virtual network gateway or not. </param>
        /// <param name="enablePrivateIPAddress"> Whether private IP needs to be enabled on this gateway for connections or not. </param>
        /// <param name="active"> ActiveActive flag. </param>
        /// <param name="disableIPSecReplayProtection"> disableIPSecReplayProtection flag. </param>
        /// <param name="gatewayDefaultSiteId"> The reference to the LocalNetworkGateway resource which represents local network site having default routes. Assign Null value in case of removing existing default site setting. </param>
        /// <param name="sku"> The reference to the VirtualNetworkGatewaySku resource which represents the SKU selected for Virtual network gateway. </param>
        /// <param name="vpnClientConfiguration"> The reference to the VpnClientConfiguration resource which represents the P2S VpnClient configurations. </param>
        /// <param name="virtualNetworkGatewayPolicyGroups"> The reference to the VirtualNetworkGatewayPolicyGroup resource which represents the available VirtualNetworkGatewayPolicyGroup for the gateway. </param>
        /// <param name="bgpSettings"> Virtual network gateway's BGP speaker settings. </param>
        /// <param name="customRoutesAddressPrefixes"> The reference to the address space resource which represents the custom routes address space specified by the customer for virtual network gateway and VpnClient. </param>
        /// <param name="resourceGuid"> The resource GUID property of the virtual network gateway resource. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network gateway resource. </param>
        /// <param name="enableDnsForwarding"> Whether dns forwarding is enabled or not. </param>
        /// <param name="inboundDnsForwardingEndpoint"> The IP address allocated by the gateway to which dns requests can be sent. </param>
        /// <param name="vNetExtendedLocationResourceId"> Customer vnet resource id. VirtualNetworkGateway of type local gateway is associated with the customer vnet. </param>
        /// <param name="natRules"> NatRules for virtual network gateway. </param>
        /// <param name="enableBgpRouteTranslationForNat"> EnableBgpRouteTranslationForNat flag. </param>
        /// <param name="allowVirtualWanTraffic"> Configures this gateway to accept traffic from remote Virtual WAN networks. </param>
        /// <param name="allowRemoteVnetTraffic"> Configure this gateway to accept traffic from other Azure Virtual Networks. This configuration does not support connectivity to Azure Virtual WAN. </param>
        /// <param name="adminState"> Property to indicate if the Express Route Gateway serves traffic when there are multiple Express Route Gateways in the vnet. </param>
        /// <param name="resiliencyModel"> Property to indicate if the Express Route Gateway has resiliency model of MultiHomed or SingleHomed. </param>
        /// <returns> A new <see cref="Network.VirtualNetworkGatewayData"/> instance for mocking. </returns>
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, ManagedServiceIdentity identity, VirtualNetworkGatewayAutoScaleBounds autoScaleBounds, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, IEnumerable<string> customRoutesAddressPrefixes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState, ExpressRouteGatewayResiliencyModel? resiliencyModel)
            => VirtualNetworkGatewayData(id, name, resourceType, location, tags, extendedLocation, etag, identity, autoScaleBounds, ipConfigurations, gatewayType, vpnType, vpnGatewayGeneration, enableBgp, enablePrivateIPAddress, active, disableIPSecReplayProtection, gatewayDefaultSiteId, sku, vpnClientConfiguration, virtualNetworkGatewayPolicyGroups, bgpSettings,
                                         customRoutesAddressPrefixes != null ? new VirtualNetworkAddressSpace(customRoutesAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                         resourceGuid, provisioningState, enableDnsForwarding, inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId, natRules, enableBgpRouteTranslationForNat, allowVirtualWanTraffic, allowRemoteVnetTraffic, adminState, resiliencyModel);

        /// <summary> Initializes a new instance of NetworkVirtualApplianceConnectionData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="namePropertiesName"> The name of the resource. </param>
        /// <param name="provisioningState"> The provisioning state of the NetworkVirtualApplianceConnection resource. </param>
        /// <param name="asn"> Network Virtual Appliance ASN. </param>
        /// <param name="tunnelIdentifier"> Unique identifier for the connection. </param>
        /// <param name="bgpPeerAddress"> List of bgpPeerAddresses for the NVA instances. </param>
        /// <param name="enableInternetSecurity"> Enable internet security. </param>
        /// <param name="routingConfiguration"> The Routing Configuration indicating the associated and propagated route tables on this connection. </param>
        /// <returns> A new <see cref="Network.NetworkVirtualApplianceConnectionData"/> instance for mocking. </returns>
        public static NetworkVirtualApplianceConnectionData NetworkVirtualApplianceConnectionData(ResourceIdentifier id, string name, ResourceType? resourceType, string namePropertiesName, NetworkProvisioningState? provisioningState, long? asn, long? tunnelIdentifier, IEnumerable<string> bgpPeerAddress, bool? enableInternetSecurity, RoutingConfigurationNfv routingConfiguration)
            => NetworkVirtualApplianceConnectionData(id, name, resourceType, namePropertiesName, provisioningState, asn, tunnelIdentifier, bgpPeerAddress, enableInternetSecurity, connectionRoutingConfiguration : null);

        /// <summary> Initializes a new instance of <see cref="Network.LocalNetworkGatewayData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="localNetworkAddressPrefixes"> Local network site address space. </param>
        /// <param name="gatewayIPAddress"> IP address of local network gateway. </param>
        /// <param name="fqdn"> FQDN of local network gateway. </param>
        /// <param name="bgpSettings"> Local network gateway's BGP speaker settings. </param>
        /// <param name="resourceGuid"> The resource GUID property of the local network gateway resource. </param>
        /// <param name="provisioningState"> The provisioning state of the local network gateway resource. </param>
        /// <returns> A new <see cref="Network.LocalNetworkGatewayData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LocalNetworkGatewayData LocalNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ETag? etag, IEnumerable<string> localNetworkAddressPrefixes, string gatewayIPAddress, string fqdn, BgpSettings bgpSettings, Guid? resourceGuid, NetworkProvisioningState? provisioningState)
            => LocalNetworkGatewayData(id, name, resourceType, location, tags, etag,
                                       localNetworkAddressPrefixes != null ? new VirtualNetworkAddressSpace(localNetworkAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                       gatewayIPAddress, fqdn, bgpSettings, resourceGuid, provisioningState);

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="ruleType"> Rule Type. This should be either AutoExpire or Permanent. Auto Expire Rule only creates NSG rules. Permanent Rule creates NSG rule and SLB LB Rule. </param>
        /// <param name="rules"> List of allowed rules. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <returns> A new <see cref="Models.InboundSecurityRule"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, InboundSecurityRuleType? ruleType, IEnumerable<InboundSecurityRules> rules, NetworkProvisioningState? provisioningState)
            => new InboundSecurityRule(id, name, resourceType, null, etag, ruleType, rules.ToList(), provisioningState);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Network.Models.InboundSecurityRule" />. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="rules"> List of allowed rules. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Network.Models.InboundSecurityRule" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, IEnumerable<InboundSecurityRules> rules, NetworkProvisioningState? provisioningState)
            => InboundSecurityRule(id: id, name: name, resourceType: resourceType, etag: etag, ruleType: default, rules: rules, provisioningState: provisioningState);

        /// <summary> Initializes a new instance of <see cref="Models.LoadBalancerInboundNatPool"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="frontendIPConfigurationId"> A reference to frontend IP addresses. </param>
        /// <param name="protocol"> The reference to the transport protocol used by the inbound NAT pool. </param>
        /// <param name="frontendPortRangeStart"> The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65534. </param>
        /// <param name="frontendPortRangeEnd"> The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65535. </param>
        /// <param name="backendPort"> The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535. </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </param>
        /// <param name="enableFloatingIP"> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="provisioningState"> The provisioning state of the inbound NAT pool resource. </param>
        /// <returns> A new <see cref="Models.LoadBalancerInboundNatPool"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LoadBalancerInboundNatPool LoadBalancerInboundNatPool(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, ResourceIdentifier frontendIPConfigurationId, LoadBalancingTransportProtocol? protocol, int? frontendPortRangeStart, int? frontendPortRangeEnd, int? backendPort, int? idleTimeoutInMinutes, bool? enableFloatingIP, bool? enableTcpReset, NetworkProvisioningState? provisioningState)
            => LoadBalancerInboundNatPool(
                            id: id,
                            name: name,
                            resourceType: resourceType,
                            etag: etag,
                            properties: LoadBalancerInboundNatPoolProperties(
                                frontendIPConfigurationId: frontendIPConfigurationId,
                                protocol: protocol ?? default,
                                frontendPortRangeStart: frontendPortRangeStart ?? default,
                                frontendPortRangeEnd: frontendPortRangeEnd ?? default,
                                backendPort: backendPort ?? default,
                                idleTimeoutInMinutes: idleTimeoutInMinutes,
                                enableFloatingIP: enableFloatingIP,
                                enableTcpReset: enableTcpReset,
                                provisioningState: provisioningState)
                            );

        /// <summary> Initializes a new instance of <see cref="Network.LoadBalancingRuleData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="frontendIPConfigurationId"> A reference to frontend IP addresses. </param>
        /// <param name="backendAddressPoolId"> A reference to a pool of DIPs. Inbound traffic is randomly load balanced across IPs in the backend IPs. </param>
        /// <param name="backendAddressPools"> An array of references to pool of DIPs. </param>
        /// <param name="probeId"> The reference to the load balancer probe used by the load balancing rule. </param>
        /// <param name="protocol"> The reference to the transport protocol used by the load balancing rule. </param>
        /// <param name="loadDistribution"> The load distribution policy for this rule. </param>
        /// <param name="frontendPort"> The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values are between 0 and 65534. Note that value 0 enables "Any Port". </param>
        /// <param name="backendPort"> The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables "Any Port". </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </param>
        /// <param name="enableFloatingIP"> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="disableOutboundSnat"> Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing rule. </param>
        /// <param name="provisioningState"> The provisioning state of the load balancing rule resource. </param>
        /// <returns> A new <see cref="Network.LoadBalancingRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LoadBalancingRuleData LoadBalancingRuleData(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, ResourceIdentifier frontendIPConfigurationId, ResourceIdentifier backendAddressPoolId, IEnumerable<WritableSubResource> backendAddressPools, ResourceIdentifier probeId, LoadBalancingTransportProtocol? protocol, LoadDistribution? loadDistribution, int? frontendPort, int? backendPort, int? idleTimeoutInMinutes, bool? enableFloatingIP, bool? enableTcpReset, bool? disableOutboundSnat, NetworkProvisioningState? provisioningState)
            => LoadBalancingRuleData(
                        id: id,
                        name: name,
                        resourceType: resourceType,
                        etag: etag,
                        properties: LoadBalancingRuleProperties(
                            frontendIPConfigurationId: frontendIPConfigurationId,
                            backendAddressPoolId: backendAddressPoolId,
                            backendAddressPools: backendAddressPools,
                            probeId: probeId,
                            protocol: protocol ?? default,
                            loadDistribution: loadDistribution ?? default,
                            frontendPort: frontendPort ?? default,
                            backendPort: backendPort ?? default,
                            idleTimeoutInMinutes: idleTimeoutInMinutes,
                            enableFloatingIP: enableFloatingIP,
                            enableTcpReset: enableTcpReset,
                            disableOutboundSnat: disableOutboundSnat,
                            provisioningState: provisioningState)
                        );

        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="extendedLocation"> The extended location of the virtual network. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="addressPrefixes"> The AddressSpace that contains an array of IP address ranges that can be used by subnets. </param>
        /// <param name="dhcpOptionsDnsServers"> The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network. </param>
        /// <param name="flowTimeoutInMinutes"> The FlowTimeout value (in minutes) for the Virtual Network. </param>
        /// <param name="subnets"> A list of subnets in a Virtual Network. </param>
        /// <param name="virtualNetworkPeerings"> A list of peerings in a Virtual Network. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the Virtual Network resource. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network resource. </param>
        /// <param name="enableDdosProtection"> Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource. </param>
        /// <param name="enableVmProtection"> Indicates if VM protection is enabled for all the subnets in the virtual network. </param>
        /// <param name="ddosProtectionPlanId"> The DDoS protection plan associated with the virtual network. </param>
        /// <param name="bgpCommunities"> Bgp Communities sent over ExpressRoute with each route corresponding to a prefix in this VNET. </param>
        /// <param name="encryption"> Indicates if encryption is enabled on virtual network and if VM without encryption is allowed in encrypted VNet. </param>
        /// <param name="ipAllocations"> Array of IpAllocation which reference this VNET. </param>
        /// <param name="flowLogs"> A collection of references to flow log resources. </param>
        /// <param name="privateEndpointVnetPolicy"> Private Endpoint VNet Policies. </param>
        /// <returns> A new <see cref="Network.VirtualNetworkData"/> instance for mocking. </returns>
        public static VirtualNetworkData VirtualNetworkData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, IEnumerable<string> addressPrefixes, IEnumerable<string> dhcpOptionsDnsServers, int? flowTimeoutInMinutes, IEnumerable<SubnetData> subnets, IEnumerable<VirtualNetworkPeeringData> virtualNetworkPeerings, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDdosProtection, bool? enableVmProtection, ResourceIdentifier ddosProtectionPlanId, VirtualNetworkBgpCommunities bgpCommunities, VirtualNetworkEncryption encryption, IEnumerable<WritableSubResource> ipAllocations, IEnumerable<FlowLogData> flowLogs, PrivateEndpointVnetPolicy? privateEndpointVnetPolicy)
            => VirtualNetworkData(id, name, resourceType, location, tags, extendedLocation, etag,
                                  addressPrefixes != null ? new VirtualNetworkAddressSpace(addressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                  dhcpOptionsDnsServers, flowTimeoutInMinutes, subnets, virtualNetworkPeerings, resourceGuid, provisioningState, enableDdosProtection, enableVmProtection, ddosProtectionPlanId, bgpCommunities, encryption, ipAllocations, flowLogs, privateEndpointVnetPolicy);

        /// <summary> Initializes a new instance of <see cref="Models.P2SConnectionConfiguration"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="vpnClientAddressPrefixes"> The reference to the address space resource which represents Address space for P2S VpnClient. </param>
        /// <param name="routingConfiguration"> The Routing Configuration indicating the associated and propagated route tables on this connection. </param>
        /// <param name="enableInternetSecurity"> Flag indicating whether the enable internet security flag is turned on for the P2S Connections or not. </param>
        /// <param name="configurationPolicyGroupAssociations"> List of Configuration Policy Groups that this P2SConnectionConfiguration is attached to. </param>
        /// <param name="previousConfigurationPolicyGroupAssociations"> List of previous Configuration Policy Groups that this P2SConnectionConfiguration was attached to. </param>
        /// <param name="provisioningState"> The provisioning state of the P2SConnectionConfiguration resource. </param>
        /// <returns> A new <see cref="Models.P2SConnectionConfiguration"/> instance for mocking. </returns>
        public static P2SConnectionConfiguration P2SConnectionConfiguration(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, IEnumerable<string> vpnClientAddressPrefixes, RoutingConfiguration routingConfiguration, bool? enableInternetSecurity, IEnumerable<WritableSubResource> configurationPolicyGroupAssociations, IEnumerable<VpnServerConfigurationPolicyGroupData> previousConfigurationPolicyGroupAssociations, NetworkProvisioningState? provisioningState)
            => P2SConnectionConfiguration(id, name, resourceType, etag,
                                          vpnClientAddressPrefixes != null ? new VirtualNetworkAddressSpace(vpnClientAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                          routingConfiguration, enableInternetSecurity, configurationPolicyGroupAssociations, previousConfigurationPolicyGroupAssociations, provisioningState);

        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkPeeringData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="allowVirtualNetworkAccess"> Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space. </param>
        /// <param name="allowForwardedTraffic"> Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network. </param>
        /// <param name="allowGatewayTransit"> If gateway links can be used in remote virtual networking to link to this virtual network. </param>
        /// <param name="useRemoteGateways"> If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway. </param>
        /// <param name="remoteVirtualNetworkId"> The reference to the remote virtual network. The remote virtual network can be in the same or different region (preview). See here to register for the preview and learn more (https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-create-peering). </param>
        /// <param name="localAddressPrefixes"> The local address space of the local virtual network that is peered. </param>
        /// <param name="localVirtualNetworkAddressPrefixes"> The current local address space of the local virtual network that is peered. </param>
        /// <param name="remoteAddressPrefixes"> The reference to the address space peered with the remote virtual network. </param>
        /// <param name="remoteVirtualNetworkAddressPrefixes"> The reference to the current address space of the remote virtual network. </param>
        /// <param name="remoteBgpCommunities"> The reference to the remote virtual network's Bgp Communities. </param>
        /// <param name="remoteVirtualNetworkEncryption"> The reference to the remote virtual network's encryption. </param>
        /// <param name="peeringState"> The status of the virtual network peering. </param>
        /// <param name="peeringSyncLevel"> The peering sync status of the virtual network peering. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network peering resource. </param>
        /// <param name="doNotVerifyRemoteGateways"> If we need to verify the provisioning state of the remote gateway. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the Virtual Network peering resource. </param>
        /// <param name="areCompleteVnetsPeered"> Whether complete virtual network address space is peered. </param>
        /// <param name="enableOnlyIPv6Peering"> Whether only Ipv6 address space is peered for subnet peering. </param>
        /// <param name="localSubnetNames"> List of local subnet names that are subnet peered with remote virtual network. </param>
        /// <param name="remoteSubnetNames"> List of remote subnet names from remote virtual network that are subnet peered. </param>
        /// <returns> A new <see cref="Network.VirtualNetworkPeeringData"/> instance for mocking. </returns>
        public static VirtualNetworkPeeringData VirtualNetworkPeeringData(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, bool? allowVirtualNetworkAccess, bool? allowForwardedTraffic, bool? allowGatewayTransit, bool? useRemoteGateways, ResourceIdentifier remoteVirtualNetworkId, IEnumerable<string> localAddressPrefixes, IEnumerable<string> localVirtualNetworkAddressPrefixes, IEnumerable<string> remoteAddressPrefixes, IEnumerable<string> remoteVirtualNetworkAddressPrefixes, VirtualNetworkBgpCommunities remoteBgpCommunities, VirtualNetworkEncryption remoteVirtualNetworkEncryption, VirtualNetworkPeeringState? peeringState, VirtualNetworkPeeringLevel? peeringSyncLevel, NetworkProvisioningState? provisioningState, bool? doNotVerifyRemoteGateways, Guid? resourceGuid, bool? areCompleteVnetsPeered, bool? enableOnlyIPv6Peering, IEnumerable<string> localSubnetNames, IEnumerable<string> remoteSubnetNames)
            => VirtualNetworkPeeringData(id, name, resourceType, etag, allowVirtualNetworkAccess, allowForwardedTraffic, allowGatewayTransit, useRemoteGateways, remoteVirtualNetworkId,
                                         localAddressPrefixes != null ? new VirtualNetworkAddressSpace(localAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                         localVirtualNetworkAddressPrefixes != null ? new VirtualNetworkAddressSpace(localVirtualNetworkAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                         remoteAddressPrefixes != null ? new VirtualNetworkAddressSpace(remoteAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                         remoteVirtualNetworkAddressPrefixes != null ? new VirtualNetworkAddressSpace(remoteVirtualNetworkAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                         remoteBgpCommunities, remoteVirtualNetworkEncryption, peeringState, peeringSyncLevel, provisioningState, doNotVerifyRemoteGateways, resourceGuid, areCompleteVnetsPeered, enableOnlyIPv6Peering, localSubnetNames, remoteSubnetNames);

        /// <summary> Initializes a new instance of <see cref="Models.VngClientConnectionConfiguration"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="vpnClientAddressPrefixes"> The reference to the address space resource which represents Address space for P2S VpnClient. </param>
        /// <param name="virtualNetworkGatewayPolicyGroups"> List of references to virtualNetworkGatewayPolicyGroups. </param>
        /// <param name="provisioningState"> The provisioning state of the VngClientConnectionConfiguration resource. </param>
        /// <returns> A new <see cref="Models.VngClientConnectionConfiguration"/> instance for mocking. </returns>
        public static VngClientConnectionConfiguration VngClientConnectionConfiguration(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, IEnumerable<string> vpnClientAddressPrefixes, IEnumerable<WritableSubResource> virtualNetworkGatewayPolicyGroups, NetworkProvisioningState? provisioningState)
            => VngClientConnectionConfiguration(id, name, resourceType, etag,
                                                vpnClientAddressPrefixes != null ? new VirtualNetworkAddressSpace(vpnClientAddressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                                                virtualNetworkGatewayPolicyGroups,
                                                provisioningState);

        /// <summary> Initializes a new instance of <see cref="Network.VpnSiteData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="virtualWanId"> The VirtualWAN to which the vpnSite belongs. </param>
        /// <param name="deviceProperties"> The device properties. </param>
        /// <param name="ipAddress"> The ip-address for the vpn-site. </param>
        /// <param name="siteKey"> The key for vpn-site that can be used for connections. </param>
        /// <param name="addressPrefixes"> The AddressSpace that contains an array of IP address ranges. </param>
        /// <param name="bgpProperties"> The set of bgp properties. </param>
        /// <param name="provisioningState"> The provisioning state of the VPN site resource. </param>
        /// <param name="isSecuritySite"> IsSecuritySite flag. </param>
        /// <param name="vpnSiteLinks"> List of all vpn site links. </param>
        /// <param name="o365BreakOutCategories"> Office365 Policy. </param>
        /// <returns> A new <see cref="Network.VpnSiteData"/> instance for mocking. </returns>
        public static VpnSiteData VpnSiteData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ETag? etag, ResourceIdentifier virtualWanId, DeviceProperties deviceProperties, string ipAddress, string siteKey, IEnumerable<string> addressPrefixes, BgpSettings bgpProperties, NetworkProvisioningState? provisioningState, bool? isSecuritySite, IEnumerable<VpnSiteLinkData> vpnSiteLinks, O365BreakOutCategoryPolicies o365BreakOutCategories)
            => VpnSiteData(id, name, resourceType, location, tags, etag, virtualWanId, deviceProperties, ipAddress, siteKey,
                           addressPrefixes != null ? new VirtualNetworkAddressSpace(addressPrefixes?.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), null) : null,
                           bgpProperties, provisioningState, isSecuritySite, vpnSiteLinks, o365BreakOutCategories);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Network.VirtualNetworkData" />. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="extendedLocation"> The extended location of the virtual network. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="addressPrefixes"> The AddressSpace that contains an array of IP address ranges that can be used by subnets. </param>
        /// <param name="dhcpOptionsDnsServers"> The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network. </param>
        /// <param name="flowTimeoutInMinutes"> The FlowTimeout value (in minutes) for the Virtual Network. </param>
        /// <param name="subnets"> A list of subnets in a Virtual Network. </param>
        /// <param name="virtualNetworkPeerings"> A list of peerings in a Virtual Network. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the Virtual Network resource. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network resource. </param>
        /// <param name="enableDdosProtection"> Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource. </param>
        /// <param name="enableVmProtection"> Indicates if VM protection is enabled for all the subnets in the virtual network. </param>
        /// <param name="ddosProtectionPlanId"> The DDoS protection plan associated with the virtual network. </param>
        /// <param name="bgpCommunities"> Bgp Communities sent over ExpressRoute with each route corresponding to a prefix in this VNET. </param>
        /// <param name="encryption"> Indicates if encryption is enabled on virtual network and if VM without encryption is allowed in encrypted VNet. </param>
        /// <param name="ipAllocations"> Array of IpAllocation which reference this VNET. </param>
        /// <param name="flowLogs"> A collection of references to flow log resources. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Network.VirtualNetworkData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkData VirtualNetworkData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, IEnumerable<string> addressPrefixes, IEnumerable<string> dhcpOptionsDnsServers, int? flowTimeoutInMinutes, IEnumerable<SubnetData> subnets, IEnumerable<VirtualNetworkPeeringData> virtualNetworkPeerings, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDdosProtection, bool? enableVmProtection, ResourceIdentifier ddosProtectionPlanId, VirtualNetworkBgpCommunities bgpCommunities, VirtualNetworkEncryption encryption, IEnumerable<WritableSubResource> ipAllocations, IEnumerable<FlowLogData> flowLogs)
        {
            return VirtualNetworkData(id: id, name: name, resourceType: resourceType, location: location, tags: tags, extendedLocation: extendedLocation, etag: etag, addressPrefixes: addressPrefixes, dhcpOptionsDnsServers: dhcpOptionsDnsServers, flowTimeoutInMinutes: flowTimeoutInMinutes, subnets: subnets, virtualNetworkPeerings: virtualNetworkPeerings, resourceGuid: resourceGuid, provisioningState: provisioningState, enableDdosProtection: enableDdosProtection, enableVmProtection: enableVmProtection, ddosProtectionPlanId: ddosProtectionPlanId, bgpCommunities: bgpCommunities, encryption: encryption, ipAllocations: ipAllocations, flowLogs: flowLogs, privateEndpointVnetPolicy: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Network.VirtualNetworkGatewayData" />. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="extendedLocation"> The extended location of type local virtual network gateway. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="autoScaleBounds"> Autoscale configuration for virutal network gateway. </param>
        /// <param name="ipConfigurations"> IP configurations for virtual network gateway. </param>
        /// <param name="gatewayType"> The type of this virtual network gateway. </param>
        /// <param name="vpnType"> The type of this virtual network gateway. </param>
        /// <param name="vpnGatewayGeneration"> The generation for this VirtualNetworkGateway. Must be None if gatewayType is not VPN. </param>
        /// <param name="enableBgp"> Whether BGP is enabled for this virtual network gateway or not. </param>
        /// <param name="enablePrivateIPAddress"> Whether private IP needs to be enabled on this gateway for connections or not. </param>
        /// <param name="active"> ActiveActive flag. </param>
        /// <param name="disableIPSecReplayProtection"> disableIPSecReplayProtection flag. </param>
        /// <param name="gatewayDefaultSiteId"> The reference to the LocalNetworkGateway resource which represents local network site having default routes. Assign Null value in case of removing existing default site setting. </param>
        /// <param name="sku"> The reference to the VirtualNetworkGatewaySku resource which represents the SKU selected for Virtual network gateway. </param>
        /// <param name="vpnClientConfiguration"> The reference to the VpnClientConfiguration resource which represents the P2S VpnClient configurations. </param>
        /// <param name="virtualNetworkGatewayPolicyGroups"> The reference to the VirtualNetworkGatewayPolicyGroup resource which represents the available VirtualNetworkGatewayPolicyGroup for the gateway. </param>
        /// <param name="bgpSettings"> Virtual network gateway's BGP speaker settings. </param>
        /// <param name="customRoutesAddressPrefixes"> The reference to the address space resource which represents the custom routes address space specified by the customer for virtual network gateway and VpnClient. </param>
        /// <param name="resourceGuid"> The resource GUID property of the virtual network gateway resource. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network gateway resource. </param>
        /// <param name="enableDnsForwarding"> Whether dns forwarding is enabled or not. </param>
        /// <param name="inboundDnsForwardingEndpoint"> The IP address allocated by the gateway to which dns requests can be sent. </param>
        /// <param name="vNetExtendedLocationResourceId"> Customer vnet resource id. VirtualNetworkGateway of type local gateway is associated with the customer vnet. </param>
        /// <param name="natRules"> NatRules for virtual network gateway. </param>
        /// <param name="enableBgpRouteTranslationForNat"> EnableBgpRouteTranslationForNat flag. </param>
        /// <param name="allowVirtualWanTraffic"> Configures this gateway to accept traffic from remote Virtual WAN networks. </param>
        /// <param name="allowRemoteVnetTraffic"> Configure this gateway to accept traffic from other Azure Virtual Networks. This configuration does not support connectivity to Azure Virtual WAN. </param>
        /// <param name="adminState"> Property to indicate if the Express Route Gateway serves traffic when there are multiple Express Route Gateways in the vnet. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Network.VirtualNetworkGatewayData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkGatewayData VirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, ExtendedLocation extendedLocation, ETag? etag, VirtualNetworkGatewayAutoScaleBounds autoScaleBounds, IEnumerable<VirtualNetworkGatewayIPConfiguration> ipConfigurations, VirtualNetworkGatewayType? gatewayType, VpnType? vpnType, VpnGatewayGeneration? vpnGatewayGeneration, bool? enableBgp, bool? enablePrivateIPAddress, bool? active, bool? disableIPSecReplayProtection, ResourceIdentifier gatewayDefaultSiteId, VirtualNetworkGatewaySku sku, VpnClientConfiguration vpnClientConfiguration, IEnumerable<VirtualNetworkGatewayPolicyGroup> virtualNetworkGatewayPolicyGroups, BgpSettings bgpSettings, IEnumerable<string> customRoutesAddressPrefixes, Guid? resourceGuid, NetworkProvisioningState? provisioningState, bool? enableDnsForwarding, string inboundDnsForwardingEndpoint, ResourceIdentifier vNetExtendedLocationResourceId, IEnumerable<VirtualNetworkGatewayNatRuleData> natRules, bool? enableBgpRouteTranslationForNat, bool? allowVirtualWanTraffic, bool? allowRemoteVnetTraffic, ExpressRouteGatewayAdminState? adminState)
        {
            return VirtualNetworkGatewayData(id: id, name: name, resourceType: resourceType, location: location, tags: tags, extendedLocation: extendedLocation, etag: etag, identity: default, autoScaleBounds: autoScaleBounds, ipConfigurations: ipConfigurations, gatewayType: gatewayType, vpnType: vpnType, vpnGatewayGeneration: vpnGatewayGeneration, enableBgp: enableBgp, enablePrivateIPAddress: enablePrivateIPAddress, active: active, disableIPSecReplayProtection: disableIPSecReplayProtection, gatewayDefaultSiteId: gatewayDefaultSiteId, sku: sku, vpnClientConfiguration: vpnClientConfiguration, virtualNetworkGatewayPolicyGroups: virtualNetworkGatewayPolicyGroups, bgpSettings: bgpSettings, customRoutesAddressPrefixes: customRoutesAddressPrefixes, resourceGuid: resourceGuid, provisioningState: provisioningState, enableDnsForwarding: enableDnsForwarding, inboundDnsForwardingEndpoint: inboundDnsForwardingEndpoint, vNetExtendedLocationResourceId: vNetExtendedLocationResourceId, natRules: natRules, enableBgpRouteTranslationForNat: enableBgpRouteTranslationForNat, allowVirtualWanTraffic: allowVirtualWanTraffic, allowRemoteVnetTraffic: allowRemoteVnetTraffic, adminState: adminState, resiliencyModel: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Network.VirtualNetworkPeeringData" />. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="allowVirtualNetworkAccess"> Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space. </param>
        /// <param name="allowForwardedTraffic"> Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network. </param>
        /// <param name="allowGatewayTransit"> If gateway links can be used in remote virtual networking to link to this virtual network. </param>
        /// <param name="useRemoteGateways"> If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway. </param>
        /// <param name="remoteVirtualNetworkId"> The reference to the remote virtual network. The remote virtual network can be in the same or different region (preview). See here to register for the preview and learn more (https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-create-peering). </param>
        /// <param name="remoteAddressPrefixes"> The reference to the address space peered with the remote virtual network. </param>
        /// <param name="remoteVirtualNetworkAddressPrefixes"> The reference to the current address space of the remote virtual network. </param>
        /// <param name="remoteBgpCommunities"> The reference to the remote virtual network's Bgp Communities. </param>
        /// <param name="remoteVirtualNetworkEncryption"> The reference to the remote virtual network's encryption. </param>
        /// <param name="peeringState"> The status of the virtual network peering. </param>
        /// <param name="peeringSyncLevel"> The peering sync status of the virtual network peering. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network peering resource. </param>
        /// <param name="doNotVerifyRemoteGateways"> If we need to verify the provisioning state of the remote gateway. </param>
        /// <param name="resourceGuid"> The resourceGuid property of the Virtual Network peering resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Network.VirtualNetworkPeeringData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkPeeringData VirtualNetworkPeeringData(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, bool? allowVirtualNetworkAccess, bool? allowForwardedTraffic, bool? allowGatewayTransit, bool? useRemoteGateways, ResourceIdentifier remoteVirtualNetworkId, IEnumerable<string> remoteAddressPrefixes, IEnumerable<string> remoteVirtualNetworkAddressPrefixes, VirtualNetworkBgpCommunities remoteBgpCommunities, VirtualNetworkEncryption remoteVirtualNetworkEncryption, VirtualNetworkPeeringState? peeringState, VirtualNetworkPeeringLevel? peeringSyncLevel, NetworkProvisioningState? provisioningState, bool? doNotVerifyRemoteGateways, Guid? resourceGuid)
        {
            return VirtualNetworkPeeringData(id: id, name: name, resourceType: resourceType, etag: etag, allowVirtualNetworkAccess: allowVirtualNetworkAccess, allowForwardedTraffic: allowForwardedTraffic, allowGatewayTransit: allowGatewayTransit, useRemoteGateways: useRemoteGateways, remoteVirtualNetworkId: remoteVirtualNetworkId, localAddressPrefixes: default, localVirtualNetworkAddressPrefixes: default, remoteAddressPrefixes: remoteAddressPrefixes, remoteVirtualNetworkAddressPrefixes: remoteVirtualNetworkAddressPrefixes, remoteBgpCommunities: remoteBgpCommunities, remoteVirtualNetworkEncryption: remoteVirtualNetworkEncryption, peeringState: peeringState, peeringSyncLevel: peeringSyncLevel, provisioningState: provisioningState, doNotVerifyRemoteGateways: doNotVerifyRemoteGateways, resourceGuid: resourceGuid, areCompleteVnetsPeered: default, enableOnlyIPv6Peering: default, localSubnetNames: default, remoteSubnetNames: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.LoadBalancerHealthPerRulePerBackendAddress"/>. </summary>
        /// <param name="ipAddress"> The IP address belonging to the backend address. </param>
        /// <param name="networkInterfaceIPConfigurationId"> The id of the network interface ip configuration belonging to the backend address. </param>
        /// <param name="state"> The current health of the backend instances that is associated to the LB rule. </param>
        /// <param name="reason"> The explanation of the State. </param>
        /// <returns> A new <see cref="Models.LoadBalancerHealthPerRulePerBackendAddress"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LoadBalancerHealthPerRulePerBackendAddress LoadBalancerHealthPerRulePerBackendAddress(string ipAddress, NetworkInterfaceIPConfigurationData networkInterfaceIPConfigurationId, string state, string reason)
        {
            return LoadBalancerHealthPerRulePerBackendAddress(ipAddress, networkInterfaceIPConfigurationId?.Id, state, reason);
        }
    }
}
