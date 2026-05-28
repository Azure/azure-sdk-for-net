// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class AzureAISearchToolResource
    {
        public AzureAISearchToolResource(
            string indexConnectionId,
            string indexName,
            int topK,
            string filter,
            AzureAISearchQueryType? queryType = null) // Removed default value
        {
            // Assign default value explicitly if queryType is null
            queryType ??= AzureAISearchQueryType.Simple;

            // Initialize properties or perform other logic here
            var indexList = new AISearchIndexResource(
                indexConnectionId: indexConnectionId,
                indexName: indexName,
                topK: topK,
                filter: filter,
                queryType: queryType,
                indexAssetId: null,
                serializedAdditionalRawData: null
            );

            // Additional initialization logic if needed
            this.IndexList = new List<AISearchIndexResource> { indexList };
        }
    }
}
