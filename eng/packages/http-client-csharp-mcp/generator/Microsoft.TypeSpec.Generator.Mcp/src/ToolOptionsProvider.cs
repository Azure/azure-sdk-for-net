// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ToolOptionsProvider(McpManifest manifest, string name, OptionMapping[] options)
    : McpProvider(manifest, name)
{
    protected override PropertyProvider[] BuildProperties() => options.Select(option =>
    {
        var description = option.DescriptionMember is { } member
            ? Static(ResolveType(member.Type)).Property(member.Member)
            : (ValueExpression)Literal(option.Description!);
        return Option(option.Name, ResolveType(option.Type), description);
    }).ToArray();

    private PropertyProvider Option(string name, CSharpType type, ValueExpression description) =>
        new(description: null, modifiers: MethodSignatureModifiers.Public, type: type, name: name,
            body: new AutoPropertyBody(HasSetter: true), enclosingType: this,
            attributes:
            [
                new AttributeStatement(ExistingType("Microsoft.Mcp.Core.Options", "OptionAttribute"),
                    [], [new KeyValuePair<string, ValueExpression>("Description", description)])
            ]);
}
