// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class VmssNetworkInterfaceTests : NetworkTestsManagementClientBase
    {
        public VmssNetworkInterfaceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private static string GetNameById(string Id, string resourceType)
        {
            string name = Id.Substring(Id.IndexOf(resourceType + '/') + resourceType.Length + 1);
            if (name.IndexOf('/') != -1)
            {
                name = name.Substring(0, name.IndexOf('/'));
            }
            return name;
        }

        [Test]
        public async Task VmssNetworkInterfaceApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Compute/virtualMachineScaleSets");
            string deploymentName = Recording.GenerateAssetName("vmss");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            await CreateVmss(ResourceManagementClient, resourceGroupName, deploymentName);

            string virtualMachineScaleSetName = "vmssip";
            AsyncPageable<PublicIPAddress> vmssListAllPageResultAP = NetworkManagementClient.PublicIPAddresses.ListVirtualMachineScaleSetPublicIPAddressesAsync(resourceGroupName, virtualMachineScaleSetName);
            List<PublicIPAddress> vmssListAllPageResult = await vmssListAllPageResultAP.ToEnumerableAsync();
            List<PublicIPAddress> vmssListAllResult = vmssListAllPageResult.ToList();
            PublicIPAddress firstResult = vmssListAllResult.First();

            Assert.NotNull(vmssListAllResult);
            Assert.AreEqual("Succeeded", firstResult.ProvisioningState.ToString());
            Assert.NotNull(firstResult.ResourceGuid);

            string idItem = firstResult.Id;
            string vmIndex = GetNameById(idItem, "virtualMachines");
            string nicName = GetNameById(idItem, "networkInterfaces");

            // Verify that NICs contain refernce to publicip, nsg and dns settings
            AsyncPageable<NetworkInterface> listNicPerVmssAP = NetworkManagementClient.NetworkInterfaces.ListVirtualMachineScaleSetNetworkInterfacesAsync(resourceGroupName, virtualMachineScaleSetName);
            List<NetworkInterface> listNicPerVmss = await listNicPerVmssAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVmss);

            foreach (NetworkInterface nic in listNicPerVmss)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify nics on a vm level
            AsyncPageable<NetworkInterface> listNicPerVmAP = NetworkManagementClient.NetworkInterfaces.ListVirtualMachineScaleSetVMNetworkInterfacesAsync(resourceGroupName, virtualMachineScaleSetName, vmIndex);
            List<NetworkInterface> listNicPerVm = await listNicPerVmAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVm);
            Has.One.EqualTo(listNicPerVm);

            foreach (NetworkInterface nic in listNicPerVm)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify getting individual nic
            Response<NetworkInterface> getNic = await NetworkManagementClient.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterfaceAsync(resourceGroupName, virtualMachineScaleSetName, vmIndex, nicName);
            Assert.NotNull(getNic);
            VerifyVmssNicProperties(getNic);
        }

        private void VerifyVmssNicProperties(NetworkInterface nic)
        {
            Assert.NotNull(nic.NetworkSecurityGroup);
            Assert.False(string.IsNullOrEmpty(nic.NetworkSecurityGroup.Id));
            Assert.NotNull(nic.DnsSettings);
            Assert.NotNull(nic.DnsSettings.DnsServers);
            Assert.AreEqual(1, nic.DnsSettings.DnsServers.Count);
            Assert.NotNull(nic.IpConfigurations[0].PublicIPAddress);
            Assert.False(string.IsNullOrEmpty(nic.IpConfigurations[0].PublicIPAddress.Id));
        }
    }
}
