// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetNetworkProfileTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Associates a VMScaleSet to an Application gateway
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithApplciationGateway()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var gatewaySubnet = vnetResponse.Subnets[0];
                    var vmssSubnet = vnetResponse.Subnets[1];
                    ApplicationGateway appgw = CreateApplicationGateway(rgName, gatewaySubnet);
                    Microsoft.Azure.Management.Compute.Models.SubResource backendAddressPool = new Microsoft.Azure.Management.Compute.Models.SubResource()
                    {
                        Id = appgw.BackendAddressPools[0].Id
                    };

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].IpConfigurations[0]
                                    .ApplicationGatewayBackendAddressPools.Add(backendAddressPool),
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var getGwResponse = m_NrpClient.ApplicationGateways.Get(rgName, appgw.Name);
                    Assert.True(2 == getGwResponse.BackendAddressPools[0].BackendIPConfigurations.Count);
                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Associates a VMScaleSet with DnsSettings
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithDnsSettings()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];

                    var nicDnsSettings = new VirtualMachineScaleSetNetworkConfigurationDnsSettings();
                    nicDnsSettings.DnsServers = new List<string>() { "10.0.0.5", "10.0.0.6" };

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].DnsSettings = nicDnsSettings,
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var vmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings);
                    Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers);
                    Assert.Equal(2, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers.Count);
                    Assert.Contains(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers, ip => string.Equals("10.0.0.5", ip));
                    Assert.Contains(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers, ip => string.Equals("10.0.0.6", ip));
                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Associates a VMScaleSet with PublicIp
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithPublicIP()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Hard code the location to "westcentralus".
                // This is because NRP is still deploying to other regions and is not available worldwide.
                // Before changing the default location, we have to save it to be reset it at the end of the test.
                // Since ComputeManagementTestUtilities.DefaultLocation is a static variable and can affect other tests if it is not reset.
                var originallocation = ComputeManagementTestUtilities.DefaultLocation;
                ComputeManagementTestUtilities.DefaultLocation = "westcentralus";
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                var dnsname = TestUtilities.GenerateName("dnsname");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];

                    var publicipConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration();
                    publicipConfiguration.Name = "pip1";
                    publicipConfiguration.IdleTimeoutInMinutes = 10;
                    publicipConfiguration.DnsSettings = new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings();
                    publicipConfiguration.DnsSettings.DomainNameLabel = dnsname;

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicipConfiguration,
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var vmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration);
                    Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings);
                    Assert.Equal(dnsname, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings.DomainNameLabel);
                    Assert.Equal("pip1", vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.Name);
                    Assert.Equal(10, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IdleTimeoutInMinutes);
                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                    ComputeManagementTestUtilities.DefaultLocation = originallocation;
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Associates a VMScaleSet with Nsg
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithnNsg()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                var dnsname = TestUtilities.GenerateName("dnsname");
                var nsgname = TestUtilities.GenerateName("nsg");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];
                    var nsg = CreateNsg(rgName, nsgname);

                    Microsoft.Azure.Management.Compute.Models.SubResource nsgId = new Microsoft.Azure.Management.Compute.Models.SubResource()
                    {
                        Id = nsg.Id
                    };

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].NetworkSecurityGroup = nsgId,
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var vmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].NetworkSecurityGroup);
                    Assert.Equal(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].NetworkSecurityGroup.Id, nsg.Id, StringComparer.OrdinalIgnoreCase);

                    var getNsgResponse = m_NrpClient.NetworkSecurityGroups.Get(rgName, nsg.Name);
                    Assert.Equal(2, getNsgResponse.NetworkInterfaces.Count);

                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Associates a VMScaleSet with ipv6
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithnIpv6()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                var dnsname = TestUtilities.GenerateName("dnsname");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];

                    var ipv6ipconfig = new VirtualMachineScaleSetIPConfiguration();
                    ipv6ipconfig.Name = "ipv6";
                    ipv6ipconfig.PrivateIPAddressVersion = Microsoft.Azure.Management.Compute.Models.IPVersion.IPv6;

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                                {
                                    virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                      .NetworkInterfaceConfigurations[0].IpConfigurations[0].PrivateIPAddressVersion = Microsoft.Azure.Management.Compute.Models.IPVersion.IPv4;
                                    virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                      .NetworkInterfaceConfigurations[0].IpConfigurations.Add(ipv6ipconfig);
                                },
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var vmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    Assert.Equal(2, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count);

                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Associates a VMScaleSet with multiple IPConfigurations on a single NIC
        /// </summary>
        [Fact]
        public void TestVMSSWithMultiCA()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];

                    var secondaryCA =
                        new VirtualMachineScaleSetIPConfiguration(
                            name: TestUtilities.GenerateName("vmsstestnetconfig"),
                            subnet: new ApiEntityReference() { Id = vmssSubnet.Id });

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                            {
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Primary = true;
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Add(secondaryCA);
                            },
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var vmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    Assert.Equal(2, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count);
                    Assert.True(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count(ip => ip.Primary == true) == 1);

                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }

        /// <summary>
        /// Associates a VMScaleSet with a NIC that has accelerated networking enabled.
        /// </summary>
        [Fact]
        public void TestVMSSAccelNtwkng()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) =>
                            {
                                virtualMachineScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardDS15V2;
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].EnableAcceleratedNetworking = true;
                            },
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet);

                    var vmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    Assert.True(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].EnableAcceleratedNetworking == true);

                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }
    }
}