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
            Assert.That(model, Is.Not.Null);

            // Verify the Output-only nested model has no public constructor (precondition).
            var nestedModel = plugin.Object.TypeFactory.CreateModel(propertiesModel);
            Assert.That(nestedModel, Is.Not.Null);
            Assert.That(
                nestedModel!.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)),
                Is.False,
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
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

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
            Assert.That(FlattenPropertyVisitor.IsBackwardCompatMethod(primaryMethod), Is.False);

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
            Assert.That(FlattenPropertyVisitor.IsBackwardCompatMethod(backCompatMethod), Is.True);
        }

        [Test]
        public void TestFlattenedGetterAddsNullGuardForOptionalReadOnlyParent()
        {
            var errorsProperty = InputFactory.Property("errors", InputFactory.Array(InputPrimitiveType.String), isRequired: false, serializedName: "errors");
            var dataModel = InputFactory.Model(
                "AnalysisData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties: [errorsProperty]);

            var dataProperty = InputFactory.Property("data", dataModel, isRequired: false, serializedName: "data");
            ApplyFlattenDecorator(dataProperty);

            var resultModel = InputFactory.Model(
                "AnalysisResult",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties: [dataProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [resultModel, dataModel]);

            var model = plugin.Object.TypeFactory.CreateModel(resultModel);
            Assert.That(model, Is.Not.Null);

            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [model]);
            }

            var rendered = new TypeProviderWriter(model!).Write().Content;
            Assert.That(rendered, Does.Match(@"(?:this\.)?Data is null"));
            Assert.That(rendered, Does.Contain("Data.Errors"));
            Assert.That(rendered, Does.Not.Match(@"\breturn\s+(?:this\.)?Data\.Errors;"));
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
            Assert.That(backCompatMethod.BodyStatements, Is.Not.Null);
            var statements = backCompatMethod.BodyStatements!.ToArray();
            Assert.That(statements.Length, Is.EqualTo(1));

            var returnStatement = statements[0] as ExpressionStatement;
            Assert.That(returnStatement, Is.Not.Null);
            var keywordExpr = returnStatement!.Expression as KeywordExpression;
            Assert.That(keywordExpr, Is.Not.Null);
            var newInvoke = keywordExpr!.Expression as InvokeMethodExpression;
            Assert.That(newInvoke, Is.Not.Null);

            // The arguments should now be in the PRIMARY method's order:
            // (id, name, displayName, provisioningState, etag)
            var args = newInvoke!.Arguments;
            Assert.That(args.Count, Is.EqualTo(5));
            AssertArgIsParameter(args[0], "id", "position 0");
            AssertArgIsParameter(args[1], "name", "position 1");
            AssertArgIsParameter(args[2], "displayName", "position 2");
            AssertArgIsParameter(args[3], "provisioningState", "position 3");
            AssertArgIsParameter(args[4], "etag", "position 4");
        }

        private static void AssertArgIsParameter(ValueExpression arg, string expectedName, string context)
        {
            string? actualName = arg is VariableExpression v ? v.Declaration.RequestedName : null;
            Assert.That(actualName, Is.EqualTo(expectedName), $"Expected parameter '{expectedName}' at {context}, but got '{actualName ?? arg.GetType().Name}'");
        }

        private static void ApplyFlattenDecorator(InputModelProperty property)
        {
            var decorator = new InputDecoratorInfo(
                "Azure.ResourceManager.@flattenProperty",
                new Dictionary<string, BinaryData>());
            var decoratorsProperty = typeof(InputModelProperty).GetProperty(
                nameof(InputModelProperty.Decorators),
                BindingFlags.Public | BindingFlags.Instance);
            Assert.That(decoratorsProperty, Is.Not.Null, "Could not find InputModelProperty.Decorators property");
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
            Assert.That(model, Is.Not.Null);

            // Verify precondition: before visitors run, there IS a public constructor.
            Assert.That(
                model!.Constructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)),
                Is.True,
                "Precondition: model should have a public constructor before visitors run");

            // Run the VisitType visitors (which triggers FlattenPropertyVisitor).
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [model]);
            }

            // After visitors run, the public constructor should still exist (parameterless).
            var publicCtor = model.Constructors.SingleOrDefault(
                c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.That(publicCtor, Is.Not.Null, "Public constructor should be kept (as parameterless) when all flattened properties are optional");
            Assert.That(publicCtor!.Signature.Parameters.Count, Is.EqualTo(0),
                "Public constructor should be parameterless since all flattened properties are optional");

            // The serialization type should NOT have an internal parameterless constructor
            // (it would conflict with the public one in the partial class, causing CS0111).
            foreach (var serializationType in model!.SerializationProviders)
            {
                var serializationParameterlessCtor = serializationType.Constructors
                    .SingleOrDefault(c => !c.Signature.Parameters.Any());
                Assert.That(serializationParameterlessCtor, Is.Null,
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
            Assert.That(model, Is.Not.Null);

            // Run the VisitType visitors.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null);

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [model]);
            }

            // The public constructor should exist with only the required property as parameter.
            var publicCtorMixed = model!.Constructors.SingleOrDefault(
                c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.That(publicCtorMixed, Is.Not.Null, "Public constructor should exist");
            Assert.That(publicCtorMixed!.Signature.Parameters, Has.Count.EqualTo(1),
                "Public constructor should have exactly 1 parameter (the required property)");
            Assert.That(publicCtorMixed.Signature.Parameters[0].Name, Is.EqualTo("name"),
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
            Assert.That(parentModelProvider, Is.Not.Null);

            var discriminatorModelProvider = plugin.Object.TypeFactory.CreateModel(discriminatorBaseModel);
            Assert.That(discriminatorModelProvider, Is.Not.Null);

            // Run all visitors on the parent model.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [parentModelProvider]);
            }

            // The backupPolicy property should NOT have been flattened — it should remain public.
            var backupPolicyProp = parentModelProvider!.Properties.FirstOrDefault(p => p.Name == "BackupPolicy");
            Assert.That(backupPolicyProp, Is.Not.Null, "BackupPolicy property should still exist on the parent model");
            Assert.That(
                backupPolicyProp!.Modifiers.HasFlag(MethodSignatureModifiers.Public),
                Is.True,
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
            Assert.That(parentModelProvider, Is.Not.Null);

            var stepModelProvider = plugin.Object.TypeFactory.CreateModel(stepModel);
            Assert.That(stepModelProvider, Is.Not.Null);

            // Set up a custom code view on the Step model that has an [Obsolete] property.
            var customCodeView = new ObsoletePropertyCustomCodeView(stepModelProvider!);
            ManagementMockHelpers.SetCustomCodeView(stepModelProvider!, customCodeView);

            // Run all visitors on the parent model.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [parentModelProvider]);
            }

            // After flattening, the parent model should have:
            // 1. The original "Progress" property (now internal)
            // 2. A flattened "StartTimeUtc" property (from the non-obsolete property)
            // It should NOT have a flattened "OldPropertyName" (the obsolete property from custom code).

            var flattenedStartTimeUtc = parentModelProvider!.Properties.FirstOrDefault(p => p.Name == "StartTimeUtc");
            Assert.That(flattenedStartTimeUtc, Is.Not.Null, "Non-obsolete property 'StartTimeUtc' should be flattened onto the parent model");

            var flattenedObsolete = parentModelProvider.Properties.FirstOrDefault(p => p.Name == "OldPropertyName");
            Assert.That(flattenedObsolete, Is.Null, "Obsolete property 'OldPropertyName' should NOT be flattened onto the parent model");
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
            Assert.That(parentModelProvider, Is.Not.Null);

            var stepModelProvider = plugin.Object.TypeFactory.CreateModel(stepModel);
            Assert.That(stepModelProvider, Is.Not.Null);

            // Set up a custom code view on the Step model that has an [Obsolete] property.
            var customCodeView = new ObsoletePropertyCustomCodeView(stepModelProvider!);
            ManagementMockHelpers.SetCustomCodeView(stepModelProvider!, customCodeView);

            // Run all visitors on the parent model.
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [parentModelProvider]);
            }

            // After property flattening, the parent model should have:
            // 1. The original "Progress" property (now internal)
            // 2. Flattened "StartTimeUtc" and "EndTimeUtc" properties (non-obsolete)
            // It should NOT have a flattened "OldPropertyName" (the obsolete property from custom code).

            var flattenedStartTimeUtc = parentModelProvider!.Properties.FirstOrDefault(p => p.Name == "StartTimeUtc");
            Assert.That(flattenedStartTimeUtc, Is.Not.Null, "Non-obsolete property 'StartTimeUtc' should be flattened onto the parent model");

            var flattenedEndTimeUtc = parentModelProvider.Properties.FirstOrDefault(p => p.Name == "EndTimeUtc");
            Assert.That(flattenedEndTimeUtc, Is.Not.Null, "Non-obsolete property 'EndTimeUtc' should be flattened onto the parent model");

            var flattenedObsolete = parentModelProvider.Properties.FirstOrDefault(p => p.Name == "OldPropertyName");
            Assert.That(flattenedObsolete, Is.Null, "Obsolete property 'OldPropertyName' should NOT be flattened onto the parent model");
        }

        /// <summary>
        /// Verifies the bug fix: when a base model is safe-flattened (a single-property wrapper type
        /// becomes internal and its property is promoted), the derived class's public constructor
        /// parameters AND base initializer (: base(...)) are both updated to use the flattened type.
        ///
        /// Scenario (mirrors CommonExportProperties / ExportProperties):
        ///   - WrapperModel has one required public property: Value (string)
        ///   - BaseModel has: wrapper (WrapperModel, required), name (string, required)
        ///   - DerivedModel extends BaseModel with: description (string, optional)
        ///
        /// After safe-flatten:
        ///   - BaseModel.wrapper becomes internal, WrapperValue (string) is promoted
        ///   - BaseModel public ctor: (string wrapperValue, string name)
        ///   - DerivedModel public ctor must also use (string wrapperValue, string name), NOT (WrapperModel wrapper, string name)
        ///   - DerivedModel base initializer must pass wrapperValue, not wrapper
        /// </summary>
        [Test]
        public void TestSafeFlattenUpdatesDerivedClassCtorParamsAndBaseInitializer()
        {
            // Create WrapperModel with a single required property.
            var valueProp = InputFactory.Property("value", InputPrimitiveType.String, isRequired: true, serializedName: "value");
            var wrapperModel = InputFactory.Model(
                "WrapperModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [valueProp]);

            // Create BaseModel with wrapper (WrapperModel, required) + name (string, required).
            var wrapperProp = InputFactory.Property("wrapper", wrapperModel, isRequired: true, serializedName: "wrapper");
            var nameProp = InputFactory.Property("name", InputPrimitiveType.String, isRequired: true, serializedName: "name");
            var baseModel = InputFactory.Model(
                "BaseModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [wrapperProp, nameProp]);

            // Create DerivedModel extending BaseModel with an optional description.
            var descriptionProp = InputFactory.Property("description", InputPrimitiveType.String, isRequired: false, serializedName: "description");
            var derivedModel = InputFactory.Model(
                "DerivedModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                baseModel: baseModel,
                properties: [descriptionProp]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [wrapperModel, baseModel, derivedModel]);

            var baseModelProvider = plugin.Object.TypeFactory.CreateModel(baseModel)!;
            var derivedModelProvider = plugin.Object.TypeFactory.CreateModel(derivedModel)!;
            Assert.That(baseModelProvider, Is.Not.Null);
            Assert.That(derivedModelProvider, Is.Not.Null);

            // Precondition: before visitors, DerivedModel public ctor has WrapperModel param.
            var preVisitPublicCtor = derivedModelProvider.Constructors
                .SingleOrDefault(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.That(preVisitPublicCtor, Is.Not.Null, "DerivedModel should have a public ctor before visitors");
            Assert.That(
                preVisitPublicCtor!.Signature.Parameters.Any(p => p.Type.Name == "WrapperModel"),
                Is.True,
                "Precondition: DerivedModel ctor should have WrapperModel param before flatten");

            // Run only the FlattenPropertyVisitor on both models (base must be processed first to populate the flatten map).
            var visitor = new FlattenPropertyVisitor();
            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null);

            visitTypeCore!.Invoke(visitor, [derivedModelProvider]);
            visitTypeCore!.Invoke(visitor, [baseModelProvider]);

            // After visitors: DerivedModel public ctor should use the flattened type (string), not WrapperModel.
            var publicCtor = derivedModelProvider.Constructors
                .SingleOrDefault(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.That(publicCtor, Is.Not.Null, "DerivedModel should still have a public ctor after flatten");

            Assert.That(
                publicCtor!.Signature.Parameters.Any(p => p.Type.Name == "WrapperModel"),
                Is.False,
                "DerivedModel public ctor should NOT have WrapperModel param after safe-flatten");
            Assert.That(
                publicCtor.Signature.Parameters.Any(p => p.Name == "wrapperValue"),
                Is.True,
                "DerivedModel public ctor should have the flattened 'wrapperValue' (string) param");

            // The base initializer must exist and be a base (not this) call.
            var initializer = publicCtor.Signature.Initializer;
            Assert.That(initializer, Is.Not.Null, "DerivedModel public ctor should have a base initializer");
            Assert.That(initializer!.IsBase, Is.True, "Initializer should be a base call");

            // None of the base initializer arguments should reference the old WrapperModel param.
            var initializerArgNames = initializer.Arguments
                .OfType<VariableExpression>()
                .Select(v => v.Declaration.RequestedName)
                .ToList();

            Assert.That(
                initializerArgNames.Contains("wrapper"),
                Is.False,
                $"Base initializer should NOT pass 'wrapper' (WrapperModel). Args: [{string.Join(", ", initializerArgNames)}]");
            Assert.That(
                initializerArgNames.Contains("wrapperValue"),
                Is.True,
                $"Base initializer should pass the flattened 'wrapperValue'. Args: [{string.Join(", ", initializerArgNames)}]");
        }

        /// <summary>
        /// Verifies that <see cref="FlattenPropertyVisitor.FilterAttributesForFlatten"/> drops any
        /// WirePath attribute attached to the inner property while preserving other attributes.
        /// When a property is flattened, its wire path changes (e.g., "left" -> "properties.left"),
        /// so any WirePath attribute copied from the inner property is stale and must be omitted;
        /// WirePathVisitor will later emit the correct combined wire-path attribute on the
        /// flattened property.
        /// </summary>
        [Test]
        public void TestFilterAttributesForFlattenDropsWirePath()
        {
            // LoadMockPlugin is required so ManagementClientGenerator.Instance is initialized,
            // which in turn is needed to resolve WirePathAttributeType inside the visitor.
            var dummyModel = InputFactory.Model(
                "Dummy",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("name", InputPrimitiveType.String, serializedName: "name")]);
            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [dummyModel]);

            var wirePathType = ManagementClientGenerator.Instance.OutputLibrary.WirePathAttributeDefinition.Type;

            var wirePathAttribute = new AttributeStatement(wirePathType, Literal("left"));
            var obsoleteAttribute = new AttributeStatement(typeof(ObsoleteAttribute), Literal("use something else"));

            var filtered = FlattenPropertyVisitor.FilterAttributesForFlatten([wirePathAttribute, obsoleteAttribute]);

            Assert.That(filtered.Count, Is.EqualTo(1), "WirePath attribute should be filtered out");
            Assert.That(filtered[0], Is.SameAs(obsoleteAttribute), "Non-WirePath attributes should be preserved");
            Assert.That(
                filtered.Any(a => FlattenPropertyVisitor.IsWirePathAttribute(a, wirePathType)),
                Is.False,
                "Filtered list should contain no WirePath attribute");
        }

        /// <summary>
        /// Verifies the fix for https://github.com/microsoft/typespec/issues/7380.
        ///
        /// When SafeFlatten chains across 3+ levels of single-property models the immediate
        /// `innerProperty` on a parent is itself a <see cref="FlattenedPropertyProvider"/>.
        /// Previously the generator emitted `internalProperty = new InnerModel(value)` for the
        /// flattened setter, but the value's type does not match any constructor on InnerModel
        /// (its only ctor takes the deeper inner model). The fix detects the chained case and
        /// emits the safe `if (internal == null) internal = new InnerModel(); internal.X = value;`
        /// pattern instead, delegating through the inner flattened setter.
        /// </summary>
        [Test]
        public void TestSafeFlattenChainedThreeLevelsEmitsSafeSetter()
        {
            // Level 3: leaf model with a single required string property.
            var valueProp = InputFactory.Property("value", InputPrimitiveType.String, isRequired: true, serializedName: "value");
            var levelThreeModel = InputFactory.Model(
                "LevelThreeModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [valueProp]);

            // Level 2: single required property of LevelThreeModel — triggers SafeFlatten.
            // Required ensures LevelTwoModel has no public parameterless constructor.
            var levelThreeProp = InputFactory.Property("levelThree", levelThreeModel, isRequired: true, serializedName: "levelThree");
            var levelTwoModel = InputFactory.Model(
                "LevelTwoModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [levelThreeProp]);

            // Level 1: single required property of LevelTwoModel — triggers SafeFlatten again.
            // After Level 2 is flattened, its single public property is itself a
            // FlattenedPropertyProvider (Value), so flattening Level 1 hits the chained case.
            var levelTwoProp = InputFactory.Property("levelTwo", levelTwoModel, isRequired: true, serializedName: "levelTwo");
            var levelOneModel = InputFactory.Model(
                "LevelOneModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [levelTwoProp]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [levelOneModel, levelTwoModel, levelThreeModel]);

            var levelOne = plugin.Object.TypeFactory.CreateModel(levelOneModel);
            var levelTwo = plugin.Object.TypeFactory.CreateModel(levelTwoModel);
            var levelThree = plugin.Object.TypeFactory.CreateModel(levelThreeModel);
            Assert.That(levelOne, Is.Not.Null);
            Assert.That(levelTwo, Is.Not.Null);
            Assert.That(levelThree, Is.Not.Null);

            // Precondition: LevelTwoModel has no public parameterless ctor (required prop).
            Assert.That(
                levelTwo!.Constructors.Any(c =>
                    c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    !c.Signature.Parameters.Any()),
                Is.False,
                "Precondition: LevelTwoModel should have no public parameterless constructor");

            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null);

            // Visit child models first so SafeFlatten on LevelOneModel sees the already-flattened
            // FlattenedPropertyProvider as the inner property.
            foreach (var model in new[] { levelThree, levelTwo, levelOne })
            {
                foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
                {
                    visitTypeCore!.Invoke(visitor, [model!]);
                }
            }

            var rendered = new TypeProviderWriter(levelOne!).Write().Content;

            // The buggy form would be: `LevelTwo = new LevelTwoModel(value);` — which doesn't
            // compile because LevelTwoModel only has a (LevelThreeModel) constructor.
            Assert.That(
                rendered,
                Does.Not.Match(@"LevelTwo\s*=\s*new\s+[\w\.:]*LevelTwoModel\s*\(\s*value\s*\)"),
                "Chained safe-flatten setter must not call a non-existent `new LevelTwoModel(value)` constructor");

            // The fixed form delegates through the flattened inner setter, with a parameterless
            // construction of the intermediate model.
            Assert.That(
                rendered,
                Does.Match(@"LevelTwo\s*=\s*new\s+[\w\.:]*LevelTwoModel\s*\(\s*\)"),
                "Chained safe-flatten setter should construct the intermediate model with the parameterless ctor");
            Assert.That(
                rendered,
                Does.Match(@"LevelTwo\.LevelThreeValue\s*=\s*value"),
                "Chained safe-flatten setter should delegate assignment through the inner flattened property");
        }

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

        /// <summary>
        /// Verifies that when a required value-type inner property is flattened from an optional
        /// "properties?:" parent, the generated flattened property is wrapped in Nullable&lt;T&gt;.
        /// Regression test for issue #58288: the public getter returns the inner value unguarded,
        /// but the backing "Properties" reference can be null at runtime (e.g. output-only models
        /// deserialized without a properties bag). Exposing it as non-nullable masks the NRE risk
        /// and diverges from the corresponding ModelFactory parameter shape.
        /// </summary>
        [Test]
        public void TestFlattenMakesRequiredValueTypeNullable()
        {
            var requiredIntProp = InputFactory.Property("count", InputPrimitiveType.Int32, isRequired: true, serializedName: "count");
            var propertiesModel = InputFactory.Model(
                "TestValueTypeProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [requiredIntProp]);

            var propertiesProperty = InputFactory.Property("properties", propertiesModel, isRequired: false, serializedName: "properties");
            ApplyFlattenDecorator(propertiesProperty);

            var parentModel = InputFactory.Model(
                "TestResourceWithValueType",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [propertiesProperty]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel, propertiesModel]);

            var model = plugin.Object.TypeFactory.CreateModel(parentModel);
            Assert.That(model, Is.Not.Null);

            var visitTypeCore = typeof(LibraryVisitor).GetMethod(
                "VisitTypeCore",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitTypeCore, Is.Not.Null, "Could not find LibraryVisitor.VisitTypeCore method");

            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visitTypeCore!.Invoke(visitor, [model]);
            }

            var flattened = model!.Properties.SingleOrDefault(p => p.Name == "Count");
            Assert.That(flattened, Is.Not.Null, "Expected flattened 'Count' property on parent model");
            Assert.That(flattened!.Type.IsNullable, Is.True,
                "Required value-type property flattened from an optional parent should be exposed as Nullable<T>");
        }
    }
}
