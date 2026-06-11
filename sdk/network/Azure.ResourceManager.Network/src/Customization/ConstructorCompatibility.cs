// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591
#pragma warning disable SA1402

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class BaseAdminRuleData
    {
        public BaseAdminRuleData()
        {
        }
    }

    public partial class DdosProtectionPlanData
    {
        public DdosProtectionPlanData(AzureLocation location) : base(location)
        {
        }
    }

    [CodeGenSuppress("ExpressRoutePortsLocationData")]
    public partial class ExpressRoutePortsLocationData
    {
        public ExpressRoutePortsLocationData()
        {
        }
    }

    public partial class ExpressRouteProviderPortData
    {
        public ExpressRouteProviderPortData(AzureLocation location)
        {
            Location = location;
        }
    }

    public partial class IpamPoolData
    {
        public IpamPoolData(AzureLocation location, IpamPoolProperties properties) : this(properties)
        {
            Location = location;
        }
    }

    public partial class NetworkSecurityPerimeterData
    {
        public NetworkSecurityPerimeterData(AzureLocation location) : base(location)
        {
        }
    }

    [CodeGenSuppress("NetworkSecurityPerimeterLinkReferenceData")]
    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
        public NetworkSecurityPerimeterLinkReferenceData()
        {
        }
    }

    public partial class NetworkVerifierWorkspaceData
    {
        public NetworkVerifierWorkspaceData(AzureLocation location) : this()
        {
            Location = location;
        }
    }

    [CodeGenSuppress("NetworkVirtualApplianceSkuData")]
    public partial class NetworkVirtualApplianceSkuData
    {
        public NetworkVirtualApplianceSkuData()
        {
        }
    }

    [CodeGenSuppress("PeerExpressRouteCircuitConnectionData")]
    public partial class PeerExpressRouteCircuitConnectionData
    {
        public PeerExpressRouteCircuitConnectionData()
        {
        }
    }

    public partial class ServiceGatewayData
    {
        public ServiceGatewayData(AzureLocation location) : this()
        {
            Location = location;
        }
    }
}

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("ActiveBaseSecurityAdminRule")]
    public abstract partial class ActiveBaseSecurityAdminRule
    {
        protected ActiveBaseSecurityAdminRule()
        {
        }
    }

    [CodeGenSuppress("EffectiveBaseSecurityAdminRule")]
    public abstract partial class EffectiveBaseSecurityAdminRule
    {
        protected EffectiveBaseSecurityAdminRule()
        {
        }
    }

    [CodeGenSuppress("FirewallPolicyRule")]
    public abstract partial class FirewallPolicyRule
    {
        protected FirewallPolicyRule()
        {
        }
    }

    [CodeGenSuppress("FirewallPolicyRuleCollectionInfo")]
    public abstract partial class FirewallPolicyRuleCollectionInfo
    {
        protected FirewallPolicyRuleCollectionInfo()
        {
        }
    }

    [CodeGenSuppress("ApplicationGatewayFirewallRule", typeof(int))]
    public partial class ApplicationGatewayFirewallRule
    {
        public ApplicationGatewayFirewallRule(int ruleId)
        {
            RuleId = ruleId;
        }
    }

    [CodeGenSuppress("ApplicationGatewayFirewallRuleGroup")]
    public partial class ApplicationGatewayFirewallRuleGroup
    {
        public ApplicationGatewayFirewallRuleGroup(string ruleGroupName, System.Collections.Generic.IEnumerable<ApplicationGatewayFirewallRule> rules)
        {
            RuleGroupName = ruleGroupName;
            foreach (var rule in rules ?? System.Linq.Enumerable.Empty<ApplicationGatewayFirewallRule>())
            {
                Rules.Add(rule);
            }
        }
    }

    [CodeGenSuppress("ApplicationGatewayFirewallRuleSet")]
    public partial class ApplicationGatewayFirewallRuleSet
    {
        public ApplicationGatewayFirewallRuleSet()
        {
        }
    }

    [CodeGenSuppress("ApplicationGatewayPrivateLinkResource")]
    public partial class ApplicationGatewayPrivateLinkResource
    {
        public ApplicationGatewayPrivateLinkResource()
        {
        }
    }

    [CodeGenSuppress("ApplicationGatewaySslPredefinedPolicy")]
    public partial class ApplicationGatewaySslPredefinedPolicy
    {
        public ApplicationGatewaySslPredefinedPolicy()
        {
        }
    }

    [CodeGenSuppress("AzureFirewallFqdnTag")]
    public partial class AzureFirewallFqdnTag
    {
        public AzureFirewallFqdnTag()
        {
        }
    }

    [CodeGenSuppress("BgpCommunity")]
    public partial class BgpCommunity
    {
        public BgpCommunity()
        {
        }
    }

    [CodeGenSuppress("BgpServiceCommunity")]
    public partial class BgpServiceCommunity
    {
        public BgpServiceCommunity()
        {
        }
    }

    [CodeGenSuppress("ContainerNetworkInterface")]
    public partial class ContainerNetworkInterface
    {
        public ContainerNetworkInterface()
        {
        }
    }

    [CodeGenSuppress("ExpressRoutePortsLocationBandwidths")]
    public partial class ExpressRoutePortsLocationBandwidths
    {
        public ExpressRoutePortsLocationBandwidths()
        {
        }
    }

    [CodeGenSuppress("ExpressRouteServiceProvider")]
    public partial class ExpressRouteServiceProvider
    {
        public ExpressRouteServiceProvider()
        {
        }
    }

    [CodeGenSuppress("ExpressRouteServiceProviderBandwidthsOffered")]
    public partial class ExpressRouteServiceProviderBandwidthsOffered
    {
        public ExpressRouteServiceProviderBandwidthsOffered()
        {
        }
    }

    [CodeGenSuppress("FlowLogProperties")]
    public partial class FlowLogProperties
    {
        public FlowLogProperties()
        {
        }
    }

    [CodeGenSuppress("NetworkIPConfiguration")]
    public partial class NetworkIPConfiguration
    {
        public NetworkIPConfiguration()
        {
        }
    }

    [CodeGenSuppress("NetworkVirtualApplianceSkuInstances")]
    public partial class NetworkVirtualApplianceSkuInstances
    {
        public NetworkVirtualApplianceSkuInstances()
        {
        }
    }

    [CodeGenSuppress("ResourceNavigationLink")]
    public partial class ResourceNavigationLink
    {
        public ResourceNavigationLink()
        {
        }
    }

    [CodeGenSuppress("ServiceAssociationLink")]
    public partial class ServiceAssociationLink
    {
        public ServiceAssociationLink()
        {
        }
    }

    public partial class TroubleshootingContent
    {
        public TroubleshootingContent(ResourceIdentifier targetResourceId, ResourceIdentifier storageId, System.Uri storagePath) : this(targetResourceId, storageId, storagePath?.AbsoluteUri)
        {
        }
    }

    [CodeGenSuppress("VirtualNetworkApplianceIPConfiguration")]
    public partial class VirtualNetworkApplianceIPConfiguration
    {
        public VirtualNetworkApplianceIPConfiguration()
        {
        }
    }

    [CodeGenSuppress("VirtualNetworkGatewayConnectionListEntity", typeof(WritableSubResource), typeof(VirtualNetworkGatewayConnectionType))]
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        public VirtualNetworkGatewayConnectionListEntity(WritableSubResource localNetworkGateway2, VirtualNetworkGatewayConnectionType connectionType)
            : this(new VirtualNetworkGatewayConnectionListEntityPropertiesFormat(
                null,
                null,
                null,
                new VirtualNetworkConnectionGatewayReference(localNetworkGateway2?.Id),
                connectionType,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null))
        {
        }
    }
}

#pragma warning restore SA1402
#pragma warning restore CS1591
