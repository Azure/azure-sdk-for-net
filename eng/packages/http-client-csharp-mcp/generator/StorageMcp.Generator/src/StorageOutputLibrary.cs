// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace StorageMcp.Generator;

internal sealed class StorageOutputLibrary : OutputLibrary
{
    protected override TypeProvider[] BuildTypeProviders()
    {
        var generator = CodeModelGenerator.Instance;
        var manifest = StorageManifest.Load(Path.Combine(generator.Configuration.OutputDirectory, "generation", "storage.tools.json"));
        var methods = generator.InputLibrary.InputNamespace.Clients.SelectMany(c => c.Methods).ToArray();
        manifest.ValidateOperationIds(methods.Select(m => m.CrossLanguageDefinitionId));
        var selection = manifest.Operations.Single();
        var method = methods.Single(m => m.CrossLanguageDefinitionId == selection.OperationId);
        if (method is InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod or InputPagingServiceMethod ||
            method.Operation.HttpMethod.ToString().ToUpperInvariant() != "PUT" ||
            method.Operation.Path != "/{container}" ||
            method.Operation.Uri != "{endpoint}" ||
            method.Operation.Parameters.Count() != 2 ||
            !method.Operation.Parameters.Any(p => p.Name == "restype" &&
                p.Scope == InputParameterScope.Constant && p.Type is InputLiteralType { Value: "container" }))
        {
            throw new InvalidOperationException("The private-container binding requires a non-LRO, non-paged PUT /{container}?restype=container operation with no additional wire parameters.");
        }

        var parameters = method.Parameters.Where(p => p.Scope == InputParameterScope.Method && !p.IsApiVersion).ToArray();
        if (parameters.Length != 1 || parameters[0].Name != "container" || !parameters[0].IsRequired ||
            parameters[0].Type.Name != "string")
        {
            throw new InvalidOperationException("The private-container binding expects exactly one required string container parameter.");
        }

        return
        [
            new ContainerCatalogProvider(selection, method),
            new ContainerOptionsProvider(parameters[0]),
            new ContainerBindingProvider(),
            new ContainerResultProvider(),
            new ContainerJsonContextProvider()
        ];
    }
}
