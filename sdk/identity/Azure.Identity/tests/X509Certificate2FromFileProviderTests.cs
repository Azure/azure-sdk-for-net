// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class X509Certificate2FromFileProviderTests
    {
        [Test]
        public async Task ValidatePemCertificateLoad([Values] bool async)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");

            var certProvider = new X509Certificate2FromFileProvider(certificatePath, null);

            var cert = await certProvider.GetCertificateAsync(async, default);

            Assert.That(cert, Is.Not.Null);
        }

        [Test]
        public void ValidatePemCertificateLoadFailsWithPassword([Values] bool async)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");

            var certProvider = new X509Certificate2FromFileProvider(certificatePath, "password");

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await certProvider.GetCertificateAsync(async, default));

            Assert.That(ex.Message, Does.Contain("Password protection for PEM encoded certificates is not supported."));
        }

        [Test]
        public async Task ValidatePfxCertificateLoad([Values] bool async, [Values(null, "password")] string password)
        {
            var certificatePath = password == null ? Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx") : Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-password-protected.pfx");

            var certProvider = new X509Certificate2FromFileProvider(certificatePath, password);

            var cert = await certProvider.GetCertificateAsync(async, default);

            Assert.That(cert, Is.Not.Null);
        }
    }
}
