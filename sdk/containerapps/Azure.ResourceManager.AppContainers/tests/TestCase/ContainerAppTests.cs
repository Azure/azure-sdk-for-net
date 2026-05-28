// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Tests.Helpers;
using Azure.ResourceManager.AppContainers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class ContainerAppTests : AppContainersManagementTestBase
    {
        public ContainerAppTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task AppContainerTest()
        {
            string envName = Recording.GenerateAssetName("env");
            string name = Recording.GenerateAssetName("appcontainer");
            string name2 = Recording.GenerateAssetName("appcontainer");
            string name3 = Recording.GenerateAssetName("appcontainer");
            ResourceGroupResource rg = await CreateResourceGroupAsync();
            var data = ResourceDataHelpers.GetManagedEnvironmentData();

            var containerAppManagedEnvironmentCollection = rg.GetContainerAppManagedEnvironments();
            var envResource_lro = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            var envResource = envResource_lro.Value;
            Assert.AreEqual(envName, envResource.Data.Name);

            var appData = ResourceDataHelpers.GetContainerAppData(envResource);

            // 1.Create
            var collection = rg.GetContainerApps();
            var resource_lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, appData);
            var resource = resource_lro.Value;
            Assert.AreEqual(name, resource.Data.Name);

            //2.Get
            var resource2 = await resource.GetAsync();
            ResourceDataHelpers.AssertContainerAppData(resource.Data, resource2.Value.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, appData);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, appData);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, appData);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            var resource3 = await resource.GetAsync();
            ResourceDataHelpers.AssertContainerAppData(resource.Data, resource3.Value.Data);
            //6.Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
