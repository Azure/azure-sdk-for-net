// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkExtensions type. </summary>
    public static partial class NetworkExtensions
    {
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        public static global::Azure.ResourceManager.ArmOperation SwapPublicIPAddressesLoadBalancer(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent content, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).SwapPublicIPAddressesLoadBalancer(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public static global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwaps(cloudServiceName);
        /// <summary> Invokes the GetVirtualMachineScaleSetNetworkResource compatibility operation. </summary>
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this global::Azure.ResourceManager.ArmClient client, global::Azure.Core.ResourceIdentifier id)
            => client.GetCachedClient(armClient => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetNetworkResource(id);
        /// <summary> Invokes the GetVirtualMachineScaleSetVmNetworkResource compatibility operation. </summary>
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this global::Azure.ResourceManager.ArmClient client, global::Azure.Core.ResourceIdentifier id)
            => client.GetCachedClient(armClient => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetVmNetworkResource(id);
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public static global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwap(cloudServiceName, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptions compatibility operation. </summary>
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptions(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicy compatibility operation. </summary>
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.String predefinedPolicyName, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicy(predefinedPolicyName, cancellationToken);
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        public static global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent content, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).SwapPublicIPAddressesLoadBalancerAsync(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwapAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwapAsync(cloudServiceName, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptionsAsync compatibility operation. </summary>
        public static async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.Threading.CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptionsAsync(cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicyAsync compatibility operation. </summary>
        public static async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.String predefinedPolicyName, global::System.Threading.CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicyAsync(predefinedPolicyName, cancellationToken).ConfigureAwait(false);

        /// <summary> Gets the deprecated Cloud Services network interfaces. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.NetworkInterfaceData> GetCloudServiceNetworkInterfacesAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new global::System.NotSupportedException("Cloud Services network interface operations are no longer supported.");

        /// <summary> Gets the deprecated Cloud Services network interfaces. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::Azure.Pageable<global::Azure.ResourceManager.Network.NetworkInterfaceData> GetCloudServiceNetworkInterfaces(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new global::System.NotSupportedException("Cloud Services network interface operations are no longer supported.");

        /// <summary> Gets the deprecated Cloud Services public IP addresses. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.PublicIPAddressData> GetCloudServicePublicIPAddressesAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new global::System.NotSupportedException("Cloud Services public IP address operations are no longer supported.");

        /// <summary> Gets the deprecated Cloud Services public IP addresses. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::Azure.Pageable<global::Azure.ResourceManager.Network.PublicIPAddressData> GetCloudServicePublicIPAddresses(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new global::System.NotSupportedException("Cloud Services public IP address operations are no longer supported.");

        /// <summary> Gets the deprecated Cloud Services role instance network interface collection. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::Azure.ResourceManager.Network.NetworkInterfaceCollection GetNetworkInterfaces(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.String roleInstanceName)
            => throw new global::System.NotSupportedException("Cloud Services role instance network interface operations are no longer supported.");

        /// <summary> Gets a deprecated Cloud Services role instance network interface. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceResource>> GetNetworkInterfaceAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.String roleInstanceName, global::System.String networkInterfaceName, global::System.String expand, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new global::System.NotSupportedException("Cloud Services role instance network interface operations are no longer supported.");

        /// <summary> Gets a deprecated Cloud Services role instance network interface. </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Obsolete("This method is deprecated and is no longer supported by the service.")]
        public static global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceResource> GetNetworkInterface(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.String roleInstanceName, global::System.String networkInterfaceName, global::System.String expand, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new global::System.NotSupportedException("Cloud Services role instance network interface operations are no longer supported.");
    }
}
