// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets
    {
#pragma warning disable IDE1006 // Naming Styles
        private KeyClient client;
        private CryptographyClient cryptoClient;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string vaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:CreateKeyClient
            // Create a new key client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new KeyClient(vaultUri: new Uri(vaultUrl), credential: new DefaultAzureCredential());

            // Create a new key using the key client.
            KeyVaultKey key = client.CreateKey("key-name", KeyType.Rsa);

            // Retrieve a key using the key client.
            key = client.GetKey("key-name");
            #endregion

            #region Snippet:CreateCryptographyClient
            // Create a new cryptography client using the same Key Vault or Managed HSM endpoint, service version,
            // and options as the KeyClient created earlier.
            CryptographyClient cryptoClient = client.GetCryptographyClient(key.Name, key.Properties.Version);
            #endregion

            this.client = client;
            this.cryptoClient = cryptoClient;
        }

        [Test]
        [PremiumOnly]
        public void CreateKey()
        {
            #region Snippet:CreateKey
            // Create a key. Note that you can specify the type of key
            // i.e. Elliptic curve, Hardware Elliptic Curve, RSA
            KeyVaultKey key = client.CreateKey("key-name", KeyType.Rsa);

            Console.WriteLine(key.Name);
            Console.WriteLine(key.KeyType);

            // Create a software RSA key
            var rsaCreateKey = new CreateRsaKeyOptions("rsa-key-name", hardwareProtected: false);
            KeyVaultKey rsaKey = client.CreateRsaKey(rsaCreateKey);

            Console.WriteLine(rsaKey.Name);
            Console.WriteLine(rsaKey.KeyType);

            // Create a hardware Elliptic Curve key
            // Because only premium Azure Key Vault supports HSM backed keys , please ensure your Azure Key Vault
            // SKU is premium when you set "hardwareProtected" value to true
            var echsmkey = new CreateEcKeyOptions("ec-key-name", hardwareProtected: true);
            KeyVaultKey ecKey = client.CreateEcKey(echsmkey);

            Console.WriteLine(ecKey.Name);
            Console.WriteLine(ecKey.KeyType);
            #endregion
        }

        [Test]
        [PremiumOnly]
        public async Task CreateKeyAsync()
        {
            #region Snippet:CreateKeyAsync
            // Create a key of any type
            KeyVaultKey key = await client.CreateKeyAsync("key-name", KeyType.Rsa);

            Console.WriteLine(key.Name);
            Console.WriteLine(key.KeyType);

            // Create a software RSA key
            var rsaCreateKey = new CreateRsaKeyOptions("rsa-key-name", hardwareProtected: false);
            KeyVaultKey rsaKey = await client.CreateRsaKeyAsync(rsaCreateKey);

            Console.WriteLine(rsaKey.Name);
            Console.WriteLine(rsaKey.KeyType);

            // Create a hardware Elliptic Curve key
            // Because only premium Azure Key Vault supports HSM backed keys , please ensure your Azure Key Vault
            // SKU is premium when you set "hardwareProtected" value to true
            var echsmkey = new CreateEcKeyOptions("ec-key-name", hardwareProtected: true);
            KeyVaultKey ecKey = await client.CreateEcKeyAsync(echsmkey);

            Console.WriteLine(ecKey.Name);
            Console.WriteLine(ecKey.KeyType);
            #endregion
        }

        [Test]
        public void RetrieveKey()
        {
            // Make sure a key exists.
            client.CreateKey("key-name", KeyType.Rsa);

            #region Snippet:RetrieveKey
            KeyVaultKey key = client.GetKey("key-name");

            Console.WriteLine(key.Name);
            Console.WriteLine(key.KeyType);
            #endregion
        }

        [Test]
        public void UpdateKey()
        {
            #region Snippet:UpdateKey
            KeyVaultKey key = client.CreateKey("key-name", KeyType.Rsa);

            // You can specify additional application-specific metadata in the form of tags.
            key.Properties.Tags["foo"] = "updated tag";

            KeyVaultKey updatedKey = client.UpdateKeyProperties(key.Properties);

            Console.WriteLine(updatedKey.Name);
            Console.WriteLine(updatedKey.Properties.Version);
            Console.WriteLine(updatedKey.Properties.UpdatedOn);
            #endregion
        }

        [Test]
        public void ListKeys()
        {
            #region Snippet:ListKeys
            Pageable<KeyProperties> allKeys = client.GetPropertiesOfKeys();

            foreach (KeyProperties keyProperties in allKeys)
            {
                Console.WriteLine(keyProperties.Name);
            }
            #endregion
        }

        [Test]
        public async Task ListKeysAsync()
        {
            #region Snippet:ListKeysAsync
            AsyncPageable<KeyProperties> allKeys = client.GetPropertiesOfKeysAsync();

            await foreach (KeyProperties keyProperties in allKeys)
            {
                Console.WriteLine(keyProperties.Name);
            }
            #endregion
        }

        [Test]
        public void EncryptDecrypt()
        {
#if SNIPPET
            KeyVaultKey key = null;
#endif

            #region Snippet:EncryptDecrypt
#if SNIPPET
            // Create a new cryptography client using the same Key Vault or Managed HSM endpoint, service version,
            // and options as the KeyClient created earlier.
            var cryptoClient = client.GetCryptographyClient(key.Name, key.Properties.Version);
#endif

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

            // encrypt the data using the algorithm RSAOAEP
            EncryptResult encryptResult = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep256, plaintext);

            // decrypt the encrypted data.
            DecryptResult decryptResult = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep256, encryptResult.Ciphertext);
            #endregion
        }

        [Test]
        public void NotFound()
        {
            #region Snippet:KeyNotFound
            try
            {
                KeyVaultKey key = client.GetKey("some_key");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [Ignore("The key is deleted and purged on tear down of this text fixture.")]
        public void DeleteKey()
        {
            #region Snippet:DeleteKey
            DeleteKeyOperation operation = client.StartDeleteKey("key-name");

            DeletedKey key = operation.Value;
            Console.WriteLine(key.Name);
            Console.WriteLine(key.DeletedOn);
            #endregion
        }

        [OneTimeTearDown]
        public async Task DeleteAndPurgeKey()
        {
            #region Snippet:DeleteAndPurgeKeyAsync
            DeleteKeyOperation operation = await client.StartDeleteKeyAsync("key-name");

            // You only need to wait for completion if you want to purge or recover the key.
            await operation.WaitForCompletionAsync();

            DeletedKey key = operation.Value;
            await client.PurgeDeletedKeyAsync(key.Name);
            #endregion

            DeleteKeyOperation rsaKeyOperation = client.StartDeleteKey("rsa-key-name");
            DeleteKeyOperation ecKeyOperation = client.StartDeleteKey("ec-key-name");

            try
            {
                // You only need to wait for completion if you want to purge or recover the key.
                await Task.WhenAll(
                    rsaKeyOperation.WaitForCompletionAsync().AsTask(),
                    ecKeyOperation.WaitForCompletionAsync().AsTask());

                await Task.WhenAll(
                    client.PurgeDeletedKeyAsync(rsaKeyOperation.Value.Name),
                    client.PurgeDeletedKeyAsync(ecKeyOperation.Value.Name));
            }
            catch
            {
                // Merely attempt to purge a deleted key since the Key Vault may not have soft delete enabled.
            }
        }

        [Ignore("The key is deleted and purged on tear down of this text fixture.")]
        public void DeleteAndPurge()
        {
            #region Snippet:DeleteAndPurgeKey
            DeleteKeyOperation operation = client.StartDeleteKey("key-name");

            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            DeletedKey key = operation.Value;
            client.PurgeDeletedKey(key.Name);
            #endregion
        }

        [Ignore("Used only for the migration guide")]
        private async Task MigrationGuide()
        {
            {
            #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Create
            KeyClient client = new KeyClient(
                new Uri("https://myvault.vault.azure.net"),
                new DefaultAzureCredential());

            CryptographyClient cryptoClient = new CryptographyClient(
                new Uri("https://myvault.vault.azure.net"),
                new DefaultAzureCredential());
            #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Create
            }

            #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions
            using (HttpClient httpClient = new HttpClient())
            {
                KeyClientOptions options = new KeyClientOptions
                {
                    Transport = new HttpClientTransport(httpClient)
                };

#if SNIPPET
                KeyClient client = new KeyClient(
#else
                KeyClient client = new KeyClient(
#endif
                    new Uri("https://myvault.vault.azure.net"),
                    new DefaultAzureCredential(),
                    options);

                CryptographyClientOptions cryptoOptions = new CryptographyClientOptions
                {
                    Transport = new HttpClientTransport(httpClient)
                };

#if SNIPPET
                CryptographyClient cryptoClient = new CryptographyClient(
#else
                cryptoClient = new CryptographyClient(
#endif
                    new Uri("https://myvault.vault.azure.net"),
                    new DefaultAzureCredential(),
                    cryptoOptions);
            }
            #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions

            {
                #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_CreateKeys
                // Create RSA key.
                CreateRsaKeyOptions createRsaOptions = new CreateRsaKeyOptions("rsa-key-name")
                {
                    KeySize = 4096
                };

                KeyVaultKey rsaKey = await client.CreateRsaKeyAsync(createRsaOptions);

                // Create Elliptic-Curve key.
                CreateEcKeyOptions createEcOptions = new CreateEcKeyOptions("ec-key-name")
                {
                    CurveName = KeyCurveName.P256
                };

                KeyVaultKey ecKey = await client.CreateEcKeyAsync(createEcOptions);
                #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_CreateKeys
            }

            {
                #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_ListKeys
                // List all keys asynchronously.
                await foreach (KeyProperties item in client.GetPropertiesOfKeysAsync())
                {
                    KeyVaultKey key = await client.GetKeyAsync(item.Name);
                }

                // List all keys synchronously.
                foreach (KeyProperties item in client.GetPropertiesOfKeys())
                {
                    KeyVaultKey key = client.GetKey(item.Name);
                }
                #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_ListKeys
            }

            {
                #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_DeleteKey
                // Delete the key.
                DeleteKeyOperation deleteOperation = await client.StartDeleteKeyAsync("key-name");

                // Purge or recover the deleted key if soft delete is enabled.
                if (deleteOperation.Value.RecoveryId != null)
                {
                    // Deleting a key does not happen immediately. Wait for the key to be deleted.
                    DeletedKey deletedKey = await deleteOperation.WaitForCompletionAsync();

                    // Purge the deleted key.
                    await client.PurgeDeletedKeyAsync(deletedKey.Name);

                    // You can also recover the deleted key using StartRecoverDeletedKeyAsync,
                    // which returns RecoverDeletedKeyOperation you can await like DeleteKeyOperation above.
                }
                #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_DeleteKey
            }

            {
                #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Encrypt
                // Encrypt a message. The plaintext must be small enough for the chosen algorithm.
                byte[] plaintext = Encoding.UTF8.GetBytes("Small message to encrypt");
                EncryptResult encrypted = await cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep256, plaintext);

                // Decrypt the message.
                DecryptResult decrypted = await cryptoClient.DecryptAsync(encrypted.Algorithm, encrypted.Ciphertext);
                string message = Encoding.UTF8.GetString(decrypted.Plaintext);
                #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Encrypt
            }

            {
                #region Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Wrap
                using (Aes aes = Aes.Create())
                {
                    // Use a symmetric key to encrypt large amounts of data, possibly streamed...

                    // Now wrap the key and store the encrypted key and plaintext IV to later decrypt the key to decrypt the data.
                    WrapResult wrapped = await cryptoClient.WrapKeyAsync(KeyWrapAlgorithm.RsaOaep256, aes.Key);

                    // Read the IV and the encrypted key from the payload, then unwrap the key.
                    UnwrapResult unwrapped = await cryptoClient.UnwrapKeyAsync(wrapped.Algorithm, wrapped.EncryptedKey);
                    aes.Key = unwrapped.Key;

                    // Decrypt the payload with the symmetric key.
                }
                #endregion Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Wrap
            }
        }
    }
}
