// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class FlattenPropertyVisitorTests
    {
        /// <summary>
        /// Verifies that flattening works correctly when the nested properties model
        /// has no public constructor (Output-only usage). Previously this crashed with
        /// "Sequence contains no matching element" because UpdatePublicConstructorBody
        /// unconditionally passed publicConstructor: true to BuildConstructorParameters.
        /// </summary>
        [Test]
        public void TestFlattenWithNoPublicConstructorOnNestedModel()
        {
            // Create a nested "properties" model with Output-only usage.
            // Output-only models don't get a public constructor — only an internal FullConstructor.
            var innerProperty = InputFactory.Property("displayName", InputPrimitiveType.String, isRequired: true, serializedName: "displayName");
            var propertiesModel = InputFactory.Model(
                "TestProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties: [innerProperty]);

            // Create a property on the parent model referencing the properties model,
            // then apply the @flattenProperty decorator to it.
            var propertiesProperty = InputFactory.Property("properties", propertiesModel, isRequired: true, serializedName: "properties");
            ApplyFlattenDecorator(propertiesProperty);

            // Create the parent model with Input+Output usage so it gets a public constructor.
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [propertiesProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, propertiesModel]);

            // Create the model provider (this runs PreVisit* visitors only).
            var model = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(model);

            // Verify the Output-only nested model has no public constructor (precondition).
            var nestedModel = plugin.Object.TypeFactory.CreateModel(propertiesModel);
            Assert.IsNotNull(nestedModel);
            Assert.IsFalse(
                nestedModel!.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)),
                "Precondition: Output-only nested model should have no public constructor");

            // Now run the VisitType visitors on the parent model.
            // FlattenPropertyVisitor.VisitType() processes @flattenProperty decorators and
            // calls BuildConstructorParameters on the nested model. The fix checks whether
            // the nested model has a public constructor and falls back to FullConstructor
            // when it does not. Without the fix, this throws InvalidOperationException:
            // "Sequence contains no matching element" from .First().
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");

            Assert.DoesNotThrow(() =>
            {
                foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
                {
                    visitTypeCore!.Invoke(visitor, [model]);
                }
            });
        }

        private static void ApplyFlattenDecorator(InputModelProperty property)
        {
            var decorator = new InputDecoratorInfo(
                "Azure.ResourceManager.@flattenProperty",
                new Dictionary<string, BinaryData>());
            var decoratorsProperty = typeof(InputModelProperty).GetProperty(
                nameof(InputModelProperty.Decorators),
                BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(decoratorsProperty, "Could not find InputModelProperty.Decorators property");
            decoratorsProperty!.SetValue(property, new[] { decorator });
        }

        /// <summary>
        /// Verifies that a discriminator base model with a single non-discriminator public property
        /// is NOT safe-flattened. Previously, since the discriminator property is internal and not
        /// counted in publicPropertyCount, the model appeared to have only one public property,
        /// triggering safe-flatten and making the discriminator base type internal — breaking the
        /// polymorphic hierarchy.
        /// </summary>
        [Test]
        public void TestSafeFlattenSkipsDiscriminatorBaseModel()
        {
            // Create a discriminator base model with one discriminator property and one regular property.
            // The discriminator property will be internal, so publicPropertyCount == 1.
            var discriminatorProperty = InputFactory.Property("kind", InputPrimitiveType.String, isRequired: true, isDiscriminator: true, serializedName: "kind");
            var regularProperty = InputFactory.Property("retentionDays", InputPrimitiveType.Int32, isRequired: false, serializedName: "retentionDays");

            var derivedModel = InputFactory.Model(
                "PeriodicBackupPolicy",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("intervalInHours", InputPrimitiveType.Int32, isRequired: true, serializedName: "intervalInHours")],
                discriminatedKind: "Periodic");

            var discriminatorBaseModel = InputFactory.Model(
                "BackupPolicy",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [discriminatorProperty, regularProperty],
                derivedModels: [derivedModel],
                discriminatedModels: new Dictionary<string, InputModelType> { { "Periodic", derivedModel } });

            // Create a parent model that has a property of the discriminator base type.
            var backupPolicyProperty = InputFactory.Property("backupPolicy", discriminatorBaseModel, isRequired: false, serializedName: "backupPolicy");
            var parentModel = InputFactory.Model(
                "DatabaseAccount",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [backupPolicyProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, discriminatorBaseModel, derivedModel]);

            // Create model providers.
            var parentModelProvider = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(parentModelProvider);

            var discriminatorModelProvider = plugin.Object.TypeFactory.CreateModel(discriminatorBaseModel);
            Assert.IsNotNull(discriminatorModelProvider);

            // Run all visitors on the parent model.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [parentModelProvider]);
            }

            // The backupPolicy property should NOT have been flattened — it should remain public.
            var backupPolicyProp = parentModelProvider!.Properties.FirstOrDefault(p => p.Name == "BackupPolicy");
            Assert.IsNotNull(backupPolicyProp, "BackupPolicy property should still exist on the parent model");
            Assert.IsTrue(
                backupPolicyProp!.Modifiers.HasFlag(MethodSignatureModifiers.Public),
                "BackupPolicy property should remain public (not flattened to internal)");
        }
    }
}
