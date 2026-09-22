// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class ContextCacheTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public ContextCacheTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task ClearContextCaches()
        {
            if (_resourceGroup != null)
            {
                await foreach (ContextCacheResource contextCache in _resourceGroup.GetContextCaches())
                {
                    await contextCache.DeleteAsync(WaitUntil.Completed);
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetListUpdateDeleteContextCacheAndContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string contextCacheName = Recording.GenerateAssetName("ctxcache");
            ContextCacheCollection contextCaches = _resourceGroup.GetContextCaches();
            var contextCacheData = new ContextCacheData(
                AzureLocation.EastUS,
                new ContextCacheProperties(ContextCacheAccountKind.Regional)
                {
                    Description = "Test Azure Context Cache account"
                });
            contextCacheData.Tags.Add("environment", "test");

            ContextCacheResource contextCache = (await contextCaches.CreateOrUpdateAsync(
                WaitUntil.Completed,
                contextCacheName,
                contextCacheData)).Value;

            Assert.AreEqual(contextCacheName, contextCache.Data.Name);
            Assert.AreEqual(ContextCacheAccountKind.Regional, contextCache.Data.Properties.AccountKind);
            Assert.AreEqual("Test Azure Context Cache account", contextCache.Data.Properties.Description);
            Assert.AreEqual(ContextCacheProvisioningState.Succeeded, contextCache.Data.Properties.ProvisioningState);
            Assert.AreEqual("test", contextCache.Data.Tags["environment"]);

            Assert.IsTrue((await contextCaches.ExistsAsync(contextCacheName)).Value);
            Assert.IsTrue((await contextCaches.GetIfExistsAsync(contextCacheName)).HasValue);
            Assert.AreEqual(contextCache.Id, (await contextCaches.GetAsync(contextCacheName)).Value.Id);
            Assert.AreEqual(contextCache.Id, (await contextCache.GetAsync()).Value.Id);
            Assert.AreEqual(contextCache.Id, (await _resourceGroup.GetContextCacheAsync(contextCacheName)).Value.Id);
            Assert.AreEqual(contextCache.Id, (await Client.GetContextCacheResource(contextCache.Id).GetAsync()).Value.Id);

            List<ContextCacheResource> resourceGroupCaches = await contextCaches.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resourceGroupCaches.Any(resource => resource.Id == contextCache.Id));
            List<ContextCacheResource> subscriptionCaches = await DefaultSubscription.GetContextCachesAsync().ToEnumerableAsync();
            Assert.IsTrue(subscriptionCaches.Any(resource => resource.Id == contextCache.Id));

            var patch = new ContextCachePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Properties = new ContextCachePropertiesUpdate
                {
                    Description = "Updated Azure Context Cache account"
                }
            };
            patch.Tags.Add("environment", "production");
            contextCache = (await contextCache.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("Updated Azure Context Cache account", contextCache.Data.Properties.Description);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, contextCache.Data.Identity.ManagedServiceIdentityType);
            Assert.IsNotNull(contextCache.Data.Identity.PrincipalId);
            Assert.IsNotNull(contextCache.Data.Identity.TenantId);
            Assert.AreEqual("production", contextCache.Data.Tags["environment"]);

            // Generic tag operations are currently broken for Context Cache.
            // contextCache = (await contextCache.AddTagAsync("team", "context-cache")).Value;
            // Assert.AreEqual("context-cache", contextCache.Data.Tags["team"]);
            // contextCache = (await contextCache.SetTagsAsync(new Dictionary<string, string> { ["environment"] = "production" })).Value;
            // Assert.AreEqual(1, contextCache.Data.Tags.Count);
            // contextCache = (await contextCache.RemoveTagAsync("environment")).Value;
            // Assert.IsEmpty(contextCache.Data.Tags);

            string containerName = Recording.GenerateAssetName("gpt4-prompts");
            ContextCacheContainerCollection containers = contextCache.GetContextCacheContainers();
            RequestFailedException invalidNameException = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await containers.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "Invalid_Container_Name",
                    new ContextCacheContainerData(new ContextCacheContainerProperties("gpt-4", AiProvider.OpenAI))));
            Assert.AreEqual(400, invalidNameException.Status);

            RequestFailedException invalidTimeToLiveException = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await containers.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    Recording.GenerateAssetName("invalid-ttl"),
                    new ContextCacheContainerData(
                        new ContextCacheContainerProperties("gpt-4", AiProvider.OpenAI)
                        {
                            TimeToLive = 31
                        })));
            Assert.AreEqual(400, invalidTimeToLiveException.Status);

            var containerData = new ContextCacheContainerData(
                new ContextCacheContainerProperties("gpt-4", AiProvider.OpenAI)
                {
                    Description = "Container for GPT-4 prompt caching",
                    TimeToLive = 7
                });

            ContextCacheContainerResource container = (await containers.CreateOrUpdateAsync(
                WaitUntil.Completed,
                containerName,
                containerData)).Value;

            Assert.AreEqual(containerName, container.Data.Name);
            Assert.AreEqual("gpt-4", container.Data.Properties.ModelName);
            Assert.AreEqual(AiProvider.OpenAI, container.Data.Properties.Provider);
            Assert.AreEqual(7, container.Data.Properties.TimeToLive);
            Assert.AreEqual(ContextCacheProvisioningState.Succeeded, container.Data.Properties.ProvisioningState);

            Assert.IsTrue((await containers.ExistsAsync(containerName)).Value);
            Assert.IsTrue((await containers.GetIfExistsAsync(containerName)).HasValue);
            Assert.AreEqual(container.Id, (await containers.GetAsync(containerName)).Value.Id);
            Assert.AreEqual(container.Id, (await container.GetAsync()).Value.Id);
            Assert.AreEqual(container.Id, (await contextCache.GetContextCacheContainerAsync(containerName)).Value.Id);
            Assert.AreEqual(container.Id, (await Client.GetContextCacheContainerResource(container.Id).GetAsync()).Value.Id);
            List<ContextCacheContainerResource> allContainers = await containers.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(allContainers.Any(resource => resource.Id == container.Id));

            var containerPatch = new ContextCacheContainerPatch
            {
                Properties = new ContextCacheContainerPropertiesUpdate
                {
                    Description = "Updated container for GPT-4 prompt caching",
                    TimeToLive = 14
                }
            };
            container = (await container.UpdateAsync(WaitUntil.Completed, containerPatch)).Value;
            Assert.AreEqual("Updated container for GPT-4 prompt caching", container.Data.Properties.Description);
            Assert.AreEqual(14, container.Data.Properties.TimeToLive);

            await container.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await containers.ExistsAsync(containerName)).Value);
            Assert.IsFalse((await containers.GetIfExistsAsync(containerName)).HasValue);

            await contextCache.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await contextCaches.ExistsAsync(contextCacheName)).Value);
            Assert.IsFalse((await contextCaches.GetIfExistsAsync(contextCacheName)).HasValue);
        }
    }
}
