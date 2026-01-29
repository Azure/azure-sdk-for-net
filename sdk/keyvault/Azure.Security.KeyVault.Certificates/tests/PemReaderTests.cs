// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public partial class PemReaderTests
    {
        [Test]
        public void LoadCertificate()
        {
#if NET462
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa);
            Assert.That(certificate.Subject, Is.EqualTo("CN=Azure SDK"));
            Assert.That(certificate.HasPrivateKey, Is.True);
        }

        [Test]
        public void LoadCertificateAutomatically()
        {
#if NET462
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan());
            Assert.That(certificate.Subject, Is.EqualTo("CN=Azure SDK"));
            Assert.That(certificate.HasPrivateKey, Is.True);
        }

        [Test]
        public void LoadCertificateWithPublicKey()
        {
#if NET462
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(ECDsaPrivateKey.AsSpan(), cer: s_ecdsaCertificateBytes, keyType: PemReader.KeyType.ECDsa);
            Assert.That(certificate.Subject, Is.EqualTo("CN=Azure SDK"));
            Assert.That(certificate.HasPrivateKey, Is.True);
        }

        [Test]
        public void LoadCertificateWithoutPublicKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(ECDsaPrivateKey.AsSpan(), keyType: PemReader.KeyType.ECDsa));
            Assert.That(ex.Message, Is.EqualTo("The certificate is missing the public key"));
        }

        [Test]
        public void LoadCertificateWithoutPrivateKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa));
            Assert.That(ex.Message, Is.EqualTo("The certificate is missing the private key"));
        }

        [Test]
        public void LoadCertificateWithOnlyPublicKeyAllowed()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), allowCertificateOnly: true, keyType: PemReader.KeyType.ECDsa);
            Assert.That(certificate.Subject, Is.EqualTo("CN=Azure SDK"));
            Assert.That(certificate.HasPrivateKey, Is.False);
        }

        [Test]
        public void LoadCertificateWithNoKeys()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(Span<char>.Empty, keyType: PemReader.KeyType.ECDsa));
            Assert.That(ex.Message, Is.EqualTo("The certificate is missing the public key"));
        }

        [Test]
        public void LoadCertificatePemOverridesCer()
        {
#if !NET47_OR_GREATER && !NET
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan(), cer: Encoding.UTF8.GetBytes("This is not a certificate"), keyType: PemReader.KeyType.ECDsa);
            Assert.That(certificate.Subject, Is.EqualTo("CN=Azure SDK"));
            Assert.That(certificate.HasPrivateKey, Is.True);
        }

        [Test]
        public void LoadRSACertificate()
        {
#if !NETCOREAPP3_0_OR_GREATER
            // Compatible with previous release. Goes through the LightweightPkcs8Decoder.DecodeECDsaPkcs8().
            Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(RSACertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa));
#else
            // Compatible with the previous release. Goes through RSA.ImportPKcs8PrivateKey().
            Assert.That<X509Certificate2>(() => PemReader.LoadCertificate(RSACertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa), Throws.InstanceOf<CryptographicException>());
#endif
        }

        [Test]
        public void LoadECDsaPrime256v1Certificate()
        {
#if !NET47_OR_GREATER && !NET
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa);
            Assert.That(certificate.Subject, Is.EqualTo("CN=Azure SDK"));
            Assert.That(certificate.HasPrivateKey, Is.True);
        }
    }
}
