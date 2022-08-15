// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileTests : AutomanageTestBase
    {
        public ConfigurationProfileTests(bool async) : base(async) { }

        [Test]
        [RecordedTest]
        public async Task GetConfigurationProfile()
        {
            string rgName = Recording.GenerateAssetName("SDKAutomanage-rg");
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile");

            // create resource group
            var rg = await ResourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(DefaultLocation));

            // fetch configuration profile collection
            var collection = rg.Value.GetConfigurationProfiles();

            // create configruation profile
            string configuration = "{" +
                "\"Antimalware/Enable\":true," +
                "\"Antimalware/EnableRealTimeProtection\":true," +
                "\"Antimalware/RunScheduledScan\":true," +
                "\"Backup/Enable\":true," +
                "\"WindowsAdminCenter/Enable\":false," +
                "\"VMInsights/Enable\":true," +
                "\"AzureSecurityCenter/Enable\":true," +
                "\"UpdateManagement/Enable\":true," +
                "\"ChangeTrackingAndInventory/Enable\":true," +
                "\"GuestConfiguration/Enable\":true," +
                "\"AutomationAccount/Enable\":true," +
                "\"LogAnalytics/Enable\":true," +
                "\"BootDiagnostics/Enable\":true" +
                "}";

            ConfigurationProfileData data = new ConfigurationProfileData(DefaultLocation)
            {
                Configuration = new BinaryData(configuration)
            };

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, data);

            // fetch new configuration profile
            var profile = await collection.GetAsync(profileName);

            // assert
            VerifyConfigurationProfileProperties(profile);
        }
    }
}
