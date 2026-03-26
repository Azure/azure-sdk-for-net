// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class MqttConnectEventRequestJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip()
        {
            const string payload = "{\"claims\":{\"sub\":[\"user1\"]},\"query\":{\"q\":[\"v\"]},\"subprotocols\":[\"mqtt\"],\"clientCertificates\":[],\"headers\":{\"h\":[\"v\"]},\"mqtt\":{\"protocolVersion\":5,\"username\":\"user\",\"password\":\"pass\",\"userProperties\":[{\"name\":\"k\",\"value\":\"v\"}]}}";

            MqttConnectEventRequest request = JsonSerializer.Deserialize<MqttConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.NotNull(request);
            Assert.AreEqual("user1", request.Claims["sub"].Single());
            Assert.AreEqual(MqttProtocolVersion.V500, request.Mqtt.ProtocolVersion);
            Assert.AreEqual("user", request.Mqtt.Username);
            Assert.AreEqual("pass", request.Mqtt.Password);
            Assert.AreEqual("k", request.Mqtt.UserProperties.Single().Name);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            MqttConnectEventRequest converted = JsonSerializer.Deserialize<MqttConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(request.Mqtt.ProtocolVersion, converted.Mqtt.ProtocolVersion);
            Assert.AreEqual(request.Mqtt.Username, converted.Mqtt.Username);
            Assert.AreEqual(request.Mqtt.Password, converted.Mqtt.Password);
            Assert.AreEqual(request.Claims["sub"].Single(), converted.Claims["sub"].Single());
        }
    }
}
