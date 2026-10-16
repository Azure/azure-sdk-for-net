// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace StorageMcp.Generator;

internal sealed class ContainerResultProvider() : McpProvider("GeneratedContainerCreateResult")
{
    protected override PropertyProvider[] BuildProperties() =>
    [
        new PropertyProvider(description: null, modifiers: MethodSignatureModifiers.Public,
            type: ExistingType("Azure.Mcp.Tools.Storage.Models", "ContainerInfo"), name: "Container",
            body: new AutoPropertyBody(HasSetter: true), enclosingType: this)
    ];
}
