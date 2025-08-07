// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class VirtualNetworkTests : ConnectedVMwareTestBase
    {
        public VirtualNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        // CreateVirtualNetwork
        [TestCase]
        [RecordedTest]
        public async Task VirtualNetwork_Create_Get_Exists_GetIfExists_List_Delete()
        {
            VMwareVirtualNetworkCollection collection = DefaultResourceGroup.GetVMwareVirtualNetworks();

            // Create
            string virtualNetworkName = Recording.GenerateAssetName("vmnetwork");
            VMwareVirtualNetworkData data = new VMwareVirtualNetworkData(new AzureLocation("East US"))
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/network-563661",
            };
            ArmOperation<VMwareVirtualNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, data);
            VMwareVirtualNetworkResource virtualNetwork = lro.Value;
            Assert.IsNotNull(virtualNetwork);
            VMwareVirtualNetworkData resourceData = virtualNetwork.Data;
            Assert.AreEqual(resourceData.Name, virtualNetworkName);

            // Get
            VMwareVirtualNetworkResource result = await collection.GetAsync(virtualNetworkName);
            Assert.IsNotNull(result);

            // Check exists
            bool isExist = await collection.ExistsAsync(virtualNetworkName);
            Assert.IsTrue(isExist);

            // Get if exists
            NullableResponse<VMwareVirtualNetworkResource> response = await collection.GetIfExistsAsync(virtualNetworkName);
            result = response.HasValue ? response.Value : null;
            Assert.IsNotNull(result);

            // List
            isExist = false;
            await foreach (VMwareVirtualNetworkResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == virtualNetworkName)
                    isExist = true;
            }
            Assert.IsTrue(isExist);

            // Delete
            await virtualNetwork.DeleteAsync(WaitUntil.Completed);
        }
    }
}
