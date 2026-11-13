// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Purview.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Purview.Tests
{
    public class ModelFactoryCompatibilityTests
    {
        [TestCase("https://guardian.example")]
        [TestCase("")]
        [TestCase(null)]
        public void LegacyEndpointFactoryPreservesArguments(string guardian)
        {
            var endpoint = ArmPurviewModelFactory.PurviewAccountEndpoint("catalog", guardian, "scan");

            Assert.That(endpoint.Catalog, Is.EqualTo("catalog"));
            Assert.That(endpoint.Guardian, Is.EqualTo(guardian));
            Assert.That(endpoint.Scan, Is.EqualTo("scan"));

            // Guardian is mock-only compatibility state, not part of the current wire model.
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(endpoint));
            Assert.That(json.RootElement.GetProperty("catalog").GetString(), Is.EqualTo("catalog"));
            Assert.That(json.RootElement.GetProperty("scan").GetString(), Is.EqualTo("scan"));
            Assert.That(json.RootElement.TryGetProperty("guardian", out _), Is.False);
        }

        [Test]
        public void CurrentEndpointFactoryDoesNotPopulateGuardian()
        {
            var endpoint = ArmPurviewModelFactory.PurviewAccountEndpoint(catalog: "catalog", scan: "scan");

            Assert.That(endpoint.Catalog, Is.EqualTo("catalog"));
            Assert.That(endpoint.Guardian, Is.Null);
            Assert.That(endpoint.Scan, Is.EqualTo("scan"));
        }
    }
}
