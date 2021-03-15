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
    public class PemReaderTests
    {
        [Test]
        public void LoadCertificate()
        {
#if NET461
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
        }

        [Test]
        public void LoadCertificateAutomatically()
        {
#if NET461
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan());
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
        }

        [Test]
        public void LoadCertificateWithPublicKey()
        {
#if NET461
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(ECDsaPrivateKey.AsSpan(), cer: s_ecdsaCertificateBytes, keyType: PemReader.KeyType.ECDsa);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
        }

        [Test]
        public void LoadCertificateWithoutPublicKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(ECDsaPrivateKey.AsSpan(), keyType: PemReader.KeyType.ECDsa));
            Assert.AreEqual("The certificate is missing the public key", ex.Message);
        }

        [Test]
        public void LoadCertificateWithoutPrivateKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa));
            Assert.AreEqual("The certificate is missing the private key", ex.Message);
        }

        [Test]
        public void LoadCertificateWithOnlyPublicKeyAllowed()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(ECDsaCertificate.AsSpan(), allowCertificateOnly: true, keyType: PemReader.KeyType.ECDsa);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsFalse(certificate.HasPrivateKey);
        }

        [Test]
        public void LoadCertificateWithNoKeys()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(Span<char>.Empty, keyType: PemReader.KeyType.ECDsa));
            Assert.AreEqual("The certificate is missing the public key", ex.Message);
        }

        [Test]
        public void LoadCertificatePemOverridesCer()
        {
#if NET461
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(s_ecdsaFullCertificate.AsSpan(), cer: Encoding.UTF8.GetBytes("This is not a certificate"), keyType: PemReader.KeyType.ECDsa);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
        }

        [Test]
        public void LoadRSACertificate()
        {
#if NET461 || NETCOREAPP2_1
            // Compatible with previous release. Goes through the LightweightPkcs8Decoder.DecodeECDsaPkcs8().
            Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(RSACertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa));
#else
            // Compatible with the previous release. Goes through RSA.ImportPKcs8PrivateKey().
            Assert.That(() => PemReader.LoadCertificate(RSACertificate.AsSpan(), keyType: PemReader.KeyType.ECDsa), Throws.InstanceOf<CryptographicException>());
#endif
        }

        [Test]
        public void LoadECDsaPrime256v1Certificate()
        {
#if NET461
            Assert.Ignore("Loading X509Certificate2 with private EC key not supported on this platform");
#elif NETCOREAPP2_1
            Assert.Ignore("Different OIDs in the certificate and private key prevent this from passing currently");
#endif
            using X509Certificate2 certificate = PemReader.LoadCertificate(ECDsaPrime256v1Certificate.AsSpan(), keyType: PemReader.KeyType.ECDsa);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
        }

        private const string ECDsaPrivateKey = @"
-----BEGIN PRIVATE KEY-----
MIGiAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgEr3FyNKVWsTPq+qr
5Io9ScfY30gBJucHIYKYOCNzz6agCgYIKoZIzj0DAQehRANCAAQEqAYvKsuyGZ7p
cIDI1Z1Xi/QTbnGDZZymwySF6dodTEvDU5mgHJukfxDHCIlKMhMiZ+ONQ3ZjJw0l
SSNy9L/FoA0wCwYDVR0PMQQDAgCA
-----END PRIVATE KEY-----";

        private const string ECDsaCertificate = @"
-----BEGIN CERTIFICATE-----
MIIBoTCCAUegAwIBAgIPOJ+TFwtB67Bx1oGcjy8bMAoGCCqGSM49BAMCMBQxEjAQ
BgNVBAMTCUF6dXJlIFNESzAeFw0yMTAzMDMwMTA1MDhaFw0yMjAzMDMwMTE1MDha
MBQxEjAQBgNVBAMTCUF6dXJlIFNESzBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IA
BASoBi8qy7IZnulwgMjVnVeL9BNucYNlnKbDJIXp2h1MS8NTmaAcm6R/EMcIiUoy
EyJn441DdmMnDSVJI3L0v8WjfDB6MA4GA1UdDwEB/wQEAwIHgDAJBgNVHRMEAjAA
MB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjAfBgNVHSMEGDAWgBTBmiXR
aat2MZBsBzAPA3MOba4nFzAdBgNVHQ4EFgQUwZol0WmrdjGQbAcwDwNzDm2uJxcw
CgYIKoZIzj0EAwIDSAAwRQIhAKP1i0h+JX6QjOoHCNvteIX/el7xgzU7sePLL2oW
j6qoAiBymxZvx4myxSyI6g0eBH54ImcIw//Hxs4JRnFVKg9IBA==
-----END CERTIFICATE-----";

        private const string RSACertificate = @"
