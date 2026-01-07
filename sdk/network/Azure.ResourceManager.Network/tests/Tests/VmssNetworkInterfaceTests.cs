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

            Assert.That(vmssListAllPageResult, Is.Not.Null);
            Assert.That(firstResult.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(firstResult.ResourceGuid, Is.Not.Null);

            string idItem = firstResult.Id;
            string vmIndex = GetNameById(idItem, "virtualMachines");
            string nicName = GetNameById(idItem, "networkInterfaces");

            // Verify that NICs contain refernce to publicip, nsg and dns settings
            var listNicPerVmssAP = ArmClient.GetVirtualMachineScaleSetNetworkResource(vmssId).GetAllNetworkInterfaceDataAsync();
            var listNicPerVmss = await listNicPerVmssAP.ToEnumerableAsync();
            Assert.That(listNicPerVmss, Is.Not.Null);

            foreach (var nic in listNicPerVmss)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify nics on a vm level
            var vmssVmId = VirtualMachineScaleSetVmNetworkResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, resourceGroupName, virtualMachineScaleSetName, vmIndex);
            var listNicPerVmAP = ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetAllNetworkInterfaceDataAsync();
            var listNicPerVm = await listNicPerVmAP.ToEnumerableAsync();
            Assert.That(listNicPerVm, Is.Not.Null);
            Has.One.EqualTo(listNicPerVm);

            foreach (var nic in listNicPerVm)
            {
                VerifyVmssNicProperties(nic);
            }

            // Verify getting individual nic
            var getNic = await ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetNetworkInterfaceDataAsync(nicName);
            Assert.That(getNic, Is.Not.Null);
            VerifyVmssNicProperties(getNic);
        }

        private void VerifyVmssNicProperties(NetworkInterfaceData nic)
        {
            Assert.That(nic.NetworkSecurityGroup, Is.Not.Null);
            Assert.That(string.IsNullOrEmpty(nic.NetworkSecurityGroup.Id), Is.False);
            Assert.That(nic.DnsSettings, Is.Not.Null);
            Assert.That(nic.DnsSettings.DnsServers, Is.Not.Null);
            Assert.That(nic.DnsSettings.DnsServers.Count, Is.EqualTo(1));
            Assert.That(nic.IPConfigurations[0].PublicIPAddress, Is.Not.Null);
            Assert.That(string.IsNullOrEmpty(nic.IPConfigurations[0].PublicIPAddress.Id), Is.False);
        }
    }
}
