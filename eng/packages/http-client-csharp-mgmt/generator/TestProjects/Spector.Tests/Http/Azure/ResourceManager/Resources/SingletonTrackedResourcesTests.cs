// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.Resources
{
    public class SingletonTrackedResourcesTests : ResourcesTestBase
    {
        private static ResourceIdentifier ResourceId => SingletonTrackedResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName);

        [SpectorTest]
        public Task GetByResourceGroup() => Test(async host =>
        {
            var response = await GetClient(host).GetResourceGroupResource(ResourceGroupId)
                .GetSingletonTrackedResource().GetAsync();

            AssertData(response.Value.Data, "valid");
        });

        [SpectorTest]
        public Task CreateOrUpdate() => Test(async host =>
        {
            var operation = await GetClient(host).GetResourceGroupResource(ResourceGroupId)
                .GetSingletonTrackedResource().CreateOrUpdateAsync(WaitUntil.Completed, CreateData("valid"));

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, "valid");
        });

        [SpectorTest]
        public Task Update() => Test(async host =>
        {
            var response = await GetClient(host).GetSingletonTrackedResource(ResourceId).UpdateAsync(CreateData("valid2"));

            AssertData(response.Value.Data, "valid2");
        });

        // Azure_ResourceManager_Resources_Singleton_listByResourceGroup is scoped out of C# generation
        // until https://github.com/microsoft/typespec/issues/12175 is fixed. The management generator
        // also does not currently emit a collection or a public list method for singleton resources.

        private static SingletonTrackedResourceData CreateData(string description) => new(Location)
        {
            Properties = new SingletonTrackedResourceProperties { Description = description }
        };

        private static void AssertData(SingletonTrackedResourceData data, string description)
        {
            AssertResource(data, ResourceId, "default", "Azure.ResourceManager.Resources/singletonTrackedResources");
            Assert.That(data.Location, Is.EqualTo(Location));
            Assert.That(data.Properties.Description, Is.EqualTo(description));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
        }
    }
}
