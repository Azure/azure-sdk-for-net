# Azure.Search.Documents Samples - Vector Search

Vector search is an information retrieval technique that uses numeric representations of searchable documents and query strings. By searching for numeric representations of content that are most similar to the numeric query, vector search can find relevant matches, even if the exact terms of the query are not present in the index. Moreover, vector search can be applied to various types of content, including images and videos and translated text, not just same-language text.

Azure AI Search doesn't host vectorization models. This presents a challenge in creating embeddings for query inputs and outputs. To address this, you need to ensure that the documents you push to your search service include vectors within the payload. To generate vectorized data, you have the flexibility to use any embedding model of your choice. However, we recommend utilizing the [Azure OpenAI Embeddings models](https://learn.microsoft.com/azure/cognitive-services/openai/how-to/embeddings) for this purpose. You can leverage the [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library to generate text embeddings.

Please refer the [documentation](https://learn.microsoft.com/azure/search/vector-search-overview) to learn more about vector search.

Here's the list of samples that will show you how to index the vector fields and perform vector search using .NET SDK.

* [Vector Search Using Vectorized Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md#vector-search-using-vector-query)
     * [Single Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md#single-vector-search)
     * [Single Vector Search With Filter](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md#single-vector-search-with-filter)
     * [Hybrid Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md#hybrid-search)
     * [Multi-Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md#multi-vector-search)
     * [Multi-Field Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md#multi-field-vector-search)
* [Vector Search Using Vectorizable Text Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md#vector-search-using-vectorizable-text-query)
     * [Single Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md#single-vector-search)
     * [Single Vector Search With Filter](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md#single-vector-search-with-filter)
     * [Hybrid Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md#hybrid-search)
     * [Multi-vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md#multi-vector-search)
     * [Multi-field Vector Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md#multi-field-vector-search)
* [Vector Semantic Hybrid Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingSemanticHybridQuery.md)
* [Vector Search Using Field Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingFieldBuilder.md)
* [Vector Search Using Reduced Embeddings](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingReducedEmbeddings.md)
