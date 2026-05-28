// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.AppContainers.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class ManagedEnviromentTests : AppContainersManagementTestBase
    {
        public ManagedEnviromentTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task AppContainerTest()
        {
            string envName = Recording.GenerateAssetName("env");
            string envName2 = Recording.GenerateAssetName("env");
            string envName3 = Recording.GenerateAssetName("env");
            ResourceGroupResource rg = await CreateResourceGroupAsync();
            var data = ResourceDataHelpers.GetManagedEnvironmentData();

            //1.Create
            var containerAppManagedEnvironmentCollection = rg.GetContainerAppManagedEnvironments();
            var envResource_lro = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            var envResource = envResource_lro.Value;
            Assert.AreEqual(envName, envResource.Data.Name);
            //2.Get
            var resource2 = await envResource.GetAsync();
            ResourceDataHelpers.AssertContainerAppManagedEnvironmentData(envResource.Data, resource2.Value.Data);
            //3.GetAll
            _ = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            _ = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName2, data);
            _ = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName3, data);
            int count = 0;
            await foreach (var num in containerAppManagedEnvironmentCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await containerAppManagedEnvironmentCollection.ExistsAsync(envName));
            Assert.IsFalse(await containerAppManagedEnvironmentCollection.ExistsAsync(envName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await containerAppManagedEnvironmentCollection.ExistsAsync(null));
            //Resource
            //5.Get
            var resource3 = await envResource.GetAsync();
            ResourceDataHelpers.AssertContainerAppManagedEnvironmentData(envResource.Data, resource3.Value.Data);
            //6.Delete
            await envResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
