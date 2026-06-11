// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class MqttConnectEventErrorResponseJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip_BackwardCompatible()
        {
            const string payload = "{\"mqtt\":{\"code\":135,\"reason\":\"error message\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}";

            MqttConnectEventErrorResponse response = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Mqtt.Code, Is.EqualTo(135));
            Assert.That(response.Mqtt.Reason, Is.EqualTo("error message"));
            Assert.That(response.Mqtt.UserProperties.Single().Name, Is.EqualTo("a"));
            Assert.That(response.Mqtt.UserProperties.Single().Value, Is.EqualTo("b"));

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Mqtt.Code, Is.EqualTo(response.Mqtt.Code));
            Assert.That(converted.Mqtt.Reason, Is.EqualTo(response.Mqtt.Reason));
            Assert.That(converted.Mqtt.UserProperties.Single().Name, Is.EqualTo(response.Mqtt.UserProperties.Single().Name));
        }

        [Test]
        public void NullUserProperties_RoundTrips()
        {
            const string payload = "{\"mqtt\":{\"code\":135,\"reason\":null,\"userProperties\":null}}";

            MqttConnectEventErrorResponse response = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Mqtt.Code, Is.EqualTo(135));
            Assert.That(response.Mqtt.Reason, Is.Null);
            Assert.That(response.Mqtt.UserProperties, Is.Null);

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Mqtt.Code, Is.EqualTo(135));
            Assert.That(converted.Mqtt.Reason, Is.Null);
            Assert.That(converted.Mqtt.UserProperties, Is.Null);
        }

        [Test]
        public void MissingMqttProperty_Throws()
        {
            const string payload = "{\"other\":\"value\"}";

            Assert.Throws<JsonException>(() =>
                JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions));
        }

        [Test]
        public void MultipleUserProperties_RoundTrips()
        {
            const string payload = "{\"mqtt\":{\"code\":135,\"reason\":\"err\",\"userProperties\":[{\"name\":\"a\",\"value\":\"1\"},{\"name\":\"b\",\"value\":\"2\"},{\"name\":\"c\",\"value\":\"3\"}]}}";

            MqttConnectEventErrorResponse response = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Mqtt.UserProperties.Count, Is.EqualTo(3));
            Assert.That(response.Mqtt.UserProperties[0].Name, Is.EqualTo("a"));
            Assert.That(response.Mqtt.UserProperties[1].Name, Is.EqualTo("b"));
            Assert.That(response.Mqtt.UserProperties[2].Name, Is.EqualTo("c"));

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Mqtt.UserProperties.Count, Is.EqualTo(3));
            for (int i = 0; i < 3; i++)
            {
                Assert.That(converted.Mqtt.UserProperties[i].Name, Is.EqualTo(response.Mqtt.UserProperties[i].Name));
                Assert.That(converted.Mqtt.UserProperties[i].Value, Is.EqualTo(response.Mqtt.UserProperties[i].Value));
            }
        }

        [Test]
        public void V311Code_RoundTrips()
        {
            // Code < 0x80 indicates MQTT 3.1.1
            const string payload = "{\"mqtt\":{\"code\":4,\"reason\":\"bad credentials\",\"userProperties\":null}}";

            MqttConnectEventErrorResponse response = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Mqtt.Code, Is.EqualTo(4));
            Assert.That(response.Mqtt.Reason, Is.EqualTo("bad credentials"));

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Mqtt.Code, Is.EqualTo(4));
            Assert.That(converted.Mqtt.Reason, Is.EqualTo("bad credentials"));
        }
    }
}
