// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultSettingsClientTests
    {
        private Uri VaultUri { get; } = new Uri("https://myhsm.managedhsm.azure.net");

        [Test]
        public void NewVaultUriNullThrows() => Assert.Throws<ArgumentNullException>(() => new KeyVaultSettingsClient(null, null));

        [Test]
        public void NewCredentialNullThrows() => Assert.Throws<ArgumentNullException>(() => new KeyVaultSettingsClient(VaultUri, null));

        [Test]
        public void GetSettingNameNullThrows()
        {
            KeyVaultSettingsClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.GetSetting(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.GetSettingAsync(null));
        }

        [Test]
        public void GetSettingNameEmptyThrows()
        {
            KeyVaultSettingsClient client = new(new Uri("https://myhsm.managedhsm.vault.net"), new MockCredential());
            Assert.Throws<ArgumentException>(() => client.GetSetting(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.GetSettingAsync(string.Empty));
        }

        [Test]
        public void UpdateSettingNullThrows()
        {
            KeyVaultSettingsClient client = new(new Uri("https://myhsm.managedhsm.vault.net"), new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.UpdateSetting(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.UpdateSettingAsync(null));
        }
    }
}
