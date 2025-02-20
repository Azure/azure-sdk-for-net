// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests
{
    public sealed class MaintanenceConfigurationCancellationTests : MaintenanceManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private MaintenanceApplyUpdateCollection _configCollection;

        public MaintanenceConfigurationCancellationTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task Setup()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();

            _resourceGroup = await CreateResourceGroup(
               _subscription,
               "Maintenance-RG-",
               Location);

            _configCollection = _resourceGroup.GetMaintenanceApplyUpdates();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task MaintenanceConfigurationCancelTest()
        {
            string resourceName = Recording.GenerateAssetName("maintenance-config-");

            DateTimeOffset startOn = Recording.UtcNow.AddMinutes(12);
            MaintenanceConfigurationResource config = await CreateMaintenanceConfiguration(resourceName, startOn);
            Assert.IsNotEmpty(config.Data.Id);

            MaintenanceApplyUpdateData data = new MaintenanceApplyUpdateData()
            {
                Status = MaintenanceUpdateStatus.Cancel,
            };
            string providerName = "Microsoft.Maintenance";
            string resourceType = "maintenanceConfigurations";
            string applyUpdateName = $"{startOn:yyyyMMddHHmm00}";

            // wait 3 minutes
            await Delay(3 * 60 * 1000, playbackDelayMilliseconds: 0);

            // cancel the maintenance
            bool retry;
            do
            {
                try
                {
                    retry = false;
                    ArmOperation<MaintenanceApplyUpdateResource> lro = await _configCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName, resourceType, resourceName, applyUpdateName, data);
                    MaintenanceApplyUpdateResource result = lro.Value;

                    Assert.IsTrue(result.HasData);
                    Assert.AreEqual(result.Data.Status, MaintenanceUpdateStatus.Cancelled);
                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        retry = true;
                        await Delay(30 * 1000);
                    }
                    else
                    {
                        throw;
                    }
                }
            } while (retry && startOn > DateTime.UtcNow);

            if (retry)
            {
                Assert.Fail("Maintenance configuration could not be cancelled. Got 404 responses for all tries.");
            }
        }

        private async Task<MaintenanceConfigurationResource> CreateMaintenanceConfiguration(string resourceName, DateTimeOffset startOn)
        {
            MaintenanceConfigurationData data = new MaintenanceConfigurationData(Location)
            {
                Namespace = "Microsoft.Maintenance",
                MaintenanceScope = MaintenanceScope.InGuestPatch,
                Visibility = MaintenanceConfigurationVisibility.Custom,
                StartOn = startOn,
                ExpireOn = DateTimeOffset.Parse("9999-12-31 00:00"),
                Duration = TimeSpan.Parse("02:00"),
                TimeZone = "UTC",
                RecurEvery = "Day",
                InstallPatches = new MaintenancePatchConfiguration(MaintenanceRebootOption.Always,
                    new MaintenanceWindowsPatchSettings(new List<string>(), new List<string>(), new List<string>() { "Security", "Critical" }, false, null),
                    new MaintenanceLinuxPatchSettings(new List<string>(), new List<string>(), new List<string>() { "Security", "Critical" }, null), null)
            };
            data.ExtensionProperties.Add("InGuestPatchMode", "User");

            ArmOperation<MaintenanceConfigurationResource> lro = await _resourceGroup.GetMaintenanceConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);

            return lro.Value;
        }
    }
}
