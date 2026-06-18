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
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnectionsAsync(cancellationToken);

        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnections(cancellationToken);

        /// <summary> Gets available delegations. </summary>
        public static AsyncPageable<AvailableDelegation> GetAvailableDelegationsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableDelegationsAsync(location, cancellationToken);

        /// <summary> Gets available delegations. </summary>
        public static Pageable<AvailableDelegation> GetAvailableDelegations(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableDelegations(location, cancellationToken);

        /// <summary> Gets available resource group delegations. </summary>
        public static AsyncPageable<AvailableDelegation> GetAvailableResourceGroupDelegationsAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableResourceGroupDelegationsAsync(location, cancellationToken);

        /// <summary> Gets available resource group delegations. </summary>
        public static Pageable<AvailableDelegation> GetAvailableResourceGroupDelegations(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableResourceGroupDelegations(location, cancellationToken);

        /// <summary> Gets auto-approved private link services by resource group. </summary>
        public static AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync(location, cancellationToken);

        /// <summary> Gets auto-approved private link services by resource group. </summary>
        public static Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices(location, cancellationToken);

        /// <summary> Gets auto-approved private link services. </summary>
        public static AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync(location, cancellationToken);

        /// <summary> Gets auto-approved private link services. </summary>
        public static Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesPrivateLinkServices(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAutoApprovedPrivateLinkServicesPrivateLinkServices(location, cancellationToken);

        /// <summary> Gets available private endpoint types. </summary>
        public static AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailablePrivateEndpointTypesAsync(location, cancellationToken);

        /// <summary> Gets available private endpoint types. </summary>
        public static Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypes(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailablePrivateEndpointTypes(location, cancellationToken);

        /// <summary> Gets available private endpoint types by resource group. </summary>
        public static AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailablePrivateEndpointTypesByResourceGroupAsync(location, cancellationToken);

        /// <summary> Gets available private endpoint types by resource group. </summary>
        public static Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroup(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailablePrivateEndpointTypesByResourceGroup(location, cancellationToken);

        /// <summary> Gets available service aliases. </summary>
        public static AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServiceAliasesAsync(location, cancellationToken);

        /// <summary> Gets available service aliases. </summary>
        public static Pageable<AvailableServiceAlias> GetAvailableServiceAliases(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServiceAliases(location, cancellationToken);

        /// <summary> Gets available service aliases by resource group. </summary>
        public static AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableServiceAliasesByResourceGroupAsync(location, cancellationToken);

        /// <summary> Gets available service aliases by resource group. </summary>
        public static Pageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroup(this ResourceGroupResource resourceGroupResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableServiceAliasesByResourceGroup(location, cancellationToken);

        /// <summary> Gets available endpoint services. </summary>
        public static AsyncPageable<EndpointServiceResult> GetAvailableEndpointServicesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableEndpointServicesAsync(location, cancellationToken);

        /// <summary> Gets available endpoint services. </summary>
        public static Pageable<EndpointServiceResult> GetAvailableEndpointServices(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableEndpointServices(location, cancellationToken);

        /// <summary> Gets network security perimeter associable resource types. </summary>
        public static AsyncPageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterAssociableResourceTypesAsync(location, cancellationToken);

        /// <summary> Gets network security perimeter associable resource types. </summary>
        public static Pageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypes(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterAssociableResourceTypes(location, cancellationToken);

        /// <summary> Gets network security perimeter service tags. </summary>
        public static AsyncPageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTagsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterServiceTagsAsync(location, cancellationToken);

        /// <summary> Gets network security perimeter service tags. </summary>
        public static Pageable<Models.NetworkSecurityPerimeterServiceTags> GetNetworkSecurityPerimeterServiceTags(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterServiceTags(location, cancellationToken);

        /// <summary> Gets usages. </summary>
        public static AsyncPageable<NetworkUsage> GetUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetUsagesAsync(location, cancellationToken);

        /// <summary> Gets usages. </summary>
        public static Pageable<NetworkUsage> GetUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetUsages(location, cancellationToken);

        /// <summary> Gets service tag information. </summary>
        public static AsyncPageable<Models.ServiceTagInformation> GetAllServiceTagInformationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAllServiceTagInformationAsync(location, noAddressPrefixes, tagName, cancellationToken);

        /// <summary> Gets service tag information. </summary>
        public static Pageable<Models.ServiceTagInformation> GetAllServiceTagInformation(this SubscriptionResource subscriptionResource, AzureLocation location, bool? noAddressPrefixes, string tagName, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAllServiceTagInformation(location, noAddressPrefixes, tagName, cancellationToken);

        /// <summary> Gets service endpoint policies. </summary>
        public static AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(cancellationToken);

        /// <summary> Gets service endpoint policies. </summary>
        public static Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceEndpointPoliciesByServiceEndpointPolicy(cancellationToken);

        /// <summary> Gets available request headers. </summary>
        public static AsyncPageable<string> GetAvailableRequestHeadersApplicationGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableRequestHeadersApplicationGatewaysAsync(cancellationToken);

        /// <summary> Gets available request headers. </summary>
        public static Pageable<string> GetAvailableRequestHeadersApplicationGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableRequestHeadersApplicationGateways(cancellationToken);

        /// <summary> Gets available response headers. </summary>
        public static AsyncPageable<string> GetAvailableResponseHeadersApplicationGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableResponseHeadersApplicationGatewaysAsync(cancellationToken);

        /// <summary> Gets available response headers. </summary>
        public static Pageable<string> GetAvailableResponseHeadersApplicationGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableResponseHeadersApplicationGateways(cancellationToken);

        /// <summary> Gets available server variables. </summary>
        public static AsyncPageable<string> GetAvailableServerVariablesApplicationGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServerVariablesApplicationGatewaysAsync(cancellationToken);

        /// <summary> Gets available server variables. </summary>
        public static Pageable<string> GetAvailableServerVariablesApplicationGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServerVariablesApplicationGateways(cancellationToken);

        /// <summary> Checks private link service visibility by resource group. </summary>
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Checks private link service visibility by resource group. </summary>
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(waitUntil, location, content, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckPrivateLinkServiceVisibilityPrivateLinkService(waitUntil, location, content, cancellationToken);

        /// <summary> Gets the regional application gateway WAF manifest collection. </summary>
        public static ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(this SubscriptionResource subscriptionResource, AzureLocation location)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifests(location);

        /// <summary> Gets the regional application gateway WAF manifest. </summary>
        [global::Azure.Core.ForwardsClientCalls]
        public static Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifestAsync(location, cancellationToken);

        /// <summary> Gets the regional application gateway WAF manifest. </summary>
        [global::Azure.Core.ForwardsClientCalls]
        public static Response<ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifest(location, cancellationToken);

        /// <summary> Checks DNS name availability. </summary>
        public static Task<Response<DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string domainNameLabel, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckDnsNameAvailabilityAsync(location, domainNameLabel, cancellationToken);

        /// <summary> Checks DNS name availability. </summary>
        public static Response<DnsNameAvailabilityResult> CheckDnsNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, string domainNameLabel, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckDnsNameAvailability(location, domainNameLabel, cancellationToken);

        /// <summary> Gets service tags. </summary>
        public static Task<Response<ServiceTagsListResult>> GetServiceTagAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceTagAsync(location, cancellationToken);

        /// <summary> Gets service tags. </summary>
        public static Response<ServiceTagsListResult> GetServiceTag(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceTag(location, cancellationToken);
    }
}
