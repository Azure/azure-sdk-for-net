// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkSubscriptionResource
    {
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        public virtual ArmOperation SwapPublicIPAddressesLoadBalancer(WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken)
            => SwapPublicIPAddresses(waitUntil, location, content, cancellationToken);

        // Keep the released historical names for binary compatibility.
        // The PrivateLinkService suffix is redundant; these aliases forward to the preferred shorter generated names.
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityPrivateLinkService compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibility instead.")]
        public virtual ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibility(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        // Keep the released regional facade and its virtual mocking surface.
        // The collection retains the location and uses the distinct list and singleton endpoints.
        /// <summary> Gets the regional application gateway WAF manifest collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This collection facade is deprecated and retained for backward compatibility. There is no equivalent native public listing API.")]
        public virtual ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(AzureLocation location)
            => new ApplicationGatewayWafDynamicManifestCollection(Client, Id, location);

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).Get(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(AzureLocation location, CancellationToken cancellationToken = default)
            => GetApplicationGatewayWafDynamicManifests(location).Get(cancellationToken);

        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptions compatibility operation. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().Get() instead.")]
        public virtual Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(CancellationToken cancellationToken)
        {
            var clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            using DiagnosticScope scope = clientDiagnostics.CreateScope("MockableNetworkSubscriptionResource.GetApplicationGatewayAvailableSslOptions");
            scope.Start();
            try
            {
                var restClient = new ApplicationGateways(clientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, "2026-01-01", resourceType => TryGetApiVersion(resourceType, out string apiVersion) ? apiVersion : null);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public virtual Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken)
            => SwapPublicIPAddressesAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).GetAsync(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetApplicationGatewayWafDynamicManifests(location).GetAsync(cancellationToken);

        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptionsAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().GetAsync() instead.")]
        public virtual async Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(CancellationToken cancellationToken)
        {
            var clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            using DiagnosticScope scope = clientDiagnostics.CreateScope("MockableNetworkSubscriptionResource.GetApplicationGatewayAvailableSslOptions");
            scope.Start();
            try
            {
                var restClient = new ApplicationGateways(clientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, "2026-01-01", resourceType => TryGetApiVersion(resourceType, out string apiVersion) ? apiVersion : null);
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

        // Preserve the released token-only signatures even though the generated overloads now have an optional filter.
        // A typed default filter selects the generated overloads without recursing into these adapters.
        /// <summary> Invokes the GetExpressRouteCrossConnectionsAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(CancellationToken cancellationToken)
            => GetExpressRouteCrossConnectionsAsync(default(string), cancellationToken);

        /// <summary> Invokes the GetExpressRouteCrossConnections compatibility operation. </summary>
        public virtual Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(CancellationToken cancellationToken)
            => GetExpressRouteCrossConnections(default(string), cancellationToken);

        // Keep the previously released, misleading names for binary compatibility.
        // These operations list policies across the subscription; GetServiceEndpointPolicies[Async] correctly describes that scope.
        /// <summary> Invokes the GetServiceEndpointPoliciesByServiceEndpointPolicyAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPoliciesAsync instead.")]
        public virtual AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(CancellationToken cancellationToken)
            => GetServiceEndpointPoliciesAsync(cancellationToken);

        /// <summary> Invokes the GetServiceEndpointPoliciesByServiceEndpointPolicy compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPolicies instead.")]
        public virtual Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(CancellationToken cancellationToken)
            => GetServiceEndpointPolicies(cancellationToken);
    }
}
