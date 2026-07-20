// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkSubscriptionResource type. </summary>
    public partial class MockableNetworkSubscriptionResource
    {
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        public virtual ArmOperation SwapPublicIPAddressesLoadBalancer(WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken)
            => SwapPublicIpAddresses(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityPrivateLinkService compatibility operation. </summary>
        public virtual ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibility(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayWafDynamicManifests compatibility operation. </summary>
        public virtual ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(AzureLocation location)
            => new ApplicationGatewayWafDynamicManifestCollection(Client, Id, location);
        /// <summary> Invokes the GetApplicationGatewayWafDynamicManifest compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(AzureLocation location, CancellationToken cancellationToken)
            => GetApplicationGatewayWafDynamicManifests(location).Get(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptions compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(CancellationToken cancellationToken)
        {
            var clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            using DiagnosticScope scope = clientDiagnostics.CreateScope("MockableNetworkSubscriptionResource.GetApplicationGatewayAvailableSslOptions");
            scope.Start();
            try
            {
                var restClient = new ApplicationGateways(clientDiagnostics, Pipeline, Endpoint, "2025-07-01");
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = restClient.CreateGetAvailableSslOptionsRequest(Guid.Parse(Id.SubscriptionId), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ApplicationGatewayAvailableSslOptionsInfoData data = ApplicationGatewayAvailableSslOptionsInfoData.FromResponse(response);
                if (data is null)
                {
                    throw new RequestFailedException(response);
                }
                return Response.FromValue(ApplicationGatewayAvailableSslOptionsInfo.FromData(data, Id.SubscriptionId), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicy compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(string predefinedPolicyName, CancellationToken cancellationToken)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = resource.GetSslPredefinedPolicy(predefinedPolicyName, cancellationToken);
            return Response.FromValue(NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(response.Value, Id.SubscriptionId), response.GetRawResponse());
        }
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken)
            => SwapPublicIpAddressesAsync(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayWafDynamicManifestAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetApplicationGatewayWafDynamicManifests(location).GetAsync(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptionsAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(CancellationToken cancellationToken)
        {
            var clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            using DiagnosticScope scope = clientDiagnostics.CreateScope("MockableNetworkSubscriptionResource.GetApplicationGatewayAvailableSslOptions");
            scope.Start();
            try
            {
                var restClient = new ApplicationGateways(clientDiagnostics, Pipeline, Endpoint, "2025-07-01");
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = restClient.CreateGetAvailableSslOptionsRequest(Guid.Parse(Id.SubscriptionId), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ApplicationGatewayAvailableSslOptionsInfoData data = ApplicationGatewayAvailableSslOptionsInfoData.FromResponse(response);
                if (data is null)
                {
                    throw new RequestFailedException(response);
                }
                return Response.FromValue(ApplicationGatewayAvailableSslOptionsInfo.FromData(data, Id.SubscriptionId), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicyAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(string predefinedPolicyName, CancellationToken cancellationToken)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = await resource.GetSslPredefinedPolicyAsync(predefinedPolicyName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(response.Value, Id.SubscriptionId), response.GetRawResponse());
        }
    }
}
