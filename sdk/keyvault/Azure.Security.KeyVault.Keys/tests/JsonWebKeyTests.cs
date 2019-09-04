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
        public void SerializeOctet()
        {
            JsonWebKey jwk = new JsonWebKey(Aes.Create());
            ReadOnlyMemory<byte> serialized = jwk.Serialize();
            Assert.True(jwk.HasPrivateKey);

            using MemoryStream ms = new MemoryStream(serialized.ToArray());
            JsonWebKey deserialized = new JsonWebKey();
            deserialized.Deserialize(ms);

            Assert.That(deserialized, Is.EqualTo(jwk).Using(JsonWebKeyComparer.Instance));
        }

        [Test]
        public void ToAes()
        {
            JsonWebKey jwk = new JsonWebKey(Aes.Create());
            Assert.True(jwk.HasPrivateKey);

            Aes key = jwk.ToAes();
            CollectionAssert.AreEqual(jwk.K, key.Key);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SerializeECDsa(bool includePrivateParameters)
        {
#if NET461
            Assert.Ignore("Not implemented on .NET Framework 4.6.1");
#else
            JsonWebKey jwk = new JsonWebKey(ECDsa.Create(), includePrivateParameters);
            ReadOnlyMemory<byte> serialized = jwk.Serialize();
            Assert.AreEqual(includePrivateParameters, jwk.HasPrivateKey);

            using MemoryStream ms = new MemoryStream(serialized.ToArray());
            JsonWebKey deserialized = new JsonWebKey();
            deserialized.Deserialize(ms);

            Assert.That(deserialized, Is.EqualTo(jwk).Using(JsonWebKeyComparer.Instance));
#endif
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SerializeRSA(bool includePrivateParameters)
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), includePrivateParameters);
            ReadOnlyMemory<byte> serialized = jwk.Serialize();
            Assert.AreEqual(includePrivateParameters, jwk.HasPrivateKey);

            using MemoryStream ms = new MemoryStream(serialized.ToArray());
            JsonWebKey deserialized = new JsonWebKey();
            deserialized.Deserialize(ms);

            Assert.That(deserialized, Is.EqualTo(jwk).Using(JsonWebKeyComparer.Instance));
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

                if (x.KeyType == KeyType.Octet)
                {
                    return CollectionEquals(x.K, y.K);
                }

                if (x.KeyType == KeyType.Rsa)
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

                if (x.KeyType == KeyType.EllipticCurve)
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
                KeyType.Octet => HashCodeBuilder.Combine(obj.KeyType, obj.K),
                KeyType.Rsa => HashCodeBuilder.Combine(obj.KeyType, obj.N),
                KeyType.EllipticCurve => HashCodeBuilder.Combine(obj.KeyType, obj.X),
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
