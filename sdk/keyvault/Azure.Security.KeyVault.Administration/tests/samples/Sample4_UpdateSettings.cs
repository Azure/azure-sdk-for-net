// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample4_UpdateSettings : SettingsTestBase
    {
        public Sample4_UpdateSettings(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [SyncOnly]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string managedHsmUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:KeyVaultSettingsClient_Create
            KeyVaultSettingsClient client = new KeyVaultSettingsClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
            #endregion
        }

        [RecordedTest]
        [SyncOnly]
        public void UpdateSettingSync()
        {
            KeyVaultSettingsClient client = Client;

            #region Snippet:KeyVaultSettingsClient_UpdateSettingSync
            KeyVaultSetting current = client.GetSetting("AllowKeyManagementOperationsThroughARM");

            KeyVaultSetting updated = new KeyVaultSetting(current.Name, true);
#if SNIPPET
            client.UpdateSetting(updated);
#else
            updated = client.UpdateSetting(updated);
            Assert.IsTrue(updated.Value.AsBoolean());
#endif
            #endregion
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task UpdateSettingAsync()
        {
            KeyVaultSettingsClient client = Client;

            #region Snippet:KeyVaultSettingsClient_UpdateSettingAsync
            KeyVaultSetting current = await client.GetSettingAsync("AllowKeyManagementOperationsThroughARM");

            KeyVaultSetting updated = new KeyVaultSetting(current.Name, true);
#if SNIPPET
            await client.UpdateSettingAsync(updated);
#else
            updated = await client.UpdateSettingAsync(updated);
            Assert.IsTrue(updated.Value.AsBoolean());
#endif
            #endregion
        }
    }
}
