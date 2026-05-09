// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class InheritableSystemObjectModelVisitorTests
    {
        /// <summary>
        /// Verifies that a model extending TrackedResource resolves to TrackedResourceData
        /// as its base type, not ArmResource or any other incorrect type.
        /// This reproduces the bug where the framework eagerly caches CSharpType.BaseType
        /// during model construction. When model processing order causes the derived model
        /// to be constructed before the base model's InheritableSystemObjectModelProvider,
        /// the cached BaseType gets permanently set to the wrong value.
        /// </summary>
        [TestCase("Azure.ResourceManager.CommonTypes.TrackedResource", typeof(Azure.ResourceManager.Models.TrackedResourceData))]
        [TestCase("Azure.ResourceManager.CommonTypes.ProxyResource", typeof(Azure.ResourceManager.Models.ResourceData))]
        [TestCase("Azure.ResourceManager.CommonTypes.ExtensionResource", typeof(Azure.ResourceManager.Models.ResourceData))]
        public void ResourceDataModelInheritsCorrectBaseType(string baseModelCrossLanguageId, System.Type expectedBaseType)
        {
            // Arrange: Create a base model (TrackedResource/ProxyResource) and a derived model
            var baseModel = new InputModelType(
                "TrackedResource",
                "Azure.ResourceManager.CommonTypes",
                baseModelCrossLanguageId,
                "public",
                null,
                null,
                "ARM Tracked Resource",
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

            var derivedModel = new InputModelType(
                "MonitorResource",
                "Samples.Models",
                "MonitorResource",
                "public",
                null,
                null,
                "Monitor Resource extending tracked resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [InputFactory.Property("monitorName", InputPrimitiveType.String)],
                baseModel,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            // Load with derived model FIRST to stress model ordering
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [derivedModel, baseModel]);

            // Act - create the derived model
            var derivedType = plugin.Object.TypeFactory.CreateModel(derivedModel);

            // Assert
            Assert.That(derivedType, Is.Not.Null, "Derived model should be created");
            Assert.That(derivedType!.BaseModelProvider, Is.Not.Null, "Derived model should have a base model provider");

            // The critical assertion: the derived model's CSharpType.BaseType should be the
            // correct framework type (TrackedResourceData/ResourceData), not ArmResource.
            var actualBaseType = derivedType.Type.BaseType;
            Assert.That(actualBaseType, Is.Not.Null, "Derived model's CSharpType.BaseType should not be null");
            Assert.That(actualBaseType!.IsFrameworkType, Is.True,
                $"Expected framework type {expectedBaseType.Name} but got non-framework type: {actualBaseType.Name} ({actualBaseType.Namespace})");
            Assert.That(actualBaseType.FrameworkType, Is.EqualTo(expectedBaseType),
                $"Derived model should inherit from {expectedBaseType.Name}");
        }

        /// <summary>
        /// Verifies that a PATCH model reparented (via @@hierarchyBuilding) under a sibling
        /// resource that itself extends TrackedResource still exposes the public
        /// (AzureLocation location) constructor chaining to base(location). Reproduces the
        /// real scenario from https://github.com/Azure/azure-sdk-for-net/issues/58490 where
        /// the PATCH envelope has multiple properties (so FlattenPropertyVisitor's safe-flatten
        /// path does not run) and the chain is patch -> resource -> TrackedResource.
        /// </summary>
        [Test]
        public void PatchModelExtendingTrackedResourceKeepsLocationConstructor()
        {
            var trackedResource = new InputModelType(
                "TrackedResource",
                "Azure.ResourceManager.CommonTypes",
                "Azure.ResourceManager.CommonTypes.TrackedResource",
                "public",
                null,
                null,
                "ARM Tracked Resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputFactory.Primitive.String("azureLocation", "Azure.Core.azureLocation"), isRequired: true),
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

            // The resource model: extends TrackedResource (via `is TrackedResource`).
            var multiPropResource = new InputModelType(
                "MultiProp",
                "Samples.Models",
                "MultiProp",
                "public",
                null,
                null,
                "MultiProp resource extending tracked resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [InputFactory.Property("multiName", InputPrimitiveType.String)],
                trackedResource,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            var multiPropsUpdate = InputFactory.Model(
                "MultiPropsUpdate",
                usage: InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("propA", InputPrimitiveType.String, isRequired: false, serializedName: "propA"),
                    InputFactory.Property("propB", InputPrimitiveType.Int32, isRequired: false, serializedName: "propB"),
                    InputFactory.Property("propC", InputPrimitiveType.Boolean, isRequired: false, serializedName: "propC"),
                ]);

            // The PATCH model: reparented under MultiProp via @@hierarchyBuilding.
            // Multi-property envelope so FlattenPropertyVisitor's safe-flatten gate is NOT met.
            var patchModel = new InputModelType(
                "MultiPropPatch",
                "Samples.Models",
                "MultiPropPatch",
                "public",
                null,
                null,
                "PATCH model extending the resource via hierarchy building",
                InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [
                    InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String), isRequired: false, serializedName: "tags"),
                    InputFactory.Property("properties", multiPropsUpdate, isRequired: false, serializedName: "properties"),
                ],
                multiPropResource,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [patchModel, multiPropResource, trackedResource, multiPropsUpdate]);

            // Realize all models in the chain so visitors run on each.
            var resourceModel = plugin.Object.TypeFactory.CreateModel(multiPropResource);
            var model = plugin.Object.TypeFactory.CreateModel(patchModel);
            Assert.That(resourceModel, Is.Not.Null);
            Assert.That(model, Is.Not.Null);

            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [resourceModel]);
                visitTypeCore!.Invoke(visitor, [model]);
            }

            // Resource itself should expose the (AzureLocation location) public ctor with : base(location).
            AssertHasLocationCtorChainingToBase(resourceModel!, "Resource model");

            // PATCH descendant must also expose (AzureLocation location) chaining to its (now-fixed) base.
            AssertHasLocationCtorChainingToBase(model!, "PATCH model");
        }

        private static void AssertHasLocationCtorChainingToBase(ModelProvider model, string label)
        {
            var publicConstructor = model.Constructors.SingleOrDefault(
                c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.That(publicConstructor, Is.Not.Null, $"{label} should keep a public constructor");
            Assert.That(publicConstructor!.Signature.Parameters.Count, Is.EqualTo(1), $"{label} should expose a single required location parameter");
            Assert.That(publicConstructor.Signature.Parameters[0].Name, Is.EqualTo("location"));
            Assert.That(publicConstructor.Signature.Parameters[0].Type.Name, Is.EqualTo("AzureLocation"));

            var initializer = publicConstructor.Signature.Initializer;
            Assert.That(initializer, Is.Not.Null, $"{label}'s public constructor should delegate to a base constructor");
            Assert.That(initializer!.IsBase, Is.True, $"{label}'s public constructor should use a base initializer");
            Assert.That(initializer.Arguments.Count, Is.EqualTo(1));
            Assert.That(initializer.Arguments[0], Is.TypeOf<VariableExpression>());
            Assert.That(((VariableExpression)initializer.Arguments[0]).Declaration.RequestedName, Is.EqualTo("location"));
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
        /// Verifies that a two-level inheritance chain (Resource → BaseModel → DerivedModel)
        /// produces consistent raw-data field references. Before the fix, the derived model's
        /// FullConstructor parameter for additionalBinaryDataProperties referenced a different
        /// FieldProvider than the one the serialization code finds via base-model field lookup,
        /// causing the code writer to emit mismatched variable names (additionalBinaryDataProperties0).
        /// Regression test for https://github.com/Azure/azure-sdk-for-net/issues/57281
        /// </summary>
        [Test]
        public void DerivedModelRawDataFieldMatchesBaseModelField()
        {
            // Arrange: Resource → EntityResourceLike → ContainerItemLike
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

            // Mid-level model extending Resource (like AzureEntityResource)
            var entityModel = new InputModelType(
                "EntityResourceLike",
                "Samples.Models",
                "EntityResourceLike",
                "public",
                null,
                null,
                "Entity resource extending ARM Resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [InputFactory.Property("etag", InputPrimitiveType.String, isReadOnly: true)],
                resourceModel,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            // Leaf model extending mid-level model (like ListContainerItem)
            var containerModel = new InputModelType(
                "ContainerItemLike",
                "Samples.Models",
                "ContainerItemLike",
                "public",
                null,
                null,
                "Container item extending entity resource",
                InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                [InputFactory.Property("something", InputPrimitiveType.String)],
                entityModel,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [resourceModel, entityModel, containerModel]);

            // Act - create models in order; the visitor runs Update on entityModel
            // (adding a new _additionalBinaryDataProperties field) and then
            // FixRawDataFieldReference on containerModel.
            var entityType = plugin.Object.TypeFactory.CreateModel(entityModel);
            var containerType = plugin.Object.TypeFactory.CreateModel(containerModel);

            Assert.That(entityType, Is.Not.Null);
            Assert.That(containerType, Is.Not.Null);

            // Find the _additionalBinaryDataProperties field on the base model
            var baseRawDataField = entityType!.Fields.FirstOrDefault(
                f => f.Name == "_additionalBinaryDataProperties");
            Assert.That(baseRawDataField, Is.Not.Null, "Base model should have _additionalBinaryDataProperties field");

            // Find the constructor parameter on the derived model
            var derivedCtorParam = containerType!.FullConstructor.Signature.Parameters
                .FirstOrDefault(p => p.Name == "additionalBinaryDataProperties");
            Assert.That(derivedCtorParam, Is.Not.Null, "Derived model should have additionalBinaryDataProperties constructor parameter");

            // Assert: the derived model's constructor parameter references the same
            // FieldProvider that the base model exposes — this is exactly what
            // FixRawDataFieldReference ensures.
            Assert.That(derivedCtorParam!.Field, Is.SameAs(baseRawDataField),
                "Derived model's constructor parameter must reference the same FieldProvider " +
                "as the base model's _additionalBinaryDataProperties field to avoid variable " +
                "name mismatch in generated serialization code");
        }
    }
}
