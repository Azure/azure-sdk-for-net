// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET462
using System;
using System.Formats.Cbor;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyKeyParserTests
    {
        private static string B64Url(byte[] bytes) =>
            Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

        private static string BuildJwk(string kid, string crv, ECParameters p) =>
            $"{{\"kty\":\"EC\",\"kid\":\"{kid}\",\"crv\":\"{crv}\",\"x\":\"{B64Url(p.Q.X)}\",\"y\":\"{B64Url(p.Q.Y)}\"}}";

        private static byte[] BuildJwks(params string[] jwks) =>
            Encoding.UTF8.GetBytes("{\"keys\":[" + string.Join(",", jwks) + "]}");

        private static byte[] BuildCoseKey(string kid, int coseCrv, ECParameters p, bool includePrivate = false, bool compressedY = false)
        {
            var writer = new CborWriter();
            writer.WriteStartMap(includePrivate ? 6 : 5);
            writer.WriteInt32(1);
            writer.WriteInt32(2); // kty: EC2
            writer.WriteInt32(2);
            writer.WriteByteString(Encoding.UTF8.GetBytes(kid)); // kid
            writer.WriteInt32(-1);
            writer.WriteInt32(coseCrv); // crv
            writer.WriteInt32(-2);
            writer.WriteByteString(p.Q.X); // x
            writer.WriteInt32(-3);
            if (compressedY)
            {
                writer.WriteBoolean(true);
            }
            else
            {
                writer.WriteByteString(p.Q.Y); // y
            }
            if (includePrivate)
            {
                writer.WriteInt32(-4);
                writer.WriteByteString(new byte[] { 1, 2, 3 }); // d (private)
            }
            writer.WriteEndMap();
            return writer.Encode();
        }

        private static byte[] BuildCoseKeySet(params byte[][] coseKeys)
        {
            var writer = new CborWriter();
            writer.WriteStartArray(coseKeys.Length);
            foreach (byte[] key in coseKeys)
            {
                writer.WriteEncodedValue(key);
            }
            writer.WriteEndArray();
            return writer.Encode();
        }

        private static (ECCurve Curve, string Crv, int CoseCrv) CurveInfo(string crv) => crv switch
        {
            "P-256" => (ECCurve.NamedCurves.nistP256, "P-256", 1),
            "P-384" => (ECCurve.NamedCurves.nistP384, "P-384", 2),
            "P-521" => (ECCurve.NamedCurves.nistP521, "P-521", 3),
            _ => throw new ArgumentException(crv),
        };

        [TestCase("P-256")]
        [TestCase("P-384")]
        [TestCase("P-521")]
        public void ParseJwks_RoundTripsPublicKey(string crv)
        {
            (ECCurve curve, string crvName, _) = CurveInfo(crv);
            using ECDsa full = ECDsa.Create(curve);
            ECParameters pub = full.ExportParameters(false);

            CodeTransparencyVerificationKeySet set = CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(BuildJwk("key-1", crvName, pub)));

            Assert.AreEqual(1, set.Keys.Count);
            Assert.AreEqual("key-1", set.Keys[0].KeyId);

            // The normalized public key must verify a signature created by the original private key.
            byte[] data = Encoding.UTF8.GetBytes("hello code transparency");
            byte[] signature = full.SignData(data, HashAlgorithmName.SHA256);
            using ECDsa verifier = set.Keys[0].ToECDsa();
            Assert.IsTrue(verifier.VerifyData(data, signature, HashAlgorithmName.SHA256));
        }

        [TestCase("P-256")]
        [TestCase("P-384")]
        [TestCase("P-521")]
        public void ParseJwkAndCose_ProduceEquivalentKeys(string crv)
        {
            (ECCurve curve, string crvName, int coseCrv) = CurveInfo(crv);
            using ECDsa full = ECDsa.Create(curve);
            ECParameters pub = full.ExportParameters(false);

            CodeTransparencyVerificationKey fromJwk = CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(BuildJwk("k", crvName, pub))).Keys[0];
            CodeTransparencyVerificationKey fromCose = CodeTransparencyKeyParser.ParseCoseKey(BuildCoseKey("k", coseCrv, pub));

            ECParameters a = fromJwk.ExportPublicParameters();
            ECParameters b = fromCose.ExportPublicParameters();
            Assert.AreEqual(fromJwk.KeyId, fromCose.KeyId);
            CollectionAssert.AreEqual(a.Q.X, b.Q.X);
            CollectionAssert.AreEqual(a.Q.Y, b.Q.Y);
        }

        [Test]
        public void ParseCoseKeySet_RoundTripsMultipleKeys()
        {
            using ECDsa k1 = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            using ECDsa k2 = ECDsa.Create(ECCurve.NamedCurves.nistP384);
            byte[] cbor = BuildCoseKeySet(
                BuildCoseKey("k1", 1, k1.ExportParameters(false)),
                BuildCoseKey("k2", 2, k2.ExportParameters(false)));

            CodeTransparencyVerificationKeySet set = CodeTransparencyKeyParser.ParseCoseKeySet(cbor);

            Assert.AreEqual(2, set.Keys.Count);
            Assert.IsTrue(set.TryGetKey("k1", out _));
            Assert.IsTrue(set.TryGetKey("k2", out _));
        }

        [Test]
        public void ParseJwks_MalformedBase64Url_ThrowsFormatException()
        {
            string jwk = "{\"kty\":\"EC\",\"kid\":\"k\",\"crv\":\"P-256\",\"x\":\"@@@not-base64@@@\",\"y\":\"AAAA\"}";
            Assert.Throws<FormatException>(() => CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(jwk)));
        }

        [Test]
        public void ParseJwks_OffCurvePoint_ThrowsFormatException()
        {
            // Valid-length but off-curve coordinates.
            byte[] x = new byte[32];
            byte[] y = new byte[32];
            x[31] = 1;
            y[31] = 1;
            string jwk = $"{{\"kty\":\"EC\",\"kid\":\"k\",\"crv\":\"P-256\",\"x\":\"{B64Url(x)}\",\"y\":\"{B64Url(y)}\"}}";
            Assert.Throws<FormatException>(() => CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(jwk)));
        }

        [Test]
        public void ParseJwks_UnsupportedKeyType_ThrowsNotSupportedException()
        {
            string jwk = "{\"kty\":\"RSA\",\"kid\":\"k\",\"n\":\"AAAA\",\"e\":\"AQAB\"}";
            Assert.Throws<NotSupportedException>(() => CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(jwk)));
        }

        [Test]
        public void ParseJwks_UnsupportedCurve_ThrowsNotSupportedException()
        {
            string jwk = "{\"kty\":\"EC\",\"kid\":\"k\",\"crv\":\"P-192\",\"x\":\"AAAA\",\"y\":\"AAAA\"}";
            Assert.Throws<NotSupportedException>(() => CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(jwk)));
        }

        [Test]
        public void ParseJwks_MissingKid_ThrowsFormatException()
        {
            string jwk = "{\"kty\":\"EC\",\"crv\":\"P-256\",\"x\":\"AAAA\",\"y\":\"AAAA\"}";
            Assert.Throws<FormatException>(() => CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(jwk)));
        }

        [Test]
        public void ParseJwks_PrivateMaterial_ThrowsFormatException()
        {
            using ECDsa full = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            ECParameters pub = full.ExportParameters(false);
            string jwk = $"{{\"kty\":\"EC\",\"kid\":\"k\",\"crv\":\"P-256\",\"x\":\"{B64Url(pub.Q.X)}\",\"y\":\"{B64Url(pub.Q.Y)}\",\"d\":\"AAAA\"}}";
            Assert.Throws<FormatException>(() => CodeTransparencyKeyParser.ParseJwksJson(BuildJwks(jwk)));
        }

        [Test]
        public void ParseJwks_DuplicateKid_ThrowsArgumentException()
        {
            using ECDsa full = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            ECParameters pub = full.ExportParameters(false);
            byte[] jwks = BuildJwks(BuildJwk("dup", "P-256", pub), BuildJwk("dup", "P-256", pub));
            Assert.Throws<ArgumentException>(() => CodeTransparencyKeyParser.ParseJwksJson(jwks));
        }

        [Test]
        public void ParseCoseKeySet_MalformedCbor_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => CodeTransparencyKeyParser.ParseCoseKeySet(new byte[] { 0xFF, 0x00, 0x13 }));
        }

        [Test]
        public void ParseCoseKey_PrivateMaterial_ThrowsFormatException()
        {
            using ECDsa full = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            byte[] cose = BuildCoseKey("k", 1, full.ExportParameters(false), includePrivate: true);
            Assert.Throws<FormatException>(() => CodeTransparencyKeyParser.ParseCoseKey(cose));
        }

        [Test]
        public void ParseCoseKey_CompressedPoint_ThrowsNotSupportedException()
        {
            using ECDsa full = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            byte[] cose = BuildCoseKey("k", 1, full.ExportParameters(false), compressedY: true);
            Assert.Throws<NotSupportedException>(() => CodeTransparencyKeyParser.ParseCoseKey(cose));
        }
    }
}
#endif
