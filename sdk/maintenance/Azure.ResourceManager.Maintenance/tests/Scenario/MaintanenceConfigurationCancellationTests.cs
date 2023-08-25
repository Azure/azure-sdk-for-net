// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Configuration.Provider;
using System.Security.AccessControl;
using Newtonsoft.Json;

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
               AzureLocation.CentralUS);

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
            MaintenanceConfigurationResource config = await CreateMaintenanceConfiguration(resourceName);

            Console.WriteLine("Got config: " + JsonConvert.SerializeObject(config.Data));
            Console.WriteLine("Here1 - " + DateTime.Now);

            MaintenanceApplyUpdateData data = new MaintenanceApplyUpdateData()
            {
                Status = MaintenanceUpdateStatus.Cancel,
            };
            string providerName = "Microsoft.Maintenance";
            string resourceType = "maintenanceConfigurations";
            string applyUpdateName = "20230901121200";

            //await Delay(15 * 60 * 1000);
            //await Delay(5 * 1000);
            //Console.WriteLine("Here - " + DateTime.Now);
            //var retrieveConfig = await _resourceGroup.GetMaintenanceConfigurations().GetAsync(config.Data.Name);
            //Assert.IsNotEmpty(retrieveConfig.Value.Data.Id);
            //Console.WriteLine("Got retrieved config: " + JsonConvert.SerializeObject(retrieveConfig.Value.Data));

            await Delay(5 * 1000);
            var exists = await _configCollection.ExistsAsync(providerName, resourceType, resourceName, applyUpdateName);
            Console.WriteLine("Exists: " + exists.Value);

           // await Delay(5 * 1000);
            //var retrieveUpdateConfig = await _configCollection.GetAsync(providerName, resourceType, resourceName, applyUpdateName);
            //Assert.IsNotEmpty(retrieveUpdateConfig.Value.Data.Id);
            //Console.WriteLine("Got retrieved update config: " + JsonConvert.SerializeObject(retrieveUpdateConfig.Value.Data));

            // wait 10 minutes
            //await Delay(10 * 60 * 1000);

            ArmOperation<MaintenanceApplyUpdateResource> lro = await _configCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName, resourceType, resourceName, applyUpdateName, data);
            MaintenanceApplyUpdateResource result = lro.Value;

            Console.WriteLine("Got update: " + JsonConvert.SerializeObject(result.Data));
        }

        private async Task<MaintenanceConfigurationResource> CreateMaintenanceConfiguration(string resourceName)
        {
            MaintenanceConfigurationData data = new MaintenanceConfigurationData(AzureLocation.CentralUS)
            {
                Namespace = "Microsoft.Maintenance",
                MaintenanceScope = MaintenanceScope.Host,
                Visibility = MaintenanceConfigurationVisibility.Custom,
                StartOn = DateTimeOffset.Parse("2023-12-31 00:00"),
                ExpireOn = DateTimeOffset.Parse("9999-12-31 00:00"),
                Duration = TimeSpan.Parse("05:00"),
                TimeZone = "Pacific Standard Time",
                RecurEvery = "Day",
            };
            ArmOperation<MaintenanceConfigurationResource> lro = await _resourceGroup.GetMaintenanceConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            return lro.Value;
        }
    }
}
