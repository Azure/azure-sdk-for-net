// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class BinaryDataJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void Deserializes_LegacyBufferPayload()
        {
            const string payload = "{\"data\":{\"type\":\"Buffer\",\"data\":[65,66,67]},\"dataType\":\"Binary\"}";

            UserEventResponse response = JsonSerializer.Deserialize<UserEventResponse>(payload, JsonSerializationOptions);

            Assert.NotNull(response);
            CollectionAssert.AreEqual(new byte[] { 65, 66, 67 }, response.Data.ToArray());
            Assert.AreEqual(WebPubSubDataType.Binary, response.DataType);
        }

        [Test]
        public void StringToken_ReturnsStringData()
        {
            const string payload = "{\"data\":\"hello world\",\"dataType\":\"Text\"}";

            UserEventResponse response = JsonSerializer.Deserialize<UserEventResponse>(payload, JsonSerializationOptions);

            Assert.NotNull(response);
            Assert.AreEqual("hello world", response.Data.ToString());
        }

        [Test]
        public void BufferWithValidArray_ReturnsFromBytes()
        {
            const string payload = "{\"data\":{\"type\":\"Buffer\",\"data\":[72,101,108,108,111]},\"dataType\":\"Binary\"}";

            UserEventResponse response = JsonSerializer.Deserialize<UserEventResponse>(payload, JsonSerializationOptions);

            Assert.NotNull(response);
            CollectionAssert.AreEqual(new byte[] { 72, 101, 108, 108, 111 }, response.Data.ToArray());
        }

        [Test]
        public void BufferWithEmptyArray_ReturnsEmptyBytes()
        {
            const string payload = "{\"data\":{\"type\":\"Buffer\",\"data\":[]},\"dataType\":\"Binary\"}";

            UserEventResponse response = JsonSerializer.Deserialize<UserEventResponse>(payload, JsonSerializationOptions);

            Assert.NotNull(response);
            Assert.AreEqual(0, response.Data.ToArray().Length);
        }

        [Test]
        public void RoundTrip_StringValue()
        {
            var response = new UserEventResponse("test message", WebPubSubDataType.Text);

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            UserEventResponse converted = JsonSerializer.Deserialize<UserEventResponse>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual("test message", converted.Data.ToString());
        }
    }
}
