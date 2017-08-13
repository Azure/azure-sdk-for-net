// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Fluent.Tests.Network.LoadBalancerHelpers
{
    /// <summary>
    /// Internet-facing LB test with NAT rules.
    /// </summary>
    public class InternetWithNatRule : TestTemplate<ILoadBalancer, ILoadBalancers, INetworkManager>
    {
        private IPublicIPAddresses pips;
        private IComputeManager computeManager;
        private IAvailabilitySets availabilitySets;
        private INetworks networks;
        private LoadBalancerHelper loadBalancerHelper;

        public InternetWithNatRule(
                IComputeManager computeManager,
                [CallerMemberName] string methodName = "testframework_failed")
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
            networks = resources.Manager.Networks;
            availabilitySets = computeManager.AvailabilitySets;
            var existingVMs = loadBalancerHelper.EnsureVMs(networks, computeManager, 2);
            Assert.Equal(2, existingVMs.Count());
            var existingPips = loadBalancerHelper.EnsurePIPs(pips);
            var nic1 = existingVMs.ElementAt(0).GetPrimaryNetworkInterface();
            var nic2 = existingVMs.ElementAt(1).GetPrimaryNetworkInterface();
            IPublicIPAddress pip = resources.Manager.PublicIPAddresses.GetByResourceGroup(
                loadBalancerHelper.GroupName,
                loadBalancerHelper.PipNames[0]);

            // Create a load balancer
            var lb = resources.Define(loadBalancerHelper.LoadBalancerName)
                        .WithRegion(loadBalancerHelper.Region)
                        .WithExistingResourceGroup(loadBalancerHelper.GroupName)

                        // Load balancing rules
                        .DefineLoadBalancingRule("rule1")
                            .WithProtocol(TransportProtocol.Tcp)    // Required
                            .FromExistingPublicIPAddress(pip)
                            .FromFrontendPort(81)
                            .ToBackend("backend1")
                            .ToBackendPort(82)                    // Optionals
                            .WithProbe("tcpProbe1")
                            .WithIdleTimeoutInMinutes(10)
                            .WithLoadDistribution(LoadDistribution.SourceIP)
                            .Attach()

                        // Inbound NAT rules
                        .DefineInboundNatRule("natrule1")
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromExistingPublicIPAddress(pip) // Implicitly uses the same frontend because the PIP is the same
                            .FromFrontendPort(88)
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

                        .Create();

            string backendName = lb.Backends.Values.First().Name;
            string frontendName = lb.Frontends.Values.First().Name;

            // Connect NICs explicitly
            nic1.Update()
                .WithExistingLoadBalancerBackend(lb, backendName)
                .WithExistingLoadBalancerInboundNatRule(lb, "natrule1")
                .Apply();
            NetworkInterfaceHelper.PrintNic(nic1);
            Assert.True(nic1.PrimaryIPConfiguration.ListAssociatedLoadBalancerBackends().ElementAt(0)
                            .Name.Equals(backendName, StringComparison.OrdinalIgnoreCase));
            Assert.True(nic1.PrimaryIPConfiguration.ListAssociatedLoadBalancerInboundNatRules().ElementAt(0)
                            .Name.Equals("natrule1", StringComparison.OrdinalIgnoreCase));

            nic2.Update()
                .WithExistingLoadBalancerBackend(lb, backendName)
                .Apply();
            NetworkInterfaceHelper.PrintNic(nic2);
            Assert.True(nic2.PrimaryIPConfiguration.ListAssociatedLoadBalancerBackends().ElementAt(0)
                            .Name.Equals(backendName, StringComparison.OrdinalIgnoreCase));

            // Verify frontends
            Assert.Equal(1, lb.Frontends.Count);
            Assert.Equal(1, lb.PublicFrontends.Count);
            Assert.Equal(0, lb.PrivateFrontends.Count);
            Assert.NotNull(lb.Frontends.ContainsKey(frontendName));
            var frontend = lb.Frontends[frontendName];
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(pip.Id.Equals(publicFrontend.PublicIPAddressId, StringComparison.OrdinalIgnoreCase));

            pip.Refresh();
            Assert.True(pip.GetAssignedLoadBalancerFrontend().Name.Equals(frontendName, StringComparison.OrdinalIgnoreCase));

            // Verify backends
            Assert.True(lb.Backends.ContainsKey(backendName));
            Assert.Equal(1, lb.Backends.Count);

            // Verify probes
            Assert.True(lb.HttpProbes.ContainsKey("httpProbe1"));
            Assert.Equal(1, lb.HttpProbes.Count);
            Assert.True(lb.TcpProbes.ContainsKey("tcpProbe1"));
            Assert.Equal(1, lb.TcpProbes.Count);

            // Verify rules
            Assert.Equal(1, lb.LoadBalancingRules.Count);
            Assert.True(lb.LoadBalancingRules.ContainsKey("rule1"));
            var rule = lb.LoadBalancingRules["rule1"];
            Assert.True(rule.Backend.Name.Equals(backendName, StringComparison.OrdinalIgnoreCase));
            Assert.True(rule.Frontend.Name.Equals(frontendName, StringComparison.OrdinalIgnoreCase));
            Assert.True(rule.Probe.Name.Equals("tcpProbe1", StringComparison.OrdinalIgnoreCase));

            // Verify inbound NAT rules
            Assert.Equal(1, lb.InboundNatRules.Count);
            Assert.True(lb.InboundNatRules.ContainsKey("natrule1"));
            var inboundNatRule = lb.InboundNatRules["natrule1"];
            Assert.True(inboundNatRule.Frontend.Name.Equals(frontendName, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(88, inboundNatRule.FrontendPort);
            Assert.Equal(88, inboundNatRule.BackendPort);

            return lb;
        }

        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            String backendName = resource.Backends.Values.First().Name;
            String frontendName = resource.Frontends.Values.First().Name;

            var nics = new List<INetworkInterface>();
            foreach (string nicId in resource.Backends[backendName].BackendNicIPConfigurationNames.Keys)
            {
                nics.Add(networks.Manager.NetworkInterfaces.GetById(nicId));
            }
            INetworkInterface nic1 = nics[0];
            INetworkInterface nic2 = nics[1];

            // Remove the NIC associations
            nic1.Update()
                .WithoutLoadBalancerBackends()
                .WithoutLoadBalancerInboundNatRules()
                .Apply();
            Assert.Equal(nic1.PrimaryIPConfiguration.ListAssociatedLoadBalancerBackends().Count, 0);

            nic2.Update()
                    .WithoutLoadBalancerBackends()
                    .WithoutLoadBalancerInboundNatRules()
                    .Apply();
            Assert.Equal(nic2.PrimaryIPConfiguration.ListAssociatedLoadBalancerBackends().Count, 0);

            // Update the load balancer
            var existingPips = loadBalancerHelper.EnsurePIPs(pips);
            IPublicIPAddress pip = resource.Manager.PublicIPAddresses.GetByResourceGroup(
                loadBalancerHelper.GroupName,
                loadBalancerHelper.PipNames[1]);
            resource = resource.Update()
                    .UpdatePublicFrontend(frontendName)
                        .WithExistingPublicIPAddress(pip)
                        .Parent()
                    .WithoutLoadBalancingRule("rule1")
                    .WithoutInboundNatRule("natrule1")
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .Apply();

            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.Equal(0, resource.InboundNatRules.Count);

            // Verify frontends
            Assert.Equal(1, resource.PublicFrontends.Count);
            Assert.Equal(0, resource.PrivateFrontends.Count);
            Assert.True(resource.Frontends.ContainsKey(frontendName));
            var frontend = resource.Frontends[frontendName];
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(pip.Id.Equals(publicFrontend.PublicIPAddressId, StringComparison.OrdinalIgnoreCase));

            return resource;
        }
    }
}
