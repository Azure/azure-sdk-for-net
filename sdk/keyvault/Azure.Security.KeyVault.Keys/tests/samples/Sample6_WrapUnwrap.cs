// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// This sample demonstrates how to wrap and unwrap a symmetric key with an RSA key using the synchronous methods of the <see cref="CryptographyClient">.
    /// </summary>
    public partial class Sample6_WrapUnwrap
    {
        [Test]
        public void WrapUnwrapSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:KeysSample6KeyClient
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample6CreateKey
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
            #endregion

            #region Snippet:KeysSample6CryptographyClient
            var cryptoClient = new CryptographyClient(cloudRsaKey.Id, new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample6GenerateKey
            byte[] keyData = AesManaged.Create().Key;
            Debug.WriteLine($"Generated Key: {Convert.ToBase64String(keyData)}");
            #endregion

            #region Snippet:KeysSample6WrapKey
            WrapResult wrapResult = cryptoClient.WrapKey(KeyWrapAlgorithm.RsaOaep, keyData);
            Debug.WriteLine($"Encrypted data using the algorithm {wrapResult.Algorithm}, with key {wrapResult.KeyId}. The resulting encrypted data is {Convert.ToBase64String(wrapResult.EncryptedKey)}");
            #endregion

            #region Snippet:KeysSample6UnwrapKey
            UnwrapResult unwrapResult = cryptoClient.UnwrapKey(KeyWrapAlgorithm.RsaOaep, wrapResult.EncryptedKey);
            Debug.WriteLine($"Decrypted data using the algorithm {unwrapResult.Algorithm}, with key {unwrapResult.KeyId}. The resulting decrypted data is {Encoding.UTF8.GetString(unwrapResult.Key)}");
            #endregion

            #region Snippet:KeysSample6DeleteKey
            DeleteKeyOperation operation = keyClient.StartDeleteKey(rsaKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }
            #endregion

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);
        }
    }
}
