// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientTests: ClientTestBase
    {
        public KeyClientTests(bool isAsync) : base(isAsync)
        {
            Client = InstrumentClient(new KeyClient(new Uri("http://localhost"), new DefaultAzureCredential()));
        }

        public KeyClient Client { get; set; }

        [Test]
        public void CreateKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync(null, KeyType.EllipticCurve));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateKeyAsync("name", default));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync("", KeyType.EllipticCurve));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateEcKeyAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateRsaKeyAsync(null));
        }

        [Test]
        public void UpdateKeyArgumentValidation()
        {
            var keyOperations = new List<KeyOperations>() { KeyOperations.Sign };
            var key = new KeyBase("name");

            Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateKeyAsync(null, null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateKeyAsync(null, keyOperations));
            Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateKeyAsync(key, null));
        }

        [Test]
        public void RestoreKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreKeyAsync(null));
        }

        [Test]
        public void PurgeDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedKeyAsync(""));
        }

        [Test]
        public void GetKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetKeyAsync(""));
        }

        [Test]
        public void DeleteKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteKeyAsync(""));
        }

        [Test]
        public void GetDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedKeyAsync(""));
        }

        [Test]
        public void RecoverDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecoverDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecoverDeletedKeyAsync(""));
        }

        [Test]
        public void BackupKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.BackupKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.BackupKeyAsync(""));
        }

        [Test]
        public void ImportKeyArgumentValidation()
        {
            var keyMaterial = new JsonWebKey();
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ImportKeyAsync("", keyMaterial));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ImportKeyAsync(null, keyMaterial));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ImportKeyAsync(null, null));
        }

        [Test]
        public void GetKeyVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentException>(() => Client.GetKeyVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetKeyVersionsAsync(""));
        }
    }
}