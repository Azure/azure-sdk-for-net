// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The C# `: TrackedResourceData` base is declared here (instead of via a
    // shadow model + @@alternateType in client.tsp). The generator picks the
    // base up from this partial and strips the inherited ARM base properties.
    // Back-compat alias: 1.4.0 GA exposed the flat name `ResourceDatabaseName`
    // on the wrapper; the generator now emits the nested `Resource.DatabaseName`
    // form instead, so re-add the flat name as a pass-through (lazy-create Resource).
    /// <summary> Parameters to create and update Cosmos DB SQL database. </summary>
    public partial class CosmosDBSqlDatabaseCreateOrUpdateContent : TrackedResourceData
    {
        /// <summary> Name of the Cosmos DB SQL database. </summary>
        public string ResourceDatabaseName
        {
            get => Resource is null ? default : Resource.DatabaseName;
            set
            {
                if (Resource is null)
                    Resource = new CosmosDBSqlDatabaseResourceInfo(value);
                else
                    Resource.DatabaseName = value;
            }
        }
    }
}
