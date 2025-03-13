// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects
{
    /// <summary> The Type (or category) of the connection. </summary>
    public enum ConnectionType
    {
        /// <summary> Azure OpenAI Service. </summary>
        AzureOpenAI,
        /// <summary> Serverless API Service. </summary>
        Serverless,
        /// <summary> Azure Blob Storage. </summary>
        AzureBlobStorage,
        /// <summary> Azure AI Services. </summary>
        AzureAIServices,
        /// <summary> Azure AI Search. </summary>
        AzureAISearch,
        /// <summary> Bing Grounding. </summary>
        ApiKey
    }
}
