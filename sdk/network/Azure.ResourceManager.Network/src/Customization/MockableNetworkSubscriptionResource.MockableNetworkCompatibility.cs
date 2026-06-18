// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkSubscriptionResource type. </summary>
    public partial class MockableNetworkSubscriptionResource
    {
        /// <summary> Invokes the GetExpressRouteCrossConnectionsAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(CancellationToken cancellationToken)
            => GetExpressRouteCrossConnectionsAsync(default(string), cancellationToken);

        /// <summary> Invokes the GetExpressRouteCrossConnections compatibility operation. </summary>
        public virtual Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(CancellationToken cancellationToken)
            => GetExpressRouteCrossConnections(default(string), cancellationToken);

        /// <summary> Invokes the GetAvailableDelegationsAsync compatibility operation. </summary>
        public virtual AsyncPageable<AvailableDelegation> GetAvailableDelegationsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableDelegationsAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableDelegations compatibility operation. </summary>
        public virtual Pageable<AvailableDelegation> GetAvailableDelegations(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableDelegations(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync compatibility operation. </summary>
        public virtual AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAutoApprovedPrivateLinkServicesPrivateLinkServices compatibility operation. </summary>
        public virtual Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServices(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServices(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailablePrivateEndpointTypesAsync compatibility operation. </summary>
        public virtual AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailablePrivateEndpointTypes compatibility operation. </summary>
        public virtual Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypes(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypes(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableServiceAliasesAsync compatibility operation. </summary>
        public virtual AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableServiceAliases compatibility operation. </summary>
        public virtual Pageable<AvailableServiceAlias> GetAvailableServiceAliases(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliases(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableEndpointServicesAsync compatibility operation. </summary>
        public virtual AsyncPageable<EndpointServiceResult> GetAvailableEndpointServicesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableEndpointServicesAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableEndpointServices compatibility operation. </summary>
        public virtual Pageable<EndpointServiceResult> GetAvailableEndpointServices(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableEndpointServices(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetNetworkSecurityPerimeterAssociableResourceTypesAsync compatibility operation. </summary>
        public virtual AsyncPageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterAssociableResourceTypesAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetNetworkSecurityPerimeterAssociableResourceTypes compatibility operation. </summary>
        public virtual Pageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypes(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterAssociableResourceTypes(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetNetworkSecurityPerimeterServiceTagsAsync compatibility operation. </summary>
        public virtual AsyncPageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTagsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterServiceTagsAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetNetworkSecurityPerimeterServiceTags compatibility operation. </summary>
        public virtual Pageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTags(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterServiceTags(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetUsagesAsync compatibility operation. </summary>
        public virtual AsyncPageable<NetworkUsage> GetUsagesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetUsagesAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetUsages compatibility operation. </summary>
        public virtual Pageable<NetworkUsage> GetUsages(AzureLocation location, CancellationToken cancellationToken)
            => GetUsages(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAllServiceTagInformationAsync compatibility operation. </summary>
        public virtual AsyncPageable<Models.ServiceTagInformation> GetAllServiceTagInformationAsync(AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetAllServiceTagInformationAsync(location.ToString(), noAddressPrefixes, tagName, cancellationToken);

        /// <summary> Invokes the GetAllServiceTagInformation compatibility operation. </summary>
        public virtual Pageable<Models.ServiceTagInformation> GetAllServiceTagInformation(AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetAllServiceTagInformation(location.ToString(), noAddressPrefixes, tagName, cancellationToken);

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
