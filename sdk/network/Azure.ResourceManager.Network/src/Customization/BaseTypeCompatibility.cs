// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;

// These base-type declarations preserve the previous GA inheritance hierarchy during the MPG migration.
// Regeneration consumes these partial declarations and updates generated base types accordingly.
#pragma warning disable CS0108, CS0114
#pragma warning disable SA1402 // Base compatibility declarations are intentionally grouped for regeneration.
namespace Azure.ResourceManager.Network
{
    public partial class AdminRuleGroupData : ResourceData { }
    public partial class ApplicationGatewayWafDynamicManifestData : ResourceData { }
    public partial class AzureWebCategoryData : ResourceData { }
    public partial class BaseAdminRuleData : ResourceData { }
    public partial class CloudServiceSwapData : ResourceData { }
    public partial class ConnectionMonitorData : ResourceData
    {
        /// <summary> Resource tags. </summary>
        [Azure.ResourceManager.Network.WirePath("tags")]
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
    public partial class ConnectivityConfigurationData : ResourceData { }
    public partial class NetworkGroupData : ResourceData { }
    public partial class NetworkGroupStaticMemberData : ResourceData { }
    public partial class NetworkManagerRoutingConfigurationData : ResourceData { }
    public partial class NetworkManagerRoutingRuleData : ResourceData { }
    public partial class NetworkManagerRoutingRulesData : ResourceData { }
    public partial class NetworkManagerSecurityUserConfigurationData : ResourceData { }
    public partial class NetworkManagerSecurityUserRuleData : ResourceData { }
    public partial class NetworkManagerSecurityUserRulesData : ResourceData { }
    public partial class NetworkSecurityPerimeterAccessRuleData : ResourceData { }
    public partial class NetworkSecurityPerimeterAssociationData : ResourceData { }
    public partial class NetworkSecurityPerimeterLinkData : ResourceData { }
    public partial class NetworkSecurityPerimeterLinkReferenceData : ResourceData { }
    public partial class NetworkSecurityPerimeterLoggingConfigurationData : ResourceData { }
    public partial class NetworkSecurityPerimeterProfileData : ResourceData { }
    public partial class PacketCaptureData : ResourceData { }
    public partial class ReachabilityAnalysisIntentData : ResourceData { }
    public partial class ReachabilityAnalysisRunData : ResourceData { }
    public partial class RouteMapData : ResourceData { }
    public partial class ScopeConnectionData : ResourceData { }
    public partial class SecurityAdminConfigurationData : ResourceData { }
    public partial class StaticCidrData : ResourceData { }

    public partial class NetworkInterfaceIPConfigurationData : Azure.ResourceManager.Network.Models.NetworkWritableResourceData { }
    public partial class RouteData : Azure.ResourceManager.Network.Models.NetworkWritableResourceData { }
    public partial class SecurityRuleData : Azure.ResourceManager.Network.Models.NetworkWritableResourceData { }
    public partial class SubnetData : Azure.ResourceManager.Network.Models.NetworkWritableResourceData { }
    public partial class VirtualNetworkPeeringData : Azure.ResourceManager.Network.Models.NetworkWritableResourceData { }

    public partial class P2SVpnGatewayData : NetworkTrackedResourceData { }
    public partial class RouteFilterData : NetworkTrackedResourceData { }
    public partial class VirtualHubData : NetworkTrackedResourceData { }
    public partial class VpnGatewayData : NetworkTrackedResourceData { }
    public partial class VpnServerConfigurationData : NetworkTrackedResourceData { }
    public partial class VpnSiteData : NetworkTrackedResourceData { }

    public partial class DdosProtectionPlanData : TrackedResourceData { }
    public partial class ExpressRouteProviderPortData : TrackedResourceData { }
    public partial class IpamPoolData : TrackedResourceData { }
    public partial class NetworkSecurityPerimeterData : TrackedResourceData { }
    public partial class NetworkVerifierWorkspaceData : TrackedResourceData { }
    public partial class ServiceGatewayData : TrackedResourceData { }

