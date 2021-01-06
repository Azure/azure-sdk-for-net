// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class Base64UrlTests
    {
        [Test]
        public void ValidateEncodeDecodeZeroLength()
        {
            var data = new byte[0];

            var encoded = Base64Url.Encode(data);

            Assert.AreEqual(string.Empty, encoded);

            var decoded = Base64Url.Decode(encoded);

            CollectionAssert.AreEqual(data, decoded);
        }

        [Test]
        public void ValidateEncodeDecodeStringZeroLength()
        {
            var data = string.Empty;

            var encoded = Base64Url.EncodeString(data);

            Assert.AreEqual(string.Empty, encoded);

            var decoded = Base64Url.DecodeString(encoded);

            Assert.AreEqual(data, decoded);
        }

        [Test]
        public void ValidateEncodeDecodeRandom()
        {
            var seed = new Random().Next();

            var rand = new Random(seed);

            for (int i = 1; i <= 512; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    var data = new byte[i];

                    rand.NextBytes(data);

                    var encoded = Base64Url.Encode(data);

                    var decoded = Base64Url.Decode(encoded);

                    CollectionAssert.AreEqual(data, decoded, "Data round trip failed. Seed {0}", seed);
                }
            }
        }

        [Test]
        public void ValidateEncodeDecodeStringRandom()
        {
            var seed = new Random().Next();

            var rand = new Random(seed);

            for (int i = 1; i <= 512; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    var data = GenerateRandomString(rand, i);

                    var encoded = Base64Url.EncodeString(data);

                    var decoded = Base64Url.DecodeString(encoded);

                    Assert.AreEqual(data, decoded, "String round trip failed. Seed {0}", seed);
                }
            }
        }

        public string GenerateRandomString(Random rand, int length)
        {
            var generated = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                generated.Append((char)rand.Next(1, 1024));
            }

            return generated.ToString();
        }

        private static readonly (string, string)[] s_staticValues = new (string, string)[]
        {
            ("foo", "Zm9v"),
            ("<foo!>", "PGZvbyE-"),
            ("<foo!?", "PGZvbyE_"),
            ("<foo!?><<foo?>>", "PGZvbyE_Pjw8Zm9vPz4-"),
            ("<foo!?><<foo?>>foo", "PGZvbyE_Pjw8Zm9vPz4-Zm9v")
        };

        [Test]
        public void ValidateEncodeDecodeStringStaticValues()
        {
            foreach ((string, string) valuePair in s_staticValues)
            {
                var encoded = Base64Url.EncodeString(valuePair.Item1);

                Assert.AreEqual(valuePair.Item2, encoded);

                var decoded = Base64Url.DecodeString(valuePair.Item2);

                Assert.AreEqual(valuePair.Item1, decoded);
            }
        }
    }
}
