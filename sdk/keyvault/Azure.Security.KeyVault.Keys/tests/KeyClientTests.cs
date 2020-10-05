// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientTests : ClientTestBase
    {
        public KeyClientTests(bool isAsync) : base(isAsync)
        {
            KeyClientOptions options = new KeyClientOptions
            {
                Transport = new MockTransport(),
            };

            Client = InstrumentClient(new KeyClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public KeyClient Client { get; set; }

        [Test]
        public void CreateKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateKeyAsync(null, KeyType.Ec));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync("name", default));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync(string.Empty, KeyType.Ec));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateEcKeyAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateRsaKeyAsync(null));
        }

        [Test]
        public void UpdateKeyPropertiesArgumentValidation()
        {
            var keyOperations = new List<KeyOperation>() { KeyOperation.Sign };
            var key = new KeyProperties("name");

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyPropertiesAsync(null, null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyPropertiesAsync(null, keyOperations));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyPropertiesAsync(key, null));
        }

        [Test]
        public void RestoreKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreKeyBackupAsync(null));
        }

        [Test]
        public void PurgeDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void GetKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetKeyAsync(string.Empty));
        }

        [Test]
        public void DeleteKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartDeleteKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartDeleteKeyAsync(string.Empty));
        }

        [Test]
        public void GetDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void RecoverDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartRecoverDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartRecoverDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void BackupKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.BackupKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.BackupKeyAsync(string.Empty));
        }

        [Test]
        public void ImportKeyArgumentValidation()
        {
            var jwk = new JsonWebKey();
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ImportKeyAsync(string.Empty, jwk));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null, jwk));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null, null));
        }

        [Test]
        public void GetKeyVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetPropertiesOfKeyVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetPropertiesOfKeyVersionsAsync(string.Empty));
        }

        [Test]
        public void ChallengeBasedAuthenticationRequiresHttps()
        {
            // After passing parameter validation, ChallengeBasedAuthenticationPolicy should throw for "http" requests.
            Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetKeyAsync("test"));
        }
    }
}
