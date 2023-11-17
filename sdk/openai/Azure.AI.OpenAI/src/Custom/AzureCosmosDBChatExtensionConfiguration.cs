// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    public partial class AzureCosmosDBChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        /// <summary> The database name of Azure Cosmos DB. </summary>
        public string DatabaseName { get; set; }
        /// <summary> The container name name of Azure Cosmos DB. </summary>
        public string ContainerName { get; set; }
        /// <summary> The index name name of Azure Cosmos DB. </summary>
        public string IndexName { get; set; }
        /// <summary> Customized field mapping behavior to use when interacting with the search index. </summary>
        public AzureCosmosDBFieldMappingOptions FieldMappingOptions { get; set; }

        public AzureCosmosDBChatExtensionConfiguration()
        {
            Type = AzureChatExtensionType.AzureCosmosDB;
        }
    }
}
