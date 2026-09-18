// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CosmosSqlDataTransferDataSourceSink", typeof(string), typeof(string))]
    public partial class CosmosSqlDataTransferDataSourceSink
    {
        /// <summary> Initializes a new instance of <see cref="CosmosSqlDataTransferDataSourceSink"/>. </summary>
        /// <param name="databaseName"></param>
        /// <param name="containerName"></param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="containerName"/> is null. </exception>
        public CosmosSqlDataTransferDataSourceSink(string databaseName, string containerName)
            : base(DataTransferComponent.CosmosDBSql)
        {
            Argument.AssertNotNull(databaseName, nameof(databaseName));
            Argument.AssertNotNull(containerName, nameof(containerName));

            DatabaseName = databaseName;
            ContainerName = containerName;
        }
    }
}
