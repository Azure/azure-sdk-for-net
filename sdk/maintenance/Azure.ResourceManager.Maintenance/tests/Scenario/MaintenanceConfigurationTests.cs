// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests
{
    public sealed class MaintenanceConfigurationTests : MaintenanceManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private MaintenanceConfigurationCollection _configCollection;

        public MaintenanceConfigurationTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task Setup()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();

            _resourceGroup = await CreateResourceGroup(
               _subscription,
               "Maintenance-RG-",
               Location);

            _configCollection = _resourceGroup.GetMaintenanceConfigurations();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Delete()
        {
            MaintenanceConfigurationResource maintenanceConfigurationResource = await CreateMaintenanceConfiguration();

            var deleted = await maintenanceConfigurationResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsNotEmpty(deleted.Value.Data.Id);

            MaintenanceConfigurationCollection collection = _resourceGroup.GetMaintenanceConfigurations();

            var exist = await collection.ExistsAsync(maintenanceConfigurationResource.Data.Name);
            Assert.IsFalse(exist.Value);
        }

        [RecordedTest]
        public async Task Create()
        {
            MaintenanceConfigurationResource maintenanceConfigurationResource = await CreateMaintenanceConfiguration();
            Assert.IsNotEmpty(maintenanceConfigurationResource.Data.Id);
            Assert.AreEqual(maintenanceConfigurationResource.Data.StartOn, new DateTimeOffset(2024, 12, 31, 14, 0, 0, TimeSpan.Zero));
            Assert.AreEqual(maintenanceConfigurationResource.Data.ExpireOn, new DateTimeOffset(9999, 12, 31, 0, 0, 0, TimeSpan.Zero));
        }

        [RecordedTest]
        public async Task List()
        {
            MaintenanceConfigurationResource config1 = await CreateMaintenanceConfiguration();
            MaintenanceConfigurationResource config2 = await CreateMaintenanceConfiguration();

            var list = await _configCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(list.Count >= 2);
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == config1.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == config2.Data.Name));
        }

        [RecordedTest]
        public async Task Get()
        {
            MaintenanceConfigurationResource config = await CreateMaintenanceConfiguration();

            var retrieveConfig = await _configCollection.GetAsync(config.Data.Name);
            Assert.IsNotEmpty(retrieveConfig.Value.Data.Id);
        }

        private async Task<MaintenanceConfigurationResource> CreateMaintenanceConfiguration()
        {
            string resourceName = Recording.GenerateAssetName("maintenance-config-");
            MaintenanceConfigurationData data = new MaintenanceConfigurationData(Location)
            {
                Namespace = "Microsoft.Maintenance",
                MaintenanceScope = MaintenanceScope.InGuestPatch,
                Visibility = MaintenanceConfigurationVisibility.Custom,
                StartOn = DateTimeOffset.Parse("2024-12-31 14:00"),
                ExpireOn = DateTimeOffset.Parse("9999-12-31 00:00"),
                Duration = TimeSpan.Parse("03:00"),
                TimeZone = "Pacific Standard Time",
                RecurEvery = "Day",

                // TODO: These tests are commented out for patch release.
                //InstallPatches = new MaintenancePatchConfiguration(MaintenanceRebootOption.Always,
                //    new MaintenanceWindowsPatchSettings(new List<string>(), new List<string>(), new List<string>() { "Security", "Critical" }, false, null),
                //    new MaintenanceLinuxPatchSettings(new List<string>(), new List<string>(), new List<string>() { "Security", "Critical" }, null), null)
            };
            data.ExtensionProperties.Add("InGuestPatchMode", "User");

            ArmOperation<MaintenanceConfigurationResource> lro = await _configCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            return lro.Value;
        }
    }
}
