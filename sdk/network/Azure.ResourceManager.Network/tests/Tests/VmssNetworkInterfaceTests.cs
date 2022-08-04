// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if false
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
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

            string location = TestEnvironment.Location;
            string deploymentName = Recording.GenerateAssetName("vmss");
            var resourceGroup = CreateResourceGroup(resourceGroupName, location);

            await CreateVmss(ResourceManagementClient, resourceGroupName, deploymentName);

            string virtualMachineScaleSetName = "vmssip";
            AsyncPageable<PublicIPAddressResource> vmssListAllPageResultAP = NetworkManagementClient.PublicIPAddresses.GetVirtualMachineScaleSetPublicIPAddressesAsync(resourceGroupName, virtualMachineScaleSetName);
            List<PublicIPAddressResource> vmssListAllPageResult = await vmssListAllPageResultAP.ToEnumerableAsync();
            List<PublicIPAddressResource> vmssListAllResult = vmssListAllPageResult.ToList();
            PublicIPAddressResource firstResult = vmssListAllResult.First();

            Assert.NotNull(vmssListAllResult);
            Assert.AreEqual("Succeeded", firstResult.ProvisioningState.ToString());
            Assert.NotNull(firstResult.ResourceGuid);

            string idItem = firstResult.Id;
            string vmIndex = GetNameById(idItem, "virtualMachines");
            string nicName = GetNameById(idItem, "networkInterfaces");

            // Verify that NICs contain refernce to publicip, nsg and dns settings
            AsyncPageable<NetworkInterfaceResource> listNicPerVmssAP = NetworkManagementClient.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterfacesAsync(resourceGroupName, virtualMachineScaleSetName);
            List<NetworkInterfaceResource> listNicPerVmss = await listNicPerVmssAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVmss);

            foreach (NetworkInterfaceResource nic in listNicPerVmss)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify nics on a vm level
            AsyncPageable<NetworkInterfaceResource> listNicPerVmAP = NetworkManagementClient.NetworkInterfaces.GetVirtualMachineScaleSetVMNetworkInterfacesAsync(resourceGroupName, virtualMachineScaleSetName, vmIndex);
            List<NetworkInterfaceResource> listNicPerVm = await listNicPerVmAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVm);
            Has.One.EqualTo(listNicPerVm);

            foreach (NetworkInterfaceResource nic in listNicPerVm)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify getting individual nic
            Response<NetworkInterfaceResource> getNic = await NetworkManagementClient.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterfaceAsync(resourceGroupName, virtualMachineScaleSetName, vmIndex, nicName);
            Assert.NotNull(getNic);
            VerifyVmssNicProperties(getNic);
        }

        private void VerifyVmssNicProperties(NetworkInterfaceResource nic)
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
#endif
