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
    public class NestedProxyResourcesTests : ResourcesTestBase
    {
        private const string ResourceName = "nested";
        private static ResourceIdentifier ResourceId => NestedProxyResource.CreateResourceIdentifier(
            SubscriptionId, ResourceGroupName, TopLevelResourceName, ResourceName);

        [SpectorTest]
        public Task Get() => Test(async host =>
        {
            var response = await GetClient(host).GetTopLevelTrackedResource(TopLevelResourceId)
                .GetNestedProxyResourceAsync(ResourceName);

            AssertData(response.Value.Data, "valid");
        });

        [SpectorTest]
        public Task CreateOrReplace() => Test(async host =>
        {
            var operation = await GetClient(host).GetTopLevelTrackedResource(TopLevelResourceId)
                .GetNestedProxyResources().CreateOrUpdateAsync(WaitUntil.Completed, ResourceName, CreateData("valid"));

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, "valid");
        });

        [SpectorTest]
        public Task Update() => Test(async host =>
        {
            var operation = await GetClient(host).GetNestedProxyResource(ResourceId)
                .UpdateAsync(WaitUntil.Completed, CreateData("valid2"));

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, "valid2");
        });

        [SpectorTest]
        public Task Delete() => Test(async host =>
        {
            var operation = await GetClient(host).GetNestedProxyResource(ResourceId).DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ListByTopLevelTrackedResource() => Test(host => AssertList(
            GetClient(host).GetTopLevelTrackedResource(TopLevelResourceId).GetNestedProxyResources().GetAllAsync(),
            resource => AssertData(resource.Data, "valid")));

        private static NestedProxyResourceData CreateData(string description) => new()
        {
            Properties = new NestedProxyResourceProperties { Description = description }
        };

        private static void AssertData(NestedProxyResourceData data, string description)
        {
            AssertResource(data, ResourceId, ResourceName, "Azure.ResourceManager.Resources/topLevelTrackedResources/top/nestedProxyResources");
            Assert.That(data.Properties.Description, Is.EqualTo(description));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
        }
    }
}
