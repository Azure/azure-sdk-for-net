// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
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
        // TODO: This is workaround to get AzureResourceManagerContext, we will remove this when we fix the dependency context generation issue in System.ClientModel.
        private static AzureResourceManagerContext s_managerContext;
        private AzureResourceManagerContext ArmContext => s_managerContext ??= AzureResourceManagerContext.Default;

        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories.Add(typeof(ManagedServiceIdentity), () => ArmContext.GetTypeBuilder(typeof(ManagedServiceIdentity)));
            factories.Add(typeof(SystemData), () => ArmContext.GetTypeBuilder(typeof(SystemData)));
        }
    }
}
