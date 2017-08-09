// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Collections.Generic;

namespace Fluent.Tests.Network.LoadBalancerHelpers
{
    /// <summary>
    /// Internet-facing minimalistic LB test
    /// </summary>
    public class InternetMinimal : TestTemplate<ILoadBalancer, ILoadBalancers, INetworkManager>
    {
        private IComputeManager computeManager;
        private LoadBalancerHelper loadBalancerHelper;

        public InternetMinimal(IComputeManager computeManager, [CallerMemberName] string methodName = "testframework_failed")
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
            string pipDnsLabel = SdkContext.RandomResourceName("pip", 20);

            // Create a load balancer
            var lb = resources.Define(loadBalancerHelper.LoadBalancerName)
                        .WithRegion(loadBalancerHelper.Region)
                        .WithExistingResourceGroup(loadBalancerHelper.GroupName)

                        // LB rule
                        .DefineLoadBalancingRule("lbrule1")
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromNewPublicIPAddress(pipDnsLabel)
                            .FromFrontendPort(80)
                            .ToExistingVirtualMachines(new List<IHasNetworkInterfaces>(existingVMs))
                            .Attach()
                        .Create();

            // Verify frontends
            Assert.Equal(1, lb.Frontends.Count);
            Assert.Equal(1, lb.PublicFrontends.Count);
            Assert.Equal(0, lb.PrivateFrontends.Count);
            var frontend = lb.Frontends.Values.First();
            Assert.Equal(1, frontend.LoadBalancingRules.Count);
            Assert.True("lbrule1".Equals(frontend.LoadBalancingRules.Values.First().Name, StringComparison.OrdinalIgnoreCase));
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend) frontend;
            IPublicIPAddress pip = publicFrontend.GetPublicIPAddress();
            Assert.NotNull(pip);
            Assert.True(pip.LeafDomainLabel.Equals(pipDnsLabel, StringComparison.OrdinalIgnoreCase));

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
            foreach (var vm in existingVMs)
            {
                Assert.True(backend.BackendNicIPConfigurationNames.ContainsKey(vm.PrimaryNetworkInterfaceId));
            }

            return lb;
        }


        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            var existingPips = loadBalancerHelper.EnsurePIPs(resource.Manager.PublicIPAddresses);
            var pip = resource.Manager.PublicIPAddresses.GetByResourceGroup(
                loadBalancerHelper.GroupName,
                loadBalancerHelper.PipNames[0]);
            Assert.NotNull(pip);
            Assert.NotEqual(0, resource.Backends.Count);
            var backend = resource.Backends.Values.First();
            Assert.True(resource.LoadBalancingRules.ContainsKey("lbrule1"));
            var lbRule = resource.LoadBalancingRules["lbrule1"];

            resource = resource.Update()
                    .UpdatePublicFrontend(lbRule.Frontend.Name)
                        .WithExistingPublicIPAddress(pip)
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
            Assert.Equal(1, resource.PublicFrontends.Count);
            Assert.Equal(0, resource.PrivateFrontends.Count);
            var frontend = lbRule.Frontend;
            Assert.True(frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(pip.Id.Equals(publicFrontend.PublicIPAddressId, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(2, publicFrontend.LoadBalancingRules.Count);

            // Verify probes
            Assert.True(resource.TcpProbes.ContainsKey("tcpprobe"));
            var tcpProbe = resource.TcpProbes["tcpprobe"];
            Assert.Equal(22, tcpProbe.Port);
            Assert.Equal(1, tcpProbe.LoadBalancingRules.Count);
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
            Assert.NotNull(lbRule);
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
