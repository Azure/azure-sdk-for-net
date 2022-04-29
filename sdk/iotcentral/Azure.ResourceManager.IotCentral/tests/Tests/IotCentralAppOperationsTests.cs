// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IotCentral.Models;
using Azure.Identity;
using Azure.Core;
using System.Threading;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotCentral.Tests
{
    public class IotCentralAppOperationsTests : IotCentralManagementTestBase
    {
        public IotCentralAppOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralApplicationCrudOperationsTest()
        {
            var appName = Recording.GenerateAssetName("test-app-");

            // Initialize ARM client.
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // Get IoT Central apps collection for resource group.
            var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central application.
            var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new AppSkuInfo(AppSku.ST0))
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
                Sku = new AppSkuInfo(AppSku.ST1),
                Identity = new SystemAssignedServiceIdentity(ResourceManager.Models.SystemAssignedServiceIdentityType.SystemAssigned),
            };
            await iotCentralApp.UpdateAsync(WaitUntil.Completed, iotCentralAppPatch, CancellationToken.None);

            // Delete IoT Central application.
            await iotCentralApp.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralListSubscriptionApplicationsTest()
        {
            // Initialize ARM client.
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // Get IoT Central apps collection for resource group.
            var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central applications.
            var appNames = new List<string>() { GetRandomTestAppName(), GetRandomTestAppName(), GetRandomTestAppName() };
            foreach (var appName in appNames)
            {
                var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new AppSkuInfo(AppSku.ST0))
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
            // Initialize ARM client.
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // Get IoT Central apps collection for resource group.
            var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var rg = await CreateResourceGroupAsync(subscription, "sdk-test-rg-");

            var appsCollection = rg.GetIotCentralApps();

            // Create IoT Central applications.
            var appNames = new List<string>() { GetRandomTestAppName(), GetRandomTestAppName(), GetRandomTestAppName() };
            foreach (var appName in appNames)
            {
                var iotCentralAppData = new IotCentralAppData(AzureLocation.WestUS, new AppSkuInfo(AppSku.ST0))
                {
                    DisplayName = appName,
                    Subdomain = appName,
                };
                await appsCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, iotCentralAppData, CancellationToken.None);
            }

            // Get and delete IoT Central apps.
            await foreach (var rgApp in rg.GetIotCentralApps())
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
            // Initialize ARM client.
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // Check name operation.
            var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var appAvailabilityInfoResponse = await subscription.CheckNameAvailabilityAppAsync(new OperationInputs(Guid.NewGuid().ToString()), CancellationToken.None);
            var appAvailabilityInfo = appAvailabilityInfoResponse.Value;

            Assert.IsTrue(appAvailabilityInfo.NameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralCheckSubdomainTest()
        {
            // Initialize ARM client.
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // Check subdomain operation.
            var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var appAvailabilityInfoResponse = await subscription.CheckSubdomainAvailabilityAppAsync(new OperationInputs(Guid.NewGuid().ToString()), CancellationToken.None);
            var appAvailabilityInfo = appAvailabilityInfoResponse.Value;

            Assert.IsTrue(appAvailabilityInfo.NameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotCentralAppTemplatesTest()
        {
            // Initialize ARM client.
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // List app templates.
            var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{SessionEnvironment.SubscriptionId}"));
            var firstAppTemplate = await subscription.GetTemplatesAppsAsync(CancellationToken.None).FirstOrDefaultAsync((_) => true, CancellationToken.None);

            Assert.IsNotNull(firstAppTemplate);
        }
    }
}
