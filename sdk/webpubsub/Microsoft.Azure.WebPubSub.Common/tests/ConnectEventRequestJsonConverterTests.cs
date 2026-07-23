// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.Common.Tests
{
    [TestFixture]
    public class ConnectEventRequestJsonConverterTests
    {
        private static readonly JsonSerializerOptions JsonSerializationOptions = new(WebPubSubCommonJsonSerializerContext.Default.Options) { TypeInfoResolver = null };

        [Test]
        public void RoundTrip_BackwardCompatible()
        {
            const string payload = "{\"claims\":{\"sub\":[\"user1\"],\"role\":[\"send\",\"join\"]},\"query\":{\"access_token\":[\"token\"]},\"subprotocols\":[\"protocol1\",\"protocol2\"],\"clientCertificates\":[{\"thumbprint\":\"tp1\",\"content\":\"c1\"}],\"headers\":{\"request-id\":[\"aaa\"]}}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Claims["sub"].Single(), Is.EqualTo("user1"));
            Assert.That(request.Query["access_token"].Single(), Is.EqualTo("token"));
            Assert.That(request.Subprotocols, Is.EqualTo(new[] { "protocol1", "protocol2" }));
            Assert.That(request.ClientCertificates.Single().Thumbprint, Is.EqualTo("tp1"));

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Claims["sub"].Single(), Is.EqualTo(request.Claims["sub"].Single()));
            Assert.That(converted.Subprotocols, Is.EqualTo(request.Subprotocols));
            Assert.That(converted.ClientCertificates.Single().Thumbprint, Is.EqualTo(request.ClientCertificates.Single().Thumbprint));
        }

        [Test]
        public void WithNullCollections_RoundTrips()
        {
            const string payload = "{\"claims\":null,\"query\":null,\"subprotocols\":null,\"clientCertificates\":null,\"headers\":null}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Claims, Is.Null);
            Assert.That(request.Query, Is.Null);
            Assert.That(request.Subprotocols, Is.Null);
            Assert.That(request.ClientCertificates, Is.Null);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Claims, Is.Null);
            Assert.That(converted.Query, Is.Null);
        }

        [Test]
        public void MultipleClaims_PreservesOrder()
        {
            const string payload = "{\"claims\":{\"sub\":[\"user1\"],\"role\":[\"admin\",\"reader\"]},\"query\":{},\"subprotocols\":[],\"clientCertificates\":[],\"headers\":{}}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.Claims["role"], Is.EqualTo(new[] { "admin", "reader" }));

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.Claims["role"], Is.EqualTo(new[] { "admin", "reader" }));
        }

        [Test]
        public void MultipleClientCertificates_RoundTrips()
        {
            const string payload = "{\"claims\":{},\"query\":{},\"subprotocols\":[],\"clientCertificates\":[{\"thumbprint\":\"t1\",\"content\":\"c1\"},{\"thumbprint\":\"t2\"}],\"headers\":{}}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.That(request, Is.Not.Null);
            Assert.That(request.ClientCertificates.Count, Is.EqualTo(2));
            Assert.That(request.ClientCertificates[0].Thumbprint, Is.EqualTo("t1"));
            Assert.That(request.ClientCertificates[0].Content, Is.EqualTo("c1"));
            Assert.That(request.ClientCertificates[1].Thumbprint, Is.EqualTo("t2"));
            Assert.That(request.ClientCertificates[1].Content, Is.Null);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.That(converted, Is.Not.Null);
            Assert.That(converted.ClientCertificates.Count, Is.EqualTo(2));
            Assert.That(converted.ClientCertificates[0].Thumbprint, Is.EqualTo("t1"));
            Assert.That(converted.ClientCertificates[0].Content, Is.EqualTo("c1"));
            Assert.That(converted.ClientCertificates[1].Thumbprint, Is.EqualTo("t2"));
            Assert.That(converted.ClientCertificates[1].Content, Is.Null);
        }

        [Test]
        public void WithConnectionContext_UsesBase64EncodedStates()
        {
            var states = new Dictionary<string, BinaryData>
            {
                { "counter", BinaryData.FromBytes(new byte[] { 1, 2, 3 }) }
            };

            var context = new WebPubSubConnectionContext(
                WebPubSubEventType.System,
                "connect",
                "hub1",
                "conn1",
                "user1",
                "sig",
                "origin",
                states,
                new Dictionary<string, string[]>
                {
                    { "h1", new[] { "v1" } }
                });

            var request = new ConnectEventRequest(
                context,
                new Dictionary<string, string[]> { { "sub", new[] { "user1" } } },
                new Dictionary<string, string[]> { { "q1", new[] { "v1" } } },
                new[] { "protocol1" },
                Array.Empty<WebPubSubClientCertificate>(),
                new Dictionary<string, string[]> { { "request-id", new[] { "id1" } } });

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            using JsonDocument document = JsonDocument.Parse(serialized);
            JsonElement connectionContext = document.RootElement.GetProperty("connectionContext");
            string state = connectionContext.GetProperty("states").GetProperty("counter").GetString();

            Assert.That(state, Is.EqualTo(Convert.ToBase64String(new byte[] { 1, 2, 3 })));
        }
    }
}
