// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class JoinedGroupEventRequestJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip()
        {
            const string payload = "{\"group\":\"myGroup\"}";

            JoinedGroupEventRequest request = JsonSerializer.Deserialize<JoinedGroupEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Group, Is.EqualTo("myGroup"));

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            JoinedGroupEventRequest converted = JsonSerializer.Deserialize<JoinedGroupEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Group, Is.EqualTo("myGroup"));
        }
    }
}
