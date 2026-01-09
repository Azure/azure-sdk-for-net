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
            Assert.That(envResource.Data.Name, Is.EqualTo(envName));

            var ContainerAppCollection = rg.GetContainerApps();
            string resourceName = Recording.GenerateAssetName("resource");

            // Create
            var resource = await CreateContainerApp(rg, envResource, resourceName);
            Assert.That(resource.Data.Name, Is.EqualTo(resourceName));

            // Exists
            var result = await ContainerAppCollection.ExistsAsync(resourceName);
            Assert.That((bool)result, Is.True);

            // Get
            var getResult = await ContainerAppCollection.GetAsync(resourceName);
            Assert.That(getResult.Value.Data.Name, Is.EqualTo(resourceName));

            // List
            var listResult = await ContainerAppCollection.GetAllAsync().ToEnumerableAsync();
            Assert.Multiple(() =>
            {
                Assert.That(listResult, Is.Not.Empty);
                Assert.That(resourceName, Is.EqualTo(listResult[0].Data.Name));
            });

            // Delete
            await resource.DeleteAsync(WaitUntil.Completed);
            result = await ContainerAppCollection.ExistsAsync(resourceName);
            Assert.That((bool)result, Is.False);
        }
    }
}
