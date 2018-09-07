// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using KeyVault.TestFramework;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Serialization;
using Xunit;

namespace Microsoft.Azure.KeyVault.Tests
{
    public class Operations : IClassFixture<KeyVaultTestFixture>
    {
        private KeyVaultTestFixture fixture;

        public Operations(KeyVaultTestFixture fixture)
        {
            this.fixture = fixture;
            _standardVaultOnly = fixture.standardVaultOnly;
            _softDeleteEnabled = fixture.softDeleteEnabled;
            _vaultAddress = fixture.vaultAddress;
            _keyName = fixture.keyName;
            _keyVersion = fixture.keyVersion;
            _keyIdentifier = fixture.keyIdentifier;
            _storageResourceUrl1 = fixture.StorageResourceUrl1;
            _storageResourceUrl2 = fixture.StorageResourceUrl2;
        }

        private bool _standardVaultOnly = false;
        private bool _softDeleteEnabled = false;
        private string _vaultAddress = "";
        private string _keyName = "";
        private string _keyVersion = "";
        private KeyIdentifier _keyIdentifier;
        private string _storageResourceUrl1;
        private string _storageResourceUrl2;

        private void Initialize()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["VaultAddress"] = _vaultAddress;
                HttpMockServer.Variables["KeyName"] = _keyName;
                HttpMockServer.Variables["KeyVersion"] = _keyVersion;
                HttpMockServer.Variables["SoftDeleteEnabled"] = _softDeleteEnabled.ToString();
                HttpMockServer.Variables["StorageResourceUrl1"] = _storageResourceUrl1;
                HttpMockServer.Variables["StorageResourceUrl2"] = _storageResourceUrl2;
            }
            else
            {
                _vaultAddress = HttpMockServer.Variables["VaultAddress"];
                _keyName = HttpMockServer.Variables["KeyName"];
                _keyVersion = HttpMockServer.Variables["KeyVersion"];

                string softDeleteSetting = String.Empty;
                if (HttpMockServer.Variables.TryGetValue("SoftDeleteEnabled", out softDeleteSetting))
                {
                    Boolean.TryParse(softDeleteSetting, out _softDeleteEnabled);
                }

                _storageResourceUrl1 = HttpMockServer.Variables.ContainsKey("StorageResourceUrl1")
                    ? HttpMockServer.Variables["StorageResourceUrl1"]
                    : string.Empty;

                _storageResourceUrl2 = HttpMockServer.Variables.ContainsKey("StorageResourceUrl2")
                    ? HttpMockServer.Variables["StorageResourceUrl2"]
                    : string.Empty;
            }
        }

        private KeyVaultClient GetKeyVaultClient()
        {
            Initialize();
            _keyIdentifier = new KeyIdentifier(_vaultAddress, _keyName, _keyVersion);
            return fixture.CreateKeyVaultClient();
        }

        private KeyVaultClient GetKeyVaultUserClient()
        {
            Initialize();
            _keyIdentifier = new KeyIdentifier(_vaultAddress, _keyName, _keyVersion);
            return fixture.CreateKeyVaultUserClient();
        }

        [Fact]
        public void Constructor()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                Initialize();
                var httpClient = HttpClientFactory.Create(fixture.GetHandlers());

                var kvClient = new KeyVaultClient(new TestKeyVaultCredential(fixture.GetAccessToken), httpClient);
                Assert.Equal(httpClient, kvClient.HttpClient);
                kvClient.GetKeysAsync(_vaultAddress).GetAwaiter().GetResult();
            }
        }

        #region Key Operations
        [Fact]
        public void EncryptDecryptRsaOaepTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP);
            }
        }

        [Fact]
        public void EncryptDecryptRsa15Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSA15);
            }
        }

        [Fact]
        public void EncryptDecryptRsaOaep256Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP256);
            }
        }

        [Fact]
        public void EncryptDecryptWithOlderKeyVersion()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var algorithm = JsonWebKeyEncryptionAlgorithm.RSA15;

                // Create a newer version of the current software key
                var newVersionKey =
                    client.CreateKeyAsync(_vaultAddress, _keyName, JsonWebKeyType.Rsa,
                        keyOps: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                // Use the older version of the software key to do encryption and decryption operation
                EncryptDecrypt(client, _keyIdentifier, algorithm);
            }
        }

        [Fact]
        public void EncryptDecryptWithDifferentKeyVersions()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var algorithm = JsonWebKeyEncryptionAlgorithm.RSA15;

                // Create a newer version of the current software key
                var newVersionKey =
                    client.CreateKeyAsync(_vaultAddress, _keyName, JsonWebKeyType.Rsa,
                        keyOps: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                var plainText = RandomBytes(10);
                var encryptResult = client.EncryptAsync(newVersionKey.Key.Kid, algorithm, plainText).GetAwaiter().GetResult();

                Assert.Throws<KeyVaultErrorException>(() =>
                    client.DecryptAsync(_keyIdentifier.Identifier, algorithm, encryptResult.Result).GetAwaiter().GetResult());
            }
        }

        [Fact]
        public void SignVerifyRS256Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA256.Create(), 32);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS256, digest);
            }
        }

        [Fact]
        public void SignVerifyRS384Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA384.Create(), 64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS384, digest);
            }
        }

        [Fact]
        public void SignVerifyRS512Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA512.Create(), 64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS512, digest);
            }
        }

        [Fact]
        public void SignVerifyPS256Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA256.Create(), 32);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.PS256, digest);
            }
        }

        [Fact]
        public void SignVerifyPS384Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA384.Create(), 64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.PS384, digest);
            }
        }

        [Fact]
        public void SignVerifyPS512Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA512.Create(), 64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.PS512, digest);
            }
        }

        [Fact]
        public void WrapUnwrapRsaOaepTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP, symmetricKeyBytes);
            }
        }

        [Fact]
        public void WrapUnwrapRsa15Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSA15, symmetricKeyBytes);
            }
        }

        [Fact]
        public void WrapUnwrapRsaOaep256Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP256, symmetricKeyBytes);
            }
        }

        [Fact]
        public void EcKeyCreateSignVerifyP256()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var curve = JsonWebKeyCurveName.P256;
                var digestSize = 256;
                var algorithm = JsonWebKeySignatureAlgorithm.ES256;

                TestEcKeyCreateSignVerify(curve, digestSize, algorithm);
            }
        }

        [Fact]
        public void EcKeyCreateSignVerifyP384()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var curve = JsonWebKeyCurveName.P384;
                var digestSize = 384;
                var algorithm = JsonWebKeySignatureAlgorithm.ES384;

                TestEcKeyCreateSignVerify(curve, digestSize, algorithm);
            }
        }

        [Fact]
        public void EcKeyCreateSignVerifyP521()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var curve = JsonWebKeyCurveName.P521;
                var digestSize = 512;
                var algorithm = JsonWebKeySignatureAlgorithm.ES512;

                TestEcKeyCreateSignVerify(curve, digestSize, algorithm);
            }
        }

        [Fact]
        public void EcKeyCreateSignVerifySECP256K1()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var curve = JsonWebKeyCurveName.P256K;
                var digestSize = 256;
                var algorithm = JsonWebKeySignatureAlgorithm.ES256K;

                TestEcKeyCreateSignVerify(curve, digestSize, algorithm);
            }
        }

        private void TestEcKeyCreateSignVerify(string curve, int digestSize, string algorithm)
        {
            var client = GetKeyVaultClient();

            var keyParameters = new NewKeyParameters();

            keyParameters.Kty = JsonWebKeyType.EllipticCurve;
            keyParameters.CurveName = curve;
            keyParameters.KeyOps = new[] { JsonWebKeyOperation.Sign, JsonWebKeyOperation.Verify };

            // Create an EC software key.
            var keyBundle = client.CreateKeyAsync(_vaultAddress, _keyName, keyParameters).Result;

            TestSignVerify(client, keyBundle, digestSize, algorithm);
        }

        private static void TestSignVerify(KeyVaultClient client, KeyBundle keyBundle, int digestSize, string algorithm)
        {
            var key = keyBundle.Key;
            var kid = key.Kid;
            var ecdsa = key.ToECDsa(false);

            // Sign.
            var digest = RandomBytes(digestSize / 8);
            Assert.True(digest.Length * 8 == digestSize);

            var signatureResult = client.SignAsync(kid, algorithm, digest).Result;
            var signature = signatureResult.Result;
            Assert.Equal(kid, signatureResult.Kid);

            // Verify - positive test.
            var verified = client.VerifyAsync(kid, algorithm, digest, signature).Result;
            Assert.True(verified);

#if FullNetFx
            verified = ecdsa.VerifyData(digest, signature);
            Assert.True(verified);
#endif

            // Verify - negative test.
            signature[signature.Length - 1] ^= 1;
            verified = client.VerifyAsync(kid, algorithm, digest, signature).Result;
            Assert.False(verified);

#if FullNetFx
            verified = ecdsa.VerifyData(digest, signature);
            Assert.False(verified);
#endif
        }

        public void CreateGetDeleteKeyTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();
                bool recoveryLevelIsConsistent = true;

                var attributes = new KeyAttributes();
                var tags = new Dictionary<string, string>() { { "purpose", "unit test" }, { "test name ", "CreateGetDeleteKeyTest" } };
                var createdKey = client.CreateKeyAsync(_vaultAddress, "CreateSoftKeyTest", JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attributes, tags).GetAwaiter().GetResult();

                try
                {
                    VerifyKeyAttributesAreEqual(attributes, createdKey.Attributes);
                    Assert.Equal(JsonWebKeyType.Rsa, createdKey.Key.Kty);
                    Assert.Equal("CreateSoftKeyTest", createdKey.KeyIdentifier.Name);
                    var retrievedKey = client.GetKeyAsync(createdKey.Key.Kid).GetAwaiter().GetResult();
                    VerifyKeyAttributesAreEqual(attributes, retrievedKey.Attributes);
                    VerifyWebKeysAreEqual(createdKey.Key, retrievedKey.Key);
                    VerifyTagsAreEqual(tags, retrievedKey.Tags);

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(retrievedKey.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, "CreateSoftKeyTest").GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(deletedKey.Attributes, createdKey.Attributes);
                    VerifyWebKeysAreEqual(deletedKey.Key, createdKey.Key);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedKey.Attributes, _softDeleteEnabled);

                    //verify the key is deleted
                    try
                    {
                        client.GetKeyAsync(_vaultAddress, "CreateSoftKeyTest").GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, "CreateSoftKeyTest");

                        client.PurgeDeletedKeyAsync(_vaultAddress, "CreateSoftKeyTest").GetAwaiter().GetResult();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void CreateHsmKeyTest()
        {
            if (_standardVaultOnly) return;

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                bool recoveryLevelIsConsistent = true;
                var attributes = new KeyAttributes();
                var createdKey = client.CreateKeyAsync(_vaultAddress, "CreateHsmKeyTest", JsonWebKeyType.RsaHsm, 2048,
                    JsonWebKeyOperation.AllOperations, attributes).GetAwaiter().GetResult();

                try
                {
                    //Trace.WriteLine("Verify generated key is as expected");
                    VerifyKeyAttributesAreEqual(attributes, createdKey.Attributes);
                    Assert.Equal(JsonWebKeyType.RsaHsm, createdKey.Key.Kty);
                    Assert.False(String.IsNullOrWhiteSpace(createdKey.Attributes.RecoveryLevel));

                    //Trace.WriteLine("Get the key");
                    var retrievedKey = client.GetKeyAsync(createdKey.Key.Kid).GetAwaiter().GetResult();
                    VerifyKeyAttributesAreEqual(attributes, retrievedKey.Attributes);
                    VerifyWebKeysAreEqual(createdKey.Key, retrievedKey.Key);

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdKey.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    //Trace.WriteLine("Delete the key");
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, "CreateHsmKeyTest").GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(deletedKey.Attributes, createdKey.Attributes);
                    VerifyWebKeysAreEqual(deletedKey.Key, createdKey.Key);
                    Assert.False(String.IsNullOrWhiteSpace(deletedKey.Attributes.RecoveryLevel));

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedKey.Attributes, _softDeleteEnabled);

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, "CreateHsmKeyTest");

                        client.PurgeDeletedKeyAsync(_vaultAddress, "CreateHsmKeyTest").Wait();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void ImportSoftKeyTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();
                // Generates a new RSA key.
                var rsa = RSA.Create(); rsa.KeySize = 2048;
                var key = CreateJsonWebKey(rsa.ExportParameters(true));
                var keyBundle = new KeyBundle()
                {
                    Attributes = null,
                    Key = key,
                    Tags = new Dictionary<string, string>() { { "purpose", "unit test" } }
                };

                var importedKey =
                    client.ImportKeyAsync(_vaultAddress, "ImportSoftKeyTest", keyBundle).GetAwaiter().GetResult();
                Assert.False(String.IsNullOrWhiteSpace(importedKey.Attributes.RecoveryLevel));

                try
                {
                    Assert.Equal(keyBundle.Key.Kty, importedKey.Key.Kty);
                    Assert.NotNull(importedKey.Attributes);
                    Assert.Equal("unit test", importedKey.Tags["purpose"]);

                    var retrievedKey = client.GetKeyAsync(importedKey.Key.Kid).GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(importedKey.Attributes, retrievedKey.Attributes);
                    VerifyWebKeysAreEqual(importedKey.Key, retrievedKey.Key);
                    Assert.False(String.IsNullOrWhiteSpace(retrievedKey.Attributes.RecoveryLevel));
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, "ImportSoftKeyTest").Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, "ImportSoftKeyTest");

                        client.PurgeDeletedKeyAsync(_vaultAddress, "ImportSoftKeyTest").GetAwaiter().GetResult();
                    }
                }
            }
        }

        [Fact]
        public void UpdateKeyAttributesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();
                var keyName = "UpdateKeyAttributesTest";
                try
                {
                    // Create a key
                    var attributes = new KeyAttributes();
                    var operations = new string[] { JsonWebKeyOperation.Decrypt, JsonWebKeyOperation.Encrypt };
                    var createdKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                            JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                    // Update the current version
                    attributes.Enabled = true;
                    //use a constant to avoid time difference failures
                    attributes.NotBefore = UnixTimeJsonConverter.EpochDate.AddSeconds(315561600);
                    attributes.Expires = UnixTimeJsonConverter.EpochDate.AddSeconds(347184000);

                    var updatedKey =
                        client.UpdateKeyAsync(_vaultAddress, keyName, operations, attributes)
                            .GetAwaiter()
                            .GetResult();

                    VerifyKeyAttributesAreEqual(updatedKey.Attributes, attributes);
                    VerifyKeyOperationsAreEqual(updatedKey.Key.KeyOps, operations);
                    updatedKey.Key.KeyOps = JsonWebKeyOperation.AllOperations;
                    VerifyWebKeysAreEqual(updatedKey.Key, createdKey.Key);
                    Assert.False(String.IsNullOrWhiteSpace(updatedKey.Attributes.RecoveryLevel));

                    // Create a new version of the key
                    var newkeyVersion = client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                        JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                    // Update the original version
                    attributes.Enabled = false;
                    attributes.NotBefore = UnixTimeJsonConverter.EpochDate.AddSeconds(631180800);
                    attributes.Expires = UnixTimeJsonConverter.EpochDate.AddSeconds(662716800);

                    updatedKey =
                        client.UpdateKeyAsync(createdKey.Key.Kid, operations, attributes).GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(updatedKey.Attributes, attributes);
                    VerifyKeyOperationsAreEqual(updatedKey.Key.KeyOps, operations);
                    updatedKey.Key.KeyOps = JsonWebKeyOperation.AllOperations;
                    VerifyWebKeysAreEqual(updatedKey.Key, createdKey.Key);
                    Assert.False(String.IsNullOrWhiteSpace(updatedKey.Attributes.RecoveryLevel));
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                        client.PurgeDeletedKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    }
                }
            }
        }

        [Fact]
        public void UpdateKeyAttributesWithNoChangeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var keyName = "UpdateKeyAttributesWithNoChangeTest";
                try
                {
                    var enabledState = false;
                    var attributes = new KeyAttributes()
                    {
                        Enabled = enabledState,
                        Expires = new DateTime(2030, 1, 1).ToUniversalTime(),
                        NotBefore = new DateTime(2010, 1, 1).ToUniversalTime()
                    };
                    var createdKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                            JsonWebKeyOperation.AllOperations, attributes).GetAwaiter().GetResult();

                    var attributes2 = new KeyAttributes()
                    {
                        Enabled = null, //when attributes are null there should not be any change
                        NotBefore = null,
                        Expires = null
                    };

                    // You cannot update a specific version of a key, only the current version
                    var updatedKey =
                        client.UpdateKeyAsync(_vaultAddress, keyName, null, attributes).GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(updatedKey.Attributes, createdKey.Attributes);
                    VerifyKeyOperationsAreEqual(updatedKey.Key.KeyOps, createdKey.Key.KeyOps);
                    VerifyWebKeysAreEqual(updatedKey.Key, createdKey.Key);
                    Assert.False(String.IsNullOrWhiteSpace(updatedKey.Attributes.RecoveryLevel));
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                        client.PurgeDeletedKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    }
                }
            }
        }

        [Fact]
        public void KeyBackupRestoreTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var keyName = "KeyBackupRestoreTest";

                var attribute = new KeyAttributes()
                {
                    Enabled = false,
                    Expires = new DateTime(2030, 1, 1).ToUniversalTime(),
                    NotBefore = new DateTime(2010, 1, 1).ToUniversalTime()
                };
                bool recoveryLevelIsConsistent = true;

                var createdKey = client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attribute).GetAwaiter().GetResult();

                try
                {
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdKey.Attributes, _softDeleteEnabled);

                    // Backup the key
                    var backupResponse = client.BackupKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();

                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                        client.PurgeDeletedKeyAsync(_vaultAddress, keyName).Wait();
                    }

                    // Restore the backedup key
                    var restoredDeletedKey =
                        this.fixture.retryExecutor.ExecuteAction(() => client.RestoreKeyAsync(_vaultAddress, backupResponse.Value).GetAwaiter().GetResult());

                    VerifyKeyAttributesAreEqual(restoredDeletedKey.Attributes, createdKey.Attributes);
                    Assert.Equal(restoredDeletedKey.Key.Kty, createdKey.Key.Kty);
                    Assert.Equal(createdKey.Key.Kid, restoredDeletedKey.Key.Kid);
                    Assert.False(String.IsNullOrWhiteSpace(restoredDeletedKey.Attributes.RecoveryLevel));
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(restoredDeletedKey.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnKey(client, _vaultAddress, keyName);

                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                        client.PurgeDeletedKeyAsync(_vaultAddress, keyName).Wait();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void SecretBackupRestoreTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var name = "SecretBackupRestoreTest";
                bool recoveryLevelIsConsistent = true;
                var attributes = new SecretAttributes()
                {
                    Enabled = true,
                    Expires = new DateTime(2030, 1, 1).ToUniversalTime(),
                    NotBefore = new DateTime(2010, 1, 1).ToUniversalTime()
                };

                var created = client.SetSecretAsync(_vaultAddress, name, "if found please return to secretbackuprestoretest", tags: null, contentType: "text", secretAttributes: attributes)
                    .GetAwaiter()
                    .GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(created.Attributes, _softDeleteEnabled);

                try
                {
                    // Backup the secret 
                    var backupResponse = client.BackupSecretAsync(_vaultAddress, name).GetAwaiter().GetResult();

                    client.DeleteSecretAsync(_vaultAddress, name).Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedSecret(client, _vaultAddress, name);

                        client.PurgeDeletedSecretAsync(_vaultAddress, name).Wait();
                    }

                    // Restore the backedup secret
                    var restoredDeletedSecret =
                        this.fixture.retryExecutor.ExecuteAction(() => client.RestoreSecretAsync(_vaultAddress, backupResponse.Value).GetAwaiter().GetResult());

                    VerifySecretAttributesAreEqual(restoredDeletedSecret.Attributes, created.Attributes);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(restoredDeletedSecret.Attributes, _softDeleteEnabled);
                    Assert.Equal(created.Id, restoredDeletedSecret.Id);
                }
                finally
                {
                    this.fixture.WaitOnSecret(client, _vaultAddress, name);

                    client.DeleteSecretAsync(_vaultAddress, name).Wait();

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedSecret(client, _vaultAddress, name);

                        client.PurgeDeletedSecretAsync(_vaultAddress, name).Wait();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void ListKeysTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                int numKeys = 3;
                int maxResults = 1;
                bool recoveryLevelIsConsistent = true;

                var addedObjects = new HashSet<string>();

                //Create the keys
                for (int i = 0; i < numKeys; i++)
                {
                    string keyName = "listkeytest" + i.ToString();

                    var addedKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa).GetAwaiter().GetResult();
                    addedObjects.Add(GetKidWithoutVersion(addedKey.Key.Kid));

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(addedKey.Attributes, _softDeleteEnabled);
                }

                //List the keys
                var listResponse = client.GetKeysAsync(_vaultAddress, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (KeyItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Kid))
                    {
                        Assert.StartsWith("listkeytest", m.Identifier.Name);
                        addedObjects.Remove(m.Kid);
                    }

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetKeysNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (KeyItem m in listNextResponse)
                    {
                        if (addedObjects.Contains(m.Kid))
                        {
                            Assert.StartsWith("listkeytest", m.Identifier.Name);
                            addedObjects.Remove(m.Kid);
                        }

                        recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);
                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void ListKeyVersionsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                int numKeys = 3;
                int maxResults = 1;
                bool recoveryLevelIsConsistent = true;

                var addedObjects = new HashSet<string>();

                string keyName = "listkeyversionstest";

                //Create the keys
                for (int i = 0; i < numKeys; i++)
                {
                    var addedKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa).GetAwaiter().GetResult();
                    addedObjects.Add(addedKey.Key.Kid);

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(addedKey.Attributes, _softDeleteEnabled);
                }

                //List the keys
                var listResponse = client.GetKeyVersionsAsync(_vaultAddress, keyName, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (KeyItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Kid))
                        addedObjects.Remove(m.Kid);

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetKeyVersionsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (KeyItem m in listNextResponse)
                    {
                        if (addedObjects.Contains(m.Kid))
                            addedObjects.Remove(m.Kid);

                        recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);
                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }
