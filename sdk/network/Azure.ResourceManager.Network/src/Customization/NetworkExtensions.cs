// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("GetNetworkInterfaceResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetPublicIPAddressResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class NetworkExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="NetworkInterfaceResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="NetworkInterfaceResource"/> object. </returns>
        public static NetworkInterfaceResource GetNetworkInterfaceResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableNetworkArmClient(client).GetNetworkInterfaceResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PublicIPAddressResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PublicIPAddressResource"/> object. </returns>
        public static PublicIPAddressResource GetPublicIPAddressResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableNetworkArmClient(client).GetPublicIPAddressResource(id);
        }

        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetExpressRouteCrossConnectionsAsync(subscriptionResource, default(string), cancellationToken);

        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetExpressRouteCrossConnections(subscriptionResource, default(string), cancellationToken);

        /// <summary> Gets available delegations. </summary>
        public static AsyncPageable<AvailableDelegation> GetAvailableDelegationsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableDelegationsAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available delegations. </summary>
        public static Pageable<AvailableDelegation> GetAvailableDelegations(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableDelegations(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available resource group delegations. </summary>
        public static AsyncPageable<AvailableDelegation> GetAvailableResourceGroupDelegationsAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableResourceGroupDelegationsAsync(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets available resource group delegations. </summary>
        public static Pageable<AvailableDelegation> GetAvailableResourceGroupDelegations(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableResourceGroupDelegations(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets auto-approved private link services by resource group. </summary>
        public static AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesByResourceGroupAsync(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets auto-approved private link services by resource group. </summary>
        public static Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesByResourceGroup(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets auto-approved private link services. </summary>
        public static AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets auto-approved private link services. </summary>
        public static Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServices(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServices(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available private endpoint types. </summary>
        public static AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available private endpoint types. </summary>
        public static Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypes(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypes(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available private endpoint types by resource group. </summary>
        public static AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesByResourceGroupAsync(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets available private endpoint types by resource group. </summary>
        public static Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroup(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesByResourceGroup(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets available service aliases. </summary>
        public static AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available service aliases. </summary>
        public static Pageable<AvailableServiceAlias> GetAvailableServiceAliases(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliases(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available service aliases by resource group. </summary>
        public static AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesByResourceGroupAsync(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets available service aliases by resource group. </summary>
        public static Pageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroup(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesByResourceGroup(resourceGroupResource, location.ToString(), cancellationToken);

        /// <summary> Gets available endpoint services. </summary>
        public static AsyncPageable<EndpointServiceResult> GetAvailableEndpointServicesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableEndpointServicesAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets available endpoint services. </summary>
        public static Pageable<EndpointServiceResult> GetAvailableEndpointServices(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableEndpointServices(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets network security perimeter associable resource types. </summary>
        public static AsyncPageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterAssociableResourceTypesAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets network security perimeter associable resource types. </summary>
        public static Pageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypes(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterAssociableResourceTypes(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets network security perimeter service tags. </summary>
        public static AsyncPageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTagsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterServiceTagsAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets network security perimeter service tags. </summary>
        public static Pageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTags(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetNetworkSecurityPerimeterServiceTags(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets usages. </summary>
        public static AsyncPageable<NetworkUsage> GetUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetUsagesAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets usages. </summary>
        public static Pageable<NetworkUsage> GetUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetUsages(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets service tag information. </summary>
        public static AsyncPageable<Models.ServiceTagInformation> GetAllServiceTagInformationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetAllServiceTagInformationAsync(subscriptionResource, location.ToString(), noAddressPrefixes, tagName, cancellationToken);

        /// <summary> Gets service tag information. </summary>
        public static Pageable<Models.ServiceTagInformation> GetAllServiceTagInformation(this SubscriptionResource subscriptionResource, AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetAllServiceTagInformation(subscriptionResource, location.ToString(), noAddressPrefixes, tagName, cancellationToken);

        /// <summary> Gets service endpoint policies. </summary>
        public static AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetServiceEndpointPoliciesAsync(subscriptionResource, cancellationToken);

        /// <summary> Gets service endpoint policies. </summary>
        public static Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetServiceEndpointPolicies(subscriptionResource, cancellationToken);

        /// <summary> Gets available request headers. </summary>
        public static AsyncPageable<string> GetAvailableRequestHeadersApplicationGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAvailableRequestHeadersAsync(subscriptionResource, cancellationToken);

        /// <summary> Gets available request headers. </summary>
        public static Pageable<string> GetAvailableRequestHeadersApplicationGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAvailableRequestHeaders(subscriptionResource, cancellationToken);

        /// <summary> Gets available response headers. </summary>
        public static AsyncPageable<string> GetAvailableResponseHeadersApplicationGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAvailableResponseHeadersAsync(subscriptionResource, cancellationToken);

        /// <summary> Gets available response headers. </summary>
        public static Pageable<string> GetAvailableResponseHeadersApplicationGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAvailableResponseHeaders(subscriptionResource, cancellationToken);

        /// <summary> Gets available server variables. </summary>
        public static AsyncPageable<string> GetAvailableServerVariablesApplicationGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAvailableServerVariablesAsync(subscriptionResource, cancellationToken);

        /// <summary> Gets available server variables. </summary>
        public static Pageable<string> GetAvailableServerVariablesApplicationGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAvailableServerVariables(subscriptionResource, cancellationToken);

        /// <summary> Checks private link service visibility by resource group. </summary>
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityByResourceGroupAsync(resourceGroupResource, waitUntil, location.ToString(), content, cancellationToken);

        /// <summary> Checks private link service visibility by resource group. </summary>
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityByResourceGroup(resourceGroupResource, waitUntil, location.ToString(), content, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityAsync(subscriptionResource, waitUntil, location.ToString(), content, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibility(subscriptionResource, waitUntil, location.ToString(), content, cancellationToken);

        /// <summary> Gets the regional application gateway WAF manifest collection. </summary>
        public static ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(this SubscriptionResource subscriptionResource, AzureLocation location)
            => GetApplicationGatewayWafDynamicManifests(subscriptionResource, location.ToString());

        /// <summary> Gets the regional application gateway WAF manifest. </summary>
        public static Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetApplicationGatewayWafDynamicManifestAsync(subscriptionResource, location.ToString(), "default", cancellationToken);

        /// <summary> Gets the regional application gateway WAF manifest. </summary>
        public static Response<ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetApplicationGatewayWafDynamicManifest(subscriptionResource, location.ToString(), "default", cancellationToken);

        /// <summary> Checks DNS name availability. </summary>
        public static Task<Response<DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string domainNameLabel, CancellationToken cancellationToken)
            => CheckDnsNameAvailabilityAsync(subscriptionResource, location.ToString(), domainNameLabel, cancellationToken);

        /// <summary> Checks DNS name availability. </summary>
        public static Response<DnsNameAvailabilityResult> CheckDnsNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, string domainNameLabel, CancellationToken cancellationToken)
            => CheckDnsNameAvailability(subscriptionResource, location.ToString(), domainNameLabel, cancellationToken);

        /// <summary> Gets service tags. </summary>
        public static Task<Response<ServiceTagsListResult>> GetServiceTagAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetServiceTagAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Gets service tags. </summary>
        public static Response<ServiceTagsListResult> GetServiceTag(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetServiceTag(subscriptionResource, location.ToString(), cancellationToken);
    }
}
