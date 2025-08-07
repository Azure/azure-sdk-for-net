// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class DatastoreTests : ConnectedVMwareTestBase
    {
        public DatastoreTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Datastore_Create_Get_Exists_GetIfExists_List_Delete()
        {
            VMwareDatastoreCollection collection = DefaultResourceGroup.GetVMwareDatastores();

            // Create
            string datastoreName = Recording.GenerateAssetName("datastore");
            VMwareDatastoreData data = new VMwareDatastoreData(DefaultLocation)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/datastore-1102196",
            };
            ArmOperation<VMwareDatastoreResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, data);
            VMwareDatastoreResource datastore = lro.Value;
            Assert.IsNotNull(datastore);
            VMwareDatastoreData resourceData = datastore.Data;
            Assert.AreEqual(resourceData.Name, datastoreName);

            // Get
            VMwareDatastoreResource result = await collection.GetAsync(datastoreName);
            Assert.IsNotNull(result);

            // Check exists
            bool isExist = await collection.ExistsAsync(datastoreName);
            Assert.IsTrue(isExist);

            // Get if exists
            NullableResponse<VMwareDatastoreResource> response = await collection.GetIfExistsAsync(datastoreName);
            result = response.HasValue ? response.Value : null;
            Assert.IsNotNull(result);

            // List
            isExist = false;
            await foreach (VMwareDatastoreResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == datastoreName)
                    isExist = true;
            }
            Assert.IsTrue(isExist);

            // Delete
            await datastore.DeleteAsync(WaitUntil.Completed);
        }
    }
}
