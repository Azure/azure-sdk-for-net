// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    /// <summary>
    /// Guards that a token is only accepted when one of the signers the caller trusts signed it, and that certificates
    /// carried in the token are never trusted or loaded from anywhere but the token.
    /// </summary>
    public class AttestationTokenSignerValidationTests
    {
        private const string Provider = "https://provider.attest.azure.net";

        // A public-only, self-signed ECDSA certificate, so these tests also run on .NET Framework.
        private const string EmbeddedCertificate =
            "MIIBMDCB16ADAgECAgkAv8Zx3o56o10wCgYIKoZIzj0EAwIwHjEcMBoGA1UEAxMTTG9jYWxBdWRpdCBYNWMgVGVzdDAeFw0yNjAxMDEwMDAwMDBaFw0zNjAxMDEwMDAwMDBaMB4xHDAaBgNVBAMTE0xvY2FsQXVkaXQgWDVjIFRlc3QwWTATBgcqhkjOPQIBBggqhkjOPQMBBwNCAARAQ4p8qjRKdJuf72WM3RlSz7SVyHnuJH5wkYgiiHmNztkokfYknqS23cYW3MNg/Luk6w292Roh+tHRrkdHdUYyMAoGCCqGSM49BAMCA0gAMEUCIGw6mPMM98nJH6841GPj7JZmevrDFvHfzpg+z01RvhCXAiEAwZYt7oy+yPuosSUDKwndhUZxmVsRHpWPtADytFcdbY4=";
        private const string EmbeddedCertificateThumbprint = "F81481D46F8E77E37007D70DA7E27A0762A7CA96";

        [Test]
        public void X509CertificateChainDecodesHeaderCertificates()
        {
            AttestationToken token = UnsignedToken(new Dictionary<string, object> { ["alg"] = "RS256", ["x5c"] = new[] { EmbeddedCertificate } });

            X509Certificate2[] chain = token.X509CertificateChain;

            Assert.AreEqual(1, chain.Length);
            Assert.AreEqual(EmbeddedCertificateThumbprint, chain[0].Thumbprint);
        }

        [Test]
        public void X509CertificateChainDoesNotLoadFiles()
        {
            string path = Path.Combine(Path.GetTempPath(), $"attestation-x5c-{Guid.NewGuid():N}.cer");
            File.WriteAllBytes(path, Convert.FromBase64String(EmbeddedCertificate));
            try
            {
                AttestationToken token = UnsignedToken(new Dictionary<string, object> { ["alg"] = "RS256", ["x5c"] = new[] { path } });

                Assert.Throws<FormatException>(() => _ = token.X509CertificateChain);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Test]
        public void X509CertificateChainIsEmptyWithoutHeaderCertificates()
        {
            AttestationToken token = UnsignedToken(new Dictionary<string, object> { ["alg"] = "RS256" });

            Assert.IsEmpty(token.X509CertificateChain);
        }

        // Only the header is read, so the body and signature are placeholders.
        private static AttestationToken UnsignedToken(Dictionary<string, object> header)
            => AttestationToken.Deserialize(
                Base64Url.Encode(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header))) + "." +
                Base64Url.Encode(Encoding.UTF8.GetBytes("{}")) + "." +
                Base64Url.Encode(new byte[] { 1 }));

