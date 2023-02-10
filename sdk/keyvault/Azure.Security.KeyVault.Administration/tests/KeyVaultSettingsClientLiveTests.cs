// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultSettingsClientLiveTests : SettingsTestBase
    {
        public KeyVaultSettingsClientLiveTests(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task GetSettings()
        {
            Response<GetSettingsResult> response = await Client.GetSettingsAsync();

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Settings, Is.Not.Empty);
        }

        // GetSetting and UpdateSetting are tested in samples/Sample4_UpdateSettings.cs.
    }
}
