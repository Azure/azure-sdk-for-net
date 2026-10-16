// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;

namespace Microsoft.TypeSpec.Generator.Mcp;

[Export(typeof(CodeModelGenerator))]
[ExportMetadata(GeneratorMetadataName, nameof(McpGenerator))]
[method: ImportingConstructor]
public sealed class McpGenerator(GeneratorContext context) : CodeModelGenerator(context)
{
    private McpManifest? _manifest;
    internal McpManifest Manifest => _manifest ??= McpManifest.Load(
        Path.Combine(Configuration.OutputDirectory, "tspMcpCodeModel.json"));

    public override OutputLibrary OutputLibrary { get; } = new McpOutputLibrary();

    protected override void Configure()
    {
        foreach (var reference in Manifest.MetadataReferences)
        {
            var path = Path.Combine(Configuration.OutputDirectory, reference.Replace('\\', Path.DirectorySeparatorChar));
            if (!File.Exists(path))
            {
                throw new InvalidOperationException($"Build the consumer before generation: missing metadata reference '{path}'.");
            }
            AddMetadataReference(MetadataReference.CreateFromFile(path));
        }
    }

    public override Task WriteAdditionalFiles(string outputPath)
    {
        foreach (var tool in Manifest.Operations)
        {
            OptionsSyntaxAdapter.Rewrite(Path.Combine(outputPath, "src", "Generated", tool.Types.Options + ".cs"), tool.Options);
        }
        return Task.CompletedTask;
    }
}
