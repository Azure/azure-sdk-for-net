// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.PlanetaryComputer.Models;

namespace Azure.ResourceManager.PlanetaryComputer
{
    [ModelReaderWriterBuildable(typeof(GeoCatalogListResult))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogPatch))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogProperties))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogData))]
    [ModelReaderWriterBuildable(typeof(PlanetaryComputerGeoCatalogResource))]
    public partial class AzureResourceManagerPlanetaryComputerContext
    {
    }
}
