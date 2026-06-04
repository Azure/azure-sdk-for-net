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

            Assert.NotNull(request);
            Assert.AreEqual("user1", request.Claims["sub"].Single());
            Assert.AreEqual("token", request.Query["access_token"].Single());
            CollectionAssert.AreEqual(new[] { "protocol1", "protocol2" }, request.Subprotocols);
            Assert.AreEqual("tp1", request.ClientCertificates.Single().Thumbprint);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(request.Claims["sub"].Single(), converted.Claims["sub"].Single());
            CollectionAssert.AreEqual(request.Subprotocols, converted.Subprotocols);
            Assert.AreEqual(request.ClientCertificates.Single().Thumbprint, converted.ClientCertificates.Single().Thumbprint);
        }

        [Test]
        public void WithNullCollections_RoundTrips()
        {
            const string payload = "{\"claims\":null,\"query\":null,\"subprotocols\":null,\"clientCertificates\":null,\"headers\":null}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.NotNull(request);
            Assert.IsNull(request.Claims);
            Assert.IsNull(request.Query);
            Assert.IsNull(request.Subprotocols);
            Assert.IsNull(request.ClientCertificates);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.IsNull(converted.Claims);
            Assert.IsNull(converted.Query);
        }

        [Test]
        public void MultipleClaims_PreservesOrder()
        {
            const string payload = "{\"claims\":{\"sub\":[\"user1\"],\"role\":[\"admin\",\"reader\"]},\"query\":{},\"subprotocols\":[],\"clientCertificates\":[],\"headers\":{}}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.NotNull(request);
            CollectionAssert.AreEqual(new[] { "admin", "reader" }, request.Claims["role"]);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            CollectionAssert.AreEqual(new[] { "admin", "reader" }, converted.Claims["role"]);
        }

        [Test]
        public void MultipleClientCertificates_RoundTrips()
        {
            const string payload = "{\"claims\":{},\"query\":{},\"subprotocols\":[],\"clientCertificates\":[{\"thumbprint\":\"t1\",\"content\":\"c1\"},{\"thumbprint\":\"t2\"}],\"headers\":{}}";

            ConnectEventRequest request = JsonSerializer.Deserialize<ConnectEventRequest>(payload, JsonSerializationOptions);

            Assert.NotNull(request);
            Assert.AreEqual(2, request.ClientCertificates.Count);
            Assert.AreEqual("t1", request.ClientCertificates[0].Thumbprint);
            Assert.AreEqual("c1", request.ClientCertificates[0].Content);
            Assert.AreEqual("t2", request.ClientCertificates[1].Thumbprint);
            Assert.IsNull(request.ClientCertificates[1].Content);

            string serialized = JsonSerializer.Serialize(request, JsonSerializationOptions);
            ConnectEventRequest converted = JsonSerializer.Deserialize<ConnectEventRequest>(serialized, JsonSerializationOptions);

            Assert.NotNull(converted);
            Assert.AreEqual(2, converted.ClientCertificates.Count);
            Assert.AreEqual("t1", converted.ClientCertificates[0].Thumbprint);
            Assert.AreEqual("c1", converted.ClientCertificates[0].Content);
            Assert.AreEqual("t2", converted.ClientCertificates[1].Thumbprint);
            Assert.IsNull(converted.ClientCertificates[1].Content);
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

            Assert.AreEqual(Convert.ToBase64String(new byte[] { 1, 2, 3 }), state);
        }
    }
}
