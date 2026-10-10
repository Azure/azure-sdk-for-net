// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class WebPubSubClientCertificateJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip()
        {
            const string payload = "{\"thumbprint\":\"abc123\",\"content\":\"certContent\"}";

            WebPubSubClientCertificate cert = JsonSerializer.Deserialize<WebPubSubClientCertificate>(payload, JsonSerializationOptions);

            Assert.That(cert, Is.Not.Null);
            Assert.That(cert.Thumbprint, Is.EqualTo("abc123"));
            Assert.That(cert.Content, Is.EqualTo("certContent"));

            string serialized = JsonSerializer.Serialize(cert, JsonSerializationOptions);
            WebPubSubClientCertificate converted = JsonSerializer.Deserialize<WebPubSubClientCertificate>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Thumbprint, Is.EqualTo("abc123"));
            Assert.That(converted.Content, Is.EqualTo("certContent"));
        }

        [Test]
        public void NullContent_RoundTrips()
        {
            const string payload = "{\"thumbprint\":\"abc123\"}";

            WebPubSubClientCertificate cert = JsonSerializer.Deserialize<WebPubSubClientCertificate>(payload, JsonSerializationOptions);

            Assert.That(cert, Is.Not.Null);
            Assert.That(cert.Thumbprint, Is.EqualTo("abc123"));
            Assert.That(cert.Content, Is.Null);

            string serialized = JsonSerializer.Serialize(cert, JsonSerializationOptions);
            WebPubSubClientCertificate converted = JsonSerializer.Deserialize<WebPubSubClientCertificate>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Thumbprint, Is.EqualTo("abc123"));
            Assert.That(converted.Content, Is.Null);
        }
    }
}
