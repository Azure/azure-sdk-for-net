// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Runtime.CompilerServices;
using Azure.Tests;

namespace Fluent.Tests.Compute
{
    public class VirtualMachineScaleSetTests
    {
        private readonly string location = "eastus";

        [Fact]
        public void CanCreateVirtualMachineScaleSetWithCustomScriptExtension()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("javacsmrg");
                string vmssName = TestUtilities.GenerateName("vmss");
                string apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/Fluent/src/ResourceManagement/Azure.Fluent/Fluent.Tests/Assets/install_apache.sh";
                string installCommand = "bash install_apache.sh";
                List<string> fileUris = new List<string>();
                fileUris.Add(apacheInstallScript);

                var azure = TestHelper.CreateRollupClient();

                IResourceGroup resourceGroup = azure.ResourceGroups
                    .Define(rgName)
                    .WithRegion(location)
                    .Create();

                INetwork network = azure
                    .Networks
                    .Define(TestUtilities.GenerateName("vmssvnet"))
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
                        .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                        .WithRootUsername("jvuser")
                        .WithRootPassword("123OData!@#123")
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                        .WithNewStorageAccount(TestUtilities.GenerateName("stg2"))
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
        }

        [Fact]
        public void CanCreateUpdateVirtualMachineScaleSet()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vmss_name = TestUtilities.GenerateName("vmss");
                string rgName = TestUtilities.GenerateName("javacsmrg");

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
                foreach (string backend in publicLoadBalancer.Backends.Keys)
                {
                    backends.Add(backend);
                }
                Assert.True(backends.Count() == 2);

                IVirtualMachineScaleSet virtualMachineScaleSet = azure.VirtualMachineScaleSets
                    .Define(vmss_name)
                    .WithRegion(location)
                    .WithExistingResourceGroup(resourceGroup)
                    .WithSku(VirtualMachineScaleSetSkuTypes.STANDARD_A0)
                    .WithExistingPrimaryNetworkSubnet(network, "subnet1")
                    .WithExistingPrimaryInternetFacingLoadBalancer(publicLoadBalancer)
                    .WithPrimaryInternetFacingLoadBalancerBackends(backends[0], backends[1])
                    .WithoutPrimaryInternalLoadBalancer()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                    .WithRootUsername("jvuser")
                    .WithRootPassword("123OData!@#123")
                    .WithNewStorageAccount(TestUtilities.GenerateName("stg"))
                    .WithNewStorageAccount(TestUtilities.GenerateName("stg3"))
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
                    virtualMachineScaleSet.ListPrimaryInternetFacingLoadBalancerInboundNatPools().Keys)
                {
                    inboundNatPoolToRemove = inboundNatPoolName;
                    break;
                }

                ILoadBalancer internalLoadBalancer = CreateInternalLoadBalancer(azure, resourceGroup,
                    primaryNetwork,
                    "1");

                virtualMachineScaleSet
                    .Update()
                    .WithExistingPrimaryInternalLoadBalancer(internalLoadBalancer)
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
                CheckInstances(virtualMachineScaleSet);
            }
        }

        private void CheckInstances(IVirtualMachineScaleSet vmScaleSet)
        {
            var virtualMachineScaleSetVMs = vmScaleSet.VirtualMachines;
            var virtualMachines = virtualMachineScaleSetVMs.List();
            Assert.Equal(virtualMachines.Count(), vmScaleSet.Capacity);
            foreach (var vm in virtualMachines)
            {
                Assert.NotNull(vm.Size);
                Assert.Equal(vm.OsType, OperatingSystemTypes.Linux);
                Assert.NotNull(vm.ComputerName.StartsWith(vmScaleSet.ComputerNamePrefix));
                Assert.True(vm.IsLinuxPasswordAuthenticationEnabled);
                Assert.True(vm.IsOsBasedOnPlatformImage);
                Assert.Null(vm.CustomImageVhdUri);
                Assert.False(vm.IsWindowsAutoUpdateEnabled);
                Assert.False(vm.IsWindowsVmAgentProvisioned);
                Assert.True(vm.AdministratorUserName.Equals("jvuser", StringComparison.OrdinalIgnoreCase));
                var vmImage = vm.GetPlatformImage();
                Assert.NotNull(vmImage);
                Assert.Equal(vm.Extensions.Count(), vmScaleSet.Extensions.Count);
                Assert.NotNull(vm.PowerState);
                vm.RefreshInstanceView();
            }
            // Check actions
            var virtualMachineScaleSetVM = virtualMachines.FirstOrDefault();
            Assert.NotNull(virtualMachineScaleSetVM);
            virtualMachineScaleSetVM.Restart();
            virtualMachineScaleSetVM.PowerOff();
            virtualMachineScaleSetVM.RefreshInstanceView();
            Assert.Equal(virtualMachineScaleSetVM.PowerState, PowerState.STOPPED);
            virtualMachineScaleSetVM.Start();
        }


        private ILoadBalancer createInternetFacingLoadBalancer(Microsoft.Azure.Management.Fluent.IAzure azure, IResourceGroup resourceGroup, string id, [CallerMemberName] string methodName = "testframework_failed")
        {
            string loadBalancerName = TestUtilities.GenerateName("extlb" + id + "-", methodName);
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
            ILoadBalancerHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            ILoadBalancerHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            Assert.Equal(loadBalancer.InboundNatPools.Count(), 2);
            return loadBalancer;
        }

        private ILoadBalancer CreateInternalLoadBalancer(Microsoft.Azure.Management.Fluent.IAzure azure, IResourceGroup resourceGroup,
                                                INetwork network, string id, [CallerMemberName] string methodName = "testframework_failed")
        {
            string loadBalancerName = TestUtilities.GenerateName("InternalLb" + id + "-", methodName);
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
            ILoadBalancerBackend backend1 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName1, out backend1));
            ILoadBalancerBackend backend2 = null;
            Assert.True(loadBalancer.Backends.TryGetValue(backendPoolName2, out backend2));
            ILoadBalancerHttpProbe httpProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpProbe", out httpProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            ILoadBalancerHttpProbe httpsProbe = null;
            Assert.True(loadBalancer.HttpProbes.TryGetValue("httpsProbe", out httpsProbe));
            Assert.Equal(httpProbe.LoadBalancingRules.Count(), 1);
            Assert.Equal(loadBalancer.InboundNatPools.Count(), 2);
            return loadBalancer;
        }

        private ILoadBalancer CreateHttpLoadBalancers(Microsoft.Azure.Management.Fluent.IAzure azure, IResourceGroup resourceGroup, string id, [CallerMemberName] string methodName = "testframework_failed")
        {
            string loadBalancerName = TestUtilities.GenerateName("extlb" + id + "-", methodName);
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
