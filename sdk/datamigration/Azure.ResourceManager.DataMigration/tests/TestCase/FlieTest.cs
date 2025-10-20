// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataMigration.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using NUnit.Framework;
using Azure.ResourceManager.DataMigration.Models;

namespace Azure.ResourceManager.DataMigration.Tests
{
    internal class FlieTest : DataMigrationManagementTestBase
    {
        public FlieTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The requested resource does not support http method 'PUT'.")]
        public async Task FlieApiTest()
        {
            //prepare
            string vnetName = Recording.GenerateAssetName("tc-vnet");
            string subnetName = Recording.GenerateAssetName("tc-subnet");
            string serviceName = Recording.GenerateAssetName("service");
            string projectName = Recording.GenerateAssetName("project");
            string fileName = Recording.GenerateAssetName("flie");
            string fileName2 = Recording.GenerateAssetName("flie");
            string fileName3 = Recording.GenerateAssetName("flie");
            //CreateService
            var resourceGroup = await CreateResourceGroupAsync();
            var serviceCollection = resourceGroup.GetDataMigrationServices();
            SubnetResource subnet;
            if (Mode == RecordedTestMode.Playback)
            {
                ResourceIdentifier id = SubnetResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vnetName, subnetName);
                subnet = Client.GetSubnetResource(id);
            }
            else
            {
                VirtualNetworkCollection vnets = resourceGroup.GetVirtualNetworks();
                VirtualNetworkData vnetData = new VirtualNetworkData()
                {
                    Location = DefaultLocation,
                    AddressPrefixes = { "10.225.0.0/16" },
                };
                VirtualNetworkResource vnet = vnets.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData).Result.Value;
                SubnetCollection subnets = vnet.GetSubnets();
                SubnetData subnetData = new SubnetData()
                {
                    AddressPrefix = "10.225.0.0/24",
                };
                subnet = subnets.CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData).Result.Value;
            }
            var serviceInput = ResourceDataHelpers.GetServiceData(subnet.Id);
            var serviceResource = (await serviceCollection.CreateOrUpdateAsync(WaitUntil.Completed, serviceName, serviceInput)).Value;
            //Create Project
            var projectCollection = serviceResource.GetDataMigrationProjects();
            var projectInput = ResourceDataHelpers.GetProject();
            var projectResource = (await projectCollection.CreateOrUpdateAsync(WaitUntil.Completed, projectName, projectInput)).Value;
            //Create
            var collection = projectResource.GetDataMigrationProjectFiles();
            var input = ResourceDataHelpers.GetProjectFileData();
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, fileName, input)).Value;
            Assert.AreEqual(fileName, resource.Data.Name);
            //Get
            var resource2 = (await collection.GetAsync(fileName)).Value;
            ResourceDataHelpers.AssertFlieData(resource.Data, resource2.Data);
            //GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, fileName2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, fileName3, input);
            int count = 0;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(fileName));
            Assert.IsFalse(await collection.ExistsAsync(fileName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await collection.GetAsync(fileName)).Value;
            ResourceDataHelpers.AssertFlieData(resource.Data, resource3.Data);
            //2.Update
            var updateData = new DataMigrationProjectFileData()
            {
                Properties = new DataMigrationProjectFileProperties()
                {
                    FilePath = "aad"
                }
            };
            var resource4 = (await resource.UpdateAsync(updateData)).Value;
            ResourceDataHelpers.AssertFlieData(updateData, resource4.Data);
            //3. Delete
            await resource4.DeleteAsync(WaitUntil.Completed);
        }
    }
}