-----BEGIN PRIVATE KEY-----
MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDbRUT3kwyXKfvK
7vpeYQ8FXkaPtKfQHNq8ZNhzj3sddGnLgRzx51fkLq7tCk755A5WUUBt7IiDX8gw
Z2h3xC5qvHXWaoLIGFdWVK2uOqg1MijTQ4D0QWtaORrZlisvGWdLqT/DaTXydAT4
U/rcMhfU6RdTdPEd9WFlbAeA5urmNbPHgSMbfuGdhImScAH/vU31/aDrdxQzbwdw
YN8zM2sSFuT5OkV8aDetmKiwfJsPIMfHzyNPFHEVgGJpZCk07NkD4z1dR5Qret3E
5+PkkvwTFYa48yP1A0oZwqRxysugy0zmEU/1Hx/2cF55iuYBSxnBTsdZR9pPNYfi
ChZ9lEVBAgMBAAECggEBALOLCcjrCLEyeHGXszzanrEXnBGJrKt1JQqETNR7FSVu
MD6pjyjo9IfsTeHcwgROYAr/5xDbUIC6SjKQSfNfmV5eyOJ0PnhXrhQLrFdwwlEk
rFco/AuFEcFD5x9pnhyn4XQLtyFsIfdQVs17/nqVLfxxjF8S72hHh6PDjHVZH9i1
daF4woC7obyKqv8+uoc/MEqTgE/bbaQoL8tDUhCcuoKjcBEXpRryWFaeMoolnuTU
D7656CHKFAnloGpNaeNPy8XmpicRxHEODXSoEZDxYoj3SSbPqn/7FDzHqh/Fk3kD
tfjhYdhwZFrlTkvC766DxEBgIQHvJbdjujsX4uLJVQECgYEA/HoOKmA2KgK+f126
oKmF38o4S/8hBd4vT7Qq2Q88zFom7MWrdlHdg5WO0ZLXS+l6LTOVkS2NM+WtbeeF
5el4ICEl0x/Z1/e3vZl0QTDDOKqzfWsVxNwM9FD2bmVjVZHU0o9DPy45ugZdV0ti
9YTm9TLIachAjU5vIIwz6CJ5g9ECgYEA3lSWtSeo76q0hlXE/FN5jn9BeuZHYmCJ
aHYhtG50tXUxghwPRzfTVoQFbUQa1w/Ex4Ny2xZ+OnQTzdBjC13Xz2PAaldrNYlH
5C/LjhbFdOvuQWU3nli9wXq25GTvzla3F5dn0NCUP3xwUIMld1Yq7mCaIy9HrP4i
gn6jZimzNnECgYEAsXdR0bODHxCCuqA1eIzwTxejbrfMjIVamBm6LIyrXbDYv4FK
PobYv482rlUbBH7+pBsoPL3aDOqadzBQTAVJrLvgDIDM7SNwgdMFhnUyI/jI5ZWJ
3bAXYvwt2/dkVVeGUuLkj9p8NSgYIC4bRxy+AwhJGyHpTeod7rDeI4NoCqECgYB1
DKWXU/ztyLpn6undSfk6GycXE/tLALX2yBKwkmJhUgSxkiI9BVf/OVw+DVfwF34q
57plO69TCN+QQICUcGB47/RSSBnKQq8VpFAPS0/DYZ660RX6CJBGN1voXHef8ylL
g0uFtPoHfnUG/jSQYk4R18vucCrVGaqDdzaBR7zxEQKBgCEqovhMGJ1xOrkzetBB
+zgh5zJbAWx5DQk5ZdmAcAnEeqconM2yhFB636wC07UbeAZaQmhB5kQYMOuiCstt
30sdQlNG9EGdqNsoVn/363Cg1iKJy4JU5uW/5kjh4UfBZG6DDwjLK88ZWh0OHPRV
h8q0or9YnvqnVrELMR8cjUkZ
-----END PRIVATE KEY-----
-----BEGIN CERTIFICATE-----
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
pn29yMivL7r48dlo
-----END CERTIFICATE-----";

        private const string ECDsaPrime256v1Certificate = @"
