// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class JsonWebKeyTests
    {
        [Test]
        public void Aes_Defaults_KeyOps()
        {
            using Aes aes = Aes.Create();
            JsonWebKey jwk = new JsonWebKey(aes);

            CollectionAssert.AreEqual(new[] { JsonWebKeyOperations.Encrypt, JsonWebKeyOperations.Decrypt, JsonWebKeyOperations.WrapKey, JsonWebKeyOperations.UnwrapKey }, jwk.KeyOps);
        }

        [Test]
        public void SerializeOctet()
        {
            using Aes aes = Aes.Create();
            JsonWebKey jwk = new JsonWebKey(aes);
            ReadOnlyMemory<byte> serialized = jwk.Serialize();
            Assert.True(HasPrivateKey(jwk));

            using MemoryStream ms = new MemoryStream(serialized.ToArray());
            JsonWebKey deserialized = new JsonWebKey();
            deserialized.Deserialize(ms);

            Assert.That(deserialized, Is.EqualTo(jwk).Using(JsonWebKeyComparer.Instance));
        }

        [Test]
        public void ToAes()
        {
            using Aes aes = Aes.Create();
            JsonWebKey jwk = new JsonWebKey(aes);
            Assert.True(HasPrivateKey(jwk));

            Aes key = jwk.ToAes();
            CollectionAssert.AreEqual(jwk.K, key.Key);
        }

        [Test]
        public void ToAes_Invalid_KeyType()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                KeyType = JsonWebKeyType.Other,
            };

            Assert.Throws<InvalidOperationException>(() => jwk.ToAes());
        }

        [Test]
        public void ToAes_Invalid_Key()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                KeyType = JsonWebKeyType.Octet,
                K = null,
            };

            Assert.Throws<InvalidOperationException>(() => jwk.ToAes());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ECDsa_Defaults_KeyOps(bool includePrivateParameters)
        {
#if NET461
            Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net461.");
#else
            using ECDsa ecdsa = ECDsa.Create();
            JsonWebKey jwk = new JsonWebKey(ecdsa, includePrivateParameters);

            if (includePrivateParameters)
            {
                CollectionAssert.AreEqual(new[] { JsonWebKeyOperations.Sign, JsonWebKeyOperations.Verify }, jwk.KeyOps);
            }
            else
            {
                CollectionAssert.AreEqual(new[] { JsonWebKeyOperations.Sign }, jwk.KeyOps);
            }
#endif
        }

        [TestCaseSource(nameof(GetECDSaTestData))]
        public void SerializeECDsa(string oid, string friendlyName, bool includePrivateParameters)
        {
#if NET461
            Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net461.");
#else
            using ECDsa ecdsa = ECDsa.Create();
            ecdsa.GenerateKey(ECCurve.CreateFromValue(oid));

            JsonWebKey jwk = new JsonWebKey(ecdsa, includePrivateParameters);
            Assert.AreEqual(friendlyName, jwk.CurveName);

            ReadOnlyMemory<byte> serialized = jwk.Serialize();
            Assert.AreEqual(includePrivateParameters, HasPrivateKey(jwk));

            using MemoryStream ms = new MemoryStream(serialized.ToArray());
            JsonWebKey deserialized = new JsonWebKey();
            deserialized.Deserialize(ms);

            Assert.That(deserialized, Is.EqualTo(jwk).Using(JsonWebKeyComparer.Instance));
#endif
        }

        [TestCaseSource(nameof(GetECDSaTestData))]
        public void ToECDsa(string oid, string friendlyName, bool includePrivateParameters)
        {
#if NET461
            Assert.Ignore("Creating ECDsa with JsonWebKey is not supported on net461.");
#else
            using ECDsa ecdsa = ECDsa.Create();
            int bitLength = ecdsa.KeySize;

            JsonWebKey jwk = new JsonWebKey(ecdsa, includePrivateParameters);

            ECDsa key = jwk.ToECDsa(includePrivateParameters);
            Assert.AreEqual(bitLength, key.KeySize);
#endif
        }

        [Test]
        public void ToECDsa_Invalid_KeyType()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                KeyType = JsonWebKeyType.Other,
            };

            Assert.Throws<InvalidOperationException>(() => jwk.ToECDsa());
        }

        [TestCaseSource(nameof(GetECDSaInvalidTestData))]
        public void ToECDsa_Invalid_Key(string curveName, byte[] x, byte[] y, string name)
        {
#if NET461
            Assert.Ignore("Creating ECDsa with JsonWebKey is not supported on net461.");
#else
            JsonWebKey jwk = new JsonWebKey
            {
                KeyType = JsonWebKeyType.EllipticCurve,
                CurveName = curveName,
                X = x,
                Y = y,
            };

            Assert.Throws<InvalidOperationException>(() => jwk.ToECDsa(), "Expected exception not thrown for data named '{0}'", name);
#endif
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RSA_Defaults_KeyOps(bool includePrivateParameters)
        {
            using RSA rsa = RSA.Create();
            JsonWebKey jwk = new JsonWebKey(rsa, includePrivateParameters);

            if (includePrivateParameters)
            {
                CollectionAssert.AreEqual(new[] { JsonWebKeyOperations.Encrypt, JsonWebKeyOperations.Decrypt, JsonWebKeyOperations.Sign, JsonWebKeyOperations.Verify, JsonWebKeyOperations.WrapKey, JsonWebKeyOperations.UnwrapKey }, jwk.KeyOps);
            }
            else
            {
                CollectionAssert.AreEqual(new[] { JsonWebKeyOperations.Encrypt, JsonWebKeyOperations.Verify, JsonWebKeyOperations.WrapKey }, jwk.KeyOps);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SerializeRSA(bool includePrivateParameters)
        {
            using RSA rsa = RSA.Create();
            JsonWebKey jwk = new JsonWebKey(rsa, includePrivateParameters);
            ReadOnlyMemory<byte> serialized = jwk.Serialize();
            Assert.AreEqual(includePrivateParameters, HasPrivateKey(jwk));

            using MemoryStream ms = new MemoryStream(serialized.ToArray());
            JsonWebKey deserialized = new JsonWebKey();
            deserialized.Deserialize(ms);

            Assert.That(deserialized, Is.EqualTo(jwk).Using(JsonWebKeyComparer.Instance));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ToRSA(bool includePrivateParameters)
        {
            using RSA rsa = RSA.Create();
            JsonWebKey jwk = new JsonWebKey(rsa, includePrivateParameters);
            int bitLength = jwk.N.Length * 8;
            Assert.AreEqual(includePrivateParameters, HasPrivateKey(jwk));

            RSA key = jwk.ToRSA(includePrivateParameters);
            Assert.AreEqual(bitLength, key.KeySize);
        }

        [Test]
        public void ToRSA_Invalid_KeyType()
        {
            JsonWebKey jwk = new JsonWebKey
            {
                KeyType = JsonWebKeyType.Other,
            };

            Assert.Throws<InvalidOperationException>(() => jwk.ToRSA());
        }

        [TestCaseSource(nameof(GetRSAInvalidKeyData))]
        public void ToRSA_Invalid_Key(RSAParameters rsaParameters, string name)
        {
            JsonWebKey jwk = new JsonWebKey
            {
                KeyType = JsonWebKeyType.Rsa,
                E = rsaParameters.Exponent,
                N = rsaParameters.Modulus,
            };

            Assert.Throws<InvalidOperationException>(() => jwk.ToRSA(), "Expected exception not thrown for data named '{0}'", name);
        }

        private static IEnumerable<object> GetECDSaTestData()
        {
            (string Oid, string FriendlyName)[] oids = new[]
            {
                ("1.2.840.10045.3.1.7", "P-256"),
                ("1.3.132.0.10", "P-256K"),
                ("1.3.132.0.34", "P-384"),
                ("1.3.132.0.35", "P-521"),
            };

            foreach (var oid in oids)
            {
                yield return new object[] { oid.Oid, oid.FriendlyName, false };
                yield return new object[] { oid.Oid, oid.FriendlyName, true };
            }
        }

        private static IEnumerable<object> GetECDSaInvalidTestData()
        {
            const string curveName = "P-256";
            byte[] x = { 0x34, 0x64, 0xc8, 0x7e, 0x68, 0xc5, 0x62, 0xa6, 0x09, 0xe4, 0x72, 0xd4, 0xd5, 0xa2, 0x75, 0xec, 0x7a, 0x9f, 0x12, 0x73, 0x4a, 0xe1, 0x00, 0x5c, 0x27, 0x40, 0x0d, 0x90, 0x61, 0x4b, 0xe8, 0x58 };
            byte[] y = { 0xbe, 0x85, 0xa3, 0x9a, 0xc9, 0x8f, 0xa8, 0xf3, 0x18, 0xc8, 0xfc, 0x33, 0x74, 0xff, 0x75, 0x6b, 0x0d, 0xe3, 0xf9, 0x66, 0x52, 0xff, 0x8b, 0x40, 0x61, 0x24, 0xd5, 0x1e, 0x7c, 0xd2, 0x79, 0x14 };

            static byte[] Resize(byte[] buffer)
            {
                byte[] result = new byte[buffer.Length + 1];
                result[0] = 0xff;
                Array.Copy(buffer, 0, result, 1, buffer.Length);

                return result;
            }

            yield return new object[] { null, x, y, "nullCurveName" };
            yield return new object[] { "invalid", x, y, "invalidCurveName" };

            yield return new object[] { curveName, null, y, "nullX" };
            yield return new object[] { curveName, Array.Empty<byte>(), y, "emptyX" };
            yield return new object[] { curveName, new byte[x.Length], y, "zeroX" };
            yield return new object[] { curveName, Resize(x), y, "longerX" };

            yield return new object[] { curveName, x, null, "nullY" };
            yield return new object[] { curveName, x, Array.Empty<byte>(), "emptyY" };
            yield return new object[] { curveName, x, new byte[x.Length], "zeroY" };
            yield return new object[] { curveName, x, Resize(y), "longerY" };
        }

        private static IEnumerable<object> GetRSAInvalidKeyData()
        {
            using RSA rsa = RSA.Create();
            RSAParameters rsaParameters = rsa.ExportParameters(false);

            RSAParameters nullE = rsaParameters;
            nullE.Exponent = null;
            yield return new object[] { nullE, nameof(nullE) };

            RSAParameters emptyE = rsaParameters;
            emptyE.Exponent = Array.Empty<byte>();
            yield return new object[] { emptyE, nameof(emptyE) };

            RSAParameters zeroE = rsaParameters;
            zeroE.Exponent = new byte[] { 0, 0, 0, 0 };
            yield return new object[] { zeroE, nameof(zeroE) };

            RSAParameters longerE = rsaParameters;
            longerE.Exponent = new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5 };
            yield return new object[] { longerE, nameof(longerE) };

            RSAParameters nullN = rsaParameters;
            nullN.Modulus = null;
            yield return new object[] { nullN, nameof(nullE) };

            RSAParameters emptyN = rsaParameters;
            emptyN.Modulus = Array.Empty<byte>();
            yield return new object[] { emptyN, nameof(emptyN) };

            RSAParameters zeroN = rsaParameters;
            zeroN.Modulus = new byte[] { 0, 0, 0, 0 };
            yield return new object[] { zeroN, nameof(zeroN) };
        }

        private static bool HasPrivateKey(JsonWebKey jwk)
        {
            switch (jwk.KeyType)
            {
                case JsonWebKeyType.Octet:
                    return jwk.K != null;

                case JsonWebKeyType.EllipticCurve:
                case JsonWebKeyType.EllipticCurveHsm:
                    return jwk.D != null;

                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    return jwk.D != null && jwk.DP != null && jwk.DQ != null && jwk.P != null && jwk.Q != null && jwk.QI != null;

                default:
                    return false;
            }
        }

        private class JsonWebKeyComparer : IEqualityComparer<JsonWebKey>
        {
            internal static readonly IEqualityComparer<JsonWebKey> Instance = new JsonWebKeyComparer();

            public bool Equals(JsonWebKey x, JsonWebKey y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null || y is null) return false;

                if (!string.Equals(x.KeyId, y.KeyId)) return false;
                if (x.KeyType != y.KeyType) return false;
                if (!CollectionEquals(x.KeyOps, y.KeyOps)) return false;

                if (x.KeyType == JsonWebKeyType.Octet)
                {
                    return CollectionEquals(x.K, y.K);
                }

                if (x.KeyType == JsonWebKeyType.Rsa)
                {
                    return CollectionEquals(x.E, y.E)
                        && CollectionEquals(x.N, y.N)
                        && CollectionEquals(x.D, y.D)
                        && CollectionEquals(x.DP, y.DP)
                        && CollectionEquals(x.DQ, y.DQ)
                        && CollectionEquals(x.P, y.P)
                        && CollectionEquals(x.Q, y.Q)
                        && CollectionEquals(x.QI, y.QI);
                }

                if (x.KeyType == JsonWebKeyType.EllipticCurve)
                {
                    return CollectionEquals(x.D, y.D)
                        && CollectionEquals(x.X, y.X)
                        && CollectionEquals(x.Y, y.Y);
                }

                throw new NotImplementedException();
            }

            public int GetHashCode(JsonWebKey obj) => obj?.KeyType switch
            {
                null => 0,
                JsonWebKeyType.Octet => HashCodeBuilder.Combine(obj.KeyType, obj.K),
                JsonWebKeyType.Rsa => HashCodeBuilder.Combine(obj.KeyType, obj.N),
                JsonWebKeyType.EllipticCurve => HashCodeBuilder.Combine(obj.KeyType, obj.X),
                _ => throw new NotImplementedException(),
            };

            private static bool CollectionEquals<T>(ICollection<T> x, ICollection<T> y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return y.Count == 0;
                if (y is null) return x.Count == 0;

                return x.SequenceEqual(y);
            }
        }
    }
}
