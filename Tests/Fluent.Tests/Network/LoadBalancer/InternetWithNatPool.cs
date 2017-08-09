// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests.Network.LoadBalancerHelpers
{
    /// <summary>
    /// Internet-facing LB test with NAT pool test. 
    /// </summary>
    public class InternetWithNatPool : TestTemplate<ILoadBalancer, ILoadBalancers, INetworkManager>
    {
        private IPublicIPAddresses pips;
        private IComputeManager computeManager;
        private IAvailabilitySets availabilitySets;
        private INetworks networks;
        private LoadBalancerHelper loadBalancerHelper;

        public InternetWithNatPool(IComputeManager computeManager, [CallerMemberName] string methodName = "testframework_failed")
            : base(methodName)
        {
            loadBalancerHelper = new LoadBalancerHelper(TestUtilities.GenerateName(methodName));

            this.computeManager = computeManager;
        }

        public override void Print(ILoadBalancer resource)
        {
            LoadBalancerHelper.PrintLB(resource);
        }

        public override ILoadBalancer CreateResource(ILoadBalancers resources)
        {
            pips = resources.Manager.PublicIPAddresses;
            availabilitySets = computeManager.AvailabilitySets;
            networks = resources.Manager.Networks;

            var existingVMs = loadBalancerHelper.EnsureVMs(networks, computeManager, 2);
            var existingPips = loadBalancerHelper.EnsurePIPs(pips);
            IPublicIPAddress pip0 = resources.Manager.PublicIPAddresses.GetByResourceGroup(
                loadBalancerHelper.GroupName,
                loadBalancerHelper.PipNames[0]);

            // Create a load balancer
            var lb = resources.Define(loadBalancerHelper.LoadBalancerName)
                        .WithRegion(loadBalancerHelper.Region)
                        .WithExistingResourceGroup(loadBalancerHelper.GroupName)

                        // Load balancing rules
                        .DefineLoadBalancingRule("rule1")
                            .WithProtocol(TransportProtocol.Tcp)    // Required
                            .FromExistingPublicIPAddress(pip0)
                            .FromFrontendPort(81)
                            .ToBackend("backend1")
                            .ToBackendPort(82)                    // Optionals
                            .WithProbe("tcpProbe1")
                            .WithIdleTimeoutInMinutes(10)
                            .WithLoadDistribution(LoadDistribution.SourceIP)
                            .Attach()

                        // Inbound NAT pools
                        .DefineInboundNatPool("natpool1")
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromExistingPublicIPAddress(pip0)
                            .FromFrontendPortRange(2000, 2001)
                            .ToBackendPort(8080)
                            .Attach()

                        // Probes
                        .DefineTcpProbe("tcpProbe1")
                            .WithPort(25)               // Required
                            .WithIntervalInSeconds(15)  // Optionals
                            .WithNumberOfProbes(5)
                            .Attach()
                        .DefineHttpProbe("httpProbe1")
                            .WithRequestPath("/")       // Required
                            .WithIntervalInSeconds(13)  // Optionals
                            .WithNumberOfProbes(4)
                            .Attach()
                        
                        // Backends
                        .DefineBackend("backend1")
                            .WithExistingVirtualMachines(new List<IHasNetworkInterfaces>(existingVMs))
                            .Attach()

                        .Create();

            // Verify frontends
            Assert.Equal(1, lb.Frontends.Count);
            Assert.Equal(1, lb.PublicFrontends.Count);
            Assert.Equal(0, lb.PrivateFrontends.Count);
            var frontend = lb.Frontends.Values.First();
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(pip0.Id.Equals(publicFrontend.PublicIPAddressId, StringComparison.OrdinalIgnoreCase));

            // Verify backends
            Assert.Equal(1, lb.Backends.Count);

            // Verify probes
            Assert.Equal(1, lb.HttpProbes.Count);
            Assert.True(lb.HttpProbes.ContainsKey("httpProbe1"));
            Assert.Equal(1, lb.TcpProbes.Count);
            Assert.True(lb.TcpProbes.ContainsKey("tcpProbe1"));

            // Verify rules
            Assert.Equal(1, lb.LoadBalancingRules.Count);
            Assert.True(lb.LoadBalancingRules.ContainsKey("rule1"));
            var rule = lb.LoadBalancingRules["rule1"];
            Assert.NotNull(rule.Backend);
            Assert.True(rule.Probe.Name.Equals("tcpProbe1", StringComparison.OrdinalIgnoreCase));

            // Verify inbound NAT pools
            Assert.True(lb.InboundNatPools.ContainsKey("natpool1"));
            Assert.Equal(1, lb.InboundNatPools.Count);
            var inboundNatPool = lb.InboundNatPools["natpool1"];
            Assert.Equal(2000, inboundNatPool.FrontendPortRangeStart);
            Assert.Equal(2001, inboundNatPool.FrontendPortRangeEnd);
            Assert.Equal(8080, inboundNatPool.BackendPort);

            return lb;
        }
        
        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            resource = resource.Update()
                        .WithoutBackend("backend1")
                        .WithoutLoadBalancingRule("rule1")
                        .WithoutInboundNatPool("natpool1")
                        .WithoutProbe("tcpProbe1")
                        .WithoutProbe("httpProbe1")
                        .WithTag("tag1", "value1")
                        .WithTag("tag2", "value2")
                        .Apply();

            resource.Refresh();
            Assert.True(resource.Tags.ContainsKey("tag1"));

            // Verify frontends
            Assert.Equal(1, resource.Frontends.Count);
            Assert.Equal(1, resource.PublicFrontends.Count);
            Assert.Equal(0, resource.PrivateFrontends.Count);

            // Verify probes
            Assert.False(resource.HttpProbes.ContainsKey("httpProbe1"));
            Assert.False(resource.HttpProbes.ContainsKey("tcpProbe1"));
            Assert.Equal(0, resource.HttpProbes.Count);
            Assert.Equal(0, resource.TcpProbes.Count);

            // Verify backends
            Assert.Equal(0, resource.Backends.Count);

            // Verify rules
            Assert.False(resource.LoadBalancingRules.ContainsKey("rule1"));
            Assert.Equal(0, resource.LoadBalancingRules.Count);

            // Verify NAT pools
            Assert.False(resource.InboundNatPools.ContainsKey("natpool1"));

            return resource;
        }
    }
}
