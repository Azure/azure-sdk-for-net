// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientLiveTests : KeysTestBase
    {
        public KeyClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CreateKey()
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
            RegisterForCleanup(key);

            Key keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task CreateKeyWithOptions()
        {
            var keyOptions = new KeyCreateOptions()
            {
                KeyOperations = new List<KeyOperations>() { KeyOperations.Verify },
                Enabled = false
            };

            Key key = await Client.CreateKeyAsync(Recording.GenerateId(), KeyType.EllipticCurve, keyOptions);
            RegisterForCleanup(key);

            Key keyReturned = await Client.GetKeyAsync(key.Name);

            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6551")]
        public async Task CreateEcHsmKey()
        {
            var echsmkey = new EcKeyCreateOptions(Recording.GenerateId(), hsm: true);
            Key keyHsm = await Client.CreateEcKeyAsync(echsmkey);
            RegisterForCleanup(keyHsm);

            Key keyReturned = await Client.GetKeyAsync(keyHsm.Name);
            AssertKeysEqual(keyHsm, keyReturned);
        }

        [Test]
        public async Task CreateEcKey()
        {
            var eckey = new EcKeyCreateOptions(Recording.GenerateId(), hsm: false);
            Key keyNoHsm = await Client.CreateEcKeyAsync(eckey);
            RegisterForCleanup(keyNoHsm);

            Key keyReturned = await Client.GetKeyAsync(keyNoHsm.Name);
            AssertKeysEqual(keyNoHsm, keyReturned);
        }

        [Test]
        public async Task CreateEcWithCurveKey()
        {
            var ecCurveKey = new EcKeyCreateOptions(Recording.GenerateId(), hsm: false, KeyCurveName.P256);
            Key keyNoHsmCurve = await Client.CreateEcKeyAsync(ecCurveKey);
            RegisterForCleanup(keyNoHsmCurve);

            Key keyReturned = await Client.GetKeyAsync(ecCurveKey.Name);
            AssertKeysEqual(keyNoHsmCurve, keyReturned);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6551")]
        public async Task CreateRsaHsmKey()
        {
            var rsaHsmkey = new RsaKeyCreateOptions(Recording.GenerateId(), hsm: true);
            Key keyHsm = await Client.CreateRsaKeyAsync(rsaHsmkey);
            RegisterForCleanup(keyHsm);

            Key keyReturned = await Client.GetKeyAsync(keyHsm.Name);
            AssertKeysEqual(keyHsm, keyReturned);
        }

        [Test]
        public async Task CreateRsaKey()
        {
            var rsaKey = new RsaKeyCreateOptions(Recording.GenerateId(), hsm: false);
            Key key = await Client.CreateRsaKeyAsync(rsaKey);
            RegisterForCleanup(key);

            Key keyReturned = await Client.GetKeyAsync(key.Name);
            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task CreateRsaWithSizeKey()
        {
            var rsaSizeKey = new RsaKeyCreateOptions(name: Recording.GenerateId(), hsm: false, keySize: 2048);
            Key key = await Client.CreateRsaKeyAsync(rsaSizeKey);
            RegisterForCleanup(key);

            Key keyReturned = await Client.GetKeyAsync(rsaSizeKey.Name);
            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task UpdateKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
            RegisterForCleanup(key);

            key.Expires = key.Created;
            Key updateResult = await Client.UpdateKeyAsync(key, key.KeyMaterial.KeyOps);

            AssertKeysEqual(key, updateResult);
        }

        [Test]
        public async Task UpdateEnabled()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
            RegisterForCleanup(key);

            key.Enabled = false;
            Key updateResult = await Client.UpdateKeyAsync(key, key.KeyMaterial.KeyOps);
            Key keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeysEqual(keyReturned, updateResult);
        }
        
        [Test]
        public async Task DeleteKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);

            RegisterForCleanup(key, delete: false);

            DeletedKey deletedKey = await Client.DeleteKeyAsync(keyName);

            Assert.NotNull(deletedKey.DeletedDate);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);
            AssertKeysEqual(key, deletedKey);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));
        }
        
        [Test]
        public async Task GetDeletedKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);

            RegisterForCleanup(key, delete: false);

            DeletedKey deletedKey = await Client.DeleteKeyAsync(keyName);

            await WaitForDeletedKey(keyName);

            DeletedKey polledSecret = await Client.GetDeletedKeyAsync(keyName);

            Assert.NotNull(deletedKey.DeletedDate);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);

            AssertKeysEqual(deletedKey, polledSecret);
            AssertKeysEqual(key, polledSecret);
        }
    }
}