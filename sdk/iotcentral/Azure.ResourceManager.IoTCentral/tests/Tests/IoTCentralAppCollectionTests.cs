// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IoTCentral.Models;
using Azure.Core;
using System.Threading;

namespace Azure.ResourceManager.IoTCentral.Tests
{
    public class IoTCentralAppCollectionTests : IoTCentralManagementTestBase
    {
        public IoTCentralAppCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralAppCollectionExistsTest()
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

            // Check that the created app exists.
            var iotCentralAppExists = await appsCollection.ExistsAsync(appName, CancellationToken.None);
            Assert.True(iotCentralAppExists);
        }
    }
}
