// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
#if !NET462

    public class EcCryptographyProviderTests
    {
        [TestCase("sign", true)]
        [TestCase("verify", true)]
        [TestCase("encrypt", false)]
        [TestCase("decrypt", false)]
        [TestCase("wrapKey", false)]
        [TestCase("unwrapKey", false)]
        public void SupportsOperation(string operationValue, bool supported)
        {
            JsonWebKey jwk = KeyModelFactory.JsonWebKey(KeyType.Ec, curveName: KeyCurveName.P256, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });

            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            KeyOperation operation = new KeyOperation(operationValue);

            Assert.AreEqual(supported, client.SupportsOperation(operation));
        }

        [Test]
        public void SupportsOperationUnsupportedCurve()
        {
            JsonWebKey jwk = KeyModelFactory.JsonWebKey(KeyType.Ec, curveName: "invalid", keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });

            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);

            // The provider caches the original allow key operations to facilitate tracing. Operation will still be sent to the service.
            Assert.IsTrue(client.SupportsOperation(KeyOperation.Sign));
        }

        [Test]
        public void SupportsOperationUnauthorizedOperation()
        {
            JsonWebKey jwk = KeyModelFactory.JsonWebKey(KeyType.Ec, curveName: "invalid", keyOps: new[] { KeyOperation.Verify });

            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);

            Assert.IsFalse(client.SupportsOperation(KeyOperation.Sign));
        }

        [Test]
        public async Task Sign()
        {
            using ECDsa ecdsa = ECDsa.Create();
            ecdsa.GenerateKey(ECCurve.NamedCurves.nistP256);

            JsonWebKey jwk = new JsonWebKey(ecdsa, true) { Id = "test" };
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignatureAlgorithm algorithm = GetSignatureAlgorithm(jwk);

            byte[] digest = new byte[] { 0x9f, 0x86, 0xd0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f, 0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15, 0xa3, 0xbf, 0x4f, 0x1b, 0x2b, 0x0b, 0x82, 0x2c, 0xd1, 0x5d, 0x6c, 0x15, 0xb0, 0xf0, 0x0a, 0x08 };
            SignResult result = await client.SignAsync(algorithm, digest, default);

            Assert.AreEqual(algorithm, result.Algorithm);
            Assert.AreEqual("test", result.KeyId);
            Assert.AreEqual(64, result.Signature.Length);
        }

        [Test]
        public void SignThrowsOnNullDigest()
        {
            using ECDsa ecdsa = ECDsa.Create();

            JsonWebKey jwk = new JsonWebKey(ecdsa);
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignatureAlgorithm algorithm = GetSignatureAlgorithm(jwk);

            Assert.Throws<ArgumentNullException>(() => client.Sign(algorithm, null, default));
        }

        [TestCaseSource(nameof(GetInvalidKeys))]
        public void SignThrowsOnInvalidKey(JsonWebKey jwk, SignatureAlgorithm algorithm)
        {
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);

            byte[] digest = new byte[1] { 0xff };
            Assert.Throws<ArgumentException>(() => client.Sign(algorithm, digest, default), "Expected exception with wrong key length");
        }

        [Test]
        public void SignReturnsNullWithoutPrivateKey()
        {
            using ECDsa ecdsa = ECDsa.Create();
            ECParameters ecParameters = ecdsa.ExportParameters(false);
            ecdsa.ImportParameters(ecParameters);

            JsonWebKey jwk = new JsonWebKey(ecdsa)
            {
                Id = "test",
            };

            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignatureAlgorithm algorithm = GetSignatureAlgorithm(jwk);

            Assert.IsNull(client.Sign(algorithm, new byte[] { 0xff }, default));
        }

        [Test]
        public void SignReturnsNullOnUnsupported()
        {
            JsonWebKey jwk = KeyModelFactory.JsonWebKey(KeyType.Ec, curveName: "invalid", keyOps: new[] { KeyOperation.Sign });

            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignResult result = client.Sign(default, new byte[] { 0xff }, default);

            Assert.IsNull(result);
        }

        [Test]
        public async Task Verify()
        {
            using ECDsa ecdsa = ECDsa.Create();
            ecdsa.GenerateKey(ECCurve.NamedCurves.nistP256);

            JsonWebKey jwk = new JsonWebKey(ecdsa, true) { Id = "test" };
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignatureAlgorithm algorithm = GetSignatureAlgorithm(jwk);

            byte[] digest = new byte[] { 0x9f, 0x86, 0xd0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f, 0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15, 0xa3, 0xbf, 0x4f, 0x1b, 0x2b, 0x0b, 0x82, 0x2c, 0xd1, 0x5d, 0x6c, 0x15, 0xb0, 0xf0, 0x0a, 0x08 };
            SignResult signResult = await client.SignAsync(algorithm, digest, default);
            VerifyResult verifyResult = await client.VerifyAsync(algorithm, digest, signResult.Signature, default);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual("test", verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);
        }

        [Test]
        public void VerifyThrowsOnNullDigest()
        {
            using ECDsa ecdsa = ECDsa.Create();

            JsonWebKey jwk = new JsonWebKey(ecdsa);
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignatureAlgorithm algorithm = GetSignatureAlgorithm(jwk);

            Assert.Throws<ArgumentNullException>(() => client.Verify(algorithm, null, null, default));
        }

        [Test]
        public void VerifyThrowsOnNullSignature()
        {
            using ECDsa ecdsa = ECDsa.Create();

            JsonWebKey jwk = new JsonWebKey(ecdsa);
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);
            SignatureAlgorithm algorithm = GetSignatureAlgorithm(jwk);

            Assert.Throws<ArgumentNullException>(() => client.Verify(algorithm, new byte[] { 0xff }, null, default));
        }

        [TestCaseSource(nameof(GetInvalidKeys))]
        public void VerifyThrowsOnInvalidKey(JsonWebKey jwk, SignatureAlgorithm algorithm)
        {
            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);

            byte[] digest = new byte[] { 0xff };
            byte[] signature = new byte[] { 0xff, 0xff };
            Assert.Throws<ArgumentException>(() => client.Verify(algorithm, digest, signature, default), "Expected exception with wrong key length");
        }

        [Test]
        public void VerifyReturnsNullOnUnsupported()
        {
            JsonWebKey jwk = KeyModelFactory.JsonWebKey(KeyType.Ec, curveName: "invalid", keyOps: new[] { KeyOperation.Sign });

            EcCryptographyProvider client = new EcCryptographyProvider(jwk, null, false);

            byte[] digest = new byte[] { 0xff };
            byte[] signature = new byte[] { 0xff, 0xff };
            VerifyResult result = client.Verify(default, digest, signature, default);

            Assert.IsNull(result);
        }

        [Test]
        public void SignBeforeValidDate()
        {
            using ECDsa ecdsa = ECDsa.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(ecdsa),
                Properties =
                {
                    NotBefore = DateTimeOffset.Now.AddDays(1),
                },
            };

            EcCryptographyProvider client = new EcCryptographyProvider(key.Key, key.Properties, false);

            byte[] digest = new byte[] { 0x9f, 0x86, 0xd0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f, 0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15, 0xa3, 0xbf, 0x4f, 0x1b, 0x2b, 0x0b, 0x82, 0x2c, 0xd1, 0x5d, 0x6c, 0x15, 0xb0, 0xf0, 0x0a, 0x08 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => client.Sign(GetSignatureAlgorithm(key.Key), digest, default));
            Assert.AreEqual($"The key \"test\" is not valid before {key.Properties.NotBefore.Value:r}.", ex.Message);
        }

        [Test]
        public void SignAfterValidDate()
        {
            using ECDsa ecdsa = ECDsa.Create();

            KeyVaultKey key = new KeyVaultKey("test")
            {
                Key = new JsonWebKey(ecdsa),
                Properties =
                {
                    ExpiresOn = DateTimeOffset.Now.AddDays(-1),
                },
            };

            EcCryptographyProvider client = new EcCryptographyProvider(key.Key, key.Properties, false);

            byte[] digest = new byte[] { 0x9f, 0x86, 0xd0, 0x81, 0x88, 0x4c, 0x7d, 0x65, 0x9a, 0x2f, 0xea, 0xa0, 0xc5, 0x5a, 0xd0, 0x15, 0xa3, 0xbf, 0x4f, 0x1b, 0x2b, 0x0b, 0x82, 0x2c, 0xd1, 0x5d, 0x6c, 0x15, 0xb0, 0xf0, 0x0a, 0x08 };
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => client.Sign(GetSignatureAlgorithm(key.Key), digest, default));
            Assert.AreEqual($"The key \"test\" is not valid after {key.Properties.ExpiresOn.Value:r}.", ex.Message);
        }

        private static IEnumerable<TestCaseData> GetInvalidKeys()
        {
            static IEnumerable<(string, SignatureAlgorithm[])> GetInvalidPairs()
            {
                yield return ("1.2.840.10045.3.1.7", new[] { SignatureAlgorithm.ES256K, SignatureAlgorithm.ES384, SignatureAlgorithm.ES512 }); // P-256
                yield return ("1.3.132.0.10", new[] { SignatureAlgorithm.ES256, SignatureAlgorithm.ES384, SignatureAlgorithm.ES512 }); // P-256K
                yield return ("1.3.132.0.34", new[] { SignatureAlgorithm.ES256, SignatureAlgorithm.ES256K, SignatureAlgorithm.ES512 }); // P-384
                yield return ("1.3.132.0.35", new[] { SignatureAlgorithm.ES256, SignatureAlgorithm.ES256K, SignatureAlgorithm.ES384 }); // P-521
            };

            foreach ((string oid, SignatureAlgorithm[] algorithms) in GetInvalidPairs())
            {
                using ECDsa ecdsa = ECDsa.Create();
                ECCurve curve = ECCurve.CreateFromValue(oid);

                bool supported = true;
                try
                {
                    ecdsa.GenerateKey(curve);
                }
                catch (NotSupportedException)
                {
                    supported = false;
                }

                if (supported)
                {
                    JsonWebKey jwk = new JsonWebKey(ecdsa, true)
                    {
                        Id = "test",
                    };

                    foreach (SignatureAlgorithm algorithm in algorithms)
                    {
                        yield return new TestCaseData(jwk, algorithm);
                    }
                }
                else
                {
                    yield return new TestCaseData(null, default(SignatureAlgorithm)).Ignore($"This platform does not support OID {oid}");
                }
            }
        }

        private static SignatureAlgorithm GetSignatureAlgorithm(JsonWebKey jwk)
        {
            if (jwk.CurveName == KeyCurveName.P256)
            {
                return SignatureAlgorithm.ES256Value;
            }

            if (jwk.CurveName == KeyCurveName.P256K)
            {
                return SignatureAlgorithm.ES256KValue;
            }

            if (jwk.CurveName == KeyCurveName.P384)
            {
                return SignatureAlgorithm.ES384Value;
            }

            if (jwk.CurveName == KeyCurveName.P521)
            {
                return SignatureAlgorithm.ES512Value;
            }

            throw new NotSupportedException();
        }
    }

#endif
}
