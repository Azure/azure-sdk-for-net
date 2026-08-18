// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using Azure.Core;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // Keep provisioning-only compatibility names together.

namespace Azure.Provisioning.Network
{
    public partial class ApplicationGateway
    {
        private BicepList<string> _compatibilityAvailabilityZones;

        /// <summary> Gets or sets the availability zones. </summary>
        [CodeGenMember("Zones")]
        public BicepList<string> AvailabilityZones
        {
            get { Initialize(); return _compatibilityAvailabilityZones; }
            set { Initialize(); _compatibilityAvailabilityZones.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityAvailabilityZones = DefineListProperty<string>(nameof(AvailabilityZones), new string[] { "zones" });
    }

    public partial class ApplicationGatewayRequestRoutingRule
    {
        /// <summary> Gets or sets the Entra JWT validation configuration resource identifier. </summary>
        [CodeGenMember("EntraJWTValidationConfig")]
        public BicepValue<ResourceIdentifier> EntraJwtValidationConfigId
        {
            get { return Properties is null ? default : Properties.EntraJWTValidationConfig; }
            set
            {
                Properties ??= new ApplicationGatewayRequestRoutingRulePropertiesFormat();
                Properties.EntraJWTValidationConfig = value;
            }
        }
    }

    public partial class CustomIPPrefix
    {
        /// <summary> Gets or sets the parent custom IP prefix resource identifier. </summary>
        [CodeGenMember("CustomIPPrefixParent")]
        public BicepValue<ResourceIdentifier> ParentCustomIPPrefixId
        {
            get { return Properties is null ? default : Properties.CustomIPPrefixParent; }
            set
            {
                Properties ??= new CustomIpPrefixPropertiesFormat();
                Properties.CustomIPPrefixParent = value;
            }
        }

        /// <summary> Gets the child custom IP prefixes. </summary>
        [CodeGenMember("ChildCustomIPPrefixes")]
        public BicepList<WritableSubResource> ChildCustomIPPrefixList
        {
            get
            {
                Properties ??= new CustomIpPrefixPropertiesFormat();
                return Properties.ChildCustomIPPrefixes;
            }
        }
    }

    public partial class ExpressRouteCircuitPeering
    {
        /// <summary> Gets or sets the ExpressRoute connection resource identifier. </summary>
        [CodeGenMember("ExpressRouteConnection")]
        public BicepValue<ResourceIdentifier> ExpressRouteConnectionId
        {
            get { return Properties is null ? default : Properties.ExpressRouteConnection; }
            set
            {
                Properties ??= new ExpressRouteCircuitPeeringPropertiesFormat();
                Properties.ExpressRouteConnection = value;
            }
        }
    }

    public partial class ExpressRouteConnection
    {
        /// <summary> Gets or sets the ExpressRoute circuit peering resource identifier. </summary>
        [CodeGenMember("ExpressRouteCircuitPeering")]
        public BicepValue<ResourceIdentifier> ExpressRouteCircuitPeeringId
        {
            get { return Properties is null ? default : Properties.ExpressRouteCircuitPeering; }
            set
            {
                Properties ??= new ExpressRouteConnectionProperties();
                Properties.ExpressRouteCircuitPeering = value;
            }
        }
    }

    public partial class ExpressRouteCrossConnection
    {
        /// <summary> Gets or sets the ExpressRoute circuit resource identifier. </summary>
        [CodeGenMember("ExpressRouteCircuit")]
        public BicepValue<ResourceIdentifier> ExpressRouteCircuitId
        {
            get { return Properties is null ? default : Properties.ExpressRouteCircuit; }
            set
            {
                Properties ??= new ExpressRouteCrossConnectionProperties();
                Properties.ExpressRouteCircuit = value;
            }
        }
    }

    public partial class ExpressRouteGateway
    {
        /// <summary> Gets or sets the ExpressRoute connections. </summary>
        [CodeGenMember("ExpressRouteConnections")]
        public BicepList<ExpressRouteConnection> ExpressRouteConnectionList
        {
            get
            {
                Properties ??= new ExpressRouteGatewayProperties();
                return Properties.ExpressRouteConnections;
            }
            set
            {
                Properties ??= new ExpressRouteGatewayProperties();
                Properties.ExpressRouteConnections = value;
            }
        }

        /// <summary> Gets or sets the virtual hub resource identifier. </summary>
        [CodeGenMember("VirtualHub")]
        public BicepValue<ResourceIdentifier> VirtualHubId
        {
            get { return Properties is null ? default : Properties.VirtualHub; }
            set
            {
                Properties ??= new ExpressRouteGatewayProperties();
                Properties.VirtualHub = value;
            }
        }
    }

    public partial class LoadBalancerBackendAddress
    {
        /// <summary> Gets or sets the load balancer frontend IP configuration resource identifier. </summary>
        [CodeGenMember("LoadBalancerFrontendIPConfiguration")]
        public BicepValue<ResourceIdentifier> LoadBalancerFrontendIPConfigurationId
        {
            get { return Properties is null ? default : Properties.LoadBalancerFrontendIPConfiguration; }
            set
            {
                Properties ??= new LoadBalancerBackendAddressPropertiesFormat();
                Properties.LoadBalancerFrontendIPConfiguration = value;
            }
        }
    }

    public partial class NvaInterfaceConfigurationsProperties
    {
        private BicepList<NvaNicType> _compatibilityPropertiesType;

        /// <summary> Gets or sets the NVA NIC types. </summary>
        [CodeGenMember("Type")]
        public BicepList<NvaNicType> PropertiesType
        {
            get { Initialize(); return _compatibilityPropertiesType; }
            set { Initialize(); _compatibilityPropertiesType.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityPropertiesType = DefineListProperty<NvaNicType>(nameof(PropertiesType), new string[] { "type" });
    }

    public partial class ApplicationGatewayPrivateEndpointConnection
    {
        /// <summary> Gets or sets the private link service connection state. </summary>
        [CodeGenMember("PrivateLinkServiceConnectionState")]
        public NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get { return Properties is null ? default : Properties.PrivateLinkServiceConnectionState; }
            set
            {
                Properties ??= new ApplicationGatewayPrivateEndpointConnectionProperties();
                Properties.PrivateLinkServiceConnectionState = value;
            }
        }
    }

    public partial class NetworkPrivateEndpointConnection
    {
        /// <summary> Gets or sets the private link service connection state. </summary>
        [CodeGenMember("PrivateLinkServiceConnectionState")]
        public NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get { return Properties is null ? default : Properties.PrivateLinkServiceConnectionState; }
            set
            {
                Properties ??= new PrivateEndpointConnectionProperties();
                Properties.PrivateLinkServiceConnectionState = value;
            }
        }
    }

    public partial class NetworkPrivateLinkServiceConnection
    {
        /// <summary> Gets or sets the private link service connection state. </summary>
        [CodeGenMember("PrivateLinkServiceConnectionState")]
        public NetworkPrivateLinkServiceConnectionState ConnectionState
        {
            get { return Properties is null ? default : Properties.PrivateLinkServiceConnectionState; }
            set
            {
                Properties ??= new PrivateLinkServiceConnectionProperties();
                Properties.PrivateLinkServiceConnectionState = value;
            }
        }
    }

    public partial class FlowLog
    {
        /// <summary> Gets or sets the traffic analytics configuration. </summary>
        [CodeGenMember("NetworkWatcherFlowAnalyticsConfiguration")]
        public TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration
        {
            get { return Properties is null ? default : Properties.NetworkWatcherFlowAnalyticsConfiguration; }
            set
            {
                Properties ??= new FlowLogPropertiesFormat();
                Properties.NetworkWatcherFlowAnalyticsConfiguration = value;
            }
        }
    }

    public partial class P2SConnectionConfiguration
    {
        /// <summary> Gets or sets the configuration policy groups. </summary>
        [CodeGenMember("ConfigurationPolicyGroupAssociations")]
        public BicepList<WritableSubResource> ConfigurationPolicyGroups
        {
            get
            {
                Properties ??= new P2SConnectionConfigurationProperties();
                return Properties.ConfigurationPolicyGroupAssociations;
            }
            set
            {
                Properties ??= new P2SConnectionConfigurationProperties();
                Properties.ConfigurationPolicyGroupAssociations = value;
            }
        }
    }

    public partial class SubnetResource
    {
        /// <summary> Gets or sets the private endpoint network policy. </summary>
        [CodeGenMember("PrivateEndpointNetworkPolicies")]
        public BicepValue<VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy
        {
            get { return Properties is null ? default : Properties.PrivateEndpointNetworkPolicies; }
            set
            {
                Properties ??= new SubnetPropertiesFormat();
                Properties.PrivateEndpointNetworkPolicies = value;
            }
        }

        /// <summary> Gets or sets the private link service network policy. </summary>
        [CodeGenMember("PrivateLinkServiceNetworkPolicies")]
        public BicepValue<VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy
        {
            get { return Properties is null ? default : Properties.PrivateLinkServiceNetworkPolicies; }
            set
            {
                Properties ??= new SubnetPropertiesFormat();
                Properties.PrivateLinkServiceNetworkPolicies = value;
            }
        }
    }

    public partial class ApplicationGatewayBackendSettings
    {
        /// <summary> Gets or sets whether L4 client IP preservation is enabled. </summary>
        [CodeGenMember("EnableL4ClientIpPreservation")]
        public BicepValue<bool> IsL4ClientIPPreservationEnabled
        {
            get { return Properties is null ? default : Properties.EnableL4ClientIpPreservation; }
            set
            {
                Properties ??= new ApplicationGatewayBackendSettingsPropertiesFormat();
                Properties.EnableL4ClientIpPreservation = value;
            }
        }

        /// <summary> Gets or sets the timeout in seconds. </summary>
        [CodeGenMember("Timeout")]
        public BicepValue<int> TimeoutInSeconds
        {
            get { return Properties is null ? default : Properties.Timeout; }
            set
            {
                Properties ??= new ApplicationGatewayBackendSettingsPropertiesFormat();
                Properties.Timeout = value;
            }
        }
    }

    public partial class ApplicationGatewayPrivateLinkIPConfiguration
    {
        /// <summary> Gets or sets whether this is the primary IP configuration. </summary>
        [CodeGenMember("Primary")]
        public BicepValue<bool> IsPrimary
        {
            get { return Properties is null ? default : Properties.Primary; }
            set
            {
                Properties ??= new ApplicationGatewayPrivateLinkIpConfigurationProperties();
                Properties.Primary = value;
            }
        }
    }

    public partial class ApplicationGatewayProbe
    {
        /// <summary> Gets or sets the probe interval in seconds. </summary>
        [CodeGenMember("Interval")]
        public BicepValue<int> IntervalInSeconds
        {
            get { return Properties is null ? default : Properties.Interval; }
            set
            {
                Properties ??= new ApplicationGatewayProbePropertiesFormat();
                Properties.Interval = value;
            }
        }

        /// <summary> Gets or sets the probe timeout in seconds. </summary>
        [CodeGenMember("Timeout")]
        public BicepValue<int> TimeoutInSeconds
        {
            get { return Properties is null ? default : Properties.Timeout; }
            set
            {
                Properties ??= new ApplicationGatewayProbePropertiesFormat();
                Properties.Timeout = value;
            }
        }

        /// <summary> Gets or sets whether the proxy protocol header is enabled. </summary>
        [CodeGenMember("EnableProbeProxyProtocolHeader")]
        public BicepValue<bool> IsProbeProxyProtocolHeaderEnabled
        {
            get { return Properties is null ? default : Properties.EnableProbeProxyProtocolHeader; }
            set
            {
                Properties ??= new ApplicationGatewayProbePropertiesFormat();
                Properties.EnableProbeProxyProtocolHeader = value;
            }
        }
    }

    public partial class ConnectionMonitorTestConfiguration
    {
        /// <summary> Gets or sets whether trace route is disabled. </summary>
        [CodeGenMember("IcmpDisableTraceRoute")]
        public BicepValue<bool> DisableTraceRoute
        {
            get { return IcmpConfiguration is null ? default : IcmpConfiguration.DisableTraceRoute; }
            set
            {
                IcmpConfiguration ??= new ConnectionMonitorIcmpConfiguration();
                IcmpConfiguration.DisableTraceRoute = value;
            }
        }
    }

    public partial class PacketCapture
    {
        /// <summary> Gets or sets whether continuous capture is enabled. </summary>
        [CodeGenMember("ContinuousCapture")]
        public BicepValue<bool> IsContinuousCapture
        {
            get { return Properties is null ? default : Properties.ContinuousCapture; }
            set
            {
                Properties ??= new PacketCaptureResultProperties();
                Properties.ContinuousCapture = value;
            }
        }
    }

    public partial class VirtualNetworkEncryption
    {
        private BicepValue<bool> _compatibilityIsEnabled;

        /// <summary> Gets or sets whether encryption is enabled. </summary>
        [CodeGenMember("Enabled")]
        public BicepValue<bool> IsEnabled
        {
            get { Initialize(); return _compatibilityIsEnabled; }
            set { Initialize(); _compatibilityIsEnabled.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityIsEnabled = DefineProperty<bool>(nameof(IsEnabled), new string[] { "enabled" });
    }

    public partial class VirtualNetworkGateway
    {
        /// <summary> Gets or sets whether the gateway is active-active. </summary>
        [CodeGenMember("ActiveActive")]
        public BicepValue<bool> Active
        {
            get { return Properties is null ? default : Properties.ActiveActive; }
            set
            {
                Properties ??= new VirtualNetworkGatewayPropertiesFormat();
                Properties.ActiveActive = value;
            }
        }
    }

    public partial class VirtualNetworkPeering
    {
        /// <summary> Gets or sets whether complete virtual networks are peered. </summary>
        [CodeGenMember("PeerCompleteVnets")]
        public BicepValue<bool> AreCompleteVnetsPeered
        {
            get { return Properties is null ? default : Properties.PeerCompleteVnets; }
            set
            {
                Properties ??= new VirtualNetworkPeeringPropertiesFormat();
                Properties.PeerCompleteVnets = value;
            }
        }
    }

    public partial class TunnelConnectionHealth
    {
        private BicepValue<string> _compatibilityLastConnectionEstablishedOn;

        /// <summary> Gets the last connection establishment time. </summary>
        [CodeGenMember("LastConnectionEstablishedUtcTime")]
        public BicepValue<string> LastConnectionEstablishedOn
        {
            get { Initialize(); return _compatibilityLastConnectionEstablishedOn; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityLastConnectionEstablishedOn = DefineProperty<string>(
                nameof(LastConnectionEstablishedOn),
                new string[] { "lastConnectionEstablishedUtcTime" },
                isOutput: true);
    }

    public partial class ContainerNetworkInterfaceIPConfiguration
    {
        private BicepValue<string> _compatibilityType;

        /// <summary> Gets the container network interface IP configuration type. </summary>
        [CodeGenMember("Type")]
        public BicepValue<string> ContainerNetworkInterfaceIpConfigurationType
        {
            get { Initialize(); return _compatibilityType; }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityType = DefineProperty<string>(
                nameof(ContainerNetworkInterfaceIpConfigurationType),
                new string[] { "type" },
                isOutput: true);
    }

    public partial class PrivateEndpointIPConfiguration
    {
        private BicepValue<string> _compatibilityType;
        private BicepValue<IPAddress> _compatibilityPrivateIPAddress;

        /// <summary> Gets the private endpoint IP configuration type. </summary>
        [CodeGenMember("Type")]
        public BicepValue<string> PrivateEndpointIPConfigurationType
        {
            get { Initialize(); return _compatibilityType; }
        }

        /// <summary> Gets or sets the private IP address. </summary>
        [CodeGenMember("PrivateIPAddress")]
        public BicepValue<IPAddress> PrivateIPAddress
        {
            get { Initialize(); return _compatibilityPrivateIPAddress; }
            set { Initialize(); _compatibilityPrivateIPAddress.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityType = DefineProperty<string>(
                nameof(PrivateEndpointIPConfigurationType),
                new string[] { "type" },
                isOutput: true);
            _compatibilityPrivateIPAddress = DefineProperty<IPAddress>(
                nameof(PrivateIPAddress),
                new string[] { "properties", "privateIPAddress" });
        }
    }

    public partial class VirtualNetworkApplianceIPConfiguration
    {
        private BicepValue<bool> _compatibilityPrimary;

        /// <summary> Gets or sets whether this is the primary IP configuration. </summary>
        [CodeGenMember("Primary")]
        public BicepValue<bool> Primary
        {
            get { Initialize(); return _compatibilityPrimary; }
            set { Initialize(); _compatibilityPrimary.Assign(value); }
        }
    }

    public partial class ApplicationGatewayCustomError
    {
        private BicepValue<Uri> _compatibilityCustomErrorPageUri;

        /// <summary> Gets or sets the custom error page URI. </summary>
        [CodeGenMember("CustomErrorPageUrl")]
        public BicepValue<Uri> CustomErrorPageUri
        {
            get { Initialize(); return _compatibilityCustomErrorPageUri; }
            set { Initialize(); _compatibilityCustomErrorPageUri.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityCustomErrorPageUri = DefineProperty<Uri>(
                nameof(CustomErrorPageUri),
                new string[] { "customErrorPageUrl" });
    }
}
