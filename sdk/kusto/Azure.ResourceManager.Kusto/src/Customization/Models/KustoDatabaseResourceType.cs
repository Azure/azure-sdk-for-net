// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// The old GA SDK had KustoDatabaseResourceType as a fixed C# enum
// (from Swagger type 'Type'). In TypeSpec this type doesn't exist
// as a standalone model. Providing it here preserves backward compat.

namespace Azure.ResourceManager.Kusto.Models
{
    /// <summary> The type of resource, for instance Microsoft.Kusto/clusters/databases. </summary>
    public enum KustoDatabaseResourceType
    {
        /// <summary> Microsoft.Kusto/clusters/databases. </summary>
        MicrosoftKustoClustersDatabases,
        /// <summary> Microsoft.Kusto/clusters/attachedDatabaseConfigurations. </summary>
        MicrosoftKustoClustersAttachedDatabaseConfigurations
    }
}
