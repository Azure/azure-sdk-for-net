// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Mocking;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
// These model names also identify internal REST clients in the Network namespace.
using NetworkSecurityPerimeterServiceTagsModel = Azure.ResourceManager.Network.Models.NetworkSecurityPerimeterServiceTags;
using ServiceTagInformationModel = Azure.ResourceManager.Network.Models.ServiceTagInformation;

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        public static ArmOperation SwapPublicIPAddressesLoadBalancer(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).SwapPublicIPAddressesLoadBalancer(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public static CloudServiceSwapCollection GetCloudServiceSwaps(this ResourceGroupResource resourceGroupResource, string cloudServiceName)
            => resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwaps(cloudServiceName);
        /// <summary> Invokes the GetVirtualMachineScaleSetNetworkResource compatibility operation. </summary>
        public static VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this ArmClient client, ResourceIdentifier id)
            => client.GetCachedClient(armClient => new MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetNetworkResource(id);
        /// <summary> Invokes the GetVirtualMachineScaleSetVmNetworkResource compatibility operation. </summary>
        public static VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this ArmClient client, ResourceIdentifier id)
            => client.GetCachedClient(armClient => new MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetVmNetworkResource(id);
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public static Response<CloudServiceSwapResource> GetCloudServiceSwap(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwap(cloudServiceName, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptions compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().Get() instead.")]
        public static Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptions(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicy compatibility operation. </summary>
        public static Response<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this SubscriptionResource subscriptionResource, string predefinedPolicyName, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicy(predefinedPolicyName, cancellationToken);
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        public static Task<ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).SwapPublicIPAddressesLoadBalancerAsync(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwapAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public static Task<Response<CloudServiceSwapResource>> GetCloudServiceSwapAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwapAsync(cloudServiceName, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptionsAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().GetAsync() instead.")]
        public static async Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptionsAsync(cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicyAsync compatibility operation. </summary>
        public static async Task<Response<ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this SubscriptionResource subscriptionResource, string predefinedPolicyName, CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicyAsync(predefinedPolicyName, cancellationToken).ConfigureAwait(false);

        // The previous GA exposed APIs for deprecated Cloud Service networking operations. These members are retained solely to mitigate breaking changes and delegate to the mockable compatibility members.
        /// <summary> Gets a collection of network interfaces for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public static NetworkInterfaceCollection GetNetworkInterfaces(this ResourceGroupResource resourceGroupResource, string cloudServiceName, string roleInstanceName)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetNetworkInterfaces(cloudServiceName, roleInstanceName);
        }

        /// <summary> Gets a network interface for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public static Response<NetworkInterfaceResource> GetNetworkInterface(this ResourceGroupResource resourceGroupResource, string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetNetworkInterface(cloudServiceName, roleInstanceName, networkInterfaceName, expand, cancellationToken);
        }

        /// <summary> Gets a network interface for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public static Task<Response<NetworkInterfaceResource>> GetNetworkInterfaceAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetNetworkInterfaceAsync(cloudServiceName, roleInstanceName, networkInterfaceName, expand, cancellationToken);
        }

        /// <summary> Gets all network interfaces for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public static Pageable<NetworkInterfaceData> GetCloudServiceNetworkInterfaces(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceNetworkInterfaces(cloudServiceName, cancellationToken);
        }

        /// <summary> Gets all network interfaces for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public static AsyncPageable<NetworkInterfaceData> GetCloudServiceNetworkInterfacesAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceNetworkInterfacesAsync(cloudServiceName, cancellationToken);
        }

        /// <summary> Gets all public IP addresses for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service public IP address operation is deprecated and no longer supported. There is no replacement.")]
        public static Pageable<PublicIPAddressData> GetCloudServicePublicIPAddresses(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServicePublicIPAddresses(cloudServiceName, cancellationToken);
        }

        /// <summary> Gets all public IP addresses for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service public IP address operation is deprecated and no longer supported. There is no replacement.")]
        public static AsyncPageable<PublicIPAddressData> GetCloudServicePublicIPAddressesAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServicePublicIPAddressesAsync(cloudServiceName, cancellationToken);
        }

        // Preserve the released token-only signatures: adding an optional filter changes the binary signature.
        // The mockable adapters supply the default filter to the generated overloads.
        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnectionsAsync(cancellationToken);

        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnections(cancellationToken);

        // String-location overloads were introduced in 1.16.0; 1.15.0 exposed AzureLocation only.
        // TypeSpec alternateType now restores the generated AzureLocation APIs. Retain these obsolete
        // overloads for released API compatibility and dispatch through the corresponding virtual mockable methods.
        /// <summary> Gets available delegations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableDelegationsAsync with an AzureLocation instead.")]
        public static AsyncPageable<AvailableDelegation> GetAvailableDelegationsAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableDelegationsAsync(location, cancellationToken);
        }

        /// <summary> Gets available delegations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableDelegations with an AzureLocation instead.")]
        public static Pageable<AvailableDelegation> GetAvailableDelegations(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableDelegations(location, cancellationToken);
        }

        /// <summary> Gets available resource group delegations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableResourceGroupDelegationsAsync with an AzureLocation instead.")]
        public static AsyncPageable<AvailableDelegation> GetAvailableResourceGroupDelegationsAsync(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableResourceGroupDelegationsAsync(location, cancellationToken);
        }

        /// <summary> Gets available resource group delegations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableResourceGroupDelegations with an AzureLocation instead.")]
        public static Pageable<AvailableDelegation> GetAvailableResourceGroupDelegations(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableResourceGroupDelegations(location, cancellationToken);
        }

        // The 1.16.0 string APIs also shortened these names; generated AzureLocation APIs retain the 1.15.0 names.
        /// <summary> Gets auto-approved private link services by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync with an AzureLocation instead.")]
        public static AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAutoApprovedPrivateLinkServicesByResourceGroupAsync(location, cancellationToken);
        }

        /// <summary> Gets auto-approved private link services by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices with an AzureLocation instead.")]
        public static Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroup(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAutoApprovedPrivateLinkServicesByResourceGroup(location, cancellationToken);
        }

        /// <summary> Gets auto-approved private link services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesPrivateLinkServicesAsync with an AzureLocation instead.")]
        public static AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAutoApprovedPrivateLinkServicesAsync(location, cancellationToken);
        }

        /// <summary> Gets auto-approved private link services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesPrivateLinkServices with an AzureLocation instead.")]
        public static Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServices(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAutoApprovedPrivateLinkServices(location, cancellationToken);
        }

        /// <summary> Gets available private endpoint types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypesAsync with an AzureLocation instead.")]
        public static AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailablePrivateEndpointTypesAsync(location, cancellationToken);
        }

        /// <summary> Gets available private endpoint types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypes with an AzureLocation instead.")]
        public static Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypes(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailablePrivateEndpointTypes(location, cancellationToken);
        }

        /// <summary> Gets available private endpoint types by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypesByResourceGroupAsync with an AzureLocation instead.")]
        public static AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailablePrivateEndpointTypesByResourceGroupAsync(location, cancellationToken);
        }

        /// <summary> Gets available private endpoint types by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypesByResourceGroup with an AzureLocation instead.")]
        public static Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroup(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailablePrivateEndpointTypesByResourceGroup(location, cancellationToken);
        }

        /// <summary> Gets available service aliases. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliasesAsync with an AzureLocation instead.")]
        public static AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServiceAliasesAsync(location, cancellationToken);
        }

        /// <summary> Gets available service aliases. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliases with an AzureLocation instead.")]
        public static Pageable<AvailableServiceAlias> GetAvailableServiceAliases(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServiceAliases(location, cancellationToken);
        }

        /// <summary> Gets available service aliases by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliasesByResourceGroupAsync with an AzureLocation instead.")]
        public static AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableServiceAliasesByResourceGroupAsync(location, cancellationToken);
        }

        /// <summary> Gets available service aliases by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliasesByResourceGroup with an AzureLocation instead.")]
        public static Pageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroup(this ResourceGroupResource resourceGroupResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetAvailableServiceAliasesByResourceGroup(location, cancellationToken);
        }

        // Preserve the released signatures from before the optional detailLevel parameter was introduced.
        // The mockable adapters supply the default detail level to the generated overloads.
        /// <summary> Gets the specified load balancer. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<LoadBalancerResource>> GetLoadBalancerAsync(this ResourceGroupResource resourceGroupResource, string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableNetworkResourceGroupResource(resourceGroupResource).GetLoadBalancerAsync(loadBalancerName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specified load balancer. </summary>
        [ForwardsClientCalls]
        public static Response<LoadBalancerResource> GetLoadBalancer(this ResourceGroupResource resourceGroupResource, string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetLoadBalancer(loadBalancerName, expand, cancellationToken);
        }

        /// <summary> Gets available endpoint services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableEndpointServicesAsync with an AzureLocation instead.")]
        public static AsyncPageable<EndpointServiceResult> GetAvailableEndpointServicesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableEndpointServicesAsync(location, cancellationToken);
        }

        /// <summary> Gets available endpoint services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableEndpointServices with an AzureLocation instead.")]
        public static Pageable<EndpointServiceResult> GetAvailableEndpointServices(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableEndpointServices(location, cancellationToken);
        }

        /// <summary> Gets network security perimeter associable resource types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterAssociableResourceTypesAsync with an AzureLocation instead.")]
        public static AsyncPageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterAssociableResourceTypesAsync(location, cancellationToken);
        }

        /// <summary> Gets network security perimeter associable resource types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterAssociableResourceTypes with an AzureLocation instead.")]
        public static Pageable<NetworkSecurityPerimeterAssociableResourceType> GetNetworkSecurityPerimeterAssociableResourceTypes(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterAssociableResourceTypes(location, cancellationToken);
        }

        /// <summary> Gets network security perimeter service tags. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterServiceTagsAsync with an AzureLocation instead.")]
        public static AsyncPageable<NetworkSecurityPerimeterServiceTagsModel> GetNetworkSecurityPerimeterServiceTagsAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterServiceTagsAsync(location, cancellationToken);
        }

        /// <summary> Gets network security perimeter service tags. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetNetworkSecurityPerimeterServiceTags with an AzureLocation instead.")]
        public static Pageable<NetworkSecurityPerimeterServiceTagsModel> GetNetworkSecurityPerimeterServiceTags(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetNetworkSecurityPerimeterServiceTags(location, cancellationToken);
        }

        /// <summary> Gets usages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetUsagesAsync with an AzureLocation instead.")]
        public static AsyncPageable<NetworkUsage> GetUsagesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetUsagesAsync(location, cancellationToken);
        }

        /// <summary> Gets usages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetUsages with an AzureLocation instead.")]
        public static Pageable<NetworkUsage> GetUsages(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetUsages(location, cancellationToken);
        }

        /// <summary> Gets service tag information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAllServiceTagInformationAsync with an AzureLocation instead.")]
        public static AsyncPageable<ServiceTagInformationModel> GetAllServiceTagInformationAsync(this SubscriptionResource subscriptionResource, string location, bool? noAddressPrefixes = default, string tagName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAllServiceTagInformationAsync(location, noAddressPrefixes, tagName, cancellationToken);
        }

        /// <summary> Gets service tag information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAllServiceTagInformation with an AzureLocation instead.")]
        public static Pageable<ServiceTagInformationModel> GetAllServiceTagInformation(this SubscriptionResource subscriptionResource, string location, bool? noAddressPrefixes = default, string tagName = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAllServiceTagInformation(location, noAddressPrefixes, tagName, cancellationToken);
        }

        // Keep the previously released, misleading names for binary compatibility.
        // These operations list policies across the subscription; GetServiceEndpointPolicies[Async] correctly describes that scope.
        /// <summary> Gets service endpoint policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPoliciesAsync instead.")]
        public static AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(cancellationToken);

        /// <summary> Gets service endpoint policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPolicies instead.")]
        public static Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceEndpointPoliciesByServiceEndpointPolicy(cancellationToken);

        // Keep the shorter names released in 1.16.1 and 1.17 for binary compatibility.
        // Generated names again identify this metadata as application-gateway-specific; keep dispatch through the mockable aliases.
        /// <summary> Gets available request headers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableRequestHeadersApplicationGatewaysAsync instead.")]
        public static AsyncPageable<string> GetAvailableRequestHeadersAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableRequestHeadersAsync(cancellationToken);
        }

        /// <summary> Gets available request headers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableRequestHeadersApplicationGateways instead.")]
        public static Pageable<string> GetAvailableRequestHeaders(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableRequestHeaders(cancellationToken);
        }

        /// <summary> Gets available response headers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableResponseHeadersApplicationGatewaysAsync instead.")]
        public static AsyncPageable<string> GetAvailableResponseHeadersAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableResponseHeadersAsync(cancellationToken);
        }

        /// <summary> Gets available response headers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableResponseHeadersApplicationGateways instead.")]
        public static Pageable<string> GetAvailableResponseHeaders(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableResponseHeaders(cancellationToken);
        }

        /// <summary> Gets available server variables. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableServerVariablesApplicationGatewaysAsync instead.")]
        public static AsyncPageable<string> GetAvailableServerVariablesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServerVariablesAsync(cancellationToken);
        }

        /// <summary> Gets available server variables. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetAvailableServerVariablesApplicationGateways instead.")]
        public static Pageable<string> GetAvailableServerVariables(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAvailableServerVariables(cancellationToken);
        }

        // Keep the released historical names for binary compatibility.
        // The PrivateLinkService suffix repeats what is already in the name; prefer the shorter generated names for the same operations.
        /// <summary> Checks private link service visibility by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityByResourceGroupAsync instead.")]
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Checks private link service visibility by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityByResourceGroup instead.")]
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(waitUntil, location, content, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibility instead.")]
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest content, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckPrivateLinkServiceVisibilityPrivateLinkService(waitUntil, location, content, cancellationToken);

        // Preserve the released regional facade; native subscription access does not retain a location.
        // The collection still performs true listing, for which no equivalent native public API exists.
        /// <summary> Gets the regional application gateway WAF manifest collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This collection facade is deprecated and retained for backward compatibility. There is no equivalent native public listing API.")]
        public static ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifests(location);
        }

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).GetAsync(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public static Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifestAsync(location, cancellationToken);
        }

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).Get(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public static Response<ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifest(location, cancellationToken);
        }
    }
}
