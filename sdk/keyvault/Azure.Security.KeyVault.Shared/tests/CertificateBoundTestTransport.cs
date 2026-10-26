// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    // Explicit test-only binding contract. Every bound send proves possession of the
    // pool's private-key copy before invoking the mock service; no live TLS is involved.
    internal sealed class CertificateBoundTestTransport : IDisposable
    {
        private readonly KeyVaultTransport.CertificateTransportPool _pool;
        internal HttpPipelineTransport Transport { get; }
        internal List<X509Certificate2> BoundCertificates { get; } = new();

        internal CertificateBoundTestTransport(MockTransport service)
        {
            _pool = new KeyVaultTransport.CertificateTransportPool(4, TimeSpan.FromMinutes(2), Timeout.InfiniteTimeSpan,
                certificate =>
                {
                    BoundCertificates.Add(certificate);
                    return new BoundTransport(service, certificate);
                }, () => DateTimeOffset.UtcNow);
            Transport = new KeyVaultTransport(service, _pool, true);
        }

        public void Dispose() => _pool.Dispose();

        private sealed class BoundTransport : HttpPipelineTransport
        {
            private readonly MockTransport _service;
            private readonly X509Certificate2 _certificate;
            internal BoundTransport(MockTransport service, X509Certificate2 certificate) { _service = service; _certificate = certificate; }
            public override Request CreateRequest() => _service.CreateRequest();

            private void Verify(HttpMessage message)
            {
                Assert.That(message.TryGetProperty(typeof(KeyVaultTransport.RequestAuthentication), out object value), Is.True);
                var authentication = (KeyVaultTransport.RequestAuthentication)value;
                Assert.That(authentication.Certificate.RawData, Is.EqualTo(_certificate.RawData));
                byte[] challenge = { 1, 2, 3, 4 };
                using RSA privateKey = _certificate.GetRSAPrivateKey();
                using RSA publicKey = authentication.Certificate.GetRSAPublicKey();
                byte[] signature = privateKey.SignData(challenge, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                Assert.That(publicKey.VerifyData(challenge, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1), Is.True);
            }

            public override void Process(HttpMessage message) { Verify(message); _service.Process(message); }
            public override ValueTask ProcessAsync(HttpMessage message) { Verify(message); return _service.ProcessAsync(message); }
        }
    }
}
