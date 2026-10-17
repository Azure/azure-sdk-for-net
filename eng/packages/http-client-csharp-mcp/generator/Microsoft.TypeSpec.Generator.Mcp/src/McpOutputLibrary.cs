// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed class McpOutputLibrary : OutputLibrary
{
    internal IReadOnlyList<CommandModel> Commands { get; private set; } = [];

    protected override TypeProvider[] BuildTypeProviders()
    {
        var generator = (McpGenerator)CodeModelGenerator.Instance;
        var manifest = generator.Manifest;
        var methods = generator.InputLibrary.InputNamespace.Clients.SelectMany(client =>
            client.Methods.Select(method => (Client: client, Method: method))).ToArray();
        manifest.ValidateOperationIds(methods.Select(pair => pair.Method.CrossLanguageDefinitionId));
        var providers = new List<TypeProvider>();
        var commands = new List<CommandModel>();
        var types = new ContractTypes(manifest);
        foreach (var selection in manifest.Commands)
        {
            var pair = methods.Single(pair => pair.Method.CrossLanguageDefinitionId == selection.OperationId);
            var output = manifest with { Namespace = selection.Namespace };
            var contract = ServiceContract.Create(output, selection, pair.Client, pair.Method, types);
            var model = CommandModel.Create(selection, pair.Method, contract);
            commands.Add(model);
            var options = new ToolOptionsProvider(output, selection.Prefix + "Options", model.Options);
            var command = new CommandProvider(output, model, options);
            providers.AddRange([
                command, options, new CommandCatalogProvider(output, model, command),
                new ToolJsonContextProvider(output, selection.Prefix + "JsonContext", command.Result, contract.Request),
                contract.Request, contract.Response, contract.Service
            ]);
        }
        providers.AddRange(types.Models);
        Commands = commands;
        McpManifest.Require(providers.Select(provider => provider.RelativeFilePath).Distinct(StringComparer.OrdinalIgnoreCase).Count() == providers.Count,
            "Generated service/model output filenames collide.");
        foreach (var contract in providers.OfType<DataContractProvider>())
        {
            McpManifest.Require(contract.ContractProperties.All(property => McpManifest.IsIdentifier(property.Name)) &&
                contract.ContractProperties.Select(property => property.Name).Distinct(StringComparer.OrdinalIgnoreCase).Count() == contract.ContractProperties.Length,
                $"Invalid or colliding contract property names in '{contract.Name}'.");
        }
        return providers.ToArray();
    }

}
