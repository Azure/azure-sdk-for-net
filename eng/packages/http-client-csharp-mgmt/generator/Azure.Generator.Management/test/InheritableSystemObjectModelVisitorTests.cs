// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    public class InheritableSystemObjectModelVisitorTests
    {
        [TestCase(typeof(ResourceData))]
        [TestCase(typeof(TrackedResourceData))]
        public void TryGetInheritableSystemTypeByName_MatchesKnownFrameworkType(System.Type expectedType)
        {
            var csharpType = new CSharpType(expectedType);
            Assert.IsTrue(KnownManagementTypes.TryGetInheritableSystemTypeByName(csharpType, out var clrType));
            Assert.AreEqual(expectedType, clrType);
        }

        [Test]
        public void TryGetInheritableSystemTypeByName_DoesNotMatchUnknownType()
        {
            // Use a framework type that is NOT a known inheritable system type
            var csharpType = new CSharpType(typeof(string));
            Assert.IsFalse(KnownManagementTypes.TryGetInheritableSystemTypeByName(csharpType, out _));
        }

        [Test]
        public void EnsureFrameworkTypeRegistered_RegistersBothTypes()
        {
            // Set up the mock plugin to get access to CSharpTypeMap
            var proxyResourceModel = InputFactory.Model(
                "ProxyResource",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);

            // Set crossLanguageDefinitionId via reflection since it's not exposed in the factory
            var crossLangProp = typeof(InputModelType).GetProperty(nameof(InputModelType.CrossLanguageDefinitionId));
            crossLangProp!.GetSetMethod(true)!.Invoke(proxyResourceModel, ["Azure.ResourceManager.CommonTypes.ProxyResource"]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [proxyResourceModel]);

            // Force creation of the model which triggers the visitor
            var modelProvider = plugin.Object.TypeFactory.CreateModel(proxyResourceModel);
            Assert.IsNotNull(modelProvider);
            Assert.IsInstanceOf<InheritableSystemObjectModelProvider>(modelProvider);

            // The CSharpTypeMap should now have both framework and non-framework entries
            var typeMap = plugin.Object.TypeFactory.CSharpTypeMap;

            // Check that a framework CSharpType for ResourceData can be found
            var frameworkResourceData = new CSharpType(typeof(ResourceData));
            Assert.IsTrue(typeMap.ContainsKey(frameworkResourceData),
                "CSharpTypeMap should contain a framework CSharpType entry for ResourceData after EnsureFrameworkTypeRegistered");
        }

        [Test]
        public void ModelWithInheritableSystemBase_PropertiesAreFiltered()
        {
            // Create ProxyResource (maps to ResourceData)
            var proxyResourceModel = InputFactory.Model(
                "ProxyResource",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);

            var crossLangProp = typeof(InputModelType).GetProperty(nameof(InputModelType.CrossLanguageDefinitionId));
            crossLangProp!.GetSetMethod(true)!.Invoke(proxyResourceModel, ["Azure.ResourceManager.CommonTypes.ProxyResource"]);

            // Create child model that extends ProxyResource
            var childModel = InputFactory.Model(
                "ChildModel",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("customProp", InputPrimitiveType.String),
                ],
                baseModel: proxyResourceModel,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [proxyResourceModel, childModel]);

            var childProvider = plugin.Object.TypeFactory.CreateModel(childModel);
            Assert.IsNotNull(childProvider);

            // The base type properties (id, name, type, systemData) should be filtered out
            // Only customProp should remain
            var propertyNames = childProvider!.Properties.Select(p => p.Name).ToList();
            Assert.IsFalse(propertyNames.Contains("Id"), "Id should be filtered (from base ResourceData)");
            Assert.IsFalse(propertyNames.Contains("Name"), "Name should be filtered (from base ResourceData)");
            Assert.IsFalse(propertyNames.Contains("ResourceType"), "ResourceType should be filtered (from base ResourceData)");
            Assert.IsFalse(propertyNames.Contains("SystemData"), "SystemData should be filtered (from base ResourceData)");
            Assert.IsTrue(propertyNames.Contains("CustomProp"), "CustomProp should remain as model-specific property");
        }
    }
}
