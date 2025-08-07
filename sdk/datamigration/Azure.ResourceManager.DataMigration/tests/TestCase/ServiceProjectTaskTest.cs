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
using System.Threading;

namespace Azure.ResourceManager.DataMigration.Tests
{
    public class ServiceProjectTaskTest : DataMigrationManagementTestBase
    {
        public ServiceProjectTaskTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task SqlOfflineTaskApiTest()
        {
            //prepare
            string vnetName = Recording.GenerateAssetName("tc-vnet");
            string subnetName = Recording.GenerateAssetName("tc-subnet");
            string serviceName = Recording.GenerateAssetName("service");
            string projectName = Recording.GenerateAssetName("project");
            string taskName = Recording.GenerateAssetName("task");
            string taskName2 = Recording.GenerateAssetName("task");
            string taskName3 = Recording.GenerateAssetName("task");
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
            var projectInput = ResourceDataHelpers.GetTaskProject();
            var projectResource = (await projectCollection.CreateOrUpdateAsync(WaitUntil.Completed, projectName, projectInput)).Value;
            //Create
            var collection = projectResource.GetDataMigrationServiceTasks();
            var input = ResourceDataHelpers.GetProjectTaskData();
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, taskName, input)).Value;
            Assert.AreEqual(taskName, resource.Data.Name);
            //Get
            var resource2 = (await collection.GetAsync(taskName)).Value;
            ResourceDataHelpers.AssertMySqlOfflineTaskData(resource.Data, resource2.Data);
            //GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, taskName2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, taskName3, input);
            int count = 0;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(taskName));
            Assert.IsFalse(await collection.ExistsAsync(taskName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //Get
            var resource3 = (await collection.GetAsync(taskName)).Value;
            ResourceDataHelpers.AssertMySqlOfflineTaskData(resource.Data, resource3.Data);
            //Thread.Sleep(120 * 1000);
            if (Mode == RecordedTestMode.Playback)
            {
                Thread.Sleep(1 * 1000);
            }
            else
            {
                Thread.Sleep(120 * 1000);
            }
            // Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
