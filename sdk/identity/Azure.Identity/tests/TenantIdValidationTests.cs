// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TenantIdValidationTests
    {
        [Test]
        public void AuthorizationCodeCredential([Values(null, "", "invalid?character")] string tenantId)
        {
            string clientId = Guid.NewGuid().ToString();
            string clientSecret = Guid.NewGuid().ToString();
            string authCode = Guid.NewGuid().ToString();

            var ex = Assert.Catch<ArgumentException>(() => new AuthorizationCodeCredential(tenantId, clientId, clientSecret, authCode));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new AuthorizationCodeCredential(tenantId, clientId, clientSecret, authCode, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);
        }

        [Test]
        public void ClientCertificateCredential([Values(null, "", "invalid?character")] string tenantId)
        {
            var clientId = Guid.NewGuid().ToString();

            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");

            var ex = Assert.Catch<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificatePath));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificatePath, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificatePath, new ClientCertificateCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

#if NET9_0_OR_GREATER
            var certificate = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var certificate = new X509Certificate2(certificatePath);
#endif

            ex = Assert.Catch<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificate));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificate, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificate, new ClientCertificateCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);
        }
        [Test]
        public void ClientSecretCredential([Values(null, "", "invalid?character")] string tenantId)
        {
            var clientId = Guid.NewGuid().ToString();

            var secret = Guid.NewGuid().ToString();

            var ex = Assert.Catch<ArgumentException>(() => new ClientSecretCredential(tenantId, clientId, secret));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new ClientSecretCredential(tenantId, clientId, secret, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new ClientSecretCredential(tenantId, clientId, secret, new ClientSecretCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);
        }

        [Test]
        public void DeviceCodeCredentialOptionsInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var options = new DeviceCodeCredentialOptions();

            var ex = Assert.Catch<ArgumentException>(() => options.TenantId = tenantId);

            ValidateTenantIdArgumentException(tenantId, null, ex);
        }

        [Test]
        public void DeviceCodeCredentialOptionsNullTenantId()
        {
            var options = new DeviceCodeCredentialOptions();

            // validate no exception is thrown when setting TenantId to null
            options.TenantId = null;
        }

        [Test]
        public void DeviceCodeCredentialCtorInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var clientId = Guid.NewGuid().ToString();

            var ex = Assert.Catch<ArgumentException>(() => new DeviceCodeCredential(DeviceCodeCredential.DefaultDeviceCodeHandler, tenantId, clientId));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new DeviceCodeCredential(DeviceCodeCredential.DefaultDeviceCodeHandler, tenantId, clientId, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);
        }

        [Test]
        public void DeviceCodeCredentialCtorNullTenantId()
        {
            var clientId = Guid.NewGuid().ToString();

            // validate no exception is thrown when setting TenantId to null
            var cred = new DeviceCodeCredential(DeviceCodeCredential.DefaultDeviceCodeHandler, null, clientId);

            cred = new DeviceCodeCredential(DeviceCodeCredential.DefaultDeviceCodeHandler, null, clientId, new TokenCredentialOptions());
        }

        [Test]
        public void InteractiveBrowserCredentialOptionsInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var options = new InteractiveBrowserCredentialOptions();

            var ex = Assert.Catch<ArgumentException>(() => options.TenantId = tenantId);

            ValidateTenantIdArgumentException(tenantId, null, ex);
        }

        [Test]
        public void InteractiveBrowserCredentialOptionsNullTenantId()
        {
            var options = new InteractiveBrowserCredentialOptions();

            // validate no exception is thrown when setting TenantId to null
            options.TenantId = null;
        }

        [Test]
        public void InteractiveBrowserCredentialCtorInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var clientId = Guid.NewGuid().ToString();

            var ex = Assert.Catch<ArgumentException>(() => new InteractiveBrowserCredential(tenantId, clientId));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new InteractiveBrowserCredential(tenantId, clientId, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);
        }

        [Test]
        public void InteractiveBrowserCredentialCtorNullTenantId()
        {
            var clientId = Guid.NewGuid().ToString();

            // validate no exception is thrown when setting TenantId to null
            var cred = new InteractiveBrowserCredential(null, clientId);

            cred = new InteractiveBrowserCredential(null, clientId, new TokenCredentialOptions());
        }

        [Test]
        public void SharedTokenCacheCredentialOptionsInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var options = new SharedTokenCacheCredentialOptions();

            var ex = Assert.Catch<ArgumentException>(() => options.TenantId = tenantId);

            ValidateTenantIdArgumentException(tenantId, null, ex);
        }

        [Test]
        public void SharedTokenCacheCredentialOptionsNullTenantId()
        {
            var options = new SharedTokenCacheCredentialOptions();

            // validate no exception is thrown when setting TenantId to null
            options.TenantId = null;
        }

        [Test]
        public void UsernamePasswordCredential([Values(null, "", "invalid?character")] string tenantId)
        {
            var username = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();

            var ex = Assert.Catch<ArgumentException>(() => new UsernamePasswordCredential(username, password, tenantId, clientId));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new UsernamePasswordCredential(username, password, tenantId, clientId, new TokenCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);

            ex = Assert.Catch<ArgumentException>(() => new UsernamePasswordCredential(username, password, tenantId, clientId, new UsernamePasswordCredentialOptions()));

            ValidateTenantIdArgumentException(tenantId, "tenantId", ex);
        }

        [Test]
        public void VisualStudioCredentialOptionsInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var options = new VisualStudioCredentialOptions();

            var ex = Assert.Catch<ArgumentException>(() => options.TenantId = tenantId);

            ValidateTenantIdArgumentException(tenantId, null, ex);
        }

        [Test]
        public void VisualStudioCredentialOptionsNullTenantId()
        {
            var options = new VisualStudioCredentialOptions();

            // validate no exception is thrown when setting TenantId to null
            options.TenantId = null;
        }

        [Test]
        public void VisualStudioCodeCredentialOptionsInvalidTenantId([Values("", "invalid?character")] string tenantId)
        {
            var options = new VisualStudioCodeCredentialOptions();

            var ex = Assert.Catch<ArgumentException>(() => options.TenantId = tenantId);

            ValidateTenantIdArgumentException(tenantId, null, ex);
        }

        [Test]
        public void VisualStudioCodeCredentialOptionsNullTenantId()
        {
            var options = new VisualStudioCodeCredentialOptions();

            // validate no exception is thrown when setting TenantId to null
            options.TenantId = null;
        }

        private void ValidateTenantIdArgumentException(string tenantId, string argumentName, ArgumentException ex)
        {
            Assert.AreEqual(argumentName, ex.ParamName);

            if (tenantId == null)
            {
                Assert.True(ex is ArgumentNullException);
            }
        }
    }
}
