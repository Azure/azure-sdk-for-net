// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        private async Task<MaintenanceConfigurationResource> Create()
        {
            // get the collection of this MaintenanceConfigurationResource
            MaintenanceConfigurationCollection collection = _resourceGroup.GetMaintenanceConfigurations();

            // invoke the operation
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
            ArmOperation<MaintenanceConfigurationResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            return lro.Value;
        }
    }
}
