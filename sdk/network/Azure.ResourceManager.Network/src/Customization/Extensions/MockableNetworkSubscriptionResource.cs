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
// These model names also identify internal REST clients in the enclosing Network namespace.
using NetworkSecurityPerimeterServiceTagsModel = Azure.ResourceManager.Network.Models.NetworkSecurityPerimeterServiceTags;
using ServiceTagInformationModel = Azure.ResourceManager.Network.Models.ServiceTagInformation;

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

        // String-location overloads were introduced in 1.16.0; alternateType restores the generated 1.15.0 AzureLocation APIs.
        // Retain the string signatures for released API and mocking compatibility, including their input validation.
        // Explicit AzureLocation construction selects the generated overload rather than recursing into these adapters.
        /// <summary> Invokes the GetAvailableDelegationsAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableDelegationsAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AvailableDelegation> GetAvailableDelegationsAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableDelegationsAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableDelegations compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableDelegations with an AzureLocation instead.")]
        public virtual Pageable<AvailableDelegation> GetAvailableDelegations(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableDelegations(new AzureLocation(location), cancellationToken);
        }

        // Preserve the shorter 1.16.0 string API names while forwarding to the generated 1.15.0 names.
        /// <summary> Gets auto-approved private link services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Gets auto-approved private link services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesPrivateLinkServices with an AzureLocation instead.")]
        public virtual Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServices(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAutoApprovedPrivateLinkServicesPrivateLinkServices(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailablePrivateEndpointTypesAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailablePrivateEndpointTypesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailablePrivateEndpointTypes compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypes with an AzureLocation instead.")]
        public virtual Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypes(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailablePrivateEndpointTypes(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableServiceAliasesAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliasesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableServiceAliasesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableServiceAliases compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliases with an AzureLocation instead.")]
        public virtual Pageable<AvailableServiceAlias> GetAvailableServiceAliases(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableServiceAliases(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableEndpointServicesAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableEndpointServicesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<EndpointServiceResult> GetAvailableEndpointServicesAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableEndpointServicesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableEndpointServices compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableEndpointServices with an AzureLocation instead.")]
        public virtual Pageable<EndpointServiceResult> GetAvailableEndpointServices(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableEndpointServices(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetNetworkSecurityPerimeterAssociableResourceTypesAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterAssociableResourceTypesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypesAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetNetworkSecurityPerimeterAssociableResourceTypesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetNetworkSecurityPerimeterAssociableResourceTypes compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterAssociableResourceTypes with an AzureLocation instead.")]
        public virtual Pageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypes(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetNetworkSecurityPerimeterAssociableResourceTypes(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetNetworkSecurityPerimeterServiceTagsAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterServiceTagsAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<NetworkSecurityPerimeterServiceTagsModel> GetNetworkSecurityPerimeterServiceTagsAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetNetworkSecurityPerimeterServiceTagsAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetNetworkSecurityPerimeterServiceTags compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterServiceTags with an AzureLocation instead.")]
        public virtual Pageable<NetworkSecurityPerimeterServiceTagsModel> GetNetworkSecurityPerimeterServiceTags(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetNetworkSecurityPerimeterServiceTags(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetUsagesAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetUsagesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<NetworkUsage> GetUsagesAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetUsagesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetUsages compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetUsages with an AzureLocation instead.")]
        public virtual Pageable<NetworkUsage> GetUsages(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetUsages(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAllServiceTagInformationAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAllServiceTagInformationAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<ServiceTagInformationModel> GetAllServiceTagInformationAsync(string location, bool? noAddressPrefixes = default, string tagName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAllServiceTagInformationAsync(new AzureLocation(location), noAddressPrefixes, tagName, cancellationToken);
        }

        /// <summary> Invokes the GetAllServiceTagInformation compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAllServiceTagInformation with an AzureLocation instead.")]
        public virtual Pageable<ServiceTagInformationModel> GetAllServiceTagInformation(string location, bool? noAddressPrefixes = default, string tagName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAllServiceTagInformation(new AzureLocation(location), noAddressPrefixes, tagName, cancellationToken);
        }

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

        // Keep the shorter names released in 1.16.1 and 1.17 for binary compatibility.
        // Generated names again identify this metadata as application-gateway-specific.
        /// <summary> Invokes the GetAvailableRequestHeadersAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableRequestHeadersApplicationGatewaysAsync instead.")]
        public virtual AsyncPageable<string> GetAvailableRequestHeadersAsync(CancellationToken cancellationToken = default)
            => GetAvailableRequestHeadersApplicationGatewaysAsync(cancellationToken);

        /// <summary> Invokes the GetAvailableRequestHeaders compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableRequestHeadersApplicationGateways instead.")]
        public virtual Pageable<string> GetAvailableRequestHeaders(CancellationToken cancellationToken = default)
            => GetAvailableRequestHeadersApplicationGateways(cancellationToken);

        /// <summary> Invokes the GetAvailableResponseHeadersAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableResponseHeadersApplicationGatewaysAsync instead.")]
        public virtual AsyncPageable<string> GetAvailableResponseHeadersAsync(CancellationToken cancellationToken = default)
            => GetAvailableResponseHeadersApplicationGatewaysAsync(cancellationToken);

        /// <summary> Invokes the GetAvailableResponseHeaders compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableResponseHeadersApplicationGateways instead.")]
        public virtual Pageable<string> GetAvailableResponseHeaders(CancellationToken cancellationToken = default)
            => GetAvailableResponseHeadersApplicationGateways(cancellationToken);

        /// <summary> Invokes the GetAvailableServerVariablesAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableServerVariablesApplicationGatewaysAsync instead.")]
        public virtual AsyncPageable<string> GetAvailableServerVariablesAsync(CancellationToken cancellationToken = default)
            => GetAvailableServerVariablesApplicationGatewaysAsync(cancellationToken);

        /// <summary> Invokes the GetAvailableServerVariables compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableServerVariablesApplicationGateways instead.")]
        public virtual Pageable<string> GetAvailableServerVariables(CancellationToken cancellationToken = default)
            => GetAvailableServerVariablesApplicationGateways(cancellationToken);
    }
}
