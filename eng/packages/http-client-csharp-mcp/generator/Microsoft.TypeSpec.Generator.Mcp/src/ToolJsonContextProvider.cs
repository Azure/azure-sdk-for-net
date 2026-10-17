// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ToolJsonContextProvider(McpManifest manifest, string name, TypeProvider result, TypeProvider request) : McpProvider(manifest, name)
{
    protected override CSharpType BuildBaseType() => typeof(JsonSerializerContext);

    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Partial;

    protected override AttributeStatement[] BuildAttributes() =>
    [
        new AttributeStatement(typeof(JsonSerializableAttribute),
            [TypeOf(result.Type)]),
        new AttributeStatement(typeof(JsonSerializableAttribute),
            [TypeOf(request.Type)]),
        new AttributeStatement(typeof(JsonSourceGenerationOptionsAttribute), [],
        [
            new("PropertyNamingPolicy", Static(typeof(JsonKnownNamingPolicy)).Property("CamelCase")),
            new("DefaultIgnoreCondition", Static(typeof(JsonIgnoreCondition)).Property("WhenWritingDefault")),
            new("UnmappedMemberHandling", Static(typeof(JsonUnmappedMemberHandling)).Property("Disallow")),
            new("RespectNullableAnnotations", True)
        ])
    ];
}
