// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkSubscriptionResource
    {
        public virtual AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(CancellationToken cancellationToken)
            => GetExpressRouteCrossConnectionsAsync(default(string), cancellationToken);

        public virtual Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(CancellationToken cancellationToken)
            => GetExpressRouteCrossConnections(default(string), cancellationToken);

        public virtual AsyncPageable<AvailableDelegation> GetAvailableDelegationsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableDelegationsAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AvailableDelegation> GetAvailableDelegations(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableDelegations(location.ToString(), cancellationToken);

        public virtual AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServices(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServices(location.ToString(), cancellationToken);

        public virtual AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypes(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypes(location.ToString(), cancellationToken);

        public virtual AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AvailableServiceAlias> GetAvailableServiceAliases(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliases(location.ToString(), cancellationToken);

        public virtual AsyncPageable<EndpointServiceResult> GetAvailableEndpointServicesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableEndpointServicesAsync(location.ToString(), cancellationToken);

        public virtual Pageable<EndpointServiceResult> GetAvailableEndpointServices(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableEndpointServices(location.ToString(), cancellationToken);

        public virtual AsyncPageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterAssociableResourceTypesAsync(location.ToString(), cancellationToken);

        public virtual Pageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypes(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterAssociableResourceTypes(location.ToString(), cancellationToken);

        public virtual AsyncPageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTagsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterServiceTagsAsync(location.ToString(), cancellationToken);

        public virtual Pageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTags(AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterServiceTags(location.ToString(), cancellationToken);

        public virtual AsyncPageable<NetworkUsage> GetUsagesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetUsagesAsync(location.ToString(), cancellationToken);

        public virtual Pageable<NetworkUsage> GetUsages(AzureLocation location, CancellationToken cancellationToken)
            => GetUsages(location.ToString(), cancellationToken);

        public virtual AsyncPageable<Models.ServiceTagInformation> GetAllServiceTagInformationAsync(AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetAllServiceTagInformationAsync(location.ToString(), noAddressPrefixes, tagName, cancellationToken);

        public virtual Pageable<Models.ServiceTagInformation> GetAllServiceTagInformation(AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetAllServiceTagInformation(location.ToString(), noAddressPrefixes, tagName, cancellationToken);

        public virtual AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(CancellationToken cancellationToken)
            => GetServiceEndpointPoliciesAsync(cancellationToken);

        public virtual Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(CancellationToken cancellationToken)
            => GetServiceEndpointPolicies(cancellationToken);

        public virtual AsyncPageable<string> GetAvailableRequestHeadersApplicationGatewaysAsync(CancellationToken cancellationToken)
            => GetAvailableRequestHeadersAsync(cancellationToken);

        public virtual Pageable<string> GetAvailableRequestHeadersApplicationGateways(CancellationToken cancellationToken)
            => GetAvailableRequestHeaders(cancellationToken);

        public virtual AsyncPageable<string> GetAvailableResponseHeadersApplicationGatewaysAsync(CancellationToken cancellationToken)
            => GetAvailableResponseHeadersAsync(cancellationToken);

        public virtual Pageable<string> GetAvailableResponseHeadersApplicationGateways(CancellationToken cancellationToken)
            => GetAvailableResponseHeaders(cancellationToken);

        public virtual AsyncPageable<string> GetAvailableServerVariablesApplicationGatewaysAsync(CancellationToken cancellationToken)
            => GetAvailableServerVariablesAsync(cancellationToken);

        public virtual Pageable<string> GetAvailableServerVariablesApplicationGateways(CancellationToken cancellationToken)
            => GetAvailableServerVariables(cancellationToken);
    }
}
