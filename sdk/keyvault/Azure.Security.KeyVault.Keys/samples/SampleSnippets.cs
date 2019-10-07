// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
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
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            #region CreateKeyClient
            // Create a new key client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new KeyClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Create a new key using the key client
            Key key = client.CreateKey("key-name", KeyType.Rsa);
            #endregion

            #region CreateCryptographyClient
            // Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var cryptoClient = new CryptographyClient(keyId: key.Id, credential: new DefaultAzureCredential());
            #endregion

            this.client = client;
            this.cryptoClient = cryptoClient;
        }

        [Test]
        public void CreateKey()
        {
            #region CreateKey
            // Create a key. Note that you can specify the type of key
            // i.e. Elliptic curve, Hardware Elliptic Curve, RSA
            Key key = client.CreateKey("key-name", KeyType.Rsa);

            Console.WriteLine(key.Name);
            Console.WriteLine(key.KeyMaterial.KeyType);

            // Create a software RSA key
            var rsaCreateKey = new RsaKeyCreateOptions("rsa-key-name", hsm: false);
            Key rsaKey = client.CreateRsaKey(rsaCreateKey);

            Console.WriteLine(rsaKey.Name);
            Console.WriteLine(rsaKey.KeyMaterial.KeyType);

            // Create a hardware Elliptic Curve key
            var echsmkey = new EcKeyCreateOptions("ec-key-name", hsm: true);
            Key ecKey = client.CreateEcKey(echsmkey);

            Console.WriteLine(ecKey.Name);
            Console.WriteLine(ecKey.KeyMaterial.KeyType);
            #endregion
        }

        [Test]
        public async Task CreateKeyAsync()
        {
            #region CreateKeyAsync
            // Create a key of any type
            Key key = await client.CreateKeyAsync("key-name", KeyType.Rsa);

            Console.WriteLine(key.Name);
            Console.WriteLine(key.KeyMaterial.KeyType);

            // Create a software RSA key
            var rsaCreateKey = new RsaKeyCreateOptions("rsa-key-name", hsm: false);
            Key rsaKey = await client.CreateRsaKeyAsync(rsaCreateKey);

            Console.WriteLine(rsaKey.Name);
            Console.WriteLine(rsaKey.KeyMaterial.KeyType);

            // Create a hardware Elliptic Curve key
            var echsmkey = new EcKeyCreateOptions("ec-key-name", hsm: true);
            Key ecKey = await client.CreateEcKeyAsync(echsmkey);

            Console.WriteLine(ecKey.Name);
            Console.WriteLine(ecKey.KeyMaterial.KeyType);
            #endregion
        }

        [Test]
        public void RetrieveKey()
        {
            // Make sure a key exists.
            client.CreateKey("key-name", KeyType.Rsa);

            #region RetrieveKey
            Key key = client.GetKey("key-name");

            Console.WriteLine(key.Name);
            Console.WriteLine(key.KeyMaterial.KeyType);
            #endregion
        }

        [Test]
        public void UpdateKey()
        {
            #region UpdateKey
            Key key = client.CreateKey("key-name", KeyType.Rsa);

            // You can specify additional application-specific metadata in the form of tags.
            key.Properties.Tags["foo"] = "updated tag";

            Key updatedKey = client.UpdateKeyProperties(key.Properties, key.KeyMaterial.KeyOps);

            Console.WriteLine(updatedKey.Name);
            Console.WriteLine(updatedKey.Properties.Version);
            Console.WriteLine(updatedKey.Properties.Updated);
            #endregion
        }

        [Test]
        public void ListKeys()
        {
            #region ListKeys
            Pageable<KeyProperties> allKeys = client.GetKeys();

            foreach (KeyProperties key in allKeys)
            {
                Console.WriteLine(key.Name);
            }
            #endregion
        }

        [Test]
        public void EncryptDecrypt()
        {
            #region EncryptDecrypt
            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

            // encrypt the data using the algorithm RSAOAEP
            EncryptResult encryptResult = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep, plaintext);

            // decrypt the encrypted data.
            DecryptResult decryptResult = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep, encryptResult.Ciphertext);
            #endregion
        }

        [Test]
        public async Task NotFoundAsync()
        {
            #region NotFound
            try
            {
                Key key = await client.GetKeyAsync("some_key");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [OneTimeTearDown]
        public void DeleteKey()
        {
            #region DeleteKey
            DeletedKey key = client.DeleteKey("key-name");

            Console.WriteLine(key.Name);
            Console.WriteLine(key.DeletedDate);
            #endregion

            DeletedKey rsaKey = client.DeleteKey("rsa-key-name");
            DeletedKey ecKey = client.DeleteKey("ec-key-name");

            try
            {
                // Deleting a key when soft delete is enabled may not happen immediately.
                WaitForDeletedKey(key.Name);
                WaitForDeletedKey(rsaKey.Name);
                WaitForDeletedKey(ecKey.Name);

                client.PurgeDeletedKey(key.Name);
                client.PurgeDeletedKey(rsaKey.Name);
                client.PurgeDeletedKey(ecKey.Name);
            }
            catch
            {
                // Merely attempt to purge a deleted key since the Key Vault may not have soft delete enabled.
            }
        }

        private void WaitForDeletedKey(string keyName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    client.GetDeletedKey(keyName);
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
