// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetClient();

                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [Test]
        public async Task CreateKey()
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            Key keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task CreateKeyWithOptions()
        {
            var exp = new DateTimeOffset(new DateTime(637027248120000000, DateTimeKind.Utc));
            DateTimeOffset nbf = exp.AddDays(-30);

            var keyOptions = new KeyCreateOptions()
            {
                KeyOperations = new List<KeyOperation>() { KeyOperation.Verify },
                Enabled = false,
                Expires = exp,
                NotBefore = nbf,
            };

            Key key = await Client.CreateKeyAsync(Recording.GenerateId(), KeyType.Ec, keyOptions);
            RegisterForCleanup(key.Name);

            Key keyReturned = await Client.GetKeyAsync(key.Name);

            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6551")]
        public async Task CreateEcHsmKey()
        {
            var echsmkey = new EcKeyCreateOptions(Recording.GenerateId(), hsm: true);
            Key keyHsm = await Client.CreateEcKeyAsync(echsmkey);
            RegisterForCleanup(keyHsm.Name);

            Key keyReturned = await Client.GetKeyAsync(keyHsm.Name);
            AssertKeysEqual(keyHsm, keyReturned);
        }

        [Test]
        public async Task CreateEcKey()
        {
            var eckey = new EcKeyCreateOptions(Recording.GenerateId(), hsm: false);
            Key keyNoHsm = await Client.CreateEcKeyAsync(eckey);
            RegisterForCleanup(keyNoHsm.Name);

            Key keyReturned = await Client.GetKeyAsync(keyNoHsm.Name);
            AssertKeysEqual(keyNoHsm, keyReturned);
        }

        [Test]
        public async Task CreateEcWithCurveKey([Fields]KeyCurveName curve)
        {
            var ecCurveKey = new EcKeyCreateOptions(Recording.GenerateId(), hsm: false, curve);
            Key keyNoHsmCurve = await Client.CreateEcKeyAsync(ecCurveKey);

            RegisterForCleanup(keyNoHsmCurve.Name);

            Key keyReturned = await Client.GetKeyAsync(ecCurveKey.Name);
            AssertKeysEqual(keyNoHsmCurve, keyReturned);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6551")]
        public async Task CreateRsaHsmKey()
        {
            var rsaHsmkey = new RsaKeyCreateOptions(Recording.GenerateId(), hsm: true);
            Key keyHsm = await Client.CreateRsaKeyAsync(rsaHsmkey);
            RegisterForCleanup(keyHsm.Name);

            Key keyReturned = await Client.GetKeyAsync(keyHsm.Name);
            AssertKeysEqual(keyHsm, keyReturned);
        }

        [Test]
        public async Task CreateRsaKey()
        {
            var rsaKey = new RsaKeyCreateOptions(Recording.GenerateId(), hsm: false);
            Key key = await Client.CreateRsaKeyAsync(rsaKey);
            RegisterForCleanup(key.Name);

            Key keyReturned = await Client.GetKeyAsync(key.Name);
            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task CreateRsaWithSizeKey()
        {
            var rsaSizeKey = new RsaKeyCreateOptions(name: Recording.GenerateId(), hsm: false, keySize: 2048);
            Key key = await Client.CreateRsaKeyAsync(rsaSizeKey);
            RegisterForCleanup(key.Name);

            Key keyReturned = await Client.GetKeyAsync(rsaSizeKey.Name);
            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task UpdateKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            key.Properties.Expires = key.Properties.Created;
            Key updateResult = await Client.UpdateKeyPropertiesAsync(key.Properties, key.KeyMaterial.KeyOps);

            AssertKeysEqual(key, updateResult);
        }

        [Test]
        public async Task UpdateEnabled()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            key.Properties.Enabled = false;
            Key updateResult = await Client.UpdateKeyPropertiesAsync(key.Properties, key.KeyMaterial.KeyOps);
            Key keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeysEqual(keyReturned, updateResult);
        }

        [Test]
        public async Task GetKey()
        {
            string keyName = Recording.GenerateId();
            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

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
            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            Key keyReturned = await Client.GetKeyAsync(keyName, key.Properties.Version);

            AssertKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task DeleteKey()
        {
            string keyName = Recording.GenerateId();

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name, delete: false);

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

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name, delete: false);

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

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            DeletedKey deletedKey = await Client.DeleteKeyAsync(keyName);

            await WaitForDeletedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            Key recoverKeyResult = await Client.RecoverDeletedKeyAsync(keyName);

            await PollForKey(keyName);

            Key recoveredKey = await Client.GetKeyAsync(keyName);

            RegisterForCleanup(recoveredKey.Name);

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

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name);

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

            Key key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            byte[] backup = await Client.BackupKeyAsync(keyName);

            await Client.DeleteKeyAsync(keyName);
            await WaitForDeletedKey(keyName);

            await Client.PurgeDeletedKeyAsync(keyName);
            await WaitForPurgedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            Key restoredResult = await Client.RestoreKeyAsync(backup);
            RegisterForCleanup(restoredResult.Name);

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
                Key key = await Client.CreateKeyAsync(keyName + i, KeyType.Ec);
                createdKeys.Add(key);
                RegisterForCleanup(key.Name);
            }

            List<KeyProperties> allKeys = await Client.GetKeysAsync().ToEnumerableAsync();

            foreach (Key createdKey in createdKeys)
            {
                KeyProperties returnedKey = allKeys.Single(s => s.Name == createdKey.Name);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey);
            }
        }

        [Test]
        public async Task GetDeletedKeys()
        {
            string keyName = Recording.GenerateId();

            List<Key> createdKeys = new List<Key>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                Key Key = await Client.CreateKeyAsync(keyName + i, KeyType.Ec);
                createdKeys.Add(Key);
                await Client.DeleteKeyAsync(keyName + i);

                RegisterForCleanup(Key.Name, delete: false);
            }

            foreach (Key deletedKey in createdKeys)
            {
                await WaitForDeletedKey(deletedKey.Name);
            }

            List<DeletedKey> allKeys = await Client.GetDeletedKeysAsync().ToEnumerableAsync();

            foreach (Key createdKey in createdKeys)
            {
                Key returnedKey = allKeys.Single(s => s.Properties.Name == createdKey.Name);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey.Properties);
            }
        }

        [Test]
        public async Task GetKeysVersions()
        {
            string keyName = Recording.GenerateId();

            List<Key> createdKeys = new List<Key>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                Key Key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
                createdKeys.Add(Key);
            }
            RegisterForCleanup(createdKeys.First().Name);

            List<KeyProperties> allKeys = await Client.GetKeyVersionsAsync(keyName).ToEnumerableAsync();

            foreach (Key createdKey in createdKeys)
            {
                KeyProperties returnedKey = allKeys.Single(s => s.Version == createdKey.Version);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey);
            }
        }

        [Test]
        public async Task GetKeysVersionsNonExisting()
        {
            int count = 0;
            List<KeyProperties> allKeys = await Client.GetKeyVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();
            foreach (KeyProperties key in allKeys)
            {
                count++;
            }
            Assert.AreEqual(0, count);
        }
    }
}