#endregion

#region Deleted Key Operations

        [Fact]
        public void GetDeletedKeyTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                bool recoveryLevelIsConsistent = true;
                var keyName = "GetDeletedKeyTest";
                var attributes = new KeyAttributes();
                var tags = new Dictionary<string, string>() { { "purpose", "unit test" }, { "test name ", "GetDeletedKeyTest" } };
                var createdKey = client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attributes, tags).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdKey.Attributes, _softDeleteEnabled);

                var deletedKey = client.DeleteKeyAsync(_vaultAddress, createdKey.KeyIdentifier.Name).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedKey.Attributes, _softDeleteEnabled);

                try
                {
                    this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                    // Get the deleted key using its recovery identifier
                    var getDeletedKey = client.GetDeletedKeyAsync(_vaultAddress, createdKey.KeyIdentifier.Name).GetAwaiter().GetResult();
                    VerifyIdsAreEqual(createdKey.Key.Kid, getDeletedKey.Key.Kid);
                    VerifyIdsAreEqual(deletedKey.RecoveryId, getDeletedKey.RecoveryId);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(getDeletedKey.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                    // Purge the key
                    client.PurgeDeletedKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        public void KeyCreateDeleteRecoverPurgeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                bool recoveryLevelIsConsistent = true;
                var keyName = "CreateDeleteRecoverPurgeTest";
                var attributes = new KeyAttributes();
                var tags = new Dictionary<string, string>() { { "purpose", "unit test" }, { "test name ", "CreateDeleteRecoverPurgeTest" } };
                var createdKey = client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attributes, tags).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdKey.Attributes, _softDeleteEnabled);

                var originalKey = client.GetKeyAsync(_vaultAddress, createdKey.KeyIdentifier.Name).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(originalKey.Attributes, _softDeleteEnabled);

                try
                {
                    // Delete the key
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedKey.Attributes, _softDeleteEnabled);

                    //verify the key is deleted
                    try
                    {
                        client.GetKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                    // Recover the key
                    var recoveredKey = client.RecoverDeletedKeyAsync(deletedKey.RecoveryId).GetAwaiter().GetResult();
                    VerifyKeyAttributesAreEqual(recoveredKey.Attributes, originalKey.Attributes);
                    VerifyKeyOperationsAreEqual(recoveredKey.Key.KeyOps, originalKey.Key.KeyOps);
                    Assert.Equal(keyName, recoveredKey.KeyIdentifier.Name);
                    Assert.Equal(originalKey.Key.Kid, recoveredKey.Key.Kid);
                    Assert.False(String.IsNullOrWhiteSpace(recoveredKey.Attributes.RecoveryLevel));
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(recoveredKey.Attributes, _softDeleteEnabled);

                    this.fixture.WaitOnKey(client, _vaultAddress, keyName);

                    var recoveredGetKey = client.GetKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    VerifyKeyAttributesAreEqual(recoveredGetKey.Attributes, originalKey.Attributes);
                    VerifyKeyOperationsAreEqual(recoveredGetKey.Key.KeyOps, originalKey.Key.KeyOps);
                    Assert.Equal(keyName, recoveredGetKey.KeyIdentifier.Name);
                    Assert.Equal(originalKey.Key.Kid, recoveredGetKey.Key.Kid);
                    Assert.False(String.IsNullOrWhiteSpace(recoveredGetKey.Attributes.RecoveryLevel));
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(recoveredGetKey.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnKey(client, _vaultAddress, keyName);

                    // Delete the key
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedKey.Attributes, _softDeleteEnabled);

                    //verify the key is deleted
                    try
                    {
                        client.GetKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                    // Purge the key
                    client.PurgeDeletedKeyAsync(deletedKey.RecoveryId).GetAwaiter().GetResult();

                    //verify the key is purged
                    try
                    {
                        client.GetDeletedKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void ListDeletedKeysTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                string keyNamePrefix = "listdeletedkeytest";
                int numKeys = 3;
                int maxResults = 1;
                bool recoveryLevelIsConsistent = true;

                var addedObjects = new HashSet<string>();
                var removedObjects = new HashSet<string>();

                //Create and delete the keys
                for (int i = 0; i < numKeys; i++)
                {
                    string keyName = keyNamePrefix + i.ToString();

                    var addedKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa).GetAwaiter().GetResult();
                    client.DeleteKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();

                    this.fixture.WaitOnDeletedKey(client, _vaultAddress, keyName);

                    addedObjects.Add(GetKidWithoutVersion(addedKey.Key.Kid));
                }

                //List the deleted keys
                var listResponse = client.GetDeletedKeysAsync(_vaultAddress, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (DeletedKeyItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Kid))
                    {
                        Assert.StartsWith(keyNamePrefix, m.Identifier.Name);
                        Assert.NotNull(m.RecoveryId);
                        Assert.NotNull(m.ScheduledPurgeDate);
                        Assert.NotNull(m.DeletedDate);
                        Assert.Equal(m.RecoveryIdentifier.Name, m.Identifier.Name);
                        Assert.StartsWith(keyNamePrefix, m.RecoveryIdentifier.Name);

                        recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);

                        addedObjects.Remove(m.Kid);
                        removedObjects.Add(m.RecoveryId);
                    }
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetDeletedKeysNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (DeletedKeyItem m in listNextResponse)
                    {
                        if (addedObjects.Contains(m.Kid))
                        {
                            Assert.StartsWith(keyNamePrefix, m.Identifier.Name);
                            Assert.NotNull(m.RecoveryId);
                            Assert.NotNull(m.ScheduledPurgeDate);
                            Assert.NotNull(m.DeletedDate);
                            Assert.Equal(m.RecoveryIdentifier.Name, m.Identifier.Name);
                            Assert.StartsWith(keyNamePrefix,m.RecoveryIdentifier.Name);

                            recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);

                            addedObjects.Remove(m.Kid);
                            removedObjects.Add(m.RecoveryId);
                        }
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                foreach (string recoveryId in removedObjects)
                {
                    client.PurgeDeletedKeyAsync(recoveryId).Wait();
                }

                Assert.True(addedObjects.Count == 0);
                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }
#endregion

