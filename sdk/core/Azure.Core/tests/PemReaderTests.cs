// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public partial class PemReaderTests
    {
        [TestCaseSource(nameof(LineEndings))]
        public void ReadsCertificate(string lineEnding)
        {
            string pem =
$"-----BEGIN CERTIFICATE-----{lineEnding}" +
$"MIIDCDCCAfCgAwIBAgIUB9Mxn1KLNBaTKu6pYdn3W1EBvWkwDQYJKoZIhvcNAQEL{lineEnding}" +
$"BQAwFDESMBAGA1UEAwwJQXp1cmUgU0RLMB4XDTIxMDIwNDE5MzUzNVoXDTIxMTAy{lineEnding}" +
$"NzE5MzUzNVowFDESMBAGA1UEAwwJQXp1cmUgU0RLMIIBIjANBgkqhkiG9w0BAQEF{lineEnding}" +
$"AAOCAQ8AMIIBCgKCAQEA20VE95MMlyn7yu76XmEPBV5Gj7Sn0BzavGTYc497HXRp{lineEnding}" +
$"y4Ec8edX5C6u7QpO+eQOVlFAbeyIg1/IMGdod8Quarx11mqCyBhXVlStrjqoNTIo{lineEnding}" +
$"00OA9EFrWjka2ZYrLxlnS6k/w2k18nQE+FP63DIX1OkXU3TxHfVhZWwHgObq5jWz{lineEnding}" +
$"x4EjG37hnYSJknAB/71N9f2g63cUM28HcGDfMzNrEhbk+TpFfGg3rZiosHybDyDH{lineEnding}" +
$"x88jTxRxFYBiaWQpNOzZA+M9XUeUK3rdxOfj5JL8ExWGuPMj9QNKGcKkccrLoMtM{lineEnding}" +
$"5hFP9R8f9nBeeYrmAUsZwU7HWUfaTzWH4goWfZRFQQIDAQABo1IwUDAJBgNVHRME{lineEnding}" +
$"AjAAMAsGA1UdDwQEAwIF4DATBgNVHSUEDDAKBggrBgEFBQcDATAhBgNVHREEGjAY{lineEnding}" +
$"gRZhenVyZXNka0BtaWNyb3NvZnQuY29tMA0GCSqGSIb3DQEBCwUAA4IBAQAbUn/U{lineEnding}" +
$"IrlqGYv417Zwx00VEKOsis3Hafof6KjxQKzHwhNZ2EhLSNIRPrzK3ITbR2f0ZoCO{lineEnding}" +
$"J5RnL11/KiLA1C9i38aAiekMxxYYikVWkpQHc3BB85v+lhSm5cuSvrdVeTcCXDTA{lineEnding}" +
$"rJUjjPW4aQuo0GyzL4v1M1U2pByKsVCYAikuLmQKS2zXLoyW3ana1aQYyh2/3cXm{lineEnding}" +
$"lkApwUZg00+9hRWxv0DTh/mRS2zu5i/9W+cZbIcRah0JHgOzAjvsyY9RHjqZ9r7c{lineEnding}" +
$"Md7RrFHxnAKJj5TZJJJOf5h3OaaF3A5W8gf9Bc68aGQLFT5Y2afIawkYNSULypc3{lineEnding}" +
$"pn29yMivL7r48dlo{lineEnding}" +
$"-----END CERTIFICATE-----";

            Assert.IsTrue(PemReader.TryRead(pem.AsSpan(), out PemReader.PemField field));
            Assert.AreEqual("CERTIFICATE", field.Label.ToString());
            Assert.AreEqual(s_rsaCertificateBytes, field.FromBase64Data());
        }

        [Test]
        public void ReadNoLabel()
        {
            const string pem = @"
MIIDCDCCAfCgAwIBAgIUB9Mxn1KLNBaTKu6pYdn3W1EBvWkwDQYJKoZIhvcNAQEL
BQAwFDESMBAGA1UEAwwJQXp1cmUgU0RLMB4XDTIxMDIwNDE5MzUzNVoXDTIxMTAy
NzE5MzUzNVowFDESMBAGA1UEAwwJQXp1cmUgU0RLMIIBIjANBgkqhkiG9w0BAQEF
AAOCAQ8AMIIBCgKCAQEA20VE95MMlyn7yu76XmEPBV5Gj7Sn0BzavGTYc497HXRp
y4Ec8edX5C6u7QpO+eQOVlFAbeyIg1/IMGdod8Quarx11mqCyBhXVlStrjqoNTIo
00OA9EFrWjka2ZYrLxlnS6k/w2k18nQE+FP63DIX1OkXU3TxHfVhZWwHgObq5jWz
x4EjG37hnYSJknAB/71N9f2g63cUM28HcGDfMzNrEhbk+TpFfGg3rZiosHybDyDH
x88jTxRxFYBiaWQpNOzZA+M9XUeUK3rdxOfj5JL8ExWGuPMj9QNKGcKkccrLoMtM
5hFP9R8f9nBeeYrmAUsZwU7HWUfaTzWH4goWfZRFQQIDAQABo1IwUDAJBgNVHRME
AjAAMAsGA1UdDwQEAwIF4DATBgNVHSUEDDAKBggrBgEFBQcDATAhBgNVHREEGjAY
gRZhenVyZXNka0BtaWNyb3NvZnQuY29tMA0GCSqGSIb3DQEBCwUAA4IBAQAbUn/U
IrlqGYv417Zwx00VEKOsis3Hafof6KjxQKzHwhNZ2EhLSNIRPrzK3ITbR2f0ZoCO
J5RnL11/KiLA1C9i38aAiekMxxYYikVWkpQHc3BB85v+lhSm5cuSvrdVeTcCXDTA
rJUjjPW4aQuo0GyzL4v1M1U2pByKsVCYAikuLmQKS2zXLoyW3ana1aQYyh2/3cXm
lkApwUZg00+9hRWxv0DTh/mRS2zu5i/9W+cZbIcRah0JHgOzAjvsyY9RHjqZ9r7c
Md7RrFHxnAKJj5TZJJJOf5h3OaaF3A5W8gf9Bc68aGQLFT5Y2afIawkYNSULypc3
pn29yMivL7r48dlo";

            Assert.IsFalse(PemReader.TryRead(pem.AsSpan(), out _));
        }

        [Test]
        public void ReadInvalidLabel()
        {
            const string pem = @"
-----BEGIN CERTIFICATE
MIIDCDCCAfCgAwIBAgIUB9Mxn1KLNBaTKu6pYdn3W1EBvWkwDQYJKoZIhvcNAQEL
BQAwFDESMBAGA1UEAwwJQXp1cmUgU0RLMB4XDTIxMDIwNDE5MzUzNVoXDTIxMTAy
NzE5MzUzNVowFDESMBAGA1UEAwwJQXp1cmUgU0RLMIIBIjANBgkqhkiG9w0BAQEF
AAOCAQ8AMIIBCgKCAQEA20VE95MMlyn7yu76XmEPBV5Gj7Sn0BzavGTYc497HXRp
y4Ec8edX5C6u7QpO+eQOVlFAbeyIg1/IMGdod8Quarx11mqCyBhXVlStrjqoNTIo
00OA9EFrWjka2ZYrLxlnS6k/w2k18nQE+FP63DIX1OkXU3TxHfVhZWwHgObq5jWz
x4EjG37hnYSJknAB/71N9f2g63cUM28HcGDfMzNrEhbk+TpFfGg3rZiosHybDyDH
x88jTxRxFYBiaWQpNOzZA+M9XUeUK3rdxOfj5JL8ExWGuPMj9QNKGcKkccrLoMtM
5hFP9R8f9nBeeYrmAUsZwU7HWUfaTzWH4goWfZRFQQIDAQABo1IwUDAJBgNVHRME
AjAAMAsGA1UdDwQEAwIF4DATBgNVHSUEDDAKBggrBgEFBQcDATAhBgNVHREEGjAY
gRZhenVyZXNka0BtaWNyb3NvZnQuY29tMA0GCSqGSIb3DQEBCwUAA4IBAQAbUn/U
IrlqGYv417Zwx00VEKOsis3Hafof6KjxQKzHwhNZ2EhLSNIRPrzK3ITbR2f0ZoCO
J5RnL11/KiLA1C9i38aAiekMxxYYikVWkpQHc3BB85v+lhSm5cuSvrdVeTcCXDTA
rJUjjPW4aQuo0GyzL4v1M1U2pByKsVCYAikuLmQKS2zXLoyW3ana1aQYyh2/3cXm
lkApwUZg00+9hRWxv0DTh/mRS2zu5i/9W+cZbIcRah0JHgOzAjvsyY9RHjqZ9r7c
Md7RrFHxnAKJj5TZJJJOf5h3OaaF3A5W8gf9Bc68aGQLFT5Y2afIawkYNSULypc3
pn29yMivL7r48dlo";

            Assert.IsFalse(PemReader.TryRead(pem.AsSpan(), out _));
        }

        [Test]
        public void ReadNoEndLabel()
        {
            const string pem = @"
MIIDCDCCAfCgAwIBAgIUB9Mxn1KLNBaTKu6pYdn3W1EBvWkwDQYJKoZIhvcNAQEL
BQAwFDESMBAGA1UEAwwJQXp1cmUgU0RLMB4XDTIxMDIwNDE5MzUzNVoXDTIxMTAy
NzE5MzUzNVowFDESMBAGA1UEAwwJQXp1cmUgU0RLMIIBIjANBgkqhkiG9w0BAQEF
AAOCAQ8AMIIBCgKCAQEA20VE95MMlyn7yu76XmEPBV5Gj7Sn0BzavGTYc497HXRp
y4Ec8edX5C6u7QpO+eQOVlFAbeyIg1/IMGdod8Quarx11mqCyBhXVlStrjqoNTIo
00OA9EFrWjka2ZYrLxlnS6k/w2k18nQE+FP63DIX1OkXU3TxHfVhZWwHgObq5jWz
x4EjG37hnYSJknAB/71N9f2g63cUM28HcGDfMzNrEhbk+TpFfGg3rZiosHybDyDH
x88jTxRxFYBiaWQpNOzZA+M9XUeUK3rdxOfj5JL8ExWGuPMj9QNKGcKkccrLoMtM
5hFP9R8f9nBeeYrmAUsZwU7HWUfaTzWH4goWfZRFQQIDAQABo1IwUDAJBgNVHRME
AjAAMAsGA1UdDwQEAwIF4DATBgNVHSUEDDAKBggrBgEFBQcDATAhBgNVHREEGjAY
gRZhenVyZXNka0BtaWNyb3NvZnQuY29tMA0GCSqGSIb3DQEBCwUAA4IBAQAbUn/U
IrlqGYv417Zwx00VEKOsis3Hafof6KjxQKzHwhNZ2EhLSNIRPrzK3ITbR2f0ZoCO
J5RnL11/KiLA1C9i38aAiekMxxYYikVWkpQHc3BB85v+lhSm5cuSvrdVeTcCXDTA
rJUjjPW4aQuo0GyzL4v1M1U2pByKsVCYAikuLmQKS2zXLoyW3ana1aQYyh2/3cXm
lkApwUZg00+9hRWxv0DTh/mRS2zu5i/9W+cZbIcRah0JHgOzAjvsyY9RHjqZ9r7c
Md7RrFHxnAKJj5TZJJJOf5h3OaaF3A5W8gf9Bc68aGQLFT5Y2afIawkYNSULypc3
pn29yMivL7r48dlo";

            Assert.IsFalse(PemReader.TryRead(pem.AsSpan(), out _));
        }

        [Test]
        public void ReadWithExtraneousData()
        {
            Assert.IsTrue(PemReader.TryRead(RsaPemPrivateKey.AsSpan(), out PemReader.PemField field));
            Assert.AreEqual("PRIVATE KEY", field.Label.ToString());
            Assert.AreEqual(s_rsaPrivateKeyBytes, field.FromBase64Data());
        }

        [Test]
        public void ReadCertificateWithPrivateKey()
        {
            ReadOnlySpan<char> data = RsaPem.AsSpan();

            // Expect to find the private key first.
            Assert.IsTrue(PemReader.TryRead(data, out PemReader.PemField field));
            Assert.AreEqual("PRIVATE KEY", field.Label.ToString());
            Assert.AreEqual(s_rsaPrivateKeyBytes, field.FromBase64Data());

            // Expect to find the certificate second.
            data = data.Slice(field.Start + field.Length);

            Assert.IsTrue(PemReader.TryRead(data, out field));
            Assert.AreEqual("CERTIFICATE", field.Label.ToString());
            Assert.AreEqual(s_rsaCertificateBytes, field.FromBase64Data());
        }

        [Test]
        public void LoadCertificate()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(RsaPem.AsSpan(), keyType: PemReader.KeyType.RSA);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.GetRSAPrivateKey().KeySize);
        }

        [Test]
        public void LoadCertificateAutomatically()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(RsaPem.AsSpan());
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.GetRSAPrivateKey().KeySize);
        }

        [Test]
        public void LoadCertificateWithPublicKey()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(RsaPemPrivateKey.AsSpan(), s_rsaCertificateBytes, keyType: PemReader.KeyType.RSA);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.GetRSAPrivateKey().KeySize);
        }

        [Test]
        public void LoadCertificateWithoutPublicKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(RsaPemPrivateKey.AsSpan(), keyType: PemReader.KeyType.RSA));
            Assert.AreEqual("The certificate is missing the public key", ex.Message);
        }

        [Test]
        public void LoadCertificateWithoutPrivateKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(RsaPemCertificate.AsSpan(), keyType: PemReader.KeyType.RSA));
            Assert.AreEqual("The certificate is missing the private key", ex.Message);
        }

        [Test]
        public void LoadCertificateWithOnlyPublicKeyAllowed()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(RsaPemCertificate.AsSpan(), s_rsaCertificateBytes, keyType: PemReader.KeyType.RSA, allowCertificateOnly: true);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsFalse(certificate.HasPrivateKey);
        }

        [Test]
        public void LoadCertificateWithNoKeys()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(Span<char>.Empty));
            Assert.AreEqual("The certificate is missing the public key", ex.Message);
        }

        [Test]
        public void LoadedCertificateNotDisposed()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(RsaPem.AsSpan(), keyType: PemReader.KeyType.RSA);

            using RSA publicKey = certificate.GetRSAPublicKey();
            using RSA privateKey = certificate.GetRSAPrivateKey();

            byte[] plaintext = Encoding.UTF8.GetBytes("test");
            byte[] ciphertext = publicKey.Encrypt(plaintext, RSAEncryptionPadding.Pkcs1);

            byte[] decrypted = privateKey.Decrypt(ciphertext, RSAEncryptionPadding.Pkcs1);
            Assert.AreEqual(plaintext, decrypted);
        }

        [Test]
        public void LoadCertificateReversed()
        {
            string pem = RsaPemCertificate + "\n" + RsaPemPrivateKey;

            using X509Certificate2 certificate = PemReader.LoadCertificate(pem.AsSpan(), keyType: PemReader.KeyType.RSA);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.GetRSAPrivateKey().KeySize);
        }

        [Test]
        public void LoadCertificatePemOverridesCer()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(RsaPem.AsSpan(), Encoding.UTF8.GetBytes("This is not a certificate"), keyType: PemReader.KeyType.RSA);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.GetRSAPrivateKey().KeySize);
        }

        [Test]
        public void LoadECDsaCertificate()
        {
#if NET462
            // Compatible with previous release. Goes through the LightweightPkcs8Decoder.DecodeRSAPkcs8().
            Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), keyType: PemReader.KeyType.RSA));
#else
            // Compatible with the previous release. Goes through RSA.ImportPKcs8PrivateKey().
            Assert.That(() => PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), keyType: PemReader.KeyType.RSA), Throws.InstanceOf<CryptographicException>());
#endif
        }

        [Test]
        public void LoadECDsaCertificateAutomatically()
        {
            // Support for ECDsa certificates are not supported by default. See Azure.Security.KeyVault.Certificates for support.
            Assert.Throws<NotSupportedException>(() => PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), keyType: PemReader.KeyType.Auto));
        }

        private static IEnumerable<string> LineEndings => new[]
        {
            "\n",   // Linux
            "\r\n", // Windows
            "\r",   // Mac
        };
    }
}
