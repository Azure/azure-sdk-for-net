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
    public class ProjectTest : DataMigrationManagementTestBase
    {
        public ProjectTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ProjectApiTest()
        {
            //prepare
            string vnetName = Recording.GenerateAssetName("tc-vnet");
            string subnetName = Recording.GenerateAssetName("tc-subnet");
            string serviceName = Recording.GenerateAssetName("service");
            string projectName = Recording.GenerateAssetName("project");
            string projectName2 = Recording.GenerateAssetName("project");
            string projectName3 = Recording.GenerateAssetName("project");
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
            //Create
            var collection = serviceResource.GetDataMigrationProjects();
            var input = ResourceDataHelpers.GetProject();
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, projectName, input)).Value;
            Assert.AreEqual(projectName, resource.Data.Name);
            //Get
            var resource2 = (await collection.GetAsync(projectName)).Value;
            ResourceDataHelpers.AssertProjectData(resource.Data, resource2.Data);
            //GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, projectName2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, projectName3, input);
            int count = 0;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(projectName));
            Assert.IsFalse(await collection.ExistsAsync(projectName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await collection.GetAsync(projectName)).Value;
            ResourceDataHelpers.AssertProjectData(resource.Data, resource3.Data);
            //2. Delete
            await resource3.DeleteAsync(WaitUntil.Completed);
        }
    }
}