    public partial class CloudServiceSwapCollection : IEnumerable<CloudServiceSwapResource>, IAsyncEnumerable<CloudServiceSwapResource>
    {
        IEnumerator<CloudServiceSwapResource> IEnumerable<CloudServiceSwapResource>.GetEnumerator() => ((IEnumerable<CloudServiceSwapResource>)Array.Empty<CloudServiceSwapResource>()).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Array.Empty<CloudServiceSwapResource>().GetEnumerator();
        IAsyncEnumerator<CloudServiceSwapResource> IAsyncEnumerable<CloudServiceSwapResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<CloudServiceSwapResource>();
    }

    public partial class ExpressRouteGatewayCollection : IEnumerable<ExpressRouteGatewayResource>, IAsyncEnumerable<ExpressRouteGatewayResource>
    {
        IEnumerator<ExpressRouteGatewayResource> IEnumerable<ExpressRouteGatewayResource>.GetEnumerator() => ((IEnumerable<ExpressRouteGatewayResource>)Array.Empty<ExpressRouteGatewayResource>()).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Array.Empty<ExpressRouteGatewayResource>().GetEnumerator();
        IAsyncEnumerator<ExpressRouteGatewayResource> IAsyncEnumerable<ExpressRouteGatewayResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<ExpressRouteGatewayResource>();
    }

    public partial class ExpressRouteProviderPortCollection : IEnumerable<ExpressRouteProviderPortResource>, IAsyncEnumerable<ExpressRouteProviderPortResource>
    {
        IEnumerator<ExpressRouteProviderPortResource> IEnumerable<ExpressRouteProviderPortResource>.GetEnumerator() => ((IEnumerable<ExpressRouteProviderPortResource>)Array.Empty<ExpressRouteProviderPortResource>()).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Array.Empty<ExpressRouteProviderPortResource>().GetEnumerator();
        IAsyncEnumerator<ExpressRouteProviderPortResource> IAsyncEnumerable<ExpressRouteProviderPortResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<ExpressRouteProviderPortResource>();
    }

