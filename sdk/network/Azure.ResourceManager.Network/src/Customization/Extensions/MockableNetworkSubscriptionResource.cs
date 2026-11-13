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
        // Preserve the 1.15.0 subscription-scoped virtual method; native listing now lives on the SSL-options resource.
        /// <summary> Gets the predefined application gateway SSL policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(CancellationToken cancellationToken = default)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            return new AsyncPageableWrapper<ApplicationGatewaySslPredefinedPolicy, ApplicationGatewaySslPredefinedPolicy>(resource.GetAvailableSslPredefinedPoliciesAsync(cancellationToken), policy => NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(policy, Id.SubscriptionId));
        }

        // Preserve the 1.15.0 subscription method and legacy policy IDs while reusing native paging and cancellation.
        /// <summary> Gets the predefined application gateway SSL policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(CancellationToken cancellationToken = default)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            return new PageableWrapper<ApplicationGatewaySslPredefinedPolicy, ApplicationGatewaySslPredefinedPolicy>(resource.GetAvailableSslPredefinedPolicies(cancellationToken), policy => NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(policy, Id.SubscriptionId));
        }

        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use SwapPublicIPAddresses instead.")]
        public virtual ArmOperation SwapPublicIPAddressesLoadBalancer(WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken = default)
            => SwapPublicIPAddresses(waitUntil, location, content, cancellationToken);

        // Keep the released historical names for binary compatibility.
        // The PrivateLinkService suffix is redundant; these aliases forward to the preferred shorter generated names.
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityPrivateLinkService compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibility instead.")]
        public virtual ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
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

        // Native Get wraps a resource and requires a response ID; the released model also accepts ID-less SSL payloads.
        // Use the generated request and shared FromData projection without constructing that resource response wrapper.
        /// <summary> Gets the available SSL options in the released model shape. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().Get() instead.")]
        public virtual Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(CancellationToken cancellationToken = default)
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

        // The released subscription action returns a model; native policy access lives on the SSL-options resource.
        // Preserve legacy policy identifiers through the same normalization used by the retained listing adapters.
        /// <summary> Gets the specified SSL predefined policy. </summary>
        [ForwardsClientCalls]
        public virtual Response<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(string predefinedPolicyName, CancellationToken cancellationToken = default)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            var response = resource.GetSslPredefinedPolicy(predefinedPolicyName, cancellationToken);
            return Response.FromValue(NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(response.Value, Id.SubscriptionId), response.GetRawResponse());
        }

        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public virtual Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use SwapPublicIPAddressesAsync instead.")]
        public virtual Task<ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken = default)
            => SwapPublicIPAddressesAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).GetAsync(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetApplicationGatewayWafDynamicManifests(location).GetAsync(cancellationToken);

        /// <summary> Gets the available SSL options in the released model shape. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().GetAsync() instead.")]
        public virtual async Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(CancellationToken cancellationToken = default)
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

        /// <summary> Gets the specified SSL predefined policy. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(string predefinedPolicyName, CancellationToken cancellationToken = default)
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
        public virtual AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(CancellationToken cancellationToken = default)
            => GetServiceEndpointPoliciesAsync(cancellationToken);

        /// <summary> Invokes the GetServiceEndpointPoliciesByServiceEndpointPolicy compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPolicies instead.")]
        public virtual Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(CancellationToken cancellationToken = default)
            => GetServiceEndpointPolicies(cancellationToken);
    }
}
