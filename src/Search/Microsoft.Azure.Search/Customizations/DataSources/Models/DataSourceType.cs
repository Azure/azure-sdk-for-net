// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines the type of an Azure Search datasource.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<DataSourceType>))]
    public sealed class DataSourceType : ExtensibleEnum<DataSourceType>
    {
        /// <summary>
        /// Indicates an Azure SQL datasource.
        /// </summary>
        public static readonly DataSourceType AzureSql = new DataSourceType("azuresql");

        /// <summary>
        /// Indicates a DocumentDB datasource.
        /// </summary>
        public static readonly DataSourceType DocumentDb = new DataSourceType("documentdb");

        /// <summary>
        /// Indicates a Azure Blob datasource.
        /// </summary>
        public static readonly DataSourceType AzureBlob = new DataSourceType("azureblob");

        /// <summary>
        /// Indicates a Azure Table datasource.
        /// </summary>
        public static readonly DataSourceType AzureTable = new DataSourceType("azuretable");

        private DataSourceType(string typeName) : base(typeName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new DataSourceType instance, or returns an existing instance if the given name matches that of a
        /// known data source type.
        /// </summary>
        /// <param name="name">Name of the data source type.</param>
        /// <returns>A DataSourceType instance with the given name.</returns>
        public static DataSourceType Create(string name)
        {
            // Data source type names are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(name) ?? new DataSourceType(name);
        }
    }
}