#region Secret Operations

        public void SecretCreateUpdateDeleteTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                string secretName = "crpsecret";
                string originalSecretValue = "mysecretvalue";
                bool recoveryLevelAttributeIsConsistent = true;

                var originalSecret =
                    client.SetSecretAsync(_vaultAddress, secretName, originalSecretValue).GetAwaiter().GetResult();

                VerifySecretValuesAreEqual(originalSecret.Value, originalSecretValue);
                Assert.Equal(secretName, originalSecret.SecretIdentifier.Name);
                recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(originalSecret.Attributes, _softDeleteEnabled);

                try
                {
                    // Get the original secret
                    var originalReadSecret = client.GetSecretAsync(originalSecret.Id).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(originalReadSecret.Value, originalSecret.Value);
                    VerifyIdsAreEqual(originalSecret.Id, originalReadSecret.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(originalReadSecret.Attributes, _softDeleteEnabled);

                    // Update the secret
                    var updatedSecretValue = "mysecretvalue2";
                    var updatedSecret =
                        client.SetSecretAsync(_vaultAddress, secretName, updatedSecretValue).GetAwaiter().GetResult();
                    VerifySecretValuesAreNotEqual(originalSecret.Value, updatedSecret.Value);
                    VerifyIdsAreNotEqual(originalSecret.Id, updatedSecret.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(updatedSecret.Attributes, _softDeleteEnabled);

                    // Read the secret using full identifier
                    var updatedReadSecret = client.GetSecretAsync(updatedSecret.Id).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(updatedReadSecret.Value, updatedSecret.Value);
                    VerifyIdsAreEqual(updatedReadSecret.Id, updatedSecret.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(updatedReadSecret.Attributes, _softDeleteEnabled);

                    // Read the secret with the version independent identifier
                    updatedReadSecret = client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(updatedReadSecret.Value, updatedSecret.Value);
                    VerifyIdsAreEqual(updatedReadSecret.Id, updatedSecret.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(updatedReadSecret.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    // Delete the secret
                    var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(deletedSecret.Attributes, _softDeleteEnabled);

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                        client.PurgeDeletedSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }

                    //verify the secret is deleted
                    try
                    {
                        client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    Assert.True(recoveryLevelAttributeIsConsistent, "The recoveryLevel attribute did not return consistently the expected value");
                }
            }
        }

        [Fact]
        public void GetSecretVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var secretName = "mysecretname";
                var secretValue = "mysecretvalue";
                var secretOlder = client.SetSecretAsync(_vaultAddress, secretName, secretValue).GetAwaiter().GetResult();
                bool recoveryLevelAttributeIsConsistent = true;

                try
                {
                    // Get the latest secret using its identifier without version
                    var secretIdentifier = new SecretIdentifier(secretOlder.Id);
                    var getSecret = client.GetSecretAsync(_vaultAddress, secretIdentifier.Name).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(getSecret.Value, secretOlder.Value);
                    VerifyIdsAreEqual(secretOlder.Id, getSecret.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(getSecret.Attributes, _softDeleteEnabled);

                    var secretNewer =
                        client.SetSecretAsync(_vaultAddress, secretName, secretValue).GetAwaiter().GetResult();

                    // Get the older secret version using its name and version
                    var getSecretOlder =
                        client.GetSecretAsync(_vaultAddress, secretIdentifier.Name, secretIdentifier.Version)
                            .GetAwaiter()
                            .GetResult();
                    VerifySecretValuesAreEqual(getSecretOlder.Value, secretOlder.Value);
                    VerifyIdsAreEqual(secretOlder.Id, getSecretOlder.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(getSecretOlder.Attributes, _softDeleteEnabled);

                    // Get the latest secret using its identifier with version
                    var secretIdentifierNewer = new SecretIdentifier(secretNewer.Id);
                    var getSecretNewer =
                        client.GetSecretAsync(_vaultAddress, secretIdentifierNewer.Name, secretIdentifierNewer.Version)
                            .GetAwaiter()
                            .GetResult();
                    VerifySecretValuesAreEqual(getSecretNewer.Value, secretNewer.Value);
                    VerifyIdsAreEqual(secretNewer.Id, getSecretNewer.Id);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(getSecretNewer.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    // Delete the secret
                    var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(deletedSecret.Attributes, _softDeleteEnabled);

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                        client.PurgeDeletedSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                }
            }
        }

        [Fact]
        public void ListSecretsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                int numSecrets = 3;
                int maxResults = 1;

                var addedObjects = new HashSet<string>();
                string secretValue = "mysecretvalue";

                //Create the secrets
                for (int i = 0; i < numSecrets; i++)
                {
                    string secretName = "listsecrettest" + i.ToString();

                    var addedSecret =
                        client.SetSecretAsync(_vaultAddress, secretName, secretValue, contentType: "plainText").GetAwaiter().GetResult();
                    addedObjects.Add(addedSecret.Id.Substring(0, addedSecret.Id.LastIndexOf("/")));
                }

                //List the secrets
                var listResponse = client.GetSecretsAsync(_vaultAddress, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (SecretItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Id))
                    {
                        Assert.Equal("plainText", m.ContentType);
                        Assert.StartsWith("listsecrettest", m.Identifier.Name);
                        addedObjects.Remove(m.Id);
                    }
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetSecretsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (SecretItem m in listNextResponse)
                    {
                        if (addedObjects.Contains(m.Id))
                        {
                            Assert.Equal("plainText", m.ContentType);
                            if (addedObjects.Contains(m.Id))
                            {
                                Assert.StartsWith("listsecrettest", m.Identifier.Name);
                                addedObjects.Remove(m.Id);
                            }
                            addedObjects.Remove(m.Id);
                        }
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }

        [Fact]
        public void ListSecretVersionsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                int numSecretVersions = 3;
                int maxResults = 1;

                var addedObjects = new HashSet<string>();
                string secretValue = "mysecretvalue";
                string secretName = "listsecretversionstest";

                //Create the secrets
                for (int i = 0; i < numSecretVersions; i++)
                {

                    var addedSecret =
                        client.SetSecretAsync(_vaultAddress, secretName, secretValue).GetAwaiter().GetResult();
                    addedObjects.Add(addedSecret.Id);
                }

                //List the secret versions
                var listResponse = client.GetSecretVersionsAsync(_vaultAddress, secretName, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (SecretItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Id))
                        addedObjects.Remove(m.Id);
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetSecretVersionsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (SecretItem m in listNextResponse)
                    {
                        if (addedObjects.Contains(m.Id))
                            addedObjects.Remove(m.Id);
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }

        [Fact]
        public void TestSecretExtendedAttributes()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                string secretName = "secretwithextendedattribs";
                string originalSecretValue = "mysecretvalue";
                bool recoveryLevelIsConsistent = true;

                try
                {
                    var originalSecret = client.SetSecretAsync(
                        vaultBaseUrl: _vaultAddress,
                        secretName: secretName,
                        value: originalSecretValue,
                        tags: new Dictionary<string, string>() { { "purpose", "unit test" } },
                        contentType: "plaintext",
                        secretAttributes: NewSecretAttributes(
                            enabled: false,
                            active: false,
                            expired: false)
                        ).GetAwaiter().GetResult();

                    Assert.Equal("plaintext", originalSecret.ContentType);
                    Assert.Equal("unit test", originalSecret.Tags["purpose"]);
                    Assert.True(originalSecret.Attributes.Enabled != null && originalSecret.Attributes.Enabled == false);

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(originalSecret.Attributes, _softDeleteEnabled);

                    // Cannot get disabled secret
                    try
                    {
                        client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                        Assert.True(false, "Get on disabled secret must throw an exception.");
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        // Validate that exception contains an error code, an error message, and an inner error code
                        Assert.True(!String.IsNullOrEmpty(ex.Body.Error.Code));
                        Assert.True(!String.IsNullOrEmpty(ex.Body.Error.Message));
                        Assert.NotNull(ex.Body.Error.InnerError);
                        Assert.True(!String.IsNullOrEmpty(ex.Body.Error.InnerError.Code));
                    }

                    // Cleanup is a bit more difficult in soft-delete-enabled vaults; since deletion
                    // is asynchronous, and the secret is disabled, we can't know when the secret is
                    // safe to purge. Therefore we'll re-enable the secret before proceeding with the
                    // common cleanup code.
                    if (_softDeleteEnabled)
                    {
                        originalSecret.Attributes.Enabled = true;
                        originalSecret.Attributes.NotBefore = DateTime.UtcNow.AddDays(-1);

                        // rev the secret to enable it
                        var updatedSecret = client.SetSecretAsync(_vaultAddress, secretName, originalSecretValue, (IDictionary<string,string>)originalSecret.Tags, originalSecret.ContentType, originalSecret.Attributes)
                            .GetAwaiter()
                            .GetResult();

                        // verify we can retrieve the secret
                        try
                        {
                            var retrievedEnabledSecret = client.GetSecretAsync(_vaultAddress, secretName)
                                .GetAwaiter()
                                .GetResult();
                        }
                        catch (KeyVaultErrorException)
                        {
                            Assert.False(false, "failed to re-enable disabled secret in soft-delete-enabled vault; cleanup will fail");
                        }
                    }
                }
                finally
                {
                    // Delete the secret
                    var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedSecret.Attributes, _softDeleteEnabled);

                    if (_softDeleteEnabled)
                    {
                        this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                        client.PurgeDeletedSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

#endregion

#region Deleted Secret Operations

        [Fact]
        public void GetDeletedSecretTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                var secretName = "GetDeletedSecretTest";
                var secretValue = "mysecretvalue";
                bool recoveryLevelIsConsistent = true;

                var secretOlder = client.SetSecretAsync(_vaultAddress, secretName, secretValue).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(secretOlder.Attributes, _softDeleteEnabled);

                var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedSecret.Attributes, _softDeleteEnabled);

                this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                try
                {
                    // Get the deleted secret using its recovery identifier
                    var getDeletedSecret = client.GetDeletedSecretAsync(_vaultAddress, secretOlder.SecretIdentifier.Name).GetAwaiter().GetResult();
                    VerifyIdsAreEqual(secretOlder.Id, getDeletedSecret.Id);
                    VerifyIdsAreEqual(deletedSecret.RecoveryId, getDeletedSecret.RecoveryId);

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(getDeletedSecret.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                    // Purge the secret
                    client.PurgeDeletedSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        public void SecretCreateDeleteRecoverPurgeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                string secretName = "SecretCreateDeleteRecoverPurgeTest";
                string originalSecretValue = "mysecretvalue";
                bool recoveryLevelAttributeIsConsistent = true;

                var originalSecret =
                    client.SetSecretAsync(_vaultAddress, secretName, originalSecretValue).GetAwaiter().GetResult();

                VerifySecretValuesAreEqual(originalSecret.Value, originalSecretValue);
                Assert.Equal(secretName, originalSecret.SecretIdentifier.Name);
                recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(originalSecret.Attributes, _softDeleteEnabled);

                try
                {
                    // Delete the secret
                    var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(deletedSecret.Attributes, _softDeleteEnabled);

                    //verify the secret is deleted
                    try
                    {
                        client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                    // Recover the secret
                    var recoveredSecret = client.RecoverDeletedSecretAsync(deletedSecret.RecoveryId).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(recoveredSecret.Value, null);
                    Assert.Equal(secretName, recoveredSecret.SecretIdentifier.Name);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(recoveredSecret.Attributes, _softDeleteEnabled);

                    this.fixture.WaitOnSecret(client, _vaultAddress, secretName);

                    // Read the recovered secret using full identifier
                    var recoveredReadSecret = client.GetSecretAsync(recoveredSecret.Id).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(recoveredReadSecret.Value, originalSecretValue);
                    VerifyIdsAreEqual(recoveredReadSecret.Id, recoveredSecret.Id);
                    VerifyTagsAreEqual(originalSecret.Tags, recoveredReadSecret.Tags);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(recoveredReadSecret.Attributes, _softDeleteEnabled);

                    // Read the recovered secret with the version independent identifier
                    recoveredReadSecret = client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(recoveredReadSecret.Value, originalSecretValue);
                    VerifyIdsAreEqual(recoveredReadSecret.Id, recoveredSecret.Id);
                    VerifyTagsAreEqual(originalSecret.Tags, recoveredReadSecret.Tags);
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(recoveredReadSecret.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnSecret(client, _vaultAddress, secretName);

                    // Delete the secret
                    var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(deletedSecret.Attributes, _softDeleteEnabled);

                    //verify the secret is deleted
                    try
                    {
                        client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);

                    // Purge the secret
                    client.PurgeDeletedSecretAsync(deletedSecret.RecoveryId).GetAwaiter().GetResult();

                    //verify the secret is purged
                    try
                    {
                        client.GetDeletedSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }
                }

                Assert.True(recoveryLevelAttributeIsConsistent, "The 'recoveryLevel' attribute did not consistently return the expected value");
            }
        }

        [Fact]
        public void ListDeletedSecretsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                int numSecrets = 3;
                int maxResults = 1;
                bool recoveryLevelAttributeIsConsistent = true;

                var addedObjects = new HashSet<string>();
                var removedObjects = new HashSet<string>();
                string secretValue = "mysecretvalue";

                //Create and delete the secrets
                for (int i = 0; i < numSecrets; i++)
                {
                    string secretName = "listdeletedsecrettest" + i.ToString();

                    var addedSecret =
                        client.SetSecretAsync(_vaultAddress, secretName, secretValue, contentType: "plainText").GetAwaiter().GetResult();
                    addedObjects.Add(addedSecret.Id.Substring(0, addedSecret.Id.LastIndexOf("/")));

                    client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();

                    this.fixture.WaitOnDeletedSecret(client, _vaultAddress, secretName);
                }

                //List the secrets
                var listResponse = client.GetDeletedSecretsAsync(_vaultAddress, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (DeletedSecretItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Id))
                    {
                        Assert.StartsWith("listdeletedsecrettest", m.Identifier.Name);
                        Assert.NotNull(m.RecoveryId);
                        Assert.NotNull(m.ScheduledPurgeDate);
                        Assert.NotNull(m.DeletedDate);
                        Assert.StartsWith("listdeletedsecrettest", m.RecoveryIdentifier.Name);

                        recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);

                        addedObjects.Remove(m.Id);
                        removedObjects.Add(m.RecoveryId);
                    }
                }

                var nextLink = listResponse.NextPageLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetDeletedSecretsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (DeletedSecretItem m in listNextResponse)
                    {
                        if (addedObjects.Contains(m.Id))
                        {
                            Assert.StartsWith("listdeletedsecrettest", m.Identifier.Name);
                            Assert.NotNull(m.RecoveryId);
                            Assert.NotNull(m.ScheduledPurgeDate);
                            Assert.NotNull(m.DeletedDate);
                            Assert.StartsWith("listdeletedsecrettest", m.RecoveryIdentifier.Name);

                            recoveryLevelAttributeIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);

                            addedObjects.Remove(m.Id);
                            removedObjects.Add(m.RecoveryId);
                        }
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);

                foreach (string recoveryId in removedObjects)
                {
                    client.PurgeDeletedSecretAsync(recoveryId).Wait();
                }

                Assert.True(recoveryLevelAttributeIsConsistent, "The 'recoveryLevel' attribute did not consistently return the expected value");
            }
        }

#endregion

#region Certificate Operations
        [Fact]
        public void CertificateImportTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "importCert01";
                const string certificateContent =
                    "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";
                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";
                bool recoveryLevelIsConsistent = true;

                var myCertificate = new X509Certificate2(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                // Import cert
                var createdCertificateBundle = client.ImportCertificateAsync(_vaultAddress, certificateName, certificateContent, certificatePassword, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdCertificateBundle.Attributes, _softDeleteEnabled);

                Assert.NotNull(createdCertificateBundle.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                try
                {
                    // Get the current version
                    var certificateBundleLatest =
                        client.GetCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleLatest);
                    Assert.NotNull(certificateBundleLatest.SecretIdentifier);
                    Assert.NotNull(certificateBundleLatest.KeyIdentifier);
                    Assert.NotNull(certificateBundleLatest.X509Thumbprint);
                    Assert.NotNull(createdCertificateBundle.Policy);
                    Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(certificateBundleLatest.Attributes, _softDeleteEnabled);

                    Assert.NotNull(certificateBundleLatest.Cer);
                    publicCer = new X509Certificate2(certificateBundleLatest.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the specific version
                    var certificateBundleVersion =
                        client.GetCertificateAsync(createdCertificateBundle.CertificateIdentifier.Identifier).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleVersion);
                    Assert.NotNull(certificateBundleVersion.SecretIdentifier);
                    Assert.NotNull(certificateBundleVersion.KeyIdentifier);
                    Assert.NotNull(certificateBundleVersion.X509Thumbprint);
                    Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(certificateBundleVersion.Attributes, _softDeleteEnabled);

                    Assert.NotNull(certificateBundleVersion.Cer);
                    publicCer = new X509Certificate2(certificateBundleVersion.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the secret
                    var retrievedSecret =
                        client.GetSecretAsync(certificateBundleVersion.SecretIdentifier.Identifier).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(retrievedSecret.ContentType, certificateMimeType));
                    Assert.True(retrievedSecret.Managed);

                    // Get corresponding key
                    var key = client.GetKeyAsync(createdCertificateBundle.Kid).GetAwaiter().GetResult();
                    Assert.True(key.Managed);

                    var retrievedCertificate = new X509Certificate2(
                        Convert.FromBase64String(retrievedSecret.Value),
                        string.Empty,
                        X509KeyStorageFlags.Exportable);

                    Assert.True(retrievedCertificate.HasPrivateKey);
                    Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, retrievedCertificate.Thumbprint));
                }
                finally
                {
                    // Delete
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(certificateBundleDeleted.Attributes, _softDeleteEnabled);

                    Assert.NotNull(certificateBundleDeleted);

                    if ( _softDeleteEnabled )
                    {
                        this.fixture.WaitOnDeletedCertificate(client, _vaultAddress, certificateName);
                        client.PurgeDeletedCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        [Fact]
        public void CertificateImportTest2()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "importCert02";
                const string certificateContent =
                    "MIIJOwIBAzCCCPcGCSqGSIb3DQEHAaCCCOgEggjkMIII4DCCBgkGCSqGSIb3DQEHAaCCBfoEggX2MIIF8jCCBe4GCyqGSIb3DQEMCgECoIIE/jCCBPowHAYKKoZIhvcNAQwBAzAOBAj15YH9pOE58AICB9AEggTYLrI+SAru2dBZRQRlJY7XQ3LeLkah2FcRR3dATDshZ2h0IA2oBrkQIdsLyAAWZ32qYR1qkWxLHn9AqXgu27AEbOk35+pITZaiy63YYBkkpR+pDdngZt19Z0PWrGwHEq5z6BHS2GLyyN8SSOCbdzCz7blj3+7IZYoMj4WOPgOm/tQ6U44SFWek46QwN2zeA4i97v7ftNNns27ms52jqfhOvTA9c/wyfZKAY4aKJfYYUmycKjnnRl012ldS2lOkASFt+lu4QCa72IY6ePtRudPCvmzRv2pkLYS6z3cI7omT8nHP3DymNOqLbFqr5O2M1ZYaLC63Q3xt3eVvbcPh3N08D1hHkhz/KDTvkRAQpvrW8ISKmgDdmzN55Pe55xHfSWGB7gPw8sZea57IxFzWHTK2yvTslooWoosmGxanYY2IG/no3EbPOWDKjPZ4ilYJe5JJ2immlxPz+2e2EOCKpDI+7fzQcRz3PTd3BK+budZ8aXX8aW/lOgKS8WmxZoKnOJBNWeTNWQFugmktXfdPHAdxMhjUXqeGQd8wTvZ4EzQNNafovwkI7IV/ZYoa++RGofVR3ZbRSiBNF6TDj/qXFt0wN/CQnsGAmQAGNiN+D4mY7i25dtTu/Jc7OxLdhAUFpHyJpyrYWLfvOiS5WYBeEDHkiPUa/8eZSPA3MXWZR1RiuDvuNqMjct1SSwdXADTtF68l/US1ksU657+XSC+6ly1A/upz+X71+C4Ho6W0751j5ZMT6xKjGh5pee7MVuduxIzXjWIy3YSd0fIT3U0A5NLEvJ9rfkx6JiHjRLx6V1tqsrtT6BsGtmCQR1UCJPLqsKVDvAINx3cPA/CGqr5OX2BGZlAihGmN6n7gv8w4O0k0LPTAe5YefgXN3m9pE867N31GtHVZaJ/UVgDNYS2jused4rw76ZWN41akx2QN0JSeMJqHXqVz6AKfz8ICS/dFnEGyBNpXiMRxrY/QPKi/wONwqsbDxRW7vZRVKs78pBkE0ksaShlZk5GkeayDWC/7Hi/NqUFtIloK9XB3paLxo1DGu5qqaF34jZdktzkXp0uZqpp+FfKZaiovMjt8F7yHCPk+LYpRsU2Cyc9DVoDA6rIgf+uEP4jppgehsxyT0lJHax2t869R2jYdsXwYUXjgwHIV0voj7bJYPGFlFjXOp6ZW86scsHM5xfsGQoK2Fp838VT34SHE1ZXU/puM7rviREHYW72pfpgGZUILQMohuTPnd8tFtAkbrmjLDo+k9xx7HUvgoFTiNNWuq/cRjr70FKNguMMTIrid+HwfmbRoaxENWdLcOTNeascER2a+37UQolKD5ksrPJG6RdNA7O2pzp3micDYRs/+s28cCIxO//J/d4nsgHp6RTuCu4+Jm9k0YTw2Xg75b2cWKrxGnDUgyIlvNPaZTB5QbMid4x44/lE0LLi9kcPQhRgrK07OnnrMgZvVGjt1CLGhKUv7KFc3xV1r1rwKkosxnoG99oCoTQtregcX5rIMjHgkc1IdflGJkZzaWMkYVFOJ4Weynz008i4ddkske5vabZs37Lb8iggUYNBYZyGzalruBgnQyK4fz38Fae4nWYjyildVfgyo/fCePR2ovOfphx9OQJi+M9BoFmPrAg+8ARDZ+R+5yzYuEc9ZoVX7nkp7LTGB3DANBgkrBgEEAYI3EQIxADATBgkqhkiG9w0BCRUxBgQEAQAAADBXBgkqhkiG9w0BCRQxSh5IAGEAOAAwAGQAZgBmADgANgAtAGUAOQA2AGUALQA0ADIAMgA0AC0AYQBhADEAMQAtAGIAZAAxADkANABkADUAYQA2AGIANwA3MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAHQAcgBvAG4AZwAgAEMAcgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIwggLPBgkqhkiG9w0BBwagggLAMIICvAIBADCCArUGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECNX+VL2MxzzWAgIH0ICCAojmRBO+CPfVNUO0s+BVuwhOzikAGNBmQHNChmJ/pyzPbMUbx7tO63eIVSc67iERda2WCEmVwPigaVQkPaumsfp8+L6iV/BMf5RKlyRXcwh0vUdu2Qa7qadD+gFQ2kngf4Dk6vYo2/2HxayuIf6jpwe8vql4ca3ZtWXfuRix2fwgltM0bMz1g59d7x/glTfNqxNlsty0A/rWrPJjNbOPRU2XykLuc3AtlTtYsQ32Zsmu67A7UNBw6tVtkEXlFDqhavEhUEO3dvYqMY+QLxzpZhA0q44ZZ9/ex0X6QAFNK5wuWxCbupHWsgxRwKftrxyszMHsAvNoNcTlqcctee+ecNwTJQa1/MDbnhO6/qHA7cfG1qYDq8Th635vGNMW1w3sVS7l0uEvdayAsBHWTcOC2tlMa5bfHrhY8OEIqj5bN5H9RdFy8G/W239tjDu1OYjBDydiBqzBn8HG1DSj1Pjc0kd/82d4ZU0308KFTC3yGcRad0GnEH0Oi3iEJ9HbriUbfVMbXNHOF+MktWiDVqzndGMKmuJSdfTBKvGFvejAWVO5E4mgLvoaMmbchc3BO7sLeraHnJN5hvMBaLcQI38N86mUfTR8AP6AJ9c2k514KaDLclm4z6J8dMz60nUeo5D3YD09G6BavFHxSvJ8MF0Lu5zOFzEePDRFm9mH8W0N/sFlIaYfD/GWU/w44mQucjaBk95YtqOGRIj58tGDWr8iUdHwaYKGqU24zGeRae9DhFXPzZshV1ZGsBQFRaoYkyLAwdJWIXTi+c37YaC8FRSEnnNmS79Dou1Kc3BvK4EYKAD2KxjtUebrV174gD0Q+9YuJ0GXOTspBvCFd5VT2Rw5zDNrA/J3F5fMCk4wOzAfMAcGBSsOAwIaBBSxgh2xyF+88V4vAffBmZXv8Txt4AQU4O/NX4MjxSodbE7ApNAMIvrtREwCAgfQ";

                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";

                var myCertificateCollection = new X509Certificate2Collection();
                myCertificateCollection.Import(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                var privateKeyCertificateIndex = 0;
                for (var i = 0; i < myCertificateCollection.Count; i++)
                {
                    if (myCertificateCollection[i].HasPrivateKey)
                    {
                        privateKeyCertificateIndex = i;
                        break;
                    }
                }

                // Import cert
                var createdCertificateBundle = client.ImportCertificateAsync(_vaultAddress, certificateName, myCertificateCollection, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                Assert.NotNull(createdCertificateBundle.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                try
                {
                    // Get the current version
                    var certificateBundleLatest =
                        client.GetCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleLatest);
                    Assert.NotNull(certificateBundleLatest.SecretIdentifier);
                    Assert.NotNull(certificateBundleLatest.KeyIdentifier);
                    Assert.NotNull(certificateBundleLatest.X509Thumbprint);
                    Assert.NotNull(createdCertificateBundle.Policy);
                    Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    Assert.NotNull(certificateBundleLatest.Cer);
                    publicCer = new X509Certificate2(certificateBundleLatest.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the specific version
                    var certificateBundleVersion =
                        client.GetCertificateAsync(createdCertificateBundle.CertificateIdentifier.Identifier).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleVersion);
                    Assert.NotNull(certificateBundleVersion.SecretIdentifier);
                    Assert.NotNull(certificateBundleVersion.KeyIdentifier);
                    Assert.NotNull(certificateBundleVersion.X509Thumbprint);
                    Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    Assert.NotNull(certificateBundleVersion.Cer);
                    publicCer = new X509Certificate2(certificateBundleVersion.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the secret
                    var retrievedSecret =
                        client.GetSecretAsync(certificateBundleVersion.SecretIdentifier.Identifier).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(retrievedSecret.ContentType, certificateMimeType));

                    var retrievedCertificate = new X509Certificate2(
                        Convert.FromBase64String(retrievedSecret.Value),
                        string.Empty,
                        X509KeyStorageFlags.Exportable);

                    Assert.True(retrievedCertificate.HasPrivateKey);
                    Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, retrievedCertificate.Thumbprint));
                }
                finally
                {
                    // Delete
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificateImportTest3()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "importCert03";
                const string certificateContent =
                      "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";

                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";

                var myCertificateCollection = new X509Certificate2Collection();
                myCertificateCollection.Import(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                var privateKeyCertificateIndex = 0;
                for (var i = 0; i < myCertificateCollection.Count; i++)
                {
                    if (myCertificateCollection[i].HasPrivateKey)
                    {
                        privateKeyCertificateIndex = i;
                        break;
                    }
                }

                // Import cert
                var createdCertificateBundle = client.ImportCertificateAsync(_vaultAddress, certificateName, myCertificateCollection, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                Assert.NotNull(createdCertificateBundle.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                try
                {
                    // Get the current version
                    var certificateBundleLatest =
                        client.GetCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleLatest);
                    Assert.NotNull(certificateBundleLatest.SecretIdentifier);
                    Assert.NotNull(certificateBundleLatest.KeyIdentifier);
                    Assert.NotNull(certificateBundleLatest.X509Thumbprint);
                    Assert.NotNull(createdCertificateBundle.Policy);
                    Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    Assert.NotNull(certificateBundleLatest.Cer);
                    publicCer = new X509Certificate2(certificateBundleLatest.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the specific version
                    var certificateBundleVersion =
                        client.GetCertificateAsync(createdCertificateBundle.CertificateIdentifier.Identifier).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleVersion);
                    Assert.NotNull(certificateBundleVersion.SecretIdentifier);
                    Assert.NotNull(certificateBundleVersion.KeyIdentifier);
                    Assert.NotNull(certificateBundleVersion.X509Thumbprint);
                    Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    Assert.NotNull(certificateBundleVersion.Cer);
                    publicCer = new X509Certificate2(certificateBundleVersion.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the secret
                    var retrievedSecret =
                        client.GetSecretAsync(certificateBundleVersion.SecretIdentifier.Identifier).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(retrievedSecret.ContentType, certificateMimeType));

                    var retrievedCertificate = new X509Certificate2(
                        Convert.FromBase64String(retrievedSecret.Value),
                        string.Empty,
                        X509KeyStorageFlags.Exportable);

                    Assert.True(retrievedCertificate.HasPrivateKey);
                    Assert.True(0 == string.CompareOrdinal(myCertificateCollection[privateKeyCertificateIndex].Thumbprint, retrievedCertificate.Thumbprint));
                }
                finally
                {
                    // Delete
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificateListTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // Create two certificates
                const string certificate01Name = "listCert01";
                const string certificate01Content =
                    "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";
                const string certificate01Password = "123";
                const string certificate01MimeType = "application/x-pkcs12";

                var certificate01 = new X509Certificate2(Convert.FromBase64String(certificate01Content), certificate01Password, X509KeyStorageFlags.Exportable);
                var createdCertificateBundle01 = client.ImportCertificateAsync(_vaultAddress, certificate01Name, certificate01Content, certificate01Password, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificate01MimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle01);
                Assert.NotNull(createdCertificateBundle01.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle01.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle01.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle01.Policy);
                Assert.True(0 == string.CompareOrdinal(certificate01.Thumbprint, ToHexString(createdCertificateBundle01.X509Thumbprint)));

                Assert.NotNull(createdCertificateBundle01.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle01.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                const string certificate02Name = "listCert02";
                const string certificate02Content =
                    "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";
                const string certificate02Password = "123";
                const string certificate02MimeType = "application/x-pkcs12";

                var certificate02 = new X509Certificate2(Convert.FromBase64String(certificate02Content), certificate02Password, X509KeyStorageFlags.Exportable);

                var createdCertificateBundle02 = client.ImportCertificateAsync(_vaultAddress, certificate02Name, certificate02Content, certificate02Password, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificate02MimeType
                    }
                }).GetAwaiter().GetResult();


                Assert.NotNull(createdCertificateBundle02);
                Assert.NotNull(createdCertificateBundle02.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle02.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle02.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle02.Policy);
                Assert.True(0 == string.CompareOrdinal(certificate02.Thumbprint, ToHexString(createdCertificateBundle02.X509Thumbprint)));

                Assert.NotNull(createdCertificateBundle02.Cer);
                publicCer = new X509Certificate2(createdCertificateBundle02.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                try
                {
                    var certList = client.GetCertificatesAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(certList);
                    Assert.True(certList.Count() >= 2);
                    Assert.Contains(certList, s => 0 == string.CompareOrdinal(ToHexString(s.X509Thumbprint), ToHexString(createdCertificateBundle01.X509Thumbprint)));
                    Assert.Contains(certList, s => 0 == string.CompareOrdinal(ToHexString(s.X509Thumbprint), ToHexString(createdCertificateBundle02.X509Thumbprint)));
                }
                finally
                {
                    // Delete
                    var certificateBundleDeleted01 =
                        client.DeleteCertificateAsync(_vaultAddress, certificate01Name).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted01);

                    var certificateBundleDeleted02 =
                        client.DeleteCertificateAsync(_vaultAddress, certificate02Name).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted02);
                }
            }

        }

        [Fact]
        public void CertificateListVersionsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // Create two certificates
                const string certificateName = "listVersionsCert01";
                const string certificate01Content =
                    "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";
                const string certificate01Password = "123";
                const string certificate01MimeType = "application/x-pkcs12";

                var version01 = new X509Certificate2(Convert.FromBase64String(certificate01Content), certificate01Password, X509KeyStorageFlags.Exportable);
                var createdCertificateBundle01 = client.ImportCertificateAsync(_vaultAddress, certificateName, certificate01Content, certificate01Password, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificate01MimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle01);
                Assert.NotNull(createdCertificateBundle01.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle01.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle01.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle01.Policy);
                Assert.True(0 == string.CompareOrdinal(version01.Thumbprint, ToHexString(createdCertificateBundle01.X509Thumbprint)));

                Assert.NotNull(createdCertificateBundle01.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle01.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                const string certificate02Content =
    "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";
                const string certificate02Password = "123";
                const string certificate02MimeType = "application/x-pkcs12";

                var version02 = new X509Certificate2(Convert.FromBase64String(certificate02Content), certificate02Password, X509KeyStorageFlags.Exportable);
                var createdCertificateBundle02 = client.ImportCertificateAsync(_vaultAddress, certificateName, certificate02Content, certificate02Password, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificate02MimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle02);
                Assert.NotNull(createdCertificateBundle02.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle02.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle02.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle02.Policy);
                Assert.True(0 == string.CompareOrdinal(version02.Thumbprint, ToHexString(createdCertificateBundle02.X509Thumbprint)));

                Assert.NotNull(createdCertificateBundle02.Cer);
                publicCer = new X509Certificate2(createdCertificateBundle02.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                try
                {
                    var certList = client.GetCertificateVersionsAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    Assert.NotNull(certList);
                    Assert.True(2 == certList.Count());
                    Assert.Contains(certList, s => s.X509Thumbprint.SequenceEqual(createdCertificateBundle01.X509Thumbprint));
                    Assert.Contains(certList, s => s.X509Thumbprint.SequenceEqual(createdCertificateBundle02.X509Thumbprint));
                }
                finally
                {
                    // Delete
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }

        }

        [Fact]
        public void CertificateCreateSelfSignedTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "selfSignedCert01";
                const string certificateMimeType = "application/x-pkcs12";
                const string certificateSubjectName = "CN=*.microsoft.com";
                try
                {
                    var certificateOperation = client.CreateCertificateAsync(_vaultAddress, certificateName, new CertificatePolicy
                    {
                        KeyProperties = new KeyProperties
                        {
                            Exportable = true,
                            KeySize = 2048,
                            KeyType = "RSA",
                            ReuseKey = false
                        },
                        SecretProperties = new SecretProperties
                        {
                            ContentType = certificateMimeType
                        },
                        IssuerParameters = new IssuerParameters
                        {
                            Name = WellKnownIssuers.Self
                        },
                        X509CertificateProperties = new X509CertificateProperties
                        {
                            Subject = certificateSubjectName,
                            SubjectAlternativeNames = new SubjectAlternativeNames
                            {
                                DnsNames = new[]
                                {
                                    "onedrive.microsoft.com",
                                    "xbox.microsoft.com"
                                }
                            }
                        }
                    }).GetAwaiter().GetResult();

                    var createdCertificateBundle = PollOnCertificateOperation(client, certificateOperation);
                    Assert.NotNull(createdCertificateBundle);
                    Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                    Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                    Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                    Assert.NotNull(createdCertificateBundle.Policy);

                    Assert.NotNull(createdCertificateBundle.Cer);
                    var publicCer = new X509Certificate2(createdCertificateBundle.Cer);
                    Assert.NotNull(publicCer);
                    Assert.False(publicCer.HasPrivateKey);

                    // Get the certificate as a secret
                    var retrievedSecret = client.GetSecretAsync(createdCertificateBundle.SecretIdentifier.Identifier).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(retrievedSecret.ContentType, certificateMimeType));

                    var retrievedCertificate = new X509Certificate2(
                        Convert.FromBase64String(retrievedSecret.Value),
                        string.Empty,
                        X509KeyStorageFlags.Exportable);

                    Assert.True(retrievedCertificate.HasPrivateKey);
                    Assert.True(0 == string.CompareOrdinal(retrievedCertificate.SubjectName.Name, certificateSubjectName));
                    Assert.True(0 == string.CompareOrdinal(retrievedCertificate.IssuerName.Name, certificateSubjectName));
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificateCreateLongSelfSignedTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "longSelfSignedCert01";
                const string certificateMimeType = "application/x-pkcs12";
                const string certificateSubjectName = "CN=*.microsoft.com";

                var certificateOperation = client.CreateCertificateAsync(_vaultAddress, certificateName, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    },
                    IssuerParameters = new IssuerParameters
                    {
                        Name = WellKnownIssuers.Self
                    },
                    X509CertificateProperties = new X509CertificateProperties
                    {
                        Subject = certificateSubjectName,
                        SubjectAlternativeNames = new SubjectAlternativeNames
                        {
                            DnsNames = new[]
                            {
                                "onedrive.microsoft.com",
                                "xbox.microsoft.com"
                            }
                        },
                        ValidityInMonths = 24,
                    }
                }).GetAwaiter().GetResult();

                var createdCertificateBundle = PollOnCertificateOperation(client, certificateOperation);
                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);

                try
                {
                    // Get the certificate as a secret
                    var retrievedSecret = client.GetSecretAsync(createdCertificateBundle.SecretIdentifier.Identifier).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(retrievedSecret.ContentType, certificateMimeType));

                    var retrievedCertificate = new X509Certificate2(
                        Convert.FromBase64String(retrievedSecret.Value),
                        string.Empty,
                        X509KeyStorageFlags.Exportable);

                    Assert.True(retrievedCertificate.HasPrivateKey);
                    Assert.True(0 == string.CompareOrdinal(retrievedCertificate.SubjectName.Name, certificateSubjectName));
                    Assert.True(0 == string.CompareOrdinal(retrievedCertificate.IssuerName.Name, certificateSubjectName));

                    // 24 months (ie 2 years) is 729 or 730 days. 
                    // for some reason the validity is 731 (+ some) days though
                    var validity = retrievedCertificate.NotAfter - retrievedCertificate.NotBefore;
                    Assert.True(validity >= TimeSpan.FromDays(729));
                    Assert.True(validity <= TimeSpan.FromDays(732));
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificateCreateTestIssuerTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string issuer01Name = "issuer01";
                var issuer01 = new IssuerBundle
                {
                    Provider = "Test",
                };

                var createdIssuer01 = client.SetCertificateIssuerAsync(_vaultAddress, issuer01Name, issuer01.Provider).GetAwaiter().GetResult();
                Assert.NotNull(createdIssuer01);

                const string certificateName = "testIssuerCert01";
                const string certificateMimeType = "application/x-pkcs12";
                const string certificateSubjectName = "CN=*.microsoft.com";

                var certificateOperation = client.CreateCertificateAsync(_vaultAddress, certificateName, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    },
                    IssuerParameters = new IssuerParameters
                    {
                        Name = createdIssuer01.IssuerIdentifier.Name
                    },
                    X509CertificateProperties = new X509CertificateProperties
                    {
                        Subject = certificateSubjectName,
                        SubjectAlternativeNames = new SubjectAlternativeNames
                        {
                            DnsNames = new[]
                            {
                                "onedrive.microsoft.com",
                                "xbox.microsoft.com"
                            }
                        },
                        ValidityInMonths = 24,
                    }
                }).GetAwaiter().GetResult();

                try
                {
                    var createdCertificateBundle = PollOnCertificateOperation(client, certificateOperation);

                    Assert.NotNull(createdCertificateBundle);
                    Assert.NotNull(createdCertificateBundle.Policy);
                    Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                    Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                    Assert.NotNull(createdCertificateBundle.X509Thumbprint);

                    // Get the certificate as a secret
                    var retrievedSecret = client.GetSecretAsync(createdCertificateBundle.SecretIdentifier.Identifier).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(retrievedSecret.ContentType, certificateMimeType));

                    var retrievedCertificate = new X509Certificate2(
                        Convert.FromBase64String(retrievedSecret.Value),
                        string.Empty,
                        X509KeyStorageFlags.Exportable);

                    Assert.True(retrievedCertificate.HasPrivateKey);
                    Assert.True(0 == string.CompareOrdinal(retrievedCertificate.SubjectName.Name, certificateSubjectName));
                    Assert.True(0 == string.CompareOrdinal(retrievedCertificate.IssuerName.Name, certificateSubjectName));

                    // 24 months (ie 2 years) is 729 or 730 days. 
                    // for some reason the validity is 731 (+ some) days though
                    var validity = retrievedCertificate.NotAfter - retrievedCertificate.NotBefore;
                    Assert.True(validity >= TimeSpan.FromDays(729));
                    Assert.True(validity <= TimeSpan.FromDays(732));
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificateAsyncRequestCancellationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string issuer01Name = "issuer02";
                var issuer01 = new IssuerBundle
                {
                    Provider = "Test",
                };

                var createdIssuer01 = client.SetCertificateIssuerAsync(_vaultAddress, issuer01Name, issuer01.Provider).GetAwaiter().GetResult();
                Assert.NotNull(createdIssuer01);

                const string certificateName = "cancellationRequestedCert01";
                const string certificateMimeType = "application/x-pkcs12";
                const string certificateSubjectName = "CN=*.microsoft.com";

                var certificateOperation = client.CreateCertificateAsync(_vaultAddress, certificateName, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    },
                    IssuerParameters = new IssuerParameters
                    {
                        Name = createdIssuer01.IssuerIdentifier.Name
                    },
                    X509CertificateProperties = new X509CertificateProperties
                    {
                        Subject = certificateSubjectName,
                        SubjectAlternativeNames = new SubjectAlternativeNames
                        {
                            DnsNames = new[]
                            {
                                "onedrive.microsoft.com",
                                "xbox.microsoft.com"
                            }
                        },
                        ValidityInMonths = 24,
                    }
                }).GetAwaiter().GetResult();

                try
                {
                    Assert.NotNull(certificateOperation);
                    var cancelledCertificateOperation = client.UpdateCertificateOperationAsync(_vaultAddress, certificateName, cancellationRequested: true).GetAwaiter().GetResult();

                    Assert.NotNull(cancelledCertificateOperation);
                    Assert.True(cancelledCertificateOperation.CancellationRequested.HasValue && cancelledCertificateOperation.CancellationRequested.Value);

                    certificateOperation = client.GetCertificateOperationAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    Assert.NotNull(certificateOperation);
                    Assert.True(certificateOperation.CancellationRequested.HasValue && certificateOperation.CancellationRequested.Value);
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        public void CertificateAsyncDeleteOperationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string issuer01Name = "issuer03";
                var issuer01 = new IssuerBundle
                {
                    Provider = "Test",
                };

                var createdIssuer01 = client.SetCertificateIssuerAsync(_vaultAddress, issuer01Name, issuer01.Provider).GetAwaiter().GetResult();
                Assert.NotNull(createdIssuer01);

                const string certificateName = "deletedRequestedCert01";
                const string certificateMimeType = "application/x-pkcs12";
                const string certificateSubjectName = "CN=*.microsoft.com";

                var certificateOperation = client.CreateCertificateAsync(_vaultAddress, certificateName, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    },
                    IssuerParameters = new IssuerParameters
                    {
                        Name = createdIssuer01.IssuerIdentifier.Name
                    },
                    X509CertificateProperties = new X509CertificateProperties
                    {
                        Subject = certificateSubjectName,
                        SubjectAlternativeNames = new SubjectAlternativeNames
                        {
                            DnsNames = new[]
                            {
                                "onedrive.microsoft.com",
                                "xbox.microsoft.com"
                            }
                        },
                        ValidityInMonths = 24,
                    }
                }).GetAwaiter().GetResult();

                try
                {
                    Assert.NotNull(certificateOperation);
                    var deletedCertificateOperation = client.DeleteCertificateOperationAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(deletedCertificateOperation);

                    var exceptionThrown = false;
                    try
                    {
                        client.GetCertificateOperationAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException e)
                    {
                        if (e.Response.StatusCode == HttpStatusCode.NotFound)
                        {
                            exceptionThrown = true;
                        }
                    }

                    Assert.True(exceptionThrown);
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);

                    //verify the certificate is deleted
                    try
                    {
                        client.GetCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }
                }
            }
        }

        [Fact]
        public void CertificateUpdateTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "updateCert01";
                const string certificateContent =
                    "MIIJOwIBAzCCCPcGCSqGSIb3DQEHAaCCCOgEggjkMIII4DCCBgkGCSqGSIb3DQEHAaCCBfoEggX2MIIF8jCCBe4GCyqGSIb3DQEMCgECoIIE/jCCBPowHAYKKoZIhvcNAQwBAzAOBAj15YH9pOE58AICB9AEggTYLrI+SAru2dBZRQRlJY7XQ3LeLkah2FcRR3dATDshZ2h0IA2oBrkQIdsLyAAWZ32qYR1qkWxLHn9AqXgu27AEbOk35+pITZaiy63YYBkkpR+pDdngZt19Z0PWrGwHEq5z6BHS2GLyyN8SSOCbdzCz7blj3+7IZYoMj4WOPgOm/tQ6U44SFWek46QwN2zeA4i97v7ftNNns27ms52jqfhOvTA9c/wyfZKAY4aKJfYYUmycKjnnRl012ldS2lOkASFt+lu4QCa72IY6ePtRudPCvmzRv2pkLYS6z3cI7omT8nHP3DymNOqLbFqr5O2M1ZYaLC63Q3xt3eVvbcPh3N08D1hHkhz/KDTvkRAQpvrW8ISKmgDdmzN55Pe55xHfSWGB7gPw8sZea57IxFzWHTK2yvTslooWoosmGxanYY2IG/no3EbPOWDKjPZ4ilYJe5JJ2immlxPz+2e2EOCKpDI+7fzQcRz3PTd3BK+budZ8aXX8aW/lOgKS8WmxZoKnOJBNWeTNWQFugmktXfdPHAdxMhjUXqeGQd8wTvZ4EzQNNafovwkI7IV/ZYoa++RGofVR3ZbRSiBNF6TDj/qXFt0wN/CQnsGAmQAGNiN+D4mY7i25dtTu/Jc7OxLdhAUFpHyJpyrYWLfvOiS5WYBeEDHkiPUa/8eZSPA3MXWZR1RiuDvuNqMjct1SSwdXADTtF68l/US1ksU657+XSC+6ly1A/upz+X71+C4Ho6W0751j5ZMT6xKjGh5pee7MVuduxIzXjWIy3YSd0fIT3U0A5NLEvJ9rfkx6JiHjRLx6V1tqsrtT6BsGtmCQR1UCJPLqsKVDvAINx3cPA/CGqr5OX2BGZlAihGmN6n7gv8w4O0k0LPTAe5YefgXN3m9pE867N31GtHVZaJ/UVgDNYS2jused4rw76ZWN41akx2QN0JSeMJqHXqVz6AKfz8ICS/dFnEGyBNpXiMRxrY/QPKi/wONwqsbDxRW7vZRVKs78pBkE0ksaShlZk5GkeayDWC/7Hi/NqUFtIloK9XB3paLxo1DGu5qqaF34jZdktzkXp0uZqpp+FfKZaiovMjt8F7yHCPk+LYpRsU2Cyc9DVoDA6rIgf+uEP4jppgehsxyT0lJHax2t869R2jYdsXwYUXjgwHIV0voj7bJYPGFlFjXOp6ZW86scsHM5xfsGQoK2Fp838VT34SHE1ZXU/puM7rviREHYW72pfpgGZUILQMohuTPnd8tFtAkbrmjLDo+k9xx7HUvgoFTiNNWuq/cRjr70FKNguMMTIrid+HwfmbRoaxENWdLcOTNeascER2a+37UQolKD5ksrPJG6RdNA7O2pzp3micDYRs/+s28cCIxO//J/d4nsgHp6RTuCu4+Jm9k0YTw2Xg75b2cWKrxGnDUgyIlvNPaZTB5QbMid4x44/lE0LLi9kcPQhRgrK07OnnrMgZvVGjt1CLGhKUv7KFc3xV1r1rwKkosxnoG99oCoTQtregcX5rIMjHgkc1IdflGJkZzaWMkYVFOJ4Weynz008i4ddkske5vabZs37Lb8iggUYNBYZyGzalruBgnQyK4fz38Fae4nWYjyildVfgyo/fCePR2ovOfphx9OQJi+M9BoFmPrAg+8ARDZ+R+5yzYuEc9ZoVX7nkp7LTGB3DANBgkrBgEEAYI3EQIxADATBgkqhkiG9w0BCRUxBgQEAQAAADBXBgkqhkiG9w0BCRQxSh5IAGEAOAAwAGQAZgBmADgANgAtAGUAOQA2AGUALQA0ADIAMgA0AC0AYQBhADEAMQAtAGIAZAAxADkANABkADUAYQA2AGIANwA3MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAHQAcgBvAG4AZwAgAEMAcgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIwggLPBgkqhkiG9w0BBwagggLAMIICvAIBADCCArUGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECNX+VL2MxzzWAgIH0ICCAojmRBO+CPfVNUO0s+BVuwhOzikAGNBmQHNChmJ/pyzPbMUbx7tO63eIVSc67iERda2WCEmVwPigaVQkPaumsfp8+L6iV/BMf5RKlyRXcwh0vUdu2Qa7qadD+gFQ2kngf4Dk6vYo2/2HxayuIf6jpwe8vql4ca3ZtWXfuRix2fwgltM0bMz1g59d7x/glTfNqxNlsty0A/rWrPJjNbOPRU2XykLuc3AtlTtYsQ32Zsmu67A7UNBw6tVtkEXlFDqhavEhUEO3dvYqMY+QLxzpZhA0q44ZZ9/ex0X6QAFNK5wuWxCbupHWsgxRwKftrxyszMHsAvNoNcTlqcctee+ecNwTJQa1/MDbnhO6/qHA7cfG1qYDq8Th635vGNMW1w3sVS7l0uEvdayAsBHWTcOC2tlMa5bfHrhY8OEIqj5bN5H9RdFy8G/W239tjDu1OYjBDydiBqzBn8HG1DSj1Pjc0kd/82d4ZU0308KFTC3yGcRad0GnEH0Oi3iEJ9HbriUbfVMbXNHOF+MktWiDVqzndGMKmuJSdfTBKvGFvejAWVO5E4mgLvoaMmbchc3BO7sLeraHnJN5hvMBaLcQI38N86mUfTR8AP6AJ9c2k514KaDLclm4z6J8dMz60nUeo5D3YD09G6BavFHxSvJ8MF0Lu5zOFzEePDRFm9mH8W0N/sFlIaYfD/GWU/w44mQucjaBk95YtqOGRIj58tGDWr8iUdHwaYKGqU24zGeRae9DhFXPzZshV1ZGsBQFRaoYkyLAwdJWIXTi+c37YaC8FRSEnnNmS79Dou1Kc3BvK4EYKAD2KxjtUebrV174gD0Q+9YuJ0GXOTspBvCFd5VT2Rw5zDNrA/J3F5fMCk4wOzAfMAcGBSsOAwIaBBSxgh2xyF+88V4vAffBmZXv8Txt4AQU4O/NX4MjxSodbE7ApNAMIvrtREwCAgfQ";
                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";

                var myCertificate = new X509Certificate2(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                // Import cert
                var createdCertificateBundle = client.ImportCertificateAsync(_vaultAddress, certificateName, certificateContent, certificatePassword, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                try
                {
                    // Get the certificate bundle
                    var certificateBundleLatest = client.GetCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleLatest);
                    Assert.NotNull(certificateBundleLatest.SecretIdentifier);
                    Assert.NotNull(certificateBundleLatest.KeyIdentifier);
                    Assert.NotNull(certificateBundleLatest.X509Thumbprint);
                    Assert.NotNull(certificateBundleLatest.Policy);
                    Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                    // Update certificate bundle
                    var tags = certificateBundleLatest.Tags ?? new Dictionary<string, string>();
                    tags.Add("department", "KeyVaultTest");
                    certificateBundleLatest.Tags = tags;

                    var certificateBundleUpdatedResponse = client.UpdateCertificateAsync(
                        certificateBundleLatest.CertificateIdentifier.Identifier, null, certificateBundleLatest.Attributes, certificateBundleLatest.Tags).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleUpdatedResponse);
                    Assert.NotNull(certificateBundleUpdatedResponse.SecretIdentifier);
                    Assert.NotNull(certificateBundleUpdatedResponse.KeyIdentifier);
                    Assert.NotNull(certificateBundleUpdatedResponse.X509Thumbprint);
                    Assert.True(certificateBundleUpdatedResponse.Tags.ContainsKey("department"));
                    Assert.True(0 == string.CompareOrdinal(certificateBundleUpdatedResponse.Tags["department"], "KeyVaultTest"));
                    Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(certificateBundleUpdatedResponse.X509Thumbprint)));

                    // Get the update certificate bundle
                    var certificateBundleUpdated = client.GetCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleUpdated);
                    Assert.NotNull(certificateBundleUpdated.SecretIdentifier);
                    Assert.NotNull(certificateBundleUpdated.KeyIdentifier);
                    Assert.NotNull(certificateBundleUpdated.X509Thumbprint);
                    Assert.NotNull(certificateBundleUpdated.Policy);
                    Assert.True(certificateBundleUpdated.Tags.ContainsKey("department"));
                    Assert.True(0 == string.CompareOrdinal(certificateBundleUpdated.Tags["department"], "KeyVaultTest"));
                    Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(certificateBundleUpdated.X509Thumbprint)));
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificatePolicyTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "updateCert01";
                const string certificateContent =
                    "MIIJOwIBAzCCCPcGCSqGSIb3DQEHAaCCCOgEggjkMIII4DCCBgkGCSqGSIb3DQEHAaCCBfoEggX2MIIF8jCCBe4GCyqGSIb3DQEMCgECoIIE/jCCBPowHAYKKoZIhvcNAQwBAzAOBAj15YH9pOE58AICB9AEggTYLrI+SAru2dBZRQRlJY7XQ3LeLkah2FcRR3dATDshZ2h0IA2oBrkQIdsLyAAWZ32qYR1qkWxLHn9AqXgu27AEbOk35+pITZaiy63YYBkkpR+pDdngZt19Z0PWrGwHEq5z6BHS2GLyyN8SSOCbdzCz7blj3+7IZYoMj4WOPgOm/tQ6U44SFWek46QwN2zeA4i97v7ftNNns27ms52jqfhOvTA9c/wyfZKAY4aKJfYYUmycKjnnRl012ldS2lOkASFt+lu4QCa72IY6ePtRudPCvmzRv2pkLYS6z3cI7omT8nHP3DymNOqLbFqr5O2M1ZYaLC63Q3xt3eVvbcPh3N08D1hHkhz/KDTvkRAQpvrW8ISKmgDdmzN55Pe55xHfSWGB7gPw8sZea57IxFzWHTK2yvTslooWoosmGxanYY2IG/no3EbPOWDKjPZ4ilYJe5JJ2immlxPz+2e2EOCKpDI+7fzQcRz3PTd3BK+budZ8aXX8aW/lOgKS8WmxZoKnOJBNWeTNWQFugmktXfdPHAdxMhjUXqeGQd8wTvZ4EzQNNafovwkI7IV/ZYoa++RGofVR3ZbRSiBNF6TDj/qXFt0wN/CQnsGAmQAGNiN+D4mY7i25dtTu/Jc7OxLdhAUFpHyJpyrYWLfvOiS5WYBeEDHkiPUa/8eZSPA3MXWZR1RiuDvuNqMjct1SSwdXADTtF68l/US1ksU657+XSC+6ly1A/upz+X71+C4Ho6W0751j5ZMT6xKjGh5pee7MVuduxIzXjWIy3YSd0fIT3U0A5NLEvJ9rfkx6JiHjRLx6V1tqsrtT6BsGtmCQR1UCJPLqsKVDvAINx3cPA/CGqr5OX2BGZlAihGmN6n7gv8w4O0k0LPTAe5YefgXN3m9pE867N31GtHVZaJ/UVgDNYS2jused4rw76ZWN41akx2QN0JSeMJqHXqVz6AKfz8ICS/dFnEGyBNpXiMRxrY/QPKi/wONwqsbDxRW7vZRVKs78pBkE0ksaShlZk5GkeayDWC/7Hi/NqUFtIloK9XB3paLxo1DGu5qqaF34jZdktzkXp0uZqpp+FfKZaiovMjt8F7yHCPk+LYpRsU2Cyc9DVoDA6rIgf+uEP4jppgehsxyT0lJHax2t869R2jYdsXwYUXjgwHIV0voj7bJYPGFlFjXOp6ZW86scsHM5xfsGQoK2Fp838VT34SHE1ZXU/puM7rviREHYW72pfpgGZUILQMohuTPnd8tFtAkbrmjLDo+k9xx7HUvgoFTiNNWuq/cRjr70FKNguMMTIrid+HwfmbRoaxENWdLcOTNeascER2a+37UQolKD5ksrPJG6RdNA7O2pzp3micDYRs/+s28cCIxO//J/d4nsgHp6RTuCu4+Jm9k0YTw2Xg75b2cWKrxGnDUgyIlvNPaZTB5QbMid4x44/lE0LLi9kcPQhRgrK07OnnrMgZvVGjt1CLGhKUv7KFc3xV1r1rwKkosxnoG99oCoTQtregcX5rIMjHgkc1IdflGJkZzaWMkYVFOJ4Weynz008i4ddkske5vabZs37Lb8iggUYNBYZyGzalruBgnQyK4fz38Fae4nWYjyildVfgyo/fCePR2ovOfphx9OQJi+M9BoFmPrAg+8ARDZ+R+5yzYuEc9ZoVX7nkp7LTGB3DANBgkrBgEEAYI3EQIxADATBgkqhkiG9w0BCRUxBgQEAQAAADBXBgkqhkiG9w0BCRQxSh5IAGEAOAAwAGQAZgBmADgANgAtAGUAOQA2AGUALQA0ADIAMgA0AC0AYQBhADEAMQAtAGIAZAAxADkANABkADUAYQA2AGIANwA3MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAHQAcgBvAG4AZwAgAEMAcgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIwggLPBgkqhkiG9w0BBwagggLAMIICvAIBADCCArUGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECNX+VL2MxzzWAgIH0ICCAojmRBO+CPfVNUO0s+BVuwhOzikAGNBmQHNChmJ/pyzPbMUbx7tO63eIVSc67iERda2WCEmVwPigaVQkPaumsfp8+L6iV/BMf5RKlyRXcwh0vUdu2Qa7qadD+gFQ2kngf4Dk6vYo2/2HxayuIf6jpwe8vql4ca3ZtWXfuRix2fwgltM0bMz1g59d7x/glTfNqxNlsty0A/rWrPJjNbOPRU2XykLuc3AtlTtYsQ32Zsmu67A7UNBw6tVtkEXlFDqhavEhUEO3dvYqMY+QLxzpZhA0q44ZZ9/ex0X6QAFNK5wuWxCbupHWsgxRwKftrxyszMHsAvNoNcTlqcctee+ecNwTJQa1/MDbnhO6/qHA7cfG1qYDq8Th635vGNMW1w3sVS7l0uEvdayAsBHWTcOC2tlMa5bfHrhY8OEIqj5bN5H9RdFy8G/W239tjDu1OYjBDydiBqzBn8HG1DSj1Pjc0kd/82d4ZU0308KFTC3yGcRad0GnEH0Oi3iEJ9HbriUbfVMbXNHOF+MktWiDVqzndGMKmuJSdfTBKvGFvejAWVO5E4mgLvoaMmbchc3BO7sLeraHnJN5hvMBaLcQI38N86mUfTR8AP6AJ9c2k514KaDLclm4z6J8dMz60nUeo5D3YD09G6BavFHxSvJ8MF0Lu5zOFzEePDRFm9mH8W0N/sFlIaYfD/GWU/w44mQucjaBk95YtqOGRIj58tGDWr8iUdHwaYKGqU24zGeRae9DhFXPzZshV1ZGsBQFRaoYkyLAwdJWIXTi+c37YaC8FRSEnnNmS79Dou1Kc3BvK4EYKAD2KxjtUebrV174gD0Q+9YuJ0GXOTspBvCFd5VT2Rw5zDNrA/J3F5fMCk4wOzAfMAcGBSsOAwIaBBSxgh2xyF+88V4vAffBmZXv8Txt4AQU4O/NX4MjxSodbE7ApNAMIvrtREwCAgfQ";
                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";

                var myCertificate = new X509Certificate2(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                // Import cert
                var createdCertificateBundle = client.ImportCertificateAsync(_vaultAddress, certificateName, certificateContent, certificatePassword, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));

                try
                {
                    // Get the certificate policy
                    var certificateBundlePolicy = client.GetCertificatePolicyAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    Assert.NotNull(certificateBundlePolicy);

                    // Update certificate policy
                    certificateBundlePolicy.IssuerParameters = new IssuerParameters
                    {
                        Name = WellKnownIssuers.Self
                    };

                    var certificateBundlePolicyUpdatedResponse = client.UpdateCertificatePolicyAsync(_vaultAddress, certificateName, certificateBundlePolicy).GetAwaiter().GetResult();
                    Assert.NotNull(certificateBundlePolicyUpdatedResponse);
                    Assert.True(0 == string.CompareOrdinal(certificateBundlePolicyUpdatedResponse.IssuerParameters.Name, WellKnownIssuers.Self));

                    // Get the update certificate policy
                    var certificateBundlePolicyUpdated = client.GetCertificatePolicyAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    Assert.NotNull(certificateBundlePolicyUpdated);
                    Assert.True(0 == string.CompareOrdinal(certificateBundlePolicyUpdated.IssuerParameters.Name, WellKnownIssuers.Self));
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void CertificateContactsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // Create contacts
                var contacts = new Contacts
                {
                    ContactList = new List<Contact>
                    {
                        new Contact
                        {
                            EmailAddress = "admin@contoso.com",
                            Name = "John Doe",
                            Phone = "1111111111"
                        },
                    }
                };

                var createdContacts = client.SetCertificateContactsAsync(_vaultAddress, contacts).GetAwaiter().GetResult();
                Assert.NotNull(createdContacts);

                Assert.True(createdContacts.ContactList.Count() == 1);
                Assert.Contains(createdContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com"));
                Assert.Contains(createdContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "John Doe"));
                Assert.Contains(createdContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "1111111111"));

                try
                {
                    // Get contacts
                    var retrievedContacts = client.GetCertificateContactsAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(retrievedContacts);

                    Assert.True(retrievedContacts.ContactList.Count() == 1);
                    Assert.Contains(retrievedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com"));
                    Assert.Contains(retrievedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "John Doe"));
                    Assert.Contains(retrievedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "1111111111"));

                    // Update contacts
                    retrievedContacts.ContactList = new List<Contact>
                    {
                        new Contact
                        {
                            EmailAddress = "admin@contoso.com",
                            Name = "John Doe",
                            Phone = "1111111111"
                        },
                        new Contact
                        {
                            EmailAddress = "admin@contoso2.com",
                            Name = "Johnathan Doeman",
                            Phone = "2222222222"
                        }
                    };


                    var updatedContacts = client.SetCertificateContactsAsync(_vaultAddress, retrievedContacts).GetAwaiter().GetResult();
                    Assert.NotNull(updatedContacts);

                    Assert.True(updatedContacts.ContactList.Count() == 2);
                    Assert.Contains(updatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com"));
                    Assert.Contains(updatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "John Doe"));
                    Assert.Contains(updatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "1111111111"));

                    Assert.Contains(updatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso2.com"));
                    Assert.Contains(updatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "Johnathan Doeman"));
                    Assert.Contains(updatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "2222222222"));

                    // Retrieve updated
                    var retrievedUpdatedContacts = client.GetCertificateContactsAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(retrievedUpdatedContacts);

                    Assert.True(retrievedUpdatedContacts.ContactList.Count() == 2);
                    Assert.Contains(retrievedUpdatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com"));
                    Assert.Contains(retrievedUpdatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "John Doe"));
                    Assert.Contains(retrievedUpdatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "1111111111"));

                    Assert.Contains(retrievedUpdatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso2.com"));
                    Assert.Contains(retrievedUpdatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "Johnathan Doeman"));
                    Assert.Contains(retrievedUpdatedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "2222222222"));
                }
                finally
                {
                    // Delete contacts
                    var deletedContacts = client.DeleteCertificateContactsAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(deletedContacts);

                    Assert.True(deletedContacts.ContactList.Count() == 2);
                    Assert.Contains(deletedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com"));
                    Assert.Contains(deletedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "John Doe"));
                    Assert.Contains(deletedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "1111111111"));

                    Assert.Contains(deletedContacts.ContactList, s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso2.com"));
                    Assert.Contains(deletedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Name, "Johnathan Doeman"));
                    Assert.Contains(deletedContacts.ContactList, s => 0 == string.CompareOrdinal(s.Phone, "2222222222"));
                }
            }

        }

        [Fact]
        public void CertificateIssuersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string issuer01Name = "issuer01";
                var issuer01 = new IssuerBundle
                {
                    Provider = "Test",
                    Credentials = new IssuerCredentials
                    {
                        AccountId = "keyvaultuser",
                        Password = "password"
                    },
                    OrganizationDetails = new OrganizationDetails
                    {
                        AdminDetails = new List<AdministratorDetails>
                        {
                            new AdministratorDetails
                            {
                                FirstName = "John",
                                LastName = "Doe",
                                EmailAddress = "admin@microsoft.com",
                                Phone = "4255555555"
                            },
                        },
                    }
                };

                var createdIssuer01 = client.SetCertificateIssuerAsync(_vaultAddress, issuer01Name,
                    issuer01.Provider, issuer01.Credentials, issuer01.OrganizationDetails, issuer01.Attributes).GetAwaiter().GetResult();
                Assert.NotNull(createdIssuer01);

                var retrievedIssuer01 = client.GetCertificateIssuerAsync(_vaultAddress, issuer01Name).GetAwaiter().GetResult();
                Assert.NotNull(retrievedIssuer01);

                const string issuer02Name = "issuer02";
                var issuer02 = new IssuerBundle
                {
                    Provider = "Test",
                    Credentials = new IssuerCredentials
                    {
                        AccountId = "xboxuser",
                        Password = "security"
                    },
                    OrganizationDetails = new OrganizationDetails
                    {
                        AdminDetails = new List<AdministratorDetails>
                        {
                            new AdministratorDetails
                            {
                                FirstName = "Jane",
                                LastName = "Doe",
                                EmailAddress = "admin@microsoft.com",
                                Phone = "4256666666"
                            },
                        },
                    }
                };

                var createdIssuer02 = client.SetCertificateIssuerAsync(_vaultAddress, issuer02Name,
                    issuer01.Provider, issuer01.Credentials, issuer01.OrganizationDetails, issuer01.Attributes).GetAwaiter().GetResult();
                Assert.NotNull(createdIssuer02);

                var issuers = client.GetCertificateIssuersAsync(_vaultAddress).GetAwaiter().GetResult();
                Assert.NotNull(issuers);
                Assert.True(issuers.Count() > 1);
                Assert.Contains(issuers, i => i.Id.Contains(issuer01Name));
                Assert.Contains(issuers, i => i.Id.Contains(issuer02Name));

                var deletedIssuer01 = client.DeleteCertificateIssuerAsync(_vaultAddress, issuer01Name).GetAwaiter().GetResult();
                Assert.NotNull(deletedIssuer01);

                var deletedIssuer02 = client.DeleteCertificateIssuerAsync(_vaultAddress, issuer02Name).GetAwaiter().GetResult();
                Assert.NotNull(deletedIssuer02);

                var emptyIssuers = client.GetCertificateIssuersAsync(_vaultAddress).GetAwaiter().GetResult();
                Assert.NotNull(emptyIssuers);
                Assert.DoesNotContain(emptyIssuers, i => i.Id.Contains(issuer01Name));
                Assert.DoesNotContain(emptyIssuers, i => i.Id.Contains(issuer02Name));
            }
        }

        [Fact (Skip = "Asserts failing, need to be fixed")]
        public void CertificateCreateManualEnrolledTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "manualCert01";

                const string certificateMimeType = "application/x-pkcs12";
                const string certificateSubjectName = "CN=*.microsoft.com";

                var certificateOperation = client.CreateCertificateAsync(_vaultAddress, certificateName, new CertificatePolicy
                {
                    KeyProperties = new KeyProperties
                    {
                        Exportable = true,
                        KeySize = 2048,
                        KeyType = "RSA",
                        ReuseKey = false
                    },
                    SecretProperties = new SecretProperties
                    {
                        ContentType = certificateMimeType
                    },
                    IssuerParameters = new IssuerParameters
                    {
                        Name = WellKnownIssuers.Unknown
                    },
                    X509CertificateProperties = new X509CertificateProperties
                    {
                        Subject = certificateSubjectName,
                        SubjectAlternativeNames = new SubjectAlternativeNames
                        {
                            DnsNames = new[]
                            {
                                "onedrive.microsoft.com",
                                "xbox.microsoft.com"
                            }
                        }
                    }
                }).GetAwaiter().GetResult();

                Assert.NotNull(certificateOperation);
                Assert.NotNull(certificateOperation.Csr);

                try
                {
                    // CSR can also be obtained directly
                    var pendingVersionCsr = client.GetPendingCertificateSigningRequestAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                    Assert.True(0 == string.CompareOrdinal(pendingVersionCsr, Convert.ToBase64String(certificateOperation.Csr)));
                }
                finally
                {
                    var certificateBundleDeleted =
                        client.DeleteCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

#endregion

#region Deleted Certificate Operations

        [Fact]
        public void GetDeletedCertificateTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                // set up a cert
                const string certificateName = "getDeletedCert";
                const string certificateContent =
                    "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";
                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";
                bool recoveryLevelIsConsistent = true;

                var myCertificate = new X509Certificate2(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                // Import cert
                var keyProps = new KeyProperties
                {
                    Exportable = true,
                    KeySize = 2048,
                    KeyType = "RSA",
                    ReuseKey = false
                };
                var secretProps = new SecretProperties
                {
                    ContentType = certificateMimeType
                };
                var policy = new CertificatePolicy
                {
                    KeyProperties = keyProps,
                    SecretProperties = secretProps
                };
                var createdCertificateBundle = client.ImportCertificateAsync(
                    _vaultAddress,
                    certificateName,
                    certificateContent,
                    certificatePassword,
                    policy).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdCertificateBundle.Attributes, _softDeleteEnabled);

                // add another version 
                var attributes = new CertificateAttributes
                {
                    Enabled = true,
                };
                var updatedCertificateBundle = client.UpdateCertificateAsync(
                    createdCertificateBundle.CertificateIdentifier.BaseIdentifier,
                    certificatePolicy: policy,
                    certificateAttributes: attributes).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(updatedCertificateBundle.Attributes, _softDeleteEnabled);

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));
                Assert.NotNull(createdCertificateBundle.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);

                // soft-delete the cert
                var deletedCert = client.DeleteCertificateAsync(_vaultAddress, certificateName).ConfigureAwait(false).GetAwaiter().GetResult();
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedCert.Attributes, _softDeleteEnabled);
                this.fixture.WaitOnDeletedCertificate(client, _vaultAddress, certificateName);

                try
                {
                    // Get the deleted certificate using its recovery identifier
                    var getDeletedCertificate = client.GetDeletedCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();

                    VerifyIdsAreEqual(createdCertificateBundle.Id, getDeletedCertificate.Id);
                    VerifyIdsAreEqual(createdCertificateBundle.KeyIdentifier.Identifier, getDeletedCertificate.KeyIdentifier.Identifier);
                    VerifyIdsAreEqual(createdCertificateBundle.SecretIdentifier.Identifier, getDeletedCertificate.SecretIdentifier.Identifier);

                    VerifyIdsAreEqual(deletedCert.RecoveryId, getDeletedCertificate.RecoveryId);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(getDeletedCertificate.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnDeletedCertificate(client, _vaultAddress, certificateName);

                    // Purge the cert
                    client.PurgeDeletedCertificateAsync(_vaultAddress, certificateName).GetAwaiter().GetResult();
                }

                Assert.True(recoveryLevelIsConsistent, "The 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

        public void CertificateCreateDeleteRecoverPurgeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                // set up a cert
                string name = "CertCreateDeleteRecoverPurgeTest";
                const string certificateContent =
                    "MIIJOwIBAzCCCPcGCSqGSIb3DQEHAaCCCOgEggjkMIII4DCCBgkGCSqGSIb3DQEHAaCCBfoEggX2MIIF8jCCBe4GCyqGSIb3DQEMCgECoIIE/jCCBPowHAYKKoZIhvcNAQwBAzAOBAj15YH9pOE58AICB9AEggTYLrI+SAru2dBZRQRlJY7XQ3LeLkah2FcRR3dATDshZ2h0IA2oBrkQIdsLyAAWZ32qYR1qkWxLHn9AqXgu27AEbOk35+pITZaiy63YYBkkpR+pDdngZt19Z0PWrGwHEq5z6BHS2GLyyN8SSOCbdzCz7blj3+7IZYoMj4WOPgOm/tQ6U44SFWek46QwN2zeA4i97v7ftNNns27ms52jqfhOvTA9c/wyfZKAY4aKJfYYUmycKjnnRl012ldS2lOkASFt+lu4QCa72IY6ePtRudPCvmzRv2pkLYS6z3cI7omT8nHP3DymNOqLbFqr5O2M1ZYaLC63Q3xt3eVvbcPh3N08D1hHkhz/KDTvkRAQpvrW8ISKmgDdmzN55Pe55xHfSWGB7gPw8sZea57IxFzWHTK2yvTslooWoosmGxanYY2IG/no3EbPOWDKjPZ4ilYJe5JJ2immlxPz+2e2EOCKpDI+7fzQcRz3PTd3BK+budZ8aXX8aW/lOgKS8WmxZoKnOJBNWeTNWQFugmktXfdPHAdxMhjUXqeGQd8wTvZ4EzQNNafovwkI7IV/ZYoa++RGofVR3ZbRSiBNF6TDj/qXFt0wN/CQnsGAmQAGNiN+D4mY7i25dtTu/Jc7OxLdhAUFpHyJpyrYWLfvOiS5WYBeEDHkiPUa/8eZSPA3MXWZR1RiuDvuNqMjct1SSwdXADTtF68l/US1ksU657+XSC+6ly1A/upz+X71+C4Ho6W0751j5ZMT6xKjGh5pee7MVuduxIzXjWIy3YSd0fIT3U0A5NLEvJ9rfkx6JiHjRLx6V1tqsrtT6BsGtmCQR1UCJPLqsKVDvAINx3cPA/CGqr5OX2BGZlAihGmN6n7gv8w4O0k0LPTAe5YefgXN3m9pE867N31GtHVZaJ/UVgDNYS2jused4rw76ZWN41akx2QN0JSeMJqHXqVz6AKfz8ICS/dFnEGyBNpXiMRxrY/QPKi/wONwqsbDxRW7vZRVKs78pBkE0ksaShlZk5GkeayDWC/7Hi/NqUFtIloK9XB3paLxo1DGu5qqaF34jZdktzkXp0uZqpp+FfKZaiovMjt8F7yHCPk+LYpRsU2Cyc9DVoDA6rIgf+uEP4jppgehsxyT0lJHax2t869R2jYdsXwYUXjgwHIV0voj7bJYPGFlFjXOp6ZW86scsHM5xfsGQoK2Fp838VT34SHE1ZXU/puM7rviREHYW72pfpgGZUILQMohuTPnd8tFtAkbrmjLDo+k9xx7HUvgoFTiNNWuq/cRjr70FKNguMMTIrid+HwfmbRoaxENWdLcOTNeascER2a+37UQolKD5ksrPJG6RdNA7O2pzp3micDYRs/+s28cCIxO//J/d4nsgHp6RTuCu4+Jm9k0YTw2Xg75b2cWKrxGnDUgyIlvNPaZTB5QbMid4x44/lE0LLi9kcPQhRgrK07OnnrMgZvVGjt1CLGhKUv7KFc3xV1r1rwKkosxnoG99oCoTQtregcX5rIMjHgkc1IdflGJkZzaWMkYVFOJ4Weynz008i4ddkske5vabZs37Lb8iggUYNBYZyGzalruBgnQyK4fz38Fae4nWYjyildVfgyo/fCePR2ovOfphx9OQJi+M9BoFmPrAg+8ARDZ+R+5yzYuEc9ZoVX7nkp7LTGB3DANBgkrBgEEAYI3EQIxADATBgkqhkiG9w0BCRUxBgQEAQAAADBXBgkqhkiG9w0BCRQxSh5IAGEAOAAwAGQAZgBmADgANgAtAGUAOQA2AGUALQA0ADIAMgA0AC0AYQBhADEAMQAtAGIAZAAxADkANABkADUAYQA2AGIANwA3MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAHQAcgBvAG4AZwAgAEMAcgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIwggLPBgkqhkiG9w0BBwagggLAMIICvAIBADCCArUGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECNX+VL2MxzzWAgIH0ICCAojmRBO+CPfVNUO0s+BVuwhOzikAGNBmQHNChmJ/pyzPbMUbx7tO63eIVSc67iERda2WCEmVwPigaVQkPaumsfp8+L6iV/BMf5RKlyRXcwh0vUdu2Qa7qadD+gFQ2kngf4Dk6vYo2/2HxayuIf6jpwe8vql4ca3ZtWXfuRix2fwgltM0bMz1g59d7x/glTfNqxNlsty0A/rWrPJjNbOPRU2XykLuc3AtlTtYsQ32Zsmu67A7UNBw6tVtkEXlFDqhavEhUEO3dvYqMY+QLxzpZhA0q44ZZ9/ex0X6QAFNK5wuWxCbupHWsgxRwKftrxyszMHsAvNoNcTlqcctee+ecNwTJQa1/MDbnhO6/qHA7cfG1qYDq8Th635vGNMW1w3sVS7l0uEvdayAsBHWTcOC2tlMa5bfHrhY8OEIqj5bN5H9RdFy8G/W239tjDu1OYjBDydiBqzBn8HG1DSj1Pjc0kd/82d4ZU0308KFTC3yGcRad0GnEH0Oi3iEJ9HbriUbfVMbXNHOF+MktWiDVqzndGMKmuJSdfTBKvGFvejAWVO5E4mgLvoaMmbchc3BO7sLeraHnJN5hvMBaLcQI38N86mUfTR8AP6AJ9c2k514KaDLclm4z6J8dMz60nUeo5D3YD09G6BavFHxSvJ8MF0Lu5zOFzEePDRFm9mH8W0N/sFlIaYfD/GWU/w44mQucjaBk95YtqOGRIj58tGDWr8iUdHwaYKGqU24zGeRae9DhFXPzZshV1ZGsBQFRaoYkyLAwdJWIXTi+c37YaC8FRSEnnNmS79Dou1Kc3BvK4EYKAD2KxjtUebrV174gD0Q+9YuJ0GXOTspBvCFd5VT2Rw5zDNrA/J3F5fMCk4wOzAfMAcGBSsOAwIaBBSxgh2xyF+88V4vAffBmZXv8Txt4AQU4O/NX4MjxSodbE7ApNAMIvrtREwCAgfQ";
                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";
                bool recoveryLevelIsConsistent = true;

                var myCertificate = new X509Certificate2(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                // Import cert
                var createdCertificateBundle = client.ImportCertificateAsync(
                    _vaultAddress,
                    name,
                    certificateContent,
                    certificatePassword,
                    new CertificatePolicy
                    {
                        KeyProperties = new KeyProperties
                        {
                            Exportable = true,
                            KeySize = 2048,
                            KeyType = "RSA",
                            ReuseKey = false
                        },
                        SecretProperties = new SecretProperties
                        {
                            ContentType = certificateMimeType
                        }
                    }).GetAwaiter().GetResult();

                Assert.NotNull(createdCertificateBundle);
                Assert.NotNull(createdCertificateBundle.SecretIdentifier);
                Assert.NotNull(createdCertificateBundle.KeyIdentifier);
                Assert.NotNull(createdCertificateBundle.X509Thumbprint);
                Assert.NotNull(createdCertificateBundle.Policy);
                Assert.True(0 == string.CompareOrdinal(myCertificate.Thumbprint, ToHexString(createdCertificateBundle.X509Thumbprint)));
                Assert.NotNull(createdCertificateBundle.Cer);
                var publicCer = new X509Certificate2(createdCertificateBundle.Cer);
                Assert.NotNull(publicCer);
                Assert.False(publicCer.HasPrivateKey);
                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(createdCertificateBundle.Attributes, _softDeleteEnabled);

                try
                {
                    // Delete the certificate
                    var deletedCert = client.DeleteCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(deletedCert.Attributes, _softDeleteEnabled);

                    //verify the certificate is deleted
                    try
                    {
                        client.GetCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    this.fixture.WaitOnDeletedCertificate(client, _vaultAddress, name);

                    // Recover the certificate
                    var recoveredCert = client.RecoverDeletedCertificateAsync(deletedCert.RecoveryId).GetAwaiter().GetResult();
                    Assert.Equal(name, recoveredCert.SecretIdentifier.Name);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(recoveredCert.Attributes, _softDeleteEnabled);

                    this.fixture.WaitOnCertificate(client, _vaultAddress, name);

                    // Read the recovered certificate using full identifier
                    var recoveredReadCert = client.GetCertificateAsync(recoveredCert.Id).GetAwaiter().GetResult();
                    VerifyIdsAreEqual(recoveredReadCert.Id, recoveredCert.Id);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(recoveredReadCert.Attributes, _softDeleteEnabled);

                    // Read the recovered cert with the version independent identifier
                    recoveredReadCert = client.GetCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();
                    VerifyIdsAreEqual(recoveredReadCert.Id, recoveredCert.Id);
                    recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(recoveredReadCert.Attributes, _softDeleteEnabled);
                }
                finally
                {
                    this.fixture.WaitOnCertificate(client, _vaultAddress, name);

                    // Delete the certificate
                    var deletedCert = client.DeleteCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();

                    //verify the certificate is deleted
                    try
                    {
                        client.GetCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }

                    this.fixture.WaitOnDeletedCertificate(client, _vaultAddress, name);

                    // Purge the certificate
                    client.PurgeDeletedCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();

                    //verify the certificate is purged
                    try
                    {
                        deletedCert = client.GetDeletedCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw;
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "The 'recoveryLevel' attribute did not consistently return the expected value");
            }
        }

        [Fact]
        public void ListDeletedCertificatesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // settings may not be loaded until the client is fully initialized
                if (!_softDeleteEnabled) return;

                int numCerts = 3;
                int maxResults = 1;

                var addedObjects = new HashSet<string>();
                var removedObjects = new HashSet<string>();

                const string namePrefix = "listdeletedcerttest";
                const string certificateContent =
                    "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";
                const string certificatePassword = "123";
                const string certificateMimeType = "application/x-pkcs12";
                bool recoveryLevelIsConsistent = true;

                try
                {
                    //Create and delete the certs
                    for (int i = 0; i < numCerts; i++)
                    {
                        string name = namePrefix + i.ToString();

                        var myCertificate = new X509Certificate2(Convert.FromBase64String(certificateContent), certificatePassword, X509KeyStorageFlags.Exportable);

                        // Import cert
                        var addedCert = client.ImportCertificateAsync(
                            _vaultAddress,
                            name,
                            certificateContent,
                            certificatePassword,
                            new CertificatePolicy
                            {
                                KeyProperties = new KeyProperties
                                {
                                    Exportable = true,
                                    KeySize = 2048,
                                    KeyType = "RSA",
                                    ReuseKey = false
                                },
                                SecretProperties = new SecretProperties
                                {
                                    ContentType = certificateMimeType
                                }
                            }).GetAwaiter().GetResult();

                        addedObjects.Add(addedCert.Id.Substring(0, addedCert.Id.LastIndexOf("/")));

                        client.DeleteCertificateAsync(_vaultAddress, name).GetAwaiter().GetResult();

                        this.fixture.WaitOnDeletedCertificate(client, _vaultAddress, name);
                    }

                    //List the deleted certificates
                    var listResponse = client.GetDeletedCertificatesAsync(_vaultAddress, maxResults).GetAwaiter().GetResult();
                    Assert.NotNull(listResponse);
                    foreach (DeletedCertificateItem m in listResponse)
                    {
                        if (addedObjects.Contains(m.Id))
                        {
                            Assert.StartsWith(namePrefix, m.Identifier.Name);
                            Assert.NotNull(m.RecoveryId);
                            Assert.NotNull(m.ScheduledPurgeDate);
                            Assert.NotNull(m.DeletedDate);
                            Assert.StartsWith(namePrefix, m.RecoveryIdentifier.Name);
                            recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);

                            addedObjects.Remove(m.Id);
                            removedObjects.Add(m.RecoveryId);
                        }
                    }

                    var nextLink = listResponse.NextPageLink;
                    while (!string.IsNullOrEmpty(nextLink))
                    {
                        var listNextResponse = client.GetDeletedCertificatesNextAsync(nextLink).GetAwaiter().GetResult();
                        Assert.NotNull(listNextResponse);
                        foreach (DeletedCertificateItem m in listNextResponse)
                        {
                            if (addedObjects.Contains(m.Id))
                            {
                                Assert.StartsWith(namePrefix, m.Identifier.Name);
                                Assert.NotNull(m.RecoveryId);
                                Assert.NotNull(m.ScheduledPurgeDate);
                                Assert.NotNull(m.DeletedDate);
                                Assert.StartsWith(namePrefix, m.RecoveryIdentifier.Name);
                                recoveryLevelIsConsistent &= VerifyDeletionRecoveryLevel(m.Attributes, _softDeleteEnabled);

                                addedObjects.Remove(m.Id);
                                removedObjects.Add(m.RecoveryId);
                            }
                        }
                        nextLink = listNextResponse.NextPageLink;
                    }

                    Assert.True(addedObjects.Count == 0);
                }
                finally
                {
                    foreach (string recoveryId in removedObjects)
                    {
                        client.PurgeDeletedCertificateAsync(recoveryId).Wait();
                    }
                }

                Assert.True(recoveryLevelIsConsistent, "the 'recoveryLevel' attribute did not consistently return the expected value.");
            }
        }

