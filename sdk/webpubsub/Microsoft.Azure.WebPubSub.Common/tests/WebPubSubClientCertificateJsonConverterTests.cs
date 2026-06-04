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

            Assert.NotNull(cert);
            Assert.AreEqual("abc123", cert.Thumbprint);
            Assert.AreEqual("certContent", cert.Content);

            string serialized = JsonSerializer.Serialize(cert, JsonSerializationOptions);
            WebPubSubClientCertificate converted = JsonSerializer.Deserialize<WebPubSubClientCertificate>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual("abc123", converted.Thumbprint);
            Assert.AreEqual("certContent", converted.Content);
        }

        [Test]
        public void NullContent_RoundTrips()
        {
            const string payload = "{\"thumbprint\":\"abc123\"}";

            WebPubSubClientCertificate cert = JsonSerializer.Deserialize<WebPubSubClientCertificate>(payload, JsonSerializationOptions);

            Assert.NotNull(cert);
            Assert.AreEqual("abc123", cert.Thumbprint);
            Assert.IsNull(cert.Content);

            string serialized = JsonSerializer.Serialize(cert, JsonSerializationOptions);
            WebPubSubClientCertificate converted = JsonSerializer.Deserialize<WebPubSubClientCertificate>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual("abc123", converted.Thumbprint);
            Assert.IsNull(converted.Content);
        }
    }
}
