// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat alias: 1.4.0 GA exposed the flat name `ResourceDatabaseName`
    // on the wrapper; the generator now emits the nested `Resource.DatabaseName`
    // form instead, so re-add the flat name as a pass-through (lazy-create Resource).
    /// <summary> Parameters to create and update Cosmos DB MongoDB database. </summary>
    public partial class MongoDBDatabaseCreateOrUpdateContent
    {
        /// <summary> Name of the Cosmos DB MongoDB database. </summary>
        public string ResourceDatabaseName
        {
            get => Resource is null ? default : Resource.DatabaseName;
            set
            {
                if (Resource is null)
                    Resource = new MongoDBDatabaseResourceInfo(value);
                else
                    Resource.DatabaseName = value;
            }
        }
    }
}
