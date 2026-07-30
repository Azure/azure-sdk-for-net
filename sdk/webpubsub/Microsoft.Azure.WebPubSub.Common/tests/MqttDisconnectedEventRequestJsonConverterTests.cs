// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class MqttDisconnectedEventRequestJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip()
        {
            const string payload = "{\"reason\":\"client disconnect\",\"mqtt\":{\"initiatedByClient\":true,\"disconnectPacket\":{\"code\":0,\"userProperties\":[{\"name\":\"p1\",\"value\":\"v1\"}]}}}";

            MqttDisconnectedEventRequest request = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Reason, Is.EqualTo("client disconnect"));
            Assert.That(request.Mqtt.InitiatedByClient, Is.True);
            Assert.That(request.Mqtt.DisconnectPacket.Code, Is.EqualTo((MqttDisconnectReasonCode)0));
            Assert.That(request.Mqtt.DisconnectPacket.UserProperties.Single().Name, Is.EqualTo("p1"));

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            MqttDisconnectedEventRequest converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Reason, Is.EqualTo("client disconnect"));
            Assert.That(converted.Mqtt.InitiatedByClient, Is.True);
            Assert.That(converted.Mqtt.DisconnectPacket.Code, Is.EqualTo(request.Mqtt.DisconnectPacket.Code));
        }

        [Test]
        public void WithoutDisconnectPacket_RoundTrips()
        {
            const string payload = "{\"reason\":\"timeout\",\"mqtt\":{\"initiatedByClient\":false}}";

            MqttDisconnectedEventRequest request = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Reason, Is.EqualTo("timeout"));
            Assert.That(request.Mqtt.InitiatedByClient, Is.False);
            Assert.That(request.Mqtt.DisconnectPacket, Is.Null);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            MqttDisconnectedEventRequest converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Reason, Is.EqualTo("timeout"));
            Assert.That(converted.Mqtt.InitiatedByClient, Is.False);
            Assert.That(converted.Mqtt.DisconnectPacket, Is.Null);
        }
    }
}
