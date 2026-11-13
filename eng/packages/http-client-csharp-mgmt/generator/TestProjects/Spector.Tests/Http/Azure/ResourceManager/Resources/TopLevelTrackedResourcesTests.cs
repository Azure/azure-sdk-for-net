// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.Resources
{
    public class TopLevelTrackedResourcesTests : ResourcesTestBase
    {
        [SpectorTest]
        public Task Get() => Test(async host =>
        {
            var response = await GetClient(host).GetResourceGroupResource(ResourceGroupId)
                .GetTopLevelTrackedResourceAsync(TopLevelResourceName);

            AssertData(response.Value.Data, "valid");
        });

        [SpectorTest]
        public Task CreateOrReplace() => Test(async host =>
        {
            var data = new TopLevelTrackedResourceData(Location)
            {
                Properties = new TopLevelTrackedResourceProperties { Description = "valid" }
            };
            var operation = await GetClient(host).GetResourceGroupResource(ResourceGroupId)
                .GetTopLevelTrackedResources().CreateOrUpdateAsync(WaitUntil.Completed, TopLevelResourceName, data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, "valid");
        });

        [SpectorTest]
        public Task Update() => Test(async host =>
        {
            var data = new TopLevelTrackedResourceData(Location)
            {
                Properties = new TopLevelTrackedResourceProperties { Description = "valid2" }
            };
            var operation = await GetClient(host).GetTopLevelTrackedResource(TopLevelResourceId)
                .UpdateAsync(WaitUntil.Completed, data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, "valid2");
        });

        [SpectorTest]
        public Task Delete() => Test(async host =>
        {
            var operation = await GetClient(host).GetTopLevelTrackedResource(TopLevelResourceId)
                .DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ActionSync() => Test(async host =>
        {
            var response = await GetClient(host).GetTopLevelTrackedResource(TopLevelResourceId)
                .ActionSyncAsync(new NotificationDetails("Resource action at top level.", true));

            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ListByResourceGroup() => Test(host => AssertList(
            GetClient(host).GetResourceGroupResource(ResourceGroupId).GetTopLevelTrackedResources().GetAllAsync(),
            resource => AssertData(resource.Data, "valid")));

        [SpectorTest]
        public Task ListBySubscription() => Test(host => AssertList(
            GetClient(host).GetSubscriptionResource(new($"/subscriptions/{SubscriptionId}")).GetTopLevelTrackedResourcesAsync(),
            resource => AssertData(resource.Data, "valid")));

        private static void AssertData(TopLevelTrackedResourceData data, string description)
        {
            AssertResource(data, TopLevelResourceId, TopLevelResourceName, "Azure.ResourceManager.Resources/topLevelTrackedResources");
            Assert.That(data.Location, Is.EqualTo(Location));
            Assert.That(data.Properties.Description, Is.EqualTo(description));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
        }
    }
}
