// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// A specific representation of configurable options for Azure Cognitive Search when using it as an Azure OpenAI chat
    /// extension.
    /// </summary>
    public partial class AzureCognitiveSearchChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        // CUSTOM CODE NOTE: this override effects the desired "default" behavior in the derived type
        public override AzureChatExtensionType Type
        {
            get => base.Type == default ? AzureChatExtensionType.AzureCognitiveSearch : base.Type;
            set => base.Type = value;
        }

        // CUSTOM CODE NOTE: the following required properties have setters added here to support an init-only
        //                      default constructor pattern and use AzureKeyCredential for key fields

        /// <summary> The absolute endpoint path for the Azure Cognitive Search resource to use. </summary>
        public Uri SearchEndpoint { get; set; }
        /// <summary> The name of the index to use as available in the referenced Azure Cognitive Search resource. </summary>
        public string IndexName { get; set; }

        /// <summary> The API key to use with the specified Azure Cognitive Search endpoint. </summary>
        private string SearchKey { get; set; }
        /// <summary> When using embeddings, specifies the API key to use with the provided embeddings endpoint. </summary>
        private string EmbeddingKey { get; set; }

        /// <summary>
        /// Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration.
        /// </summary>
        public AzureCognitiveSearchChatExtensionConfiguration()
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future.
        }

        // CUSTOM CODE NOTE: Users must set the search key using the SetSearchKey method, so we make the constructor
        //                       that receives it as a parameter to be internal and instead expose a public constructor
        //                       without it.

        /// <summary> Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration. </summary>
        /// <param name="type">
        /// The type label to use when configuring Azure OpenAI chat extensions. This should typically not be changed from its
        /// default value for Azure Cognitive Search.
        /// </param>
        /// <param name="searchEndpoint"> The absolute endpoint path for the Azure Cognitive Search resource to use. </param>
        /// <param name="indexName"> The name of the index to use as available in the referenced Azure Cognitive Search resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchEndpoint"/>, or <paramref name="indexName"/> is null. </exception>
        public AzureCognitiveSearchChatExtensionConfiguration(AzureChatExtensionType type, Uri searchEndpoint, string indexName)
        {
            Argument.AssertNotNull(searchEndpoint, nameof(searchEndpoint));
            Argument.AssertNotNull(indexName, nameof(indexName));

            Type = type;
            SearchEndpoint = searchEndpoint;
            IndexName = indexName;
        }

        /// <summary> Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration. </summary>
        /// <param name="type">
        /// The type label to use when configuring Azure OpenAI chat extensions. This should typically not be changed from its
        /// default value for Azure Cognitive Search.
        /// </param>
        /// <param name="searchEndpoint"> The absolute endpoint path for the Azure Cognitive Search resource to use. </param>
        /// <param name="searchKey"> The API admin key to use with the specified Azure Cognitive Search endpoint. </param>
        /// <param name="indexName"> The name of the index to use as available in the referenced Azure Cognitive Search resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchEndpoint"/>, <paramref name="searchKey"/> or <paramref name="indexName"/> is null. </exception>
        internal AzureCognitiveSearchChatExtensionConfiguration(AzureChatExtensionType type, Uri searchEndpoint, string searchKey, string indexName)
        {
            Argument.AssertNotNull(searchEndpoint, nameof(searchEndpoint));
            Argument.AssertNotNull(searchKey, nameof(searchKey));
            Argument.AssertNotNull(indexName, nameof(indexName));

            Type = type;
            SearchEndpoint = searchEndpoint;
            SearchKey = searchKey;
            IndexName = indexName;
        }

        /// <summary>
        /// Sets the API key to use with the specified Azure Cognitive Search endpoint.
        /// </summary>
        /// <param name="searchKey"> The API key. </param>
        public void SetSearchKey(string searchKey)
        {
            SearchKey = searchKey;
        }

        /// <summary>
        /// Sets the API key to use with the provided embeddings endpoint when using embeddings.
        /// </summary>
        /// <param name="embeddingKey"> The API key. </param>
        public void SetEmbeddingKey(string embeddingKey)
        {
            EmbeddingKey = embeddingKey;
        }
    }
}
