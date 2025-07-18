// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.PlanetaryComputer.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.PlanetaryComputer
{
    [ModelReaderWriterBuildable(typeof(GeoCatalogListResult))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogPatch))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogProperties))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogData))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogResource))]
[ModelReaderWriterBuildable(typeof(SystemData))]
[ModelReaderWriterBuildable(typeof(ManagedServiceIdentity))]
[ModelReaderWriterBuildable(typeof(WritableSubResource))]
[ModelReaderWriterBuildable(typeof(SubResource))]
    public partial class AzureResourceManagerPlanetaryComputerContext
    {
    }
}
