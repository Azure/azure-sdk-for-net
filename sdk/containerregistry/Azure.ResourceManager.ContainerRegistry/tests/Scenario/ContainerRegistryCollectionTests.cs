// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerRegistry.Tests
{
    public class ContainerRegistryCollectionTests : ContainerRegistryManagementTestBase
    {
        public ContainerRegistryCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckNameAvailability()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);

            // Check valid name
            string registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryNameAvailabilityContent content = new ContainerRegistryNameAvailabilityContent(registryName);
            ContainerRegistryNameAvailableResult result = await Subscription.CheckContainerRegistryNameAvailabilityAsync(content);
            Assert.True(result.IsNameAvailable);
            Assert.Null(result.Reason);
            Assert.Null(result.Message);

            // Check disallowed name
            registryName = "Microsoft";
            content = new ContainerRegistryNameAvailabilityContent(registryName);
            result = await Subscription.CheckContainerRegistryNameAvailabilityAsync(content);
            Assert.False(result.IsNameAvailable);
            Assert.AreEqual("Invalid", result.Reason);
            Assert.AreEqual("The specified resource name is disallowed.", result.Message);

            // Check name of container registry that already exists
            registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            content = new ContainerRegistryNameAvailabilityContent(registryName);
            result = await Subscription.CheckContainerRegistryNameAvailabilityAsync(content);
            Assert.False(result.IsNameAvailable);
            Assert.AreEqual("AlreadyExists", result.Reason);
            Assert.AreEqual("The registry " + registryName + " is already in use.", result.Message);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryCoreScenario()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);
            var registries = rg.GetContainerRegistries();
            // Validate the created registry
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            var registryData = registry.Data;
            ValidateResourceDefaultTags(registryData);
            Assert.NotNull(registryData.Sku);
            Assert.AreEqual(ContainerRegistrySkuName.Premium, registryData.Sku.Name);
            Assert.AreEqual(ContainerRegistrySkuTier.Premium, registryData.Sku.Tier);

            Assert.NotNull(registryData.LoginServer);
            Assert.NotNull(registryData.CreatedOn);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, registryData.ProvisioningState);
            Assert.False(registryData.IsAdminUserEnabled);

            // List container registries by resource group
            var registryPages = registries.GetAllAsync();
            ContainerRegistryResource registryFromList = await registryPages.FirstOrDefaultAsync(r => r.Data.Name.Equals(registryName, StringComparison.Ordinal));
            ValidateResourceDefaultTags(registryFromList.Data);
            Assert.AreEqual(ContainerRegistrySkuName.Premium, registryFromList.Data.Sku.Name);

            // Get the container registry
            ContainerRegistryResource registryFromGet = await registries.GetAsync(registryName);
            ValidateResourceDefaultTags(registryFromGet.Data);
            Assert.AreEqual(ContainerRegistrySkuName.Premium, registryFromGet.Data.Sku.Name);

            // Try to list credentials, should fail when admin user is disabled
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await registryFromGet.GetCredentialsAsync());
            Assert.AreEqual(400, ex.Status);

            // Update the container registry
            var registryPatch = new ContainerRegistryPatch()
            {
                Tags =
                {
                    { "key2","value2"},
                    { "key3","value3"},
                    { "key4","value4"}
                },
                IsAdminUserEnabled = true,
                Sku = new ContainerRegistrySku(ContainerRegistrySkuName.Basic)
            };
            ContainerRegistryResource registryFromUpdate = (await registryFromGet.UpdateAsync(WaitUntil.Completed, registryPatch)).Value;
            // Validate the updated registry
            ValidateResourceDefaultNewTags(registryFromUpdate.Data);
            registryData = registryFromUpdate.Data;
            Assert.NotNull(registryData.Sku);
            Assert.AreEqual(ContainerRegistrySkuName.Basic, registryData.Sku.Name);
            Assert.AreEqual(ContainerRegistrySkuTier.Basic, registryData.Sku.Tier);

            Assert.NotNull(registryData.LoginServer);
            Assert.NotNull(registryData.CreatedOn);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, registryData.ProvisioningState);
            Assert.True(registryData.IsAdminUserEnabled);

            // List credentials
            ContainerRegistryListCredentialsResult credentials = await registryFromUpdate.GetCredentialsAsync();
            // Validate username and password
            Assert.NotNull(credentials);
            Assert.NotNull(credentials.Username);
            Assert.AreEqual(2, credentials.Passwords.Count);
            var password1 = credentials.Passwords[0].Value;
            var password2 = credentials.Passwords[1].Value;
            Assert.NotNull(password1);
            Assert.NotNull(password2);

            // Regenerate credential
            ContainerRegistryCredentialRegenerateContent credentialContent = new ContainerRegistryCredentialRegenerateContent(ContainerRegistryPasswordName.Password);
            credentials = await registryFromUpdate.RegenerateCredentialAsync(credentialContent);
            // Validate if generated password is different
            var newPassword1 = credentials.Passwords[0].Value;
            var newPassword2 = credentials.Passwords[1].Value;
            Assert.AreNotEqual(password1, newPassword1);
            Assert.AreEqual(password2, newPassword2);

            credentialContent = new ContainerRegistryCredentialRegenerateContent(ContainerRegistryPasswordName.Password2);
            credentials = await registryFromUpdate.RegenerateCredentialAsync(credentialContent);
            // Validate if generated password is different
            Assert.AreEqual(newPassword1, credentials.Passwords[0].Value);
            Assert.AreNotEqual(newPassword2, credentials.Passwords[1].Value);

            // Delete the container registry
            await registryFromUpdate.DeleteAsync(WaitUntil.Completed);

            // Delete the container registry again
            await registryFromUpdate.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryWebhook()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);
            var registries = rg.GetContainerRegistries();
            // Create container registry and webhook
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            var webhookName = Recording.GenerateAssetName("acrwebhook");
            ContainerRegistryWebhookResource webhook = await CreateContainerWebhookAsync(registry, webhookName);
            // Validate the created webhook
            var webhookData = webhook.Data;
            ValidateResourceDefaultTags(webhookData);
            Assert.AreEqual(ContainerRegistryWebhookStatus.Enabled, webhookData.Status);
            Assert.True(string.IsNullOrEmpty(webhookData.Scope));
            Assert.AreEqual(1, webhookData.Actions.Count);
            Assert.True(webhookData.Actions.Contains(ContainerRegistryWebhookAction.Push));
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, webhookData.ProvisioningState);

            // List webhooks by container registry
        }

        private static void ValidateResourceDefaultTags(TrackedResourceData resourceData)
        {
            ValidateResourceData(resourceData);
            Assert.NotNull(resourceData.Tags);
            Assert.AreEqual(2, resourceData.Tags.Count);
            Assert.AreEqual("value1", resourceData.Tags["key1"]);
            Assert.AreEqual("value2", resourceData.Tags["key2"]);
        }

        private static void ValidateResourceDefaultNewTags(TrackedResourceData resourceData)
        {
            ValidateResourceData(resourceData);
            Assert.NotNull(resourceData.Tags);
            Assert.AreEqual(3, resourceData.Tags.Count);
            Assert.AreEqual("value2", resourceData.Tags["key2"]);
            Assert.AreEqual("value3", resourceData.Tags["key3"]);
            Assert.AreEqual("value4", resourceData.Tags["key4"]);
        }

        private static void ValidateResourceData(TrackedResourceData resourceData)
        {
            Assert.NotNull(resourceData);
            Assert.NotNull(resourceData.Id);
            Assert.NotNull(resourceData.Name);
            Assert.NotNull(resourceData.ResourceType);
            Assert.NotNull(resourceData.Location);
        }
    }
}
