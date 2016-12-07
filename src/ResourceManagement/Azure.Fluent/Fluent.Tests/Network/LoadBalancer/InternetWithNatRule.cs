// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Linq;
using Xunit;

namespace Azure.Tests.Network.LoadBalancer
{
    /// <summary>
    /// Internet-facing LB test with NAT rules.
    /// </summary>
    public class InternetWithNatRule : TestTemplate<ILoadBalancer, ILoadBalancers>
    {
        private IPublicIpAddresses pips;
        private IVirtualMachines vms;
        private INetworks networks;

        public InternetWithNatRule(
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
            Assert.Equal(2, existingVMs.Count());
            var existingPips = LoadBalancerHelper.EnsurePIPs(pips);
            var nic1 = existingVMs.ElementAt(0).GetPrimaryNetworkInterface();
            var nic2 = existingVMs.ElementAt(1).GetPrimaryNetworkInterface();

            // Create a load balancer
            var lb = resources.Define(LoadBalancerHelper.LB_NAME)
                        .WithRegion(LoadBalancerHelper.REGION)
                        .WithExistingResourceGroup(LoadBalancerHelper.GROUP_NAME)

                        // Frontends
                        .DefinePublicFrontend("frontend1")
                            .WithExistingPublicIpAddress(existingPips.ElementAt(0))
                            .Attach()

                        // Backends
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

                        // Inbound NAT rules
                        .DefineInboundNatRule("natrule1")
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend("frontend1")
                            .WithFrontendPort(88)
                            .Attach()
                        .Create();

            // Connect NICs explicitly
            nic1.Update()
                .WithExistingLoadBalancerBackend(lb, "backend1")
                .WithExistingLoadBalancerInboundNatRule(lb, "natrule1")
                .Apply();
            NetworkInterfaceHelper.PrintNic(nic1);
            Assert.True(nic1.PrimaryIpConfiguration.ListAssociatedLoadBalancerBackends().ElementAt(0)
                            .Name.Equals("backend1", StringComparison.OrdinalIgnoreCase));
            Assert.True(nic1.PrimaryIpConfiguration.ListAssociatedLoadBalancerInboundNatRules().ElementAt(0)
                            .Name.Equals("natrule1", StringComparison.OrdinalIgnoreCase));

            nic2.Update()
                .WithExistingLoadBalancerBackend(lb, "backend1")
                .Apply();
            NetworkInterfaceHelper.PrintNic(nic2);
            Assert.True(nic2.PrimaryIpConfiguration.ListAssociatedLoadBalancerBackends().ElementAt(0)
                            .Name.Equals("backend1", StringComparison.OrdinalIgnoreCase));

            // Verify frontends
            Assert.True(lb.Frontends.ContainsKey("frontend1"));
            Assert.True(lb.Frontends.Count == 1);

            existingPips.ElementAt(0).Refresh();
            Assert.True(existingPips.ElementAt(0).GetAssignedLoadBalancerFrontend()
                                    .Name.Equals("frontend1", StringComparison.OrdinalIgnoreCase));
            PublicIpAddressHelper.PrintPIP(existingPips.ElementAt(0).Refresh());

            // Verify backends
            Assert.True(lb.Backends.ContainsKey("backend1"));
            Assert.True(lb.Backends.Count == 1);

            // Verify probes
            Assert.True(lb.HttpProbes.ContainsKey("httpProbe1"));
            Assert.True(lb.TcpProbes.ContainsKey("tcpProbe1"));
            Assert.True(!lb.HttpProbes.ContainsKey("default"));
            Assert.True(!lb.TcpProbes.ContainsKey("default"));

            // Verify rules
            Assert.True(lb.LoadBalancingRules.ContainsKey("rule1"));
            Assert.True(!lb.LoadBalancingRules.ContainsKey("default"));
            Assert.True(lb.LoadBalancingRules.Values.Count == 1);
            var rule = lb.LoadBalancingRules["rule1"];
            Assert.True(rule.Backend.Name.Equals("backend1", StringComparison.OrdinalIgnoreCase));
            Assert.True(rule.Frontend.Name.Equals("frontend1", StringComparison.OrdinalIgnoreCase));
            Assert.True(rule.Probe.Name.Equals("tcpProbe1", StringComparison.OrdinalIgnoreCase));

            // Verify inbound NAT rules
            Assert.True(lb.InboundNatRules.ContainsKey("natrule1"));
            Assert.True(lb.InboundNatRules.Count == 1);
            var inboundNatRule = lb.InboundNatRules["natrule1"];
            Assert.True(inboundNatRule.Frontend.Name.Equals("frontend1", StringComparison.OrdinalIgnoreCase));
            Assert.True(inboundNatRule.FrontendPort == 88);
            Assert.True(inboundNatRule.BackendPort == 88);

            return lb;
        }

        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            var existingVMs = LoadBalancerHelper.EnsureVMs(this.networks, this.vms, LoadBalancerHelper.VM_IDS);
            Assert.Equal(2, existingVMs.Count());
            var nic1 = existingVMs.ElementAt(0).GetPrimaryNetworkInterface();
            var nic2 = existingVMs.ElementAt(1).GetPrimaryNetworkInterface();

            // Remove the NIC associations
            nic1.Update()
                .WithoutLoadBalancerBackends()
                .WithoutLoadBalancerInboundNatRules()
                .Apply();
            Assert.True(nic1.PrimaryIpConfiguration.ListAssociatedLoadBalancerBackends().Count == 0);

            nic2.Update()
                    .WithoutLoadBalancerBackends()
                    .WithoutLoadBalancerInboundNatRules()
                    .Apply();
            Assert.True(nic2.PrimaryIpConfiguration.ListAssociatedLoadBalancerBackends().Count == 0);

            // Update the load balancer
            var existingPips = LoadBalancerHelper.EnsurePIPs(pips);
            resource = resource.Update()
                        .UpdateInternetFrontend("frontend1")
                            .WithExistingPublicIpAddress(existingPips.ElementAt(1))
                            .Parent()
                        .WithoutFrontend("default")
                        .WithoutBackend("default")
                        .WithoutLoadBalancingRule("rule1")
                        .WithoutInboundNatRule("natrule1")
                        .WithTag("tag1", "value1")
                        .WithTag("tag2", "value2")
                        .Apply();
            Assert.True(resource.Tags.ContainsKey("tag1"));

            return resource;
        }
    }
}
