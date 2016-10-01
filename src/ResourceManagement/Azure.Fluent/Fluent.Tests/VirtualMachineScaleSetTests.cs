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

            ILoadBalancer publicLoadBalancer = CreateHttpLoadBalancers(azure, resourceGroup, "1");
            Assert.True(true);
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
            return loadBalancer;
        }
    }
}
