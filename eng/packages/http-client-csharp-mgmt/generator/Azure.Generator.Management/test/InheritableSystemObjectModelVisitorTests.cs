// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    public class InheritableSystemObjectModelVisitorTests
    {
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
            Assert.That(modelProvider, Is.Not.Null);
            Assert.That(modelProvider, Is.InstanceOf<SystemObjectModelProvider>());

            // The CSharpTypeMap should now have both framework and non-framework entries
            var typeMap = plugin.Object.TypeFactory.CSharpTypeMap;

            // Check that a framework CSharpType for ResourceData can be found
            var frameworkResourceData = new CSharpType(typeof(ResourceData));
            Assert.That(typeMap.ContainsKey(frameworkResourceData), Is.True,
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
            Assert.That(childProvider, Is.Not.Null);

            // The base type properties (id, name, type, systemData) should be filtered out
            // Only customProp should remain
            var propertyNames = childProvider!.Properties.Select(p => p.Name).ToList();
            Assert.That(propertyNames.Contains("Id"), Is.False, "Id should be filtered (from base ResourceData)");
            Assert.That(propertyNames.Contains("Name"), Is.False, "Name should be filtered (from base ResourceData)");
            Assert.That(propertyNames.Contains("ResourceType"), Is.False, "ResourceType should be filtered (from base ResourceData)");
            Assert.That(propertyNames.Contains("SystemData"), Is.False, "SystemData should be filtered (from base ResourceData)");
            Assert.That(propertyNames.Contains("CustomProp"), Is.True, "CustomProp should remain as model-specific property");
        }

        /// <summary>
        /// Verifies that creating a discriminated model extending ARM Resource does not cause
        /// a stack overflow. Before the fix, UpdateSerialization accessed Methods during
        /// PreVisitModel which triggered building DerivedModels -> CreateModel for derived types
        /// -> which needed the base model (not yet cached) -> infinite recursion.
        /// Regression test for https://github.com/Azure/azure-sdk-for-net/issues/56505
        /// </summary>
        [Test]
        public void DiscriminatedModelExtendingResourceDoesNotStackOverflow()
        {
            // Create the ARM Resource base model (recognized as InheritableSystemObjectModelProvider
            // via crossLanguageDefinitionId = "Azure.ResourceManager.CommonTypes.Resource")
            var resourceModel = new InputModelType(
                "Resource",
                "Azure.ResourceManager.CommonTypes",
                "Azure.ResourceManager.CommonTypes.Resource",
                "public",
                null,
                null,
                "ARM Resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                ],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            // Create a derived model (its BaseModel will be set automatically by
            // UsageDetail's constructor via AddDerivedModel when added to discriminatedSubtypes)
            var legacyModel = new InputModelType(
                "LegacyUsageDetail",
                "Samples.Models",
                "LegacyUsageDetail",
                "public",
                null,
                null,
                "Legacy usage detail",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [InputFactory.Property("billingAccountId", InputPrimitiveType.String)],
                null,
                [],
                "legacy",
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            // Create the discriminated model extending Resource.
            // The discriminatedSubtypes setter triggers AddDerivedModel, which sets
            // legacyModel.BaseModel = usageDetailModel and also creates an UnknownUsageDetail model.
            var discriminatorProp = InputFactory.Property("kind", InputPrimitiveType.String, isDiscriminator: true);
            var usageDetailModel = new InputModelType(
                "UsageDetail",
                "Samples.Models",
                "UsageDetail",
                "public",
                null,
                null,
                "Discriminated usage detail extending ARM Resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [discriminatorProp],
                resourceModel,
                [],
                null,
                discriminatorProp,
                new Dictionary<string, InputModelType> { ["legacy"] = legacyModel },
                null,
                false,
                new InputSerializationOptions(),
                false);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [resourceModel, usageDetailModel, legacyModel]);

            // Act - CreateModel triggers PreVisitModel which calls Update on UsageDetail.
            // Before the fix, UpdateSerialization would access .Methods, triggering
            // DerivedModels building -> CreateModel(LegacyUsageDetail) -> needs BaseModel
            // -> CreateModel(UsageDetail) [not yet cached] -> infinite recursion -> stack overflow.
            // With the fix, UpdateSerialization is deferred to VisitType for discriminated models.
            var usageDetailType = plugin.Object.TypeFactory.CreateModel(usageDetailModel);

            // Assert the model was created successfully
            Assert.That(usageDetailType, Is.Not.Null);
            Assert.That(usageDetailType!.BaseModelProvider, Is.Not.Null);

            // Also verify derived models can be created without issues
            var legacyType = plugin.Object.TypeFactory.CreateModel(legacyModel);
            Assert.That(legacyType, Is.Not.Null);
        }

        /// <summary>
        /// Verifies that when custom code overrides a model's base type to an inheritable
        /// system type (e.g., TrackedResourceData) that is NOT present as an
        /// InheritableSystemObjectModelProvider, the visitor uses CLR reflection to enumerate
        /// base properties and filters them from the model.
        /// </summary>
        [Test]
        public void CustomCodeBaseTypeOverride_UsesClrReflectionFallback()
        {
            // Create a TrackedResource input model with all the base properties
            var trackedResourceInputModel = InputFactory.Model(
                "TrackedResource",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String),
                    InputFactory.Property("tags", InputPrimitiveType.String),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);

            // Create a simple model with properties that overlap TrackedResourceData's properties
            var inputModel = InputFactory.Model(
                "MyTrackedModel",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String),
                    InputFactory.Property("tags", InputPrimitiveType.String),
                    InputFactory.Property("customProp", InputPrimitiveType.String),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);

            // Load mock plugin (needed for ManagementClientGenerator.Instance)
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [inputModel, trackedResourceInputModel]);

            // Register a SystemObjectModelProvider for TrackedResourceData in CSharpTypeMap
            var trackedResourceType = new CSharpType(typeof(TrackedResourceData));
            var systemBase = new SystemObjectModelProvider(trackedResourceType, trackedResourceInputModel);
            var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
            typeMap[trackedResourceType] = systemBase;

            // Create model directly (not via TypeFactory to avoid the automatic visitor pass)
            var model = new ModelProvider(inputModel);

            // Set custom code view with BaseType = TrackedResourceData
            SetCustomCodeView(model, new TrackedResourceDataCustomCodeView());

            // Create a testable visitor and invoke PreVisitModel
            var visitor = new TestableInheritableSystemObjectModelVisitor();
            var result = visitor.InvokePreVisitModel(inputModel, model);

            Assert.That(result, Is.Not.Null);

            // Properties from TrackedResourceData (Id, Name, ResourceType, SystemData, Tags, Location)
            // should be filtered out by the base generator's native property dedup.
            // Only CustomProp should remain.
            var propertyNames = result!.Properties.Select(p => p.Name).ToList();
            Assert.That(propertyNames.Contains("Id"), Is.False, "Id should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("Name"), Is.False, "Name should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("ResourceType"), Is.False, "ResourceType should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("SystemData"), Is.False, "SystemData should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("Tags"), Is.False, "Tags should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("Location"), Is.False, "Location should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("CustomProp"), Is.True, "CustomProp should remain as model-specific property");
        }

        [Test]
        public void InputResourceModelCustomCodeBaseTypeOverride_UsesCustomBaseType()
        {
            var resourceModel = InputFactory.Model(
                "Resource",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            typeof(InputModelType).GetProperty(nameof(InputModelType.CrossLanguageDefinitionId))!
                .GetSetMethod(true)!
                .Invoke(resourceModel, ["Azure.ResourceManager.CommonTypes.Resource"]);

            var inputModel = InputFactory.Model(
                "ClusterUpdatePatch",
                properties: [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String),
                    InputFactory.Property("tags", InputPrimitiveType.String),
                    InputFactory.Property("customProp", InputPrimitiveType.String),
                ],
                baseModel: resourceModel,
                usage: InputModelTypeUsage.Input | InputModelTypeUsage.Json);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [resourceModel, inputModel]);

            var model = plugin.Object.TypeFactory.CreateModel(inputModel);
            Assert.That(model, Is.Not.Null);
            SetCustomCodeView(model!, new ClusterUpdatePatchCustomCodeView());

            var visitor = new TestableInheritableSystemObjectModelVisitor();
            var result = visitor.InvokePreVisitModel(inputModel, model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.BaseType?.AreNamesEqual(new CSharpType(typeof(TrackedResourceData))), Is.True);

            var propertyNames = result.Properties.Select(p => p.Name).ToList();
            Assert.That(propertyNames.Contains("Id"), Is.False, "Id should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("Name"), Is.False, "Name should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("ResourceType"), Is.False, "ResourceType should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("SystemData"), Is.False, "SystemData should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("Tags"), Is.False, "Tags should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("Location"), Is.False, "Location should be filtered (from TrackedResourceData base)");
            Assert.That(propertyNames.Contains("CustomProp"), Is.True, "CustomProp should remain as model-specific property");

            var modelContent = new TypeProviderWriter(result).Write().Content;
            Assert.That(modelContent, Does.Contain("public partial class ClusterUpdatePatch : global::Azure.ResourceManager.Models.TrackedResourceData"));
            Assert.That(modelContent, Does.Not.Contain(" : base("));
        }

        private static void SetCustomCodeView(TypeProvider typeProvider, TypeProvider customCodeTypeProvider)
        {
            var currentType = typeProvider.GetType();
            while (currentType is not null)
            {
                var field = currentType.GetField("_customCodeView", BindingFlags.NonPublic | BindingFlags.Instance);
                if (field is not null)
                {
                    field.SetValue(typeProvider, new Lazy<TypeProvider>(() => customCodeTypeProvider));
                    return;
                }

                currentType = currentType.BaseType;
            }

            throw new InvalidOperationException($"Unable to find _customCodeView field on {typeProvider.GetType().FullName}.");
        }

        /// <summary>
        /// A custom code view that declares TrackedResourceData as the base type,
        /// simulating custom code like: public partial class MyTrackedModel : TrackedResourceData { }
        /// </summary>
        private class TrackedResourceDataCustomCodeView : TypeProvider
        {
            protected override CSharpType BuildBaseType() => new CSharpType(typeof(TrackedResourceData));
            protected override string BuildName() => "MyTrackedModel";
            protected override string BuildRelativeFilePath() => "MyTrackedModel.cs";
        }

        private class ClusterUpdatePatchCustomCodeView : TypeProvider
        {
            protected override CSharpType BuildBaseType() => new CSharpType(typeof(TrackedResourceData));
            protected override string BuildName() => "ClusterUpdatePatch";
            protected override string BuildRelativeFilePath() => "ClusterUpdatePatch.cs";
        }

        private class TestableInheritableSystemObjectModelVisitor : InheritableSystemObjectModelVisitor
        {
            public ModelProvider? InvokePreVisitModel(InputModelType inputType, ModelProvider? type)
            {
                return base.PreVisitModel(inputType, type);
            }
        }
    }
}
