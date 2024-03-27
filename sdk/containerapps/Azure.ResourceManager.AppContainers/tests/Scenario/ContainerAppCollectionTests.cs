// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class ContainerAppCollectionTests : AppContainersManagementTestBase
    {
        public ContainerAppCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync();
            string envName = Recording.GenerateAssetName("env");
            var envResource = await CreateContainerAppManagedEnvironment(rg, envName);
            Assert.AreEqual(envName, envResource.Data.Name);

            var ContainerAppCollection = rg.GetContainerApps();
            string resourceName = Recording.GenerateAssetName("resource");

            // Create
            var resource = await CreateContainerApp(rg, envResource, resourceName);
            Assert.AreEqual(resourceName, resource.Data.Name);

            // Exists
            var result = await ContainerAppCollection.ExistsAsync(resourceName);
            Assert.IsTrue(result);

            // Get
            var getResult = await ContainerAppCollection.GetAsync(resourceName);
            Assert.AreEqual(resourceName, getResult.Value.Data.Name);

            // List
            var listResult = await ContainerAppCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listResult);
            Assert.AreEqual(listResult[0].Data.Name, resourceName);

            // Delete
            await resource.DeleteAsync(WaitUntil.Completed);
            result = await ContainerAppCollection.ExistsAsync(resourceName);
            Assert.IsFalse(result);
        }
    }
}
