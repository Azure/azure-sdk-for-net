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

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Claims["sub"].Single(), Is.EqualTo("user1"));
            Assert.That(request.Mqtt.ProtocolVersion, Is.EqualTo(MqttProtocolVersion.V500));
            Assert.That(request.Mqtt.Username, Is.EqualTo("user"));
            Assert.That(request.Mqtt.Password, Is.EqualTo("pass"));
            Assert.That(request.Mqtt.UserProperties.Single().Name, Is.EqualTo("k"));

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            MqttConnectEventRequest converted = JsonSerializer.Deserialize<MqttConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Mqtt.ProtocolVersion, Is.EqualTo(request.Mqtt.ProtocolVersion));
            Assert.That(converted.Mqtt.Username, Is.EqualTo(request.Mqtt.Username));
            Assert.That(converted.Mqtt.Password, Is.EqualTo(request.Mqtt.Password));
            Assert.That(converted.Claims["sub"].Single(), Is.EqualTo(request.Claims["sub"].Single()));
        }
    }
}
