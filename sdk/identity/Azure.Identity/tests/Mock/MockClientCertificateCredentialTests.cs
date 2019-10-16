﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Identity.Tests.Mock
{
    public class MockClientCertificateCredentialTests
    {
        [Test]
        public void VerifyCtorErrorHandling()
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
            var clientCertificate = new X509Certificate2(certificatePath, "password");

            var tenantId = Guid.NewGuid().ToString();

            var clientId = Guid.NewGuid().ToString();

            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(null, clientId, clientCertificate));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, null, clientCertificate));
            Assert.Throws<ArgumentNullException>(() => new ClientCertificateCredential(tenantId, clientId, null));
        }
    }
}
