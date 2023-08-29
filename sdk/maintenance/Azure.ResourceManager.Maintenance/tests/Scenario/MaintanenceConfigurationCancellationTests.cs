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
               new AzureLocation("centraluseuap"));

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
            string resourceName = Recording.GenerateAssetName("maintenance-config-adanapopescu-");
            DateTime startOn = DateTime.UtcNow.AddMinutes(42);
            MaintenanceConfigurationResource config = await CreateMaintenanceConfiguration(resourceName, startOn);

            Console.WriteLine("Got config: " + JsonConvert.SerializeObject(config.Data));
            Console.WriteLine("Here1 - " + DateTime.Now);

            MaintenanceApplyUpdateData data = new MaintenanceApplyUpdateData()
            {
                Status = MaintenanceUpdateStatus.Cancel,
            };
            string providerName = "Microsoft.Maintenance";
            string resourceType = "maintenanceConfigurations";
            string applyUpdateName = $"{startOn:yyyyMMddHHmmss}";

            //await Delay(15 * 60 * 1000);
            //await Delay(5 * 1000);
            //Console.WriteLine("Here - " + DateTime.Now);
            //var retrieveConfig = await _resourceGroup.GetMaintenanceConfigurations().GetAsync(config.Data.Name);
            //Assert.IsNotEmpty(retrieveConfig.Value.Data.Id);
            //Console.WriteLine("Got retrieved config: " + JsonConvert.SerializeObject(retrieveConfig.Value.Data));

            //await Delay(5 * 1000);
            var exists = await _configCollection.ExistsAsync(providerName, resourceType, resourceName, applyUpdateName);
            Console.WriteLine("Exists: " + exists.Value);

            // await Delay(5 * 1000);
            //var retrieveUpdateConfig = await _configCollection.GetAsync(providerName, resourceType, resourceName, applyUpdateName);
            //Assert.IsNotEmpty(retrieveUpdateConfig.Value.Data.Id);
            //Console.WriteLine("Got retrieved update config: " + JsonConvert.SerializeObject(retrieveUpdateConfig.Value.Data));

            // wait 10 minutes
            await Delay(10 * 60 * 1000);
            Console.WriteLine("Here2 - " + DateTime.Now);

            ArmOperation<MaintenanceApplyUpdateResource> lro = await _configCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName, resourceType, resourceName, applyUpdateName, data);
            MaintenanceApplyUpdateResource result = lro.Value;

            Console.WriteLine("Got update: " + JsonConvert.SerializeObject(result.Data));
        }

        private async Task<MaintenanceConfigurationResource> CreateMaintenanceConfiguration(string resourceName, DateTime startOn)
        {
            MaintenanceConfigurationData data = new MaintenanceConfigurationData(new AzureLocation("centraluseuap"))
            {
                Namespace = "Microsoft.Maintenance",
                MaintenanceScope = MaintenanceScope.InGuestPatch,
                Visibility = MaintenanceConfigurationVisibility.Custom,
                StartOn = startOn,
                ExpireOn = DateTimeOffset.Parse("9999-12-31 00:00"),
                Duration = TimeSpan.Parse("03:55"),
                TimeZone = "Pacific Standard Time",
                RecurEvery = "Day",
                InstallPatches = new MaintenancePatchConfiguration()
                {
                    LinuxParameters = new MaintenanceLinuxPatchSettings (null, null, new List<string>() { "Critical", "Security" }),
                    RebootSetting=MaintenanceRebootOption.IfRequired,
                    WindowsParameters = new MaintenanceWindowsPatchSettings(),
                },
            };
            data.InstallPatches.WindowsParameters.ClassificationsToInclude.Add("CriticalUpdates");
            data.ExtensionProperties.Add("InGuestPatchMode", "User");

            ArmOperation<MaintenanceConfigurationResource> lro = await _resourceGroup.GetMaintenanceConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);

            return lro.Value;
        }
    }
}
