// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace StorageMcp.Generator;

internal abstract class McpProvider(string name) : TypeProvider
{
    protected override string BuildName() => name;
    protected override string BuildNamespace() => "Azure.Mcp.Tools.Storage.GeneratedMcp";
    protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", Name + ".cs");

    protected static CSharpType ExistingType(string ns, string name) =>
        CodeModelGenerator.Instance.SourceInputModel.FindForTypeInCurrentCompilation(ns, name, includeReferencedAssemblies: true)?.Type
        ?? throw new InvalidOperationException($"Cannot resolve existing type '{ns}.{name}'.");
}
