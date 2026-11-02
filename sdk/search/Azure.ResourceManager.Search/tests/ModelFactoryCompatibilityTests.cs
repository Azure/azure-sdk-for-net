// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Search.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Search.Tests
{
    public class ModelFactoryCompatibilityTests
    {
        [TestCase("searchServices")]
        [TestCase("customResourceType")]
        [TestCase("")]
        public void LegacyNameAvailabilityFactoryPreservesArguments(string value)
        {
            var resourceType = new SearchServiceResourceType(value);
            var content = ArmSearchModelFactory.SearchServiceNameAvailabilityContent("service-name", resourceType);

            Assert.That(content.Name, Is.EqualTo("service-name"));
            Assert.That(content.ResourceType, Is.EqualTo(resourceType));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(content));
            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo(value));
        }

        [Test]
        public void LegacyNameAvailabilityFactoryPreservesDefaultResourceType()
        {
            var content = ArmSearchModelFactory.SearchServiceNameAvailabilityContent("service-name", default(SearchServiceResourceType));

            Assert.That(content.Name, Is.EqualTo("service-name"));
            Assert.That(content.ResourceType, Is.EqualTo(default(SearchServiceResourceType)));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(content));
            Assert.That(json.RootElement.GetProperty("type").ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        [Test]
        public void CurrentNameAvailabilityFactoryRetainsDefaultResourceType()
        {
            var content = ArmSearchModelFactory.SearchServiceNameAvailabilityContent(name: "service-name");

            Assert.That(content.Name, Is.EqualTo("service-name"));
            Assert.That(content.ResourceType, Is.EqualTo(SearchServiceResourceType.SearchServices));
        }
    }
}
