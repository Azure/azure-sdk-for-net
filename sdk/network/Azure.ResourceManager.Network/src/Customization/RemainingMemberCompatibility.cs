// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("Data")]
    public partial class ManagementGroupNetworkManagerConnectionResource
    {
        public virtual NetworkManagerConnectionData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }

                return new NetworkManagerConnectionData();
            }
        }
    }

    [CodeGenSuppress("Data")]
    public partial class SubscriptionNetworkManagerConnectionResource
    {
        public virtual NetworkManagerConnectionData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }

                return new NetworkManagerConnectionData();
            }
        }
    }

    public partial class ExpressRouteLinkData
    {
        public ETag? ETag => default;
    }

    public partial class FirewallPolicyRuleCollectionGroupData
    {
        public ETag? ETag => default;
    }

    public partial class HubIPConfigurationData
    {
        public ETag? ETag => default;
    }

    public partial class HubRouteTableData
    {
        public ETag? ETag => default;
    }

    public partial class IPAllocationData
    {
        public ETag? ETag => default;
    }

    public partial class InboundNatRuleData
    {
        public ETag? ETag => default;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendIPConfiguration
        {
            get => FrontendIPConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendIPConfigurationId };
            set => FrontendIPConfigurationId = value?.Id;
        }
    }

    public partial class InboundSecurityRuleData
    {
        public ETag? ETag => default;
    }

    public partial class NetworkInterfaceTapConfigurationData
    {
        public ETag? ETag => default;
    }

    public partial class NetworkWatcherData
    {
        public ETag? ETag => default;
    }

    public partial class PrivateDnsZoneGroupData
    {
        public ETag? ETag => default;
    }

    public partial class RoutingIntentData
    {
        public ETag? ETag => default;
    }

    public partial class SecurityPartnerProviderData
    {
        public ETag? ETag => default;
    }

    public partial class VirtualApplianceSiteData
    {
        public ETag? ETag => default;
    }

    public partial class VirtualHubRouteTableV2Data
    {
        public ETag? ETag => default;
    }

    [CodeGenSuppress("Endpoints")]
    [CodeGenSuppress("Outputs")]
    [CodeGenSuppress("TestConfigurations")]
    [CodeGenSuppress("TestGroups")]
    [CodeGenSuppress("ConnectionMonitorType")]
    public partial class ConnectionMonitorData
    {
        public IReadOnlyList<Models.ConnectionMonitorEndpoint> Endpoints => Properties?.Endpoints as IReadOnlyList<Models.ConnectionMonitorEndpoint>;
        public IReadOnlyList<Models.ConnectionMonitorOutput> Outputs => Properties?.Outputs as IReadOnlyList<Models.ConnectionMonitorOutput>;
        public IReadOnlyList<Models.ConnectionMonitorTestConfiguration> TestConfigurations => Properties?.TestConfigurations as IReadOnlyList<Models.ConnectionMonitorTestConfiguration>;
        public IReadOnlyList<Models.ConnectionMonitorTestGroup> TestGroups => Properties?.TestGroups as IReadOnlyList<Models.ConnectionMonitorTestGroup>;
        public Models.ConnectionMonitorType? ConnectionMonitorType => Properties?.ConnectionMonitorType is null ? default : new Models.ConnectionMonitorType(Properties.ConnectionMonitorType.Value.ToString());
    }

    [CodeGenSuppress("AvailableRuleSets")]
    public partial class ApplicationGatewayWafDynamicManifestData
    {
        public IReadOnlyList<Models.ApplicationGatewayFirewallManifestRuleSet> AvailableRuleSets => Properties?.AvailableRuleSets as IReadOnlyList<Models.ApplicationGatewayFirewallManifestRuleSet>;
    }

    [CodeGenSuppress("ExpressRouteConnections")]
    public partial class ExpressRouteGatewayData
    {
        public IReadOnlyList<ExpressRouteConnectionData> ExpressRouteConnections => Properties?.ExpressRouteConnections as IReadOnlyList<ExpressRouteConnectionData>;
    }

    [CodeGenSuppress("Filters")]
    public partial class PacketCaptureData
    {
        public IReadOnlyList<Models.PacketCaptureFilter> Filters => Properties?.Filters as IReadOnlyList<Models.PacketCaptureFilter>;
    }

    [CodeGenSuppress("PublicIPAddresses")]
    public partial class PublicIPPrefixData
    {
        public IReadOnlyList<SubResource> PublicIPAddresses => default;
    }

    [CodeGenSuppress("ApplicationGatewayForContainers")]
    public partial class WebApplicationFirewallPolicyData
    {
        public IReadOnlyList<SubResource> ApplicationGatewayForContainers => default;
    }

    [CodeGenSuppress("ServiceResources")]
    public partial class ServiceEndpointPolicyDefinitionData
    {
        public IList<ResourceIdentifier> ServiceResources { get; } = new ChangeTrackingList<ResourceIdentifier>();
    }
}

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("Locations")]
    public partial class ServiceAssociationLink
    {
        public IList<AzureLocation> Locations { get; } = new ChangeTrackingList<AzureLocation>();
    }

    [CodeGenSuppress("Sources")]
    [CodeGenSuppress("Destinations")]
    [CodeGenSuppress("SourcePortRanges")]
    [CodeGenSuppress("DestinationPortRanges")]
    public partial class ActiveSecurityAdminRule
    {
        public IReadOnlyList<AddressPrefixItem> Sources => Properties?.Sources as IReadOnlyList<AddressPrefixItem>;
        public IReadOnlyList<AddressPrefixItem> Destinations => Properties?.Destinations as IReadOnlyList<AddressPrefixItem>;
        public IReadOnlyList<string> SourcePortRanges => Properties?.SourcePortRanges as IReadOnlyList<string>;
        public IReadOnlyList<string> DestinationPortRanges => Properties?.DestinationPortRanges as IReadOnlyList<string>;
    }

    [CodeGenSuppress("Sources")]
    [CodeGenSuppress("Destinations")]
    [CodeGenSuppress("SourcePortRanges")]
    [CodeGenSuppress("DestinationPortRanges")]
    public partial class EffectiveSecurityAdminRule
    {
        public IReadOnlyList<AddressPrefixItem> Sources => Properties?.Sources as IReadOnlyList<AddressPrefixItem>;
        public IReadOnlyList<AddressPrefixItem> Destinations => Properties?.Destinations as IReadOnlyList<AddressPrefixItem>;
        public IReadOnlyList<string> SourcePortRanges => Properties?.SourcePortRanges as IReadOnlyList<string>;
        public IReadOnlyList<string> DestinationPortRanges => Properties?.DestinationPortRanges as IReadOnlyList<string>;
    }

    [CodeGenSuppress("ConfigurationPolicyGroupAssociations")]
    public partial class P2SConnectionConfiguration
    {
        public IReadOnlyList<WritableSubResource> ConfigurationPolicyGroupAssociations => Properties?.ConfigurationPolicyGroupAssociations as IReadOnlyList<WritableSubResource>;
    }

    [CodeGenSuppress("AppliesToGroups")]
    [CodeGenSuppress("Hubs")]
    public partial class EffectiveConnectivityConfiguration
    {
        public IReadOnlyList<ConnectivityGroupItem> AppliesToGroups => Properties?.AppliesToGroups as IReadOnlyList<ConnectivityGroupItem>;
        public IReadOnlyList<ConnectivityHub> Hubs => Properties?.Hubs as IReadOnlyList<ConnectivityHub>;
    }
}
