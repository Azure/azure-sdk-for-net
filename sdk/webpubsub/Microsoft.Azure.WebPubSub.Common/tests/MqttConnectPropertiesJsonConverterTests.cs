// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class MqttConnectPropertiesJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip_BackwardCompatible()
        {
            const string payload = "{\"protocolVersion\":5,\"username\":\"username\",\"password\":\"password\",\"userProperties\":[{\"name\":\"x\",\"value\":\"y\"}]}";

            MqttConnectProperties properties = JsonSerializer.Deserialize<MqttConnectProperties>(payload, JsonSerializationOptions);

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.ProtocolVersion, Is.EqualTo(MqttProtocolVersion.V500));
            Assert.That(properties.Username, Is.EqualTo("username"));
            Assert.That(properties.Password, Is.EqualTo("password"));
            Assert.That(properties.UserProperties.Single().Name, Is.EqualTo("x"));

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttConnectProperties converted = JsonSerializer.Deserialize<MqttConnectProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.ProtocolVersion, Is.EqualTo(properties.ProtocolVersion));
            Assert.That(converted.Username, Is.EqualTo(properties.Username));
            Assert.That(converted.UserProperties.Single().Value, Is.EqualTo(properties.UserProperties.Single().Value));
        }

        [Test]
        public void NullFields_RoundTrips()
        {
            const string payload = "{\"protocolVersion\":4,\"username\":null,\"password\":null,\"userProperties\":null}";

            MqttConnectProperties properties = JsonSerializer.Deserialize<MqttConnectProperties>(payload, JsonSerializationOptions);

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.ProtocolVersion, Is.EqualTo(MqttProtocolVersion.V311));
            Assert.That(properties.Username, Is.Null);
            Assert.That(properties.Password, Is.Null);
            Assert.That(properties.UserProperties, Is.Null);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttConnectProperties converted = JsonSerializer.Deserialize<MqttConnectProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Username, Is.Null);
            Assert.That(converted.Password, Is.Null);
            Assert.That(converted.UserProperties, Is.Null);
        }

        [Test]
        public void MissingProtocolVersion_Throws()
        {
            const string payload = "{\"username\":\"user\",\"password\":\"pass\",\"userProperties\":null}";

            Assert.Throws<JsonException>(() =>
                JsonSerializer.Deserialize<MqttConnectProperties>(payload, JsonSerializationOptions));
        }

        [Test]
        public void MultipleUserProperties_RoundTrips()
        {
            const string payload = "{\"protocolVersion\":5,\"username\":\"u\",\"password\":\"p\",\"userProperties\":[{\"name\":\"a\",\"value\":\"1\"},{\"name\":\"b\",\"value\":\"2\"}]}";

            MqttConnectProperties properties = JsonSerializer.Deserialize<MqttConnectProperties>(payload, JsonSerializationOptions);

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.UserProperties.Count, Is.EqualTo(2));

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttConnectProperties converted = JsonSerializer.Deserialize<MqttConnectProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.UserProperties.Count, Is.EqualTo(2));
            Assert.That(converted.UserProperties[0].Name, Is.EqualTo("a"));
            Assert.That(converted.UserProperties[1].Value, Is.EqualTo("2"));
        }
    }
}
