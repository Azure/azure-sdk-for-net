// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Azure.Core.TestFramework;
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

        [Test]
        public void GetRegistrationTransactionId_ReturnsEntryIdFromReceipt()
        {
            byte[] receiptBytes = readFileBytes("receipt.cose");

            string entryId = CcfReceipt.GetRegistrationTransactionId(receiptBytes);

            Assert.AreEqual("8.198", entryId);
        }

        [Test]
        public void GetRegistrationTransactionId_ReturnsNullForInvalidInput()
        {
            Assert.IsNull(CcfReceipt.GetRegistrationTransactionId(null));
            Assert.IsNull(CcfReceipt.GetRegistrationTransactionId(Array.Empty<byte>()));
            Assert.IsNull(CcfReceipt.GetRegistrationTransactionId(new byte[] { 0x01, 0x02, 0x03 }));
        }

        private const string MatchingKid = "87d64669f1c5988e28f22da4f3526334de860ad2395a71a735de59f9ec3aa662";

        private static JsonWebKey CreateMatchingP384Key() => CodeTransparencyModelFactory.JsonWebKey(
            crv: "P-384",
            kid: MatchingKid,
            kty: "EC",
            x: "9y7Zs09nKjYQHdJ7oAsxftOvSK9RfGWJM3p0_5XXyBuvkUs-kN-YB-EQCCuB_Hsw",
            y: "teV4Jkd2zphYJa2gPSm5HEjuvEM9MNu3e5E7z1L_0s0GWKaEqmHpAiXBtLGHC5-A");

        private static string Base64UrlEncode(byte[] value) =>
            Convert.ToBase64String(value).TrimEnd('=').Replace('+', '-').Replace('/', '_');

#if !NET462
        private static JsonWebKey ToJsonWebKey(ECDsa key, string curveName, string kid)
        {
            ECParameters parameters = key.ExportParameters(includePrivateParameters: false);
            return CodeTransparencyModelFactory.JsonWebKey(
                crv: curveName,
                kid: kid,
                kty: "EC",
                x: Base64UrlEncode(parameters.Q.X),
                y: Base64UrlEncode(parameters.Q.Y));
        }
#endif

        [Test]
        public void VerifyTransparentStatementReceipt_EcdsaOverload_BehavesIdenticallyToJsonWebKeyOverload()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] receiptBytes = readFileBytes("receipt.cose");
            byte[] inputSignedPayloadBytes = readFileBytes("input_signed_claims");
            JsonWebKey jsonWebKey = CreateMatchingP384Key();

            // The JWK overload reaches the claim-digest check, which means the ECDsa signature over
            // the accumulator verified successfully with this key.
            var fromJwk = Assert.Throws<InvalidOperationException>(
                () => CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, receiptBytes, inputSignedPayloadBytes));

            using ECDsa publicKey = CcfReceiptVerifier.ConvertToECDsa(jsonWebKey);
            var fromEcdsa = Assert.Throws<InvalidOperationException>(
                () => CcfReceiptVerifier.VerifyTransparentStatementReceipt(publicKey, MatchingKid, receiptBytes, inputSignedPayloadBytes));

            StringAssert.Contains("Claim digest mismatch", fromJwk.Message);
            Assert.AreEqual(fromJwk.Message, fromEcdsa.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatementReceipt_EcdsaOverload_KidMismatch_Throws()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] receiptBytes = readFileBytes("receipt.cose");
            byte[] inputSignedPayloadBytes = readFileBytes("input_signed_claims");

            using ECDsa publicKey = CcfReceiptVerifier.ConvertToECDsa(CreateMatchingP384Key());

            var exception = Assert.Throws<InvalidOperationException>(
                () => CcfReceiptVerifier.VerifyTransparentStatementReceipt(publicKey, "not-the-right-kid", receiptBytes, inputSignedPayloadBytes));
            StringAssert.Contains("KID mismatch", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatementReceipt_EcdsaOverload_KeySizeAlgorithmMismatch_Throws()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] receiptBytes = readFileBytes("receipt.cose");
            byte[] inputSignedPayloadBytes = readFileBytes("input_signed_claims");

            // The receipt is signed with ES384; a P-256 key must be rejected on the algorithm check.
            using ECDsa p256 = ECDsa.Create(ECCurve.NamedCurves.nistP256);

            var exception = Assert.Throws<InvalidOperationException>(
                () => CcfReceiptVerifier.VerifyTransparentStatementReceipt(p256, MatchingKid, receiptBytes, inputSignedPayloadBytes));
            StringAssert.Contains("The ECDsa key uses the wrong algorithm. Expected -7 Found -35", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatementReceipt_NullArguments_Throw()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] some = new byte[] { 0x01 };
            using ECDsa key = ECDsa.Create(ECCurve.NamedCurves.nistP256);

            Assert.Throws<ArgumentNullException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt((JsonWebKey)null, some, some));
            Assert.Throws<ArgumentNullException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt((ECDsa)null, "kid", some, some));
            Assert.Throws<ArgumentNullException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt(key, null, some, some));
            Assert.Throws<ArgumentException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt(key, string.Empty, some, some));
            Assert.Throws<ArgumentNullException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt(key, "kid", null, some));
            Assert.Throws<ArgumentNullException>(() => CcfReceiptVerifier.VerifyTransparentStatementReceipt(key, "kid", some, null));
