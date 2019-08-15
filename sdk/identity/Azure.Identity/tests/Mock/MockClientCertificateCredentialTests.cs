using NUnit.Framework;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Identity.Tests.Mock
{
    public class MockClientCertificateCredentialTests
    {
        [Test]
        public void VerifyCtorErrorHandling()
        {
            var clientCertificate = new X509Certificate2(@"./Data/cert.pfx", "password");

            var tenantId = Guid.NewGuid().ToString();

            var clientId = Guid.NewGuid().ToString();

            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(null, clientId, clientCertificate));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, null, clientCertificate));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, clientId, null));
        }
    }
}
