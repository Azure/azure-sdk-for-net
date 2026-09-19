// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CosmosCassandraDataTransferDataSourceSink", typeof(string), typeof(string))]
    public partial class CosmosCassandraDataTransferDataSourceSink
    {
        /// <summary> Initializes a new instance of <see cref="CosmosCassandraDataTransferDataSourceSink"/>. </summary>
        /// <param name="keyspaceName"></param>
        /// <param name="tableName"></param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="keyspaceName"/> or <paramref name="tableName"/> is null. </exception>
        public CosmosCassandraDataTransferDataSourceSink(string keyspaceName, string tableName)
            : base(DataTransferComponent.CosmosDBCassandra)
        {
            Argument.AssertNotNull(keyspaceName, nameof(keyspaceName));
            Argument.AssertNotNull(tableName, nameof(tableName));

            KeyspaceName = keyspaceName;
            TableName = tableName;
        }
    }
}
