// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkSubscriptionResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation SwapPublicIPAddressesLoadBalancer(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(global::Azure.Core.AzureLocation p0) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(global::System.Threading.CancellationToken p0)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = resource.Get(p0);
            return global::Azure.Response.FromValue(global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo.FromData(response.Value.Data), response.GetRawResponse());
        }
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(global::System.String p0, global::System.Threading.CancellationToken p1)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = resource.GetSslPredefinedPolicy(p0, p1);
            return global::Azure.Response.FromValue(global::Azure.ResourceManager.Network.NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(response.Value, Id.SubscriptionId), response.GetRawResponse());
        }
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.DnsNameAvailabilityResult> CheckDnsNameAvailability(global::Azure.Core.AzureLocation p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ServiceTagsListResult> GetServiceTag(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        [global::Azure.Core.ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(global::System.Threading.CancellationToken p0)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = await resource.GetAsync(p0).ConfigureAwait(false);
            return global::Azure.Response.FromValue(global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo.FromData(response.Value.Data), response.GetRawResponse());
        }
        [global::Azure.Core.ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(global::System.String p0, global::System.Threading.CancellationToken p1)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = await resource.GetSslPredefinedPolicyAsync(p0, p1).ConfigureAwait(false);
            return global::Azure.Response.FromValue(global::Azure.ResourceManager.Network.NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(response.Value, Id.SubscriptionId), response.GetRawResponse());
        }
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(global::Azure.Core.AzureLocation p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ServiceTagsListResult>> GetServiceTagAsync(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
    }
}
