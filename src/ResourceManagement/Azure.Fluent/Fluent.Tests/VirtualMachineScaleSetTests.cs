using Fluent.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Network;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            string vmssName = ResourceNamer.RandomResourceName("vmss", 10);
            string apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-mgmt-compute/src/test/assets/install_apache.sh";
            string installCommand = "bash install_apache.sh Abc.123x(";
            List<string> fileUris = new List<string>();
            fileUris.Add(apacheInstallScript);

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

            ILoadBalancer publicLoadBalancer = CreateHttpLoadBalancers(azure, resourceGroup, "1");
            IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                    .Define(vmssName)
                    .WithRegion(location)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithSku(VirtualMachineScaleSetSkuTypes.STANDARD_A0)
                    .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                    .WithPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                    .WithoutPrimaryInternalLoadBalancer()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                    .WithRootUserName("jvuser")
                    .WithPassword("123OData!@#123")
                    .WithNewStorageAccount(ResourceNamer.RandomResourceName("stg", 15))
                    .WithNewStorageAccount(ResourceNamer.RandomResourceName("stg", 15))
                    .DefineNewExtension("CustomScriptForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("CustomScriptForLinux")
                        .WithVersion("1.4")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("fileUris", fileUris)
                        .WithPublicSetting("commandToExecute", installCommand)
                    .Attach()
                    .Create();

            IList<string> publicIpAddressIds = virtualMachineScaleSet.PrimaryPublicIpAddressIds;
            IPublicIpAddress publicIpAddress = azure.PublicIpAddresses
                    .GetById(publicIpAddressIds[0]);

            string fqdn = publicIpAddress.Fqdn;
            // Assert public load balancing connection
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + fqdn);
            HttpResponseMessage response = client.GetAsync("/").Result;
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public void CanCreateUpdateVirtualMachineScaleSet()
        {
            string vmss_name = ResourceNamer.RandomResourceName("vmss", 10);
            string rgName = ResourceNamer.RandomResourceName("javacsmrg", 20);

            var azure = TestHelper.CreateRollupClient();

            IResourceGroup resourceGroup = azure.ResourceGroups
                .Define(rgName)
                .WithRegion(location)
                .Create();

            INetwork network = azure
                .Networks
                .Define("vmssvnet")
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithAddressSpace("10.0.0.0/28")
                .WithSubnet("subnet1", "10.0.0.0/28")
                .Create();

            ILoadBalancer publicLoadBalancer = createInternetFacingLoadBalancer(azure, resourceGroup, "1");
            List<string> backends = new List<string>();
            foreach (string backend in publicLoadBalancer.Backends.Keys) {
                backends.Add(backend);
            }
            Assert.True(backends.Count() == 2);

            IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                .Define(vmss_name)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithSku(VirtualMachineScaleSetSkuTypes.STANDARD_A0)
                .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                .WithPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                .WithoutPrimaryInternalLoadBalancer()
                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                .WithRootUserName("jvuser")
                .WithPassword("123OData!@#123")
                .WithNewStorageAccount(ResourceNamer.RandomResourceName("stg", 15))
                .WithNewStorageAccount(ResourceNamer.RandomResourceName("stg", 15))
                .Create();

            Assert.Null(virtualMachineScaleSet.GetPrimaryInternalLoadBalancer());
            Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends().Count() == 0);
            Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools().Count() == 0);

            Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer());
            Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends().Count() == 2);
            Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools().Count() == 2);

            Assert.NotNull(virtualMachineScaleSet.GetPrimaryNetwork());

            Assert.Equal(virtualMachineScaleSet.VhdContainers.Count(), 2);
            Assert.Equal(virtualMachineScaleSet.Sku, VirtualMachineScaleSetSkuTypes.STANDARD_A0);
            // Check defaults
            Assert.True(virtualMachineScaleSet.UpgradeModel == UpgradeMode.Automatic);
            Assert.Equal(virtualMachineScaleSet.Capacity, 2);
            // Fetch the primary Virtual network
            INetwork primaryNetwork = virtualMachineScaleSet.GetPrimaryNetwork();
    
            string inboundNatPoolToRemove = null;
            foreach (string inboundNatPoolName in
                virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools().Keys) {
                inboundNatPoolToRemove = inboundNatPoolName;
                break;
            }

            ILoadBalancer internalLoadBalancer = CreateInternalLoadBalancer(azure, resourceGroup,
                primaryNetwork,
                "1");

            virtualMachineScaleSet
                .Update()
                .WithPrimaryInternalLoadBalancer(internalLoadBalancer)
                .WithoutPrimaryInternalLoadBalancerNatPools(inboundNatPoolToRemove)
                .Apply();

            virtualMachineScaleSet = azure
                .VirtualMachineScaleSets
                .GetByGroup(rgName, vmss_name);

            Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternetFacingLoadBalancer());
            Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerBackends().Count() == 2);
            Assert.True(virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools().Count() == 1);

            Assert.NotNull(virtualMachineScaleSet.GetPrimaryInternalLoadBalancer());
            Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerBackends().Count() == 2);
            Assert.True(virtualMachineScaleSet.ListPrimaryInternalLoadBalancerInboundNatPools().Count() == 2);
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
