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
            Assert.That(result, Is.Null);
        }

        [Test]
        public void DecodeConnectionStates_WhenEmpty_ReturnsNull()
        {
            var result = "".DecodeConnectionStates();
            Assert.That(result, Is.Null);
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

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result["key1"].ToString(), Is.EqualTo("value1"));
            Assert.That(result["key2"].ToObjectFromJson<int>(), Is.EqualTo(123));
        }

        [Test]
        public void DecodeConnectionStates_WhenInvalidBase64_ReturnsEmptyDictionary()
        {
            var result = "not-valid-base64!!!".DecodeConnectionStates();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void DecodeConnectionStates_WhenBase64ButNotJson_ReturnsEmptyDictionary()
        {
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("not json"));

            var result = base64.DecodeConnectionStates();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
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

            Assert.That(decoded, Is.Not.Null);
            Assert.That(decoded.Count, Is.EqualTo(2));
            Assert.That(decoded["strKey"].ToString(), Is.EqualTo("hello"));
            Assert.That(decoded["intKey"].ToObjectFromJson<int>(), Is.EqualTo(42));
        }
    }
}
#endif
