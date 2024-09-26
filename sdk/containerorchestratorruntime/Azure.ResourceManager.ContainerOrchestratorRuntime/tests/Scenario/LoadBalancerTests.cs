// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerOrchestratorRuntime.Mocking;
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
        public async Task CreateLoadBalancerAsync()
        {
            var connectedCluster = ConnectedClusterResource.CreateResourceIdentifier("b9e38f20-7c9c-4497-a25d-1a0c5eef2108", "xinyuhe-canary", "test-cluster-euap-arc");
            var loadBalancerCollection = new ConnectedClusterLoadBalancerCollection(Client, connectedCluster);
            var loadBalancerData = new ConnectedClusterLoadBalancerData
            {
                AdvertiseMode = AdvertiseMode.Arp
            };
            loadBalancerData.Addresses.Add("192.168.10.1/32");
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testlb", loadBalancerData);
            var bgpPeerData = new ConnectedClusterBgpPeerData
            {
                MyAsn = 64000,
                PeerAsn = 64001,
                PeerAddress = "192.168.2.0"
            };
            var bgpPeerCollection = new ConnectedClusterBgpPeerCollection(Client, connectedCluster);
            await bgpPeerCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testpeer", bgpPeerData);
        }
    }
}
