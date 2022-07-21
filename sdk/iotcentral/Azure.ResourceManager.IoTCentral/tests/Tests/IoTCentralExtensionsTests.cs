// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IoTCentral.Models;
using Azure.Core;
using System.Threading;

namespace Azure.ResourceManager.IoTCentral.Tests
{
    public class IoTCentralExtensionsTests : IoTCentralManagementTestBase
    {
        public IoTCentralExtensionsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralAppByResourceIdTest()
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
            var createdAppOperation = await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            var createdApp = createdAppOperation.Value;

            // Read IoT Central application.
            var iotCentralApp = Client.GetIoTCentralAppResource(createdApp.Id);
            await iotCentralApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralListSubscriptionApplicationsTest()
        {
            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIoTCentralApps();

            // Create IoT Central applications.
            var appNames = new List<string>() { GetRandomTestName(), GetRandomTestName(), GetRandomTestName() };
            foreach (var appName in appNames)
            {
                var iotCentralAppData = new IoTCentralAppData(AzureLocation.WestUS, new IoTCentralAppSkuInfo(IoTCentralAppSku.ST0))
                {
                    DisplayName = appName,
                    Subdomain = appName,
                };
                await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            }

            // Get and delete IoT Central apps.
            await foreach (var subApp in subscription.GetIoTCentralAppsAsync(CancellationToken.None))
            {
                if (appNames.Contains(subApp.Data.Name))
                {
                    appNames.Remove(subApp.Data.Name);
                    await subApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
                }
            }

            // Assert all apps created were found and deleted.
            Assert.IsFalse(appNames.Any());
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralListResourceGroupApplicationsTest()
        {
            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIoTCentralApps();

            // Create IoT Central applications.
            var appNames = new List<string>() { GetRandomTestName(), GetRandomTestName(), GetRandomTestName() };
            foreach (var appName in appNames)
            {
                var iotCentralAppData = new IoTCentralAppData(AzureLocation.WestUS, new IoTCentralAppSkuInfo(IoTCentralAppSku.ST0))
                {
                    DisplayName = appName,
                    Subdomain = appName,
                };
                await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            }

            // Get and delete IoT Central apps.
            await foreach (var rgApp in appsCollection.GetAllAsync())
            {
                if (appNames.Contains(rgApp.Data.Name))
                {
                    appNames.Remove(rgApp.Data.Name);
                    await rgApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
                }
            }

            // Assert all apps created were found and deleted.
            Assert.IsFalse(appNames.Any());
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralCheckNameTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var appAvailabilityInfoResponse = await subscription.CheckIoTCentralAppNameAvailabilityAsync(new IoTCentralAppNameAvailabilityContent(GetRandomTestName()), CancellationToken.None);
            var appAvailabilityInfo = appAvailabilityInfoResponse.Value;

            Assert.IsTrue(appAvailabilityInfo.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralCheckSubdomainTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var appAvailabilityInfoResponse = await subscription.CheckIoTCentralAppSubdomainAvailabilityAsync(new IoTCentralAppNameAvailabilityContent(GetRandomTestName()), CancellationToken.None);
            var appAvailabilityInfo = appAvailabilityInfoResponse.Value;

            Assert.IsTrue(appAvailabilityInfo.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task IoTCentralAppTemplatesTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var firstAppTemplate = await subscription.GetTemplatesAppsAsync(CancellationToken.None).FirstOrDefaultAsync((_) => true, CancellationToken.None);

            Assert.IsNotNull(firstAppTemplate);
        }
    }
}
