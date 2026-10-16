// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace StorageMcp.Generator;

internal sealed class ContainerJsonContextProvider() : McpProvider("GeneratedStorageJsonContext")
{
    protected override CSharpType BuildBaseType() => typeof(JsonSerializerContext);

    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class | TypeSignatureModifiers.Sealed | TypeSignatureModifiers.Partial;

    protected override AttributeStatement[] BuildAttributes() =>
    [
        new AttributeStatement(typeof(JsonSerializableAttribute),
            [TypeOf(new ContainerResultProvider().Type)]),
        new AttributeStatement(typeof(JsonSourceGenerationOptionsAttribute), [],
        [
            new("PropertyNamingPolicy", Static(typeof(JsonKnownNamingPolicy)).Property("CamelCase")),
            new("DefaultIgnoreCondition", Static(typeof(JsonIgnoreCondition)).Property("WhenWritingDefault"))
        ])
    ];
}
