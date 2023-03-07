// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

// Custom code to restore the safeflattened property

namespace Azure.ResourceManager.CosmosDB.Models
{
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
