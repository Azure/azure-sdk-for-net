// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Azure.AI.Extensions.OpenAI;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents.Tests;

public class LegacyModelNameResolutionTests
{
    private const string LegacyNamespace = "Azure.AI.Projects.Agents";
    private const string SharedNamespace = "Azure.AI.Extensions.OpenAI";

    private static readonly MetadataReference[] References =
    [
        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
        MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location), "System.Runtime.dll")),
        MetadataReference.CreateFromFile(typeof(AgentAdministrationClient).Assembly.Location),
        MetadataReference.CreateFromFile(typeof(AzureAIExtensionsOpenAIContext).Assembly.Location),
        MetadataReference.CreateFromFile(typeof(ResponseTool).Assembly.Location),
        MetadataReference.CreateFromFile(typeof(System.ClientModel.Primitives.IJsonModel<>).Assembly.Location)
    ];

    [TestCase("A2APreviewTool")]
    [TestCase("AzureAISearchTool")]
    [TestCase("AzureAISearchToolIndex")]
    [TestCase("AzureAISearchToolOptions")]
    [TestCase("AzureFunctionBinding")]
    [TestCase("AzureFunctionDefinition")]
    [TestCase("AzureFunctionDefinitionFunction")]
    [TestCase("AzureFunctionStorageQueue")]
    [TestCase("AzureFunctionTool")]
    [TestCase("BingCustomSearchPreviewTool")]
    [TestCase("BingCustomSearchToolOptions")]
    [TestCase("BingGroundingSearchToolOptions")]
    [TestCase("BingGroundingTool")]
    [TestCase("BrowserAutomationPreviewTool")]
    [TestCase("BrowserAutomationToolOptions")]
    [TestCase("CaptureStructuredOutputsTool")]
    [TestCase("FabricDataAgentToolOptions")]
    [TestCase("MemorySearchPreviewTool")]
    [TestCase("MicrosoftFabricPreviewTool")]
    [TestCase("OpenApiAuthenticationDetails")]
    [TestCase("OpenApiFunctionDefinition")]
    [TestCase("OpenApiProjectConnectionAuthenticationDetails")]
    [TestCase("OpenApiProjectConnectionSecurityScheme")]
    [TestCase("SharePointGroundingToolOptions")]
    [TestCase("StructuredOutputDefinition")]
    [TestCase("ToolProjectConnection")]
    public void OverlappingTypeRequiresQualificationDespiteEditorBrowsableNever(string name)
    {
        CSharpCompilation ambiguous = CreateCompilation($"typeof({name})");
        Diagnostic[] errors = ambiguous.GetDiagnostics().Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error).ToArray();
        Assert.That(errors, Has.Length.EqualTo(1), string.Join(Environment.NewLine, errors.Select(error => error.ToString())));
        Assert.That(errors[0].Id, Is.EqualTo("CS0104"));
        Assert.That(errors[0].GetMessage(), Does.Contain($"{LegacyNamespace}.{name}").And.Contain($"{SharedNamespace}.{name}"));

        CSharpCompilation qualified = CreateCompilation(
            $"typeof(global::{LegacyNamespace}.{name}), typeof(global::{SharedNamespace}.{name})");
        using var output = new MemoryStream();
        Microsoft.CodeAnalysis.Emit.EmitResult result = qualified.Emit(output);
        Assert.That(result.Success, Is.True, string.Join(Environment.NewLine, result.Diagnostics));

        SyntaxTree tree = qualified.SyntaxTrees.Single();
        SemanticModel model = qualified.GetSemanticModel(tree);
        TypeOfExpressionSyntax[] references = tree.GetRoot().DescendantNodes().OfType<TypeOfExpressionSyntax>().ToArray();
        ITypeSymbol legacy = model.GetTypeInfo(references[0].Type).Type;
        ITypeSymbol shared = model.GetTypeInfo(references[1].Type).Type;
        Assert.That(legacy.ToDisplayString(), Is.EqualTo($"{LegacyNamespace}.{name}"));
        Assert.That(shared.ToDisplayString(), Is.EqualTo($"{SharedNamespace}.{name}"));
        Assert.That(SymbolEqualityComparer.Default.Equals(legacy, shared), Is.False);
        Assert.That(legacy.ContainingAssembly.Name, Is.EqualTo(typeof(AgentAdministrationClient).Assembly.GetName().Name));
        Assert.That(shared.ContainingAssembly.Name, Is.EqualTo(typeof(AzureAIExtensionsOpenAIContext).Assembly.GetName().Name));

        AttributeData browsable = legacy.GetAttributes().Single(attribute =>
            attribute.AttributeClass.ToDisplayString() == "System.ComponentModel.EditorBrowsableAttribute");
        Assert.That(browsable.ConstructorArguments.Single().Value, Is.EqualTo((int)System.ComponentModel.EditorBrowsableState.Never));
    }

    [Test]
    public void ExplicitCasesCoverEveryOverlappingPublicTypeInBothNamespaces()
    {
        string[] legacyNames = typeof(AgentAdministrationClient).Assembly.GetExportedTypes()
            .Where(type => !type.IsNested && type.Namespace == LegacyNamespace)
            .Select(type => type.Name).ToArray();
        string[] sharedNames = typeof(AzureAIExtensionsOpenAIContext).Assembly.GetExportedTypes()
            .Where(type => !type.IsNested && type.Namespace == SharedNamespace)
            .Select(type => type.Name).ToArray();
        string[] collisions = legacyNames.Intersect(sharedNames, StringComparer.Ordinal).ToArray();
        string[] cases = typeof(LegacyModelNameResolutionTests)
            .GetMethod(nameof(OverlappingTypeRequiresQualificationDespiteEditorBrowsableNever))
            .GetCustomAttributes<TestCaseAttribute>()
            .Select(test => (string)test.Arguments.Single()).ToArray();

        Assert.That(cases, Is.Unique);
        Assert.That(cases, Is.EquivalentTo(collisions),
            "Every overlapping public type must have an explicit qualification test.");
    }

    private static CSharpCompilation CreateCompilation(string expressions)
    {
        // Use an unrelated customer namespace: nesting under Agents would give its
        // types precedence and hide the ambiguity caused by these two imports.
        string source = $$"""
            #pragma warning disable AAIP001, AAIP002, OPENAI001, SCME0001, SCME0002
            using {{LegacyNamespace}};
            using {{SharedNamespace}};

            namespace CustomerApplication
            {
                public static class ModelReferences
                {
                    public static object[] GetTypes() => new object[] { {{expressions}} };
                }
            }
            """;
        return CSharpCompilation.Create(
            "CustomerModelReferences",
            [CSharpSyntaxTree.ParseText(source)],
            References,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }
}
