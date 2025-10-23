// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Azure.Core.TestFramework;
using Azure.Security.CodeTransparency.Receipt;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CcfReceiptVerifierTests : ClientTestBase
    {
        private string _fileQualifierPrefix;

        public CcfReceiptVerifierTests(bool isAsync) : base(isAsync)
        {
        }

        private byte[] readFileBytes(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix + name))
            using (MemoryStream mem = new())
            {
                if (stream == null)
                    throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix + name);
                stream.CopyTo(mem);
                return mem.ToArray();
            }
        }

        [SetUp]
        public void BaseSetUp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "receipt.cose";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[] { mustExistFilename }, StringSplitOptions.None)[0];
        }

        [Test]
        public void RunVerifyTransparentStatementReceipt_KidMismatch_ThrowInvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"fb29ce6d6b37e7a0b03a5fc94205490e1c37de1f41f68b92e3620021e9981d01\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"Tv_tP9eJIb5oJY9YB6iAzMfds4v3N84f8pgcPYLaxd_Nj3Nb_dBm6Fc8ViDZQhGR\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] receiptBytes = readFileBytes("receipt.cose");
            byte[] inputSignedPayloadBytes = readFileBytes("input_signed_claims");

            Response<JwksDocument> key = client.GetPublicKeys();

            var exception = Assert.Throws<InvalidOperationException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt(key.Value.Keys[0], receiptBytes, inputSignedPayloadBytes));
            StringAssert.Contains(expected: "KID mismatch", exception.Message);
#endif
        }

        [Test]
        public void RunVerifyTransparentStatementReceipt_ClaimDigestMismatch_ThrowInvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"87d64669f1c5988e28f22da4f3526334de860ad2395a71a735de59f9ec3aa662\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"9y7Zs09nKjYQHdJ7oAsxftOvSK9RfGWJM3p0_5XXyBuvkUs-kN-YB-EQCCuB_Hsw\"," +
                "\"y\": \"teV4Jkd2zphYJa2gPSm5HEjuvEM9MNu3e5E7z1L_0s0GWKaEqmHpAiXBtLGHC5-A\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] receiptBytes = readFileBytes("receipt.cose");
            byte[] inputSignedPayloadBytes = readFileBytes("input_signed_claims");

            Response<JwksDocument> key = client.GetPublicKeys();

            var exception = Assert.Throws<InvalidOperationException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt(key.Value.Keys[0], receiptBytes, inputSignedPayloadBytes));
            StringAssert.Contains(expected: "Claim digest mismatch", exception.Message);
#endif
        }
    }
}
