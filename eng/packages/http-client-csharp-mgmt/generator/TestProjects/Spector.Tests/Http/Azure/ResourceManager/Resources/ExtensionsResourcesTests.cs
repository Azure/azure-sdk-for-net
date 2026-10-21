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
    public class ExtensionsResourcesTests : ResourcesTestBase
    {
        private const string ResourceName = "extension";

        [SpectorTest]
        [TestCase("resourceGroup")]
        [TestCase("subscription")]
        [TestCase("tenant")]
        [TestCase("resource")]
        public Task Get(string scope) => Test(async host =>
        {
            var response = await GetClient(host).GetExtensionsResourceAsync(GetScope(scope), ResourceName);

            AssertData(response.Value.Data, scope, "valid");
        });

        [SpectorTest]
        [TestCase("resourceGroup")]
        [TestCase("subscription")]
        [TestCase("tenant")]
        [TestCase("resource")]
        public Task CreateOrUpdate(string scope) => Test(async host =>
        {
            var operation = await GetClient(host).GetExtensionsResources(GetScope(scope))
                .CreateOrUpdateAsync(WaitUntil.Completed, ResourceName, CreateData("valid"));

            Assert.That(operation.HasCompleted, Is.True);
            AssertData(operation.Value.Data, scope, "valid");
        });

        [SpectorTest]
        [TestCase("resourceGroup")]
        [TestCase("subscription")]
        [TestCase("tenant")]
        [TestCase("resource")]
        public Task Update(string scope) => Test(async host =>
        {
            var response = await GetClient(host).GetExtensionsResource(GetResourceId(scope)).UpdateAsync(CreateData("valid2"));

            AssertData(response.Value.Data, scope, "valid2");
        });

        [SpectorTest]
        [TestCase("resourceGroup")]
        [TestCase("subscription")]
        [TestCase("tenant")]
        [TestCase("resource")]
        public Task Delete(string scope) => Test(async host =>
        {
            var operation = await GetClient(host).GetExtensionsResource(GetResourceId(scope)).DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        [TestCase("resourceGroup")]
        [TestCase("subscription")]
        [TestCase("tenant")]
        [TestCase("resource")]
        public Task ListByScope(string scope) => Test(host => AssertList(
            GetClient(host).GetExtensionsResources(GetScope(scope)).GetAllAsync(),
            resource => AssertData(resource.Data, scope, "valid")));

        private static ResourceIdentifier GetScope(string scope) => scope switch
        {
            "resourceGroup" => ResourceGroupId,
            "subscription" => new($"/subscriptions/{SubscriptionId}"),
            "tenant" => ResourceIdentifier.Root,
            "resource" => TopLevelResourceId,
            _ => throw new System.ArgumentOutOfRangeException(nameof(scope))
        };

        private static ResourceIdentifier GetResourceId(string scope) => ExtensionsResource.CreateResourceIdentifier(
            GetScope(scope).ToString().TrimEnd('/'), ResourceName);

        private static ExtensionsResourceData CreateData(string description) => new()
        {
            Properties = new ExtensionsResourceProperties { Description = description }
        };

        private static void AssertData(ExtensionsResourceData data, string scope, string description)
        {
            AssertResource(data, GetResourceId(scope), ResourceName, "Azure.ResourceManager.Resources/extensionsResources");
            Assert.That(data.Properties.Description, Is.EqualTo(description));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
        }
    }
}
