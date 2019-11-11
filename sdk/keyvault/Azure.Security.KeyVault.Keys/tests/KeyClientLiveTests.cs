// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task CreateKeyWithOptions()
        {
            var exp = new DateTimeOffset(new DateTime(637027248120000000, DateTimeKind.Utc));
            DateTimeOffset nbf = exp.AddDays(-30);

            var keyOptions = new CreateKeyOptions()
            {
                KeyOperations = { KeyOperation.Verify },
                Enabled = false,
                ExpiresOn = exp,
                NotBefore = nbf,
            };

            KeyVaultKey key = await Client.CreateKeyAsync(Recording.GenerateId(), KeyType.Ec, keyOptions);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(key.Name);

            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6551")]
        public async Task CreateEcHsmKey()
        {
            var echsmkey = new CreateEcKeyOptions(Recording.GenerateId(), hardwareProtected: true);
            KeyVaultKey keyHsm = await Client.CreateEcKeyAsync(echsmkey);
            RegisterForCleanup(keyHsm.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyHsm.Name);
            AssertKeyVaultKeysEqual(keyHsm, keyReturned);
        }

        [Test]
        public async Task CreateEcKey()
        {
            var eckey = new CreateEcKeyOptions(Recording.GenerateId(), hardwareProtected: false);
            KeyVaultKey keyNoHsm = await Client.CreateEcKeyAsync(eckey);
            RegisterForCleanup(keyNoHsm.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyNoHsm.Name);
            AssertKeyVaultKeysEqual(keyNoHsm, keyReturned);
        }

        [Test]
        public async Task CreateEcWithCurveKey([EnumValues]KeyCurveName curveName)
        {
            var ecCurveKey = new CreateEcKeyOptions(Recording.GenerateId(), hardwareProtected: false)
            {
                CurveName = curveName,
            };

            KeyVaultKey keyNoHsmCurve = await Client.CreateEcKeyAsync(ecCurveKey);

            RegisterForCleanup(keyNoHsmCurve.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(ecCurveKey.Name);
            AssertKeyVaultKeysEqual(keyNoHsmCurve, keyReturned);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6551")]
        public async Task CreateRsaHsmKey()
        {
            var rsaHsmkey = new CreateRsaKeyOptions(Recording.GenerateId(), hardwareProtected: true);
            KeyVaultKey keyHsm = await Client.CreateRsaKeyAsync(rsaHsmkey);
            RegisterForCleanup(keyHsm.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyHsm.Name);
            AssertKeyVaultKeysEqual(keyHsm, keyReturned);
        }

        [Test]
        public async Task CreateRsaKey()
        {
            var rsaKey = new CreateRsaKeyOptions(Recording.GenerateId(), hardwareProtected: false);
            KeyVaultKey key = await Client.CreateRsaKeyAsync(rsaKey);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(key.Name);
            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task CreateRsaWithSizeKey()
        {
            var rsaSizeKey = new CreateRsaKeyOptions(name: Recording.GenerateId(), hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey key = await Client.CreateRsaKeyAsync(rsaSizeKey);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(rsaSizeKey.Name);
            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task UpdateKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            key.Properties.ExpiresOn = key.Properties.CreatedOn;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(key.Properties, key.KeyOperations);

            AssertKeyVaultKeysEqual(key, updateResult);
        }

        [Test]
        public async Task UpdateEnabled()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            key.Properties.Enabled = false;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(key.Properties, key.KeyOperations);
            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(keyReturned, updateResult);
        }

        [Test]
        public async Task UpdateOps()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName)
            {
                KeyOperations =
                {
                    KeyOperation.Verify,
                },
            };

            KeyVaultKey key = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(key.Name);

            AssertAreEqual(new[] { KeyOperation.Verify }, key.KeyOperations);

            key.Properties.ExpiresOn = DateTimeOffset.Now.AddDays(1);

            key = await Client.UpdateKeyPropertiesAsync(key.Properties);
            AssertAreEqual(new[] { KeyOperation.Verify }, key.KeyOperations);

            key = await Client.UpdateKeyPropertiesAsync(key.Properties, new[] { KeyOperation.Sign, KeyOperation.Verify });
            AssertAreEqual(new[] { KeyOperation.Sign, KeyOperation.Verify }, key.KeyOperations);
        }

        [Test]
        public async Task UpdateTags()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName)
            {
                Tags =
                {
                    ["A"] = "1",
                    ["B"] = "2",
                },
            };

            KeyVaultKey key = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(key.Name);

            IDictionary<string, string> expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "2",
            };

            AssertAreEqual(expectedTags, key.Properties.Tags);

            key.Properties.Tags["B"] = "3";
            key.Properties.Tags["C"] = "4";

            key = await Client.UpdateKeyPropertiesAsync(key.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "3",
                ["C"] = "4",
            };

            AssertAreEqual(expectedTags, key.Properties.Tags);

            key.Properties.Tags.Clear();
            key.Properties.Tags["D"] = "5";

            key = await Client.UpdateKeyPropertiesAsync(key.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["D"] = "5",
            };

            AssertAreEqual(expectedTags, key.Properties.Tags);
        }

        [Test]
        public async Task GetKey()
        {
            string keyName = Recording.GenerateId();
            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(key, keyReturned);
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
            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName, key.Properties.Version);

            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [Test]
        public async Task DeleteKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name, delete: false);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);
            DeletedKey deletedKey = operation.Value;

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);
            AssertKeyVaultKeysEqual(key, deletedKey);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));
        }

        [Test]
        public void DeleteKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.StartDeleteKeyAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task GetDeletedKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name, delete: false);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);
            DeletedKey deletedKey = operation.Value;

            await WaitForDeletedKey(keyName);

            DeletedKey polledSecret = await Client.GetDeletedKeyAsync(keyName);

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);

            AssertKeyVaultKeysEqual(deletedKey, polledSecret);
            AssertKeyVaultKeysEqual(key, polledSecret);
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

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            DeleteKeyOperation deleteOperation = await Client.StartDeleteKeyAsync(keyName);
            DeletedKey deletedKey = deleteOperation.Value;

            await WaitForDeletedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            RecoverDeletedKeyOperation recoverOperation = await Client.StartRecoverDeletedKeyAsync(keyName);
            KeyVaultKey recoverKeyResult = recoverOperation.Value;

            await PollForKey(keyName);

            KeyVaultKey recoveredKey = await Client.GetKeyAsync(keyName);

            RegisterForCleanup(recoveredKey.Name);

            AssertKeyVaultKeysEqual(key, deletedKey);
            AssertKeyVaultKeysEqual(key, recoverKeyResult);
            AssertKeyVaultKeysEqual(key, recoveredKey);
        }

        [Test]
        public void RecoverDeletedKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.StartRecoverDeletedKeyAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task BackupKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

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
        public async Task RestoreKeyBackup()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            byte[] backup = await Client.BackupKeyAsync(keyName);

            await Client.StartDeleteKeyAsync(keyName);
            await WaitForDeletedKey(keyName);

            await Client.PurgeDeletedKeyAsync(keyName);
            await WaitForPurgedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            KeyVaultKey restoredResult = await Client.RestoreKeyBackupAsync(backup);
            RegisterForCleanup(restoredResult.Name);

            AssertKeyVaultKeysEqual(key, restoredResult);
        }

        [Test]
        public void RestoreKeyNonExisting()
        {
            byte[] backupMalformed = Encoding.ASCII.GetBytes("non-existing");
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RestoreKeyBackupAsync(backupMalformed));
        }

        [Test]
        public async Task GetPropertiesOfKeys()
        {
            string keyName = Recording.GenerateId();

            List<KeyVaultKey> createdKeys = new List<KeyVaultKey>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                KeyVaultKey key = await Client.CreateKeyAsync(keyName + i, KeyType.Ec);
                createdKeys.Add(key);
                RegisterForCleanup(key.Name);
            }

            List<KeyProperties> allKeys = await Client.GetPropertiesOfKeysAsync().ToEnumerableAsync();

            foreach (KeyVaultKey createdKey in createdKeys)
            {
                KeyProperties returnedKey = allKeys.Single(s => s.Name == createdKey.Name);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey);
            }
        }

        [Test]
        public async Task GetDeletedKeys()
        {
            string keyName = Recording.GenerateId();

            List<KeyVaultKey> createdKeys = new List<KeyVaultKey>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                KeyVaultKey Key = await Client.CreateKeyAsync(keyName + i, KeyType.Ec);
                createdKeys.Add(Key);
                await Client.StartDeleteKeyAsync(keyName + i);

                RegisterForCleanup(Key.Name, delete: false);
            }

            foreach (KeyVaultKey deletedKey in createdKeys)
            {
                await WaitForDeletedKey(deletedKey.Name);
            }

            List<DeletedKey> allKeys = await Client.GetDeletedKeysAsync().ToEnumerableAsync();

            foreach (KeyVaultKey createdKey in createdKeys)
            {
                KeyVaultKey returnedKey = allKeys.Single(s => s.Properties.Name == createdKey.Name);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey.Properties);
            }
        }

        [Test]
        public async Task GetPropertiesOfKeyVersions()
        {
            string keyName = Recording.GenerateId();

            List<KeyVaultKey> createdKeys = new List<KeyVaultKey>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                KeyVaultKey Key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
                createdKeys.Add(Key);
            }
            RegisterForCleanup(createdKeys.First().Name);

            List<KeyProperties> allKeys = await Client.GetPropertiesOfKeyVersionsAsync(keyName).ToEnumerableAsync();

            foreach (KeyVaultKey createdKey in createdKeys)
            {
                KeyProperties returnedKey = allKeys.Single(s => s.Version == createdKey.Properties.Version);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey);
            }
        }

        [Test]
        public async Task GetPropertiesOfKeyVersionsNonExisting()
        {
            int count = 0;
            List<KeyProperties> allKeys = await Client.GetPropertiesOfKeyVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();
            foreach (KeyProperties key in allKeys)
            {
                count++;
            }
            Assert.AreEqual(0, count);
        }
    }
}
