// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The C# `: TrackedResourceData` base is declared here (instead of via a
    // shadow model + @@alternateType in client.tsp). The generator picks the
    // base up from this partial and strips the inherited ARM base properties
    // (id/name/type/tags/location/identity) from the renamed wrapper.
    public partial class CosmosDBSqlContainerCreateOrUpdateContent : TrackedResourceData
    {
    }
}
