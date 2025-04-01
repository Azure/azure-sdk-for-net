// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    public partial class DownloadCertificate
    {
// Need to exclude actual TFMs since SNIPPET is always passed during CIs, such that the following will fail:
// NET472_OR_GREATER || NETSTANDARD2_1_OR_GREATER || SNIPPET
#if !NET462 && !NET47
        [Test]
        public void DownloadCertificateSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

        #region Snippet:CertificatesSample4CertificateClient
            CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
        #endregion

            string certificateName = $"rsa-{Guid.NewGuid()}";
            CertificateOperation operation = client.StartCreateCertificate(certificateName, CertificatePolicy.Default);

            while (!operation.HasCompleted)
            {
                operation.UpdateStatus();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            using SHA256 sha = SHA256.Create();
            byte[] data = Encoding.UTF8.GetBytes("test");
            byte[] hash = sha.ComputeHash(data);

        #region Snippet:CertificatesSample4DownloadCertificate
            X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.MachineKeySet;
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                keyStorageFlags |= X509KeyStorageFlags.EphemeralKeySet;
            }

            DownloadCertificateOptions options = new DownloadCertificateOptions(certificateName)
            {
                KeyStorageFlags = keyStorageFlags
            };

            using X509Certificate2 certificate = client.DownloadCertificate(options);
            using RSA key = certificate.GetRSAPrivateKey();

            byte[] signature = key.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            Debug.WriteLine($"Signature: {Convert.ToBase64String(signature)}");
            #endregion

#pragma warning disable SYSLIB0057 // New APIs are not supported on all versions of .NET
        #region Snippet:CertificatesSample4PublicKey
            Response<KeyVaultCertificateWithPolicy> certificateResponse = client.GetCertificate(certificateName);
            using X509Certificate2 publicCertificate = new X509Certificate2(certificateResponse.Value.Cer);
            using RSA publicKey = publicCertificate.GetRSAPublicKey();

            bool verified = publicKey.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            Debug.WriteLine($"Signature verified: {verified}");
        #endregion
#pragma warning restore SYSLIB0057 // New APIs are not supported on all versions of .NET

            Assert.IsTrue(verified);

            DeleteCertificateOperation deleteOperation = client.StartDeleteCertificate(certificateName);
            while (!deleteOperation.HasCompleted)
            {
                deleteOperation.UpdateStatus();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            client.PurgeDeletedCertificate(certificateName);
        }
#endif
    }
}
