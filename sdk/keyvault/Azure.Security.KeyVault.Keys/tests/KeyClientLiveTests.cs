// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientLiveTests : KeysTestBase
    {
        private const int PagedKeyCount = 2;

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
        public async Task GetKey()
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
            RegisterForCleanup(key);

            Key keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public void GetKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task GetKeyWithVersion()
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
            RegisterForCleanup(key);

            Key keyReturned = await Client.GetKeyAsync(keyName, key.Version);

            AssertKeysEqual(key, keyReturned);
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
        public void DeleteKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.DeleteKeyAsync(Recording.GenerateId()));
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

        [Test]
        public void GetDeletedKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedKeyAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task RecoverDeletedKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);

            DeletedKey deletedKey = await Client.DeleteKeyAsync(keyName);

            await WaitForDeletedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            KeyBase recoverKeyResult = await Client.RecoverDeletedKeyAsync(keyName);

            await PollForKey(keyName);

            Key recoveredKey = await Client.GetKeyAsync(keyName);

            RegisterForCleanup(recoveredKey);

            AssertKeysEqual(key, deletedKey);
            AssertKeysEqual(key, recoverKeyResult);
            AssertKeysEqual(key, recoveredKey);
        }

        [Test]
        public void RecoverDeletedKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RecoverDeletedKeyAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task BackupKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);

            RegisterForCleanup(key);

            byte[] backup = await Client.BackupKeyAsync(keyName);

            Assert.NotNull(backup);
        }

        [Test]
        public void BackupKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.BackupKeyAsync(Recording.GenerateId()));
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6514")]
        public async Task RestoreKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);

            byte[] backup = await Client.BackupKeyAsync(keyName);

            await Client.DeleteKeyAsync(keyName);
            await WaitForDeletedKey(keyName);

            await Client.PurgeDeletedKeyAsync(keyName);
            await WaitForPurgedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            Key restoredResult = await Client.RestoreKeyAsync(backup);
            RegisterForCleanup(restoredResult);

            AssertKeysEqual(key, restoredResult);
        }

        [Test]
        public void RestoreKeyNonExisting()
        {
            byte[] backupMalformed = Encoding.ASCII.GetBytes("non-existing");
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RestoreKeyAsync(backupMalformed));
        }

        [Test]
        public async Task GetKeys()
        {
            string keyName = Recording.GenerateId();

            List<Key> createdKeys = new List<Key>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                Key Key = await Client.CreateKeyAsync(keyName + i, KeyType.EllipticCurve);
                createdKeys.Add(Key);
                RegisterForCleanup(Key);
            }

            List<Response<KeyBase>> allKeys = await Client.GetKeysAsync().ToEnumerableAsync();

            foreach (Key createdKey in createdKeys)
            {
                KeyBase returnedKey = allKeys.Single(s => s.Value.Name == createdKey.Name);
                AssertKeysEqual(createdKey, returnedKey);
            }
        }

        [Test]
        public async Task GetDeletedKeys()
        {
            string keyName = Recording.GenerateId();

            List<Key> createdKeys = new List<Key>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                Key Key = await Client.CreateKeyAsync(keyName + i, KeyType.EllipticCurve);
                createdKeys.Add(Key);
                await Client.DeleteKeyAsync(keyName + i);

                RegisterForCleanup(Key, delete: false);
            }

            foreach (Key deletedKey in createdKeys)
            {
                await WaitForDeletedKey(deletedKey.Name);
            }

            List<Response<DeletedKey>> allKeys = await Client.GetDeletedKeysAsync().ToEnumerableAsync();

            foreach (Key createdKey in createdKeys)
            {
                KeyBase returnedKey = allKeys.Single(s => s.Value.Name == createdKey.Name);
                AssertKeysEqual(createdKey, returnedKey);
            }
        }

        [Test]
        public async Task GetKeysVersions()
        {
            string keyName = Recording.GenerateId();

            List<Key> createdKeys = new List<Key>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                Key Key = await Client.CreateKeyAsync(keyName, KeyType.EllipticCurve);
                createdKeys.Add(Key);
            }
            RegisterForCleanup(createdKeys.First());

            List<Response<KeyBase>> allKeys = await Client.GetKeyVersionsAsync(keyName).ToEnumerableAsync();

            foreach (Key createdKey in createdKeys)
            {
                KeyBase returnedKey = allKeys.Single(s => s.Value.Version == createdKey.Version);
                AssertKeysEqual(createdKey, returnedKey);
            }
        }

        [Test]
        public async Task GetKeysVersionsNonExisting()
        {
            int count = 0;
            List<Response<KeyBase>> allKeys = await Client.GetKeyVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();
            foreach (KeyBase key in allKeys)
            {
                count++;
            }
            Assert.AreEqual(0, count);
        }
    }
}