// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class LightweightPcks8DecoderTests : ClientTestBase
    {
        public LightweightPcks8DecoderTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void VerifyDecoder()
        {
            byte[] data = ExtractPrivateKeyBlobFromPem(File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem")));

            RSA fromPem = LightweightPkcs8Decoder.DecodeRSAPkcs8(data);
            RSA fromPfx = (RSA) new X509Certificate2(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-password-protected.pfx"), "password").PrivateKey;

            RSAParameters pemParams = fromPem.ExportParameters(false);
            RSAParameters pfxParams = fromPfx.ExportParameters(false);

            Assert.AreEqual(pfxParams.Modulus, pemParams.Modulus);
            Assert.AreEqual(pfxParams.Exponent, pemParams.Exponent);
        }

        public void VerifyDecoderBadData()
        {
            byte[] data = ExtractPrivateKeyBlobFromPem(File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert-invalid.pem")));

            Assert.Throws<InvalidDataException>(() => LightweightPkcs8Decoder.DecodeRSAPkcs8(data));
        }

        private byte[] ExtractPrivateKeyBlobFromPem(string pemContents)
        {
            Regex certRegex = new Regex("(-+BEGIN PRIVATE KEY-+)(\n\r?|\r\n?)([A-Za-z0-9+/\n\r]+=*)(\n\r?|\r\n?)(-+END PRIVATE KEY-+)", RegexOptions.CultureInvariant);
            return Convert.FromBase64String(certRegex.Match(pemContents).Groups[3].Value);
        }
    }
}
