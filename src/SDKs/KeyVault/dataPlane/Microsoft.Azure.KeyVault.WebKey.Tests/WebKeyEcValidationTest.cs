//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
using System.Linq;
using System.Security.Cryptography;
using Xunit;

// ReSharper disable InconsistentNaming

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeyEcValidationTest
    {

        // Encrypt and Decrypt methods used by the test cases.
        private static byte[] _data = new byte[] { 1, 3, 2, 7 };
        private static string[] signOperations = new[] { JsonWebKeyOperation.Sign, JsonWebKeyOperation.Verify };
        private static CngKeyCreationParameters cngKeyCreationParameters = new CngKeyCreationParameters
        {
            ExportPolicy = CngExportPolicies.AllowPlaintextExport,
            KeyCreationOptions = CngKeyCreationOptions.OverwriteExistingKey,
            KeyUsage = CngKeyUsages.Signing
        };

        private void SignVerify(ECDsa privateKey, ECDsa publicKey)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(_data);

                var signedHash = privateKey.SignHash(hash);
                var verifiedHash = publicKey.VerifyHash(hash, signedHash);
                Assert.True(verifiedHash);
            }
        }

        private void SignVerify(ECDsa ecdsa)
        {
            SignVerify(ecdsa, ecdsa);
        }

        [Fact]
        public void RoundTripP256Test()
        {
            var usePrivateKey = true;

            using (var ecdsa = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP256, "P256ecdsa", cngKeyCreationParameters)))
            {
                var jwk = new JsonWebKey(ecdsa, usePrivateKey);
                VerifyJsonWebKeyEcdsa(jwk, usePrivateKey, JsonWebKeyECCurve.P256, signOperations);

                var ecdsa_jwk = jwk.ToECDsa(usePrivateKey);
                
                Assert.Equal(ecdsa_jwk.KeySize, ecdsa.KeySize);
#if NET452
                Assert.Equal(ecdsa_jwk.SignatureAlgorithm, ecdsa.SignatureAlgorithm);
#endif
                SignVerify(ecdsa_jwk);
            }
        }

        [Fact]
        public void RoundTripP384Test()
        {
            var usePrivateKey = true;

            using (var ecdsa = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP384, "P384ecdsa", cngKeyCreationParameters)))
            {
                var jwk = new JsonWebKey(ecdsa, usePrivateKey);
                VerifyJsonWebKeyEcdsa(jwk, usePrivateKey, JsonWebKeyECCurve.P384, signOperations);

                var ecdsa_jwk = jwk.ToECDsa(usePrivateKey);

                Assert.Equal(ecdsa_jwk.KeySize, ecdsa.KeySize);
#if NET452
                Assert.Equal(ecdsa_jwk.SignatureAlgorithm, ecdsa.SignatureAlgorithm);
#endif
                SignVerify(ecdsa_jwk);
            }
        }

        [Fact]
        public void RoundTripP521Test()
        {
            var usePrivateKey = true;

            using (var ecdsa = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP521, "P521ecdsa", cngKeyCreationParameters)))
            {
                var jwk = new JsonWebKey(ecdsa, usePrivateKey);
                VerifyJsonWebKeyEcdsa(jwk, usePrivateKey, JsonWebKeyECCurve.P521, signOperations);

                var ecdsa_jwk = jwk.ToECDsa(usePrivateKey);

                Assert.Equal(ecdsa_jwk.KeySize, ecdsa.KeySize);
#if NET452
                Assert.Equal(ecdsa_jwk.SignatureAlgorithm, ecdsa.SignatureAlgorithm);
#endif
                SignVerify(ecdsa_jwk);
            }
        }

        [Fact]
        public void PublicOnlyKeyTest()
        {
            var usePrivateKey = false;

            using (var ecdsa = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP256, "P256ecdsa", cngKeyCreationParameters)))
            {
                var jwk = new JsonWebKey(ecdsa, usePrivateKey);
                VerifyJsonWebKeyEcdsa(jwk, usePrivateKey, JsonWebKeyECCurve.P256, signOperations);

                var ecdsa_jwk = jwk.ToECDsa(usePrivateKey);

                Assert.Equal(ecdsa_jwk.KeySize, ecdsa.KeySize);
#if NET452
                Assert.Equal(ecdsa_jwk.SignatureAlgorithm, ecdsa.SignatureAlgorithm);
                // Private key doesn't exist. Sign should fail with Key is missing.
                Assert.Throws<CryptographicException>(()=>SignVerify(ecdsa_jwk));
#endif
            }
        }

        [Fact]
        public void PrivateSignPublicVerifyTest()
        {
            using (var ecdsa = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP256, "P256ecdsa", cngKeyCreationParameters)))
            {
                var publicKey = new JsonWebKey(ecdsa, false);
                var privateKey = new JsonWebKey(ecdsa, true);
                SignVerify(privateKey.ToECDsa(true), publicKey.ToECDsa(false));
            }
        }

        [Fact]
        public void PublicSignPrivateVerifyTest()
        {
            using (var ecdsa = new ECDsaCng(CngKey.Create(CngAlgorithm.ECDsaP256, "P256ecdsa", cngKeyCreationParameters)))
            {
                var publicKey = new JsonWebKey(ecdsa, false);
                Assert.Throws<CryptographicException>(() => publicKey.ToECDsa(true));
            }
        }

        private void VerifyJsonWebKeyEcdsa(JsonWebKey jwk, bool usePrivateKey, string eccurve, string[] ops)
        {
            if(usePrivateKey)
                Assert.NotNull(jwk.D);
            else
                Assert.Null(jwk.D);

            Assert.NotNull(jwk.X);
            Assert.NotNull(jwk.Y);
            Assert.Equal(jwk.ECCurve, eccurve);
            Assert.True(ops.SequenceEqual(jwk.KeyOps));
            Assert.Equal(jwk.Kty, JsonWebKeyType.EllipticCurve);

            Assert.Null(jwk.DP);
            Assert.Null(jwk.DQ);
            Assert.Null(jwk.E);
            Assert.Null(jwk.K);
            Assert.Null(jwk.N);
            Assert.Null(jwk.P);
            Assert.Null(jwk.Q);
            Assert.Null(jwk.QI);
            Assert.Null(jwk.T);
        }
    }
}