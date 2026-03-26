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

            Assert.NotNull(request);
            Assert.AreEqual("client disconnect", request.Reason);
            Assert.True(request.Mqtt.InitiatedByClient);
            Assert.AreEqual((MqttDisconnectReasonCode)0, request.Mqtt.DisconnectPacket.Code);
            Assert.AreEqual("p1", request.Mqtt.DisconnectPacket.UserProperties.Single().Name);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            MqttDisconnectedEventRequest converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual("client disconnect", converted.Reason);
            Assert.True(converted.Mqtt.InitiatedByClient);
            Assert.AreEqual(request.Mqtt.DisconnectPacket.Code, converted.Mqtt.DisconnectPacket.Code);
        }

        [Test]
        public void WithoutDisconnectPacket_RoundTrips()
        {
            const string payload = "{\"reason\":\"timeout\",\"mqtt\":{\"initiatedByClient\":false}}";

            MqttDisconnectedEventRequest request = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(payload, JsonSerializationOptions);

            Assert.NotNull(request);
            Assert.AreEqual("timeout", request.Reason);
            Assert.False(request.Mqtt.InitiatedByClient);
            Assert.IsNull(request.Mqtt.DisconnectPacket);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            MqttDisconnectedEventRequest converted = JsonSerializer.Deserialize<MqttDisconnectedEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual("timeout", converted.Reason);
            Assert.False(converted.Mqtt.InitiatedByClient);
            Assert.IsNull(converted.Mqtt.DisconnectPacket);
        }
    }
}
