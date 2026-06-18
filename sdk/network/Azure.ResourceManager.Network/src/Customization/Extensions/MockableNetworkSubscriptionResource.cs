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
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(global::System.Threading.CancellationToken p0)
        {
            var clientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.Network.Mocking", global::Azure.ResourceManager.Network.ProviderConstants.DefaultProviderNamespace, Diagnostics);
            using global::Azure.Core.Pipeline.DiagnosticScope scope = clientDiagnostics.CreateScope("MockableNetworkSubscriptionResource.GetApplicationGatewayAvailableSslOptions");
            scope.Start();
            try
            {
                var restClient = new global::Azure.ResourceManager.Network.ApplicationGateways(clientDiagnostics, Pipeline, Endpoint, "2025-07-01");
                global::Azure.RequestContext context = new global::Azure.RequestContext
                {
                    CancellationToken = p0
                };
                global::Azure.Core.HttpMessage message = restClient.CreateGetAvailableSslOptionsRequest(global::System.Guid.Parse(Id.SubscriptionId), context);
                global::Azure.Response response = Pipeline.ProcessMessage(message, context);
                global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoData data = global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoData.FromResponse(response);
                if (data is null)
                {
                    throw new global::Azure.RequestFailedException(response);
                }
                return global::Azure.Response.FromValue(global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo.FromData(data, Id.SubscriptionId), response);
            }
            catch (global::System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(global::Azure.Core.AzureLocation p0, global::System.Threading.CancellationToken p1) => default;
        [global::Azure.Core.ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(global::System.Threading.CancellationToken p0)
        {
            var clientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.Network.Mocking", global::Azure.ResourceManager.Network.ProviderConstants.DefaultProviderNamespace, Diagnostics);
            using global::Azure.Core.Pipeline.DiagnosticScope scope = clientDiagnostics.CreateScope("MockableNetworkSubscriptionResource.GetApplicationGatewayAvailableSslOptions");
            scope.Start();
            try
            {
                var restClient = new global::Azure.ResourceManager.Network.ApplicationGateways(clientDiagnostics, Pipeline, Endpoint, "2025-07-01");
                global::Azure.RequestContext context = new global::Azure.RequestContext
                {
                    CancellationToken = p0
                };
                global::Azure.Core.HttpMessage message = restClient.CreateGetAvailableSslOptionsRequest(global::System.Guid.Parse(Id.SubscriptionId), context);
                global::Azure.Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoData data = global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoData.FromResponse(response);
                if (data is null)
                {
                    throw new global::Azure.RequestFailedException(response);
                }
                return global::Azure.Response.FromValue(global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo.FromData(data, Id.SubscriptionId), response);
            }
            catch (global::System.Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
