// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using Xunit;

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeyOperationsTest
    {
        [Fact]
        public void ClearMemoryTest()
        {
            foreach (var kty in JsonWebKeyType.AllTypes)
            {
                CheckInstance(new JsonWebKey(), kty);
            }
        }

        [Fact]
        public void JwkEqualsTests()
        {
            // Not equal keys, second key is null
            JsonWebKey key1 = new JsonWebKey();
            JsonWebKey key2 = null;
            Assert.False(key1.Equals(key2));

            // Not equal keys, their operations are different and need to handle null
            key2 = new JsonWebKey();
            key1.KeyOps = new[] { "ops" };
            key2.KeyOps = null;
            Assert.False(key1.Equals(key2));
            key1.KeyOps = null;
            key2.KeyOps = new[] { "ops" };
            Assert.False(key1.Equals(key2));

            // Equal keys, fields are null
            key1 = new JsonWebKey();
            key2 = new JsonWebKey();
            Assert.True(key1.Equals(key2));

            // Equal keys with most fields are set to a value.
            var param = RSA.Create().ExportParameters(true);
            key1 = new JsonWebKey(param);
            key2 = new JsonWebKey(param);
            key1.KeyOps = new[] { "ops1", "ops2" };
            key2.KeyOps = new[] { "ops1", "ops2" };
            Assert.True(key1.Equals(key2));
        }

        private static void CheckInstance(object key, string kty)
        {
            dynamic dkey = key;
            dkey.Kty = kty;
            var arrays = FillWithRandomData(key);

            switch (kty)
            {
                case JsonWebKeyType.Octet:
                case JsonWebKeyType.EllipticCurve:
                case JsonWebKeyType.EllipticCurveHsm:
                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    // Supported types must have ClearMemory() implemented.
                    dkey.ClearMemory();
                    VerifyArraysCleared(arrays);
                    break;

                default:
                    // Unsupported types must throw exception.
                    try
                    {
                        dkey.ClearMemory();
                        throw new Exception("If " + kty + " is supported, modify this test. If not, make sure ClearMemory() throws NotImplementedException.");
                    }
                    catch (NotImplementedException)
                    {
                        // Expected.
                    }
                    break;

            }
        }

        private static IDictionary<string, byte[]> FillWithRandomData(object key)
        {
            // Use reflection to test all properties, not just the "expected" ones.
            var result = new Dictionary<string, byte[]>();
            var random = new Random(0);
            var properties = key.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType != typeof(byte[]))
                {
                    // Ignoring the property
                    continue;
                }
                // Assume the property is writable.
                var array = new byte[1024];
                random.NextBytes(array);
                property.SetValue(key, array);
                result.Add(property.Name, array);
            }
            return result;
        }

        private static void VerifyArraysCleared(IDictionary<string, byte[]> arrays)
        {
            foreach (var property in arrays)
                VerifyCleared(property.Key, property.Value);
        }

        private static void VerifyCleared(string propName, byte[] array)
        {
            foreach (var octet in array)
                if (octet != 0)
                    throw new Exception("The array of property " + propName + " was not cleared.");
        }
    }
}
