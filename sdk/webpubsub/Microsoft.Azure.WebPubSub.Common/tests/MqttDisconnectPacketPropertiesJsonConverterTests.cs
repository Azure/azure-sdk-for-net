// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class MqttDisconnectPacketPropertiesJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip()
        {
            const string payload = "{\"code\":128,\"userProperties\":[{\"name\":\"key\",\"value\":\"val\"}]}";

            MqttDisconnectPacketProperties properties = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(payload, JsonSerializationOptions);

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.Code, Is.EqualTo((MqttDisconnectReasonCode)128));
            Assert.That(properties.UserProperties.Count, Is.EqualTo(1));
            Assert.That(properties.UserProperties[0].Name, Is.EqualTo("key"));
            Assert.That(properties.UserProperties[0].Value, Is.EqualTo("val"));

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectPacketProperties converted = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Code, Is.EqualTo(properties.Code));
            Assert.That(converted.UserProperties[0].Name, Is.EqualTo(properties.UserProperties[0].Name));
        }

        [Test]
        public void NoUserProperties_RoundTrips()
        {
            const string payload = "{\"code\":0}";

            MqttDisconnectPacketProperties properties = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(payload, JsonSerializationOptions);

            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.Code, Is.EqualTo((MqttDisconnectReasonCode)0));
            Assert.That(properties.UserProperties, Is.Null);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectPacketProperties converted = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Code, Is.EqualTo((MqttDisconnectReasonCode)0));
            Assert.That(converted.UserProperties, Is.Null);
        }

        [Test]
        public void MissingCode_Throws()
        {
            const string payload = "{\"userProperties\":[]}";

            Assert.Throws<JsonException>(() =>
                JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(payload, JsonSerializationOptions));
        }
    }
}
