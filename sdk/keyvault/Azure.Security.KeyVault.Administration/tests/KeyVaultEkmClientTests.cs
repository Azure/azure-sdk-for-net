// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
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

        [Test]
        public void GetEkmPrivateEndpointNullOrEmptyPrivateEndpointNameThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.GetEkmPrivateEndpoint(null));
            Assert.Throws<ArgumentException>(() => client.GetEkmPrivateEndpoint(string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.GetEkmPrivateEndpointAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.GetEkmPrivateEndpointAsync(string.Empty));
        }

        [Test]
        public void CreateEkmPrivateEndpointNullOrEmptyPrivateEndpointNameThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.CreateEkmPrivateEndpoint(WaitUntil.Started, null, "pls-id"));
            Assert.Throws<ArgumentException>(() => client.CreateEkmPrivateEndpoint(WaitUntil.Started, string.Empty, "pls-id"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.CreateEkmPrivateEndpointAsync(WaitUntil.Started, null, "pls-id"));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.CreateEkmPrivateEndpointAsync(WaitUntil.Started, string.Empty, "pls-id"));
        }

        [Test]
        public void CreateEkmPrivateEndpointNullOrEmptyPrivateLinkServiceAliasThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.CreateEkmPrivateEndpoint(WaitUntil.Started, "my-pe", (string)null));
            Assert.Throws<ArgumentException>(() => client.CreateEkmPrivateEndpoint(WaitUntil.Started, "my-pe", string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.CreateEkmPrivateEndpointAsync(WaitUntil.Started, "my-pe", (string)null));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.CreateEkmPrivateEndpointAsync(WaitUntil.Started, "my-pe", string.Empty));
        }

        [Test]
        public void DeleteEkmPrivateEndpointNullOrEmptyPrivateEndpointNameThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.DeleteEkmPrivateEndpoint(WaitUntil.Started, null));
            Assert.Throws<ArgumentException>(() => client.DeleteEkmPrivateEndpoint(WaitUntil.Started, string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.DeleteEkmPrivateEndpointAsync(WaitUntil.Started, null));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.DeleteEkmPrivateEndpointAsync(WaitUntil.Started, string.Empty));
        }

        [Test]
        public void GetEkmPrivateEndpointOperationStatusNullOrEmptyJobIdThrows()
        {
            KeyVaultEkmClient client = new(VaultUri, new MockCredential());
            Assert.Throws<ArgumentNullException>(() => client.GetEkmPrivateEndpointOperationStatus(null));
            Assert.Throws<ArgumentException>(() => client.GetEkmPrivateEndpointOperationStatus(string.Empty));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.GetEkmPrivateEndpointOperationStatusAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await client.GetEkmPrivateEndpointOperationStatusAsync(string.Empty));
        }
    }
}