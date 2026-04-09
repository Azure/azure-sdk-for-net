// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Reflection;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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

        /// <summary>
        /// Verifies that IsBackwardCompatMethod correctly identifies methods with the
        /// [EditorBrowsable(EditorBrowsableState.Never)] attribute.
        /// </summary>
        [Test]
        public void TestIsBackwardCompatMethod()
        {
            // Set up the mock plugin (required for ManagementClientGenerator.Instance)
            var propertiesModel = InputFactory.Model(
                "TestProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("displayName", InputPrimitiveType.String, serializedName: "displayName")]);
            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [propertiesModel]);

            var enclosingType = ManagementClientGenerator.Instance.TypeFactory.CreateModel(propertiesModel)!;

            // Create a method WITHOUT the EditorBrowsable attribute
            var primarySignature = new MethodSignature(
                "TestMethod",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                null,
                null,
                []);
            var primaryMethod = new MethodProvider(primarySignature, MethodBodyStatement.Empty, enclosingType);
            Assert.IsFalse(FlattenPropertyVisitor.IsBackwardCompatMethod(primaryMethod));

            // Create a method WITH the EditorBrowsable(Never) attribute
            var backCompatSignature = new MethodSignature(
                "TestMethod",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                null,
                null,
                [],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), Snippet.FrameworkEnumValue(EditorBrowsableState.Never))]);
            var backCompatMethod = new MethodProvider(backCompatSignature, MethodBodyStatement.Empty, enclosingType);
            Assert.IsTrue(FlattenPropertyVisitor.IsBackwardCompatMethod(backCompatMethod));
        }

        /// <summary>
        /// Verifies that FixBackwardCompatOverloads correctly reorders arguments in
        /// backward-compat overloads when the primary method's parameter order has changed
        /// after property flattening.
        /// </summary>
        [Test]
        public void TestFixBackwardCompatOverloadsReordersArguments()
        {
            // Set up the mock plugin (required for ManagementClientGenerator.Instance)
            var propertiesModel = InputFactory.Model(
                "TestProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("displayName", InputPrimitiveType.String, serializedName: "displayName")]);
            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [propertiesModel]);

            var enclosingType = ManagementClientGenerator.Instance.TypeFactory.CreateModel(propertiesModel)!;

            // Create the primary method signature with params in the FLATTENED order:
            // (id, name, displayName, provisioningState, etag)
            var paramId = new ParameterProvider("id", $"", typeof(string)) { DefaultValue = Default };
            var paramName = new ParameterProvider("name", $"", typeof(string)) { DefaultValue = Default };
            var paramDisplayName = new ParameterProvider("displayName", $"", typeof(string)) { DefaultValue = Default };
            var paramProvState = new ParameterProvider("provisioningState", $"", typeof(string)) { DefaultValue = Default };
            var paramEtag = new ParameterProvider("etag", $"", typeof(string)) { DefaultValue = Default };

            var primarySignature = new MethodSignature(
                "TestData",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(object),
                null,
                [paramId, paramName, paramDisplayName, paramProvState, paramEtag]);
            var primaryMethod = new MethodProvider(primarySignature, MethodBodyStatement.Empty, enclosingType);

            // Create the backward-compat overload that calls the primary method.
            // The OLD param order was: (id, name, etag, displayName, provisioningState)
            var oldParamId = new ParameterProvider("id", $"", typeof(string));
            var oldParamName = new ParameterProvider("name", $"", typeof(string));
            var oldParamEtag = new ParameterProvider("etag", $"", typeof(string));
            var oldParamDisplayName = new ParameterProvider("displayName", $"", typeof(string));
            var oldParamProvState = new ParameterProvider("provisioningState", $"", typeof(string));

            var oldSignature = new MethodSignature(
                "TestData",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(object),
                null,
                [oldParamId, oldParamName, oldParamEtag, oldParamDisplayName, oldParamProvState],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), Snippet.FrameworkEnumValue(EditorBrowsableState.Never))]);

            // The old invoke signature (what the base generator used to build the call)
            // has params in the PRE-FLATTEN order: (id, name, etag, displayName, provisioningState)
            var preFlattenSignature = new MethodSignature(
                "TestData",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(object),
                null,
                [paramId, paramName, paramEtag, paramDisplayName, paramProvState]);

            // Build the invoke call with positional args in the OLD (pre-flatten) order
            var invokeExpression = new InvokeMethodExpression(null, preFlattenSignature,
                [oldParamId, oldParamName, oldParamEtag, oldParamDisplayName, oldParamProvState]);

            var backCompatBody = Return(invokeExpression);
            var backCompatMethod = new MethodProvider(oldSignature, backCompatBody, enclosingType);

            // Act: Run the fix
            FlattenPropertyVisitor.FixBackwardCompatOverloads([primaryMethod, backCompatMethod]);

            // Assert: The backward-compat overload's body should now have arguments
            // in the PRIMARY method's current parameter order
            Assert.IsNotNull(backCompatMethod.BodyStatements);
            var statements = backCompatMethod.BodyStatements!.ToArray();
            Assert.AreEqual(1, statements.Length);

            var returnStatement = statements[0] as ExpressionStatement;
            Assert.IsNotNull(returnStatement);
            var keywordExpr = returnStatement!.Expression as KeywordExpression;
            Assert.IsNotNull(keywordExpr);
            var newInvoke = keywordExpr!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(newInvoke);

            // The arguments should now be in the PRIMARY method's order:
            // (id, name, displayName, provisioningState, etag)
            var args = newInvoke!.Arguments;
            Assert.AreEqual(5, args.Count);
            AssertArgIsParameter(args[0], "id", "position 0");
            AssertArgIsParameter(args[1], "name", "position 1");
            AssertArgIsParameter(args[2], "displayName", "position 2");
            AssertArgIsParameter(args[3], "provisioningState", "position 3");
            AssertArgIsParameter(args[4], "etag", "position 4");
        }

        private static void AssertArgIsParameter(ValueExpression arg, string expectedName, string context)
        {
            string? actualName = arg is VariableExpression v ? v.Declaration.RequestedName : null;
            Assert.AreEqual(expectedName, actualName, $"Expected parameter '{expectedName}' at {context}, but got '{actualName ?? arg.GetType().Name}'");
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
        /// Verifies that when all flattened sub-properties are optional (non-required),
        /// the public constructor is kept as a parameterless constructor instead of being removed.
        /// This is the regression scenario: a model with a "properties" bag where every
        /// sub-property is optional should still have a public parameterless constructor
        /// so users can create the object and populate optional properties via setters.
        /// </summary>
        [Test]
        public void TestFlattenKeepsPublicConstructorWhenAllPropertiesAreOptional()
        {
            // Create a nested "properties" model with only optional sub-properties.
            var optionalProp1 = InputFactory.Property("displayName", InputPrimitiveType.String, isRequired: false, serializedName: "displayName");
            var optionalProp2 = InputFactory.Property("description", InputPrimitiveType.String, isRequired: false, serializedName: "description");
            var propertiesModel = InputFactory.Model(
                "TestOptionalProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [optionalProp1, optionalProp2]);

            // Create a required "properties" property with @flattenProperty decorator.
            var propertiesProperty = InputFactory.Property("properties", propertiesModel, isRequired: true, serializedName: "properties");
            ApplyFlattenDecorator(propertiesProperty);

            // Create the parent model with Input+Output usage so it gets a public constructor.
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [propertiesProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, propertiesModel]);

            // Create the model provider.
            var model = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(model);

            // Verify precondition: before visitors run, there IS a public constructor.
            Assert.IsTrue(
                model!.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)),
                "Precondition: model should have a public constructor before visitors run");

            // Run the VisitType visitors (which triggers FlattenPropertyVisitor).
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [model]);
            }

            // After visitors run, the public constructor should still exist (parameterless).
            var publicCtor = model.Constructors.SingleOrDefault(
                c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsNotNull(publicCtor, "Public constructor should be kept (as parameterless) when all flattened properties are optional");
            Assert.AreEqual(0, publicCtor!.Signature.Parameters.Count,
                "Public constructor should be parameterless since all flattened properties are optional");

            // The serialization type should NOT have an internal parameterless constructor
            // (it would conflict with the public one in the partial class, causing CS0111).
            foreach (var serializationType in model!.SerializationProviders)
            {
                var serializationParameterlessCtor = serializationType.Constructors
                    .SingleOrDefault(c => !c.Signature.Parameters.Any());
                Assert.IsNull(serializationParameterlessCtor,
                    "Serialization type should not have a parameterless constructor when the model already has one");
            }
        }

        /// <summary>
        /// Verifies that when flattened sub-properties contain a mix of required and optional,
        /// only the required ones appear as constructor parameters.
        /// </summary>
        [Test]
        public void TestFlattenConstructorIncludesOnlyRequiredProperties()
        {
            // Create a nested "properties" model with one required and one optional property.
            var requiredProp = InputFactory.Property("name", InputPrimitiveType.String, isRequired: true, serializedName: "name");
            var optionalProp = InputFactory.Property("description", InputPrimitiveType.String, isRequired: false, serializedName: "description");
            var propertiesModel = InputFactory.Model(
                "TestMixedProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [requiredProp, optionalProp]);

            // Create a required "properties" property with @flattenProperty decorator.
            var propertiesProperty = InputFactory.Property("properties", propertiesModel, isRequired: true, serializedName: "properties");
            ApplyFlattenDecorator(propertiesProperty);

            // Create the parent model.
            var parentModel = InputFactory.Model(
                "TestResourceMixed",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [propertiesProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, propertiesModel]);

            var model = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(model);

            // Run the VisitType visitors.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore);

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [model]);
            }

            // The public constructor should exist with only the required property as parameter.
            var publicCtorMixed = model!.Constructors.SingleOrDefault(
                c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsNotNull(publicCtorMixed, "Public constructor should exist");
            Assert.That(publicCtorMixed!.Signature.Parameters, Has.Count.EqualTo(1),
                "Public constructor should have exactly 1 parameter (the required property)");
            Assert.AreEqual("name", publicCtorMixed.Signature.Parameters[0].Name,
                "The constructor parameter should be the required 'name' property");
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

        /// <summary>
        /// Verifies that properties marked [Obsolete] on a child model's custom code (partial class)
        /// are skipped during property flattening. Only non-obsolete public properties should be
        /// flattened onto the parent model, avoiding CS0618 warnings.
        /// </summary>
        [Test]
        public void TestFlattenSkipsObsoletePropertiesFromCustomCode()
        {
            // Create a child model "Step" with one normal property.
            var startTimeUtcProp = InputFactory.Property("startTimeUtc", InputPrimitiveType.PlainDate, isRequired: false, serializedName: "startTimeUtc");
            var stepModel = InputFactory.Model(
                "Step",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [startTimeUtcProp]);

            // Create a "properties" property on the parent model referencing the Step model,
            // then apply the @flattenProperty decorator to it.
            var progressProperty = InputFactory.Property("progress", stepModel, isRequired: false, serializedName: "progress");
            ApplyFlattenDecorator(progressProperty);

            // Create the parent model.
            var parentModel = InputFactory.Model(
                "MyProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [progressProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, stepModel]);

            // Create the model providers.
            var parentModelProvider = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(parentModelProvider);

            var stepModelProvider = plugin.Object.TypeFactory.CreateModel(stepModel);
            Assert.IsNotNull(stepModelProvider);

            // Set up a custom code view on the Step model that has an [Obsolete] property.
            var customCodeView = new ObsoletePropertyCustomCodeView(stepModelProvider!);
            ManagementMockHelpers.SetCustomCodeView(stepModelProvider!, customCodeView);

            // Run all visitors on the parent model.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [parentModelProvider]);
            }

            // After flattening, the parent model should have:
            // 1. The original "Progress" property (now internal)
            // 2. A flattened "StartTimeUtc" property (from the non-obsolete property)
            // It should NOT have a flattened "OldPropertyName" (the obsolete property from custom code).

            var flattenedStartTimeUtc = parentModelProvider!.Properties.FirstOrDefault(p => p.Name == "StartTimeUtc");
            Assert.IsNotNull(flattenedStartTimeUtc, "Non-obsolete property 'StartTimeUtc' should be flattened onto the parent model");

            var flattenedObsolete = parentModelProvider.Properties.FirstOrDefault(p => p.Name == "OldPropertyName");
            Assert.IsNull(flattenedObsolete, "Obsolete property 'OldPropertyName' should NOT be flattened onto the parent model");
        }

        /// <summary>
        /// Verifies that when the child model has multiple normal properties and an [Obsolete]
        /// property from custom code, all non-obsolete properties are flattened via PropertyFlatten
        /// while the obsolete one is skipped. This exercises the PropertyFlatten iteration loop
        /// (as opposed to SafeFlatten which handles the single-property case).
        /// </summary>
        [Test]
        public void TestPropertyFlattenSkipsObsoleteWithMultipleProperties()
        {
            // Create a child model "Step" with two normal properties.
            var startTimeUtcProp = InputFactory.Property("startTimeUtc", InputPrimitiveType.PlainDate, isRequired: false, serializedName: "startTimeUtc");
            var endTimeUtcProp = InputFactory.Property("endTimeUtc", InputPrimitiveType.PlainDate, isRequired: false, serializedName: "endTimeUtc");
            var stepModel = InputFactory.Model(
                "Step",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [startTimeUtcProp, endTimeUtcProp]);

            // Create a "properties" property on the parent model referencing the Step model,
            // then apply the @flattenProperty decorator to it.
            var progressProperty = InputFactory.Property("progress", stepModel, isRequired: false, serializedName: "progress");
            ApplyFlattenDecorator(progressProperty);

            // Create the parent model.
            var parentModel = InputFactory.Model(
                "MyProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [progressProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, stepModel]);

            // Create the model providers.
            var parentModelProvider = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.IsNotNull(parentModelProvider);

            var stepModelProvider = plugin.Object.TypeFactory.CreateModel(stepModel);
            Assert.IsNotNull(stepModelProvider);

            // Set up a custom code view on the Step model that has an [Obsolete] property.
            var customCodeView = new ObsoletePropertyCustomCodeView(stepModelProvider!);
            ManagementMockHelpers.SetCustomCodeView(stepModelProvider!, customCodeView);

            // Run all visitors on the parent model.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(visitTypeCore, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [parentModelProvider]);
            }

            // After property flattening, the parent model should have:
            // 1. The original "Progress" property (now internal)
            // 2. Flattened "StartTimeUtc" and "EndTimeUtc" properties (non-obsolete)
            // It should NOT have a flattened "OldPropertyName" (the obsolete property from custom code).

            var flattenedStartTimeUtc = parentModelProvider!.Properties.FirstOrDefault(p => p.Name == "StartTimeUtc");
            Assert.IsNotNull(flattenedStartTimeUtc, "Non-obsolete property 'StartTimeUtc' should be flattened onto the parent model");

            var flattenedEndTimeUtc = parentModelProvider.Properties.FirstOrDefault(p => p.Name == "EndTimeUtc");
            Assert.IsNotNull(flattenedEndTimeUtc, "Non-obsolete property 'EndTimeUtc' should be flattened onto the parent model");

            var flattenedObsolete = parentModelProvider.Properties.FirstOrDefault(p => p.Name == "OldPropertyName");
            Assert.IsNull(flattenedObsolete, "Obsolete property 'OldPropertyName' should NOT be flattened onto the parent model");
        }

        /// <summary>
        /// A mock custom code view TypeProvider that adds an [Obsolete] property
        /// to simulate a backward-compat alias defined in a partial class.
        /// </summary>
        private class ObsoletePropertyCustomCodeView : TypeProvider
        {
            private readonly TypeProvider _enclosingType;

            public ObsoletePropertyCustomCodeView(TypeProvider enclosingType)
            {
                _enclosingType = enclosingType;
            }

            protected override string BuildName() => _enclosingType.Name;
            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override PropertyProvider[] BuildProperties()
            {
                return
                [
                    new PropertyProvider(
                        null,
                        MethodSignatureModifiers.Public,
                        typeof(DateTimeOffset?),
                        "OldPropertyName",
                        new AutoPropertyBody(true),
                        _enclosingType,
                        attributes: [new AttributeStatement(typeof(ObsoleteAttribute), Literal("Use StartTimeUtc instead."))])
                ];
            }
        }
    }
}
