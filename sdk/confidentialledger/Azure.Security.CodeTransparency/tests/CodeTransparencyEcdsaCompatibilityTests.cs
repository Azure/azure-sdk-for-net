// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET462
using System;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyEcdsaCompatibilityTests
    {
        [Test]
        public void VerificationKey_UsesDirectCngWithoutDisposingCallerKey()
        {
            using var callerKey = new ECDsaCng(256);
            var verificationKey = new CodeTransparencyVerificationKey("key-1", callerKey);
            byte[] hash = ComputeHash("caller-owned key remains usable");

            byte[] signature = callerKey.SignHash(hash);

            Assert.IsTrue(callerKey.VerifyHash(hash, signature));
            using ECDsa verifier = verificationKey.ToECDsa();
            Assert.IsTrue(verifier.VerifyHash(hash, signature));
        }

        [Test]
        public void TrustStore_RoundTripUsesDirectCng()
        {
            using var callerKey = new ECDsaCng(384);
            var verificationKey = new CodeTransparencyVerificationKey("key-1", callerKey);
            var store = new CodeTransparencyTrustStore();
            store.SetKeys("ledger.example", new CodeTransparencyVerificationKeySet(new[] { verificationKey }));

            CodeTransparencyTrustStore restored = CodeTransparencyTrustStore.FromBinaryData(store.ToBinaryData());

            Assert.IsTrue(restored.TryGetKeys("ledger.example", out CodeTransparencyVerificationKeySet keys));
            byte[] hash = ComputeHash("restored trust store key");
            byte[] signature = callerKey.SignHash(hash);
            using ECDsa verifier = keys.Keys[0].ToECDsa();
            Assert.IsTrue(verifier.VerifyHash(hash, signature));
        }

        [Test]
        public void ParseJwks_UsesDirectCng()
        {
            using var callerKey = new ECDsaCng(256);
            byte[] blob = callerKey.Key.Export(CngKeyBlobFormat.EccPublicBlob);
            byte[] x = new byte[32];
            byte[] y = new byte[32];
            Buffer.BlockCopy(blob, 8, x, 0, x.Length);
            Buffer.BlockCopy(blob, 8 + x.Length, y, 0, y.Length);
            string json = $"{{\"keys\":[{{\"kty\":\"EC\",\"kid\":\"key-1\",\"crv\":\"P-256\",\"x\":\"{Base64Url(x)}\",\"y\":\"{Base64Url(y)}\"}}]}}";

            CodeTransparencyVerificationKeySet keys =
                CodeTransparencyKeyParser.ParseJwksJson(Encoding.UTF8.GetBytes(json));

            byte[] hash = ComputeHash("parsed JWK");
            byte[] signature = callerKey.SignHash(hash);
            using ECDsa verifier = keys.Keys[0].ToECDsa();
            Assert.IsTrue(verifier.VerifyHash(hash, signature));
        }

        private static byte[] ComputeHash(string value)
        {
            using SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
        }

        private static string Base64Url(byte[] value) =>
            Convert.ToBase64String(value).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }
}
#endif
