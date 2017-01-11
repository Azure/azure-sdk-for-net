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
    /// Internal minimalistic LB test.
    /// </summary>
    public class InternalMinimal : TestTemplate<ILoadBalancer, ILoadBalancers>
    {
        private IVirtualMachines vms;
        private IAvailabilitySets availabilitySets;
        private INetworks networks;
        private INetwork network;

        public InternalMinimal(
            IVirtualMachines vms,
            INetworks networks,
            IAvailabilitySets availabilitySets)
        {
            this.vms = vms;
            this.networks = networks;
            this.availabilitySets = availabilitySets;
        }

        public override void Print(ILoadBalancer resource)
        {
            LoadBalancerHelper.PrintLB(resource);
        }

        public override ILoadBalancer CreateResource(ILoadBalancers resources)
        {
            var existingVMs = LoadBalancerHelper.EnsureVMs(networks, vms, availabilitySets, 2);

            // Must use the same VNet as the VMs
            network = existingVMs.First().GetPrimaryNetworkInterface().PrimaryIpConfiguration.GetNetwork();

            // Create a load balancer
            var lb = resources.Define(LoadBalancerHelper.LoadBalancerName)
                        .WithRegion(LoadBalancerHelper.Region)
                        .WithExistingResourceGroup(LoadBalancerHelper.GroupName)
                        // Frontend (default)
                        .WithFrontendSubnet(network, "subnet1")
                        // Backend (default)
                        .WithExistingVirtualMachines(existingVMs.ToArray())
                        .DefineBackend("foo")
                        .Attach()
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
            Assert.False(frontend.IsPublic);
            var privateFrontend = (ILoadBalancerPrivateFrontend)frontend;
            Assert.True(network.Id.Equals(privateFrontend.NetworkId, StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(privateFrontend.PrivateIpAddress);
            Assert.True("subnet1".Equals(privateFrontend.SubnetName, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(IPAllocationMethod.Dynamic, privateFrontend.PrivateIpAllocationMethod);

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
            Assert.True("default".Equals(lbrule.Probe.Name, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(80, lbrule.BackendPort);
            Assert.NotNull(lbrule.Frontend);
            Assert.True("default".Equals(lbrule.Frontend.Name, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(80, lbrule.FrontendPort);
            Assert.NotNull(lbrule.Probe);
            Assert.True("default".Equals(lbrule.Probe.Name, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(TransportProtocol.Tcp.ToString(), lbrule.Protocol);
            Assert.NotNull(lbrule.Backend);
            Assert.True("default".Equals(lbrule.Backend.Name, StringComparison.OrdinalIgnoreCase));

            // Verify backends
            Assert.Equal(2, lb.Backends.Count);

            var backend = lb.Backends["foo"];
            Assert.NotNull(backend);
            Assert.Equal(0, backend.BackendNicIpConfigurationNames.Count);

            backend = lb.Backends["default"];
            Assert.NotNull(backend);
            Assert.Equal(2, backend.BackendNicIpConfigurationNames.Count);
            foreach (IVirtualMachine vm in existingVMs)
            {
                Assert.True(backend.BackendNicIpConfigurationNames.ContainsKey(vm.PrimaryNetworkInterfaceId));
            }

            return lb;
        }

        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            resource = resource.Update()
                        .UpdateInternalFrontend("default")
                            .WithExistingSubnet(this.network, "subnet2")
                            .WithPrivateIpAddressStatic("10.0.0.13")
                            .Parent()
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
            Assert.False(frontend.IsPublic);
            var privateFrontend = (ILoadBalancerPrivateFrontend)frontend;
            Assert.True("subnet2".Equals(privateFrontend.SubnetName, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(IPAllocationMethod.Static, privateFrontend.PrivateIpAllocationMethod);
            Assert.True("10.0.0.13".Equals(privateFrontend.PrivateIpAddress, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(2, privateFrontend.LoadBalancingRules.Count);

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
            Assert.True("default".Equals(lbRule.Frontend.Name));
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
