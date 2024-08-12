// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class HostTests : ConnectedVMwareTestBase
    {
        public HostTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Host_Create_Get_Exists_GetIfExists_List_Delete()
        {
            VMwareHostCollection collection = DefaultResourceGroup.GetVMwareHosts();

            // Create
            string hostName = Recording.GenerateAssetName("host");
            VMwareHostData data = new VMwareHostData(DefaultLocation)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/host-1147412",
            };
            ArmOperation<VMwareHostResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, data);
            VMwareHostResource host = lro.Value;
            Assert.IsNotNull(host);
            VMwareHostData resourceData = host.Data;
            Assert.AreEqual(resourceData.Name, hostName);

            // Get
            VMwareHostResource result = await collection.GetAsync(hostName);
            Assert.IsNotNull(result);

            // Check exists
            bool isExist = await collection.ExistsAsync(hostName);
            Assert.IsTrue(isExist);

            // Get if exists
            NullableResponse<VMwareHostResource> response = await collection.GetIfExistsAsync(hostName);
            result = response.HasValue ? response.Value : null;
            Assert.IsNotNull(result);

            // List
            isExist = false;
            await foreach (VMwareHostResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == hostName)
                    isExist = true;
            }
            Assert.IsTrue(isExist);

            // Delete
            await host.DeleteAsync(WaitUntil.Completed);
        }
    }
}
