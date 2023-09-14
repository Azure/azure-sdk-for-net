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
            var vmssListAllPageResultAP = ArmClient.GetVirtualMachineScaleSetNetworkResource(vmssId).GetPublicIPAddressesVirtualMachineScaleSetsAsync();
            var vmssListAllPageResult = await vmssListAllPageResultAP.ToEnumerableAsync();
            var firstResult = vmssListAllPageResult.First();

            Assert.NotNull(vmssListAllPageResult);
            Assert.AreEqual("Succeeded", firstResult.Data.ProvisioningState.ToString());
            Assert.NotNull(firstResult.Data.ResourceGuid);

            string idItem = firstResult.Id;
            string vmIndex = GetNameById(idItem, "virtualMachines");
            string nicName = GetNameById(idItem, "networkInterfaces");

            // Verify that NICs contain refernce to publicip, nsg and dns settings
            var listNicPerVmssAP = ArmClient.GetVirtualMachineScaleSetNetworkResource(vmssId).GetNetworkInterfacesVirtualMachineScaleSetsAsync();
            var listNicPerVmss = await listNicPerVmssAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVmss);

            foreach (var nic in listNicPerVmss)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify nics on a vm level
            var vmssVmId = VirtualMachineScaleSetVmNetworkResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, resourceGroupName, virtualMachineScaleSetName, vmIndex);
            var listNicPerVmAP = ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetNetworkInterfacesVirtualMachineScaleSetVMsAsync();
            var listNicPerVm = await listNicPerVmAP.ToEnumerableAsync();
            Assert.NotNull(listNicPerVm);
            Has.One.EqualTo(listNicPerVm);

            foreach (var nic in listNicPerVm)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify getting individual nic
            var getNic = await ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetNetworkInterfaceVirtualMachineScaleSetAsync(nicName);
            Assert.NotNull(getNic);
            VerifyVmssNicProperties(getNic);
        }

        private void VerifyVmssNicProperties(NetworkInterfaceResource nic)
        {
            Assert.NotNull(nic.Data.NetworkSecurityGroup);
            Assert.False(string.IsNullOrEmpty(nic.Data.NetworkSecurityGroup.Id));
            Assert.NotNull(nic.Data.DnsSettings);
            Assert.NotNull(nic.Data.DnsSettings.DnsServers);
            Assert.AreEqual(1, nic.Data.DnsSettings.DnsServers.Count);
            Assert.NotNull(nic.Data.IPConfigurations[0].PublicIPAddress);
            Assert.False(string.IsNullOrEmpty(nic.Data.IPConfigurations[0].PublicIPAddress.Id));
        }
    }
}
