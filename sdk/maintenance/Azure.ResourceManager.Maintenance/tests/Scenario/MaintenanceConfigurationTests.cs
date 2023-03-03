// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task DeleteTest()
        {
            MaintenanceConfigurationResource maintenanceConfigurationResource = await Create();

            await maintenanceConfigurationResource.DeleteAsync(WaitUntil.Completed);

            MaintenanceConfigurationCollection collection = _resourceGroup.GetMaintenanceConfigurations();

            var exist = await collection.ExistsAsync(maintenanceConfigurationResource.Data.Name);
            Assert.IsFalse(exist.Value);
        }

        [RecordedTest]
        public async Task CreateTest()
        {
            MaintenanceConfigurationResource maintenanceConfigurationResource = await Create();
            Assert.IsNotEmpty(maintenanceConfigurationResource.Data.Id);
        }

        [RecordedTest]
        public async Task ListTest()
        {
            MaintenanceConfigurationResource config1 = await Create();
            MaintenanceConfigurationResource config2 = await Create();

            var list = await _configCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(list.Count >= 2);
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Exists(item => item.Data.Name == config1.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == config2.Data.Name));
        }

        [RecordedTest]
        public async Task GetTest()
        {
            MaintenanceConfigurationResource config = await Create();

            var retrieveConfig = await _configCollection.GetAsync(config.Data.Name);
            Assert.IsNotEmpty(retrieveConfig.Value.Data.Id);
        }

        private async Task<MaintenanceConfigurationResource> Create()
        {
            string resourceName = Recording.GenerateAssetName("maintenance-config-");
            MaintenanceConfigurationData data = new MaintenanceConfigurationData(Location)
            {
                Namespace = "Microsoft.Maintenance",
                MaintenanceScope = MaintenanceScope.Host,
                Visibility = MaintenanceConfigurationVisibility.Custom,
                StartOn = DateTimeOffset.UtcNow,
                ExpireOn = DateTimeOffset.Parse("9999-12-31 00:00"),
                Duration = TimeSpan.Parse("05:00"),
                TimeZone = "Pacific Standard Time",
                RecurEvery = "Day",
            };
            ArmOperation<MaintenanceConfigurationResource> lro = await _configCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            return lro.Value;
        }
    }
}
