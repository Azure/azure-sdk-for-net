// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class DisconnectedEventRequestJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip_BackwardCompatible()
        {
            const string payload = "{\"reason\":\"invalid\"}";

            DisconnectedEventRequest request = JsonSerializer.Deserialize<DisconnectedEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Reason, Is.EqualTo("invalid"));

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            DisconnectedEventRequest converted = JsonSerializer.Deserialize<DisconnectedEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Reason, Is.EqualTo("invalid"));
        }

        [Test]
        public void WithConnectionContext_RoundTrips()
        {
            var context = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                "disconnected",
                "hub1",
                "conn1",
                "user1");

            var request = new DisconnectedEventRequest(context, "Connection closed");

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);

            Assert.That(serialized, Does.Contain("\"reason\":\"Connection closed\""));
            Assert.That(serialized, Does.Contain("\"connectionContext\""));
        }
    }
}
