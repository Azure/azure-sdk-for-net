// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IotCentral.Models;
using Azure.Core;
using System.Threading;

namespace Azure.ResourceManager.IotCentral.Tests
{
    public class IotCentralExtensionsTests : IotCentralManagementTestBase
    {
        public IotCentralExtensionsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralAppByResourceIdTest()
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
            var createdAppOperation = await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            var createdApp = createdAppOperation.Value;

            // Read IoT Central application.
            var iotCentralApp = Client.GetIotCentralAppResource(createdApp.Id);
            await iotCentralApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralListSubscriptionApplicationsTest()
        {
            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central applications.
            var appNames = new List<string>() { GetRandomTestName(), GetRandomTestName(), GetRandomTestName() };
            foreach (var appName in appNames)
            {
                var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new IotCentralAppSkuInfo(IotCentralAppSku.ST0))
                {
                    DisplayName = appName,
                    Subdomain = appName,
                };
                await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            }

            // Get and delete IoT Central apps.
            await foreach (var subApp in subscription.GetIotCentralAppsAsync(CancellationToken.None))
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
        public async Task IotCentralListResourceGroupApplicationsTest()
        {
            // Get IoT Central apps collection for resource group.
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central applications.
            var appNames = new List<string>() { GetRandomTestName(), GetRandomTestName(), GetRandomTestName() };
            foreach (var appName in appNames)
            {
                var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new IotCentralAppSkuInfo(IotCentralAppSku.ST0))
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
        public async Task IotCentralCheckNameTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var appAvailabilityInfoResponse = await subscription.CheckIotCentralAppNameAvailabilityAsync(new IotCentralAppNameAvailabilityContent(GetRandomTestName()), CancellationToken.None);
            var appAvailabilityInfo = appAvailabilityInfoResponse.Value;

            Assert.IsTrue(appAvailabilityInfo.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralCheckSubdomainTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var appAvailabilityInfoResponse = await subscription.CheckIotCentralAppSubdomainAvailabilityAsync(new IotCentralAppNameAvailabilityContent(GetRandomTestName()), CancellationToken.None);
            var appAvailabilityInfo = appAvailabilityInfoResponse.Value;

            Assert.IsTrue(appAvailabilityInfo.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralAppTemplatesTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var firstAppTemplate = await subscription.GetTemplatesAppsAsync(CancellationToken.None).FirstOrDefaultAsync((_) => true, CancellationToken.None);

            Assert.IsNotNull(firstAppTemplate);
        }
    }
}
