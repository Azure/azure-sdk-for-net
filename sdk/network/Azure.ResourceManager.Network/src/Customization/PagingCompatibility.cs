// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayResource
    {
        public virtual AsyncPageable<ApplicationGatewayPrivateLinkResource> GetApplicationGatewayPrivateLinkResourcesAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ApplicationGatewayPrivateLinkResource> GetApplicationGatewayPrivateLinkResources(CancellationToken cancellationToken) => default;
    }

    public partial class CloudServiceSwapCollection
    {
        public virtual AsyncPageable<CloudServiceSwapResource> GetAllAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<CloudServiceSwapResource> GetAll(CancellationToken cancellationToken) => default;
    }

    public partial class ExpressRouteGatewayCollection
    {
        public virtual AsyncPageable<ExpressRouteGatewayResource> GetAllAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ExpressRouteGatewayResource> GetAll(CancellationToken cancellationToken) => default;
    }

    public partial class ExpressRouteProviderPortCollection
    {
        public virtual AsyncPageable<ExpressRouteProviderPortResource> GetAllAsync(string expand, CancellationToken cancellationToken) => default;
        public virtual Pageable<ExpressRouteProviderPortResource> GetAll(string expand, CancellationToken cancellationToken) => default;
    }

    public partial class LoadBalancerResource
    {
        public virtual AsyncPageable<NetworkInterfaceResource> GetLoadBalancerNetworkInterfacesAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<NetworkInterfaceResource> GetLoadBalancerNetworkInterfaces(CancellationToken cancellationToken) => default;
    }

    [CodeGenSuppress("GetActiveConnectivityConfigurationsAsync", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetActiveConnectivityConfigurations", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetActiveSecurityAdminRulesAsync", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetActiveSecurityAdminRules", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    public partial class NetworkManagerResource
    {
        public virtual AsyncPageable<ActiveConnectivityConfiguration> GetActiveConnectivityConfigurationsAsync(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        public virtual Pageable<ActiveConnectivityConfiguration> GetActiveConnectivityConfigurations(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        public virtual AsyncPageable<ActiveBaseSecurityAdminRule> GetActiveSecurityAdminRulesAsync(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        public virtual Pageable<ActiveBaseSecurityAdminRule> GetActiveSecurityAdminRules(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
    }

    public partial class NetworkInterfaceResource
    {
        public virtual AsyncPageable<LoadBalancerResource> GetNetworkInterfaceLoadBalancersAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<LoadBalancerResource> GetNetworkInterfaceLoadBalancers(CancellationToken cancellationToken) => default;
    }

    [CodeGenSuppress("GetResourceNavigationLinksAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetResourceNavigationLinks", typeof(CancellationToken))]
    [CodeGenSuppress("GetServiceAssociationLinksAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetServiceAssociationLinks", typeof(CancellationToken))]
    public partial class SubnetResource
    {
        public virtual AsyncPageable<ResourceNavigationLink> GetResourceNavigationLinksAsync(CancellationToken cancellationToken = default) => default;
        public virtual Pageable<ResourceNavigationLink> GetResourceNavigationLinks(CancellationToken cancellationToken = default) => default;
        public virtual AsyncPageable<ServiceAssociationLink> GetServiceAssociationLinksAsync(CancellationToken cancellationToken = default) => default;
        public virtual Pageable<ServiceAssociationLink> GetServiceAssociationLinks(CancellationToken cancellationToken = default) => default;
    }

    [CodeGenSuppress("GetNetworkManagerEffectiveConnectivityConfigurationsAsync", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkManagerEffectiveConnectivityConfigurations", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkManagerEffectiveSecurityAdminRulesAsync", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkManagerEffectiveSecurityAdminRules", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    public partial class VirtualNetworkResource
    {
        public virtual AsyncPageable<EffectiveConnectivityConfiguration> GetNetworkManagerEffectiveConnectivityConfigurationsAsync(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        public virtual Pageable<EffectiveConnectivityConfiguration> GetNetworkManagerEffectiveConnectivityConfigurations(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        public virtual AsyncPageable<EffectiveBaseSecurityAdminRule> GetNetworkManagerEffectiveSecurityAdminRulesAsync(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        public virtual Pageable<EffectiveBaseSecurityAdminRule> GetNetworkManagerEffectiveSecurityAdminRules(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
    }

    [CodeGenSuppress("GetRadiusSecretsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetRadiusSecrets", typeof(CancellationToken))]
    public partial class VirtualNetworkGatewayResource
    {
        public virtual AsyncPageable<RadiusAuthServer> GetRadiusSecretsAsync(CancellationToken cancellationToken = default) => default;
        public virtual Pageable<RadiusAuthServer> GetRadiusSecrets(CancellationToken cancellationToken = default) => default;
    }

    public partial class VirtualMachineScaleSetNetworkResource
    {
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(CancellationToken cancellationToken) => default;
    }

    public partial class VirtualMachineScaleSetVmNetworkResource
    {
        public virtual AsyncPageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken) => default;
        public virtual Pageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationData(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken) => default;
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken) => default;
    }

    [CodeGenSuppress("GetRadiusSecretsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetRadiusSecrets", typeof(CancellationToken))]
    public partial class VpnServerConfigurationResource
    {
        public virtual AsyncPageable<RadiusAuthServer> GetRadiusSecretsAsync(CancellationToken cancellationToken = default) => default;
        public virtual Pageable<RadiusAuthServer> GetRadiusSecrets(CancellationToken cancellationToken = default) => default;
    }

    public static partial class NetworkExtensions
    {
        public static AsyncPageable<ExpressRouteGatewayResource> GetExpressRouteGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static Pageable<ExpressRouteGatewayResource> GetExpressRouteGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSets(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
        public static Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken) => default;
    }
}

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkSubscriptionResource
    {
        public virtual AsyncPageable<ExpressRouteGatewayResource> GetExpressRouteGatewaysAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ExpressRouteGatewayResource> GetExpressRouteGateways(CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSetsAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSets(CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(CancellationToken cancellationToken) => default;
    }
}
