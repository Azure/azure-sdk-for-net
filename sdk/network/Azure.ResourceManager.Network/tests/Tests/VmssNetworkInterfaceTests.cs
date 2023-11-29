// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class VmssNetworkInterfaceTests : NetworkServiceClientTestBase
    {
        public VmssNetworkInterfaceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");
            string location = TestEnvironment.Location;
            string deploymentName = Recording.GenerateAssetName("vmss");
            var resourceGroup = CreateResourceGroup(resourceGroupName, location).Result;

            await CreateVmss(resourceGroup, deploymentName);

            string virtualMachineScaleSetName = "vmssip";
            var vmssId = VirtualMachineScaleSetNetworkResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, resourceGroupName, virtualMachineScaleSetName);
            var vmssListAllPageResultAP = ArmClient.GetVirtualMachineScaleSetNetworkResource(vmssId).GetAllPublicIPAddressDataAsync();
            var vmssListAllPageResult = await vmssListAllPageResultAP.ToEnumerableAsync();
            var firstResult = vmssListAllPageResult.First();

            Assert.NotNull(vmssListAllPageResult);
            Assert.AreEqual("Succeeded", firstResult.ProvisioningState.ToString());
            Assert.NotNull(firstResult.ResourceGuid);

            string idItem = firstResult.Id;
            string vmIndex = GetNameById(idItem, "virtualMachines");
            string nicName = GetNameById(idItem, "networkInterfaces");

            // Verify that NICs contain refernce to publicip, nsg and dns settings
            var listNicPerVmssAP = ArmClient.GetVirtualMachineScaleSetNetworkResource(vmssId).GetAllNetworkInterfaceDataAsync();
            var listNicPerVmss = await listNicPerVmssAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVmss);

            foreach (var nic in listNicPerVmss)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify nics on a vm level
            var vmssVmId = VirtualMachineScaleSetVmNetworkResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, resourceGroupName, virtualMachineScaleSetName, vmIndex);
            var listNicPerVmAP = ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetAllNetworkInterfaceDataAsync();
            var listNicPerVm = await listNicPerVmAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVm);
            Has.One.EqualTo(listNicPerVm);

            foreach (var nic in listNicPerVm)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify getting individual nic
            var getNic = await ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetNetworkInterfaceDataAsync(nicName);
            Assert.NotNull(getNic);
            VerifyVmssNicProperties(getNic);
        }

        private void VerifyVmssNicProperties(NetworkInterfaceData nic)
        {
            Assert.NotNull(nic.NetworkSecurityGroup);
            Assert.False(string.IsNullOrEmpty(nic.NetworkSecurityGroup.Id));
            Assert.NotNull(nic.DnsSettings);
            Assert.NotNull(nic.DnsSettings.DnsServers);
            Assert.AreEqual(1, nic.DnsSettings.DnsServers.Count);
            Assert.NotNull(nic.IPConfigurations[0].PublicIPAddress);
            Assert.False(string.IsNullOrEmpty(nic.IPConfigurations[0].PublicIPAddress.Id));
        }
    }
}
