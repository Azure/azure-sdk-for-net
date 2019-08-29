using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Azure.Security.KeyVault.Keys.Samples
{

    /// <summary>
    /// Sample demonstrates how to encrypt and decrypt a single block of plain text with an RSA key using the synchronous methods of the CryptographyClient.
    /// </summary>
    [LiveOnly]
    public partial class Sample4_EncryptDecypt
    {
        [Test]
        public void EncryptDecryptSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            // Instantiate a key client that will be used to create a key. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create a RSA key which will be used to encrypt and decrypt
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new RsaKeyCreateOptions(rsaKeyName, hsm: false, keySize: 2048);

            Key cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyMaterial.KeyType}");

            // Let's create the CryptographyClient which can perform cryptographic operations with the key we just created. 
            // Again we are using the default Azure credential as above.
            var cryptoClient = new CryptographyClient(cloudRsaKey.Id, new DefaultAzureCredential());

            // Next we'll encrypt some arbitrary plain text with the key using the CryptographyClient. Note that RSA encryption 
            // algorithms have no chaining so they can only encrypt a single block of plaintext securely. For RSAOAEP this can be 
            // calculated as (keysize / 8) - 42, or in our case (2048 / 8) - 42 = 214 bytes.
            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

            // First encrypt the data using RSAOAEP with the created key.
            EncryptResult encryptResult = cryptoClient.Encrypt(EncryptionAlgorithm.RSAOAEP, plaintext);
            Debug.WriteLine($"Encrypted data using the algorithm {encryptResult.Algorithm}, with key {encryptResult.KeyId}. The resulting encrypted data is {Convert.ToBase64String(encryptResult.Ciphertext)}");

            // Now decrypt the encrypted data. Note that the same algorithm must always be used for both encrypt and decrypt
            DecryptResult decryptResult = cryptoClient.Decrypt(EncryptionAlgorithm.RSAOAEP, encryptResult.Ciphertext);
            Debug.WriteLine($"Decrypted data using the algorithm {decryptResult.Algorithm}, with key {decryptResult.KeyId}. The resulting decrypted data is {Encoding.UTF8.GetString(decryptResult.Plaintext)}");

            // The Cloud RSA Key is no longer needed, need to delete it from the Key Vault.
            keyClient.DeleteKey(rsaKeyName);

            // To ensure key is deleted on server side.
            Assert.IsTrue(WaitForDeletedKey(keyClient, rsaKeyName));

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);

        }

        private bool WaitForDeletedKey(KeyClient client, string keyName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    client.GetDeletedKey(keyName);
                    return true;
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
            return false;
        }
    }
}
