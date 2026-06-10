// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayWafDynamicManifestCollection
    {
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetIfExists(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> Get(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetAsync(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.Threading.CancellationToken p0) => default;
    }

    public partial class ExpressRoutePortsLocationResource
    {
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource> AddTag(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource> RemoveTag(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource> SetTags(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource>> AddTagAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource>> RemoveTagAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ExpressRoutePortsLocationResource>> SetTagsAsync(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
    }

    public partial class LoadBalancerCollection
    {
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.LoadBalancerResource> GetIfExists(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> Get(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetIfExistsAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
    }

    public partial class LoadBalancerResource
    {
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> Get(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedResult> MigrateToIPBased(global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedContent p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedResult>> MigrateToIPBasedAsync(global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedContent p0, global::System.Threading.CancellationToken p1) => default;
    }

    public static partial class NetworkExtensions
    {
        public static global::Azure.ResourceManager.ArmOperation SwapPublicIPAddressesLoadBalancer(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::Azure.WaitUntil p1, global::Azure.Core.AzureLocation p2, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p3, global::System.Threading.CancellationToken p4) => default;
        public static global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1) => default;
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this global::Azure.ResourceManager.ArmClient p0, global::Azure.Core.ResourceIdentifier p1) => default;
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this global::Azure.ResourceManager.ArmClient p0, global::Azure.Core.ResourceIdentifier p1) => default;
        public static global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public static global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.String p2, global::System.Threading.CancellationToken p3) => default;
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.Threading.CancellationToken p1) => default;
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public static global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::Azure.WaitUntil p1, global::Azure.Core.AzureLocation p2, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p3, global::System.Threading.CancellationToken p4) => default;
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.String p2, global::System.Threading.CancellationToken p3) => default;
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.Threading.CancellationToken p1) => default;
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
    }

    public partial class NetworkManagerResource
    {
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatus> GetNetworkManagerDeploymentStatusAsync(global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatusContent p0, global::System.Nullable<global::System.Int32> p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatus> GetNetworkManagerDeploymentStatus(global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatusContent p0, global::System.Nullable<global::System.Int32> p1, global::System.Threading.CancellationToken p2) => default;
    }

    public partial class NetworkVirtualApplianceResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.InboundSecurityRule> CreateOrUpdateInboundSecurityRule(global::Azure.WaitUntil p0, global::System.String p1, global::Azure.ResourceManager.Network.Models.InboundSecurityRule p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.InboundSecurityRule>> CreateOrUpdateInboundSecurityRuleAsync(global::Azure.WaitUntil p0, global::System.String p1, global::Azure.ResourceManager.Network.Models.InboundSecurityRule p2, global::System.Threading.CancellationToken p3) => default;
    }

    public partial class NetworkVirtualApplianceSkuResource
    {
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> AddTag(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> RemoveTag(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource> SetTags(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> AddTagAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> RemoveTagAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkVirtualApplianceSkuResource>> SetTagsAsync(global::System.Collections.Generic.IDictionary<global::System.String, global::System.String> p0, global::System.Threading.CancellationToken p1) => default;
    }

    public partial class NetworkWatcherResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.SecurityGroupViewResult> GetVmSecurityRules(global::Azure.WaitUntil p0, global::Azure.ResourceManager.Network.Models.SecurityGroupViewContent p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.SecurityGroupViewResult>> GetVmSecurityRulesAsync(global::Azure.WaitUntil p0, global::Azure.ResourceManager.Network.Models.SecurityGroupViewContent p1, global::System.Threading.CancellationToken p2) => default;
    }

    public partial class PolicySignaturesOverridesForIdpsResource
    {
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsResource> Update(global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsData p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsResource>> UpdateAsync(global::Azure.ResourceManager.Network.PolicySignaturesOverridesForIdpsData p0, global::System.Threading.CancellationToken p1) => default;
    }

    public partial class SubnetResource
    {
    }

    public partial class VirtualHubResource
    {
    }

    public partial class VirtualMachineScaleSetVmNetworkResource
    {
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceData> GetNetworkInterfaceData(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceIPConfigurationData> GetIPConfigurationData(global::System.String p0, global::System.String p1, global::System.String p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.PublicIPAddressData> GetPublicIPAddressData(global::System.String p0, global::System.String p1, global::System.String p2, global::System.String p3, global::System.Threading.CancellationToken p4) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceData>> GetNetworkInterfaceDataAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceIPConfigurationData>> GetIPConfigurationDataAsync(global::System.String p0, global::System.String p1, global::System.String p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.PublicIPAddressData>> GetPublicIPAddressDataAsync(global::System.String p0, global::System.String p1, global::System.String p2, global::System.String p3, global::System.Threading.CancellationToken p4) => default;
    }

    public partial class VirtualNetworkGatewayResource
    {
    }

    public partial class VirtualNetworkResource
    {
    }

    public partial class VpnServerConfigurationResource
    {
    }
}

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkArmClient
    {
        public virtual global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(global::Azure.Core.ResourceIdentifier p0) => default;
        public virtual global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(global::Azure.Core.ResourceIdentifier p0) => default;
    }

    public partial class MockableNetworkResourceGroupResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(global::System.String p0) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
    }

    public partial class MockableNetworkSubscriptionResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation SwapPublicIPAddressesLoadBalancer(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(global::Azure.Core.AzureLocation p0) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(global::System.Threading.CancellationToken p0) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.DnsNameAvailabilityResult> CheckDnsNameAvailability(global::Azure.Core.AzureLocation p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ServiceTagsListResult> GetServiceTag(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(global::System.Threading.CancellationToken p0) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(global::Azure.Core.AzureLocation p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ServiceTagsListResult>> GetServiceTagAsync(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
    }
}
