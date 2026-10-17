// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal abstract class McpProvider(McpManifest manifest, string name) : TypeProvider
{
    protected McpManifest Manifest { get; } = manifest;
    protected override string BuildName() => name;
    protected override string BuildNamespace() => Manifest.Namespace;
    protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", Name + ".cs");

    protected static CSharpType ExistingType(string ns, string name) =>
        CodeModelGenerator.Instance.SourceInputModel.FindForTypeInCurrentCompilation(ns, name, includeReferencedAssemblies: true)?.Type
        ?? throw new InvalidOperationException($"Cannot resolve existing type '{ns}.{name}'.");

    internal static CSharpType ResolveType(string name) => name switch
    {
        "string" => typeof(string),
        "bool" => typeof(bool),
        "int" => typeof(int),
        "long" => typeof(long),
        "float" => typeof(float),
        "double" => typeof(double),
        "decimal" => typeof(decimal),
        "System.Threading.CancellationToken" => typeof(CancellationToken),
        _ => ExistingType(name[..name.LastIndexOf('.')], name[(name.LastIndexOf('.') + 1)..])
    };
}
