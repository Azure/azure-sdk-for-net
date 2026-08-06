// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator;
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
        /// suppress AAIP001 inline, at the tightest possible scope, on its generated serialization code.
        /// </summary>
        [Test]
        public void SuppressesExperimentalOnDiscriminatedBaseSerialization()
        {
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

            var serializationProvider = VisitAndGetSerialization("ToolBase", baseModel, derivedModel);

            // Validate the entire generated serialization type against the expected TestData baseline,
            // ensuring the inline #pragma warning disable/restore AAIP001 directives are emitted around
            // only the statement that dispatches to the experimental subtype.
            var file = new TypeProviderWriter(serializationProvider).Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        /// <summary>
        /// A non-experimental model that exposes an experimental property must suppress AAIP001 inline,
        /// at the tightest possible scope, around only the individual serialization statements that
        /// reference the experimental member.
        /// </summary>
        [Test]
        public void SuppressesExperimentalOnModelWithExperimentalProperty()
        {
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

            var serializationProvider = VisitAndGetSerialization("CreationOptions", containerModel, experimentalModel);

            // Validate the entire generated serialization type against the expected TestData baseline.
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
            var model = InputFactory.Model(
                "PlainOptions",
                properties: [InputFactory.Property("name", InputPrimitiveType.String, isRequired: true)]);

            var serializationProvider = VisitAndGetSerialization("PlainOptions", model);

            var file = new TypeProviderWriter(serializationProvider).Write();
            Assert.That(file.Content, Does.Not.Contain(DiagnosticId), "No AAIP001 suppression should be emitted when there are no experimental members.");
        }

        /// <summary>
        /// Visiting the library twice must not add duplicate inline AAIP001 suppressions.
        /// </summary>
        [Test]
        public void DoesNotAddDuplicateSuppressions()
        {
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
            var visitor = new TestExperimentalAttributeVisitor();
            ScmCodeModelGenerator.Instance.AddVisitor(visitor);
            _ = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders;

            // Visit twice; suppressions are wrapped as SuppressionStatement nodes which are not
            // re-traversed, so re-visiting must not emit nested/duplicate directives.
            visitor.InvokeVisitLibrary(ScmCodeModelGenerator.Instance.OutputLibrary);
            visitor.InvokeVisitLibrary(ScmCodeModelGenerator.Instance.OutputLibrary);

            var serializationProvider = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ModelProvider>().Single(m => m.Type.Name == "CreationOptions").SerializationProviders.Single();
            foreach (var method in serializationProvider.Methods)
            {
                Assert.That(HasNestedExperimentalSuppression(method.BodyStatements!), Is.False,
                    $"Method {method.Signature.Name} should not contain nested duplicate AAIP001 suppressions.");
            }
        }

        private static TypeProvider VisitAndGetSerialization(string modelName, params InputModelType[] inputModels)
        {
            MockHelpers.LoadMockGenerator(inputModels: () => inputModels);
            var visitor = new TestExperimentalAttributeVisitor();
            ScmCodeModelGenerator.Instance.AddVisitor(visitor);
            // Accessing the output library builds the providers, which triggers the visitor's
            // PreVisit* hooks so the experimental type/member registries are populated.
            _ = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders;
            visitor.InvokeVisitLibrary(ScmCodeModelGenerator.Instance.OutputLibrary);

            return ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ModelProvider>().Single(m => m.Type.Name == modelName).SerializationProviders.Single();
        }

        // Returns true if any AAIP001 SuppressionStatement directly wraps another AAIP001
        // SuppressionStatement, which would indicate a duplicate suppression was emitted.
        private static bool HasNestedExperimentalSuppression(MethodBodyStatement statement)
        {
            switch (statement)
            {
                case SuppressionStatement suppression:
                    if (IsExperimentalSuppression(suppression) && suppression.Inner is not null
                        && ContainsExperimentalSuppression(suppression.Inner))
                    {
                        return true;
                    }
                    return suppression.Inner is not null && HasNestedExperimentalSuppression(suppression.Inner);
                case MethodBodyStatements statements:
                    return statements.Statements.Any(HasNestedExperimentalSuppression);
                case IfStatement ifStatement:
                    return HasNestedExperimentalSuppression(ifStatement.Body);
                default:
                    return false;
            }
        }

        private static bool ContainsExperimentalSuppression(MethodBodyStatement statement)
        {
            switch (statement)
            {
                case SuppressionStatement suppression:
                    return IsExperimentalSuppression(suppression)
                        || (suppression.Inner is not null && ContainsExperimentalSuppression(suppression.Inner));
                case MethodBodyStatements statements:
                    return statements.Statements.Any(ContainsExperimentalSuppression);
                case IfStatement ifStatement:
                    return ContainsExperimentalSuppression(ifStatement.Body);
                default:
                    return false;
            }
        }

        private static bool IsExperimentalSuppression(SuppressionStatement suppression) =>
            suppression.Code is ScopedApi { Original: LiteralExpression { Literal: string code } } && code == DiagnosticId;

        private class TestExperimentalAttributeVisitor : ExperimentalAttributeVisitor
        {
            public void InvokeVisitLibrary(OutputLibrary library) => base.VisitLibrary(library);
        }
    }
}
