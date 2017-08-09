// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Fluent.Tests.Network.LoadBalancerHelpers
{
    /// <summary>
    /// Internal minimalistic LB test.
    /// </summary>
    public class InternalMinimal : TestTemplate<ILoadBalancer, ILoadBalancers, INetworkManager>
    {
        private IComputeManager computeManager;
        private INetwork network;
        private LoadBalancerHelper loadBalancerHelper;

        public InternalMinimal(
            IComputeManager computeManager, [CallerMemberName] string methodName = "testframework_failed")
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
            var existingVMs = loadBalancerHelper.EnsureVMs(resources.Manager.Networks, computeManager, 2);

            // Must use the same VNet as the VMs
            network = existingVMs.First().GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();

            // Create a load balancer
            ILoadBalancer lb = resources.Define(loadBalancerHelper.LoadBalancerName)
                    .WithRegion(loadBalancerHelper.Region)
                    .WithExistingResourceGroup(loadBalancerHelper.GroupName)
                    // LB rule
                    .DefineLoadBalancingRule("lbrule1")
                        .WithProtocol(TransportProtocol.Tcp)
                        .FromExistingSubnet(network, "subnet1")
                        .FromFrontendPort(80)
                        .ToExistingVirtualMachines(new List<IHasNetworkInterfaces>(existingVMs))
                        .Attach()
                    .Create();

            // Verify frontends
            Assert.Equal(1, lb.Frontends.Count);
            Assert.Equal(1, lb.PrivateFrontends.Count);
            Assert.Equal(0, lb.PublicFrontends.Count);
            var frontend = lb.Frontends.Values.First();
            Assert.Equal(1, frontend.LoadBalancingRules.Count);
            Assert.False(frontend.IsPublic);
            Assert.True("lbrule1".Equals(frontend.LoadBalancingRules.Values.First().Name, StringComparison.OrdinalIgnoreCase));
            var privateFrontend = (ILoadBalancerPrivateFrontend) frontend;
            Assert.True(network.Id.Equals(privateFrontend.NetworkId, StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(privateFrontend.PrivateIPAddress);
            Assert.True("subnet1".Equals(privateFrontend.SubnetName, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(IPAllocationMethod.Dynamic, privateFrontend.PrivateIPAllocationMethod);

            // Verify TCP probes
            Assert.Equal(0, lb.TcpProbes.Count);

            // Verify rules
            Assert.Equal(1, lb.LoadBalancingRules.Count);
            Assert.True(lb.LoadBalancingRules.ContainsKey("lbrule1"));
            var lbrule = lb.LoadBalancingRules["lbrule1"];
            Assert.NotNull(lbrule.Frontend);
            Assert.Equal(80, lbrule.BackendPort);
            Assert.Equal(80, lbrule.FrontendPort);
            Assert.Null(lbrule.Probe);
            Assert.Equal(TransportProtocol.Tcp, lbrule.Protocol);
            Assert.NotNull(lbrule.Backend);

            // Verify backends
            Assert.Equal(1, lb.Backends.Count);
            var backend = lb.Backends.Values.First();
            Assert.NotNull(backend);

            Assert.Equal(2, backend.BackendNicIPConfigurationNames.Count);
            foreach(var vm in existingVMs)
            {
                Assert.True(backend.BackendNicIPConfigurationNames.ContainsKey(vm.PrimaryNetworkInterfaceId));
            }

            return lb;
        }

        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            Assert.Equal(1, resource.Backends.Count);
            var backend = resource.Backends.Values.First();
            Assert.True(resource.LoadBalancingRules.ContainsKey("lbrule1"));
            var lbRule = resource.LoadBalancingRules["lbrule1"];
            resource = resource.Update()
                .UpdatePrivateFrontend(lbRule.Frontend.Name)
                    .WithExistingSubnet(network, "subnet2")
                    .WithPrivateIPAddressStatic("10.0.0.13")
                    .Parent()
                .DefineTcpProbe("tcpprobe")
                    .WithPort(22)
                    .Attach()
                .DefineHttpProbe("httpprobe")
                    .WithRequestPath("/foo")
                    .WithNumberOfProbes(3)
                    .WithPort(443)
                    .Attach()
                .UpdateLoadBalancingRule("lbrule1")
                    .ToBackendPort(8080)
                    .WithIdleTimeoutInMinutes(11)
                    .WithProbe("tcpprobe")
                    .Parent()
                .DefineLoadBalancingRule("lbrule2")
                    .WithProtocol(TransportProtocol.Udp)
                    .FromFrontend(lbRule.Frontend.Name)
                    .FromFrontendPort(22)
                    .ToBackend("backend2")
                    .WithProbe("httpprobe")
                    .Attach()
                .WithoutBackend(backend.Name)
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            Assert.True(resource.Tags.ContainsKey("tag1"));

            // Verify frontends
            Assert.Equal(1, resource.Frontends.Count);
            Assert.Equal(1, resource.PrivateFrontends.Count);
            Assert.Equal(0, resource.PublicFrontends.Count);
            Assert.True(resource.Frontends.ContainsKey(lbRule.Frontend.Name));
            var frontend = resource.Frontends[lbRule.Frontend.Name];
            Assert.False(frontend.IsPublic);
            var privateFrontend = (ILoadBalancerPrivateFrontend) frontend;
            Assert.True("subnet2".Equals(privateFrontend.SubnetName, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(IPAllocationMethod.Static, privateFrontend.PrivateIPAllocationMethod);
            Assert.True("10.0.0.13".Equals(privateFrontend.PrivateIPAddress));
            Assert.Equal(2, privateFrontend.LoadBalancingRules.Count);

            // Verify probes
            Assert.Equal(1, resource.TcpProbes.Count);
            Assert.True(resource.TcpProbes.ContainsKey("tcpprobe"));
            var tcpProbe = resource.TcpProbes["tcpprobe"];
            Assert.Equal(22, tcpProbe.Port);
            Assert.True(tcpProbe.LoadBalancingRules.ContainsKey("lbrule1"));

            Assert.True(resource.HttpProbes.ContainsKey("httpprobe"));
            var httpProbe = resource.HttpProbes["httpprobe"];
            Assert.Equal(3, httpProbe.NumberOfProbes);
            Assert.True("/foo".Equals(httpProbe.RequestPath, StringComparison.OrdinalIgnoreCase));
            Assert.True(httpProbe.LoadBalancingRules.ContainsKey("lbrule2"));

            // Verify backends
            Assert.Equal(1, resource.Backends.Count);
            Assert.True(resource.Backends.ContainsKey("backend2"));
            Assert.True(!resource.Backends.ContainsKey(backend.Name));

            // Verify load balancing rules
            Assert.True(resource.LoadBalancingRules.ContainsKey("lbrule1"));
            lbRule = resource.LoadBalancingRules["lbrule1"];
            Assert.Null(lbRule.Backend);
            Assert.Equal(8080, lbRule.BackendPort);
            Assert.NotNull(lbRule.Frontend);
            Assert.Equal(11, lbRule.IdleTimeoutInMinutes);
            Assert.NotNull(lbRule.Probe);
            Assert.Equal(tcpProbe.Name, lbRule.Probe.Name);

            Assert.True(resource.LoadBalancingRules.ContainsKey("lbrule2"));
            lbRule = resource.LoadBalancingRules["lbrule2"];
            Assert.NotNull(lbRule);
            Assert.Equal(22, lbRule.FrontendPort);
            Assert.NotNull(lbRule.Frontend);
            Assert.True("httpprobe".Equals(lbRule.Probe.Name, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(TransportProtocol.Udp, lbRule.Protocol);
            Assert.NotNull(lbRule.Backend);
            Assert.True("backend2".Equals(lbRule.Backend.Name, StringComparison.OrdinalIgnoreCase));

            return resource;
        }
    }
}
