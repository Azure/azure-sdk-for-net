// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerOrchestratorRuntime.Models;
using Azure.ResourceManager.Kubernetes;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Tests.Tests
{
    [TestFixture]
    public class LoadBalancerTests : ContainerOrchestratorRuntimeManagementTestBase
    {
        public LoadBalancerTests() : base(false)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateLoadBalancer()
        {
            var connectedCluster = ConnectedClusterResource.CreateResourceIdentifier("b9e38f20-7c9c-4497-a25d-1a0c5eef2108", "xinyuhe-canary", "test-cluster-euap-arc");
            var loadBalancerCollection = new LoadBalancerCollection(Client, connectedCluster);
            var loadBalancerData = new LoadBalancerData
            {
                AdvertiseMode = AdvertiseMode.ARP
            };
            loadBalancerData.Addresses.Add("192.168.10.1/32");
            loadBalancerCollection.CreateOrUpdate(WaitUntil.Completed, "testlb", loadBalancerData);
            var bgpPeerData = new BgpPeerData
            {
                MyAsn = 64000,
                PeerAsn = 64001,
                PeerAddress = "192.168.2.0"
            };
            var bgpPeerCollection = new BgpPeerCollection(Client, connectedCluster);
            bgpPeerCollection.CreateOrUpdate(WaitUntil.Completed, "testpeer", bgpPeerData);
        }
    }
}
