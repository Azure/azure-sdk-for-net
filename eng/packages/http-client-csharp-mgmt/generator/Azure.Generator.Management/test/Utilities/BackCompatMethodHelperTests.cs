// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System.ComponentModel;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    internal class BackCompatMethodHelperTests
    {
        private const string ForwardsClientCallsAttributeName = "ForwardsClientCallsAttribute";

        [SetUp]
        public void SetUp()
        {
            // Ensure ManagementClientGenerator.Instance is initialized so providers can be rendered.
            var model = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model]);
        }

        [TestCase("ifMatch")]
        [TestCase("ifNoneMatch")]
        public void AddsStringOverloadForConditionalETagParameter(string parameterName)
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider(parameterName, $"The condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider(parameterName, $"The condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile(parameterName)));
        }

        [Test]
        public void AddsStringOverloadWhenReturnTypeHashesDiffer()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default)],
                returnType: typeof(object));
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider(
                        "ifMatch",
                        $"The condition.",
                        new CSharpType(typeof(string), isNullable: true),
                        defaultValue: Default,
                        inputParameter: InputFactory.MethodParameter("ifMatch", InputPrimitiveType.String))
                ],
                returnType: typeof(object));

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void PreservesDefaultsAfterFirstConditionalETagParameter()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifNoneMatch", $"The non-match condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", typeof(string), defaultValue: Default),
                    new ParameterProvider("ifNoneMatch", $"The non-match condition.", typeof(string), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            Assert.That(result[1].Signature.Parameters[0].DefaultValue, Is.Null);
            Assert.That(result[1].Signature.Parameters[1].DefaultValue, Is.Not.Null);

            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsStringOverloadForMatchConditionsParameter()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("matchConditions", $"The match conditions.", new CSharpType(typeof(MatchConditions), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifNoneMatch", $"The non-match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsETagOverloadForMatchConditionsParameter()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("matchConditions", $"The match conditions.", new CSharpType(typeof(MatchConditions), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsStringOverloadForRequestConditionsParameter()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("requestConditions", $"The request conditions.", new CSharpType(typeof(RequestConditions), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifNoneMatch", $"The non-match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifModifiedSince", $"The modification condition.", new CSharpType(typeof(DateTimeOffset), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifUnmodifiedSince", $"The unmodified condition.", new CSharpType(typeof(DateTimeOffset), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsModificationConditionOverloadForRequestConditionsParameter()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("requestConditions", $"The request conditions.", new CSharpType(typeof(RequestConditions), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifModifiedSince", $"The modification condition.", new CSharpType(typeof(DateTimeOffset), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsStringOverloadWhenMatchConditionHeaderAdded()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("matchConditions", $"The match conditions.", new CSharpType(typeof(MatchConditions), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsStringOverloadWhenModificationConditionHeaderAdded()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("requestConditions", $"The request conditions.", new CSharpType(typeof(RequestConditions), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifNoneMatch", $"The non-match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void PreservesOptionalDefaultWhenCurrentETagIsRequired()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(ETag), isNullable: true)),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotAddStringOverloadForRequiredNonNullableETagParameter()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(ETag)))]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default)]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotDuplicateBaseGeneratedETagCompatibilityOverload()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default)]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", typeof(string))]);
            var baseGenerated = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", typeof(string))]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current, baseGenerated], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotDuplicateCustomETagCompatibilityOverload()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default)]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", typeof(string))]);
            var customCodeView = new TestTypeView(enclosingType.Name);
            var customMethod = CreateMethod(
                customCodeView,
                [new ParameterProvider("ifMatch", $"The match condition.", typeof(string))]);
            customCodeView.MethodsToBuild = [customMethod];
            ManagementMockHelpers.SetCustomCodeView(enclosingType, customCodeView);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [TestCase("etag")]
        [TestCase("condition")]
        public void DoesNotAddStringOverloadForNonConditionalETagParameter(string parameterName)
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider(parameterName, $"The value.", new CSharpType(typeof(ETag), isNullable: true))]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider(parameterName, $"The value.", typeof(string))]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile(parameterName)));
        }

        [Test]
        public void DoesNotAddStringOverloadWhenAnotherParameterNameChanged()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("renamedName", $"The name.", typeof(string)),
                    new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(ETag), isNullable: true))
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    new ParameterProvider("ifMatch", $"The condition.", typeof(string))
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotAddStringOverloadWhenConditionalParameterTypeDiffers()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(BinaryData), isNullable: true))]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(string), isNullable: true))]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotAddStringOverloadWhenNonConditionalParameterNullabilityDiffers()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("count", $"The count.", new CSharpType(typeof(int))),
                    new ParameterProvider("matchConditions", $"The match conditions.", new CSharpType(typeof(MatchConditions), isNullable: true), defaultValue: Default)
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("count", $"The count.", new CSharpType(typeof(int), isNullable: true), defaultValue: Default),
                    new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default)
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotAddStringOverloadWhenReturnTypeDiffers()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default)]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default)],
                returnType: typeof(object));

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotDuplicateEditorBrowsableAttributeOnGeneratedOverload()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(ETag), isNullable: true), defaultValue: Default)]);
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default)],
                attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void RequiredRequestConditionValueDoesNotUseNullShortcut()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("requestConditions", $"The request conditions.", new CSharpType(typeof(RequestConditions), isNullable: true)),
                    OptionalCancellationToken()
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("ifModifiedSince", $"The modification condition.", new CSharpType(typeof(DateTimeOffset))),
                    new ParameterProvider("ifMatch", $"The match condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default),
                    OptionalCancellationToken()
                ]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([current], [current]);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void AddsForwardsClientCallsToSynthesizedOverload()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    RequiredCancellationToken()
                ]);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(HasForwardsClientCalls(synthesized), Is.True);
        }

        [Test]
        public void DoesNotDecorateOriginalMethods()
        {
            var enclosingType = new TestTypeView("TestClient");
            var original = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    RequiredCancellationToken()
                ]);

            BackCompatHelper.DecorateBackwardCompatibilityMethods([original], originalMethods: [original]);

            Assert.That(HasForwardsClientCalls(original), Is.False);
            Assert.That(original.Suppressions, Is.Empty);
        }

        [Test]
        public void AddsAzc0002SuppressionWhenTrailingRequiredCancellationToken()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    RequiredCancellationToken()
                ]);

            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            Assert.That(synthesized.Suppressions, Has.Count.EqualTo(1));

            var rendered = Render(WithMethods(enclosingType, synthesized));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void DoesNotAddAzc0002SuppressionWhenTrailingCancellationTokenIsOptional()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    OptionalCancellationToken()
                ]);

            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            // The overload still forwards client calls, but AZC0002 does not fire for an optional CancellationToken.
            Assert.That(HasForwardsClientCalls(synthesized), Is.True);
            Assert.That(synthesized.Suppressions, Is.Empty);
        }

        [Test]
        public void DoesNotAddAzc0002SuppressionWhenTrailingParameterIsNotCancellationToken()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(
                enclosingType,
                [
                    RequiredCancellationToken(),
                    new ParameterProvider("name", $"The name.", typeof(string))
                ]);

            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            Assert.That(HasForwardsClientCalls(synthesized), Is.True);
            Assert.That(synthesized.Suppressions, Is.Empty);
        }

        [Test]
        public void DoesNotAddAzc0002SuppressionWhenMethodHasNoParameters()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(enclosingType, []);

            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            Assert.That(HasForwardsClientCalls(synthesized), Is.True);
            Assert.That(synthesized.Suppressions, Is.Empty);
        }

        [Test]
        public void DoesNotDuplicateForwardsClientCallsAttribute()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(
                enclosingType,
                [new ParameterProvider("name", $"The name.", typeof(string))]);

            // Applying the decorations more than once must remain idempotent and not stack duplicate attributes.
            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);
            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            Assert.That(
                synthesized.Signature.Attributes.Count(a => a.Type.Name == ForwardsClientCallsAttributeName),
                Is.EqualTo(1));
        }

        [Test]
        public void DoesNotDuplicateAzc0002Suppression()
        {
            var enclosingType = new TestTypeView("TestClient");
            var synthesized = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    RequiredCancellationToken()
                ]);

            // Applying the decorations more than once must remain idempotent and not stack duplicate suppressions.
            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);
            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            Assert.That(synthesized.Suppressions, Has.Count.EqualTo(1));
        }

        [Test]
        public void PreservesMethodBodyWhenDecorating()
        {
            var enclosingType = new TestTypeView("TestClient");
            var signature = new MethodSignature(
                "Get",
                $"Gets something.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                typeof(string),
                $"The result.",
                [new ParameterProvider("name", $"The name.", typeof(string)), RequiredCancellationToken()]);
            var synthesized = new MethodProvider(signature, Return(Literal("value")), enclosingType);

            BackCompatHelper.DecorateBackwardCompatibilityMethods([synthesized], originalMethods: []);

            var rendered = Render(WithMethods(enclosingType, synthesized));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void HandlesEmptyBackCompatMethods()
        {
            var enclosingType = new TestTypeView("TestClient");
            var previous = CreateMethod(
                enclosingType,
                [new ParameterProvider("ifMatch", $"The match condition.", typeof(string), defaultValue: Default)]);

            var lastContractView = new TestTypeView(enclosingType.Name)
            {
                MethodsToBuild = [previous]
            };
            ModelTestHelper.SetLastContractView(enclosingType, lastContractView);

            var result = BackCompatHelper.DecorateBackwardCompatibilityMethods([], []);
            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void EndsWithRequiredCancellationTokenDistinguishesOptionalAndRequired()
        {
            var enclosingType = new TestTypeView("TestClient");
            var requiredSignature = CreateMethod(enclosingType, [RequiredCancellationToken()]).Signature;
            var optionalSignature = CreateMethod(enclosingType, [OptionalCancellationToken()]).Signature;
            var noParamsSignature = CreateMethod(enclosingType, []).Signature;

            Assert.That(BackCompatHelper.EndsWithRequiredCancellationToken(requiredSignature), Is.True);
            Assert.That(BackCompatHelper.EndsWithRequiredCancellationToken(optionalSignature), Is.False);
            Assert.That(BackCompatHelper.EndsWithRequiredCancellationToken(noParamsSignature), Is.False);
        }

        private static MethodProvider CreateMethod(
            TypeProvider enclosingType,
            IReadOnlyList<ParameterProvider> parameters,
            CSharpType? returnType = null,
            IReadOnlyList<AttributeStatement>? attributes = null)
        {
            var signature = new MethodSignature(
                "Get",
                $"Gets something.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                returnType ?? typeof(string),
                $"The result.",
                parameters,
                Attributes: attributes ?? []);
            return new MethodProvider(signature, Return(Literal("value")), enclosingType);
        }

        private static ParameterProvider RequiredCancellationToken()
            => new("cancellationToken", $"The cancellation token to use.", new CSharpType(typeof(CancellationToken)));

        private static ParameterProvider OptionalCancellationToken()
            => new("cancellationToken", $"The cancellation token to use.", new CSharpType(typeof(CancellationToken)), defaultValue: Default);

        private static bool HasForwardsClientCalls(MethodProvider method)
            => method.Signature.Attributes.Any(a => a.Type.Name == ForwardsClientCallsAttributeName);

        private static string Render(TypeProvider typeProvider)
            => new TypeProviderWriter(typeProvider).Write().Content.Replace("\r\n", "\n");

        private static TestTypeView WithMethods(TestTypeView typeView, params MethodProvider[] methods)
        {
            typeView.MethodsToBuild = methods;
            return typeView;
        }

        private class TestTypeView : TypeProvider
        {
            private readonly string _name;

            public TestTypeView(string name)
            {
                _name = name;
            }

            public MethodProvider[] MethodsToBuild { get; set; } = [];

            protected override string BuildName() => _name;

            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override MethodProvider[] BuildMethods() => MethodsToBuild;
        }
    }
}
