// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class ToolResultProvider(McpManifest manifest, ToolSelection selection) : McpProvider(manifest, selection.Types.Result)
{
    protected override PropertyProvider[] BuildProperties() => selection.Result.Select(property =>
        new PropertyProvider(description: null, modifiers: MethodSignatureModifiers.Public,
            type: ResolveType(property.Type), name: property.Name,
            body: new AutoPropertyBody(HasSetter: true), enclosingType: this)).ToArray();
}