#if NET6_0_OR_GREATER
        // CertificateRequest and RSA.Create(int) are unavailable on .NET Framework 4.6.2.
        private RSA _trustedKey;
        private RSA _untrustedKey;
        private X509Certificate2 _trustedCertificate;
        private X509Certificate2 _untrustedCertificate;

        [SetUp]
        public void SetUp()
        {
            _trustedKey = RSA.Create(2048);
            _untrustedKey = RSA.Create(2048);
            _trustedCertificate = CreateCertificate("CN=Trusted", _trustedKey);
            _untrustedCertificate = CreateCertificate("CN=Untrusted", _untrustedKey);
        }

        [TearDown]
        public void TearDown()
        {
            _trustedCertificate?.Dispose();
            _untrustedCertificate?.Dispose();
            _trustedKey?.Dispose();
            _untrustedKey?.Dispose();
        }

        [Test]
        public void TokenSignedByTrustedSignerIsAccepted()
        {
            AttestationToken token = SignedToken(_trustedKey, Header(kid: null, x5c: _trustedCertificate));

            Assert.IsTrue(token.ValidateToken(Options(), Signers(_trustedCertificate, null)));
            Assert.AreEqual(_trustedCertificate.Thumbprint, token.CertificateThumbprint);
        }

        [TestCase(null)]
        [TestCase("untrusted")]
        public void TokenCannotVouchForItselfWithoutSigners(string kid)
        {
            AttestationToken token = SignedToken(_untrustedKey, Header(kid, x5c: _untrustedCertificate));

            Assert.Throws<ArgumentNullException>(() => token.ValidateToken(Options(), null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await token.ValidateTokenAsync(Options(), null));
            Assert.IsNull(token.SigningCertificate);
        }

        [Test]
        public void EmptySignersAreRejected()
        {
            AttestationToken token = SignedToken(_untrustedKey, Header(kid: null, x5c: _untrustedCertificate));

            Assert.Throws<ArgumentException>(() => token.ValidateToken(Options(), Array.Empty<AttestationSigner>()));
            Assert.Throws<ArgumentException>(() => token.ValidateToken(Options(), new List<AttestationSigner>()));
        }

        [Test]
        public void HeaderCertificatesAreNotTrusted()
        {
            AttestationToken token = SignedToken(_untrustedKey, Header(kid: null, x5c: _untrustedCertificate));

            Exception ex = Assert.Throws<Exception>(() => token.ValidateToken(Options(), Signers(_trustedCertificate, null)));
            StringAssert.Contains("Could not find a certificate which was used to sign the token", ex.Message);
            Assert.IsNull(token.SigningCertificate);
        }

        [Test]
        public void HeaderJsonWebKeyIsNotTrusted()
        {
            string jwk = $"{{\"kty\":\"RSA\",\"kid\":\"untrusted\",\"x5c\":[\"{Encode(_untrustedCertificate)}\"]}}";
            AttestationToken token = SignedToken(_untrustedKey, $"{{\"alg\":\"RS256\",\"kid\":\"untrusted\",\"jwk\":{jwk}}}");

            Exception ex = Assert.Throws<Exception>(() => token.ValidateToken(Options(), Signers(_trustedCertificate, "trusted")));
            StringAssert.Contains("Unable to find any certificates", ex.Message);
        }

        [TestCase("http://provider.attest.azure.net")]
        [TestCase("HTTP://provider.attest.azure.net")]
        public void ClientsRequireHttps(string endpoint)
        {
            Assert.Throws<ArgumentException>(() => new AttestationClient(new Uri(endpoint), null));
            Assert.Throws<ArgumentException>(() => new AttestationClient(new Uri(endpoint), new MockCredential()));
            Assert.Throws<ArgumentException>(() => new AttestationAdministrationClient(new Uri(endpoint), new MockCredential()));
        }

        [Test]
        public void AnonymousClientAcceptsHttps()
        {
            Assert.DoesNotThrow(() => new AttestationClient(new Uri("HTTPS://provider.attest.azure.net"), null));
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        public void AnyHandlerCanRejectToken(bool first, bool second, bool accepted)
        {
            var observedDefaults = new List<bool>();
            var tokenOptions = new AttestationTokenValidationOptions();
            tokenOptions.TokenValidated += args =>
            {
                observedDefaults.Add(args.IsValid);
                args.IsValid = first;
                return Task.CompletedTask;
            };
            tokenOptions.TokenValidated += args =>
            {
                observedDefaults.Add(args.IsValid);
                args.IsValid = second;
                return Task.CompletedTask;
            };
            var client = new AttestationClient(new Uri(Provider), new MockCredential(), ClientOptions(tokenOptions));
            var request = new AttestationRequest { Evidence = BinaryData.FromBytes(new byte[] { 1 }) };

            if (accepted)
            {
                Assert.AreEqual("sgx", client.AttestSgxEnclave(request).Value.VerifierType);
            }
            else
            {
                Assert.Throws<AttestationTokenValidationFailedException>(() => client.AttestSgxEnclave(request));
            }
            CollectionAssert.AreEqual(new[] { true, true }, observedDefaults);
        }

        private AttestationClientOptions ClientOptions(AttestationTokenValidationOptions tokenOptions)
        {
            string storedPolicy = new AttestationToken(BinaryData.FromString("{\"AttestationPolicy\":\"cG9saWN5\"}")).Serialize();
            string token = new AttestationToken(
                BinaryData.FromString($"{{\"iss\":\"{Provider}\",\"x-ms-attestation-type\":\"sgx\",\"x-ms-policy\":\"{storedPolicy}\"}}"),
                new AttestationTokenSigningKey(_trustedKey, _trustedCertificate)).Serialize();
            string jwks = $"{{\"keys\":[{{\"kty\":\"RSA\",\"kid\":\"trusted\",\"x5c\":[\"{Encode(_trustedCertificate)}\"]}}]}}";

            return new AttestationClientOptions(tokenOptions: tokenOptions)
            {
                Transport = new MockTransport(request => new MockResponse(200).SetContent(
                    request.Uri.Path.EndsWith("/certs", StringComparison.Ordinal) ? jwks : $"{{\"token\":\"{token}\"}}")),
            };
        }

        private static X509Certificate2 CreateCertificate(string subject, RSA key)
            => new CertificateRequest(subject, key, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                .CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));

        private static string Encode(X509Certificate2 certificate) => Convert.ToBase64String(certificate.Export(X509ContentType.Cert));

        private static string Header(string kid, X509Certificate2 x5c)
            => kid == null
                ? $"{{\"alg\":\"RS256\",\"x5c\":[\"{Encode(x5c)}\"]}}"
                : $"{{\"alg\":\"RS256\",\"kid\":\"{kid}\",\"x5c\":[\"{Encode(x5c)}\"]}}";

        private static AttestationTokenValidationOptions Options() => new AttestationTokenValidationOptions { ExpectedIssuer = Provider };

        private static IReadOnlyList<AttestationSigner> Signers(X509Certificate2 certificate, string kid)
            => new[] { new AttestationSigner(new[] { certificate }, kid) };

        private static AttestationToken SignedToken(RSA key, string headerJson)
        {
            string signedData = Base64Url.Encode(Encoding.UTF8.GetBytes(headerJson)) + "." + Base64Url.Encode(Encoding.UTF8.GetBytes($"{{\"iss\":\"{Provider}\"}}"));
            byte[] signature = key.SignData(Encoding.UTF8.GetBytes(signedData), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return AttestationToken.Deserialize(signedData + "." + Base64Url.Encode(signature));
        }
#endif
    }
}
