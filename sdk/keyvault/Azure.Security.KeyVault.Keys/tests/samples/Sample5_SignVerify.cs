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
    /// This sample demonstrates how to sign data with both a RSA key and an EC key using the synchronous methods of the <see cref="CryptographyClient">.
    /// </summary>
    public partial class Sample5_SignVerify
    {
        [Test]
        public void SignVerifySync()
        {
#if NET462
            Assert.Ignore("Using CryptographyClient with EC keys is not supported on .NET Framework 4.6.2.");
#endif

            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

#region Snippet:KeysSample5KeyClient
            var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
#endregion

#region Snippet:KeysSample5CreateKey
            string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
            var rsaKeyOptions = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
            {
                KeySize = 2048,
            };

            string ecKeyName = $"CloudEcKey-{Guid.NewGuid()}";
            var ecKeyOptions = new CreateEcKeyOptions(ecKeyName, hardwareProtected: false)
            {
                CurveName = KeyCurveName.P256K,
            };

            KeyVaultKey rsaKey = keyClient.CreateRsaKey(rsaKeyOptions);
            Debug.WriteLine($"Key is returned with name {rsaKey.Name} and type {rsaKey.KeyType}");

            KeyVaultKey ecKey = keyClient.CreateEcKey(ecKeyOptions);
            Debug.WriteLine($"Key is returned with name {ecKey.Name} and type {ecKey.KeyType}");
#endregion

#region Snippet:KeysSample5CryptographyClient
            var rsaCryptoClient = new CryptographyClient(rsaKey.Id, new DefaultAzureCredential());

            var ecCryptoClient = new CryptographyClient(ecKey.Id, new DefaultAzureCredential());
#endregion

#region Snippet:KeysSample5SignKey
            byte[] data = Encoding.UTF8.GetBytes("This is some sample data which we will use to demonstrate sign and verify");
            byte[] digest = null;

            using (HashAlgorithm hashAlgo = SHA256.Create())
            {
                digest = hashAlgo.ComputeHash(data);
            }

            SignResult rsaSignResult = rsaCryptoClient.Sign(SignatureAlgorithm.RS256, digest);
            Debug.WriteLine($"Signed digest using the algorithm {rsaSignResult.Algorithm}, with key {rsaSignResult.KeyId}. The resulting signature is {Convert.ToBase64String(rsaSignResult.Signature)}");

            SignResult ecSignResult = ecCryptoClient.Sign(SignatureAlgorithm.ES256K, digest);
            Debug.WriteLine($"Signed digest using the algorithm {ecSignResult.Algorithm}, with key {ecSignResult.KeyId}. The resulting signature is {Convert.ToBase64String(ecSignResult.Signature)}");
#endregion

#region Snippet:KeysSample5VerifySign
            VerifyResult rsaVerifyResult = rsaCryptoClient.Verify(SignatureAlgorithm.RS256, digest, rsaSignResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {rsaVerifyResult.Algorithm}, with key {rsaVerifyResult.KeyId}. Signature is valid: {rsaVerifyResult.IsValid}");

            VerifyResult ecVerifyResult = ecCryptoClient.Verify(SignatureAlgorithm.ES256K, digest, ecSignResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {ecVerifyResult.Algorithm}, with key {ecVerifyResult.KeyId}. Signature is valid: {ecVerifyResult.IsValid}");
#endregion

#region Snippet:KeysSample5SignKeyWithSignData
            SignResult rsaSignDataResult = rsaCryptoClient.SignData(SignatureAlgorithm.RS256, data);
            Debug.WriteLine($"Signed data using the algorithm {rsaSignDataResult.Algorithm}, with key {rsaSignDataResult.KeyId}. The resulting signature is {Convert.ToBase64String(rsaSignDataResult.Signature)}");

            SignResult ecSignDataResult = ecCryptoClient.SignData(SignatureAlgorithm.ES256K, data);
            Debug.WriteLine($"Signed data using the algorithm {ecSignDataResult.Algorithm}, with key {ecSignDataResult.KeyId}. The resulting signature is {Convert.ToBase64String(ecSignDataResult.Signature)}");
#endregion

#region Snippet:KeysSample5VerifyKeyWithData
            VerifyResult rsaVerifyDataResult = rsaCryptoClient.VerifyData(SignatureAlgorithm.RS256, data, rsaSignDataResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {rsaVerifyDataResult.Algorithm}, with key {rsaVerifyDataResult.KeyId}. Signature is valid: {rsaVerifyDataResult.IsValid}");

            VerifyResult ecVerifyDataResult = ecCryptoClient.VerifyData(SignatureAlgorithm.ES256K, data, ecSignDataResult.Signature);
            Debug.WriteLine($"Verified the signature using the algorithm {ecVerifyDataResult.Algorithm}, with key {ecVerifyDataResult.KeyId}. Signature is valid: {ecVerifyDataResult.IsValid}");
#endregion

            DeleteKeyOperation rsaKeyOperation = keyClient.StartDeleteKey(rsaKeyName);
            DeleteKeyOperation ecKeyOperation = keyClient.StartDeleteKey(ecKeyName);

            // You only need to wait for completion if you want to purge or recover the key.
            while (!rsaKeyOperation.HasCompleted || !ecKeyOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                rsaKeyOperation.UpdateStatus();
                ecKeyOperation.UpdateStatus();
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            keyClient.PurgeDeletedKey(rsaKeyName);
            keyClient.PurgeDeletedKey(ecKeyName);
        }
    }
}
