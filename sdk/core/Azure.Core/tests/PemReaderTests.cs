﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class PemReaderTests
    {
        [TestCaseSource(nameof(LineEndings))]
        public void ReadsPrivateKey(string lineEnding)
        {
            string pem =
$"-----BEGIN PRIVATE KEY-----{lineEnding}" +
$"MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDbRUT3kwyXKfvK{lineEnding}" +
$"7vpeYQ8FXkaPtKfQHNq8ZNhzj3sddGnLgRzx51fkLq7tCk755A5WUUBt7IiDX8gw{lineEnding}" +
$"Z2h3xC5qvHXWaoLIGFdWVK2uOqg1MijTQ4D0QWtaORrZlisvGWdLqT/DaTXydAT4{lineEnding}" +
$"U/rcMhfU6RdTdPEd9WFlbAeA5urmNbPHgSMbfuGdhImScAH/vU31/aDrdxQzbwdw{lineEnding}" +
$"YN8zM2sSFuT5OkV8aDetmKiwfJsPIMfHzyNPFHEVgGJpZCk07NkD4z1dR5Qret3E{lineEnding}" +
$"5+PkkvwTFYa48yP1A0oZwqRxysugy0zmEU/1Hx/2cF55iuYBSxnBTsdZR9pPNYfi{lineEnding}" +
$"ChZ9lEVBAgMBAAECggEBALOLCcjrCLEyeHGXszzanrEXnBGJrKt1JQqETNR7FSVu{lineEnding}" +
$"MD6pjyjo9IfsTeHcwgROYAr/5xDbUIC6SjKQSfNfmV5eyOJ0PnhXrhQLrFdwwlEk{lineEnding}" +
$"rFco/AuFEcFD5x9pnhyn4XQLtyFsIfdQVs17/nqVLfxxjF8S72hHh6PDjHVZH9i1{lineEnding}" +
$"daF4woC7obyKqv8+uoc/MEqTgE/bbaQoL8tDUhCcuoKjcBEXpRryWFaeMoolnuTU{lineEnding}" +
$"D7656CHKFAnloGpNaeNPy8XmpicRxHEODXSoEZDxYoj3SSbPqn/7FDzHqh/Fk3kD{lineEnding}" +
$"tfjhYdhwZFrlTkvC766DxEBgIQHvJbdjujsX4uLJVQECgYEA/HoOKmA2KgK+f126{lineEnding}" +
$"oKmF38o4S/8hBd4vT7Qq2Q88zFom7MWrdlHdg5WO0ZLXS+l6LTOVkS2NM+WtbeeF{lineEnding}" +
$"5el4ICEl0x/Z1/e3vZl0QTDDOKqzfWsVxNwM9FD2bmVjVZHU0o9DPy45ugZdV0ti{lineEnding}" +
$"9YTm9TLIachAjU5vIIwz6CJ5g9ECgYEA3lSWtSeo76q0hlXE/FN5jn9BeuZHYmCJ{lineEnding}" +
$"aHYhtG50tXUxghwPRzfTVoQFbUQa1w/Ex4Ny2xZ+OnQTzdBjC13Xz2PAaldrNYlH{lineEnding}" +
$"5C/LjhbFdOvuQWU3nli9wXq25GTvzla3F5dn0NCUP3xwUIMld1Yq7mCaIy9HrP4i{lineEnding}" +
$"gn6jZimzNnECgYEAsXdR0bODHxCCuqA1eIzwTxejbrfMjIVamBm6LIyrXbDYv4FK{lineEnding}" +
$"PobYv482rlUbBH7+pBsoPL3aDOqadzBQTAVJrLvgDIDM7SNwgdMFhnUyI/jI5ZWJ{lineEnding}" +
$"3bAXYvwt2/dkVVeGUuLkj9p8NSgYIC4bRxy+AwhJGyHpTeod7rDeI4NoCqECgYB1{lineEnding}" +
$"DKWXU/ztyLpn6undSfk6GycXE/tLALX2yBKwkmJhUgSxkiI9BVf/OVw+DVfwF34q{lineEnding}" +
$"57plO69TCN+QQICUcGB47/RSSBnKQq8VpFAPS0/DYZ660RX6CJBGN1voXHef8ylL{lineEnding}" +
$"g0uFtPoHfnUG/jSQYk4R18vucCrVGaqDdzaBR7zxEQKBgCEqovhMGJ1xOrkzetBB{lineEnding}" +
$"+zgh5zJbAWx5DQk5ZdmAcAnEeqconM2yhFB636wC07UbeAZaQmhB5kQYMOuiCstt{lineEnding}" +
$"30sdQlNG9EGdqNsoVn/363Cg1iKJy4JU5uW/5kjh4UfBZG6DDwjLK88ZWh0OHPRV{lineEnding}" +
$"h8q0or9YnvqnVrELMR8cjUkZ{lineEnding}" +
$"-----END PRIVATE KEY-----";

            Assert.IsTrue(PemReader.TryRead(pem.AsSpan(), out PemReader.PemField field));
            Assert.AreEqual("PRIVATE KEY", field.Label.ToString());
            Assert.AreEqual(PrivateKeyBytes, field.FromBase64Data());
        }

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
            Assert.AreEqual(CertificateBytes, field.FromBase64Data());
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
            Assert.IsTrue(PemReader.TryRead(PEMPrivateKey.AsSpan(), out PemReader.PemField field));
            Assert.AreEqual("PRIVATE KEY", field.Label.ToString());
            Assert.AreEqual(PrivateKeyBytes, field.FromBase64Data());
        }

        [Test]
        public void ReadCertificateWithPrivateKey()
        {
            ReadOnlySpan<char> data = PEM.AsSpan();

            // Expect to find the private key first.
            Assert.IsTrue(PemReader.TryRead(data, out PemReader.PemField field));
            Assert.AreEqual("PRIVATE KEY", field.Label.ToString());
            Assert.AreEqual(PrivateKeyBytes, field.FromBase64Data());

            // Expect to find the certificate second.
            data = data.Slice(field.Start + field.Length);

            Assert.IsTrue(PemReader.TryRead(data, out field));
            Assert.AreEqual("CERTIFICATE", field.Label.ToString());
            Assert.AreEqual(CertificateBytes, field.FromBase64Data());
        }

        [Test]
        public void LoadCertificate()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(PEM.AsSpan());
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.PrivateKey.KeySize);
        }

        [Test]
        public void LoadCertificateWithPublicKey()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(PEMPrivateKey.AsSpan(), CertificateBytes);
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.PrivateKey.KeySize);
        }

        [Test]
        public void LoadCertificateWithoutPublicKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(PEMPrivateKey.AsSpan()));
            Assert.AreEqual("The certificate is missing the public key", ex.Message);
        }

        [Test]
        public void LoadCertificateWithoutPrivateKey()
        {
            Exception ex = Assert.Throws<InvalidDataException>(() => PemReader.LoadCertificate(PEMPublicKey.AsSpan()));
            Assert.AreEqual("The certificate is missing the private key", ex.Message);
        }

        [Test]
        public void LoadCertificateWithOnlyPublicKeyAllowed()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(PEMPublicKey.AsSpan(), CertificateBytes, allowCertificateOnly: true);
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
            using X509Certificate2 certificate = PemReader.LoadCertificate(PEM.AsSpan());

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
            string pem = PEMPublicKey + "\n" + PEMPrivateKey;

            using X509Certificate2 certificate = PemReader.LoadCertificate(pem.AsSpan());
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.PrivateKey.KeySize);
        }

        [Test]
        public void LoadCertificatePemOverridesCer()
        {
            using X509Certificate2 certificate = PemReader.LoadCertificate(PEM.AsSpan(), Encoding.UTF8.GetBytes("This is not a certificate"));
            Assert.AreEqual("CN=Azure SDK", certificate.Subject);
            Assert.IsTrue(certificate.HasPrivateKey);
            Assert.AreEqual(2048, certificate.PrivateKey.KeySize);
        }

        private const string PEM = @"
