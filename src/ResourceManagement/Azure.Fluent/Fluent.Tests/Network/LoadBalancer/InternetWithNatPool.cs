// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.Network.LoadBalancer
{
    /// <summary>
    /// Internet-facing LB test with NAT pool test. 
    /// </summary>
    public class InternetWithNatPool : TestTemplate<ILoadBalancer, ILoadBalancers>
    {
        private IPublicIpAddresses pips;
        private IVirtualMachines vms;
        private INetworks networks;

        public InternetWithNatPool(
                IPublicIpAddresses pips,
                IVirtualMachines vms,
                INetworks networks)
        {
            this.pips = pips;
            this.vms = vms;
            this.networks = networks;
        }

        public override void Print(ILoadBalancer resource)
        {
            LoadBalancerHelper.PrintLB(resource);
        }

        public override ILoadBalancer CreateResource(ILoadBalancers resources)
        {
            var existingVMs = LoadBalancerHelper.EnsureVMs(this.networks, this.vms, LoadBalancerHelper.VM_IDS);
            var existingPips = LoadBalancerHelper.EnsurePIPs(pips);

            // Create a load balancer
            var lb = resources.Define(LoadBalancerHelper.LB_NAME)
                        .WithRegion(LoadBalancerHelper.REGION)
                        .WithExistingResourceGroup(LoadBalancerHelper.GROUP_NAME)

                        // Frontends
                        .WithExistingPublicIpAddress(existingPips.ElementAt(0))
                        .DefinePublicFrontend("frontend1")
                            .WithExistingPublicIpAddress(existingPips.ElementAt(1))
                            .Attach()

                        // Backends
                        .WithExistingVirtualMachines(existingVMs.ToArray())
                        .DefineBackend("backend1")
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

                        // Load balancing rules
                        .DefineLoadBalancingRule("rule1")
                            .WithProtocol(TransportProtocol.Tcp)    // Required
                            .WithFrontend("frontend1")
                            .WithFrontendPort(81)
                            .WithProbe("tcpProbe1")
                            .WithBackend("backend1")
                            .WithBackendPort(82)                    // Optionals
                            .WithIdleTimeoutInMinutes(10)
                            .WithLoadDistribution(LoadDistribution.SourceIP)
                            .Attach()

                        // Inbound NAT pools
                        .DefineInboundNatPool("natpool1")
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend("frontend1")
                            .WithFrontendPortRange(2000, 2001)
                            .WithBackendPort(8080)
                            .Attach()

                        .Create();

            // Verify frontends
            Assert.True(lb.Frontends.ContainsKey("frontend1"));
            Assert.True(lb.Frontends.ContainsKey("default"));
            Assert.True(lb.Frontends.Count == 2);

            // Verify backends
            Assert.True(lb.Backends.ContainsKey("default"));
            Assert.True(lb.Backends.ContainsKey("backend1"));
            Assert.True(lb.Backends.Count == 2);

            // Verify probes
            Assert.True(lb.HttpProbes.ContainsKey("httpProbe1"));
            Assert.True(lb.TcpProbes.ContainsKey("tcpProbe1"));
            Assert.True(!lb.HttpProbes.ContainsKey("default"));
            Assert.True(!lb.TcpProbes.ContainsKey("default"));

            // Verify rules
            Assert.True(lb.LoadBalancingRules.ContainsKey("rule1"));
            Assert.True(!lb.LoadBalancingRules.ContainsKey("default"));
            Assert.True(lb.LoadBalancingRules.Values.Count() == 1);
            var rule = lb.LoadBalancingRules["rule1"];
            Assert.True(rule.Backend.Name.Equals("backend1", StringComparison.OrdinalIgnoreCase));
            Assert.True(rule.Frontend.Name.Equals("frontend1", StringComparison.OrdinalIgnoreCase));
            Assert.True(rule.Probe.Name.Equals("tcpProbe1", StringComparison.OrdinalIgnoreCase));

            // Verify inbound NAT pools
            Assert.True(lb.InboundNatPools.ContainsKey("natpool1"));
            Assert.True(lb.InboundNatPools.Count == 1);
            var inboundNatPool = lb.InboundNatPools["natpool1"];
            Assert.True(inboundNatPool.Frontend.Name.Equals("frontend1"));
            Assert.True(inboundNatPool.FrontendPortRangeStart == 2000);
            Assert.True(inboundNatPool.FrontendPortRangeEnd == 2001);
            Assert.True(inboundNatPool.BackendPort == 8080);

            return lb;
        }
        
        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            resource = resource.Update()
                        .WithoutFrontend("default")
                        .WithoutBackend("default")
                        .WithoutLoadBalancingRule("rule1")
                        .WithoutInboundNatPool("natpool1")
                        .WithTag("tag1", "value1")
                        .WithTag("tag2", "value2")
                        .Apply();
            Assert.True(resource.Tags.ContainsKey("tag1"));

            return resource;
        }
    }
}
