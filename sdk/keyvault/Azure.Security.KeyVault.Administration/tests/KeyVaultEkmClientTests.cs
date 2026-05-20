// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultEkmClientTests
    {
        private Uri VaultUri { get; } = new Uri("https://myhsm.managedhsm.azure.net");

        [Test]
        public void NewVaultUriNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => new KeyVaultEkmClient(null, new MockCredential()));

        [Test]
        public void NewCredentialNullThrows() =>
            Assert.Throws<ArgumentNullException>(() => new KeyVaultEkmClient(VaultUri, null));

        [Test]
        public void NewWithOptions_VaultUriNullThrows() =>
            Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmClient(null, new MockCredential(), new KeyVaultAdministrationClientOptions()));

        [Test]
        public void NewWithOptions_CredentialNullThrows() =>
            Assert.Throws<ArgumentNullException>(
                () => new KeyVaultEkmClient(VaultUri, null, new KeyVaultAdministrationClientOptions()));

        [Test]
        public void NewWithNullOptions_DoesNotThrow() =>
            Assert.DoesNotThrow(() => new KeyVaultEkmClient(VaultUri, new MockCredential(), null));

        [Test]
        public void VaultUri_ReturnsSuppliedUri()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.AreEqual(VaultUri, client.VaultUri);
        }

        [Test]
        public void CreateEkmConnectionNullThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.CreateEkmConnection(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.CreateEkmConnectionAsync(null));
        }

        [Test]
        public void UpdateEkmConnectionNullThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.UpdateEkmConnection(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.UpdateEkmConnectionAsync(null));
        }
    }
}