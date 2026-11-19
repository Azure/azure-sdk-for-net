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
    public class LocationResourcesTests : ResourcesTestBase
    {
        private const string ResourceName = "resource";
        private static ResourceIdentifier ResourceId => LocationResource.CreateResourceIdentifier(SubscriptionId, Location, ResourceName);

        [SpectorTest]
        public Task Get() => Test(async host =>
        {
            var response = await GetClient(host).GetSubscriptionResource(new($"/subscriptions/{SubscriptionId}"))
                .GetLocationResourceAsync(Location, ResourceName);

            AssertData(response.Value.Data, "valid");
        });

        [SpectorTest]
        public Task CreateOrUpdate() => Test(async host =>
        {
            var operation = await GetClient(host).GetSubscriptionResource(new($"/subscriptions/{SubscriptionId}"))
                .GetLocationResources(Location).CreateOrUpdateAsync(WaitUntil.Completed, ResourceName, CreateData("valid"));

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, "valid");
        });

        [SpectorTest]
        public Task Update() => Test(async host =>
        {
            var response = await GetClient(host).GetLocationResource(ResourceId).UpdateAsync(CreateData("valid2"));

            AssertData(response.Value.Data, "valid2");
        });

        [SpectorTest]
        public Task Delete() => Test(async host =>
        {
            var operation = await GetClient(host).GetLocationResource(ResourceId).DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ListByLocation() => Test(host => AssertList(
            GetClient(host).GetSubscriptionResource(new($"/subscriptions/{SubscriptionId}")).GetLocationResources(Location).GetAllAsync(),
            resource => AssertData(resource.Data, "valid")));

        private static LocationResourceData CreateData(string description) => new()
        {
            Properties = new LocationResourceProperties { Description = description }
        };

        private static void AssertData(LocationResourceData data, string description)
        {
            AssertResource(data, ResourceId, ResourceName, "Azure.ResourceManager.Resources/locationResources");
            Assert.That(data.Properties.Description, Is.EqualTo(description));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
        }
    }
}
