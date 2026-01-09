// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class ClusterTests : ConnectedVMwareTestBase
    {
        public ClusterTests(bool isAsync) : base(isAsync)
        {
        }

        // CreateCluster
        [TestCase]
        [RecordedTest]
        public async Task Cluster_Create_Get_Exists_GetIfExists_List_Delete()
        {
            VMwareClusterCollection collection = DefaultResourceGroup.GetVMwareClusters();

            // Create
            string clusterName = Recording.GenerateAssetName("cluster");
            VMwareClusterData data = new VMwareClusterData(DefaultLocation)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = $"/subscriptions/{DefaultSubscriptionId}/resourcegroups/{DefaultResourceGroupName}/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = $"/subscriptions/{DefaultSubscriptionId}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/domain-c649660",
            };
            ArmOperation<VMwareClusterResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            VMwareClusterResource cluster = lro.Value;
            Assert.That(cluster, Is.Not.Null);
            VMwareClusterData resourceData = cluster.Data;
            Assert.That(clusterName, Is.EqualTo(resourceData.Name));

            // Get
            VMwareClusterResource result = await collection.GetAsync(clusterName);
            Assert.That(result, Is.Not.Null);

            // Check exists
            bool isExist = await collection.ExistsAsync(clusterName);
            Assert.That(isExist, Is.True);

            // Get if exists
            NullableResponse<VMwareClusterResource> response = await collection.GetIfExistsAsync(clusterName);
            result = response.HasValue ? response.Value : null;
            Assert.That(result, Is.Not.Null);

            // List
            isExist = false;
            await foreach (VMwareClusterResource item in collection.GetAllAsync())
            {
                if (item.Data.Name == clusterName)
                    isExist = true;
            }
            Assert.That(isExist, Is.True);

            // Delete
            await cluster.DeleteAsync(WaitUntil.Completed);
        }
    }
}
