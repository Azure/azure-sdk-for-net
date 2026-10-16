// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;

namespace StorageMcp.Generator;

[Export(typeof(CodeModelGenerator))]
[ExportMetadata(GeneratorMetadataName, nameof(StorageMcpGenerator))]
[method: ImportingConstructor]
public sealed class StorageMcpGenerator(GeneratorContext context) : CodeModelGenerator(context)
{
    public override OutputLibrary OutputLibrary { get; } = new StorageOutputLibrary();

    protected override void Configure()
    {
        var binaries = Path.Combine(Configuration.OutputDirectory, "src", "bin", "Debug", "net10.0");
        foreach (var assembly in new[] { "Microsoft.Mcp.Core.dll", "Azure.Mcp.Core.dll" })
        {
            var path = Path.Combine(binaries, assembly);
            if (!File.Exists(path))
            {
                throw new InvalidOperationException($"Build the Storage project in Debug before generation: missing '{path}'.");
            }

            AddMetadataReference(MetadataReference.CreateFromFile(path));
        }
    }

    public override Task WriteAdditionalFiles(string outputPath)
    {
        OptionsSyntaxAdapter.Rewrite(Path.Combine(outputPath, "src", "Generated", "GeneratedContainerCreateOptions.cs"));
        return Task.CompletedTask;
    }
}
