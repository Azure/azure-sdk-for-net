// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Testing;
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
        [Ignore("SetContactsAsync() should assert empty!")]
        public void SetContactsArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetContactsAsync(null));
            Assert.AreEqual("contacts", ex.ParamName);

            // This test got very stranged.
            var contacts = new List<CertificateContact>();
            //Assert.IsNull(contacts);
            ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetContactsAsync(contacts));
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
        [Ignore("Policy should set argument validation!")]
        public void UpdateCertificatePolicyArgumentValidation()
        {
            ArgumentException ex = Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateCertificatePolicyAsync("test", null));
            Assert.AreEqual("certificateName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => Client.UpdateCertificatePolicyAsync(string.Empty, null));
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
