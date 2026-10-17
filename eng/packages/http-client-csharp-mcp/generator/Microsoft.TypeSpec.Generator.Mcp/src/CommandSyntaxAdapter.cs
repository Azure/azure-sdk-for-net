// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal static class CommandSyntaxAdapter
{
    internal static void Rewrite(string path, CommandSelection selection)
    {
        // The shared writer predates primary constructors and records.
        var root = CSharpSyntaxTree.ParseText(File.ReadAllText(path)).GetRoot();
        McpManifest.Require(!root.ContainsDiagnostics, "Generated command contains invalid C# syntax.");
        var command = root.DescendantNodes().OfType<ClassDeclarationSyntax>()
            .Single(node => node.Identifier.ValueText == selection.Prefix + "Command");
        var constructor = command.Members.OfType<ConstructorDeclarationSyntax>().Single();
        McpManifest.Require(constructor.Body is { Statements.Count: 0 } && constructor.Initializer is null,
            "Unexpected generated constructor; refusing to convert it to a primary constructor.");
        var result = command.Members.OfType<ClassDeclarationSyntax>().Single();
        var property = result.Members.OfType<PropertyDeclarationSyntax>().Single();
        McpManifest.Require(result.Members.Count == 2 && result.Members.OfType<ConstructorDeclarationSyntax>()
            .Single().ParameterList.Parameters.Count == 1, "Unexpected generated result shape.");
        var record = (RecordDeclarationSyntax)SyntaxFactory.ParseMemberDeclaration("public record Result();")!;
        record = record.WithIdentifier(result.Identifier).WithModifiers(result.Modifiers)
            .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(
                SyntaxFactory.Parameter(property.Identifier).WithType(property.Type))))
            .WithLeadingTrivia(result.GetLeadingTrivia()).WithTrailingTrivia(result.GetTrailingTrivia());
        root = root.ReplaceNode(command, command.WithParameterList(constructor.ParameterList)
            .WithMembers(SyntaxFactory.List(command.Members.Where(member => member != constructor)
                .Select(member => member == result ? record : member))));
        File.WriteAllText(path, root.NormalizeWhitespace(eol: "\n").ToFullString() + "\n");
    }
}
