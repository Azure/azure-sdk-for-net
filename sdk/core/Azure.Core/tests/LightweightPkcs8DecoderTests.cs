// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class LightweightPkcs8DecoderTests
    {
        [TestCaseSource(nameof(ReadBitStringData))]
        public void ReadBitString(byte[] data)
        {
            int offset = 0;

            byte[] actual = LightweightPkcs8Decoder.ReadBitString(data, ref offset);

            Assert.AreEqual(new byte[] { 0x11, 0x22, 0x33, 0x00 }, actual);
        }

        [Test]
        public void ReadNonBitString()
        {
            byte[] data = { 0x30 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadBitString(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void ReadEmptyBitString()
        {
            byte[] data = { 0x30, 0x00 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadBitString(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void ReadInvalidBitString()
        {
            byte[] data = { 0x30, 0x01, 0x08 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadBitString(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        private static IEnumerable ReadBitStringData => new[]
        {
            new object[] { new byte[] { 0x03, 0x05, 0x00, 0x11, 0x22, 0x33, 0x00 } },
            new object[] { new byte[] { 0x03, 0x05, 0x07, 0x11, 0x22, 0x33, 0x00 } },
        };

        [TestCaseSource(nameof(ReadObjectIdentifierData))]
        public void ReadObjectIdentifier(string expectedOid, byte[] data)
        {
            int offset = 0;

            string actualOid = LightweightPkcs8Decoder.ReadObjectIdentifier(data, ref offset);

            Assert.AreEqual(expectedOid, actualOid);
        }

        [Test]
        public void ReadNonObjectIdentifier()
        {
            byte[] data = { 0x30 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadObjectIdentifier(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void ReadInvalidObjectIdentifier()
        {
            byte[] data = new byte[] { 0x06, 0x03, 0x2B, 0x80, 0x01 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadObjectIdentifier(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void ReadUnsupportedObjectIdentifier()
        {
            byte[] data = new byte[] { 0x06, 0x06, 0x2B, 0x88, 0x80, 0x80, 0x80, 0x00 }; // 1.3.2147483648
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadObjectIdentifier(data, ref offset));
            Assert.AreEqual("Unsupported PKCS#8 Data", ex.Message);
        }

        [Test]
        public void ReadUnsupportedArc2ObjectIdentifier()
        {
            byte[] data = new byte[] { 0x06, 0x02, 0x88, 0x37 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadObjectIdentifier(data, ref offset));
            Assert.AreEqual("Unsupported PKCS#8 Data", ex.Message);
        }

        private static IEnumerable ReadObjectIdentifierData => new[]
        {
            new object[] { "1.2.840.10045.2.1", new byte[] { 0x06, 0x07, 0x2A, 0x86, 0x48, 0xCE, 0x3D, 0x02, 0x01 } },
            new object[] { "1.3.132.0.35", new byte[] { 0x06, 0x05, 0x2B, 0x81, 0x04, 0x00, 0x23 } },
            new object[] { "1.3.132.0.34", new byte[] { 0x06, 0x05, 0x2B, 0x81, 0x04, 0x00, 0x22 } },
            new object[] { "1.2.840.10045.1.1", new byte[] { 0x06, 0x07, 0x2A, 0x86, 0x48, 0xCE, 0x3D, 0x01, 0x01, } },
            new object[] { "1.3.132.0.10", new byte[] { 0x06, 0x05, 0x2B, 0x81, 0x04, 0x00, 0x0A } },
            new object[] { "1.2.840.113549.1.1.1", new byte[] { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01 } },
        };

        [Test]
        public void ReadOctetString()
        {
            byte[] data =
            {
                0x04, 0x42, 0x00, 0x43, 0x3E, 0x10, 0x5C, 0xE3, 0x75, 0x42, 0x54, 0x37, 0xDD, 0x3C, 0x35,
                0x2D, 0x2F, 0x32, 0x69, 0x09, 0x3C, 0x73, 0x23, 0x1C, 0x6F, 0x2A, 0xE6, 0x12, 0xE5, 0x78, 0x20,
                0xC8, 0xF3, 0x46, 0xA8, 0x19, 0xCB, 0xD8, 0x60, 0x02, 0xAA, 0x81, 0x79, 0x77, 0x1A, 0x86, 0x7E,
                0xE2, 0x45, 0x53, 0x66, 0xDF, 0x9A, 0xC2, 0x3C, 0x77, 0xCD, 0x12, 0x6B, 0x8D, 0x74, 0x83, 0x2B,
                0x8A, 0xEA, 0x24, 0xAA, 0xD7,
            };

            byte[] expected =
            {
                0x00, 0x43, 0x3E, 0x10, 0x5C, 0xE3, 0x75, 0x42, 0x54, 0x37, 0xDD, 0x3C, 0x35,
                0x2D, 0x2F, 0x32, 0x69, 0x09, 0x3C, 0x73, 0x23, 0x1C, 0x6F, 0x2A, 0xE6, 0x12, 0xE5, 0x78, 0x20,
                0xC8, 0xF3, 0x46, 0xA8, 0x19, 0xCB, 0xD8, 0x60, 0x02, 0xAA, 0x81, 0x79, 0x77, 0x1A, 0x86, 0x7E,
                0xE2, 0x45, 0x53, 0x66, 0xDF, 0x9A, 0xC2, 0x3C, 0x77, 0xCD, 0x12, 0x6B, 0x8D, 0x74, 0x83, 0x2B,
                0x8A, 0xEA, 0x24, 0xAA, 0xD7,
            };

            int offset = 0;
            byte[] actual = LightweightPkcs8Decoder.ReadOctetString(data, ref offset);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadNonOctsetString()
        {
            byte[] data = { 0x30 };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadOctetString(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void ReadTooLongOctsetString()
        {
            byte[] data = { 0x04, 0x83, 0x01, 0x00, 0x00, 0xff, 0xff, /* ... */ };
            int offset = 0;

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.ReadOctetString(data, ref offset));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void GetRSAPrivateKeyOid()
        {
            byte[] data = Convert.FromBase64String(PrivateKey);
            Assert.AreEqual("1.2.840.113549.1.1.1", LightweightPkcs8Decoder.DecodePrivateKeyOid(data));
        }

        [Test]
        public void GetECDsaPrivateKeyImportedOid()
        {
            // cspell:ignore Secp
            byte[] data = Convert.FromBase64String(EcSecp256k1PrivateKey);
            Assert.AreEqual("1.2.840.10045.2.1", LightweightPkcs8Decoder.DecodePrivateKeyOid(data));
        }

        [Test]
        public void VerifyDecoder()
        {
            byte[] data = Convert.FromBase64String(PrivateKey);

            using RSA fromPem = LightweightPkcs8Decoder.DecodeRSAPkcs8(data);

            byte[] cer = Convert.FromBase64String(Pfx);
            X509Certificate2 clientCert;

#if NET9_0_OR_GREATER
            clientCert = X509CertificateLoader.LoadPkcs12(cer, null);
#else
            clientCert = new X509Certificate2(cer);
#endif
            using RSA fromPfx = clientCert.GetRSAPrivateKey();

            RSAParameters pemParams = fromPem.ExportParameters(false);
            RSAParameters pfxParams = fromPfx.ExportParameters(false);

            Assert.AreEqual(pfxParams.Modulus, pemParams.Modulus);
            Assert.AreEqual(pfxParams.Exponent, pemParams.Exponent);
            clientCert.Dispose();
        }

        [Test]
        public void VerifyDecoderBadData()
        {
            byte[] data = Convert.FromBase64String(InvalidPrivateKey);

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.DecodeRSAPkcs8(data));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        [Test]
        public void VerifyRsaDecoderWithEcKey()
        {
            byte[] data = Convert.FromBase64String(EcSecp256k1PrivateKey);

            Exception ex = Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.DecodeRSAPkcs8(data));
            Assert.AreEqual("Invalid PKCS#8 Data", ex.Message);
        }

        private const string Pfx = @"
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
10dutJHzmsRcVFCBZvojiMDovF2Ge98xh3A2AGvN/nEQBayKPqSTL4JggC+K+TpizW82MDMqcp/n
fEtWJ5v0TDBlWqapKwi12hN2JIwmfWgowKfQar2FMBB1B5agHCTHXmVY8lRBqW2dSC+lUUPakHSr
IMEfjBTm8VD+GYvnlD/1wxmsooVsxDEOvxFsLgcXlY2/5SqsLSmSEmqIjGtwcOOn6brhXBBx8V/T
VsdRw00ounu+gApAFsCSGM4/O2IRRoNpLkZrSG8v9SFj5ieZqo53mb6USyhDlgL670P/oO7C+Ta0
icNR55z/h8Yu8NBPtQ6Ahsou8/wXDnbkxqjx8LwLlGsZuHmzPecBQicn0wgRa4c2z98ycyPoLcvF
o0R6D5prvHXY3ej3wtzytXiBAcJk3Yh1BQbVUBWftRqm2TcBa5TIkvdDoNP+UWDPHoxEP008gkJp
gX0aU+xI9doprq9xM/QFClPnnHyFN6lqHUFEOT8fNAKS3bQZtZPn7Iqn0rtmtWv06wCNfdlh7MGg
fIcx1Eks2bA4nMCnA7PJaG5PDaCQsxW4yiyQhC6cNz81ZpuSqmzBdToDjwTIaOiDVfAAPhzO8284
LPp2FuLEUgVyRGJ0hCgHDIqEMp7C7sgK2uWcUUGBiHXusFuA6C3WDqLsjriCtvWkIcL4v4ByKxqh
16nPBt09mhRXXzO9gKtVJ0cvTfLyKgyIHTjQnLJLuHpKiJ/9SqrWHOv6CwTUk2OV51VedYe3emr7
Fa9dt6EPvzLTbLdB/CnEOPzh7aInR/iaiWMSNxOE7AJ8hACU8/C3QEDsjnUK6LoTzC71jWAdCPcZ
1uze0fhHYwZ67rWneQOShhHEfX2Vxlm1R8L4sbPppFHrIygR9KCPjUUj8OTNvwQUumdqE0C8iNyQ
T4E0NzGB3zATBgkqhkiG9w0BCRUxBgQEAQAAADBbBgkqhkiG9w0BCRQxTh5MAHsARQBDADkAMwBC
ADcANQA1AC0AQwA5ADYAMwAtADQANgBBADAALQA5AEIARQBDAC0ANAAzADQANgBDADkARQA4AEYA
MwBBADkAfTBrBgkrBgEEAYI3EQExXh5cAE0AaQBjAHIAbwBzAG8AZgB0ACAARQBuAGgAYQBuAGMA
ZQBkACAAQwByAHkAcAB0AG8AZwByAGEAcABoAGkAYwAgAFAAcgBvAHYAaQBkAGUAcgAgAHYAMQAu
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
AAAAAAAA";

        private const string PrivateKey = @"
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
GCW0/fPxstiXQaANvVLWIIih4VlLHg==";

        private const string InvalidPrivateKey = @"
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
TPJ0/sCkfgvKDnNAiIYJVVvu4IyYUt==";

        private const string EcSecp256k1PrivateKey = @"
MIGEAgEAMBAGByqGSM49AgEGBSuBBAAKBG0wawIBAQQggIszi9CyyZSvzCmMVSnT
XlQQz+m62V3B1Uopp/Q2gOOhRANCAASy4TPJzmokaWtXadcXAC3tz8UhGCjEiygJ
OLBbWHiQCEJSk8du+JbQe0TzijhdFwqfbkenBxX7QpStBwCNqzFU";
    }
}
