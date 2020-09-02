// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientTests : ClientTestBase
    {
        public CertificateClientTests(bool isAsync) : base(isAsync)
        {
            CertificateClientOptions options = new CertificateClientOptions
            {
                Transport = new MockTransport(),
            };

            Client = InstrumentClient(new CertificateClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public CertificateClient Client { get; }

        [Test]
        public void CreateIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateIssuerAsync(null));
            Assert.AreEqual("issuer", ex.ParamName);

            CertificateIssuer issuer = new CertificateIssuer();
            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateIssuerAsync(issuer));
            Assert.AreEqual("issuer", ex.ParamName);
            StringAssert.StartsWith("issuer.Name cannot be null or an empty string.", ex.Message);

            issuer = new CertificateIssuer("test");
            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.CreateIssuerAsync(issuer));
            Assert.AreEqual("issuer", ex.ParamName);
            StringAssert.StartsWith("issuer.Provider cannot be null or an empty string.", ex.Message);
        }

        [Test]
        public void GetIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetIssuerAsync(null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.GetIssuerAsync(string.Empty));
            Assert.AreEqual("issuerName", ex.ParamName);
            StringAssert.StartsWith("Value cannot be an empty string.", ex.Message);
        }

        [Test]
        public void UpdateIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateIssuerAsync(null));
            Assert.AreEqual("issuer", ex.ParamName);

            CertificateIssuer issuer = new CertificateIssuer();
            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateIssuerAsync(issuer));
            Assert.AreEqual("issuer", ex.ParamName);
            StringAssert.StartsWith("issuer.Name cannot be null or an empty string.", ex.Message);
        }

        [Test]
        public void DeleteIssuerArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.DeleteIssuerAsync(null));
            Assert.AreEqual("issuerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteIssuerAsync(string.Empty));
            Assert.AreEqual("issuerName", ex.ParamName);
        }

        [Test]
        public void SetContactsArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetContactsAsync(null));
            Assert.AreEqual("contacts", ex.ParamName);
        }

        [Test]
        public void GetCertificatePolicyArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetCertificatePolicyAsync(null));
            Assert.AreEqual("certificateName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.GetCertificatePolicyAsync(string.Empty));
            Assert.AreEqual("certificateName", ex.ParamName);
            StringAssert.StartsWith("Value cannot be an empty string.", ex.Message);
        }

        [Test]
        public void UpdateCertificatePolicyArgumentValidation()
        {
            CertificatePolicy policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=Azure SDK");

            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateCertificatePolicyAsync(null, policy));
            Assert.AreEqual("certificateName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateCertificatePolicyAsync(string.Empty, policy));
            Assert.AreEqual("certificateName", ex.ParamName);
            StringAssert.StartsWith("Value cannot be an empty string.", ex.Message);
        }

        [Test]
        public void ChallengeBasedAuthenticationRequiresHttps()
        {
            // After passing parameter validation, ChallengeBasedAuthenticationPolicy should throw for "http" requests.
            Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetCertificateAsync("test"));
        }
    }
}
