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

            Assert.NotNull(properties);
            Assert.AreEqual(MqttProtocolVersion.V500, properties.ProtocolVersion);
            Assert.AreEqual("username", properties.Username);
            Assert.AreEqual("password", properties.Password);
            Assert.AreEqual("x", properties.UserProperties.Single().Name);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttConnectProperties converted = JsonSerializer.Deserialize<MqttConnectProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(properties.ProtocolVersion, converted.ProtocolVersion);
            Assert.AreEqual(properties.Username, converted.Username);
            Assert.AreEqual(properties.UserProperties.Single().Value, converted.UserProperties.Single().Value);
        }

        [Test]
        public void NullFields_RoundTrips()
        {
            const string payload = "{\"protocolVersion\":4,\"username\":null,\"password\":null,\"userProperties\":null}";

            MqttConnectProperties properties = JsonSerializer.Deserialize<MqttConnectProperties>(payload, JsonSerializationOptions);

            Assert.NotNull(properties);
            Assert.AreEqual(MqttProtocolVersion.V311, properties.ProtocolVersion);
            Assert.IsNull(properties.Username);
            Assert.IsNull(properties.Password);
            Assert.IsNull(properties.UserProperties);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttConnectProperties converted = JsonSerializer.Deserialize<MqttConnectProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.IsNull(converted.Username);
            Assert.IsNull(converted.Password);
            Assert.IsNull(converted.UserProperties);
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

            Assert.NotNull(properties);
            Assert.AreEqual(2, properties.UserProperties.Count);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttConnectProperties converted = JsonSerializer.Deserialize<MqttConnectProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(2, converted.UserProperties.Count);
            Assert.AreEqual("a", converted.UserProperties[0].Name);
            Assert.AreEqual("2", converted.UserProperties[1].Value);
        }
    }
}
