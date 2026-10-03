// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ResourceReferenceSafeFlattenTests
    {
        private const string ReferenceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub";
        private static readonly ModelReaderWriterOptions WireOptions = new("W");

        [Test]
        public void ApplicationGatewayRequestRoutingRuleReference()
        {
            AssertReference<ApplicationGatewayRequestRoutingRule>(
                "entraJWTValidationConfig",
                model => model.EntraJwtValidationConfigId,
                (model, id) => model.EntraJwtValidationConfigId = id);
        }

        [Test]
        public void ExpressRouteCircuitPeeringReference()
        {
            AssertReference<ExpressRouteCircuitPeeringData>(
                "expressRouteConnection",
                model => model.ExpressRouteConnectionId,
                (model, id) => model.ExpressRouteConnectionId = id,
                isReadOnly: true);
        }

        [Test]
        public void ExpressRouteCrossConnectionReference()
        {
            AssertReference<ExpressRouteCrossConnectionData>(
                "expressRouteCircuit",
                model => model.ExpressRouteCircuitId,
                (model, id) => model.ExpressRouteCircuitId = id);
        }

        [Test]
        public void ExpressRouteConnectionReference()
        {
            AssertReference<ExpressRouteConnectionData>(
                "expressRouteCircuitPeering",
                model => model.ExpressRouteCircuitPeeringId,
                (model, id) => model.ExpressRouteCircuitPeeringId = id);
        }

        [Test]
        public void ExpressRouteGatewayReference()
        {
            AssertReference<ExpressRouteGatewayData>(
                "virtualHub",
                model => model.VirtualHubId,
                (model, id) => model.VirtualHubId = id);
        }

        [Test]
        public void LoadBalancerBackendAddressReference()
        {
            AssertReference<LoadBalancerBackendAddress>(
                "loadBalancerFrontendIPConfiguration",
                model => model.LoadBalancerFrontendIPConfigurationId,
                (model, id) => model.LoadBalancerFrontendIPConfigurationId = id);
        }

        private static void AssertReference<T>(
            string wireName,
            Func<T, ResourceIdentifier> getId,
            Action<T, ResourceIdentifier> setId,
            bool isReadOnly = false)
            where T : IJsonModel<T>, new()
        {
            var model = new T();
            Assert.IsNull(getId(model));
            using (var empty = Write(model))
            {
                Assert.IsFalse(empty.RootElement.TryGetProperty("properties", out var properties)
                    && properties.TryGetProperty(wireName, out _));
            }

            setId(model, null);
            Assert.IsNull(getId(model));
            AssertClearedReference(model, wireName);

            setId(model, new ResourceIdentifier(ReferenceId));
            Assert.AreEqual(ReferenceId, getId(model).ToString());
            using (var written = Write(model))
            {
                var reference = written.RootElement.GetProperty("properties").GetProperty(wireName);
                Assert.AreEqual(JsonValueKind.Object, reference.ValueKind);
                if (isReadOnly)
                {
                    Assert.IsFalse(reference.TryGetProperty("id", out _));
                }
                else
                {
                    Assert.AreEqual(ReferenceId, reference.GetProperty("id").GetString());
                    Assert.AreEqual(ReferenceId, getId(Read<T>(written.RootElement.GetRawText())).ToString());
                }
            }

            using (var persisted = Write(model, ModelReaderWriterOptions.Json))
            {
                Assert.AreEqual(ReferenceId, persisted.RootElement.GetProperty("properties").GetProperty(wireName).GetProperty("id").GetString());
                Assert.AreEqual(ReferenceId, getId(Read<T>(persisted.RootElement.GetRawText())).ToString());
            }

            foreach (string properties in new[]
            {
                null,
                "null",
                "{}",
                $"{{\"{wireName}\":null}}",
                $"{{\"{wireName}\":{{}}}}",
                $"{{\"{wireName}\":{{\"id\":null}}}}",
            })
            {
                var json = properties is null
                    ? "{\"name\":\"preserved\"}"
                    : $"{{\"name\":\"preserved\",\"properties\":{properties}}}";
                var read = Read<T>(json);
                Assert.IsNull(getId(read), properties);
                setId(read, new ResourceIdentifier(ReferenceId));
                using var written = Write(read, ModelReaderWriterOptions.Json);
                Assert.AreEqual(ReferenceId, written.RootElement.GetProperty("properties").GetProperty(wireName).GetProperty("id").GetString());
                Assert.AreEqual("preserved", written.RootElement.GetProperty("name").GetString());
            }

            setId(model, null);
            Assert.IsNull(getId(model));
            AssertClearedReference(model, wireName);
        }

        private static void AssertClearedReference<T>(T model, string wireName)
            where T : IJsonModel<T>
        {
            using (var cleared = Write(model))
            {
                var reference = cleared.RootElement.GetProperty("properties").GetProperty(wireName);
                Assert.AreEqual(JsonValueKind.Object, reference.ValueKind);
                Assert.IsEmpty(reference.EnumerateObject());
            }
        }

        private static T Read<T>(string json) where T : IJsonModel<T>, new()
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            return ((IJsonModel<T>)new T()).Create(ref reader, WireOptions);
        }

        private static JsonDocument Write<T>(T model, ModelReaderWriterOptions options = null) where T : IJsonModel<T>
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            model.Write(writer, options ?? WireOptions);
            writer.Flush();
            return JsonDocument.Parse(stream.ToArray());
        }
    }
}
