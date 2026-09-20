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

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkExtensions type. </summary>
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
    }
}
