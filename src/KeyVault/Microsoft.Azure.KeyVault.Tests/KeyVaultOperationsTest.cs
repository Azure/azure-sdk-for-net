﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.KeyVault.WebKey;
using Xunit;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Globalization;
using System.Threading;
using KeyVault.TestFramework;

namespace Microsoft.Azure.KeyVault.Tests
{
    public class KeyVaultOperationsTest : IClassFixture<KeyVaultTestFixture>
    {
        private KeyVaultTestFixture fixture;

        public KeyVaultOperationsTest(KeyVaultTestFixture fixture)
        {
            this.fixture = fixture;
            _standardVaultOnly = fixture.standardVaultOnly;
            _vaultAddress = fixture.vaultAddress;
            _keyName = fixture.keyName;
            _keyVersion = fixture.keyVersion;
            _keyIdentifier = fixture.keyIdentifier;
        }

        private bool _standardVaultOnly = false;
        private string _vaultAddress = "";
        private string _keyName = "";
        private string _keyVersion = "";
        private KeyIdentifier _keyIdentifier;

        private KeyVaultClient GetKeyVaultClient()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["VaultAddress"] = _vaultAddress;
                HttpMockServer.Variables["KeyName"] = _keyName;
                HttpMockServer.Variables["KeyVersion"] = _keyVersion;
            }
            else
            {
                _vaultAddress = HttpMockServer.Variables["VaultAddress"];
                _keyName = HttpMockServer.Variables["KeyName"];
                _keyVersion = HttpMockServer.Variables["KeyVersion"];
            }
            _keyIdentifier = new KeyIdentifier(_vaultAddress, _keyName, _keyVersion);
            return fixture.CreateKeyVaultClient();
        }

        #region Key Operations
        [Fact]
        public void KeyVaultEncryptDecryptRsaOaepTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP);
            }
        }

        [Fact]
        public void KeyVaultEncryptDecryptRsa15Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSA15);
            }
        }

        [Fact]
        public void KeyVaultEncryptDecryptWithOlderKeyVersion()
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
        public void KeyVaultEncryptDecryptWithDifferentKeyVersions()
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
        public void KeyVaultSignVerifyRS256Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA256.Create(), 32);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS256, digest);
            }
        }

        [Fact]
        public void KeyVaultSignVerifyRS384Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA384.Create(), 64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS384, digest);
            }
        }

        [Fact]
        public void KeyVaultSignVerifyRS512Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                var digest = RandomHash(SHA512.Create(), 64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS512, digest);
            }
        }

        [Fact]
        public void KeyVaultWrapUnwrapRsaOaepTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP, symmetricKeyBytes);
            }
        }

        [Fact]
        public void KeyVaultWrapUnwrapRsa15Test()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSA15, symmetricKeyBytes);
            }
        }

        [Fact]
        public void KeyVaultCreateGetDeleteKeyTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

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
                }
                finally
                {
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, "CreateSoftKeyTest").GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(deletedKey.Attributes, createdKey.Attributes);
                    VerifyWebKeysAreEqual(deletedKey.Key, createdKey.Key);

                    //verify the key is deleted
                    try
                    {
                        client.GetKeyAsync(_vaultAddress, "CreateSoftKeyTest").GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw ex;
                    }
                }
            }
        }

        [Fact]
        public void KeyVaultCreateHsmKeyTest()
        {
            if (_standardVaultOnly) return;

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var attributes = new KeyAttributes();
                var createdKey = client.CreateKeyAsync(_vaultAddress, "CreateHsmKeyTest", JsonWebKeyType.RsaHsm, 2048,
                    JsonWebKeyOperation.AllOperations, attributes).GetAwaiter().GetResult();

                try
                {
                    //Trace.WriteLine("Verify generated key is as expected");
                    VerifyKeyAttributesAreEqual(attributes, createdKey.Attributes);
                    Assert.Equal(JsonWebKeyType.RsaHsm, createdKey.Key.Kty);

                    //Trace.WriteLine("Get the key");
                    var retrievedKey = client.GetKeyAsync(createdKey.Key.Kid).GetAwaiter().GetResult();
                    VerifyKeyAttributesAreEqual(attributes, retrievedKey.Attributes);
                    VerifyWebKeysAreEqual(createdKey.Key, retrievedKey.Key);

                }
                finally
                {
                    //Trace.WriteLine("Delete the key");
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, "CreateHsmKeyTest").GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(deletedKey.Attributes, createdKey.Attributes);
                    VerifyWebKeysAreEqual(deletedKey.Key, createdKey.Key);
                }
            }
        }

        [Fact]
        public void KeyVaultImportSoftKeyTest()
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

                try
                {
                    Assert.Equal(keyBundle.Key.Kty, importedKey.Key.Kty);
                    Assert.NotNull(importedKey.Attributes);
                    Assert.Equal("unit test", importedKey.Tags["purpose"]);

                    var retrievedKey = client.GetKeyAsync(importedKey.Key.Kid).GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(importedKey.Attributes, retrievedKey.Attributes);
                    VerifyWebKeysAreEqual(importedKey.Key, retrievedKey.Key);
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, "ImportSoftKeyTest").Wait();
                }
            }
        }

        [Fact]
        public void KeyVaultUpdateKeyAttributesTest()
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
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();
                }
            }
        }

        [Fact]
        public void KeyVaultUpdateKeyAttributesWithNoChangeTest()
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
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();
                }
            }
        }

        [Fact]
        public void KeyVaultBackupRestoreTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var keyName = "BackupRestoreTest";

                var attribute = new KeyAttributes()
                {
                    Enabled = false,
                    Expires = new DateTime(2030, 1, 1).ToUniversalTime(),
                    NotBefore = new DateTime(2010, 1, 1).ToUniversalTime()
                };

                var createdKey = client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attribute).GetAwaiter().GetResult();

                try
                {
                    // Restore a deleted key
                    var backupResponse = client.BackupKeyAsync(_vaultAddress, keyName).GetAwaiter().GetResult();

                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();

                    var restoredDeletedKey =
                        client.RestoreKeyAsync(_vaultAddress, backupResponse.Value).GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(restoredDeletedKey.Attributes, createdKey.Attributes);
                    Assert.Equal(restoredDeletedKey.Key.Kty, createdKey.Key.Kty);
                    Assert.Equal(createdKey.Key.Kid, restoredDeletedKey.Key.Kid);
                }
                finally
                {
                    client.DeleteKeyAsync(_vaultAddress, keyName).Wait();
                }
            }
        }

        [Fact]
        public void KeyVaultListKeysTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                int numKeys = 3;
                int maxResults = 1;

                var addedObjects = new HashSet<string>();

                //Create the keys
                for (int i = 0; i < numKeys; i++)
                {
                    string keyName = "listkeytest" + i.ToString();

                    var addedKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa).GetAwaiter().GetResult();
                    addedObjects.Add(GetKidWithoutVersion(addedKey.Key.Kid));
                }

                //List the keys
                var listResponse = client.GetKeysAsync(_vaultAddress, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (KeyItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Kid))
                    {
                        Assert.True(m.Identifier.Name.StartsWith("listkeytest"));
                        addedObjects.Remove(m.Kid);
                    }
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
                            Assert.True(m.Identifier.Name.StartsWith("listkeytest"));
                            addedObjects.Remove(m.Kid);
                        }
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }

        [Fact]
        public void KeyVaultListKeyVersionsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                int numKeys = 3;
                int maxResults = 1;

                var addedObjects = new HashSet<string>();

                string keyName = "listkeyversionstest";

                //Create the keys
                for (int i = 0; i < numKeys; i++)
                {
                    var addedKey =
                        client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa).GetAwaiter().GetResult();
                    addedObjects.Add(addedKey.Key.Kid);
                }

                //List the keys
                var listResponse = client.GetKeyVersionsAsync(_vaultAddress, keyName, maxResults).GetAwaiter().GetResult();
                Assert.NotNull(listResponse);
                foreach (KeyItem m in listResponse)
                {
                    if (addedObjects.Contains(m.Kid))
                        addedObjects.Remove(m.Kid);
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
                    }
                    nextLink = listNextResponse.NextPageLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }
        #endregion

        #region Secret Operations

        [Fact]
        public void KeyVaultSecretCreateUpdateDeleteTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                string secretName = "crpsecret";
                string originalSecretValue = "mysecretvalue";

                var originalSecret =
                    client.SetSecretAsync(_vaultAddress, secretName, originalSecretValue).GetAwaiter().GetResult();

                VerifySecretValuesAreEqual(originalSecret.Value, originalSecretValue);
                Assert.Equal(secretName, originalSecret.SecretIdentifier.Name);
                try
                {
                    // Get the original secret
                    var originalReadSecret = client.GetSecretAsync(originalSecret.Id).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(originalReadSecret.Value, originalSecret.Value);
                    VerifyIdsAreEqual(originalSecret.Id, originalReadSecret.Id);

                    // Update the secret
                    var updatedSecretValue = "mysecretvalue2";
                    var updatedSecret =
                        client.SetSecretAsync(_vaultAddress, secretName, updatedSecretValue).GetAwaiter().GetResult();
                    VerifySecretValuesAreNotEqual(originalSecret.Value, updatedSecret.Value);
                    VerifyIdsAreNotEqual(originalSecret.Id, updatedSecret.Id);

                    // Read the secret using full identifier
                    var updatedReadSecret = client.GetSecretAsync(updatedSecret.Id).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(updatedReadSecret.Value, updatedSecret.Value);
                    VerifyIdsAreEqual(updatedReadSecret.Id, updatedSecret.Id);

                    // Read the secret with the version independent identifier
                    updatedReadSecret = client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(updatedReadSecret.Value, updatedSecret.Value);
                    VerifyIdsAreEqual(updatedReadSecret.Id, updatedSecret.Id);
                }
                finally
                {
                    // Delete the secret
                    var deletedSecret = client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();

                    //verify the secret is deleted
                    try
                    {
                        client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                    }
                    catch (KeyVaultErrorException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound || ex.Body.Error.Message != ex.Message)
                            throw ex;
                    }
                }
            }
        }

        [Fact]
        public void KeyVaultGetSecretVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                var secretName = "mysecretname";
                var secretValue = "mysecretvalue";
                var secretOlder = client.SetSecretAsync(_vaultAddress, secretName, secretValue).GetAwaiter().GetResult();

                try
                {
                    // Get the latest secret using its identifier without version
                    var secretIdentifier = new SecretIdentifier(secretOlder.Id);
                    var getSecret = client.GetSecretAsync(_vaultAddress, secretIdentifier.Name).GetAwaiter().GetResult();
                    VerifySecretValuesAreEqual(getSecret.Value, secretOlder.Value);
                    VerifyIdsAreEqual(secretOlder.Id, getSecret.Id);

                    var secretNewer =
                        client.SetSecretAsync(_vaultAddress, secretName, secretValue).GetAwaiter().GetResult();

                    // Get the older secret version using its name and version
                    var getSecretOlder =
                        client.GetSecretAsync(_vaultAddress, secretIdentifier.Name, secretIdentifier.Version)
                            .GetAwaiter()
                            .GetResult();
                    VerifySecretValuesAreEqual(getSecretOlder.Value, secretOlder.Value);
                    VerifyIdsAreEqual(secretOlder.Id, getSecretOlder.Id);

                    // Get the latest secret using its identifier with version
                    var secretIdentifierNewer = new SecretIdentifier(secretNewer.Id);
                    var getSecretNewer =
                        client.GetSecretAsync(_vaultAddress, secretIdentifierNewer.Name, secretIdentifierNewer.Version)
                            .GetAwaiter()
                            .GetResult();
                    VerifySecretValuesAreEqual(getSecretNewer.Value, secretNewer.Value);
                    VerifyIdsAreEqual(secretNewer.Id, getSecretNewer.Id);
                }
                finally
                {
                    // Delete the secret
                    client.DeleteSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                }
            }
        }

        [Fact]
        public void KeyVaultListSecretsTest()
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
                        Assert.True(m.Identifier.Name.StartsWith("listsecrettest"));
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
                                Assert.True(m.Identifier.Name.StartsWith("listsecrettest"));
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
        public void KeyVaultListSecretVersionsTest()
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
        public void KeyVaultTestSecretExtendedAttributes()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var client = GetKeyVaultClient();

                string secretName = "secretwithextendedattribs";
                string originalSecretValue = "mysecretvalue";

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

                // Cannot get disabled secret
                Assert.Throws<KeyVaultErrorException>(() =>
                {
                    client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                });
            }
        }

        #endregion

        #region Certificate Operations
        [Fact]
        public void KeyVaultCertificateImportTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "importCert01";
                const string certificateContent =
                    "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";
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

                    Assert.NotNull(certificateBundleDeleted);
                }
            }
        }

        [Fact]
        public void KeyVaultCertificateImportTest2()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "importCert02";
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
        public void KeyVaultCertificateImportTest3()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "importCert03";
                const string certificateContent =
                      "MIIRoAIBAzCCEWAGCSqGSIb3DQEHAaCCEVEEghFNMIIRSTCCBhoGCSqGSIb3DQEHAaCCBgsEggYHMIIGAzCCBf8GCyqGSIb3DQEMCgECoIIE/jCCBPowHAYKKoZIhvcNAQwBAzAOBAhtIn/Rl4mXPwICB9AEggTYBKW39qNDo42n20iIYa60u9R5BwJpc9zh0F1L7xROH6EUF0jG01TJwFJ10Daz0FCmuK4Ikz+AdDB5FIGCNCWbQDau/aOwad9LkXf+HCHsLe4V6C4oMPsKzcHRkJn3YSx3K/SYKvqPlPzxbch/m7rXE8adPgmC0nHclSkPhQpsjwUx4MLoKGDyN6LVf0Hhn/Cu3yC6mMrFCnPLhXYYq39LDDRFUCvkuamm30skHJIQ3GkWwi21l6E4Wla2ZohRoZi/vag1qCJc3FPS27ftnD3e4xb5dOncS8wkhdwFoKmXCkC+cS8/h2Oy5p+gZ5SbwM8CrwwqLw6H8MQ1F+Bq78JWLLg6LapBegvIDHd6kLd24JMN+OByB1KZJZfvi11YLINrUsF+fdeAUVl4YwlCUR1s6JyekkfaL+Utt+Ryl1icVbS7wxPP3xrYBioJuvHYQWVhfmlBmRLDWRp/mjUmynuIkiJoC7UZLu/SIRQ63fAh92oPkzPCs3R9iKdnSM0sDKVC4r3cDklGl+66ctQCMtbG98elHwilSSCPFu7gpzKgoQUse5On+a8o4RHkS9vUUws5GCpw0qAHWbf3Ka2bW9KBwsai52src6GTt+rY5jqzw+nrfKPReXWWIrXQq/GBJslMzF77JPdoCugcbqpZcGadKj+cZl+KkxAi0DAe+byQhKksplPlpFljWLlhzhQlDiM7dCV/rh3RURTndZEZKV0WSGbD1W4h+nFA/2SYJ/gjkpoQvtkAH1KpVqfA6XZj2rJ0ypHi/TfViHj+UQ0e2b8mn5GbWrJjFNUM3VK+CwAEaLD+JQP6yprO1Tz0guSlgbp9bTiIU/1LfSR3+yKdSpbKwk+UE65GTtJJCkmBbIxzKqT2IUXiDQnWXz6gR3If9mbX0o92oVH/TGihJUOQXGHvgtmx9X99ll+WQAjeJCjJuEAPaof0BhmC3FBIjyAUR4eyQa3quf6bNAJDa9cmBcdxeUXGTsnLpGwGrwhxiVatwHVrOrVy8kCxYatobdYZWsEzYhDHE6LpNxQJ0zKaSwX24/7We0NdpJJQ8LE8dmgjqOYA8bS8Wrwf5Y7u51D/E+uQRzCO9JaORex13itmFIrTC8yTr7N22kZMduLywh/2qaxQRyvQN4z+gIbPpt0kCzGhN6mgkJsvK1ZYQa2/HDVHQZ1hW6HMizhl0O4ArE36RCu5xPhw9GEM66O3aYLtFdF4RGt4/xI7F5WoDVhsW1lftjMbATl/lN16qPCoJOz6fhGPPiwyPdZu49rq/zDyuDSGG+K+AgfvG4pI3gkz3sPkEhRd2SCnU9THQIqBaEfR+go/uTCDbM1JUhaD5rygIRckfAU9quRUxb33ppduiUTuQ/wzy/YQpPrAKxMAGwZjFiztsaYX/YNdH/+OKxL2htg8wlnfSL0LjOIek8bTfjZCl8trpCaVzCtIjE34zFIMO1t30Rauo5R2BsDnbPLOhu+JJjWiSQdNL8+JAwbeMVZ40XBJszsm/Zp3CFlKisQHO62+STHON8MWWaeS0HFuAkQ7oPvkjTisPxK6IpTyQUvt40SjKE5PqtTUA2QwDmNPMzmzXL9HcJO9ShqCQIZ06LuKyU1FjPUGpzaqr+eZ1Whqrg+1hrK0EVeFLqPLuq8g2/p7Rjol/sRWijGB7TATBgkqhkiG9w0BCRUxBgQEAQAAADBbBgkqhkiG9w0BCRQxTh5MAHsAMwA3AEIANQBEAEYANgBFAC0ANwBDAEYAOAAtADQAMQA3ADcALQBCADMAQwA5AC0ANgBCADMAMAA3ADQANQAzAEUAQQBBADgAfTB5BgkrBgEEAYI3EQExbB5qAE0AaQBjAHIAbwBzAG8AZgB0ACAARQBuAGgAYQBuAGMAZQBkACAAUgBTAEEAIABhAG4AZAAgAEEARQBTACAAQwByAHkAcAB0AG8AZwByAGEAcABoAGkAYwAgAFAAcgBvAHYAaQBkAGUAcjCCCycGCSqGSIb3DQEHBqCCCxgwggsUAgEAMIILDQYJKoZIhvcNAQcBMBwGCiqGSIb3DQEMAQYwDgQI+X7kACjTD90CAgfQgIIK4H9VWWQ6sOmJW5DTNp6FbcDBHvvaT0WvCvInP8p6s9pg0lm+BzxTATkpQRZb7ih+EfbkDMW6TMp0ikC4Ln4DTA3SB2xJuNsBhiLzHvfy9CHZhZ+CGgPQfG8ZNQzUJbkGH6vLdcdi0GCVffcZWfSGfp5jWGHE8DfZOihCKc2C+jEzUA32WNETwSsX0Uo+O+IJdIM6t4a+bFEwnOoV/vLCbHb+VoGewZX8n/mRNAjC6zmlOcnMYbck1XTpXOe0fg5OYqz2KpwK3laXDcyRczCR0mSXURHLgAFTlFoVPxnqoVKGn3zyVSyL696KjJ/2Kn0iauHltC+mnq5tpTJiEeN87v7KDyspm+jBSH27QevXCj0mzj/6rYJCXSUO78sZws5837NAVb26P9C1STduOXyCViBJUdcZlhrD1MVLXSgBEUm4UR1eG0hYMrII8I5KibB7WBFR6PGf289XQQPXBIQ4isth/qZT9SbT51Yo5OZM+VSrOmhIIXhzM22PfGwTUxoQteb99fgmIOQjxonD8gN2/g76tdSGO/X7ohmxjhPqMCHtyok8wy3RiCj2tQYX/EXUm5sWRc/73d1++IM7ePNzpmb9BPEVtiiC6P91a/2NGRHlRV893iRJgTc3bn2OSM6Iskqy7HSGDjAKnrwWYptU40jyrXGK8I1X6EBBqTK26ttAGkxBPU567bEts7RherkvbwkrhCI7p2Tp4+oPnIlBgY72h7mp/gDMECpsFOWjAPd9VLITj6tRpa4Bm2aDZFvDAAahS+KuwDJGjh6zKhNEtSIe4xBU5bQo8mMl3UrtNyrG9tJooCVlOfsQp0NS0NbBbbTanQ1NbdZ+kZOqChn7b+dj6fZtYZ6efMV4HX3/dq4rqWNPYx9BZBeduKggOLRMQ4Bz9xAWwVC3D7ksAtRsz4WRkJug/yn/dAMdrWxe9l++F1e/n7tPyoRKLC4eoxCKbcYUZrdmfcaQi8E3duzpL0VkV9hty4BvFw94riV8IVkXcJb7RH+zumwhKqmzb2tnkgXhBOwIyaG2x6avrrkxps7R5lxAyz4JmHbsKFJMrxhX75HI0AxLCUCpJxrQ3uXNSyrsXUo7tpc4Q1DYDUaKfZ3KfBh8CKD3OHcPCyPrwzSS/ZYUUq5hxNJpMTKb4B2HZSHZ6t2driPb+t0pP1khoUKYmf0Z4MJd98lOAbmB55udVDAkbhWVHplB/tU7sHMQd2XmI5ee3+x7ItvsqUZ1xf7mWjM07/HqLCdmlJVQPNtZLxwMtHxaxj0lTpBlhuO91t2XBjrRaZDES1HGNxPtMoX7Tq/yzIFmPl/YnS2QfUR6wwQzoYpKX1p/+E2faywscdOtdoURg/xbIbWALDN61heN8iI3vbMxD7vhaauEWbBSMgplKZntFH0HCbP75TuJWr2nCTsn37dql4CVEim2ITRGDwvlb0O3z37PszJCecI2BOLNAnGjkiGu1qnsrjthltBqxdXkXNtBuX5YQeyoU0I/MeKWJSy/t231Es4iBHsQ2vxdKILi0l//OUDIixc+/eCf2+cVDhcEEzB0KRNziO6b9by9/Man+ZJBxWfQkpTExx8YzmGrftffTLb3qFA7Hd4mHAV3exIL6w5LAJBRr7MwP9V/XlGDgKwaMH8iHidzAkCz5U/AH2gTItGljm/AJgaSl45nwLd4i93Hh10Z/dl5KbGZ62aF7agz0ykYWTdtWyILm1fdI3IpHYsCphiIoFDvKAfktJss1PfNst5iemsCkgzULrb1XBYFyCWTE4pZBAbeU2FpWbZWGyBjNDuofsN4l9RyRBGHFgip+ZgQ1INpvxO9SyLZ+RnG2FL7EewNWD5DepSIDIoQxF/ZRGHtEpOI8oW7beR/lEg6yuycwa7S+PxxoMqKJCyrg7xOjiwpQQBgGmdy0UO/9r4ehn9JmKFqevMQwN7iA+kcSuSx7ZBrmGM+uNDnnuN0/R3XQ/JQfF/lXt4AxaRCZtY5wc9gpwiyZeVvs/67TqBgqijCpO3qOsDMi9zDqUBpFkUOGF/FAm+bz0ouzjgJGK7K0UzBY/sB306qEc3cQiJuU4GDmCM9rs4IeoGG1h4Uy0YZHiEa7rkOr0L5G1Evx5y5wgHZCcmTjqYzGeSOqqoQlXsuiet++jAhCsa3h6bB0YTF7SaBKOeOnY6omioTxvYXoQHKnhdMZs93iKZpJ2W/4cE6D/w3XbgBaeL/D6uHdLpVip9r6VW3LYcvAhVDuygGWez1h6+vin0E1v2nW86CTjX0w+0JNZBez2s1j9SzbUz/lfZMmduQgSHhC92gBfqANhheQvwpTPV2/H1dI6YqD9kHHyquXyuY7cyJ8mmb4j7aM9fGiiwUDf+AJXnUYc7WRLex84xUHHtfArVBsN4akgaGjqgZDybpQAquZcxq5oaF0MBQkd6H3GxQA6p1M1QnoUqQzmchN2oMeaSdE9a0HhHAt3oci4pgyOeFvykrolsZu13boQ3/uyUHarVfF+QoMkKm0QvKuZr0jglwqlVaiXyWBUwN8fCpb3zo8FnY897friBIk5HcaiJiM7B25v46jbImd546ajlPSD+xxUWBmAxFYYebeGE1t/+rYUd4ZcMKaQUD8mhc6iA25ppY5N94+gbvLRl1OixUDPKQohRbvhZhYgpfiQQKWUnJS5fI1plXdVBrcDBzgfBbWBfrSr4tuJTqNGtylMAZPEJOJQYo47JWH9Wate44sM1y6+qVodw6geqDcYltiVxhFP3XYUBOtY9V34WLUxjfu3zapm+Ugnf46sZgU0yg91Lq9BupRDBWpZ/Qb4q//toXXYfeUyAG0G5wgbgqRKyA2RiGljiLOB0VaEbpr3ShBql5Ih67gmCcYlvv05WPA4kL6NMOcK9r46BexTI/7EALNZM5xV9B/jcsckDy2QZ+rMUc4IlAzBQ9exytLwzFanRqKnihuQmcYNJHDbHbYwO2S6h7HWZhVd/9J+ljKWj7pcSQdroiqzzUD8mKpuXbRnAbrsaksDfbEu0S+VmlWY7Q70H1M7V9cEwHt1CdSm95dDQVGJ2DrotPc3LXesw9UH+BmLRc2pSBojI2s5Ojv6yJW1IF6XzwA3b9BJvi5QtKuOL4Wy4u7yue8VtSkW1fqMdq6z5gDe6S6G6msYVPjofdG0/vBoZDxGz0uQ3wsTwes36IuQk9NrAo6ghPs4Yhe3S4rLk1PlVU0PBhnGlWY6PcSfg14PxFclfcR5zW9vazXE3tbzDeHaD7ZHuL2AtQ35PtSCjEqxvz/kXwd15BOvfY6JLxiQ7S3PKR+TYArkcPzRvJBXBkncdm7OC+yYK8RnswVgiG1aENLJnEJW1sMHs8ljOdb/B+m61nfSl5gCc8PyE4wfsdkZtKgxKj9gCkD3HE6C5qM0PThXvvPMKtJk3ol+MuPE1Fz7tGMhpotk0mjFMy6/TY5VtPx69636hxBk2z0zzVtHguRMHtzaKqkRqkWlb/z0wAInI2nBr/44achdUnmOV9CEga3OmSFhfPHD7G0xhKA5kg4vLu9XD/Oru70R7qpaRUzz+qJZ4KGiuGXCgOs6iFkLytBBkc7uF/hmBflF+bhfrOb7hPEEyA5trfJVUoPcDWckJzCq0U5AnpwsXeuNoEKcsKqnA9sqXLEHio/oRDrHHT9uX45s8g6Go5MQfn2Si6JtcfHKMToxJrGy2L1YB8J/jB5SrvHbshEG76n5FnBS/87P3mRTA3MB8wBwYFKw4DAhoEFFf3LCdTrWWjzuc86/lNx3oF4B9xBBRFHJ6spK47q/5FkYCXwwUyuX0eQg==";

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
        public void KeyVaultCertificateListTest()
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
                    Assert.True(certList.Any(s => 0 == string.CompareOrdinal(ToHexString(s.X509Thumbprint), ToHexString(createdCertificateBundle01.X509Thumbprint))));
                    Assert.True(certList.Any(s => 0 == string.CompareOrdinal(ToHexString(s.X509Thumbprint), ToHexString(createdCertificateBundle02.X509Thumbprint))));
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
        public void KeyVaultCertificateListVersionsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                // Create two certificates
                const string certificateName = "listVersionsCert01";
                const string certificate01Content =
                    "MIIJOwIBAzCCCPcGCSqGSIb3DQEHAaCCCOgEggjkMIII4DCCBgkGCSqGSIb3DQEHAaCCBfoEggX2MIIF8jCCBe4GCyqGSIb3DQEMCgECoIIE/jCCBPowHAYKKoZIhvcNAQwBAzAOBAj15YH9pOE58AICB9AEggTYLrI+SAru2dBZRQRlJY7XQ3LeLkah2FcRR3dATDshZ2h0IA2oBrkQIdsLyAAWZ32qYR1qkWxLHn9AqXgu27AEbOk35+pITZaiy63YYBkkpR+pDdngZt19Z0PWrGwHEq5z6BHS2GLyyN8SSOCbdzCz7blj3+7IZYoMj4WOPgOm/tQ6U44SFWek46QwN2zeA4i97v7ftNNns27ms52jqfhOvTA9c/wyfZKAY4aKJfYYUmycKjnnRl012ldS2lOkASFt+lu4QCa72IY6ePtRudPCvmzRv2pkLYS6z3cI7omT8nHP3DymNOqLbFqr5O2M1ZYaLC63Q3xt3eVvbcPh3N08D1hHkhz/KDTvkRAQpvrW8ISKmgDdmzN55Pe55xHfSWGB7gPw8sZea57IxFzWHTK2yvTslooWoosmGxanYY2IG/no3EbPOWDKjPZ4ilYJe5JJ2immlxPz+2e2EOCKpDI+7fzQcRz3PTd3BK+budZ8aXX8aW/lOgKS8WmxZoKnOJBNWeTNWQFugmktXfdPHAdxMhjUXqeGQd8wTvZ4EzQNNafovwkI7IV/ZYoa++RGofVR3ZbRSiBNF6TDj/qXFt0wN/CQnsGAmQAGNiN+D4mY7i25dtTu/Jc7OxLdhAUFpHyJpyrYWLfvOiS5WYBeEDHkiPUa/8eZSPA3MXWZR1RiuDvuNqMjct1SSwdXADTtF68l/US1ksU657+XSC+6ly1A/upz+X71+C4Ho6W0751j5ZMT6xKjGh5pee7MVuduxIzXjWIy3YSd0fIT3U0A5NLEvJ9rfkx6JiHjRLx6V1tqsrtT6BsGtmCQR1UCJPLqsKVDvAINx3cPA/CGqr5OX2BGZlAihGmN6n7gv8w4O0k0LPTAe5YefgXN3m9pE867N31GtHVZaJ/UVgDNYS2jused4rw76ZWN41akx2QN0JSeMJqHXqVz6AKfz8ICS/dFnEGyBNpXiMRxrY/QPKi/wONwqsbDxRW7vZRVKs78pBkE0ksaShlZk5GkeayDWC/7Hi/NqUFtIloK9XB3paLxo1DGu5qqaF34jZdktzkXp0uZqpp+FfKZaiovMjt8F7yHCPk+LYpRsU2Cyc9DVoDA6rIgf+uEP4jppgehsxyT0lJHax2t869R2jYdsXwYUXjgwHIV0voj7bJYPGFlFjXOp6ZW86scsHM5xfsGQoK2Fp838VT34SHE1ZXU/puM7rviREHYW72pfpgGZUILQMohuTPnd8tFtAkbrmjLDo+k9xx7HUvgoFTiNNWuq/cRjr70FKNguMMTIrid+HwfmbRoaxENWdLcOTNeascER2a+37UQolKD5ksrPJG6RdNA7O2pzp3micDYRs/+s28cCIxO//J/d4nsgHp6RTuCu4+Jm9k0YTw2Xg75b2cWKrxGnDUgyIlvNPaZTB5QbMid4x44/lE0LLi9kcPQhRgrK07OnnrMgZvVGjt1CLGhKUv7KFc3xV1r1rwKkosxnoG99oCoTQtregcX5rIMjHgkc1IdflGJkZzaWMkYVFOJ4Weynz008i4ddkske5vabZs37Lb8iggUYNBYZyGzalruBgnQyK4fz38Fae4nWYjyildVfgyo/fCePR2ovOfphx9OQJi+M9BoFmPrAg+8ARDZ+R+5yzYuEc9ZoVX7nkp7LTGB3DANBgkrBgEEAYI3EQIxADATBgkqhkiG9w0BCRUxBgQEAQAAADBXBgkqhkiG9w0BCRQxSh5IAGEAOAAwAGQAZgBmADgANgAtAGUAOQA2AGUALQA0ADIAMgA0AC0AYQBhADEAMQAtAGIAZAAxADkANABkADUAYQA2AGIANwA3MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAHQAcgBvAG4AZwAgAEMAcgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIwggLPBgkqhkiG9w0BBwagggLAMIICvAIBADCCArUGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECNX+VL2MxzzWAgIH0ICCAojmRBO+CPfVNUO0s+BVuwhOzikAGNBmQHNChmJ/pyzPbMUbx7tO63eIVSc67iERda2WCEmVwPigaVQkPaumsfp8+L6iV/BMf5RKlyRXcwh0vUdu2Qa7qadD+gFQ2kngf4Dk6vYo2/2HxayuIf6jpwe8vql4ca3ZtWXfuRix2fwgltM0bMz1g59d7x/glTfNqxNlsty0A/rWrPJjNbOPRU2XykLuc3AtlTtYsQ32Zsmu67A7UNBw6tVtkEXlFDqhavEhUEO3dvYqMY+QLxzpZhA0q44ZZ9/ex0X6QAFNK5wuWxCbupHWsgxRwKftrxyszMHsAvNoNcTlqcctee+ecNwTJQa1/MDbnhO6/qHA7cfG1qYDq8Th635vGNMW1w3sVS7l0uEvdayAsBHWTcOC2tlMa5bfHrhY8OEIqj5bN5H9RdFy8G/W239tjDu1OYjBDydiBqzBn8HG1DSj1Pjc0kd/82d4ZU0308KFTC3yGcRad0GnEH0Oi3iEJ9HbriUbfVMbXNHOF+MktWiDVqzndGMKmuJSdfTBKvGFvejAWVO5E4mgLvoaMmbchc3BO7sLeraHnJN5hvMBaLcQI38N86mUfTR8AP6AJ9c2k514KaDLclm4z6J8dMz60nUeo5D3YD09G6BavFHxSvJ8MF0Lu5zOFzEePDRFm9mH8W0N/sFlIaYfD/GWU/w44mQucjaBk95YtqOGRIj58tGDWr8iUdHwaYKGqU24zGeRae9DhFXPzZshV1ZGsBQFRaoYkyLAwdJWIXTi+c37YaC8FRSEnnNmS79Dou1Kc3BvK4EYKAD2KxjtUebrV174gD0Q+9YuJ0GXOTspBvCFd5VT2Rw5zDNrA/J3F5fMCk4wOzAfMAcGBSsOAwIaBBSxgh2xyF+88V4vAffBmZXv8Txt4AQU4O/NX4MjxSodbE7ApNAMIvrtREwCAgfQ";
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
                    Assert.True(certList.Any(s => s.X509Thumbprint.SequenceEqual(createdCertificateBundle01.X509Thumbprint)));
                    Assert.True(certList.Any(s => s.X509Thumbprint.SequenceEqual(createdCertificateBundle02.X509Thumbprint)));
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
        public void KeyVaultCertificateCreateSelfSignedTest()
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
        public void KeyVaultCertificateCreateLongSelfSignedTest()
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
        public void KeyVaultCertificateCreateTestIssuerTest()
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
        public void KeyVaultCertificateAsyncRequestCancellationTest()
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
                    var cancelledCertificateOperation = client.UpdateCertificateOperationAsync(_vaultAddress, certificateName, cancellationRequested : true).GetAwaiter().GetResult();

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

        [Fact]
        public void KeyVaultCertificateAsyncDeleteOperationTest()
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
                            throw ex;
                    }
                }
            }
        }

        [Fact]
        public void KeyVaultCertificateUpdateTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "updateCert01";
                const string certificateContent =
                    "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";
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
        public void KeyVaultCertificatePolicyTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetKeyVaultClient();

                const string certificateName = "updateCert01";
                const string certificateContent =
                    "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";
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
        public void KeyVaultCertificateContactsTest()
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
                Assert.True(createdContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com")));
                Assert.True(createdContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "John Doe")));
                Assert.True(createdContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "1111111111")));

                try
                {
                    // Get contacts
                    var retrievedContacts = client.GetCertificateContactsAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(retrievedContacts);

                    Assert.True(retrievedContacts.ContactList.Count() == 1);
                    Assert.True(retrievedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com")));
                    Assert.True(retrievedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "John Doe")));
                    Assert.True(retrievedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "1111111111")));

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
                    Assert.True(updatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com")));
                    Assert.True(updatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "John Doe")));
                    Assert.True(updatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "1111111111")));

                    Assert.True(updatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso2.com")));
                    Assert.True(updatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "Johnathan Doeman")));
                    Assert.True(updatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "2222222222")));

                    // Retrieve updated
                    var retrievedUpdatedContacts = client.GetCertificateContactsAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(retrievedUpdatedContacts);

                    Assert.True(retrievedUpdatedContacts.ContactList.Count() == 2);
                    Assert.True(retrievedUpdatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com")));
                    Assert.True(retrievedUpdatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "John Doe")));
                    Assert.True(retrievedUpdatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "1111111111")));

                    Assert.True(retrievedUpdatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso2.com")));
                    Assert.True(retrievedUpdatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "Johnathan Doeman")));
                    Assert.True(retrievedUpdatedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "2222222222")));
                }
                finally
                {
                    // Delete contacts
                    var deletedContacts = client.DeleteCertificateContactsAsync(_vaultAddress).GetAwaiter().GetResult();
                    Assert.NotNull(deletedContacts);

                    Assert.True(deletedContacts.ContactList.Count() == 2);
                    Assert.True(deletedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso.com")));
                    Assert.True(deletedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "John Doe")));
                    Assert.True(deletedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "1111111111")));

                    Assert.True(deletedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.EmailAddress, "admin@contoso2.com")));
                    Assert.True(deletedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Name, "Johnathan Doeman")));
                    Assert.True(deletedContacts.ContactList.Any(s => 0 == string.CompareOrdinal(s.Phone, "2222222222")));
                }
            }

        }

        [Fact]
        public void KeyVaultCertificateIssuersTest()
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
                Assert.True(issuers.Any(i => i.Id.Contains(issuer01Name)));
                Assert.True(issuers.Any(i => i.Id.Contains(issuer02Name)));

                var deletedIssuer01 = client.DeleteCertificateIssuerAsync(_vaultAddress, issuer01Name).GetAwaiter().GetResult();
                Assert.NotNull(deletedIssuer01);

                var deletedIssuer02 = client.DeleteCertificateIssuerAsync(_vaultAddress, issuer02Name).GetAwaiter().GetResult();
                Assert.NotNull(deletedIssuer02);

                var emptyIssuers = client.GetCertificateIssuersAsync(_vaultAddress).GetAwaiter().GetResult();
                Assert.NotNull(emptyIssuers);
                Assert.False(emptyIssuers.Any(i => i.Id.Contains(issuer01Name)));
                Assert.False(emptyIssuers.Any(i => i.Id.Contains(issuer02Name)));
            }
        }

        [Fact]
        public void KeyVaultCertificateCreateManualEnrolledTest()
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


        public void EncryptDecrypt(KeyVaultClient client, KeyIdentifier keyIdentifier, string algorithm)
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

        private void ListSecrets(int secrets, int? maxResults)
        {

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
                    if(HttpMockServer.Mode == HttpRecorderMode.Record)
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

        #endregion

    }
}
