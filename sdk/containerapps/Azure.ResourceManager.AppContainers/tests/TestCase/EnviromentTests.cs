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

namespace Azure.ResourceManager.AppContainers.Tests.TestCase
{
    public class EnviromentTests : AppContainersManagementTestBase
    {
        public EnviromentTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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
            var data = ResourceDataHelpers.GetEnvironmentData();

            //1.Create
            var containerAppConnectedEnvironmentCollection = rg.GetContainerAppConnectedEnvironments();
            var envResource_lro = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, "examplekenv", data);
            var envResource = envResource_lro.Value;
            Assert.AreEqual(envName, envResource.Data.Name);
            //2.Get
            var resource2 = await envResource.GetAsync();
            ResourceDataHelpers.AssertEnviroment(envResource.Data, resource2.Value.Data);
            //3.GetAll
            _ = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            _ = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName2, data);
            _ = await containerAppConnectedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName3, data);
            int count = 0;
            await foreach (var num in containerAppConnectedEnvironmentCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await containerAppConnectedEnvironmentCollection.ExistsAsync(envName));
            Assert.IsFalse(await containerAppConnectedEnvironmentCollection.ExistsAsync(envName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await containerAppConnectedEnvironmentCollection.ExistsAsync(null));
            //Resource
            //5.Get
            var resource3 = await envResource.GetAsync();
            ResourceDataHelpers.AssertEnviroment(envResource.Data, resource3.Value.Data);
            //6.Delete
            await envResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
