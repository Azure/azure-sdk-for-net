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

            Assert.NotNull(properties);
            Assert.AreEqual((MqttDisconnectReasonCode)128, properties.Code);
            Assert.AreEqual(1, properties.UserProperties.Count);
            Assert.AreEqual("key", properties.UserProperties[0].Name);
            Assert.AreEqual("val", properties.UserProperties[0].Value);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectPacketProperties converted = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(properties.Code, converted.Code);
            Assert.AreEqual(properties.UserProperties[0].Name, converted.UserProperties[0].Name);
        }

        [Test]
        public void NoUserProperties_RoundTrips()
        {
            const string payload = "{\"code\":0}";

            MqttDisconnectPacketProperties properties = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(payload, JsonSerializationOptions);

            Assert.NotNull(properties);
            Assert.AreEqual((MqttDisconnectReasonCode)0, properties.Code);
            Assert.IsNull(properties.UserProperties);

            string serialized = JsonSerializer.Serialize(properties, JsonSerializationOptions);
            MqttDisconnectPacketProperties converted = JsonSerializer.Deserialize<MqttDisconnectPacketProperties>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual((MqttDisconnectReasonCode)0, converted.Code);
            Assert.IsNull(converted.UserProperties);
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
