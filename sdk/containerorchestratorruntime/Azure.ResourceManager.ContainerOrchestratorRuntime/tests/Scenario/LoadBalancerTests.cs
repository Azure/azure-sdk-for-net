// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerOrchestratorRuntime.Models;
using Azure.ResourceManager.Kubernetes;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Tests.Tests
{
    [TestFixture]
    public class LoadBalancerTests : ContainerOrchestratorRuntimeManagementTestBase
    {
        public LoadBalancerTests() : base(true)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52801")]
        public async Task CreateLoadBalancerAsync()
        {
            var connectedCluster = ConnectedClusterResource.CreateResourceIdentifier("b9e38f20-7c9c-4497-a25d-1a0c5eef2108", "xinyuhe-canary", "test-cluster-euap-arc");
            var loadBalancerCollection = new ConnectedClusterLoadBalancerCollection(Client, connectedCluster);
            var loadBalancerData = new ConnectedClusterLoadBalancerData()
            {
                Properties = new ConnectedClusterLoadBalancerProperties(new System.Collections.Generic.List<string>(), AdvertiseMode.Arp)
            };
            loadBalancerData.Properties.Addresses.Add("192.168.10.1/32");
            var loadBalancerResource = await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testlb", loadBalancerData);
            await loadBalancerResource.Value.DeleteAsync(WaitUntil.Completed);
            var bgpPeerData = new ConnectedClusterBgpPeerData
            {
                Properties = new ConnectedClusterBgpPeerProperties
                {
                    MyAsn = 64000,
                    PeerAsn = 64001,
                    PeerAddress = "192.168.2.0"
                }
            };
            var bgpPeerCollection = new ConnectedClusterBgpPeerCollection(Client, connectedCluster);
            var bgpPeerResource = await bgpPeerCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testpeer", bgpPeerData);
            await bgpPeerResource.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