MAC: sha1, Iteration 2000
MAC length: 20, salt length: 20
PKCS7 Data
Shrouded Keybag: pbeWithSHA1And3-KeyTripleDES-CBC, Iteration 2000
Bag Attributes
    localKeyID: 00 00 00 00
Key Attributes: <No Attributes>
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
PKCS7 Encrypted data: pbeWithSHA1And3-KeyTripleDES-CBC, Iteration 2000
Certificate bag
Bag Attributes
    localKeyID: 00 00 00 00
subject=CN = Azure SDK

issuer=CN = Azure SDK

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

        private const string PEMPrivateKey = @"
MAC: sha1, Iteration 2000
MAC length: 20, salt length: 20
PKCS7 Data
Shrouded Keybag: pbeWithSHA1And3-KeyTripleDES-CBC, Iteration 2000
Bag Attributes
    localKeyID: 00 00 00 00
Key Attributes: <No Attributes>
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
-----END PRIVATE KEY-----";

        private const string PEMPublicKey = @"
PKCS7 Encrypted data: pbeWithSHA1And3-KeyTripleDES-CBC, Iteration 2000
Certificate bag
Bag Attributes
    localKeyID: 00 00 00 00
subject=CN = Azure SDK

issuer=CN = Azure SDK

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

        private const string PrivateKey = @"
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
h8q0or9YnvqnVrELMR8cjUkZ";

        private const string Certificate = @"
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

        private static readonly byte[] PrivateKeyBytes = Convert.FromBase64String(PrivateKey.Trim());
        private static readonly byte[] CertificateBytes = Convert.FromBase64String(Certificate.Trim());

        private static IEnumerable<string> LineEndings => new[]
        {
            "\n",   // Linux
            "\r\n", // Windows
            "\r",   // Mac
        };
    }
}
