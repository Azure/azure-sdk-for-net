// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppContainers.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppContainers.Tests.TestCase
{
    public class SessionPoolTests : AppContainersManagementTestBase
    {
        public SessionPoolTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string envName = Recording.GenerateAssetName("env");
            string name = Recording.GenerateAssetName("sessionpool");
            string name2 = Recording.GenerateAssetName("sessionpool");
            string name3 = Recording.GenerateAssetName("sessionpool");
            ResourceGroupResource rg = await CreateResourceGroupAsync();
            var envdata = ResourceDataHelpers.GetManagedEnvironmentData();
            var containerAppManagedEnvironmentCollection = rg.GetContainerAppManagedEnvironments();
            var envResource_lro = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, envdata);
            var envResource = envResource_lro.Value;
            //1.Create
            var data = ResourceDataHelpers.GetSessionPoolData(envResource.Data.Id);
            var collection = rg.GetSessionPools();
            var resource_lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            var resource = resource_lro.Value;
            Assert.AreEqual(name, resource.Data.Name);
            //2.Get
            var resource2 = await resource.GetAsync();
            ResourceDataHelpers.AssertSessionPoolData(resource.Data, resource2.Value.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, data);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, data);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
        }
    }
}
