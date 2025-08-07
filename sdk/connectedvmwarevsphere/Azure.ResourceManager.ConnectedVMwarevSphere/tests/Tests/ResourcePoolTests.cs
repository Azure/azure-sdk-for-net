// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class ResourcePoolTests: ConnectedVMwareTestBase
    {
        public ResourcePoolTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ResourcePool_Create_Get_Exists_GetIfExists_List_Delete()
        {
            VMwareResourcePoolCollection collection = DefaultResourceGroup.GetVMwareResourcePools();

            // Create
            string resourcePoolName = Recording.GenerateAssetName("resourcepool");
            VMwareResourcePoolData data = new VMwareResourcePoolData(DefaultLocation)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/resgroup-724471",
            };
            ArmOperation<VMwareResourcePoolResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourcePoolName, data);
            VMwareResourcePoolResource resourcePool = lro.Value;
            Assert.IsNotNull(resourcePool);
            VMwareResourcePoolData resourceData = resourcePool.Data;
            Assert.AreEqual(resourceData.Name, resourcePoolName);

            // Get
            VMwareResourcePoolResource result = await collection.GetAsync(resourcePoolName);
            Assert.IsNotNull(result);

            // Check exists
            bool isExist = await collection.ExistsAsync(resourcePoolName);
            Assert.IsTrue(isExist);

            // Get if exists
            NullableResponse<VMwareResourcePoolResource> response = await collection.GetIfExistsAsync(resourcePoolName);
            result = response.HasValue ? response.Value : null;
            Assert.IsNotNull(result);

            // List
            isExist = false;
            await foreach (VMwareResourcePoolResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == resourcePoolName)
                    isExist = true;
            }
            Assert.IsTrue(isExist);

            // Delete
            await resourcePool.DeleteAsync(WaitUntil.Completed);
        }
    }
}
