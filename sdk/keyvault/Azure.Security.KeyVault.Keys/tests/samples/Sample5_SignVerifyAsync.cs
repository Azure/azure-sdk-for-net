// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// Sample demonstrates how to sign data with both a RSA key and an EC key using the synchronous methods of the CryptographyClient.
    /// </summary>
    public partial class Sample5_SignVerify
    {
        [Test]
        public async Task SignVerifyAsync()
        {
#if NET461
            Assert.Ignore("Using CryptographyClient with EC keys is not supported on .NET Framework 4.6.1.");
#endif

            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            // Instantiate a key client that will be used to create a key. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // First we'll create both a RSA key and an EC which will be used to sign and verify
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            string ecKeyName = $"CloudEcKey-{Guid.NewGuid()}";
            var ecKey = new CreateEcKeyOptions(ecKeyName, hardwareProtected: false)
            {
                CurveName = KeyCurveName.P256K,
            };

            KeyVaultKey cloudRsaKey = await keyClient.CreateRsaKeyAsync(rsaKey);
            Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");

            KeyVaultKey cloudEcKey = await keyClient.CreateEcKeyAsync(ecKey);
            Debug.WriteLine($"Key is returned with name {cloudEcKey.Name} and type {cloudEcKey.KeyType}");

            // Let's create the CryptographyClient which can perform cryptographic operations with the keys we just created using the same credential created above..
            var rsaCryptoClient = new CryptographyClient(cloudRsaKey.Id, new DefaultAzureCredential());

            var ecCryptoClient = new CryptographyClient(cloudEcKey.Id, new DefaultAzureCredential());

            // Next we'll sign some arbitrary data and verify the signatures using the CryptographyClient with both the EC and RSA keys we created.
            byte[] data = Encoding.UTF8.GetBytes("This is some sample data which we will use to demonstrate sign and verify");
            byte[] digest = null;

            //
            // Signing with the SignAsync and VerifyAsync methods
            //

            // The SignAsync and VerifyAsync methods expect a precalculated digest, and the digest needs to be calculated using the hash algorithm which matches the
            // signature algorithm being used. SHA256 is the hash algorithm used for both RS256 and ES256K which are the algorithms we'll be using in this sample
            using (HashAlgorithm hashAlgo = SHA256.Create())
            {
                digest = hashAlgo.ComputeHash(data);
            }

            // Get the signature for the computed digest with both keys. Note that the signature algorithm specified must be a valid algorithm for the key type,
            // and for EC keys the algorithm must also match the curve of the key
            SignResult rsaSignResult = await rsaCryptoClient.SignAsync(SignatureAlgorithm.RS256, digest);
            Debug.WriteLine($"Signed digest using the algorithm {rsaSignResult.Algorithm}, with key {rsaSignResult.KeyId}. The resulting signature is {Convert.ToBase64String(rsaSignResult.Signature)}");

            SignResult ecSignResult = await ecCryptoClient.SignAsync(SignatureAlgorithm.ES256K, digest);
            Debug.WriteLine($"Signed digest using the algorithm {ecSignResult.Algorithm}, with key {ecSignResult.KeyId}. The resulting signature is {Convert.ToBase64String(ecSignResult.Signature)}");

            // Verify the signatures
            VerifyResult rsaVerifyResult = await rsaCryptoClient.VerifyAsync(SignatureAlgorithm.RS256, digest, rsaSignResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {rsaVerifyResult.Algorithm}, with key {rsaVerifyResult.KeyId}. Signature is valid: {rsaVerifyResult.IsValid}");

            VerifyResult ecVerifyResult = await ecCryptoClient.VerifyAsync(SignatureAlgorithm.ES256K, digest, ecSignResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {ecVerifyResult.Algorithm}, with key {ecVerifyResult.KeyId}. Signature is valid: {ecVerifyResult.IsValid}");

            //
            // Signing with the SignDataAsync and VerifyDataAsync methods
            //

            // The SignDataAsync and VerifyDataAsync methods take the raw data which is to be signed.  The calculate the digest for the user so there is no need to compute the digest

            // Get the signature for the data with both keys. Note that the signature algorithm specified must be a valid algorithm for the key type,
            // and for EC keys the algorithm must also match the curve of the key
            SignResult rsaSignDataResult = await rsaCryptoClient.SignDataAsync(SignatureAlgorithm.RS256, data);
            Debug.WriteLine($"Signed data using the algorithm {rsaSignDataResult.Algorithm}, with key {rsaSignDataResult.KeyId}. The resulting signature is {Convert.ToBase64String(rsaSignDataResult.Signature)}");

            SignResult ecSignDataResult = await ecCryptoClient.SignDataAsync(SignatureAlgorithm.ES256K, data);
            Debug.WriteLine($"Signed data using the algorithm {ecSignDataResult.Algorithm}, with key {ecSignDataResult.KeyId}. The resulting signature is {Convert.ToBase64String(ecSignDataResult.Signature)}");

            // Verify the signatures
            VerifyResult rsaVerifyDataResult = await rsaCryptoClient.VerifyDataAsync(SignatureAlgorithm.RS256, data, rsaSignDataResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {rsaVerifyDataResult.Algorithm}, with key {rsaVerifyDataResult.KeyId}. Signature is valid: {rsaVerifyDataResult.IsValid}");

            VerifyResult ecVerifyDataResult = await ecCryptoClient.VerifyDataAsync(SignatureAlgorithm.ES256K, data, ecSignDataResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {ecVerifyDataResult.Algorithm}, with key {ecVerifyDataResult.KeyId}. Signature is valid: {ecVerifyDataResult.IsValid}");

            // The Cloud Keys are no longer needed, need to delete them from the Key Vault.
            DeleteKeyOperation rsaKeyOperation = await keyClient.StartDeleteKeyAsync(rsaKeyName);
            DeleteKeyOperation ecKeyOperation = await keyClient.StartDeleteKeyAsync(ecKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            await Task.WhenAll(
                rsaKeyOperation.WaitForCompletionAsync().AsTask(),
                ecKeyOperation.WaitForCompletionAsync().AsTask());

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            await Task.WhenAll(
                keyClient.PurgeDeletedKeyAsync(rsaKeyName),
                keyClient.PurgeDeletedKeyAsync(ecKeyName));
        }
    }
}
