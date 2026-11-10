// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    /// <summary>
    /// Guards that a token is only accepted when it was issued by the attestation provider the caller trusts.
    /// </summary>
    /// <remarks>
    /// CertificateRequest and RSA.Create(int) are unavailable on .NET Framework 4.6.2.
    /// </remarks>
    public class AttestationTokenIssuerValidationTests
    {
        private const string ProviderA = "https://providera.attest.azure.net";
        private const string ProviderB = "https://providerb.attest.azure.net";

        private RSA _signingKey;
        private X509Certificate2 _providerACertificate;
        private X509Certificate2 _providerBCertificate;

        [SetUp]
        public void SetUp()
        {
            _signingKey = RSA.Create(2048);
            _providerACertificate = CreateCertificate(ProviderA);
            _providerBCertificate = CreateCertificate(ProviderB);
        }

        [TearDown]
        public void TearDown()
        {
            _providerACertificate.Dispose();
            _providerBCertificate.Dispose();
            _signingKey.Dispose();
        }

        [Test]
        public void TokenFromUnexpectedIssuerIsRejected()
        {
            AttestationToken token = SignedToken($"{{\"iss\":\"{ProviderA}\"}}");

            Exception ex = Assert.Throws<Exception>(() => token.ValidateToken(new AttestationTokenValidationOptions { ExpectedIssuer = ProviderB }, SignersFor(_providerBCertificate)));
            StringAssert.Contains("Unknown Issuer", ex.Message);
        }

        [Test]
        public void DefaultOptionsRequireExpectedIssuer()
        {
            AttestationToken token = SignedToken($"{{\"iss\":\"{ProviderA}\"}}");

            Assert.Throws<ArgumentNullException>(() => token.ValidateToken(new AttestationTokenValidationOptions(), SignersFor(_providerBCertificate)));
        }

        // A missing ExpectedIssuer is a caller error, so it is reported before the token is examined, whatever the token.
        [TestCase("untrusted signer")]
        [TestCase("no alg")]
        [TestCase("unsigned")]
        public void MissingExpectedIssuerIsReportedBeforeTheToken(string kind)
        {
            using RSA otherKey = RSA.Create(2048);
            using X509Certificate2 otherCertificate = new CertificateRequest($"CN={ProviderA}", otherKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                .CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));
            AttestationToken token = kind switch
            {
                "untrusted signer" => AttestationToken.Deserialize(new AttestationToken(
                    BinaryData.FromString($"{{\"iss\":\"{ProviderA}\"}}"), new AttestationTokenSigningKey(otherKey, otherCertificate)).Serialize()),
                "no alg" => AttestationToken.Deserialize(Base64Url.EncodeString("{\"typ\":\"JWT\"}") + "." + Base64Url.EncodeString($"{{\"iss\":\"{ProviderA}\"}}") + "." + Base64Url.Encode(new byte[] { 1 })),
                _ => AttestationToken.Deserialize(new AttestationToken(BinaryData.FromString($"{{\"iss\":\"{ProviderA}\"}}")).Serialize()),
            };

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => token.ValidateToken(new AttestationTokenValidationOptions(), SignersFor(_providerACertificate)));
            Assert.AreEqual("options.ExpectedIssuer", ex.ParamName);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await token.ValidateTokenAsync(new AttestationTokenValidationOptions(), SignersFor(_providerACertificate)));
        }

        [Test]
        public void IssuerOptionsAreIgnoredWhenValidationIsDisabled()
        {
            AttestationToken token = AttestationToken.Deserialize(new AttestationToken(BinaryData.FromString($"{{\"iss\":\"{ProviderA}\"}}")).Serialize());

            Assert.IsTrue(token.ValidateToken(new AttestationTokenValidationOptions { ValidateToken = false }, null));
        }

        [TestCase(ProviderA)]
        [TestCase(ProviderA + "/")]
        [TestCase("HTTPS://PROVIDERA.ATTEST.AZURE.NET")]
        public void MatchingIssuerIsAccepted(string expectedIssuer)
        {
            AttestationToken token = SignedToken($"{{\"iss\":\"{ProviderA}\"}}");

            Assert.IsTrue(token.ValidateToken(new AttestationTokenValidationOptions { ExpectedIssuer = expectedIssuer }, SignersFor(_providerACertificate)));
        }

        [Test]
        public void TokenWithoutIssuerIsRejected()
        {
            AttestationToken token = SignedToken("{\"x-ms-attestation-type\":\"sgx\"}");

            Assert.Throws<Exception>(() => token.ValidateToken(new AttestationTokenValidationOptions { ExpectedIssuer = ProviderA }, SignersFor(_providerACertificate)));
        }

        [Test]
        public void IssuerValidationCanBeDisabled()
        {
            AttestationToken token = SignedToken($"{{\"iss\":\"{ProviderA}\"}}");

            Assert.IsTrue(token.ValidateToken(new AttestationTokenValidationOptions { ValidateIssuer = false }, SignersFor(_providerBCertificate)));
        }

        [TestCase(ProviderA)]
        [TestCase(ProviderA + "/")]
        public void ClientAcceptsTokenFromItsEndpoint(string endpoint)
        {
            var client = new AttestationClient(new Uri(endpoint), new MockCredential(), ClientOptions(ProviderA, _providerACertificate));

            Assert.AreEqual("sgx", client.AttestSgxEnclave(Request()).Value.VerifierType);
        }

        [Test]
        public void ClientRejectsTokenFromUnexpectedIssuer()
        {
            var client = new AttestationClient(new Uri(ProviderB), new MockCredential(), ClientOptions(ProviderA, _providerBCertificate));

            Exception ex = Assert.Throws<Exception>(() => client.AttestSgxEnclave(Request()));
            StringAssert.Contains("Unknown Issuer", ex.Message);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ConfidentialVmAttestationChecksIssuer(bool tdx)
        {
            var trusted = new AttestationClient(new Uri(ProviderA), new MockCredential(), ClientOptions(ProviderA, _providerACertificate));
            var otherProvider = new AttestationClient(new Uri(ProviderB), new MockCredential(), ClientOptions(ProviderA, _providerBCertificate));

            Assert.AreEqual("sgx", (tdx ? trusted.AttestTdxVm(Request()) : trusted.AttestSevSnpVm(Request())).Value.VerifierType);
            Exception ex = Assert.Throws<Exception>(() => _ = tdx ? otherProvider.AttestTdxVm(Request()) : otherProvider.AttestSevSnpVm(Request()));
            StringAssert.Contains("Unknown Issuer", ex.Message);
        }

        [Test]
        public void AdministrationClientRejectsTokenFromUnexpectedIssuer()
        {
            var client = new AttestationAdministrationClient(new Uri(ProviderB), new MockCredential(), ClientOptions(ProviderA, _providerBCertificate));

            Exception ex = Assert.Throws<Exception>(() => client.GetPolicy(AttestationType.SgxEnclave));
            StringAssert.Contains("Unknown Issuer", ex.Message);
        }

        [Test]
        public void ClientHonorsExplicitExpectedIssuer()
        {
            AttestationClientOptions options = ClientOptions(ProviderA, _providerBCertificate, new AttestationTokenValidationOptions { ExpectedIssuer = ProviderA });
            var client = new AttestationClient(new Uri(ProviderB), new MockCredential(), options);

            Assert.AreEqual("sgx", client.AttestSgxEnclave(Request()).Value.VerifierType);
        }

        [Test]
        public void ClientDoesNotModifySharedOptions()
        {
            AttestationClientOptions options = ClientOptions(ProviderA, _providerACertificate);

            new AttestationClient(new Uri(ProviderA), new MockCredential(), options).AttestSgxEnclave(Request());

            Assert.IsNull(options.TokenOptions.ExpectedIssuer);
        }

        private X509Certificate2 CreateCertificate(string provider)
            => new CertificateRequest($"CN={provider}", _signingKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                .CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));

        private AttestationToken SignedToken(string body)
            => AttestationToken.Deserialize(new AttestationToken(BinaryData.FromString(body), new AttestationTokenSigningKey(_signingKey, _providerACertificate)).Serialize());

        private static IReadOnlyList<AttestationSigner> SignersFor(X509Certificate2 certificate)
            => new[] { new AttestationSigner(new[] { certificate }, "signer") };

        private static AttestationRequest Request() => new AttestationRequest { Evidence = BinaryData.FromBytes(new byte[] { 1 }) };

        // The service returns a token issued by tokenIssuer, and publishes signingCertificate from its /certs endpoint.
        private AttestationClientOptions ClientOptions(string tokenIssuer, X509Certificate2 signingCertificate, AttestationTokenValidationOptions tokenOptions = null)
        {
            string storedPolicy = new AttestationToken(BinaryData.FromString("{\"AttestationPolicy\":\"cG9saWN5\"}")).Serialize();
            string token = new AttestationToken(
                BinaryData.FromString($"{{\"iss\":\"{tokenIssuer}\",\"x-ms-attestation-type\":\"sgx\",\"x-ms-policy\":\"{storedPolicy}\"}}"),
                new AttestationTokenSigningKey(_signingKey, _providerACertificate)).Serialize();
            string jwks = $"{{\"keys\":[{{\"kty\":\"RSA\",\"kid\":\"signer\",\"x5c\":[\"{Convert.ToBase64String(signingCertificate.Export(X509ContentType.Cert))}\"]}}]}}";

            return new AttestationClientOptions(tokenOptions: tokenOptions)
            {
                Transport = new MockTransport(request => new MockResponse(200).SetContent(
                    request.Uri.Path.EndsWith("/certs", StringComparison.Ordinal) ? jwks : $"{{\"token\":\"{token}\"}}")),
            };
        }
    }
}
#endif
