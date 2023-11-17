// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI
{
    public partial class AzureCognitiveSearchChatExtensionConfiguration : AzureChatExtensionConfiguration
    {
        // CUSTOM CODE NOTE: the following required properties have setters added here to support an init-only
        //                      default constructor pattern

        /// <summary> The absolute endpoint path for the Azure Cognitive Search resource to use. </summary>
        public Uri SearchEndpoint { get; set; }
        /// <summary> The name of the index to use as available in the referenced Azure Cognitive Search resource. </summary>
        public string IndexName { get; set; }
        /// <summary> When using embeddings, specifies the API key to use with the provided embeddings endpoint. </summary>
        private string EmbeddingKey { get; set; }

        /// <summary>
        /// Initializes a new instance of AzureCognitiveSearchChatExtensionConfiguration.
        /// </summary>
        public AzureCognitiveSearchChatExtensionConfiguration()
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future
            Type = AzureChatExtensionType.AzureCognitiveSearch;
        }

        /// <summary>
        /// Sets the API key used for a configured embeddings endpoint.
        /// </summary>
        /// <param name="embeddingKey"> The API key to use with embeddings. </param>
        public void SetEmbeddingKey(string embeddingKey)
        {
            EmbeddingKey = embeddingKey;
        }
    }
}
