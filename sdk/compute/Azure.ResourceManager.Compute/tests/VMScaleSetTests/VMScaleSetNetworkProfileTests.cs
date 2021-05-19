// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetNetworkProfileTests : VMScaleSetTestsBase
    {
        public VMScaleSetNetworkProfileTests(bool isAsync)
        : base(isAsync)
        {
        }
        /// <summary>
        /// Associates a VMScaleSet to an Application gateway
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithApplciationGateway()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var gatewaySubnet = vnetResponse.Subnets[0];
            var vmssSubnet = vnetResponse.Subnets[1];
            ApplicationGateway appgw = await CreateApplicationGateway(rgName, gatewaySubnet);
            Azure.ResourceManager.Compute.Models.SubResource backendAddressPool = new Azure.ResourceManager.Compute.Models.SubResource()
            {
                Id = appgw.BackendAddressPools[0].Id
            };

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                            .NetworkInterfaceConfigurations[0].IpConfigurations[0]
                            .ApplicationGatewayBackendAddressPools.Add(backendAddressPool),
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var getGwResponse = (await ApplicationGatewaysOperations.GetAsync(rgName, appgw.Name)).Value;
            Assert.True(2 == getGwResponse.BackendAddressPools[0].BackendIPConfigurations.Count);
            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with DnsSettings
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithDnsSettings()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];

            var nicDnsSettings = new VirtualMachineScaleSetNetworkConfigurationDnsSettings()
            {
                DnsServers = { "10.0.0.5", "10.0.0.6" }
            };

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                            .NetworkInterfaceConfigurations[0].DnsSettings = nicDnsSettings,
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings);
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers);
            Assert.AreEqual(2, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers.Count);
            //bool containFive = false;
            //bool containSix = false;
            //foreach (var detail in vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers)
            //{
            //    if(detail.)
            //}
            //Assert.Contains(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers, ip => string.Equals("10.0.0.5", ip));
            //Assert.Contains(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers, ip => string.Equals("10.0.0.6", ip));
            //Assert.Contains(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers, ip => string.Equals("10.0.0.5", ip));
            //Assert.Contains(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].DnsSettings.DnsServers, ip => string.Equals("10.0.0.6", ip));
            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with PublicIp
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithPublicIP()
        {
            EnsureClientsInitialized(LocationWestCentralUs);
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            var dnsname = Recording.GenerateAssetName("dnsname");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            // Hard code the location to "westcentralus".
            // This is because NRP is still deploying to other regions and is not available worldwide.
            // Before changing the default location, we have to save it to be reset it at the end of the test.
            // Since ComputeManagementTestUtilities.DefaultLocation is a static variable and can affect other tests if it is not reset.

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];

            var publicipConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration("pip1");
            publicipConfiguration.IdleTimeoutInMinutes = 10;
            publicipConfiguration.DnsSettings = new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(dnsname);

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                            .NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicipConfiguration,
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
            Assert.NotNull(vmss.Value.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration);
            Assert.AreEqual("pip1", vmss.Value.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.Name);
            Assert.AreEqual(10, vmss.Value.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IdleTimeoutInMinutes);
            Assert.NotNull(vmss.Value.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings);
            Assert.AreEqual(dnsname, vmss.Value.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings.DomainNameLabel);
            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with PublicIp with Ip tags
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record because of ex '[4:46 PM] Lipeng You (Wicresoft North America Ltd)'message': 'Subscription /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups//providers/Microsoft.Network/subscriptions/ is not registered for feature Microsoft.Network/AllowBringYourOwnPublicIpAddress required to carry out the requested operation.'")]
        public async Task TestVMScaleSetWithPublicIPAndIPTags()
        {
            EnsureClientsInitialized(LocationWestCentralUs);
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            var dnsname = Recording.GenerateAssetName("dnsname");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            bool passed = false;
            // Hard code the location to "westcentralus".
            // This is because NRP is still deploying to other regions and is not available worldwide.
            // Before changing the default location, we have to save it to be reset it at the end of the test.
            // Since ComputeManagementTestUtilities.DefaultLocation is a static variable and can affect other tests if it is not reset.

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];

            var publicipConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration("pip1");
            //publicipConfiguration.Name = "pip1";
            publicipConfiguration.IdleTimeoutInMinutes = 10;
            publicipConfiguration.DnsSettings = new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(dnsname);
            //publicipConfiguration.DnsSettings.DomainNameLabel = dnsname;

            publicipConfiguration.IpTags.Add(new VirtualMachineScaleSetIpTag("FirstPartyUsage", "/Sql"));

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                            .NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicipConfiguration,
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;

            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration);
            Assert.AreEqual("pip1", vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.Name);
            Assert.AreEqual(10, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IdleTimeoutInMinutes);
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings);
            Assert.AreEqual(dnsname, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings.DomainNameLabel);
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags);
            Assert.AreEqual("FirstPartyUsage", vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].IpTagType);
            Assert.AreEqual("/Sql", vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IpTags[0].Tag);

            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with PublicIp with Ip prefix
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithPublicIPAndPublicIPPrefix()
        {
            EnsureClientsInitialized(LocationWestCentralUs);
            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            var dnsname = Recording.GenerateAssetName("dnsname");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];
            var publicIpPrefix = await CreatePublicIPPrefix(rgName, 30);

            var publicipConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration("pip1");
            publicipConfiguration.IdleTimeoutInMinutes = 10;
            publicipConfiguration.DnsSettings = new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(dnsname);
            publicipConfiguration.PublicIPPrefix = new Azure.ResourceManager.Compute.Models.SubResource();
            publicipConfiguration.PublicIPPrefix.Id = publicIpPrefix.Id;

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                            .NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicipConfiguration,
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration);
            Assert.AreEqual("pip1", vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.Name);
            Assert.AreEqual(10, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.IdleTimeoutInMinutes);
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings);
            Assert.AreEqual(dnsname, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.DnsSettings.DomainNameLabel);
            Assert.AreEqual(publicIpPrefix.Id, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration.PublicIPPrefix.Id);
            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with Nsg
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithnNsg()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            var dnsname = Recording.GenerateAssetName("dnsname");
            var nsgname = Recording.GenerateAssetName("nsg");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];
            var nsg = await CreateNsg(rgName, nsgname);

            Azure.ResourceManager.Compute.Models.SubResource nsgId = new Azure.ResourceManager.Compute.Models.SubResource()
            {
                Id = nsg.Id
            };

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                            .NetworkInterfaceConfigurations[0].NetworkSecurityGroup = nsgId,
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.NotNull(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].NetworkSecurityGroup);
            Assert.AreEqual(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].NetworkSecurityGroup.Id, nsg.Id);

            var getNsgResponse = (await NetworkSecurityGroupsOperations.GetAsync(rgName, nsg.Name)).Value;
            Assert.AreEqual(2, getNsgResponse.NetworkInterfaces.Count);

            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with ipv6
        /// </summary>
        [Test]
        public async Task TestVMScaleSetWithnIpv6()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            var dnsname = Recording.GenerateAssetName("dnsname");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];

            var ipv6ipconfig = new VirtualMachineScaleSetIPConfiguration("ipv6");
            ipv6ipconfig.Name = "ipv6";
            ipv6ipconfig.PrivateIPAddressVersion = Azure.ResourceManager.Compute.Models.IPVersion.IPv6;

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                    {
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                          .NetworkInterfaceConfigurations[0].IpConfigurations[0].PrivateIPAddressVersion = Azure.ResourceManager.Compute.Models.IPVersion.IPv4;
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                          .NetworkInterfaceConfigurations[0].IpConfigurations.Add(ipv6ipconfig);
                    },
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.AreEqual(2, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count);

            passed = true;
            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with multiple IPConfigurations on a single NIC
        /// </summary>
        [Test]
        public async Task TestVMSSWithMultiCA()
        {
            EnsureClientsInitialized(LocationWestCentralUs);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];

            var secondaryCA =
                new VirtualMachineScaleSetIPConfiguration(Recording.GenerateAssetName("vmsstestnetconfig"))
                {
                    Subnet = new ApiEntityReference() { Id = vmssSubnet.Id }
                };

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                    {
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Primary = true;
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Add(secondaryCA);
                    },
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.AreEqual(2, vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count);
            Assert.True(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations.Count(ip => ip.Primary == true) == 1);

            passed = true;

            Assert.True(passed);
        }

        /// <summary>
        /// Associates a VMScaleSet with a NIC that has accelerated networking enabled.
        /// </summary>
        [Test]
        public async Task TestVMSSAccelNtwkng()
        {
            EnsureClientsInitialized(LocationWestCentralUs);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var vmssName = Recording.GenerateAssetName("vmss");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;
            bool passed = false;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);
            var vnetResponse = await CreateVNETWithSubnets(rgName, 2);
            var vmssSubnet = vnetResponse.Subnets[1];

            var getTwoVirtualMachineScaleSet = await CreateVMScaleSet_NoAsyncTracking(
                rgName: rgName,
                vmssName: vmssName,
                storageAccount: storageAccountOutput,
                imageRef: imageRef,
                vmScaleSetCustomizer:
                    (virtualMachineScaleSet) =>
                    {
                        virtualMachineScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardDS11V2.ToString();
                        virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].EnableAcceleratedNetworking = true;
                    },
                createWithPublicIpAddress: false,
                subnet: vmssSubnet);
            VirtualMachineScaleSet vmScaleSet = getTwoVirtualMachineScaleSet.Item1;
            inputVMScaleSet = getTwoVirtualMachineScaleSet.Item2;
            var vmss = (await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName)).Value;
            Assert.True(vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].EnableAcceleratedNetworking == true);
            passed = true;
            Assert.True(passed);
        }
    }
}
