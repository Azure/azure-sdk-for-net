// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MySql.FlexibleServers;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.MySql.Tests
{
    public class MySqlFlexibleServerAdvancedThreatProtectionTests: MySqlManagementTestBase
    {
        public MySqlFlexibleServerAdvancedThreatProtectionTests(bool isAsync)
            : base(isAsync)//,RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAndSetAdvancedThreatProtectionSettings()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlflexrg", AzureLocation.EastUS);
            MySqlFlexibleServerCollection serverCollection = rg.GetMySqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("mysqlflexserver");
            var serverData = new MySqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new MySqlFlexibleServerSku("Standard_B1ms", MySqlFlexibleServerSkuTier.Burstable),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "5.7",
                Storage = new MySqlFlexibleServerStorage() { StorageSizeInGB = 512 },
                CreateMode = MySqlFlexibleServerCreateMode.Default,
                Backup = new MySqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = 7
                },
                Network = new MySqlFlexibleServerNetwork(),
                HighAvailability = new MySqlFlexibleServerHighAvailability() { Mode = MySqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, serverData);
            MySqlFlexibleServerResource mySqlFlexibleServer = lro.Value;
            Assert.AreEqual(serverName, mySqlFlexibleServer.Data.Name);

            // List all Advance Threat Protection Settings
            AdvancedThreatProtectionCollection collection = mySqlFlexibleServer.GetAdvancedThreatProtections();
            // invoke the operation and iterate over the result
            await foreach (AdvancedThreatProtectionResource td in collection.GetAllAsync())
            {
                Console.WriteLine($"Found Advanced Threat Protection Settings: {td.Id}");
                Assert.AreEqual("Disabled", td.Data.State.ToString(), "Found an Advanced Threat Protection Settings, where state is not Disabled");
            }

            // Get Advanced Threat Protection Settings Default
            AdvancedThreatProtectionName advancedThreatProtectionNameDefault = AdvancedThreatProtectionName.Default;
            AdvancedThreatProtectionResource result = await mySqlFlexibleServer.GetAdvancedThreatProtectionAsync(advancedThreatProtectionNameDefault);
            Assert.AreEqual("Disabled", result.Data.State.ToString(), "Found an Advanced Threat Protection Settings, where state is not Disabled");

            // Set Enable by using patch api
            AdvancedThreatProtectionResource advancedThreatProtection = await mySqlFlexibleServer.GetAdvancedThreatProtectionAsync(advancedThreatProtectionNameDefault);
            // invoke the operation
            AdvancedThreatProtectionPatch patch = new AdvancedThreatProtectionPatch()
            {
                State = AdvancedThreatProtectionState.Enabled,
            };
            ArmOperation<AdvancedThreatProtectionResource> lroPatchATP = await advancedThreatProtection.UpdateAsync(WaitUntil.Completed, patch);
            AdvancedThreatProtectionResource resultPatchATP = lroPatchATP.Value;
            Assert.AreEqual("Enabled", resultPatchATP.Data.State.ToString(), "Set Advanced Threat Protection Settings state is not enabled");

            // Get Advanced Threat Protection Settings Default
            result = await mySqlFlexibleServer.GetAdvancedThreatProtectionAsync(advancedThreatProtectionNameDefault);
            Assert.AreEqual("Enabled", result.Data.State.ToString(), "Found an Advanced Threat Protection Settings, where state is not Enabled");

            // Set Enable by using put api
            // invoke the operation
            AdvancedThreatProtectionData data = new AdvancedThreatProtectionData()
            {
                State = AdvancedThreatProtectionState.Disabled,
            };
            ArmOperation<AdvancedThreatProtectionResource> lroPutATP = await collection.CreateOrUpdateAsync(WaitUntil.Completed, advancedThreatProtectionNameDefault, data);
            AdvancedThreatProtectionResource resultPutATP = lroPutATP.Value;
            Assert.AreEqual("Disabled", resultPutATP.Data.State.ToString(), "Set Advanced Threat Protection Settings state is not Disabled");

            // Get Advanced Threat Protection Settings Default
            result = await mySqlFlexibleServer.GetAdvancedThreatProtectionAsync(advancedThreatProtectionNameDefault);
            Assert.AreEqual("Disabled", result.Data.State.ToString(), "Found an Advanced Threat Protection Settings, where state is not Disabled");
        }
    }
}
