// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        public static global::Azure.ResourceManager.ArmOperation SwapPublicIPAddressesLoadBalancer(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent content, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).SwapPublicIPAddressesLoadBalancer(waitUntil, location, content, cancellationToken);
        public static global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwaps(cloudServiceName);
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this global::Azure.ResourceManager.ArmClient client, global::Azure.Core.ResourceIdentifier id)
            => client.GetCachedClient(armClient => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetNetworkResource(id);
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this global::Azure.ResourceManager.ArmClient client, global::Azure.Core.ResourceIdentifier id)
            => client.GetCachedClient(armClient => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetVmNetworkResource(id);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwap(cloudServiceName, cancellationToken);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String loadBalancerName, global::System.String frontendIPConfigurationName, global::System.Threading.CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetLoadBalancer(loadBalancerName, frontendIPConfigurationName, cancellationToken);
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptions(cancellationToken);
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.String predefinedPolicyName, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicy(predefinedPolicyName, cancellationToken);
        public static global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent content, global::System.Threading.CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).SwapPublicIPAddressesLoadBalancerAsync(waitUntil, location, content, cancellationToken);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwapAsync(cloudServiceName, cancellationToken);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, global::System.String loadBalancerName, global::System.String frontendIPConfigurationName, global::System.Threading.CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetLoadBalancerAsync(loadBalancerName, frontendIPConfigurationName, cancellationToken);
        public static async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.Threading.CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptionsAsync(cancellationToken).ConfigureAwait(false);
        public static async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, global::System.String predefinedPolicyName, global::System.Threading.CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicyAsync(predefinedPolicyName, cancellationToken).ConfigureAwait(false);
    }
}
