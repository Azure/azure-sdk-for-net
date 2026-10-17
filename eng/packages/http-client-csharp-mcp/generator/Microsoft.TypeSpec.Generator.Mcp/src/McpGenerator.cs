// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
            if (Manifest.CommandSelections.Length == 0)
            {
                return source;
            }
            var compilation = source.Customization
                ?? throw new InvalidOperationException("Complete commands require an existing consumer source compilation.");
            // The SDK workspace can disable XML-doc parsing; command option inference needs those comments.
            foreach (var tree in compilation.SyntaxTrees.Where(tree => tree.Options.DocumentationMode == DocumentationMode.None).ToArray())
            {
                var options = ((CSharpParseOptions)tree.Options).WithDocumentationMode(DocumentationMode.Parse);
                compilation = compilation.ReplaceSyntaxTree(tree, CSharpSyntaxTree.ParseText(tree.GetText(), options, tree.FilePath));
            }
            // Selected commands replace handwritten declarations under a consumer build switch.
            // Do not let customization filtering silently suppress their generated implementations.
            var declarations = Manifest.CommandSelections.SelectMany(command =>
                compilation.GetTypeByMetadataName(command.CommandType)?.DeclaringSyntaxReferences ?? [])
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
        foreach (var command in Manifest.CommandSelections)
        {
            var model = CommandModel.Create(command, InputLibrary.InputNamespace.Clients.SelectMany(client => client.Methods)
                .Single(method => method.CrossLanguageDefinitionId == command.OperationId));
            OptionsSyntaxAdapter.Rewrite(Path.Combine(outputPath, "src", "Generated", command.Prefix + "Options.cs"), model.Options);
            CommandSyntaxAdapter.Rewrite(Path.Combine(outputPath, "src", "Generated", command.Prefix + "Command.cs"), command);
        }
        return Task.CompletedTask;
    }
}