#endregion

#region Storage Operations

        [Fact]
        public void StorageCreateTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "createStrg01";
                try
                {
                    CreateKvStorageAccount(client, storageAccountName);
                }
                finally
                {
                    // Delete
                    var storageBundleDeleted =
                        client.DeleteStorageAccountAsync(_vaultAddress, storageAccountName).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundleDeleted);
                }
            }
        }

        [Fact]
        public void StorageReadTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "readStrg01";
                try
                {
                    CreateKvStorageAccount(client, storageAccountName);

                    var storageBundle = client
                        .GetStorageAccountAsync(_vaultAddress, storageAccountName).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundle);
                    Assert.NotNull(storageBundle.Id);
                    Assert.NotNull(storageBundle.ActiveKeyName);
                    Assert.NotNull(storageBundle.AutoRegenerateKey);
                    Assert.NotNull(storageBundle.RegenerationPeriod);
                    Assert.Null(storageBundle.Tags);
                    Assert.True(storageBundle.Attributes.Enabled);
                }
                finally
                {
                    // Delete
                    var storageBundleDeleted =
                        client.DeleteStorageAccountAsync(_vaultAddress, storageAccountName).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundleDeleted);
                }
            }
        }

        [Fact]
        public void StorageDeleteTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "deleteStrg01";

                CreateKvStorageAccount(client, storageAccountName);

                var storageBundle = client
                    .DeleteStorageAccountAsync(_vaultAddress, storageAccountName).GetAwaiter().GetResult();

                Assert.NotNull(storageBundle);
                Assert.NotNull(storageBundle.Id);
                Assert.NotNull(storageBundle.ActiveKeyName);
                Assert.NotNull(storageBundle.AutoRegenerateKey);
                Assert.NotNull(storageBundle.RegenerationPeriod);
                Assert.Null(storageBundle.Tags);
                Assert.True(storageBundle.Attributes.Enabled);
            }
        }

        [Fact]
        public void StorageUpdateTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "updateStrg01";
                try
                {
                    CreateKvStorageAccount(client, storageAccountName);

                    var storageBundle = client
                        .UpdateStorageAccountAsync(_vaultAddress, storageAccountName, "key2", false, "P10D")
                        .GetAwaiter()
                        .GetResult();

                    Assert.NotNull(storageBundle);
                    Assert.NotNull(storageBundle.Id);
                    Assert.NotEqual("key1", storageBundle.ActiveKeyName);
                    Assert.False(storageBundle.AutoRegenerateKey);
                    Assert.Equal("P10D", storageBundle.RegenerationPeriod);
                    Assert.Null(storageBundle.Tags);
                    Assert.True(storageBundle.Attributes.Enabled);
                }
                finally
                {
                    // Delete
                    var storageBundleDeleted =
                        client.DeleteStorageAccountAsync(_vaultAddress, storageAccountName).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundleDeleted);
                }
            }
        }

        [Fact]
        public void StorageListTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();
                var addedObjects = new HashSet<string>();

                const string storageAccountName1 = "listStrg01";
                const string storageAccountName2 = "listStrg02";
                try
                {
                    var bundle01 = CreateKvStorageAccount(client, storageAccountName1);
                    addedObjects.Add(bundle01.Id);
                    var bundle02 = CreateKvStorageAccount(client, storageAccountName2, _storageResourceUrl2);
                    addedObjects.Add(bundle02.Id);

                    var listResponse = client
                        .GetStorageAccountsAsync(_vaultAddress)
                        .GetAwaiter()
                        .GetResult();

                    Assert.NotNull(listResponse);
                    foreach (StorageAccountItem m in listResponse)
                    {
                        if (addedObjects.Contains(m.Id))
                        {
                            Assert.StartsWith("listStrg", m.Identifier.Name);
                            addedObjects.Remove(m.Id);
                        }
                    }
                }
                finally
                {
                    // Delete
                    var storageBundleDeleted01 =
                        client.DeleteStorageAccountAsync(_vaultAddress, storageAccountName1).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundleDeleted01);

                    var storageBundleDeleted02 =
                        client.DeleteStorageAccountAsync(_vaultAddress, storageAccountName2).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundleDeleted02);
                }
            }
        }

        [Fact]
        public void StorageRegenerateKeyTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "regenerateKeyStrg01";
                try
                {
                    CreateKvStorageAccount(client, storageAccountName);

                    var storageBundle = client
                        .RegenerateStorageAccountKeyAsync(_vaultAddress, storageAccountName, "key2")
                        .GetAwaiter()
                        .GetResult();

                    Assert.NotNull(storageBundle);
                    Assert.NotNull(storageBundle.Id);
                    Assert.Equal("key2", storageBundle.ActiveKeyName);
                    Assert.NotNull(storageBundle.AutoRegenerateKey);
                    Assert.NotNull(storageBundle.RegenerationPeriod);
                    Assert.Null(storageBundle.Tags);
                    Assert.True(storageBundle.Attributes.Enabled);
                }
                finally
                {
                    // Delete
                    var storageBundleDeleted =
                        client.DeleteStorageAccountAsync(_vaultAddress, storageAccountName).GetAwaiter().GetResult();

                    Assert.NotNull(storageBundleDeleted);
                }
            }
        }

        public void StorageSasDefCreateTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "createsas01"; ;
                const string sasDefName = "createStrgSasDef01";

                try
                {
                    CreateKvStorageSasDef(client, storageAccountName, sasDefName);
                }
                finally
                {
                    // Delete
                    var sasDefDeleted =
                        client.DeleteSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName).GetAwaiter().GetResult();

                    Assert.NotNull(sasDefDeleted);
                }
            }
        }

        public void StorageSasDefReadTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "readsas01";
                const string sasDefName = "readStrgSasDef01";
                try
                {
                    CreateKvStorageSasDef(client, storageAccountName, sasDefName);

                    var response = client
                        .GetSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName).GetAwaiter().GetResult();

                    Assert.NotNull(response.Id);
                    Assert.NotNull(response.SecretId);
                    Assert.NotNull(response.TemplateUri);
                    Assert.NotNull(response.SasType);
                    Assert.NotNull(response.ValidityPeriod);
                    Assert.True(response.Attributes.Enabled);
                    Assert.Null(response.Tags);
                }
                finally
                {
                    // Delete
                    var sasDefDeleted =
                        client.DeleteSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName).GetAwaiter().GetResult();

                    Assert.NotNull(sasDefDeleted);
                }
            }
        }

        public void StorageSasDefDeleteTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "deletesas01";
                const string sasDefName = "deleteStrgSasDef01";

                CreateKvStorageSasDef(client, storageAccountName, sasDefName);

                var response = client
                       .DeleteSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName).GetAwaiter().GetResult();

                Assert.NotNull(response.Id);
                Assert.NotNull(response.SecretId);
                Assert.NotNull(response.TemplateUri);
                Assert.NotNull(response.SasType);
                Assert.NotNull(response.ValidityPeriod);
                Assert.True(response.Attributes.Enabled);
                Assert.Null(response.Tags);
            }
        }

        public void StorageSasDefUpdateTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();

                const string storageAccountName = "updatesas01";
                const string sasDefName = "updateStrgSasDef01";
                try
                {
                    CreateKvStorageSasDef(client, storageAccountName, sasDefName);

                    var sasType = "account";
                    var validityPeriod = "P7D";
                    var storageApiVer = "2016-05-31";
                    var templateUri = GetSasDefinitionTemplateUri(
                        blobUri: String.Format("https://{0}.blob.core.windows.net/", storageAccountName),
                        startTime: DateTime.UtcNow.ToString(),
                        expiryTime: DateTime.UtcNow.AddDays(7).ToString(),
                        resourceType: "c",  // "container"
                        permissions: "rw",  // read/write
                        storageServiceEndpoint: "b",    // "blob"
                        storageServiceVersion: storageApiVer,
                        signature: "dummySig");
                    var response = client
                        .UpdateSasDefinitionAsync(
                            _vaultAddress,
                            storageAccountName,
                            sasDefName,
                            templateUri.ToString(),
                            sasType,
                            validityPeriod,
                            new SasDefinitionAttributes(false))
                        .GetAwaiter()
                        .GetResult();

                    Assert.NotNull(response.Id);
                    Assert.NotNull(response.SecretId);
                    Assert.Equal(response.TemplateUri, templateUri.ToString());
                    Assert.False(response.Attributes.Enabled);
                    Assert.Null(response.Tags);
                }
                finally
                {
                    // Delete
                    var sasDefDeleted =
                        client.DeleteSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName)
                            .GetAwaiter()
                            .GetResult();

                    Assert.NotNull(sasDefDeleted);
                }
            }
        }

        public void StorageSasDefListTest()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultUserClient();
                var addedObjects = new HashSet<string>();

                const string storageAccountName = "listsas01";
                const string sasDefName1 = "listStrgSasDef01";
                const string sasDefName2 = "listStrgSasDef02";
                try
                {
                    var bundle01 = CreateKvStorageSasDef(client, storageAccountName, sasDefName1);
                    addedObjects.Add(bundle01.Id);
                    var bundle02 = CreateKvStorageSasDef(client, storageAccountName, sasDefName2);
                    addedObjects.Add(bundle02.Id);

                    var listResponse = client
                        .GetSasDefinitionsAsync(_vaultAddress, storageAccountName)
                        .GetAwaiter()
                        .GetResult();

                    Assert.NotNull(listResponse);
                    foreach (SasDefinitionItem m in listResponse)
                    {
                        if (addedObjects.Contains(m.Id))
                        {
                            Assert.StartsWith("listStrgSasDef", m.Identifier.Name);
                            addedObjects.Remove(m.Id);
                        }
                    }
                }
                finally
                {
                    // Delete
                    var sasDefDeleted01 =
                        client.DeleteSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName1).GetAwaiter().GetResult();

                    Assert.NotNull(sasDefDeleted01);

                    var sasDefDeleted02 =
                        client.DeleteSasDefinitionAsync(_vaultAddress, storageAccountName, sasDefName2).GetAwaiter().GetResult();

                    Assert.NotNull(sasDefDeleted02);
                }
            }
        }

