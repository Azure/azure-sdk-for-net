//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Internal;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.KeyVault.WebKey;
using Xunit;

namespace KeyVault.Tests
{
    public class KeyVaultOperationsTest : TestBase, IUseFixture<KeyVaultTestFixture>
    {
        public void SetFixture(KeyVaultTestFixture data)
        {            
            data.Initialize(TestUtilities.GetCallingClass());
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                // SECURITY: DO NOT USE IN PRODUCTION CODE; FOR TEST PURPOSES ONLY
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                this._credential = data._ClientCredential;
                this._tokenCache = new TokenCache();
                this._vaultAddress = data.vaultAddress;
                this._standardVaultOnly = data.standardVaultOnly;

                //Create one key to use for testing. Key creation is expensive.
                var myClient = CreateKeyVaultClient();
                var keyName = "sdktestkey";
                var attributes = new KeyAttributes();
                var createdKey = myClient.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attributes).GetAwaiter().GetResult();
                var keyIdentifier = new KeyIdentifier(createdKey.Key.Kid);

                _keyName = keyIdentifier.Name;
                _keyVersion = keyIdentifier.Version;

                _keyIdentifier = new KeyIdentifier(_vaultAddress, _keyName, _keyVersion);
            }            
        }        

        private string _vaultAddress = "";
        private bool _standardVaultOnly = false;
        private ClientCredential _credential;
        private TokenCache _tokenCache;
        private string _keyName = "";
        private string _keyVersion = "";
        private KeyIdentifier _keyIdentifier = null;
        

        private DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            var handler = new TestHttpMessageHandler();
            return new DelegatingHandler[] {server, handler};
        }

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
            return CreateKeyVaultClient();
        }

        private KeyVaultClient CreateKeyVaultClient()
        {
            var myclient = new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
            return myclient;
        }

        #region Key Operations
        [Fact]
        public void KeyVaultEncryptDecryptRsaOaepTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP);
            }
        }

        [Fact]
        public void KeyVaultEncryptDecryptRsa15Test()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                EncryptDecrypt(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSA15);
            }
        }

        [Fact]
        public void KeyVaultEncryptDecryptWithOlderKeyVersion()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var algorithm = JsonWebKeyEncryptionAlgorithm.RSA15;                

                // Create a newer version of the current software key
                var newVersionKey =
                    client.CreateKeyAsync(_vaultAddress, _keyName, JsonWebKeyType.Rsa,
                        key_ops: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                // Use the older version of the software key to do encryption and decryption operation
                EncryptDecrypt(client, _keyIdentifier, algorithm);
            }
        }

        [Fact]
        public void KeyVaultEncryptDecryptWithDifferentKeyVersions()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var algorithm = JsonWebKeyEncryptionAlgorithm.RSA15;

                // Create a newer version of the current software key
                var newVersionKey =
                    client.CreateKeyAsync(_vaultAddress, _keyName, JsonWebKeyType.Rsa,
                        key_ops: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                var plainText = RandomBytes(10);
                var encryptResult = client.EncryptAsync(newVersionKey.Key.Kid, algorithm, plainText).GetAwaiter().GetResult();

                Assert.Throws<KeyVaultClientException>(()=>
                    client.DecryptAsync(_keyIdentifier.Identifier, algorithm, encryptResult.Result).GetAwaiter().GetResult());
            }
        }

        [Fact]
        public void KeyVaultSignVerifyRS256Test()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var digest = RandomHash<SHA256CryptoServiceProvider>(32);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS256, digest);
            }
        }

        [Fact]
        public void KeyVaultSignVerifyRS384Test()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var digest = RandomHash<SHA384CryptoServiceProvider>(64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS384, digest);
            }
        }

        [Fact]
        public void KeyVaultSignVerifyRS512Test()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var digest = RandomHash<SHA512CryptoServiceProvider>(64);

                SignVerify(client, _keyIdentifier, JsonWebKeySignatureAlgorithm.RS512, digest);
            }
        }

        [Fact]
        public void KeyVaultWrapUnwrapRsaOaepTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSAOAEP, symmetricKeyBytes);
            }
        }

        [Fact]
        public void KeyVaultWrapUnwrapRsa15Test()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var symmetricKeyBytes = GetSymmetricKeyBytes();
                WrapAndUnwrap(client, _keyIdentifier, JsonWebKeyEncryptionAlgorithm.RSA15, symmetricKeyBytes);
            }
        } 

        [Fact]
        public void KeyVaultCreateGetDeleteKeyTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var attributes = new KeyAttributes();
                var tags = new Dictionary<string, string>() {{"purpose", "unit test"}, {"test name ", "CreateGetDeleteKeyTest"}};
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
                }
            }
        }

        [Fact]
        public void KeyVaultCreateHsmKeyTest()
        {
            if (_standardVaultOnly) return;

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var attributes = new KeyAttributes();
                var createdKey = client.CreateKeyAsync(_vaultAddress, "CreateHsmKeyTest", JsonWebKeyType.RsaHsm, 2048,
                    JsonWebKeyOperation.AllOperations, attributes).GetAwaiter().GetResult();

                try
                {
                    Trace.WriteLine("Verify generated key is as expected");
                    VerifyKeyAttributesAreEqual(attributes, createdKey.Attributes);
                    Assert.Equal(JsonWebKeyType.RsaHsm, createdKey.Key.Kty);

                    Trace.WriteLine("Get the key");
                    var retrievedKey = client.GetKeyAsync(createdKey.Key.Kid).GetAwaiter().GetResult();
                    VerifyKeyAttributesAreEqual(attributes, retrievedKey.Attributes);
                    VerifyWebKeysAreEqual(createdKey.Key, retrievedKey.Key);

                }
                finally
                {
                    Trace.WriteLine("Delete the key");
                    var deletedKey = client.DeleteKeyAsync(_vaultAddress, "CreateHsmKeyTest").GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(deletedKey.Attributes, createdKey.Attributes);
                    VerifyWebKeysAreEqual(deletedKey.Key, createdKey.Key);
                }
            }
        }

        //[Fact]
        public void KeyVaultImportHsmByoKeyTest()
        {
            if (_standardVaultOnly) return;

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                var request = GetImportKeyBundle(keyType: JsonWebKeyType.RsaHsm, keyToken: Resource.Key);

                var importedKey =
                    client.ImportKeyAsync(_vaultAddress, "ImportHsmKeyTest", request).GetAwaiter().GetResult();

                VerifyKeyAttributesAreEqual(request.Attributes, importedKey.Attributes);
                Assert.Equal(request.Key.Kty, importedKey.Key.Kty);

                var retrievedKey = client.GetKeyAsync(importedKey.Key.Kid).GetAwaiter().GetResult();

                // Delete the key
                var identifier = new KeyIdentifier(importedKey.Key.Kid);
                client.DeleteKeyAsync(identifier.Vault, identifier.Name).Wait();

                VerifyKeyAttributesAreEqual(importedKey.Attributes, retrievedKey.Attributes);
                VerifyWebKeysAreEqual(importedKey.Key, retrievedKey.Key);
            }
        }

        [Fact]
        public void KeyVaultImportSoftKeyTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                // Generates a new RSA key.
                var rsa = new RSACryptoServiceProvider(2048);
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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                    attributes.NotBefore = new DateTime(1980, 1, 1).ToUniversalTime();
                    attributes.Expires = new DateTime(1981, 1, 1).ToUniversalTime();

                    var updatedKey =
                        client.UpdateKeyAsync(_vaultAddress, keyName, operations, attributes)
                            .GetAwaiter()
                            .GetResult();

                    VerifyKeyAttributesAreEqual(updatedKey.Attributes, attributes);
                    VerifyKeyOperationsAreEqual(updatedKey.Key.KeyOps, operations);
                    VerifyWebKeysAreEqual(updatedKey.Key, createdKey.Key);

                    // Create a new version of the key
                    var newkeyVersion = client.CreateKeyAsync(_vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                        JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();

                    // Update the original version
                    attributes.Enabled = false;
                    attributes.NotBefore = new DateTime(1990, 1, 1).ToUniversalTime();
                    attributes.Expires = new DateTime(1991, 1, 1).ToUniversalTime();

                    updatedKey =
                        client.UpdateKeyAsync(createdKey.Key.Kid, operations, attributes).GetAwaiter().GetResult();

                    VerifyKeyAttributesAreEqual(updatedKey.Attributes, attributes);
                    VerifyKeyOperationsAreEqual(updatedKey.Key.KeyOps, operations);
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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                        client.RestoreKeyAsync(_vaultAddress, backupResponse).GetAwaiter().GetResult();

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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                foreach (KeyItem m in listResponse.Value)
                {
                    if (addedObjects.Contains(m.Kid))
                    {
                        Assert.True(m.Identifier.Name.StartsWith("listkeytest"));
                        addedObjects.Remove(m.Kid);
                    }
                }

                var nextLink = listResponse.NextLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetKeysNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (KeyItem m in listNextResponse.Value)
                    {
                        if (addedObjects.Contains(m.Kid))
                        {
                            Assert.True(m.Identifier.Name.StartsWith("listkeytest"));
                            addedObjects.Remove(m.Kid);
                        }
                    }
                    nextLink = listNextResponse.NextLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }

        [Fact]
        public void KeyVaultListKeyVersionsTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                foreach (KeyItem m in listResponse.Value)
                {
                    if (addedObjects.Contains(m.Kid))
                        addedObjects.Remove(m.Kid);
                }

                var nextLink = listResponse.NextLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetKeyVersionsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (KeyItem m in listNextResponse.Value)
                    {
                        if (addedObjects.Contains(m.Kid))
                            addedObjects.Remove(m.Kid);
                    }
                    nextLink = listNextResponse.NextLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }
        #endregion

        #region Secret Operations
        
        [Fact]
        public void KeyVaultSecretCreateUpdateDeleteTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                }                
                Assert.Throws<KeyVaultClientException>(()=> { client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult(); });                    
                
            }
        }
        
        [Fact]
        public void KeyVaultGetSecretVersionTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                foreach (SecretItem m in listResponse.Value)
                {
                    if (addedObjects.Contains(m.Id))
                    {
                        Assert.Equal("plainText", m.ContentType);
                        Assert.True(m.Identifier.Name.StartsWith("listsecrettest"));
                        addedObjects.Remove(m.Id);
                    }
                }

                var nextLink = listResponse.NextLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetSecretsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    Assert.NotNull(listNextResponse.Value);
                    foreach (SecretItem m in listNextResponse.Value)
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
                    nextLink = listNextResponse.NextLink;
                }
                
                Assert.True(addedObjects.Count == 0);
            }
        }

        [Fact]
        public void KeyVaultListSecretVersionsTest()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
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
                foreach (SecretItem m in listResponse.Value)
                {
                    if (addedObjects.Contains(m.Id))
                        addedObjects.Remove(m.Id);
                }

                var nextLink = listResponse.NextLink;
                while (!string.IsNullOrEmpty(nextLink))
                {
                    var listNextResponse = client.GetSecretVersionsNextAsync(nextLink).GetAwaiter().GetResult();
                    Assert.NotNull(listNextResponse);
                    foreach (SecretItem m in listNextResponse.Value)
                    {
                        if (addedObjects.Contains(m.Id))
                            addedObjects.Remove(m.Id);
                    }
                    nextLink = listNextResponse.NextLink;
                }

                Assert.True(addedObjects.Count == 0);
            }
        }

        [Fact]
        public void KeyVaultTestSecretExtendedAttributes()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = GetKeyVaultClient();

                string secretName = "secretwithextendedattribs";
                string originalSecretValue = "mysecretvalue";                

                var originalSecret = client.SetSecretAsync(
                    vault: _vaultAddress,
                    secretName: secretName,
                    value: originalSecretValue,
                    tags: new Dictionary<string, string>() {{"purpose", "unit test"}},
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
                Assert.Throws<KeyVaultClientException>(() =>
                {
                    client.GetSecretAsync(_vaultAddress, secretName).GetAwaiter().GetResult();
                });
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

        protected static byte[] RandomHash<T>(int length)
        {
            var data = RandomBytes(length);
            var hash = (((T)Activator.CreateInstance(typeof(T))) as HashAlgorithm).ComputeHash(data);
            return hash;
        }

        private async Task<string> GetAccessToken(string authority, string resource, string scope)
        {                        
            var context = new AuthenticationContext(authority, _tokenCache);
            var result = await context.AcquireTokenAsync(resource, _credential).ConfigureAwait(false);

            return result.AccessToken;
        }

        private void VerifyKeyAttributesAreEqual(KeyAttributes keyAttribute1, KeyAttributes keyAttribute2)
        {
            Assert.Equal<DateTime?>(keyAttribute1.Expires, keyAttribute2.Expires);
            Assert.Equal<DateTime?>(keyAttribute1.NotBefore, keyAttribute2.NotBefore);
            Assert.Equal<bool?>(keyAttribute1.Enabled ?? true, keyAttribute2.Enabled ?? true);
        }

        private void VerifyKeyOperationsAreEqual(string[] firstOperations, string[] secondOperations)
        {
            Assert.False(firstOperations == null && secondOperations != null);
            Assert.False(firstOperations != null && secondOperations == null);
            Assert.True(firstOperations.Length == secondOperations.Length);

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
                    Expires = UnixEpoch.FromUnixTime(notAfter),
                    NotBefore = UnixEpoch.FromUnixTime(notBefore),
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
                var symmetricKey = SymmetricAlgorithm.Create();
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

        #endregion

    }
}
