// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using Xunit;

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeyAesValidationTest
    {
        [Fact]
        public void AesKeyValidation()
        {
            using (Aes aes = Aes.Create())
            {
                var key = SerializeDeserialize(aes);
                Assert.True(key.HasPrivateKey());
                Assert.True(key.IsValid());

                Aes secretKey = key.ToAes();
                EncryptDecrypt(secretKey);

                // Compare equal JSON web keys
                var sameKey = new JsonWebKey(aes);
                Assert.Equal(key, key);
                Assert.Equal(key, sameKey);
                Assert.Equal(key.GetHashCode(), sameKey.GetHashCode());
            }
        }

        [Fact]
        public void InvalidKeyOps()
        {
            var key = new JsonWebKey(Aes.Create());
            key.KeyOps = new string[] { JsonWebKeyOperation.Encrypt, "foo" };
            Assert.False(key.IsValid());
        }

        [Fact]
        public void OctHashCode()
        {
            JsonWebKey key = new JsonWebKey(Aes.Create());

            // Compare hash codes for unequal JWK that would not map to the same hash
            Assert.NotEqual(key.GetHashCode(), new JsonWebKey() { K = key.K }.GetHashCode());
            Assert.NotEqual(key.GetHashCode(), new JsonWebKey() { Kty = key.Kty }.GetHashCode());
            
            // Compare hash codes for unequal JWK that would map to the same hash
            Assert.Equal(key.GetHashCode(), new JsonWebKey() { K = key.K, Kty = key.Kty }.GetHashCode());
        }


        private void EncryptDecrypt(Aes aes)
        {
            byte[] encrypted = Encrypt("content to be encrypted", aes);

            // Decrypt the bytes to a string.
            Decrypt(encrypted, aes);
        }

        private byte[] Encrypt(string plainText, Aes aes)
        {
            byte[] encrypted;

            // Encrypt the string to an array of bytes using encryptor.
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            // Encryption stream.
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cs))
                    {

                        // write to the stream
                        sw.Write(plainText);
                    }
                    encrypted = ms.ToArray();
                }
            }
            return encrypted;
        }

        private string Decrypt(byte[] encrypted, Aes aes)
        {
            string plaintext = string.Empty;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            // Create the streams used for decryption.
            using (var ms = new MemoryStream(encrypted))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        // read from the stream
                        plaintext = sr.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        private JsonWebKey SerializeDeserialize(Aes aes)
        {
            JsonWebKey webKey = new JsonWebKey(aes);
            string serializedKey = webKey.ToString();
            return JsonConvert.DeserializeObject<JsonWebKey>(serializedKey);
        }
    }
}
