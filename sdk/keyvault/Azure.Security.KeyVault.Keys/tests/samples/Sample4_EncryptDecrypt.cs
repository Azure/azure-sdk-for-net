// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// This sample demonstrates how to encrypt and decrypt a single block of plain text with an RSA key using the synchronous methods of the <see cref="CryptographyClient">.
    /// </summary>
    public partial class Sample4_EncryptDecypt
    {
        [Test]
        public void EncryptDecryptSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:KeysSample4KeyClient
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample4CreateKey
            // Let's create a RSA key which will be used to encrypt and decrypt
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
            #endregion

            #region Snippet:KeysSample4CryptographyClient
            var cryptoClient = new CryptographyClient(cloudRsaKey.Id, new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample4EncryptKey
            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
            EncryptResult encryptResult = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep256, plaintext);
            Debug.WriteLine($"Encrypted data using the algorithm {encryptResult.Algorithm}, with key {encryptResult.KeyId}. The resulting encrypted data is {Convert.ToBase64String(encryptResult.Ciphertext)}");
            #endregion

            #region Snippet:KeysSample4DecryptKey
            DecryptResult decryptResult = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep256, encryptResult.Ciphertext);
            Debug.WriteLine($"Decrypted data using the algorithm {decryptResult.Algorithm}, with key {decryptResult.KeyId}. The resulting decrypted data is {Encoding.UTF8.GetString(decryptResult.Plaintext)}");
            #endregion

            DeleteKeyOperation operation = keyClient.StartDeleteKey(rsaKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);
        }

        [Test]
        public void OctEncryptDecryptSync()
        {
            TestEnvironment.AssertManagedHsm();

            string managedHsmUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:OctKeysSample4CreateKey
            var managedHsmClient = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());

            var octKeyOptions = new CreateOctKeyOptions($"CloudOctKey-{Guid.NewGuid()}")
            {
                KeySize = 256,
            };

            KeyVaultKey cloudOctKey = managedHsmClient.CreateOctKey(octKeyOptions);
            #endregion

            #region Snippet:OctKeySample4Encrypt
            var cryptoClient = new CryptographyClient(cloudOctKey.Id, new DefaultAzureCredential());

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
            byte[] aad = Encoding.UTF8.GetBytes("additional authenticated data");

            EncryptParameters encryptParams = EncryptParameters.A256GcmParameters(plaintext, aad);
            EncryptResult encryptResult = cryptoClient.Encrypt(encryptParams);
            #endregion

            #region Snippet:OctKeySample4Decrypt
            DecryptParameters decryptParams = DecryptParameters.A256GcmParameters(
                encryptResult.Ciphertext,
                encryptResult.Iv,
                encryptResult.AuthenticationTag,
                encryptResult.AdditionalAuthenticatedData);

            DecryptResult decryptResult = cryptoClient.Decrypt(decryptParams);
            #endregion

            Assert.AreEqual(plaintext, decryptResult.Plaintext);

            // Delete and purge the key.
            DeleteKeyOperation operation = managedHsmClient.StartDeleteKey(octKeyOptions.Name);

            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            managedHsmClient.PurgeDeletedKey(operation.Value.Name);
        }
    }
}
