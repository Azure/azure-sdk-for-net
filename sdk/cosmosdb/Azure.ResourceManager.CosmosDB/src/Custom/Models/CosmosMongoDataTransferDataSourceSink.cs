// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CosmosMongoDataTransferDataSourceSink", typeof(string), typeof(string))]
    public partial class CosmosMongoDataTransferDataSourceSink
    {
        /// <summary> Initializes a new instance of <see cref="CosmosMongoDataTransferDataSourceSink"/>. </summary>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="collectionName"/> is null. </exception>
        public CosmosMongoDataTransferDataSourceSink(string databaseName, string collectionName)
            : base(DataTransferComponent.CosmosDBMongo)
        {
            Argument.AssertNotNull(databaseName, nameof(databaseName));
            Argument.AssertNotNull(collectionName, nameof(collectionName));

            DatabaseName = databaseName;
            CollectionName = collectionName;
        }
    }
}
