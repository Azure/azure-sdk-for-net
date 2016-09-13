// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeyClearMemoryTest
    {
        [Fact]
        public void ClearMemoryTest()
        {
            foreach (var kty in JsonWebKeyType.AllTypes)
            {
                Console.WriteLine("Checking JsonWebKey with " + kty);
                CheckInstance(new JsonWebKey(), kty);
            }
        }

        private static void CheckInstance(object key, string kty)
        {
            dynamic dkey = key;
            dkey.Kty = kty;
            var arrays = FillWithRandomData(key);

            switch (kty)
            {
                case JsonWebKeyType.Octet:
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
                    Console.WriteLine("Not checking property " + property.Name);
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
            Console.WriteLine("Property " + propName + " was cleared.");
        }
    }
}
