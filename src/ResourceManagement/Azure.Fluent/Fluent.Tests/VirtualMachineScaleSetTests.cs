using Fluent.Tests;
using Microsoft.Azure.Management.Fluent.Network;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class VirtualMachineScaleSetTests
    {
        private readonly string location = "eastus";

        [Fact]
        public void CanCreateVirtualMachineScaleSetWithCustomScriptExtension()
        {
            string rgName = ResourceNamer.RandomResourceName("javacsmrg", 20);

            var azure = TestHelper.CreateRollupClient();

            IResourceGroup resourceGroup = azure.ResourceGroups
            .Define(rgName)
            .WithRegion(location)
            .Create();

            INetwork network = azure
                .Networks
                .Define(ResourceNamer.RandomResourceName("vmssvnet", 15))
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithAddressSpace("10.0.0.0/28")
                .WithSubnet("subnet1", "10.0.0.0/28")
                .Create();

            ILoadBalancer publicLoadBalancer0 = CreateInternalLoadBalancer(azure, resourceGroup, network, "1");

            ILoadBalancer publicLoadBalancer1 = CreateHttpLoadBalancers(azure, resourceGroup, "1");
            Assert.True(true);
        }



        private ILoadBalancer createInternetFacingLoadBalancer(Microsoft.Azure.Management.IAzure azure, IResourceGroup resourceGroup, string id)
        {
            string loadBalancerName = ResourceNamer.RandomResourceName("extlb" + id + "-", 18);
            string publicIpName = "pip-" + loadBalancerName;
            string frontendName = loadBalancerName + "-FE1";
            string backendPoolName1 = loadBalancerName + "-BAP1";
            string backendPoolName2 = loadBalancerName + "-BAP2";
            string natPoolName1 = loadBalancerName + "-INP1";
            string natPoolName2 = loadBalancerName + "-INP2";

            IPublicIpAddress publicIpAddress = azure.PublicIpAddresses
                .Define(publicIpName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithLeafDomainLabel(publicIpName)
                .Create();

            ILoadBalancer loadBalancer = azure.LoadBalancers
                .Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .DefinePublicFrontend(frontendName)
                .WithExistingPublicIpAddress(publicIpAddress)
                .Attach()
                // Add two backend one per rule
                .DefineBackend(backendPoolName1)
                .Attach()
                .DefineBackend(backendPoolName2)
                .Attach()
                // Add two probes one per rule
                .DefineHttpProbe("httpProbe")
                .WithRequestPath("/")
                .Attach()
                .DefineHttpProbe("httpsProbe")
                .WithRequestPath("/")
                .Attach()
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(frontendName)
                    .WithFrontendPort(80)
                    .WithProbe("httpProbe")
                    .WithBackend(backendPoolName1)
                .Attach()
                .DefineLoadBalancingRule("httpsRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(frontendName)
                    .WithFrontendPort(443)
                    .WithProbe("httpsProbe")
                    .WithBackend(backendPoolName2)
                .Attach()
                // Add two nat pools to enable direct VM connectivity to port SSH and 23
                .DefineInboundNatPool(natPoolName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(frontendName)
                    .WithFrontendPortRange(5000, 5099)
                    .WithBackendPort(22)
                .Attach()
                .DefineInboundNatPool(natPoolName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(frontendName)
                    .WithFrontendPortRange(6000, 6099)
                    .WithBackendPort(23)
                .Attach()
                .Create();

            loadBalancer = azure.LoadBalancers.GetByGroup(resourceGroup.Name, loadBalancerName);

            Assert.True(loadBalancer.PublicIpAddressIds.Count() == 1);
            Assert.Equal(loadBalancer.HttpProbes.Count(), 2);
            IHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            IHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            Assert.Equal(loadBalancer.InboundNatPools.Count(), 2);
            return loadBalancer;
        }

        private ILoadBalancer CreateInternalLoadBalancer(Microsoft.Azure.Management.IAzure azure, IResourceGroup resourceGroup,
                                                INetwork network, string id)
        {
            string loadBalancerName = ResourceNamer.RandomResourceName("InternalLb" + id + "-", 18);
            string privateFrontEndName = loadBalancerName + "-FE1";
            string backendPoolName1 = loadBalancerName + "-BAP1";
            string backendPoolName2 = loadBalancerName + "-BAP2";
            string natPoolName1 = loadBalancerName + "-INP1";
            string natPoolName2 = loadBalancerName + "-INP2";
            string subnetName = "subnet1";

            ILoadBalancer loadBalancer = azure.LoadBalancers
                .Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .DefinePrivateFrontend(privateFrontEndName)
                    .WithExistingSubnet(network, subnetName)
                .Attach()
                // Add two backend one per rule
                .DefineBackend(backendPoolName1)
                .Attach()
                .DefineBackend(backendPoolName2)
                .Attach()
                // Add two probes one per rule
                .DefineHttpProbe("httpProbe")
                    .WithRequestPath("/")
                .Attach()
                .DefineHttpProbe("httpsProbe")
                    .WithRequestPath("/")
                .Attach()
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(privateFrontEndName)
                    .WithFrontendPort(1000)
                    .WithProbe("httpProbe")
                    .WithBackend(backendPoolName1)
                .Attach()
                .DefineLoadBalancingRule("httpsRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(privateFrontEndName)
                    .WithFrontendPort(1001)
                    .WithProbe("httpsProbe")
                    .WithBackend(backendPoolName2)
                .Attach()
                // Add two nat pools to enable direct VM connectivity to port 44 and 45
                .DefineInboundNatPool(natPoolName1)
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(privateFrontEndName)
                    .WithFrontendPortRange(8000, 8099)
                    .WithBackendPort(44)
                .Attach()
                .DefineInboundNatPool(natPoolName2)
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(privateFrontEndName)
                    .WithFrontendPortRange(9000, 9099)
                    .WithBackendPort(45)
                .Attach()
                .Create();

            loadBalancer = azure.LoadBalancers.GetByGroup(resourceGroup.Name, loadBalancerName);

            Assert.Equal(loadBalancer.PublicIpAddressIds.Count(), 0);
            Assert.Equal(loadBalancer.Backends.Count(), 2);
            IBackend backend1 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName1, out backend1));
            IBackend backend2 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName2, out backend2));
            IHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            IHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            Assert.Equal(loadBalancer.InboundNatPools.Count(), 2);
            return loadBalancer;
        }

        private ILoadBalancer CreateHttpLoadBalancers(Microsoft.Azure.Management.IAzure azure, IResourceGroup resourceGroup, string id)
        {
            string loadBalancerName = ResourceNamer.RandomResourceName("extlb" + id + "-", 18);
            string publicIpName = "pip-" + loadBalancerName;
            string frontendName = loadBalancerName + "-FE1";
            string backendPoolName = loadBalancerName + "-BAP1";
            string natPoolName = loadBalancerName + "-INP1";

            var publicIpAddress = azure.PublicIpAddresses
                .Define(publicIpName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithLeafDomainLabel(publicIpName)
                .Create();

            var loadBalancer = azure.LoadBalancers
                .Define(loadBalancerName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .DefinePublicFrontend(frontendName)
                    .WithExistingPublicIpAddress(publicIpAddress)
                .Attach()
                .DefineBackend(backendPoolName)
                .Attach()
                .DefineHttpProbe("httpProbe")
                    .WithRequestPath("/")
                .Attach()
                // Add two rules that uses above backend and probe
                .DefineLoadBalancingRule("httpRule")
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(frontendName)
                    .WithFrontendPort(80)
                    .WithProbe("httpProbe")
                    .WithBackend(backendPoolName)
                .Attach()
                .DefineInboundNatPool(natPoolName)
                    .WithProtocol(TransportProtocol.Tcp)
                    .WithFrontend(frontendName)
                    .WithFrontendPortRange(5000, 5099)
                    .WithBackendPort(22)
                .Attach()
                .Create();

            loadBalancer = azure.LoadBalancers.GetByGroup(resourceGroup.Name, loadBalancerName);

            Assert.True(loadBalancer.PublicIpAddressIds.Count() == 1);
            var httpProbe = loadBalancer.HttpProbes.FirstOrDefault();
            Assert.NotNull(httpProbe);
            var rule = httpProbe.Value.LoadBalancingRules.FirstOrDefault();
            Assert.NotNull(rule);
            var natPool = loadBalancer.InboundNatPools.FirstOrDefault();
            Assert.NotNull(natPool);
            return loadBalancer;
        }
    }
}
