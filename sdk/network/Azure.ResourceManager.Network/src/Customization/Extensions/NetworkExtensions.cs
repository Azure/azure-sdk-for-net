// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        public static global::Azure.ResourceManager.ArmOperation SwapPublicIPAddressesLoadBalancer(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::Azure.WaitUntil p1, global::Azure.Core.AzureLocation p2, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p3, global::System.Threading.CancellationToken p4)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, p0.Id)).SwapPublicIPAddressesLoadBalancer(p1, p2, p3, p4);
        public static global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, p0.Id)).GetCloudServiceSwaps(p1);
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this global::Azure.ResourceManager.ArmClient p0, global::Azure.Core.ResourceIdentifier p1)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkArmClient(client, p1)).GetVirtualMachineScaleSetNetworkResource(p1);
        public static global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this global::Azure.ResourceManager.ArmClient p0, global::Azure.Core.ResourceIdentifier p1)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkArmClient(client, p1)).GetVirtualMachineScaleSetVmNetworkResource(p1);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.Threading.CancellationToken p2)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, p0.Id)).GetCloudServiceSwap(p1, p2);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.String p2, global::System.Threading.CancellationToken p3)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, p0.Id)).GetLoadBalancer(p1, p2, p3);
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.Threading.CancellationToken p1)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, p0.Id)).GetApplicationGatewayAvailableSslOptions(p1);
        public static global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.String p1, global::System.Threading.CancellationToken p2)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, p0.Id)).GetApplicationGatewaySslPredefinedPolicy(p1, p2);
        public static global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::Azure.WaitUntil p1, global::Azure.Core.AzureLocation p2, global::Azure.ResourceManager.Network.Models.LoadBalancerVipSwapContent p3, global::System.Threading.CancellationToken p4)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, p0.Id)).SwapPublicIPAddressesLoadBalancerAsync(p1, p2, p3, p4);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.Threading.CancellationToken p2)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, p0.Id)).GetCloudServiceSwapAsync(p1, p2);
        [global::Azure.Core.ForwardsClientCalls]
        public static global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(this global::Azure.ResourceManager.Resources.ResourceGroupResource p0, global::System.String p1, global::System.String p2, global::System.Threading.CancellationToken p3)
            => p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkResourceGroupResource(client, p0.Id)).GetLoadBalancerAsync(p1, p2, p3);
        public static async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.Threading.CancellationToken p1)
            => await p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, p0.Id)).GetApplicationGatewayAvailableSslOptionsAsync(p1).ConfigureAwait(false);
        public static async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this global::Azure.ResourceManager.Resources.SubscriptionResource p0, global::System.String p1, global::System.Threading.CancellationToken p2)
            => await p0.GetCachedClient(client => new global::Azure.ResourceManager.Network.Mocking.MockableNetworkSubscriptionResource(client, p0.Id)).GetApplicationGatewaySslPredefinedPolicyAsync(p1, p2).ConfigureAwait(false);
    }
}
