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

            Assert.NotNull(response);
            Assert.AreEqual(135, response.Mqtt.Code);
            Assert.AreEqual("error message", response.Mqtt.Reason);
            Assert.AreEqual("a", response.Mqtt.UserProperties.Single().Name);
            Assert.AreEqual("b", response.Mqtt.UserProperties.Single().Value);

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(response.Mqtt.Code, converted.Mqtt.Code);
            Assert.AreEqual(response.Mqtt.Reason, converted.Mqtt.Reason);
            Assert.AreEqual(response.Mqtt.UserProperties.Single().Name, converted.Mqtt.UserProperties.Single().Name);
        }

        [Test]
        public void NullUserProperties_RoundTrips()
        {
            const string payload = "{\"mqtt\":{\"code\":135,\"reason\":null,\"userProperties\":null}}";

            MqttConnectEventErrorResponse response = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions);

            Assert.NotNull(response);
            Assert.AreEqual(135, response.Mqtt.Code);
            Assert.IsNull(response.Mqtt.Reason);
            Assert.IsNull(response.Mqtt.UserProperties);

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(135, converted.Mqtt.Code);
            Assert.IsNull(converted.Mqtt.Reason);
            Assert.IsNull(converted.Mqtt.UserProperties);
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

            Assert.NotNull(response);
            Assert.AreEqual(3, response.Mqtt.UserProperties.Count);
            Assert.AreEqual("a", response.Mqtt.UserProperties[0].Name);
            Assert.AreEqual("b", response.Mqtt.UserProperties[1].Name);
            Assert.AreEqual("c", response.Mqtt.UserProperties[2].Name);

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(3, converted.Mqtt.UserProperties.Count);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(response.Mqtt.UserProperties[i].Name, converted.Mqtt.UserProperties[i].Name);
                Assert.AreEqual(response.Mqtt.UserProperties[i].Value, converted.Mqtt.UserProperties[i].Value);
            }
        }

        [Test]
        public void V311Code_RoundTrips()
        {
            // Code < 0x80 indicates MQTT 3.1.1
            const string payload = "{\"mqtt\":{\"code\":4,\"reason\":\"bad credentials\",\"userProperties\":null}}";

            MqttConnectEventErrorResponse response = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(payload, JsonSerializationOptions);

            Assert.NotNull(response);
            Assert.AreEqual(4, response.Mqtt.Code);
            Assert.AreEqual("bad credentials", response.Mqtt.Reason);

            string serialized = JsonSerializer.Serialize(response, JsonSerializationOptions);
            MqttConnectEventErrorResponse converted = JsonSerializer.Deserialize<MqttConnectEventErrorResponse>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(4, converted.Mqtt.Code);
            Assert.AreEqual("bad credentials", converted.Mqtt.Reason);
        }
    }
}