    internal class EmptyAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        public T Current => default;
        public ValueTask DisposeAsync() => default;
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(false);
    }
}

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Common base type for writable network subresources. </summary>
    public partial class NetworkWritableResourceData : IJsonModel<NetworkWritableResourceData>, IPersistableModel<NetworkWritableResourceData>
    {
        /// <summary> Resource identifier. </summary>
        [Azure.ResourceManager.Network.WirePath("id")]
        public ResourceIdentifier Id { get; set; }
        /// <summary> Resource name. </summary>
        [Azure.ResourceManager.Network.WirePath("name")]
        public string Name { get; set; }
        /// <summary> Resource type. </summary>
        [Azure.ResourceManager.Network.WirePath("type")]
        public ResourceType? ResourceType { get; set; }

        NetworkWritableResourceData IJsonModel<NetworkWritableResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetworkWritableResourceData();
        void IJsonModel<NetworkWritableResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetworkWritableResourceData IPersistableModel<NetworkWritableResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetworkWritableResourceData();
        string IPersistableModel<NetworkWritableResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetworkWritableResourceData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }

    public partial class FirewallPacketCaptureContent : NetworkSubResource { }
    public partial class NetworkSecurityPerimeterAssociableResourceType : ResourceData { }
    public partial class TrackedResourceWithSettableIdOptionalLocation : NetworkTrackedResourceData { }

    public partial class AvailableDelegation : ResourceData { }
    public partial class AvailablePrivateEndpointType : ResourceData { }
    public partial class AvailableServiceAlias : ResourceData { }
    public partial class ServiceTagsListResult : ResourceData { }

    public partial class ApplicationGatewayAuthenticationCertificate : NetworkResourceData { }
    public partial class ApplicationGatewayBackendAddressPool : NetworkResourceData { }
    public partial class ApplicationGatewayBackendHttpSettings : NetworkResourceData { }
    public partial class ApplicationGatewayBackendSettings : NetworkResourceData { }
    public partial class ApplicationGatewayEntraJwtValidationConfig : NetworkResourceData { }
    public partial class ApplicationGatewayFrontendIPConfiguration : NetworkResourceData { }
    public partial class ApplicationGatewayFrontendPort : NetworkResourceData { }
    public partial class ApplicationGatewayHttpListener : NetworkResourceData { }
    public partial class ApplicationGatewayIPConfiguration : NetworkResourceData { }
    public partial class ApplicationGatewayListener : NetworkResourceData { }
    public partial class ApplicationGatewayLoadDistributionPolicy : NetworkResourceData { }
    public partial class ApplicationGatewayLoadDistributionTarget : NetworkResourceData { }
    public partial class ApplicationGatewayPathRule : NetworkResourceData { }
    public partial class ApplicationGatewayPrivateLinkConfiguration : NetworkResourceData { }
    public partial class ApplicationGatewayPrivateLinkIPConfiguration : NetworkResourceData { }
    public partial class ApplicationGatewayPrivateLinkResource : NetworkResourceData { }
    public partial class ApplicationGatewayProbe : NetworkResourceData { }
    public partial class ApplicationGatewayRedirectConfiguration : NetworkResourceData { }
    public partial class ApplicationGatewayRequestRoutingRule : NetworkResourceData { }
    public partial class ApplicationGatewayRewriteRuleSet : NetworkResourceData { }
    public partial class ApplicationGatewayRoutingRule : NetworkResourceData { }
    public partial class ApplicationGatewaySslCertificate : NetworkResourceData { }
    public partial class ApplicationGatewaySslPredefinedPolicy : NetworkResourceData { }
    public partial class ApplicationGatewaySslProfile : NetworkResourceData { }
    public partial class ApplicationGatewayTrustedClientCertificate : NetworkResourceData { }
    public partial class ApplicationGatewayTrustedRootCertificate : NetworkResourceData { }
    public partial class ApplicationGatewayUrlPathMap : NetworkResourceData { }
    public partial class AzureFirewallApplicationRuleCollectionData : NetworkResourceData { }
    public partial class AzureFirewallIPConfiguration : NetworkResourceData { }
    public partial class AzureFirewallNatRuleCollectionData : NetworkResourceData { }
    public partial class AzureFirewallNetworkRuleCollectionData : NetworkResourceData { }
    public partial class BastionHostIPConfiguration : NetworkResourceData { }
    public partial class ContainerNetworkInterface : NetworkResourceData { }
    public partial class ContainerNetworkInterfaceConfiguration : NetworkResourceData { }
    public partial class DdosDetectionRule : NetworkResourceData { }
    public partial class LoadBalancerInboundNatPool : NetworkResourceData { }
    public partial class NetworkIPConfiguration : NetworkResourceData { }
    public partial class NetworkIPConfigurationProfile : NetworkResourceData { }
    public partial class NetworkPrivateLinkServiceConnection : NetworkResourceData { }
    public partial class P2SConnectionConfiguration : NetworkResourceData { }
    public partial class PrivateLinkServiceIPConfiguration : NetworkResourceData { }
    public partial class ResourceNavigationLink : NetworkResourceData { }
    public partial class ServiceAssociationLink : NetworkResourceData { }
    public partial class VirtualNetworkApplianceIPConfiguration : NetworkResourceData { }
    public partial class VirtualNetworkGatewayIPConfiguration : NetworkResourceData { }
    public partial class VirtualNetworkGatewayPolicyGroup : NetworkResourceData { }
    public partial class VngClientConnectionConfiguration : NetworkResourceData { }
    public partial class VpnClientRevokedCertificate : NetworkResourceData { }
    public partial class VpnClientRootCertificate : NetworkResourceData { }

    public partial class ServiceDelegation : NetworkWritableResourceData { }
}
#pragma warning restore CS0108, CS0114
#pragma warning restore SA1402
