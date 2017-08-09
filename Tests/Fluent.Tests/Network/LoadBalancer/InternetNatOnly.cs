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
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Fluent.Tests.Network.LoadBalancerHelpers
{
    /// <summary>
    /// Internet-facing LB test with NAT rules.
    /// </summary>
    public class InternetNatOnly : TestTemplate<ILoadBalancer, ILoadBalancers, INetworkManager>
    {
        private IComputeManager computeManager;
        private LoadBalancerHelper loadBalancerHelper;

        public InternetNatOnly (
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
            var existingVMs = loadBalancerHelper.EnsureVMs(resources.Manager.Networks, computeManager, 2);
            Assert.Equal(2, existingVMs.Count());

            ICreatable<IPublicIPAddress> pipDef = resources.Manager.PublicIPAddresses.Define(loadBalancerHelper.PipNames[0])
                    .WithRegion(loadBalancerHelper.Region)
                    .WithExistingResourceGroup(loadBalancerHelper.GroupName)
                    .WithLeafDomainLabel(loadBalancerHelper.PipNames[0]);

            // Create a load balancer
            ILoadBalancer lb = resources.Define(loadBalancerHelper.LoadBalancerName)
                    .WithRegion(loadBalancerHelper.Region)
                    .WithExistingResourceGroup(loadBalancerHelper.GroupName)

                    // Inbound NAT rule
                    .DefineInboundNatRule("natrule1")
                        .WithProtocol(TransportProtocol.Tcp)
                        .FromNewPublicIPAddress(pipDef)
                        .FromFrontendPort(88)
                        .ToBackendPort(80)
                        .Attach()
                    // Backend
                    .DefineBackend("backend1")
                        .WithExistingVirtualMachines(new List<IHasNetworkInterfaces>(existingVMs))
                        .Attach()
                    .Create();

            // Verify frontends
            Assert.Equal(1, lb.Frontends.Count);
            Assert.Equal(1, lb.PublicFrontends.Count);
            Assert.Equal(0, lb.PrivateFrontends.Count);
            var frontend = lb.PublicFrontends.Values.First();
            Assert.NotNull(frontend);
            Assert.NotNull(frontend.PublicIPAddressId);

            // Verify probes
            Assert.Equal(0, lb.TcpProbes.Count);
            Assert.Equal(0, lb.HttpProbes.Count);

            // Verify LB rules
            Assert.Equal(0, lb.LoadBalancingRules.Count);

            // Verify NAT rules
            Assert.Equal(1, lb.InboundNatRules.Count);
            Assert.True(lb.InboundNatRules.ContainsKey("natrule1"));
            var natRule = lb.InboundNatRules["natrule1"];
            Assert.Equal(TransportProtocol.Tcp, natRule.Protocol);
            Assert.NotNull(natRule.Frontend);
            Assert.True(natRule.Frontend.IsPublic);
            var publicFrontend = (ILoadBalancerPublicFrontend)natRule.Frontend;
            var pip = publicFrontend.GetPublicIPAddress();
            Assert.NotNull(pip);
            Assert.Equal(pip.Name, loadBalancerHelper.PipNames[0]);
            Assert.True(pip.LeafDomainLabel.Equals(loadBalancerHelper.PipNames[0], StringComparison.OrdinalIgnoreCase));
            Assert.Equal(88, natRule.FrontendPort);

            // Verify backends
            Assert.Equal(1, lb.Backends.Count);
            var backend = lb.Backends.Values.First();
            Assert.Equal(2, backend.BackendNicIPConfigurationNames.Count);
            foreach (var vm in existingVMs)
            {
                Assert.True(backend.BackendNicIPConfigurationNames.ContainsKey(vm.PrimaryNetworkInterfaceId));
            }

            return lb;
        }

        public override ILoadBalancer UpdateResource(ILoadBalancer resource)
        {
            ILoadBalancerBackend backend = resource.Backends.Values.First();
            ILoadBalancerInboundNatRule natRule = resource.InboundNatRules.Values.First();
            ILoadBalancerPublicFrontend publicFrontend = (ILoadBalancerPublicFrontend)natRule.Frontend;

            IPublicIPAddress pip = resource.Manager.PublicIPAddresses.Define(loadBalancerHelper.PipNames[1])
                .WithRegion(loadBalancerHelper.Region)
                .WithExistingResourceGroup(loadBalancerHelper.GroupName)
                .WithLeafDomainLabel(loadBalancerHelper.PipNames[1])
            .Create();

            resource = resource.Update()
                .UpdatePublicFrontend(publicFrontend.Name)
                    .WithExistingPublicIPAddress(pip)
                    .Parent()
                .DefineBackend("backend2")
                    .Attach()
                .WithoutBackend(backend.Name)
                .WithoutInboundNatRule("natrule1")
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            Assert.True(resource.Tags.ContainsKey("tag1"));

            // Verify frontends
            Assert.Equal(1, resource.Frontends.Count);
            Assert.Equal(1, resource.PublicFrontends.Count);
            Assert.Equal(0, resource.PrivateFrontends.Count);
            Assert.True(resource.Frontends.ContainsKey(publicFrontend.Name));
            var frontend = resource.Frontends[publicFrontend.Name];
            Assert.True(frontend.IsPublic);
            publicFrontend = (ILoadBalancerPublicFrontend)frontend;
            Assert.True(pip.Id.Equals(publicFrontend.PublicIPAddressId, StringComparison.OrdinalIgnoreCase));
            Assert.Equal(0, publicFrontend.LoadBalancingRules.Count);

            // Verify probes
            Assert.Equal(0, resource.TcpProbes.Count);
            Assert.Equal(0, resource.HttpProbes.Count);

            // Verify backends
            Assert.True(resource.Backends.ContainsKey("backend2"));
            Assert.True(!resource.Backends.ContainsKey(backend.Name));

            // Verify NAT rules
            Assert.Equal(0, resource.InboundNatRules.Count);

            // Verify load balancing rules
            Assert.Equal(0, resource.LoadBalancingRules.Count);

            return resource;
        }
    }
}
