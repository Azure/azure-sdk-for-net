// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

using System;

using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    public class Base64UrlJsonConverterTests
    {
        // Test vector which incorporates both URL-safe characters and padding
        private const string TestBase64NoPad = "MTA-MTE_Cg";
        private const string TestBase64Pad = "MTA-MTE_Cg==";
        private readonly byte[] TestBytes =
            new byte[] { 0x31, 0x30, 0x3e, 0x31, 0x31, 0x3f, 0x0a };

        [Fact]
        public void CanSerialize()
        {
            var holder = new Base64UrlData
            {
                Data = TestBytes,
            };
            var serializedJson = JsonConvert.SerializeObject(holder);
            var expectedJson = "{\"Data\":\"" + TestBase64NoPad + "\"}";
            Assert.Equal(expectedJson, serializedJson);
        }

        // Note: Currently handled internally by JSON.NET:
        // https://github.com/JamesNK/Newtonsoft.Json/issues/1639
        [Fact]
        public void CanSerializeNull()
        {
            var holder = new Base64UrlData();
            var serializeSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
            };
            var serializedJson = JsonConvert.SerializeObject(holder, serializeSettings);
            var expectedJson = "{\"Data\":null}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanDeserialize()
        {
            var json = "{\"Data\":\"" + TestBase64NoPad + "\"}";
            var holder = JsonConvert.DeserializeObject<Base64UrlData>(json);
            Assert.Equal(TestBytes, holder.Data);
        }

        [Fact]
        public void CanDeserializeNull()
        {
            var json = "{\"Data\":null}";
            var holder = JsonConvert.DeserializeObject<Base64UrlData>(json);
            Assert.Null(holder.Data);
        }

        [Fact]
        public void CanDeserializePadded()
        {
            var json = "{\"Data\":\"" + TestBase64Pad + "\"}";
            var holder = JsonConvert.DeserializeObject<Base64UrlData>(json);
            Assert.Equal(TestBytes, holder.Data);
        }

        [Fact]
        public void CanDeserializeNonUrlSafe()
        {
            var base64 = TestBase64NoPad.Replace('-', '+').Replace('_', '/');
            var json = "{\"Data\":\"" + base64 + "\"}";
            var holder = JsonConvert.DeserializeObject<Base64UrlData>(json);
            Assert.Equal(TestBytes, holder.Data);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeEmptyAsNull()
        {
            var json = "{\"Data\":\"\"}";
            var holder = JsonConvert.DeserializeObject<Base64UrlData>(json);
            Assert.Null(holder.Data);
        }

        [Fact]
        public void DeserializeThrowsForExtraPadding()
        {
            var json = "{\"Data\":\"" + TestBase64NoPad + "===\"}";
            Assert.Throws<FormatException>(() => JsonConvert.DeserializeObject<Base64UrlData>(json));
        }

        [Fact]
        public void DeserializeThrowsForInvalidChar()
        {
            var json = "{\"Data\":\"NotBase#64\"}";
            Assert.Throws<FormatException>(() => JsonConvert.DeserializeObject<Base64UrlData>(json));
        }

        private class Base64UrlData
        {
            [JsonConverter(typeof(Base64UrlJsonConverter))]
            public byte[] Data { get; set; }
        }
    }
}
