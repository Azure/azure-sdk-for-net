// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
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
            var previousParameter = new ParameterProvider(parameterName, $"The condition.", new CSharpType(typeof(string), isNullable: true), defaultValue: Default);
            var previous = CreateMethod(enclosingType, [previousParameter, OptionalCancellationToken()]);

            var result = BackCompatHelper.AddETagBackwardCompatibilityMethods(enclosingType, [current], [previous]);
            BackCompatHelper.DecorateBackwardCompatibilityMethods(result, [current]);

            Assert.That(result, Has.Count.EqualTo(2));
            var overload = result.Single(method => !ReferenceEquals(method, current));
            Assert.That(overload.Signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(overload.Signature.Parameters[0].DefaultValue, Is.Null);
            Assert.That(overload.Signature.Parameters[1].DefaultValue, Is.Not.Null);
            Assert.That(previousParameter.DefaultValue, Is.Not.Null);
            Assert.That(HasForwardsClientCalls(overload), Is.True);

            var rendered = Render(WithMethods(enclosingType, result.ToArray()));
            Assert.That(rendered, Does.Contain($"Get(string {parameterName}, global::System.Threading.CancellationToken cancellationToken = default)"));
            Assert.That(rendered, Does.Contain($"return this.Get(({parameterName} != null) ? new global::Azure.ETag({parameterName}) : ((global::Azure.ETag?)null), cancellationToken);"));
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

            var result = BackCompatHelper.AddETagBackwardCompatibilityMethods(enclosingType, [current], [previous]);

            var overload = result.Single(method => !ReferenceEquals(method, current));
            Assert.That(overload.Signature.Parameters[0].DefaultValue, Is.Null);
            Assert.That(overload.Signature.Parameters[1].DefaultValue, Is.Not.Null);
            Assert.That(overload.Signature.Parameters[2].DefaultValue, Is.Not.Null);
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

            var result = BackCompatHelper.AddETagBackwardCompatibilityMethods(enclosingType, [current], [previous]);

            Assert.That(result, Is.EqualTo(new[] { current }));
        }

        [Test]
        public void DoesNotAddStringOverloadWhenAnotherParameterTypeChanged()
        {
            var enclosingType = new TestTypeView("TestClient");
            var current = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(int)),
                    new ParameterProvider("ifMatch", $"The condition.", new CSharpType(typeof(ETag), isNullable: true))
                ]);
            var previous = CreateMethod(
                enclosingType,
                [
                    new ParameterProvider("name", $"The name.", typeof(string)),
                    new ParameterProvider("ifMatch", $"The condition.", typeof(string))
                ]);

            var result = BackCompatHelper.AddETagBackwardCompatibilityMethods(enclosingType, [current], [previous]);

            Assert.That(result, Is.EqualTo(new[] { current }));
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

        private static MethodProvider CreateMethod(TypeProvider enclosingType, IReadOnlyList<ParameterProvider> parameters)
        {
            var signature = new MethodSignature(
                "Get",
                $"Gets something.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                typeof(string),
                $"The result.",
                parameters);
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
