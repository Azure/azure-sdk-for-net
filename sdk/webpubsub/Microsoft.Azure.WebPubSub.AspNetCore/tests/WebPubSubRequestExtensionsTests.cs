// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests
{
    public class WebPubSubRequestExtensionsTests
    {
        [Test]
        public void DecodeConnectionStates_WhenNull_ReturnsNull()
        {
            string input = null;
            var result = input.DecodeConnectionStates();
            Assert.IsNull(result);
        }

        [Test]
        public void DecodeConnectionStates_WhenEmpty_ReturnsNull()
        {
            var result = "".DecodeConnectionStates();
            Assert.IsNull(result);
        }

        [Test]
        public void DecodeConnectionStates_WhenValidBase64Json_ReturnsDictionary()
        {
            var original = new Dictionary<string, BinaryData>
            {
                { "key1", BinaryData.FromString("value1") },
                { "key2", BinaryData.FromObjectAsJson(123) }
            };
            var base64 = original.EncodeConnectionStates();

            var result = base64.DecodeConnectionStates();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("value1", result["key1"].ToString());
            Assert.AreEqual(123, result["key2"].ToObjectFromJson<int>());
        }

        [Test]
        public void DecodeConnectionStates_WhenInvalidBase64_ReturnsEmptyDictionary()
        {
            var result = "not-valid-base64!!!".DecodeConnectionStates();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void DecodeConnectionStates_WhenBase64ButNotJson_ReturnsEmptyDictionary()
        {
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("not json"));

            var result = base64.DecodeConnectionStates();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void DecodeConnectionStates_RoundTripsWithEncode()
        {
            var states = new Dictionary<string, BinaryData>
            {
                { "strKey", BinaryData.FromString("hello") },
                { "intKey", BinaryData.FromObjectAsJson(42) }
            };

            var encoded = states.EncodeConnectionStates();
            var decoded = encoded.DecodeConnectionStates();

            Assert.IsNotNull(decoded);
            Assert.AreEqual(2, decoded.Count);
            Assert.AreEqual("hello", decoded["strKey"].ToString());
            Assert.AreEqual(42, decoded["intKey"].ToObjectFromJson<int>());
        }
    }
}
#endif
