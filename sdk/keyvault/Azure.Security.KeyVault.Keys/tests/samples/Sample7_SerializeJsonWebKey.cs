// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to serialize a JWK, use that to encrypt locally, and deserialize remotely using Key Vault.
    /// </summary>
    public partial class Sample7_SerializeJsonWebKey
    {
        [Test]
        public void SerializeJsonWebKeySync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:KeysSample7KeyClient
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample7CreateKey
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
            #endregion

            string dir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "samples", nameof(Sample7_SerializeJsonWebKey));
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, $"{nameof(SerializeJsonWebKeySync)}.json");

            // Use `using` expression for clean sample, but scope it to close and dispose immediately.
            {
                #region Snippet:KeysSample7Serialize
                using FileStream file = File.Create(path);
                using (Utf8JsonWriter writer = new Utf8JsonWriter(file))
                {
                    JsonSerializer.Serialize(writer, cloudRsaKey.Key);
                }

                Debug.WriteLine($"Saved JWK to {path}");
                #endregion
            }

            #region Snippet:KeysSamples7Deserialize
            byte[] buffer = File.ReadAllBytes(path);
            JsonWebKey jwk = JsonSerializer.Deserialize<JsonWebKey>(buffer);

            Debug.WriteLine($"Read JWK from {path} with ID {jwk.Id}");
            #endregion

            string content = "plaintext";

            #region Snippet:KeysSample7Encrypt
            var encryptClient = new CryptographyClient(jwk);

            byte[] plaintext = Encoding.UTF8.GetBytes(content);
            EncryptResult encrypted = encryptClient.Encrypt(EncryptParameters.RsaOaepParameters(plaintext));

            Debug.WriteLine($"Encrypted: {Encoding.UTF8.GetString(plaintext)}");
            #endregion

            byte[] ciphertext = encrypted.Ciphertext;

            #region Snippet:KeysSample7Decrypt
            CryptographyClient decryptClient = keyClient.GetCryptographyClient(cloudRsaKey.Name, cloudRsaKey.Properties.Version);
            DecryptResult decrypted = decryptClient.Decrypt(DecryptParameters.RsaOaepParameters(ciphertext));

            Debug.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted.Plaintext)}");
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
    }
}
