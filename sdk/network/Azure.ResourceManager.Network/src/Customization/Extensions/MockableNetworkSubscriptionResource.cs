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
                var restClient = new ApplicationGateways(clientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, "2025-07-01");
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
                var restClient = new ApplicationGateways(clientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, "2025-07-01");
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

        /// <summary> Invokes the GetServiceEndpointPoliciesByServiceEndpointPolicyAsync compatibility operation. </summary>
        public virtual AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(CancellationToken cancellationToken)
            => GetServiceEndpointPoliciesAsync(cancellationToken);

        /// <summary> Invokes the GetServiceEndpointPoliciesByServiceEndpointPolicy compatibility operation. </summary>
        public virtual Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(CancellationToken cancellationToken)
            => GetServiceEndpointPolicies(cancellationToken);

        /// <summary> Invokes the GetAvailableRequestHeadersApplicationGatewaysAsync compatibility operation. </summary>
        public virtual AsyncPageable<string> GetAvailableRequestHeadersApplicationGatewaysAsync(CancellationToken cancellationToken)
            => GetAvailableRequestHeadersAsync(cancellationToken);

        /// <summary> Invokes the GetAvailableRequestHeadersApplicationGateways compatibility operation. </summary>
        public virtual Pageable<string> GetAvailableRequestHeadersApplicationGateways(CancellationToken cancellationToken)
            => GetAvailableRequestHeaders(cancellationToken);

        /// <summary> Invokes the GetAvailableResponseHeadersApplicationGatewaysAsync compatibility operation. </summary>
        public virtual AsyncPageable<string> GetAvailableResponseHeadersApplicationGatewaysAsync(CancellationToken cancellationToken)
            => GetAvailableResponseHeadersAsync(cancellationToken);

        /// <summary> Invokes the GetAvailableResponseHeadersApplicationGateways compatibility operation. </summary>
        public virtual Pageable<string> GetAvailableResponseHeadersApplicationGateways(CancellationToken cancellationToken)
            => GetAvailableResponseHeaders(cancellationToken);

        /// <summary> Invokes the GetAvailableServerVariablesApplicationGatewaysAsync compatibility operation. </summary>
        public virtual AsyncPageable<string> GetAvailableServerVariablesApplicationGatewaysAsync(CancellationToken cancellationToken)
            => GetAvailableServerVariablesAsync(cancellationToken);

        /// <summary> Invokes the GetAvailableServerVariablesApplicationGateways compatibility operation. </summary>
        public virtual Pageable<string> GetAvailableServerVariablesApplicationGateways(CancellationToken cancellationToken)
            => GetAvailableServerVariables(cancellationToken);
    }
}
