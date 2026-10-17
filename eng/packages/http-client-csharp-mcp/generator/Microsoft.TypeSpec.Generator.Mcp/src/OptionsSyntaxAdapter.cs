// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.TypeSpec.Generator.Mcp;

public static class OptionsSyntaxAdapter
{
    public static void Rewrite(string path, OptionMapping[] options) =>
        File.WriteAllText(path, RewriteSource(File.ReadAllText(path), options));

    public static string RewriteSource(string source, OptionMapping[] options)
    {
        // The shared SDK writer predates nullable-reference and required-property syntax.
        var root = CSharpSyntaxTree.ParseText(source).GetRoot();
        if (root.ContainsDiagnostics)
        {
            throw new InvalidOperationException("Generated options contain invalid C# syntax.");
        }
        var directives = root.DescendantTrivia().Where(t => t.IsKind(SyntaxKind.NullableDirectiveTrivia));
        root = root.ReplaceTrivia(directives, (trivia, _) =>
            trivia.GetStructure() is NullableDirectiveTriviaSyntax directive &&
            directive.SettingToken.IsKind(SyntaxKind.DisableKeyword)
                ? SyntaxFactory.Trivia(directive.WithSettingToken(
                    SyntaxFactory.Token(SyntaxKind.EnableKeyword).WithTriviaFrom(directive.SettingToken)))
                : trivia);
        var properties = root.DescendantNodes().OfType<PropertyDeclarationSyntax>().ToArray();
        if (!properties.Select(p => p.Identifier.ValueText).Order(StringComparer.Ordinal)
            .SequenceEqual(options.Select(o => o.Name).Order(StringComparer.Ordinal)))
        {
            throw new InvalidOperationException("Unexpected generated options shape; refusing to change its requiredness.");
        }

        root = root.ReplaceNodes(properties, (property, _) => !options.Single(o => o.Name == property.Identifier.ValueText).Required
            ? property.Type is NullableTypeSyntax ? property
                : property.WithType(SyntaxFactory.NullableType(property.Type.WithoutTrivia()).WithTriviaFrom(property.Type))
            : property.Modifiers.Any(SyntaxKind.RequiredKeyword) ? property
                : property.WithModifiers(property.Modifiers.Add(SyntaxFactory.Token(SyntaxKind.RequiredKeyword))));
        return root.NormalizeWhitespace(eol: "\n").ToFullString() + "\n";
    }
}
