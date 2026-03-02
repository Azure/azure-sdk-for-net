// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class X509Certificate2FromPathProviderTests
    {
        [Test]
        public async ValueTask ValidateCertPathParsing([Values] bool async)
        {
            var certProvider = new X509Certificate2FromPathProvider("cert:/myStoreLocation/My/THUMBPRINT", null);
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await certProvider.GetCertificateAsync(async, default));
            StringAssert.Contains("Invalid store location 'myStoreLocation' specified in certificate path. Valid values are: CurrentUser, LocalMachine", ex.Message);
        }

        [Test]
        public async ValueTask ValidateCertPathNoPassword([Values] bool async)
        {
            var certProvider = new X509Certificate2FromPathProvider("cert:/CurrentUSER/My/THUMBPRINT", "password");
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await certProvider.GetCertificateAsync(async, default));
            StringAssert.Contains("Password protection for certificates from the certificate store is not supported.", ex.Message);
        }

        [Test]
        public async ValueTask ValidateCertPathNotFound([Values] bool async)
        {
            var certProvider = new X509Certificate2FromPathProvider("CERT:\\CURRENTUSER\\My\\THUMBPRINT", null);
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await certProvider.GetCertificateAsync(async, default));
            StringAssert.Contains("No certificate found in CurrentUser/My store with thumbprint THUMBPRINT", ex.Message);
        }

        #if NET472_OR_GREATER
        // CertificateRequest introduced in .net4.7.2
        [Test]
        public async ValueTask ValidateCertPathLoad([Values] bool async)
        {
            using X509Store store = new(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            using X509Certificate2 cert = new CertificateRequest($"CN=X509Certificate2FromPathProviderTests-ValidateCertPathLoad-{Guid.NewGuid()}", RSA.Create(2048), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                .CreateSelfSigned(DateTimeOffset.UnixEpoch, DateTimeOffset.UnixEpoch);

            Assert.IsNotEmpty(cert.Thumbprint, "created test certificate should have thumbprint");
            Assert.IsTrue(cert.HasPrivateKey, "created test cert should have private key");
            store.Add(cert);

            try
            {
                X509Certificate2FromPathProvider certProvider = new($"cert:/CurrentUser/My/{cert.Thumbprint}", null);
                using (X509Certificate2 foundCert = await certProvider.GetCertificateAsync(async, default))
                {
                    Assert.NotNull(foundCert, "Certificate should be found in store");
                    Assert.AreEqual(foundCert.Thumbprint, cert.Thumbprint, "Thumbprint of found certificate should match expected");
                    Assert.IsTrue(foundCert.HasPrivateKey, "Certificate loaded from store should have private key");
                }
            }
            finally
            {
                store.Remove(cert);
            }
        }
        #endif

        [Test]
        public async Task ValidatePemCertificateLoad([Values] bool async)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");

            var certProvider = new X509Certificate2FromPathProvider(certificatePath, null);

            var cert = await certProvider.GetCertificateAsync(async, default);

            Assert.NotNull(cert);
        }

        [Test]
        public void ValidatePemCertificateLoadFailsWithPassword([Values] bool async)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");

            var certProvider = new X509Certificate2FromPathProvider(certificatePath, "password");

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await certProvider.GetCertificateAsync(async, default));

            StringAssert.Contains("Password protection for PEM encoded certificates is not supported.", ex.Message);
        }

        [Test]
        public async Task ValidatePfxCertificateLoad([Values] bool async, [Values(null, "password")] string password)
        {
            var certificatePath = password == null ? Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx") : Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-password-protected.pfx");

            var certProvider = new X509Certificate2FromPathProvider(certificatePath, password);

            var cert = await certProvider.GetCertificateAsync(async, default);

            Assert.NotNull(cert);
        }
    }
}
