// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests
{
    public class ResourceDataCompatibilityTests
    {
        [TestCase(typeof(ApplicationInsightsComponentData))]
        [TestCase(typeof(ApplicationInsightsWebTestData))]
        public void RetainsGaBaseAndResourceProperties(Type modelType)
        {
            Assert.That(modelType.BaseType, Is.EqualTo(typeof(TrackedResourceData)));
            foreach (string property in new[] { nameof(ResourceData.Id), nameof(ResourceData.Name), nameof(ResourceData.ResourceType), nameof(ResourceData.SystemData) })
            {
                Assert.That(modelType.GetProperty(property).DeclaringType, Is.EqualTo(typeof(ResourceData)), property);
            }

            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Test/resources/test";
            BinaryData json = BinaryData.FromString($$$"""
                {"id":"{{{id}}}","name":"test","type":"Microsoft.Test/resources","systemData":{"createdBy":"creator"},"location":"westus","tags":{"key":"value"}}
                """);
            var model = (ResourceData)ModelReaderWriter.Read(json, modelType);

            Assert.That(model.Id.ToString(), Is.EqualTo(id));
            Assert.That(model.Name, Is.EqualTo("test"));
            Assert.That(model.ResourceType.ToString(), Is.EqualTo("Microsoft.Test/resources"));
            Assert.That(model.SystemData.CreatedBy, Is.EqualTo("creator"));

            var tracked = (TrackedResourceData)model;
            Assert.That(tracked.Location, Is.EqualTo(new Azure.Core.AzureLocation("westus")));
            Assert.That(tracked.Tags["key"], Is.EqualTo("value"));

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(document.RootElement.GetProperty("id").GetString(), Is.EqualTo(id));
            Assert.That(document.RootElement.GetProperty("name").GetString(), Is.EqualTo("test"));
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo("Microsoft.Test/resources"));
            Assert.That(document.RootElement.GetProperty("systemData").GetProperty("createdBy").GetString(), Is.EqualTo("creator"));
            Assert.That(document.RootElement.GetProperty("location").GetString(), Is.EqualTo("westus"));
            Assert.That(document.RootElement.GetProperty("tags").GetProperty("key").GetString(), Is.EqualTo("value"));
        }
    }
}
