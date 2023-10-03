# Azure.Search.Documents Samples - Vector Search

Vector search is a method of information retrieval technique that aims to overcome the limitations of traditional keyword-based search. Instead of relying solely on lexical analysis and matching individual query terms, vector search utilizes machine learning models to capture the contextual meaning of words and phrases. This is achieved by representing documents and queries as vectors in a high-dimensional space known as an embedding. By understanding the intent behind the query, vector search can provide more relevant results that align with the user's requirements, even if the exact terms are not present in the document. Additionally, vector search can be applied to different types of content, such as images and videos, not just text.

Cognitive Search doesn't host vectorization models. This presents a challenge in creating embeddings for query inputs and outputs. To address this, you need to ensure that the documents you push to your search service include vectors within the payload. To generate vectorized data, you have the flexibility to use any embedding model of your choice. However, we recommend utilizing the [Azure OpenAI Embeddings models](https://learn.microsoft.com/azure/cognitive-services/openai/how-to/embeddings) for this purpose. You can leverage the [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library to generate text embeddings.

Please refer the [documentation](https://learn.microsoft.com/azure/search/vector-search-overview) to learn more about Vector Search.

This sample will show you how to index a vector field and perform vector search using .NET SDK.

Here's the list of samples that will show you how to index for vector fields and perform vector search using .NET SDK.

* [Vector Search Using RAW Vector Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingRawVectorQuery.md)
     * [Single Vector Search](LINK)
     * [Single Vector Search With Filter](LINK)
     * [Hybrid Search](LINK)
     * [Multi-vector Search](LINK)
     * [Multi-field Vector Search](LINK)
* [Vector Search Using Vectorizable Text Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md)
     * [Single Vector Search](LINK)
     * [Single Vector Search With Filter](LINK)
     * [Hybrid Search](LINK)
     * [Multi-vector Search](LINK)
     * [Multi-field Vector Search](LINK)
* [Vector Semantic Hybrid Search](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingSemanticHybridQuery.md)
* [Vector Search Using Field Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingFieldBuilder.md)
