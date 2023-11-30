// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureCosmosDBChatExtensionParameters", typeof(string), typeof(string), typeof(string), typeof(AzureCosmosDBFieldMappingOptions))]
internal partial class AzureCosmosDBChatExtensionParameters
{
    internal AzureCosmosDBChatExtensionParameters()
    { }

    /// <summary> The database name of Azure Cosmos DB. </summary>
    public string DatabaseName { get; set; }
    /// <summary> The container name name of Azure Cosmos DB. </summary>
    public string ContainerName { get; set; }
    /// <summary> The index name of Azure Cosmos DB. </summary>
    public string IndexName { get; set; }
    /// <summary> Customized field mapping behavior to use when interacting with the search index. </summary>
    public AzureCosmosDBFieldMappingOptions FieldMappingOptions { get; set; }
    /// <summary>
    /// The embedding dependency for vector search.
    /// Please note <see cref="OnYourDataVectorizationSource"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="OnYourDataEndpointVectorizationSource"/>, <see cref="OnYourDataDeploymentNameVectorizationSource"/> and <see cref="OnYourDataModelIdVectorizationSource"/>.
    /// </summary>
    public OnYourDataVectorizationSource EmbeddingDependency { get; set; }
}
