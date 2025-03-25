// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public partial class KeyClientLiveTests : KeysTestBase
    {
        private const int PagedKeyCount = 2;

        private readonly KeyClientOptions.ServiceVersion _serviceVersion;

        public KeyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : this(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected KeyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, serviceVersion, mode)
        {
            _serviceVersion = serviceVersion;

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/11634
            CompareBodies = false;
        }

        [RecordedTest]
        public async Task CreateKey()
        {
            string keyName = Recording.GenerateId();
            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [RecordedTest]
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

        [RecordedTest]
        [PremiumOnly]
        public async Task CreateEcHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmkey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);
            if (!IsManagedHSM && _serviceVersion >= KeyClientOptions.ServiceVersion.V7_5)
            {
                Assert.That(keyReturned.Properties.HsmPlatform, Is.Not.Null.And.Not.Empty);
            }

            AssertKeyVaultKeysEqual(ecHsmkey, keyReturned);

            using MemoryStream ms = new();
            await JsonSerializer.SerializeAsync(ms, keyReturned.Key);
            string json = Encoding.UTF8.GetString(ms.ToArray());

            StringAssert.Contains($@"""kid"":""{keyReturned.Id}""", json);
            StringAssert.Contains(@"""kty"":""EC-HSM""", json);
            StringAssert.Contains(@"""crv"":""P-256""", json);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task CreateEcKey()
        {
            string keyName = Recording.GenerateId();

            var ecKey = new CreateEcKeyOptions(keyName, hardwareProtected: false);
            KeyVaultKey keyNoHsm = await Client.CreateEcKeyAsync(ecKey);
            RegisterForCleanup(keyNoHsm.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyNoHsm.Name);
            AssertKeyVaultKeysEqual(keyNoHsm, keyReturned);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task CreateEcWithCurveKey([EnumValues] KeyCurveName curveName)
        {
            var ecCurveKey = new CreateEcKeyOptions(Recording.GenerateId(), hardwareProtected: false)
            {
                CurveName = curveName,
            };

            KeyVaultKey keyNoHsmCurve = null;
            try
            {
                keyNoHsmCurve = await Client.CreateEcKeyAsync(ecCurveKey);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == "KeyCurveNotSupported")
            {
                Assert.Ignore(ex.Message);
            }

            RegisterForCleanup(keyNoHsmCurve.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(ecCurveKey.Name);
            AssertKeyVaultKeysEqual(keyNoHsmCurve, keyReturned);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task CreateRsaHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmkey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);
            if (!IsManagedHSM && _serviceVersion >= KeyClientOptions.ServiceVersion.V7_5)
            {
                Assert.That(keyReturned.Properties.HsmPlatform, Is.Not.Null.And.Not.Empty);
            }

            AssertKeyVaultKeysEqual(rsaHsmkey, keyReturned);

            using MemoryStream ms = new();
            await JsonSerializer.SerializeAsync(ms, keyReturned.Key);
            string json = Encoding.UTF8.GetString(ms.ToArray());

            StringAssert.Contains($@"""kid"":""{keyReturned.Id}""", json);
            StringAssert.Contains(@"""kty"":""RSA-HSM""", json);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task CreateRsaKey()
        {
            var rsaKey = new CreateRsaKeyOptions(Recording.GenerateId(), hardwareProtected: false);
            KeyVaultKey key = await Client.CreateRsaKeyAsync(rsaKey);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(key.Name);
            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [RecordedTest]
        [PremiumOnly]
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

        [RecordedTest]
        public async Task UpdateKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            key.Properties.ExpiresOn = key.Properties.CreatedOn;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(key.Properties, key.KeyOperations);

            AssertKeyVaultKeysEqual(key, updateResult);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateEcHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            ecHsmKey.Properties.ExpiresOn = ecHsmKey.Properties.CreatedOn;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(ecHsmKey.Properties, ecHsmKey.KeyOperations);

            AssertKeyVaultKeysEqual(ecHsmKey, updateResult);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateRsaHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            rsaHsmKey.Properties.ExpiresOn = rsaHsmKey.Properties.CreatedOn;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(rsaHsmKey.Properties, rsaHsmKey.KeyOperations);

            AssertKeyVaultKeysEqual(rsaHsmKey, updateResult);
        }

        [RecordedTest]
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

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateEcHsmKeyEnabled()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            ecHsmKey.Properties.Enabled = false;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(ecHsmKey.Properties, ecHsmKey.KeyOperations);
            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(keyReturned, updateResult);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateRsaHsmKeyEnabled()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            rsaHsmKey.Properties.Enabled = false;
            KeyVaultKey updateResult = await Client.UpdateKeyPropertiesAsync(rsaHsmKey.Properties, rsaHsmKey.KeyOperations);
            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(keyReturned, updateResult);
        }

        [RecordedTest]
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

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateEcHsmKeyOps()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true)
            {
                KeyOperations =
                {
                    KeyOperation.Verify,
                },
            };

            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            AssertAreEqual(new[] { KeyOperation.Verify }, ecHsmKey.KeyOperations);

            ecHsmKey.Properties.ExpiresOn = DateTimeOffset.Now.AddDays(1);

            ecHsmKey = await Client.UpdateKeyPropertiesAsync(ecHsmKey.Properties);
            AssertAreEqual(new[] { KeyOperation.Verify }, ecHsmKey.KeyOperations);

            ecHsmKey = await Client.UpdateKeyPropertiesAsync(ecHsmKey.Properties, new[] { KeyOperation.Sign, KeyOperation.Verify });
            AssertAreEqual(new[] { KeyOperation.Sign, KeyOperation.Verify }, ecHsmKey.KeyOperations);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateRsaHsmKeyOps()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true)
            {
                KeyOperations =
                {
                    KeyOperation.Verify,
                },
            };

            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            AssertAreEqual(new[] { KeyOperation.Verify }, rsaHsmKey.KeyOperations);

            rsaHsmKey.Properties.ExpiresOn = DateTimeOffset.Now.AddDays(1);

            rsaHsmKey = await Client.UpdateKeyPropertiesAsync(rsaHsmKey.Properties);
            AssertAreEqual(new[] { KeyOperation.Verify }, rsaHsmKey.KeyOperations);

            rsaHsmKey = await Client.UpdateKeyPropertiesAsync(rsaHsmKey.Properties, new[] { KeyOperation.Sign, KeyOperation.Verify });
            AssertAreEqual(new[] { KeyOperation.Sign, KeyOperation.Verify }, rsaHsmKey.KeyOperations);
        }

        [RecordedTest]
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

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateEcHsmKeyTags()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true)
            {
                Tags =
                {
                    ["A"] = "1",
                    ["B"] = "2",
                },
            };

            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            IDictionary<string, string> expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "2",
            };

            AssertAreEqual(expectedTags, ecHsmKey.Properties.Tags);

            ecHsmKey.Properties.Tags["B"] = "3";
            ecHsmKey.Properties.Tags["C"] = "4";

            ecHsmKey = await Client.UpdateKeyPropertiesAsync(ecHsmKey.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "3",
                ["C"] = "4",
            };

            AssertAreEqual(expectedTags, ecHsmKey.Properties.Tags);

            ecHsmKey.Properties.Tags.Clear();
            ecHsmKey.Properties.Tags["D"] = "5";

            ecHsmKey = await Client.UpdateKeyPropertiesAsync(ecHsmKey.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["D"] = "5",
            };

            AssertAreEqual(expectedTags, ecHsmKey.Properties.Tags);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task UpdateRsaHsmKeyTags()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true)
            {
                Tags =
                {
                    ["A"] = "1",
                    ["B"] = "2",
                },
            };

            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            IDictionary<string, string> expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "2",
            };

            AssertAreEqual(expectedTags, rsaHsmKey.Properties.Tags);

            rsaHsmKey.Properties.Tags["B"] = "3";
            rsaHsmKey.Properties.Tags["C"] = "4";

            rsaHsmKey = await Client.UpdateKeyPropertiesAsync(rsaHsmKey.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "3",
                ["C"] = "4",
            };

            AssertAreEqual(expectedTags, rsaHsmKey.Properties.Tags);

            rsaHsmKey.Properties.Tags.Clear();
            rsaHsmKey.Properties.Tags["D"] = "5";

            rsaHsmKey = await Client.UpdateKeyPropertiesAsync(rsaHsmKey.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["D"] = "5",
            };

            AssertAreEqual(expectedTags, rsaHsmKey.Properties.Tags);
        }

        [RecordedTest]
        public async Task GetKey()
        {
            string keyName = Recording.GenerateId();
            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task GetEcHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(ecHsmKey, keyReturned);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task GetRsaHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(rsaHsmKey, keyReturned);
        }

        [RecordedTest]
        public void GetKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        public async Task GetKeyWithVersion()
        {
            string keyName = Recording.GenerateId();
            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);
            RegisterForCleanup(key.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName, key.Properties.Version);

            AssertKeyVaultKeysEqual(key, keyReturned);
        }

        [RecordedTest]
        public async Task DeleteKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);
            DeletedKey deletedKey = operation.Value;

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);
            AssertKeyVaultKeysEqual(key, deletedKey);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task DeleteEcHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);

            DeletedKey deletedKey = await operation.WaitForCompletionAsync();

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);
            AssertKeyVaultKeysEqual(ecHsmKey, deletedKey);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task DeleteRsaHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);

            DeletedKey deletedKey = await operation.WaitForCompletionAsync();

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);
            AssertKeyVaultKeysEqual(rsaHsmKey, deletedKey);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));
        }

        [RecordedTest]
        public void DeleteKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.StartDeleteKeyAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        public async Task GetDeletedKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name);

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

        [RecordedTest]
        [PremiumOnly]
        public async Task GetDeletedEcHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);
            RegisterForCleanup(keyName);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);

            DeletedKey deletedKey = await operation.WaitForCompletionAsync();

            await WaitForDeletedKey(keyName);

            DeletedKey polledSecret = await Client.GetDeletedKeyAsync(keyName);

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);

            AssertKeyVaultKeysEqual(deletedKey, polledSecret);
            AssertKeyVaultKeysEqual(ecHsmKey, polledSecret);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task GetDeletedRsaHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(keyName);

            DeleteKeyOperation operation = await Client.StartDeleteKeyAsync(keyName);

            DeletedKey deletedKey = await operation.WaitForCompletionAsync();

            await WaitForDeletedKey(keyName);

            DeletedKey polledSecret = await Client.GetDeletedKeyAsync(keyName);

            Assert.NotNull(deletedKey.DeletedOn);
            Assert.NotNull(deletedKey.RecoveryId);
            Assert.NotNull(deletedKey.ScheduledPurgeDate);

            AssertKeyVaultKeysEqual(deletedKey, polledSecret);
            AssertKeyVaultKeysEqual(rsaHsmKey, polledSecret);
        }

        [RecordedTest]
        public void GetDeletedKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedKeyAsync(Recording.GenerateId()));
        }

        [RecordedTest]
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

            await WaitForKey(keyName);

            KeyVaultKey recoveredKey = await Client.GetKeyAsync(keyName);

            RegisterForCleanup(recoveredKey.Name);

            AssertKeyVaultKeysEqual(key, deletedKey);
            AssertKeyVaultKeysEqual(key, recoverKeyResult);
            AssertKeyVaultKeysEqual(key, recoveredKey);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task RecoverDeletedEcHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateEcKeyOptions options = new CreateEcKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmKey = await Client.CreateEcKeyAsync(options);

            DeleteKeyOperation deleteOperation = await Client.StartDeleteKeyAsync(keyName);

            DeletedKey deletedKey = await deleteOperation.WaitForCompletionAsync();

            await WaitForDeletedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            RecoverDeletedKeyOperation recoverOperation = await Client.StartRecoverDeletedKeyAsync(keyName);

            KeyVaultKey recoverKeyResult = await recoverOperation.WaitForCompletionAsync();

            await WaitForKey(keyName);

            KeyVaultKey recoveredKey = await Client.GetKeyAsync(keyName);

            RegisterForCleanup(recoveredKey.Name);

            AssertKeyVaultKeysEqual(ecHsmKey, deletedKey);
            AssertKeyVaultKeysEqual(ecHsmKey, recoverKeyResult);
            AssertKeyVaultKeysEqual(ecHsmKey, recoveredKey);
        }

        [RecordedTest]
        [PremiumOnly]
        public async Task RecoverDeletedRsaHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey rsaHsmKey = await Client.CreateRsaKeyAsync(options);

            DeleteKeyOperation deleteOperation = await Client.StartDeleteKeyAsync(keyName);

            DeletedKey deletedKey = await deleteOperation.WaitForCompletionAsync();

            await WaitForDeletedKey(keyName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetKeyAsync(keyName));

            RecoverDeletedKeyOperation recoverOperation = await Client.StartRecoverDeletedKeyAsync(keyName);

            KeyVaultKey recoverKeyResult = await recoverOperation.WaitForCompletionAsync();

            await WaitForKey(keyName);

            KeyVaultKey recoveredKey = await Client.GetKeyAsync(keyName);

            RegisterForCleanup(recoveredKey.Name);

            AssertKeyVaultKeysEqual(rsaHsmKey, deletedKey);
            AssertKeyVaultKeysEqual(rsaHsmKey, recoverKeyResult);
            AssertKeyVaultKeysEqual(rsaHsmKey, recoveredKey);
        }

        [RecordedTest]
        public void RecoverDeletedKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.StartRecoverDeletedKeyAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        public async Task BackupKey()
        {
            string keyName = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateKeyAsync(keyName, KeyType.Ec);

            RegisterForCleanup(key.Name);

            byte[] backup = await Client.BackupKeyAsync(keyName);

            Assert.NotNull(backup);
        }

        [RecordedTest]
        public void BackupKeyNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.BackupKeyAsync(Recording.GenerateId()));
        }

        [RecordedTest]
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

        [RecordedTest]
        public void RestoreKeyNonExisting()
        {
            byte[] backupMalformed = Encoding.ASCII.GetBytes("non-existing");
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RestoreKeyBackupAsync(backupMalformed));
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task GetDeletedKeys()
        {
            string keyName = Recording.GenerateId();

            List<KeyVaultKey> createdKeys = new List<KeyVaultKey>();
            for (int i = 0; i < PagedKeyCount; i++)
            {
                KeyVaultKey Key = await Client.CreateKeyAsync(keyName + i, KeyType.Ec);
                createdKeys.Add(Key);
                await Client.StartDeleteKeyAsync(keyName + i);

                RegisterForCleanup(Key.Name);
            }

            List<Task> deletingKeys = new List<Task>();
            foreach (KeyVaultKey deletedKey in createdKeys)
            {
                // WaitForDeletedKey disables recording, so we can wait concurrently.
                deletingKeys.Add(WaitForDeletedKey(deletedKey.Name));
            }

            await Task.WhenAll(deletingKeys);

            List<DeletedKey> allKeys = await Client.GetDeletedKeysAsync().ToEnumerableAsync();
            foreach (KeyVaultKey createdKey in createdKeys)
            {
                KeyVaultKey returnedKey = allKeys.Single(s => s.Properties.Name == createdKey.Name);
                AssertKeyPropertiesEqual(createdKey.Properties, returnedKey.Properties);
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task GetPropertiesOfKeyVersionsNonExisting()
        {
            List<KeyProperties> allKeys = await Client.GetPropertiesOfKeyVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();
            Assert.AreEqual(0, allKeys.Count);
        }
    }
}