#endif
        }

        [TestCase("P-256", 256)]
        [TestCase("P-384", 384)]
        [TestCase("P-521", 521)]
        public void ConvertToECDsa_RoundTripsSupportedCurves(string curveName, int expectedKeySize)
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            ECCurve curve = curveName switch
            {
                "P-256" => ECCurve.NamedCurves.nistP256,
                "P-384" => ECCurve.NamedCurves.nistP384,
                _ => ECCurve.NamedCurves.nistP521
            };

            using ECDsa original = ECDsa.Create(curve);
            JsonWebKey jwk = ToJsonWebKey(original, curveName, "kid-" + curveName);

            using ECDsa converted = CcfReceiptVerifier.ConvertToECDsa(jwk);

            Assert.AreEqual(expectedKeySize, converted.KeySize);

            // The converted key must validate a signature produced by the original private key.
            byte[] data = new byte[] { 1, 2, 3, 4, 5 };
            byte[] signature = original.SignData(data, HashAlgorithmName.SHA256);
            Assert.IsTrue(converted.VerifyData(data, signature, HashAlgorithmName.SHA256));
#endif
        }

        [Test]
        public void ConvertToECDsa_P521_IsSupported()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            // Regression test: the previous implementation matched on the non-existent curve name
            // "P-512" and expected COSE algorithm -39 (PS512) rather than -36 (ES512), so P-521
            // keys always fell through to the default branch and threw.
            using ECDsa original = ECDsa.Create(ECCurve.NamedCurves.nistP521);
            JsonWebKey jwk = ToJsonWebKey(original, "P-521", "p521-kid");

            using ECDsa converted = CcfReceiptVerifier.ConvertToECDsa(jwk);

            Assert.AreEqual(521, converted.KeySize);
#endif
        }

        [Test]
        public void ConvertToECDsa_RejectsUnsupportedCurve()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            JsonWebKey jwk = CodeTransparencyModelFactory.JsonWebKey(crv: "P-512", kid: "k", kty: "EC", x: "AQAB", y: "AQAB");

            var exception = Assert.Throws<InvalidOperationException>(() => CcfReceiptVerifier.ConvertToECDsa(jwk));
            StringAssert.Contains("Unsupported elliptic curve 'P-512'.", exception.Message);
#endif
        }

        [Test]
        public void ConvertToECDsa_RejectsNonEcKeyType()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            JsonWebKey jwk = CodeTransparencyModelFactory.JsonWebKey(crv: "P-256", kid: "k", kty: "RSA", x: "AQAB", y: "AQAB");

            var exception = Assert.Throws<InvalidOperationException>(() => CcfReceiptVerifier.ConvertToECDsa(jwk));
            StringAssert.Contains("Only EC keys are supported", exception.Message);
#endif
        }

        [TestCase(null, "AQAB")]
        [TestCase("AQAB", null)]
        [TestCase("", "AQAB")]
        [TestCase("AQAB", "")]
        public void ConvertToECDsa_RejectsMissingCoordinates(string x, string y)
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            JsonWebKey jwk = CodeTransparencyModelFactory.JsonWebKey(crv: "P-256", kid: "k", kty: "EC", x: x, y: y);

            var exception = Assert.Throws<InvalidOperationException>(() => CcfReceiptVerifier.ConvertToECDsa(jwk));
            StringAssert.Contains("missing the X or Y coordinate", exception.Message);
#endif
        }
    }
}
