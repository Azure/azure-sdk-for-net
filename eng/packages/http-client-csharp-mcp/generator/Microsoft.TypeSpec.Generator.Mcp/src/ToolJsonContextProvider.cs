// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ToolJsonContextProvider(McpManifest manifest, ToolSelection selection) : McpProvider(manifest, selection.Types.JsonContext)
{
    protected override CSharpType BuildBaseType() => typeof(JsonSerializerContext);

    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Partial;

    protected override AttributeStatement[] BuildAttributes() =>
    [
        new AttributeStatement(typeof(JsonSerializableAttribute),
            [TypeOf(new ToolResultProvider(Manifest, selection).Type)]),
        new AttributeStatement(typeof(JsonSourceGenerationOptionsAttribute), [],
        [
            new("PropertyNamingPolicy", Static(typeof(JsonKnownNamingPolicy)).Property("CamelCase")),
            new("DefaultIgnoreCondition", Static(typeof(JsonIgnoreCondition)).Property("WhenWritingDefault"))
        ])
    ];
}
