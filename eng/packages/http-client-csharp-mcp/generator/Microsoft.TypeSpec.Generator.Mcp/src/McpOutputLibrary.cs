// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class McpOutputLibrary : OutputLibrary
{
    protected override TypeProvider[] BuildTypeProviders()
    {
        var generator = (McpGenerator)CodeModelGenerator.Instance;
        var manifest = generator.Manifest;
        var methods = generator.InputLibrary.InputNamespace.Clients.SelectMany(c => c.Methods).ToArray();
        manifest.ValidateOperationIds(methods.Select(m => m.CrossLanguageDefinitionId));
        var providers = new List<TypeProvider>();
        foreach (var selection in manifest.Commands)
        {
            var method = methods.Single(method => method.CrossLanguageDefinitionId == selection.OperationId);
            var model = CommandModel.Create(selection, method);
            var output = manifest with { Namespace = selection.Namespace };
            var options = new ToolOptionsProvider(output, selection.Prefix + "Options", model.Options);
            var command = new CommandProvider(output, model, options);
            providers.AddRange([
                command, options, new CommandCatalogProvider(output, model, command),
                new ToolJsonContextProvider(output, selection.Prefix + "JsonContext", command.Result)
            ]);
        }
        return providers.ToArray();
    }

}
