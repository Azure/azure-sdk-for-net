// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
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
        var providers = manifest.Operations.SelectMany(selection =>
        {
            var method = methods.Single(m => m.CrossLanguageDefinitionId == selection.OperationId);
            ValidateMethod(selection, method);
            return new TypeProvider[]
            {
                new ToolCatalogProvider(manifest, selection, method),
                new ToolOptionsProvider(manifest, selection, method),
                new ToolBindingProvider(manifest, selection),
                new ToolResultProvider(manifest, selection),
                new ToolJsonContextProvider(manifest, selection)
            };
        }).ToList();
        foreach (var selection in manifest.CommandSelections)
        {
            var method = methods.Single(method => method.CrossLanguageDefinitionId == selection.OperationId);
            var model = CommandModel.Create(selection, method);
            var options = new ToolOptionsProvider(manifest, selection.Prefix + "Options", model.Options, method);
            var command = new CommandProvider(manifest, model, options);
            providers.AddRange([
                command, options, new CommandCatalogProvider(manifest, model, command),
                new ToolJsonContextProvider(manifest, selection.Prefix + "JsonContext", command.Result)
            ]);
        }
        return providers.ToArray();
    }

    internal static void ValidateMethod(ToolSelection selection, InputServiceMethod method)
    {
        var wire = selection.Wire;
        McpManifest.Require(method is not (InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod or InputPagingServiceMethod),
            $"Paging and LRO mappings are not supported for '{selection.OperationId}'.");
        McpManifest.Require(method.Operation.HttpMethod.ToString().Equals(wire.Method, StringComparison.OrdinalIgnoreCase) &&
            method.Operation.Path == wire.Path && method.Operation.Uri == wire.Uri,
            $"HTTP operation shape does not match the reviewed mapping for '{selection.OperationId}'.");
        var parameters = method.Parameters.Where(p => p.Scope == InputParameterScope.Method && !p.IsApiVersion).ToArray();
        var sources = selection.Options.Where(o => o.Source is not null).ToArray();
        McpManifest.Require(parameters.Length == sources.Length && sources.All(option =>
            parameters.Any(p => p.Name == option.Source && p.IsRequired == option.Required &&
                MatchesPrimitive(option.Type, p.Type))),
            $"Every method parameter for '{selection.OperationId}' needs a matching primitive option mapping.");
        var wireParameters = method.Operation.Parameters.ToArray();
        McpManifest.Require(wireParameters.Length == parameters.Length + wire.Constants.Length &&
            wire.Constants.All(c => wireParameters.Any(p => p.Name == c.Name &&
                p.Scope == InputParameterScope.Constant && p.Type is InputLiteralType literal &&
                System.Text.Json.JsonElement.DeepEquals(
                    System.Text.Json.JsonSerializer.SerializeToElement(literal.Value), c.Value))),
            $"Additional or mismatched wire parameters are not supported for '{selection.OperationId}'.");
    }

    private static bool MatchesPrimitive(string type, InputType input) => (type, input.Name) switch
    {
        ("string", "string") or ("bool", "boolean") or ("int", "int32") or ("long", "int64") or
        ("float", "float32") or ("double", "float64") or ("decimal", "decimal") => true,
        _ => false
    };
}
