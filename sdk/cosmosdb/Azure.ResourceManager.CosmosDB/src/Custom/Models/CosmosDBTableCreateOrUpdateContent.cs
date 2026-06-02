// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat alias: 1.4.0 GA exposed the flat name `ResourceTableName` on
    // the wrapper; the generator now emits the nested `Resource.TableName` form
    // instead, so re-add the flat name as a pass-through (lazy-create Resource).
    /// <summary> Parameters to create and update Cosmos DB Table. </summary>
    public partial class CosmosDBTableCreateOrUpdateContent
    {
        /// <summary> Name of the Cosmos DB table. </summary>
        public string ResourceTableName
        {
            get => Resource is null ? default : Resource.TableName;
            set
            {
                if (Resource is null)
                    Resource = new CosmosDBTableResourceInfo(value);
                else
                    Resource.TableName = value;
            }
        }
    }
}
