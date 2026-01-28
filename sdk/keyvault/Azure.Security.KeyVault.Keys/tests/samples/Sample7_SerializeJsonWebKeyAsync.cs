// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Samples
{
    public partial class Sample7_SerializeJsonWebKey
    {
        [Test]
        public async Task SerializeJsonWebKeyAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            KeyVaultKey cloudRsaKey = await keyClient.CreateRsaKeyAsync(rsaKey);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");

            string dir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "samples", nameof(Sample7_SerializeJsonWebKey));
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, $"{nameof(SerializeJsonWebKeyAsync)}.json");

            // Use `using` expression for clean sample, but scope it to close and dispose immediately.
            {
                using FileStream file = File.Create(path);
                await JsonSerializer.SerializeAsync(file, cloudRsaKey.Key);

                Debug.WriteLine($"Saved JWK to {path}");
            }

            // Use `using` expression for clean sample, but scope it to close and dispose immediately.
            JsonWebKey jwk = null;
            {
                using FileStream file = File.Open(path, FileMode.Open);
                jwk = await JsonSerializer.DeserializeAsync<JsonWebKey>(file);

                Debug.WriteLine($"Read JWK from {path} with ID {jwk.Id}");
            }

            string content = "plaintext";

            var encryptClient = new CryptographyClient(jwk);

            byte[] plaintext = Encoding.UTF8.GetBytes(content);
            EncryptResult encrypted = await encryptClient.EncryptAsync(EncryptParameters.RsaOaepParameters(plaintext));

            Debug.WriteLine($"Encrypted: {Encoding.UTF8.GetString(plaintext)}");

            byte[] ciphertext = encrypted.Ciphertext;

            CryptographyClient decryptClient = keyClient.GetCryptographyClient(cloudRsaKey.Name, cloudRsaKey.Properties.Version);
            DecryptResult decrypted = await decryptClient.DecryptAsync(DecryptParameters.RsaOaepParameters(ciphertext));

            Debug.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted.Plaintext)}");

            DeleteKeyOperation operation = await keyClient.StartDeleteKeyAsync(rsaKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            await operation.WaitForCompletionAsync();

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);
        }
    }
}
