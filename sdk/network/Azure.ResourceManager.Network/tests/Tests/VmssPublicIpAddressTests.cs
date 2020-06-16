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
    public class VmssPublicIpAddressTests : NetworkTestsManagementClientBase
    {
        public VmssPublicIpAddressTests(bool isAsync) : base(isAsync)
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
        public async Task VmssPublicIpAddressApiTest()
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
            string ipConfigName = GetNameById(idItem, "ipConfigurations");
            string ipName = GetNameById(idItem, "publicIPAddresses");

            AsyncPageable<PublicIPAddress> vmssListPageResultAP = NetworkManagementClient.PublicIPAddresses.ListVirtualMachineScaleSetVMPublicIPAddressesAsync(
                resourceGroupName, virtualMachineScaleSetName, vmIndex, nicName, ipConfigName);
            List<PublicIPAddress> vmssListPageResult = await vmssListPageResultAP.ToEnumerableAsync();
            List<PublicIPAddress> vmssListResult = vmssListPageResult.ToList();

            Has.One.EqualTo(vmssListResult);

            Response<PublicIPAddress> vmssGetResult = await NetworkManagementClient.PublicIPAddresses.GetVirtualMachineScaleSetPublicIPAddressAsync(
                resourceGroupName, virtualMachineScaleSetName, vmIndex, nicName, ipConfigName, ipName);

            Assert.NotNull(vmssGetResult);
            Assert.AreEqual("Succeeded", vmssGetResult.Value.ProvisioningState.ToString());
            Assert.NotNull(vmssGetResult.Value.ResourceGuid);
        }
    }
}
