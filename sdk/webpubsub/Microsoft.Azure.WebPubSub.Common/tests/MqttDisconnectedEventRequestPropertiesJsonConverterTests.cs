// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class MqttDisconnectedEventRequestPropertiesJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip_BackwardCompatible()
        {
            const string payload = "{\"initiatedByClient\":false,\"disconnectPacket\":{\"code\":128,\"userProperties\":[{\"name\":\"u1\",\"value\":\"v1\"}]}}";

            MqttDisconnectedEventRequestProperties properties = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(payload, JsonSerializationOptions);

            Assert.NotNull(properties);
            Assert.False(properties.InitiatedByClient);
            Assert.NotNull(properties.DisconnectPacket);
            Assert.AreEqual((MqttDisconnectReasonCode)128, properties.DisconnectPacket.Code);
            Assert.AreEqual("u1", properties.DisconnectPacket.UserProperties.Single().Name);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectedEventRequestProperties converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.False(converted.InitiatedByClient);
            Assert.AreEqual(properties.DisconnectPacket.Code, converted.DisconnectPacket.Code);
            Assert.AreEqual(properties.DisconnectPacket.UserProperties.Single().Value, converted.DisconnectPacket.UserProperties.Single().Value);
        }

        [Test]
        public void NoDisconnectPacket_RoundTrips()
        {
            const string payload = "{\"initiatedByClient\":true}";

            MqttDisconnectedEventRequestProperties properties = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(payload, JsonSerializationOptions);

            Assert.NotNull(properties);
            Assert.True(properties.InitiatedByClient);
            Assert.IsNull(properties.DisconnectPacket);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectedEventRequestProperties converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.True(converted.InitiatedByClient);
            Assert.IsNull(converted.DisconnectPacket);
        }

        [Test]
        public void MissingInitiatedByClient_Throws()
        {
            const string payload = "{\"disconnectPacket\":{\"code\":128}}";

            Assert.Throws<JsonException>(() =>
                JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(payload, JsonSerializationOptions));
        }
    }
}
