// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.SourceInput;

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

    private SourceInputModel? _commandSource;
    public override SourceInputModel SourceInputModel
    {
        get
        {
            if (_commandSource is not null)
            {
                return _commandSource;
            }
            var source = base.SourceInputModel;
            if (Manifest.Commands.Length == 0)
            {
                return source;
            }
            var compilation = source.Customization
                ?? throw new InvalidOperationException("Complete commands require an existing consumer source compilation.");
            // Implementing partial methods must not suppress their generated defining declarations.
            var declarations = Manifest.Commands.SelectMany(command =>
                new[] { command.CommandType, command.Namespace + "." + command.ServiceName })
                .SelectMany(name => compilation.GetTypeByMetadataName(name)?.DeclaringSyntaxReferences ?? [])
                .GroupBy(reference => reference.SyntaxTree);
            foreach (var group in declarations)
            {
                var root = group.Key.GetRoot();
                var rewritten = root.RemoveNodes(group.Select(reference => reference.GetSyntax()), SyntaxRemoveOptions.KeepNoTrivia)
                    ?? throw new InvalidOperationException("Cannot exclude a selected command from customization input.");
                compilation = compilation.ReplaceSyntaxTree(group.Key, group.Key.WithRootAndOptions(rewritten, group.Key.Options));
            }
            return _commandSource = new SourceInputModel(compilation, source.LastContract, source.ApiCompatBaseline);
        }
    }

    protected override void Configure()
    {
        foreach (var path in ConsumerMetadata.Resolve(Configuration.OutputDirectory))
        {
            AddMetadataReference(MetadataReference.CreateFromFile(path));
        }
    }

    public override Task WriteAdditionalFiles(string outputPath)
    {
        var library = (McpOutputLibrary)OutputLibrary;
        foreach (var model in library.Commands)
        {
            OptionsSyntaxAdapter.Rewrite(Path.Combine(outputPath, "src", "Generated", model.Selection.Prefix + "Options.cs"), model.Options);
            CommandSyntaxAdapter.Rewrite(Path.Combine(outputPath, "src", "Generated", model.Selection.Prefix + "Command.cs"), model.Selection);
        }
        foreach (var contract in library.TypeProviders.OfType<DataContractProvider>())
        {
            OptionsSyntaxAdapter.Rewrite(Path.Combine(outputPath, contract.RelativeFilePath),
                contract.ContractProperties.Select(property => new OptionMapping(property.Name, "", property.Required)).ToArray());
        }
        return Task.CompletedTask;
    }
}
