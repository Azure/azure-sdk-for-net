// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IoTCentral.Models;
using Azure.Core;
using System.Threading;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IoTCentral.Tests
{
    public class IoTCentralAppOperationsTests : IoTCentralManagementTestBase
    {
        public IoTCentralAppOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralApplicationCrudOperationsTest()
        {
            var appName = Recording.GenerateAssetName("test-app-");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIoTCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IoTCentralAppData(AzureLocation.WestUS, new IoTCentralAppSkuInfo(IoTCentralAppSku.ST0))
            {
                DisplayName = appName,
                Subdomain = appName,
            };
            await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);

            // Read IoT Central application.
            var iotCentralAppResponse = await appsCollection.GetAsync(appName, CancellationToken.None);
            var iotCentralApp = iotCentralAppResponse.Value;

            // Update IoT Central application.
            var iotCentralAppPatch = new IoTCentralAppPatch()
            {
                Sku = new IoTCentralAppSkuInfo(IoTCentralAppSku.ST1),
                Identity = new SystemAssignedServiceIdentity(ResourceManager.Models.SystemAssignedServiceIdentityType.SystemAssigned),
            };
            await iotCentralApp.UpdateAsync(WaitUntil.Completed, iotCentralAppPatch, CancellationToken.None);

            // Delete IoT Central application.
            await iotCentralApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralApplicationAddTagsTest()
        {
            var appName = Recording.GenerateAssetName("test-app-");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIoTCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IoTCentralAppData(AzureLocation.WestUS, new IoTCentralAppSkuInfo(IoTCentralAppSku.ST0))
            {
                DisplayName = appName,
                Subdomain = appName,
            };
            var iotCentralAppOperation = await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            var iotCentralApp = iotCentralAppOperation.Value;

            // Add a tag.
            var tag1IoTCentralAppResponse = await iotCentralApp.AddTagAsync("key", "value", CancellationToken.None);
            var tag1IoTCentralApp = tag1IoTCentralAppResponse.Value;

            tag1IoTCentralApp.Data.Tags.TryGetValue("key", out var tagReadVal);
            Assert.AreEqual("value", tagReadVal);
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralApplicationRemoveTagsTest()
        {
            var appName = Recording.GenerateAssetName("test-app-");

            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIoTCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IoTCentralAppData(AzureLocation.WestUS, new IoTCentralAppSkuInfo(IoTCentralAppSku.ST0))
            {
                DisplayName = appName,
                Subdomain = appName,
            };
            iotCentralAppData.Tags.Add("key", "value");
            var iotCentralAppOperation = await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            var iotCentralApp = iotCentralAppOperation.Value;

            Assert.IsTrue(iotCentralApp.Data.Tags.ContainsKey("key"));

            // Remove a tag.
            var tag2IoTCentralAppResource = await iotCentralApp.RemoveTagAsync("key", CancellationToken.None);
            var tag2IoTCentralApp = tag2IoTCentralAppResource.Value;

            Assert.IsFalse(tag2IoTCentralApp.Data.Tags.ContainsKey("key"));
        }
    }
}