-----BEGIN PRIVATE KEY-----
MIIBMgIBADCBrgYHKoZIzj0CATCBogIBATAsBgcqhkjOPQEBAiEA////////////
/////////////////////////v///C8wBgQBAAQBBwRBBHm+Zn753LusVaBilc6H
CwcCm/zbLc4o2VnygVsW+BeYSDradyajxGVdpPv8DhEIqP0XtEimhVQZnEfQj/sQ
1LgCIQD////////////////////+uq7c5q9IoDu/0l6M0DZBQQIBAQRtMGsCAQEE
INIX6ZEliNAwvZAq3GkJHNHSvQOlIzFMkifg/C8DfVAhoUQDQgAEnxIn+jXd3Pfw
IcpGkQx9b1L/BYXHDzNINDOTwmOku3fG+zI6vT3R3VkHfcd7GR9aJxp1tdxMnIkF
xU2Z1eNVXqANMAsGA1UdDzEEAwIAgA==
-----END PRIVATE KEY-----
-----BEGIN CERTIFICATE-----
MIICPzCCAeWgAwIBAgIQdclPKrRQTmCpZ0p2lM2pmDAKBggqhkjOPQQDAjAUMRIw
EAYDVQQDEwlBenVyZSBTREswHhcNMjEwMzAzMDEwOTIxWhcNMjIwMzAzMDExOTIx
WjAUMRIwEAYDVQQDEwlBenVyZSBTREswgfUwga4GByqGSM49AgEwgaICAQEwLAYH
KoZIzj0BAQIhAP////////////////////////////////////7///wvMAYEAQAE
AQcEQQR5vmZ++dy7rFWgYpXOhwsHApv82y3OKNlZ8oFbFvgXmEg62ncmo8RlXaT7
/A4RCKj9F7RIpoVUGZxH0I/7ENS4AiEA/////////////////////rqu3OavSKA7
v9JejNA2QUECAQEDQgAEnxIn+jXd3PfwIcpGkQx9b1L/BYXHDzNINDOTwmOku3fG
+zI6vT3R3VkHfcd7GR9aJxp1tdxMnIkFxU2Z1eNVXqN8MHowDgYDVR0PAQH/BAQD
AgeAMAkGA1UdEwQCMAAwHQYDVR0lBBYwFAYIKwYBBQUHAwEGCCsGAQUFBwMCMB8G
A1UdIwQYMBaAFAJEtqOacY6KuA8KAyt3dgByxWGlMB0GA1UdDgQWBBQCRLajmnGO
irgPCgMrd3YAcsVhpTAKBggqhkjOPQQDAgNIADBFAiEAlGVRNxgGsOpmBAGud2v1
aSnz2Zm8A9EV1a+5EVp8Rz8CIFkJYAXOL/n0xo4fp+7yR+9SwVa3c6wNimYSfhoU
+YpQ
-----END CERTIFICATE-----";

        private static readonly string s_ecdsaFullCertificate = ECDsaPrivateKey + ECDsaCertificate;
        private static readonly byte[] s_ecdsaCertificateBytes = Convert.FromBase64String(@"
MIIBoTCCAUegAwIBAgIPOJ+TFwtB67Bx1oGcjy8bMAoGCCqGSM49BAMCMBQxEjAQ
BgNVBAMTCUF6dXJlIFNESzAeFw0yMTAzMDMwMTA1MDhaFw0yMjAzMDMwMTE1MDha
MBQxEjAQBgNVBAMTCUF6dXJlIFNESzBZMBMGByqGSM49AgEGCCqGSM49AwEHA0IA
BASoBi8qy7IZnulwgMjVnVeL9BNucYNlnKbDJIXp2h1MS8NTmaAcm6R/EMcIiUoy
EyJn441DdmMnDSVJI3L0v8WjfDB6MA4GA1UdDwEB/wQEAwIHgDAJBgNVHRMEAjAA
MB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjAfBgNVHSMEGDAWgBTBmiXR
aat2MZBsBzAPA3MOba4nFzAdBgNVHQ4EFgQUwZol0WmrdjGQbAcwDwNzDm2uJxcw
CgYIKoZIzj0EAwIDSAAwRQIhAKP1i0h+JX6QjOoHCNvteIX/el7xgzU7sePLL2oW
j6qoAiBymxZvx4myxSyI6g0eBH54ImcIw//Hxs4JRnFVKg9IBA==");
    }
}
