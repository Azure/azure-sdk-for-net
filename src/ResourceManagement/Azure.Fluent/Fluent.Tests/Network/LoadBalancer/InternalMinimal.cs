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
        private INetworks networks;
        private INetwork network;

        public InternalMinimal(
            IVirtualMachines vms,
            INetworks networks)
        {
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
            this.network = this.networks.Define("net" + LoadBalancerHelper.TEST_ID)
                    .WithRegion(LoadBalancerHelper.REGION)
                    .WithNewResourceGroup(LoadBalancerHelper.GROUP_NAME)
                    .WithAddressSpace("10.0.0.0/28")
                    .WithSubnet("subnet1", "10.0.0.0/29")
                    .WithSubnet("subnet2", "10.0.0.8/29")
                    .Create();

            // Create a load balancer
            var lb = resources.Define(LoadBalancerHelper.LB_NAME)
                        .WithRegion(LoadBalancerHelper.REGION)
                        .WithExistingResourceGroup(LoadBalancerHelper.GROUP_NAME)
                        // Frontend (default)
                        .WithExistingSubnet(network, "subnet1")
                        // Backend (default)
                        .WithExistingVirtualMachines(existingVMs.ToArray())
                        .DefineBackend("foo")
                        .Attach()
                        // Probe (default)
                        .WithTcpProbe(22)
                        // LB rule (default)
                        .WithLoadBalancingRule(80, TransportProtocol.Tcp)
                        .Create();

            //TODO Assert.True(lb.backends.ContainsKey("default"));
            Assert.True(lb.Frontends.ContainsKey("default"));
            Assert.True(lb.TcpProbes.ContainsKey("default"));
            Assert.True(lb.LoadBalancingRules.ContainsKey("default"));

            var lbrule = lb.LoadBalancingRules["default"];
            Assert.True(lbrule.Frontend.Name.Equals("default", StringComparison.OrdinalIgnoreCase));
            //TODO Assert.True(lbrule.backend.Name.Equals("default",  StringComparison.OrdinalIgnoreCase));
            Assert.True(lbrule.Probe.Name.Equals("default", StringComparison.OrdinalIgnoreCase));

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
            Assert.True(resource.TcpProbes["default"].Port == 22);
            Assert.True(resource.HttpProbes["httpprobe"].NumberOfProbes == 3);
            Assert.True(resource.Backends.ContainsKey("backend2"));
            Assert.True(!resource.Backends.ContainsKey("default"));

            var lbRule = resource.LoadBalancingRules["default"];
            Assert.True(lbRule != null);
            Assert.True(lbRule.Backend == null);
            Assert.True(lbRule.BackendPort == 8080);
            Assert.True(lbRule.Frontend.Name.Equals("default", StringComparison.OrdinalIgnoreCase));

            var frontend = resource.Frontends["default"];
            Assert.True(!frontend.IsPublic);
            Assert.True(lbRule.Probe.Name.Equals("default", StringComparison.OrdinalIgnoreCase));

            lbRule = resource.LoadBalancingRules["lbrule2"];
            Assert.True(lbRule != null);
            Assert.True(lbRule.FrontendPort == 22);

            return resource;
        }
    }
}
