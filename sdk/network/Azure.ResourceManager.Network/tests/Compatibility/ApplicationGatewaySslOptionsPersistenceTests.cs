// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using static Azure.ResourceManager.Network.Tests.CompatibilityTestHelpers;

#pragma warning disable CS0618 // Verify persistence of the released compatibility model.

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class ApplicationGatewaySslOptionsPersistenceTests
    {
        private const string PolicyId = "/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/future-policy";
        private const string Payload = """
            {"id":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups//providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default",
             "name":"default","type":"Microsoft.Network/applicationGatewayAvailableSslOptions","location":"westus",
             "tags":{"owner":"network","empty":null},"futureEnvelope":{"items":[1,null,true]},
             "properties":{"predefinedPolicies":[{"id":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups//providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/future-policy","futurePolicy":true}],
             "defaultPolicy":"future-policy","availableCipherSuites":["future-cipher"],"availableProtocols":["future-protocol"],"futureNested":true}}
            """;

        [TestCase("J")]
        [TestCase("W")]
        public void PersistenceRetainsSslValuesAndReleasedFiltering(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(BinaryData.FromString(Payload), options, AzureResourceManagerNetworkContext.Default);
            AssertValues(model);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
            JsonElement root = document.RootElement;
            Assert.That(root.GetProperty("id").GetString(), Does.Not.Contain("resourceGroups//"));
            Assert.That(root.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(root.GetProperty("tags").GetProperty("empty").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(root.TryGetProperty("name", out _), Is.EqualTo(format == "J"));
            Assert.That(root.TryGetProperty("type", out _), Is.EqualTo(format == "J"));
            Assert.That(root.TryGetProperty("futureEnvelope", out _), Is.EqualTo(format == "J"));
            JsonElement properties = root.GetProperty("properties");
            Assert.That(properties.GetProperty("predefinedPolicies")[0].GetProperty("id").GetString(), Is.EqualTo(PolicyId));
            Assert.That(properties.GetProperty("predefinedPolicies")[0].TryGetProperty("futurePolicy", out _), Is.False);
            Assert.That(properties.TryGetProperty("futureNested", out _), Is.False);
            Assert.That(properties.GetProperty("defaultPolicy").GetString(), Is.EqualTo("future-policy"));
            Assert.That(properties.GetProperty("availableCipherSuites")[0].GetString(), Is.EqualTo("future-cipher"));
            Assert.That(properties.GetProperty("availableProtocols")[0].GetString(), Is.EqualTo("future-protocol"));
            AssertValues(ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(BinaryData.FromString(root.GetRawText()), options, AzureResourceManagerNetworkContext.Default));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void JsonInterfacesRetainSslValues(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ReadJson<ApplicationGatewayAvailableSslOptionsInfo>(Payload, options);
            AssertValues(model);
            using JsonDocument document = JsonDocument.Parse(WriteJson<ApplicationGatewayAvailableSslOptionsInfo>(model, options));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("availableProtocols")[0].GetString(), Is.EqualTo("future-protocol"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void MissingNullAndEmptyCollectionsRetainReleasedDistinction(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            foreach (string value in new[] { null, "null", "[]" })
            {
                string payload = value is null ? "{}" : "{\"properties\":{\"predefinedPolicies\":" + value + ",\"availableCipherSuites\":" + value + ",\"availableProtocols\":" + value + ",\"defaultPolicy\":null}}";
                var model = ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(BinaryData.FromString(payload), options, AzureResourceManagerNetworkContext.Default);
                Assert.That(model.PredefinedPolicies, Is.Empty);
                Assert.That(model.AvailableCipherSuites, Is.Empty);
                Assert.That(model.AvailableProtocols, Is.Empty);
                Assert.That(model.DefaultPolicy, Is.Null);
                using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
                JsonElement properties = document.RootElement.GetProperty("properties");
                foreach (string property in new[] { "predefinedPolicies", "availableCipherSuites", "availableProtocols" })
                {
                    Assert.That(properties.TryGetProperty(property, out JsonElement collection), Is.EqualTo(value == "[]"), $"{format}: {payload}: {property}");
                    if (value == "[]")
                        Assert.That(collection.GetArrayLength(), Is.Zero);
                }
            }
        }

        [Test]
        public void DefaultCollectionsAreUndefinedUntilMutated()
        {
            var model = new ApplicationGatewayAvailableSslOptionsInfo();
            using (JsonDocument empty = JsonDocument.Parse(ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default)))
            {
                Assert.That(empty.RootElement.GetProperty("properties").EnumerateObject(), Is.Empty);
            }
            model.PredefinedPolicies.Add(new WritableSubResource { Id = new ResourceIdentifier(PolicyId) });
            model.AvailableCipherSuites.Add(new ApplicationGatewaySslCipherSuite("future-cipher"));
            model.AvailableProtocols.Add(new ApplicationGatewaySslProtocol("future-protocol"));
            model.DefaultPolicy = new ApplicationGatewaySslPolicyName("future-policy");
            using JsonDocument populated = JsonDocument.Parse(ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default));
            Assert.That(populated.RootElement.GetProperty("properties").EnumerateObject().Count(), Is.EqualTo(4));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void FactoryRetainsInputsAndDefinedEmptyCollections(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var policies = new List<WritableSubResource> { new WritableSubResource { Id = new ResourceIdentifier(PolicyId) } };
            var ciphers = new List<ApplicationGatewaySslCipherSuite> { new ApplicationGatewaySslCipherSuite("future-cipher") };
            var protocols = new List<ApplicationGatewaySslProtocol> { new ApplicationGatewaySslProtocol("future-protocol") };
            var model = ArmNetworkModelFactory.ApplicationGatewayAvailableSslOptionsInfo(
                new ResourceIdentifier(PolicyId), "default", new ResourceType("Microsoft.Network/applicationGatewayAvailableSslOptions"),
                new AzureLocation("westus"), new Dictionary<string, string> { ["owner"] = "network", ["empty"] = null },
                policies, new ApplicationGatewaySslPolicyName("future-policy"), ciphers, protocols);
            policies.Clear();
            ciphers.Clear();
            protocols.Clear();
            AssertValues(model);
            using (JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default)))
            {
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("predefinedPolicies").GetArrayLength(), Is.EqualTo(1));
            }
            using JsonDocument empty = JsonDocument.Parse(ModelReaderWriter.Write(ArmNetworkModelFactory.ApplicationGatewayAvailableSslOptionsInfo(), options, AzureResourceManagerNetworkContext.Default));
            foreach (string property in new[] { "predefinedPolicies", "availableCipherSuites", "availableProtocols" })
            {
                Assert.That(empty.RootElement.GetProperty("properties").GetProperty(property).GetArrayLength(), Is.Zero);
            }
        }

        [Test]
        public void MalformedJsonIsRejected()
        {
            Assert.Catch<JsonException>(() => ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(
                BinaryData.FromString("{"), ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void NullPayloadAndNullPropertiesAreSupported(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            Assert.That(ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(BinaryData.FromString("null"), options, AzureResourceManagerNetworkContext.Default), Is.Null);
            var model = ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(BinaryData.FromString("""{"properties":null}"""), options, AzureResourceManagerNetworkContext.Default);
            Assert.That(model.PredefinedPolicies, Is.Empty);
            Assert.That(model.AvailableCipherSuites, Is.Empty);
            Assert.That(model.AvailableProtocols, Is.Empty);
        }

        [TestCase("X")]
        [TestCase("bicep")]
        public void UnsupportedFormatsAreRejected(string format)
        {
            var model = new ApplicationGatewayAvailableSslOptionsInfo();
            var options = new ModelReaderWriterOptions(format);
            Assert.Throws<FormatException>(() => ((IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>)model).Write(options));
            Assert.Throws<FormatException>(() => ((IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>)model).Create(BinaryData.FromString("{}"), options));
        }

        private static void AssertValues(ApplicationGatewayAvailableSslOptionsInfo model)
        {
            Assert.That(model.Id.ToString(), Does.Not.Contain("resourceGroups//"));
            Assert.That(model.Location.ToString(), Is.EqualTo("westus"));
            Assert.That(model.Tags["owner"], Is.EqualTo("network"));
            Assert.That(model.Tags["empty"], Is.Null);
            Assert.That(model.PredefinedPolicies, Has.Count.EqualTo(1));
            Assert.That(model.PredefinedPolicies[0].Id.ToString(), Is.EqualTo(PolicyId));
            Assert.That(model.DefaultPolicy.ToString(), Is.EqualTo("future-policy"));
            Assert.That(model.AvailableCipherSuites[0].ToString(), Is.EqualTo("future-cipher"));
            Assert.That(model.AvailableProtocols[0].ToString(), Is.EqualTo("future-protocol"));
        }
    }
}
