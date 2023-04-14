// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.DataProtectionBackup.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.DataProtectionBackup.Tests.TestCase
{
    public class BackupVaultTests : DataProtectionBackupManagementTestBase
    {
        public BackupVaultTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataProtectionBackupVaultCollection> GetAccountCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDataProtectionBackupVaults();
        }

        public static DataProtectionBackupVaultData GetData()
        {
            IEnumerable<DataProtectionBackupStorageSetting> setting = new List<DataProtectionBackupStorageSetting>() { new DataProtectionBackupStorageSetting()
            {
                DataStoreType = StorageSettingStoreType.VaultStore,
                StorageSettingType = StorageSettingType.ZoneRedundant
            },
            new DataProtectionBackupStorageSetting()
            {
                DataStoreType = StorageSettingStoreType.OperationalStore,
                StorageSettingType = StorageSettingType.ZoneRedundant
            }
            };
            var data = new DataProtectionBackupVaultData(AzureLocation.EastUS, new Models.DataProtectionBackupVaultProperties(setting));
            return data;
        }

        [Test]
        public async Task IdTests()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var name = Recording.GenerateAssetName("vault");
            var input = GetData();
            //DataProtectionBackupVaultResource backupVault;
            string id;
            if (Mode == RecordedTestMode.Playback)
            {
                ResourceIdentifier resourceId = DataProtectionBackupVaultResource.CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, name);
                DataProtectionBackupVaultResource resource = Client.GetDataProtectionBackupVaultResource(resourceId);
                //backupVault = await resource.GetAsync();
                id = resource.Id;
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    DataProtectionBackupVaultCollection collection = resourceGroup.GetDataProtectionBackupVaults();
                    var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
                    DataProtectionBackupVaultResource resource = lro.Value;
                    //backupVault = await resource.GetAsync();
                    id = resource.Id;
                }
            };
            Console.WriteLine(id);
        }
    }
}
