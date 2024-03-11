// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureCosmosDBChatExtensionParameters", typeof(string), typeof(string), typeof(string), typeof(AzureCosmosDBFieldMappingOptions))]
internal partial class AzureCosmosDBChatExtensionParameters
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    internal AzureCosmosDBChatExtensionParameters()
    { }

    /// <summary> The MongoDB vCore database name to use with Azure Cosmos DB. </summary>
    public string DatabaseName { get; set; }
    /// <summary> The name of the Azure Cosmos DB resource container. </summary>
    public string ContainerName { get; set; }
    /// <summary> The MongoDB vCore index name to use with Azure Cosmos DB. </summary>
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
