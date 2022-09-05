// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IotCentral.Models;
using Azure.Core;
using System.Threading;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotCentral.Tests
{
    public class IotCentralAppOperationsTests : IotCentralManagementTestBase
    {
        public IotCentralAppOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralApplicationCrudOperationsTest()
        {
            var appName = Recording.GenerateAssetName("test-app-");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new IotCentralAppSkuInfo(IotCentralAppSku.ST0))
            {
                DisplayName = appName,
                Subdomain = appName,
            };
            await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);

            // Read IoT Central application.
            var iotCentralAppResponse = await appsCollection.GetAsync(appName, CancellationToken.None);
            var iotCentralApp = iotCentralAppResponse.Value;

            // Update IoT Central application.
            var iotCentralAppPatch = new IotCentralAppPatch()
            {
                Sku = new IotCentralAppSkuInfo(IotCentralAppSku.ST1),
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
            };
            await iotCentralApp.UpdateAsync(WaitUntil.Completed, iotCentralAppPatch, CancellationToken.None);

            // Delete IoT Central application.
            await iotCentralApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }

        [TestCase(null)]
        [TestCase(true)]
        //[TestCase(false)] TODO: Playback fails due to inner LRO call isn't instrumented
        public async Task IotCentralApplicationAddTagsTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var appName = Recording.GenerateAssetName("test-app-");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new IotCentralAppSkuInfo(IotCentralAppSku.ST0))
            {
                DisplayName = appName,
                Subdomain = appName,
            };
            var iotCentralAppOperation = await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            var iotCentralApp = iotCentralAppOperation.Value;

            // Add a tag.
            var tag1IotCentralAppResponse = await iotCentralApp.AddTagAsync("key", "value", CancellationToken.None);
            var tag1IotCentralApp = tag1IotCentralAppResponse.Value;

            tag1IotCentralApp.Data.Tags.TryGetValue("key", out var tagReadVal);
            Assert.AreEqual("value", tagReadVal);
        }

        [TestCase(null)]
        [TestCase(true)]
        //[TestCase(false)] TODO: Playback fails due to inner LRO call isn't instrumented
        public async Task IotCentralApplicationRemoveTagsTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var appName = Recording.GenerateAssetName("test-app-");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new IotCentralAppSkuInfo(IotCentralAppSku.ST0))
            {
                DisplayName = appName,
                Subdomain = appName,
            };
            iotCentralAppData.Tags.Add("key", "value");
            var iotCentralAppOperation = await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            var iotCentralApp = iotCentralAppOperation.Value;

            Assert.IsTrue(iotCentralApp.Data.Tags.ContainsKey("key"));

            // Remove a tag.
            var tag2IotCentralAppResource = await iotCentralApp.RemoveTagAsync("key", CancellationToken.None);
            var tag2IotCentralApp = tag2IotCentralAppResource.Value;

            Assert.IsFalse(tag2IotCentralApp.Data.Tags.ContainsKey("key"));
        }
    }
}
