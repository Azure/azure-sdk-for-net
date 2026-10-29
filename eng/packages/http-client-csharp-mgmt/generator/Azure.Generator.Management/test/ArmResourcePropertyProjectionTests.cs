// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Mgmt.Tests
{
    public class ArmResourcePropertyProjectionTests
    {
        [TestCase("Id", typeof(ResourceIdentifier), "id", true)]
        [TestCase("Name", typeof(string), "name", true)]
        [TestCase("ResourceType", typeof(ResourceType), "type", true)]
        [TestCase("SystemData", typeof(SystemData), "systemData", true)]
        [TestCase("Location", typeof(AzureLocation), "location", false)]
        [TestCase("Tags", typeof(IDictionary<string, string>), "tags", false)]
        public void FrameworkWireMetadataMatchesKnownShapes(string name, Type type, string wireName, bool readOnly)
        {
            foreach (var nullable in new[] { false, true })
            {
                var property = CreateProperty(name, new CSharpType(type).WithNullable(nullable));
                Assert.That(ArmResourcePropertyProjection.TryGetFrameworkWireMetadata(property, out var wireInfo), Is.True);
                Assert.Multiple(() =>
                {
                    Assert.That(wireInfo!.SerializedName, Is.EqualTo(wireName));
                    Assert.That(wireInfo.SerializationFormat, Is.EqualTo(property.SerializationFormat));
                    Assert.That(wireInfo.IsReadOnly, Is.EqualTo(readOnly));
                    Assert.That(wireInfo.IsRequired, Is.False);
                    Assert.That(wireInfo.IsNullable, Is.False);
                    Assert.That(wireInfo.IsDiscriminator, Is.False);
                    Assert.That(wireInfo.IsHttpMetadata, Is.False);
                    Assert.That(wireInfo.IsApiVersion, Is.False);
                    Assert.That(property.WireInfo, Is.Null, "The shared property must not be mutated");
                });
            }
        }

        [TestCase("Id", typeof(string))]
        [TestCase("Name", typeof(ResourceIdentifier))]
        [TestCase("ResourceType", typeof(string))]
        [TestCase("SystemData", typeof(string))]
        [TestCase("Location", typeof(string))]
        [TestCase("Tags", typeof(IDictionary<string, int>))]
        [TestCase("Tags", typeof(Dictionary<string, string>))]
        [TestCase("id", typeof(ResourceIdentifier))]
        [TestCase("Unknown", typeof(string))]
        public void FrameworkWireMetadataRejectsUnknownOrMismatchedShapes(string name, Type type)
        {
            var property = CreateProperty(name, new CSharpType(type));
            Assert.That(ArmResourcePropertyProjection.TryGetFrameworkWireMetadata(property, out var wireInfo), Is.False);
            Assert.That(wireInfo, Is.Null);
        }

        [TestCase("id", typeof(ResourceIdentifier), null)]
        [TestCase("name", typeof(string), null)]
        [TestCase("type", typeof(ResourceType), "ResourceType")]
        [TestCase("type", typeof(string), null)]
        [TestCase("type", typeof(int), null)]
        [TestCase("systemData", typeof(SystemData), null)]
        [TestCase("location", typeof(AzureLocation), null)]
        [TestCase("tags", typeof(IDictionary<string, string>), null)]
        [TestCase("Type", typeof(ResourceType), null)]
        public void OrdinaryNameProjectionRemainsLimitedToSemanticAlias(string wireName, Type type, string? expectedName)
        {
            var property = InputFactory.Property("renamed", InputPrimitiveType.String, serializedName: wireName);
            Assert.That(ArmResourcePropertyProjection.TryGetName(property, new CSharpType(type), out var name),
                Is.EqualTo(expectedName is not null));
            Assert.That(name, Is.EqualTo(expectedName));
            Assert.That(ArmResourcePropertyProjection.TryGetAliasedName(property, out var alias), Is.EqualTo(wireName == "type"));
            Assert.That(alias, Is.EqualTo(wireName == "type" ? "ResourceType" : null));
        }

        [TestCase("id", "Id", typeof(ResourceIdentifier))]
        [TestCase("type", "ResourceType", typeof(ResourceType))]
        [TestCase("location", "Location", typeof(AzureLocation))]
        [TestCase("name", null, null)]
        [TestCase("systemData", null, null)]
        [TestCase("tags", null, null)]
        [TestCase("unknown", null, null)]
        public void HistoricalStringProjectionRemainsLimitedToEnvelopeScalars(string wireName, string? expectedName, Type? expectedType)
        {
            var property = InputFactory.Property("renamed", InputPrimitiveType.String, serializedName: wireName);
            Assert.That(ArmResourcePropertyProjection.TryGetHistoricalShape(property, new CSharpType(typeof(string)), out var name, out var type),
                Is.EqualTo(expectedName is not null));
            Assert.That(name, Is.EqualTo(expectedName));
            Assert.That(type, Is.EqualTo(expectedType is null ? null : new CSharpType(expectedType)));
        }

        private static PropertyProvider CreateProperty(string name, CSharpType type)
        {
            var model = InputFactory.Model("Widget");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            return new PropertyProvider(null, MethodSignatureModifiers.Public, type, name,
                new AutoPropertyBody(false), plugin.Object.TypeFactory.CreateModel(model)!);
        }
    }
}