#endregion

#region Helper Methods

        private static SecretAttributes NewSecretAttributes(bool enabled, bool active, bool expired)
        {
            if (!active && expired)
                throw new ArgumentException("Secret cannot be both inactive and expired; math not possible");

            var attributes = new SecretAttributes();
            attributes.Enabled = enabled;

            if (active == false)
            {
                // Set the secret to not be active for 12 hours
                attributes.NotBefore = (DateTime.UtcNow + new TimeSpan(0, 12, 0, 0));
            }

            if (expired)
            {
                // Set the secret to be expired 12 hours ago
                attributes.Expires = (DateTime.UtcNow - new TimeSpan(0, 12, 0, 0));
            }
            return attributes;
        }


        internal void EncryptDecrypt(KeyVaultClient client, KeyIdentifier keyIdentifier, string algorithm)
        {
            var plainText = RandomBytes(10);
            var encryptResult = client.EncryptAsync(keyIdentifier.BaseIdentifier, algorithm, plainText).GetAwaiter().GetResult();

            Assert.NotNull(encryptResult);
            Assert.NotNull(encryptResult.Kid);

            var decryptResult = client.DecryptAsync(encryptResult.Kid, algorithm, encryptResult.Result).GetAwaiter().GetResult();

            Assert.NotNull(decryptResult);
            Assert.NotNull(decryptResult.Kid);

            Assert.True(plainText.SequenceEqual(decryptResult.Result));
        }

        /// <summary>
        /// Wraps and unwraps symmetric key
        /// </summary>
        /// <param name="algorithm"> the wrao and unwrap algorithm </param>
        private void WrapAndUnwrap(KeyVaultClient client, KeyIdentifier keyIdentifier, string algorithm, byte[] symmetricKeyBytes)
        {

            var wrapResult = client.WrapKeyAsync(keyIdentifier.BaseIdentifier, algorithm, symmetricKeyBytes).GetAwaiter().GetResult();
            Assert.NotNull(wrapResult);
            Assert.NotNull(wrapResult.Kid);
            Assert.NotNull(wrapResult.Result);

            var unwrapResult = client.UnwrapKeyAsync(wrapResult.Kid, algorithm, wrapResult.Result).GetAwaiter().GetResult();
            Assert.NotNull(unwrapResult);
            Assert.NotNull(unwrapResult.Kid);

            Assert.True(unwrapResult.Result.SequenceEqual(symmetricKeyBytes), "the symmetric key after unwrap should match the initial key");
        }

        /// <summary>
        /// Creates a signature and verifies it
        /// </summary>
        /// <param name="keyIdentifier"> key identifier </param>
        /// <param name="algorithm"> sign algorithm </param>
        /// <param name="digest"> digest hash </param> 
        private void SignVerify(KeyVaultClient client, KeyIdentifier keyIdentifier, string algorithm, byte[] digest)
        {
            var signResult = client.SignAsync(keyIdentifier.BaseIdentifier, algorithm, digest).GetAwaiter().GetResult();
            var verifyResult = client.VerifyAsync(signResult.Kid, algorithm, digest, signResult.Result).GetAwaiter().GetResult();

            Assert.True(verifyResult, "Signature was not verified");
        }

        public static string GetKidWithoutVersion(string kid)
        {
            var uri = new Uri(kid, UriKind.Absolute);
            var result = uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);
            for (var i = 0; i < 3; i++)
            {
                result += uri.Segments[i];
            }
            result = result.Trim("/".ToCharArray());
            return result;
        }
        /// <summary>
        /// Verifies secret values are equal
        /// </summary>
        /// <param name="secretValue1"> secret value </param>
        /// <param name="secretValue2"> secret value </param>
        private void VerifySecretValuesAreEqual(string secretValue1, string secretValue2)
        {
            Assert.Equal(secretValue1, secretValue2);
        }

        /// <summary>
        /// Verifies secret values are not equal
        /// </summary>
        /// <param name="secretValue1"> secret value </param>
        /// <param name="secretValue2"> secret value </param>
        private void VerifySecretValuesAreNotEqual(string secretValue1, string secretValue2)
        {
            Assert.NotEqual(secretValue1, secretValue2);
        }

        /// <summary>
        /// Verifies IDs are equal
        /// </summary>
        /// <param name="secretId1"> ID </param>
        /// <param name="secretId2"> ID </param>
        private void VerifyIdsAreEqual(string secretId1, string secretId2)
        {
            Assert.Equal(secretId1, secretId2);
        }

        /// <summary>
        /// Verifies IDs are not equal
        /// </summary>
        /// <param name="id1"> ID </param>
        /// <param name="id2"> ID </param>
        private void VerifyIdsAreNotEqual(string id1, string id2)
        {
            Assert.NotEqual(id1, id2);
        }

        protected static byte[] RandomBytes(int length)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var bytes = new byte[length];
                Random rnd = new Random();
                rnd.NextBytes(bytes);
                HttpMockServer.Variables["RandomBytes"] = Convert.ToBase64String(bytes);
                return bytes;
            }
            else
            {
                return Convert.FromBase64String(HttpMockServer.Variables["RandomBytes"]);
            }
        }

        protected static byte[] RandomHash(HashAlgorithm hashAlgorithm, int length)
        {
            var data = RandomBytes(length);
            var hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }

        private void VerifyKeyAttributesAreEqual(KeyAttributes keyAttribute1, KeyAttributes keyAttribute2)
        {
            Assert.Equal(keyAttribute1.Expires, keyAttribute2.Expires);
            Assert.Equal(keyAttribute1.NotBefore, keyAttribute2.NotBefore);
            Assert.Equal<bool?>(keyAttribute1.Enabled ?? true, keyAttribute2.Enabled ?? true);
        }

        private void VerifySecretAttributesAreEqual(SecretAttributes leftAttributes, SecretAttributes rightAttributes)
        {
            Assert.Equal(leftAttributes.Expires, rightAttributes.Expires);
            Assert.Equal(leftAttributes.NotBefore, rightAttributes.NotBefore);
            Assert.Equal<bool?>(leftAttributes.Enabled ?? true, rightAttributes.Enabled ?? true);
        }

        private void VerifyKeyOperationsAreEqual(IList<string> firstOperations, IList<string> secondOperations)
        {
            Assert.False(firstOperations == null && secondOperations != null);
            Assert.False(firstOperations != null && secondOperations == null);
            Assert.True(firstOperations.Count == secondOperations.Count);

            Assert.True(firstOperations.All(op => secondOperations.Contains(op)));
        }

        /// <summary>
        /// Verifies web keys are equal
        /// </summary>
        /// <param name="webKey1"> first web key </param>
        /// <param name="webKey2"> second web key </param>
        private void VerifyWebKeysAreEqual(JsonWebKey webKey1, JsonWebKey webKey2)
        {
            Assert.True(webKey1.Equals(webKey2));
            Assert.Equal(webKey1.Kid, webKey2.Kid);
            Assert.Equal(webKey1.Kty, webKey2.Kty);
        }

        private void VerifyTagsAreEqual(IDictionary<string, string> expected, IDictionary<string, string> actual)
        {
            if (expected == actual) return;

            Assert.True(expected != null && actual != null);
            Assert.Equal(expected.Count, actual.Count);

            foreach (string key in expected.Keys)
            {
                Assert.Equal(expected[key], actual[key]);
            }
        }

        /// <summary>
        /// Creates a key bundle from existing key material.
        /// </summary>
        /// <param name="keyType">Key type.</param>
        /// <param name="keyToken">Key material or content description.</param>        
        /// <param name="enabled">Initial 'enabled' state.</param>
        /// <param name="notBefore">Key cannot be used before this time.</param>
        /// <param name="notAfter">Key cannot be used after this time.</param>
        /// <returns>A KeyBundle.</returns>
        protected static KeyBundle GetImportKeyBundle(string keyType, byte[] keyToken = null, bool enabled = true, int notBefore = 0, int notAfter = int.MaxValue)
        {
            return GetImportKeyBundle(new JsonWebKey { Kty = keyType, T = keyToken }, enabled, notBefore, notAfter);
        }

        /// <summary>
        /// Creates a key bundle from an existing JSON web key.
        /// </summary>
        /// <param name="key">The key to import. Must contain public and private components.</param>     
        /// <param name="enabled">Initial 'enabled' state.</param>
        /// <param name="notBefore">Key cannot be used before this time.</param>
        /// <param name="notAfter">Key cannot be used after this time.</param>
        /// <returns>A KeyBundle.</returns>
        protected static KeyBundle GetImportKeyBundle(JsonWebKey key, bool enabled = true, int notBefore = 0, int notAfter = int.MaxValue)
        {
            return new KeyBundle
            {
                Key = key,
                Attributes = new KeyAttributes()
                {
                    Enabled = enabled,
                    Expires = UnixTimeJsonConverter.EpochDate.AddSeconds(notAfter),
                    NotBefore = UnixTimeJsonConverter.EpochDate.AddSeconds(notBefore)
                },
                Tags = new Dictionary<string, string>()
                {
                    { "purpose", "unit test" }
                }
            };
        }

        private static byte[] GetSymmetricKeyBytes()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var symmetricKey = Aes.Create();
                var symmetricKeyBytes = symmetricKey.Key;
                HttpMockServer.Variables["SymmetricKeyBytes"] = Convert.ToBase64String(symmetricKeyBytes);
                return symmetricKeyBytes;
            }
            else
            {
                return Convert.FromBase64String(HttpMockServer.Variables["SymmetricKeyBytes"]);
            }
        }

        /// <summary>
        /// Converts a RSAParameters object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaParameters">The RSA parameters object to convert</param>
        /// <returns>A WebKey representing the RSA object</returns>
        private JsonWebKey CreateJsonWebKey(RSAParameters rsaParameters)
        {
            var key = new JsonWebKey
            {
                Kty = JsonWebKeyType.Rsa,
                E = rsaParameters.Exponent,
                N = rsaParameters.Modulus,
                D = rsaParameters.D,
                DP = rsaParameters.DP,
                DQ = rsaParameters.DQ,
                QI = rsaParameters.InverseQ,
                P = rsaParameters.P,
                Q = rsaParameters.Q
            };

            return key;
        }

        private CertificateBundle PollOnCertificateOperation(KeyVaultClient client, CertificateOperation pendingCertificate)
        {
            // Wait till pending is complete. We will wait for 200 seconds
            var pendingPollCount = 0;
            while (pendingPollCount < 11)
            {
                var pendingCertificateResponse = client.GetCertificateOperationAsync(_vaultAddress, pendingCertificate.CertificateOperationIdentifier.Name).GetAwaiter().GetResult();
                if (0 == string.Compare(pendingCertificateResponse.Status, "InProgress", true))
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                        Thread.Sleep(TimeSpan.FromSeconds(20));
                    pendingPollCount += 1;
                    continue;
                }

                if (0 == string.Compare(pendingCertificateResponse.Status, "Completed", true))
                {
                    return client.GetCertificateAsync(pendingCertificateResponse.Target).GetAwaiter().GetResult();
                }

                throw new Exception(string.Format(
                    CultureInfo.InvariantCulture,
                    "Polling on pending certificate returned an unexpected result. Error code = {0}, Error message = {1}",
                    pendingCertificate.Error.Code,
                    pendingCertificate.Error.Message));
            }

            throw new Exception(string.Format(
                CultureInfo.InvariantCulture,
                "Pending certificate processing delayed"));
        }

        /// <summary>
        /// Converts a byte array to a Hex encoded string
        /// </summary>
        /// <param name="input">The byte array to convert</param>
        /// <returns>The Hex encoded form of the input</returns>
        private static string ToHexString(byte[] input)
        {
            if (input == null)
                return string.Empty;

            return BitConverter.ToString(input).Replace("-", string.Empty);
        }

        /// <summary>
        /// Well known issuers
        /// </summary>
        public static class WellKnownIssuers
        {
            public const string Self = "Self";

            public const string Unknown = "Unknown";

            public static readonly string[] AllIssuers = { Self, Unknown };
        }

        private StorageBundle CreateKvStorageAccount(KeyVaultClient client, string storageAccountName)
        {
            return CreateKvStorageAccount(client, storageAccountName, _storageResourceUrl1);
        }

        private StorageBundle CreateKvStorageAccount(KeyVaultClient client, string storageAccountName, string storageUrl)
        {
            var storageBundle = client.SetStorageAccountAsync(_vaultAddress, storageAccountName, storageUrl,
                "key1", true, "P30D", new StorageAccountAttributes(true)).GetAwaiter().GetResult();

            Assert.NotNull(storageBundle);
            Assert.NotNull(storageBundle.Id);
            Assert.NotNull(storageBundle.ActiveKeyName);
            Assert.NotNull(storageBundle.AutoRegenerateKey);
            Assert.NotNull(storageBundle.RegenerationPeriod);
            Assert.Null(storageBundle.Tags);
            Assert.True(storageBundle.Attributes.Enabled);

            return storageBundle;
        }

        private SasDefinitionBundle CreateKvStorageSasDef(
            KeyVaultClient client,
            string storageAccountName,
            string sasDefName)
        {
            CreateKvStorageAccount(client, storageAccountName);

            var sasType = "account";
            var validityPeriod = "P10H";
            var storageApiVer = "2016-05-31";
            var templateUri = GetSasDefinitionTemplateUri(
                blobUri: String.Format("https://{0}.blob.core.windows.net/", storageAccountName),
                startTime: DateTime.UtcNow.ToString(),
                expiryTime: DateTime.UtcNow.AddDays(7).ToString(),
                resourceType: "c",  // "container"
                permissions: "rw",  // read/write
                storageServiceEndpoint: "bq",    // "blob"
                storageServiceVersion: storageApiVer,
                signature: "dummySig");

            var response = client.SetSasDefinitionAsync(
                _vaultAddress,
                storageAccountName,
                sasDefName,
                templateUri.ToString(),
                sasType,
                validityPeriod,
                new SasDefinitionAttributes(true))
                .GetAwaiter()
                .GetResult();

            Assert.NotNull(response.Id);
            Assert.NotNull(response.SecretId);
            Assert.Equal(response.TemplateUri, templateUri.ToString());
            Assert.True(response.Attributes.Enabled);
            Assert.Null(response.Tags);

            return response;
        }

        private class HttpClientFactory
        {
            /// <summary>
            /// Mimics the implementation of the HttpClientFactory.Create method.
            /// </summary>
            /// <param name="handlers">Delegating handlers to act as the pipeline for the client being created.</param>
            /// <returns>An http client instance with the specified delegating handlers as the inner pipeline.</returns>
            /// <remarks>
            /// * The original implementation of this class is in the System.Net.Http.Formatting assembly, which
            /// does not support .netcoreApp as a target framework. 
            /// * Since the class is private, no parameter validation is required. However, the provider
            /// of the delegating handler array must behave, and ensure there are no preset inners.
            /// </remarks>
            public static HttpClient Create(DelegatingHandler[] handlers)
            {
                for (int idx = 1; idx < handlers.Length; idx++)
                {
                    // set each previous handler as the inner of the subsequent one. 
                    // Last handler becomes the first handler in the pipeline.
                    handlers[idx].InnerHandler = handlers[idx - 1];
                }

                return new HttpClient(handlers[handlers.Length - 1]);
            }
        }

        private static bool VerifyDeletionRecoveryLevel( SecretAttributes attributes, bool isSoftDeleteEnabledVault )
        {
            return !String.IsNullOrWhiteSpace(attributes.RecoveryLevel)
                && attributes.RecoveryLevel.ToLowerInvariant().Contains(DeletionRecoveryLevel.Purgeable.ToLowerInvariant())
                && !(isSoftDeleteEnabledVault ^ attributes.RecoveryLevel.ToLowerInvariant().Contains(DeletionRecoveryLevel.Recoverable.ToLowerInvariant()));
        }

        private static bool VerifyDeletionRecoveryLevel(KeyAttributes attributes, bool isSoftDeleteEnabledVault)
        {
            return !String.IsNullOrWhiteSpace(attributes.RecoveryLevel)
                && attributes.RecoveryLevel.ToLowerInvariant().Contains(DeletionRecoveryLevel.Purgeable.ToLowerInvariant())
                && !(isSoftDeleteEnabledVault ^ attributes.RecoveryLevel.ToLowerInvariant().Contains(DeletionRecoveryLevel.Recoverable.ToLowerInvariant()));
        }

        private static bool VerifyDeletionRecoveryLevel(CertificateAttributes attributes, bool isSoftDeleteEnabledVault)
        {
            return !String.IsNullOrWhiteSpace(attributes.RecoveryLevel)
                && attributes.RecoveryLevel.ToLowerInvariant().Contains(DeletionRecoveryLevel.Purgeable.ToLowerInvariant())
                && !(isSoftDeleteEnabledVault ^ attributes.RecoveryLevel.ToLowerInvariant().Contains(DeletionRecoveryLevel.Recoverable.ToLowerInvariant()));
        }

        private static Uri GetSasDefinitionTemplateUri(string blobUri, string startTime, string expiryTime, string resourceType, string permissions, string storageServiceEndpoint, string storageServiceVersion, string signature)
        {
            StringBuilder builder = new StringBuilder(blobUri);
            builder.AppendFormat("?sv={0}", storageServiceVersion);
            builder.AppendFormat("&st={0}", startTime);
            builder.AppendFormat("&se={0}", expiryTime);
            builder.AppendFormat("&sr={0}", resourceType);
            builder.AppendFormat("&sp={0}", permissions);
            builder.AppendFormat("&ss={0}", storageServiceEndpoint);
            builder.AppendFormat("&sig={0}", signature);

            return new Uri(builder.ToString());
        }
#endregion
    }
}
