// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Extensions.Plugin.Common;
using Test.Extensions.Plugin.TestHelpers;

namespace Test.Extensions.Plugin.Visitors
{
    public class ExperimentalAttributeVisitorTests
    {
        private const string DiagnosticId = "AAIP001";

        // Mirrors the decorator emitted by the TypeSpec pipeline to flag an experimental type/member.
        private static InputDecoratorInfo ExperimentalDecorator() => new(
            "TypeSpec.OpenAPI.@extension",
            new Dictionary<string, BinaryData> { ["key"] = BinaryData.FromString("x-ms-foundry-meta") });

        /// <summary>
        /// A discriminated base whose deserializer dispatches to an experimental derived subtype must
        /// suppress AAIP001 inline on its generated serialization code.
        /// </summary>
        [Test]
        public void SuppressesExperimentalOnDiscriminatedBaseSerialization()
        {
            var visitor = new TestExperimentalAttributeVisitor();

            var discriminatorProperty = InputFactory.Property("kind", InputPrimitiveType.String, isRequired: true, isDiscriminator: true);
            var derivedModel = InputFactory.Model(
                "PreviewTool",
                properties: [InputFactory.Property("previewSetting", InputPrimitiveType.String)],
                discriminatedKind: "preview",
                decorators: [ExperimentalDecorator()]);
            var baseModel = InputFactory.Model(
                "ToolBase",
                properties: [discriminatorProperty],
                derivedModels: [derivedModel],
                discriminatedModels: new Dictionary<string, InputModelType> { { "preview", derivedModel } });

            MockHelpers.LoadMockGenerator(inputModels: () => [baseModel, derivedModel]);

            var baseProvider = ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(baseModel);
            Assert.That(baseProvider, Is.Not.Null);

            // Populate the visitor's experimental registry for all types before visiting.
            visitor.InvokePreVisitModel(baseModel, baseProvider!);
            foreach (var derived in baseProvider!.DerivedModels)
            {
                visitor.InvokePreVisitModel(derivedModel, derived);
            }

            visitor.InvokeVisitType(baseProvider);

            var serializationProvider = baseProvider.SerializationProviders.Single();
            var deserializeMethod = serializationProvider.Methods
                .First(m => m.Signature.Name.StartsWith("Deserialize", StringComparison.Ordinal));
            Assert.That(HasExperimentalSuppression(deserializeMethod.Suppressions), Is.True, "The discriminated base deserializer should suppress AAIP001 because it references experimental subtypes.");

            // Validate the full generated serialization file against the expected TestData baseline,
            // ensuring the inline #pragma warning disable/restore AAIP001 directives are emitted with
            // the per-type justification.
            var file = new TypeProviderWriter(serializationProvider).Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        /// <summary>
        /// A non-experimental model that exposes an experimental property must suppress AAIP001 inline
        /// on its generated serialization code and on its own full deserialization constructor.
        /// </summary>
        [Test]
        public void SuppressesExperimentalOnModelWithExperimentalProperty()
        {
            var visitor = new TestExperimentalAttributeVisitor();

            var experimentalModel = InputFactory.Model(
                "PreviewOptions",
                properties: [InputFactory.Property("previewSetting", InputPrimitiveType.String)],
                decorators: [ExperimentalDecorator()]);
            var containerModel = InputFactory.Model(
                "CreationOptions",
                properties:
                [
                    InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                    InputFactory.Property("draft", experimentalModel),
                ]);

            MockHelpers.LoadMockGenerator(inputModels: () => [containerModel, experimentalModel]);

            var experimentalProvider = ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(experimentalModel);
            var containerProvider = ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(containerModel);
            Assert.That(containerProvider, Is.Not.Null);

            visitor.InvokePreVisitModel(experimentalModel, experimentalProvider!);
            visitor.InvokePreVisitModel(containerModel, containerProvider!);

            visitor.InvokeVisitType(containerProvider!);

            var serializationProvider = containerProvider!.SerializationProviders.Single();
            Assert.That(serializationProvider.Methods.All(m => HasExperimentalSuppression(m.Suppressions)), Is.True, "All serialization methods should suppress AAIP001 when the model has an experimental property.");
            Assert.That(serializationProvider.Constructors.All(c => HasExperimentalSuppression(c.Suppressions)), Is.True, "All serialization constructors should suppress AAIP001 when the model has an experimental property.");
            Assert.That(containerProvider.Constructors.Any(c => HasExperimentalSuppression(c.Suppressions)), Is.True, "The model's own full deserialization constructor should suppress AAIP001.");

            // Validate the full generated serialization file against the expected TestData baseline,
            // ensuring the inline #pragma warning disable/restore AAIP001 directives are emitted with
            // the per-type justification.
            var file = new TypeProviderWriter(serializationProvider).Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        /// <summary>
        /// A model without any experimental members or experimental derived types must not receive any
        /// inline AAIP001 suppression.
        /// </summary>
        [Test]
        public void DoesNotSuppressWhenNoExperimentalMembers()
        {
            var visitor = new TestExperimentalAttributeVisitor();

            var model = InputFactory.Model(
                "PlainOptions",
                properties: [InputFactory.Property("name", InputPrimitiveType.String, isRequired: true)]);

            MockHelpers.LoadMockGenerator(inputModels: () => [model]);

            var provider = ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(model);
            Assert.That(provider, Is.Not.Null);

            visitor.InvokePreVisitModel(model, provider!);
            visitor.InvokeVisitType(provider!);

            var serializationProvider = provider!.SerializationProviders.Single();
            Assert.That(serializationProvider.Methods.Any(m => HasExperimentalSuppression(m.Suppressions)), Is.False, "Serialization methods should not be suppressed when there are no experimental members.");
            Assert.That(serializationProvider.Constructors.Any(c => HasExperimentalSuppression(c.Suppressions)), Is.False, "Serialization constructors should not be suppressed when there are no experimental members.");
            Assert.That(provider.Constructors.Any(c => HasExperimentalSuppression(c.Suppressions)), Is.False, "Model constructors should not be suppressed when there are no experimental members.");
        }

        /// <summary>
        /// Visiting the same model twice must not add duplicate AAIP001 suppressions.
        /// </summary>
        [Test]
        public void DoesNotAddDuplicateSuppressions()
        {
            var visitor = new TestExperimentalAttributeVisitor();

            var experimentalModel = InputFactory.Model(
                "PreviewOptions",
                properties: [InputFactory.Property("previewSetting", InputPrimitiveType.String)],
                decorators: [ExperimentalDecorator()]);
            var containerModel = InputFactory.Model(
                "CreationOptions",
                properties:
                [
                    InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                    InputFactory.Property("draft", experimentalModel),
                ]);

            MockHelpers.LoadMockGenerator(inputModels: () => [containerModel, experimentalModel]);

            var experimentalProvider = ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(experimentalModel);
            var containerProvider = ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(containerModel);

            visitor.InvokePreVisitModel(experimentalModel, experimentalProvider!);
            visitor.InvokePreVisitModel(containerModel, containerProvider!);

            visitor.InvokeVisitType(containerProvider!);
            visitor.InvokeVisitType(containerProvider!);

            var serializationProvider = containerProvider!.SerializationProviders.Single();
            foreach (var method in serializationProvider.Methods)
            {
                Assert.That(CountExperimentalSuppressions(method.Suppressions), Is.LessThanOrEqualTo(1), $"Method {method.Signature.Name} should have at most one AAIP001 suppression.");
            }
        }

        private static bool HasExperimentalSuppression(IEnumerable<SuppressionStatement> suppressions) =>
            CountExperimentalSuppressions(suppressions) > 0;

        private static int CountExperimentalSuppressions(IEnumerable<SuppressionStatement> suppressions) =>
            suppressions.Count(suppression =>
                suppression.Code is ScopedApi { Original: LiteralExpression { Literal: string code } } && code == DiagnosticId);

        private class TestExperimentalAttributeVisitor : ExperimentalAttributeVisitor
        {
            public ModelProvider InvokePreVisitModel(InputModelType inputType, ModelProvider type)
            {
                return base.PreVisitModel(inputType, type);
            }

            public TypeProvider InvokeVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }
        }
    }
}
