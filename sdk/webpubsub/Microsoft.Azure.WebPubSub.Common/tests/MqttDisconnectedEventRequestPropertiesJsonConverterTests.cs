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

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.InitiatedByClient, Is.False);
            Assert.That(properties.DisconnectPacket, Is.Not.Null);
            Assert.That(properties.DisconnectPacket.Code, Is.EqualTo((MqttDisconnectReasonCode)128));
            Assert.That(properties.DisconnectPacket.UserProperties.Single().Name, Is.EqualTo("u1"));

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectedEventRequestProperties converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.InitiatedByClient, Is.False);
            Assert.That(converted.DisconnectPacket.Code, Is.EqualTo(properties.DisconnectPacket.Code));
            Assert.That(converted.DisconnectPacket.UserProperties.Single().Value, Is.EqualTo(properties.DisconnectPacket.UserProperties.Single().Value));
        }

        [Test]
        public void NoDisconnectPacket_RoundTrips()
        {
            const string payload = "{\"initiatedByClient\":true}";

            MqttDisconnectedEventRequestProperties properties = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(payload, JsonSerializationOptions);

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.InitiatedByClient, Is.True);
            Assert.That(properties.DisconnectPacket, Is.Null);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectedEventRequestProperties converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequestProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.InitiatedByClient, Is.True);
            Assert.That(converted.DisconnectPacket, Is.Null);
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
