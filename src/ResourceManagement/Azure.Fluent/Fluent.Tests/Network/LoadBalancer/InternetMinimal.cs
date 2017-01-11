// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Azure.Tests.Network.LoadBalancer
{
    /// <summary>
    /// Internet-facing minimalistic LB test
    /// </summary>
    public class InternetMinimal : TestTemplate<ILoadBalancer, ILoadBalancers>
    {
        private IPublicIpAddresses pips;
        private IVirtualMachines vms;
        private INetworks networks;
        private LoadBalancerHelper loadBalancerHelper;
        private IAvailabilitySets availabilitySets;

        public InternetMinimal(
                IPublicIpAddresses pips,
                IVirtualMachines vms,
                INetworks networks,
                IAvailabilitySets availabilitySets,
                [CallerMemberName] string methodName = "testframework_failed")
            : base(methodName)
        {
            loadBalancerHelper = new LoadBalancerHelper(methodName);
            this.pips = pips;
            this.vms = vms;
            this.availabilitySets = availabilitySets;
            this.networks = networks;
        }

        public override void Print(ILoadBalancer resource)
        {
            LoadBalancerHelper.PrintLB(resource);
        }

        public override ILoadBalancer CreateResource(ILoadBalancers resources)
        {
            var existingVMs = loadBalancerHelper.EnsureVMs(this.networks, this.vms, this.availabilitySets, 2);
            var existingPips = loadBalancerHelper.EnsurePIPs(pips);

            // Create a load balancer
            var lb = resources.Define(loadBalancerHelper.LoadBalancerName)
                        .WithRegion(loadBalancerHelper.Region)
                        .WithExistingResourceGroup(loadBalancerHelper.GroupName)
                        // Frontend (default)
                        .WithExistingPublicIpAddress(existingPips.ElementAt(0))
                        // Backend (default)
                        .WithExistingVirtualMachines(existingVMs.ToArray())
                        // Probe (default)
                        .WithTcpProbe(22)
                        // LB rule (default)
                        .WithLoadBalancingRule(80, TransportProtocol.Tcp)
                        .Create();

            // Verify frontends
            Assert.True(lb.Frontends.ContainsKey("default"));
            var frontend = lb.Frontends["default"];
            Assert.Equal(1, frontend.LoadBalancingRules.Count);
            Assert.True("default".Equals(frontend.LoadBalancingRules.Values.First().Name, StringComparison.OrdinalIgnoreCase));
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(existingPips.First().Id.Equals(publicFrontend.PublicIpAddressId, StringComparison.OrdinalIgnoreCase));

            // Verify TCP probes
            Assert.True(lb.TcpProbes.ContainsKey("default"));
            Assert.Equal(1, lb.TcpProbes.Count);
            var tcpProbe = lb.TcpProbes["default"];
            Assert.True(tcpProbe.LoadBalancingRules.ContainsKey("default"));
            Assert.Equal(1, tcpProbe.LoadBalancingRules.Count);
            Assert.Equal(22, tcpProbe.Port);
            Assert.Equal(ProbeProtocol.Tcp, tcpProbe.Protocol);

            // Verify rules
            Assert.Equal(1, lb.LoadBalancingRules.Count);
            Assert.True(lb.LoadBalancingRules.ContainsKey("default"));
            var lbrule = lb.LoadBalancingRules["default"];
            Assert.True("default".Equals(lbrule.Frontend.Name, StringComparison.OrdinalIgnoreCase));
            Assert.True("default".Equals(lbrule.Probe.Name));
            Assert.Equal(80, lbrule.BackendPort);
            Assert.NotNull(lbrule.Frontend);
            Assert.True("default".Equals(lbrule.Frontend.Name, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(80, lbrule.FrontendPort);
            Assert.NotNull(lbrule.Probe);
            Assert.True("default".Equals(lbrule.Probe.Name, StringComparison.OrdinalIgnoreCase));
            Assert.True(TransportProtocol.Tcp.ToString().Equals(lbrule.Protocol, StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(lbrule.Backend);
            Assert.True("default".Equals(lbrule.Backend.Name, StringComparison.OrdinalIgnoreCase));

            // Verify backends
            Assert.Equal(1, lb.Backends.Count);
            var backend = lb.Backends["default"];
            Assert.NotNull(backend);
            Assert.Equal(2, backend.BackendNicIpConfigurationNames.Count);
            foreach (var vm in existingVMs)
            {
                Assert.True(backend.BackendNicIpConfigurationNames.ContainsKey(vm.PrimaryNetworkInterfaceId));
            }

            return lb;
        }


        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            var existingPips = loadBalancerHelper.EnsurePIPs(pips);
            var pip = existingPips.ElementAt(1);
            resource = resource.Update()
                    .WithExistingPublicIpAddress(pip)
                    .UpdateTcpProbe("default")
                        .WithPort(22)
                        .Parent()
                    .DefineHttpProbe("httpprobe")
                        .WithRequestPath("/foo")
                        .WithNumberOfProbes(3)
                        .WithPort(443)
                        .Attach()
                    .UpdateLoadBalancingRule("default")
                        .WithBackendPort(8080)
                        .WithIdleTimeoutInMinutes(11)
                        .Parent()
                    .DefineLoadBalancingRule("lbrule2")
                        .WithProtocol(TransportProtocol.Udp)
                        .WithFrontend("default")
                        .WithFrontendPort(22)
                        .WithProbe("httpprobe")
                        .WithBackend("backend2")
                        .Attach()
                    .DefineBackend("backend2")
                        .Attach()
                    .WithoutBackend("default")
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .Apply();
            Assert.True(resource.Tags.ContainsKey("tag1"));

            // Verify frontends
            Assert.Equal(1, resource.Frontends.Count);
            var frontend = resource.Frontends["default"];
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(pip.Id.Equals(publicFrontend.PublicIpAddressId, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(2, publicFrontend.LoadBalancingRules.Count);

            // Verify probes
            var tcpProbe = resource.TcpProbes["default"];
            Assert.NotNull(tcpProbe);
            Assert.Equal(22, tcpProbe.Port);

            var httpProbe = resource.HttpProbes["httpprobe"];
            Assert.NotNull(httpProbe);
            Assert.Equal(3, httpProbe.NumberOfProbes);
            Assert.True("/foo".Equals(httpProbe.RequestPath, StringComparison.OrdinalIgnoreCase));
            Assert.True(httpProbe.LoadBalancingRules.ContainsKey("lbrule2"));

            // Verify backends
            Assert.True(resource.Backends.ContainsKey("backend2"));
            Assert.True(!resource.Backends.ContainsKey("default"));

            // Verify load balancing rules
            var lbRule = resource.LoadBalancingRules["default"];
            Assert.NotNull(lbRule);
            Assert.Null(lbRule.Backend);
            Assert.Equal(8080, lbRule.BackendPort);
            Assert.True("default".Equals(lbRule.Frontend.Name, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(11, lbRule.IdleTimeoutInMinutes);

            lbRule = resource.LoadBalancingRules["lbrule2"];
            Assert.NotNull(lbRule);
            Assert.Equal(22, lbRule.FrontendPort);
            Assert.NotNull(lbRule.Frontend);
            Assert.True("default".Equals(lbRule.Frontend.Name, StringComparison.OrdinalIgnoreCase));
            Assert.True("httpprobe".Equals(lbRule.Probe.Name, StringComparison.OrdinalIgnoreCase));
            Assert.True(TransportProtocol.Udp.ToString().Equals(lbRule.Protocol, StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(lbRule.Backend);
            Assert.True("backend2".Equals(lbRule.Backend.Name, StringComparison.OrdinalIgnoreCase));

            return resource;
        }
    }
}
