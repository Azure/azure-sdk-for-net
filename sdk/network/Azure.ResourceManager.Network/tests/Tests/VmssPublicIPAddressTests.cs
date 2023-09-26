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
    public class VmssPublicIpAddressTests : NetworkServiceClientTestBase
    {
        public VmssPublicIpAddressTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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
        public async Task VmssPublicIpAddressApiTest()
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
            string ipConfigName = GetNameById(idItem, "ipConfigurations");
            string ipName = GetNameById(idItem, "publicIPAddresses");

            var vmssVmId = VirtualMachineScaleSetVmNetworkResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, resourceGroupName, virtualMachineScaleSetName, vmIndex);
            var vmssListResult = await ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetAllPublicIPAddressDataAsync(nicName, ipConfigName).ToEnumerableAsync();

            Has.One.EqualTo(vmssListResult);

            var vmssGetResult = await ArmClient.GetVirtualMachineScaleSetVmNetworkResource(vmssVmId).GetPublicIPAddressDataAsync(nicName, ipConfigName, ipName);

            Assert.NotNull(vmssGetResult);
            Assert.AreEqual("Succeeded", vmssGetResult.Value.ProvisioningState.ToString());
            Assert.NotNull(vmssGetResult.Value.ResourceGuid);
        }
    }
}
