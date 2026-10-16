# Knowledge Retrieval Response

This sample demonstrates how to limit returned documents with `MaxOutputDocuments`, inspect activity records with model names and token usage, switch between `AnswerSynthesis` and `ExtractiveData` output modes, and read citation URLs.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

Set `SEARCH_ENDPOINT` and `KNOWLEDGE_BASE_NAME` to an existing knowledge base backed by a populated hotel search index with semantic search configured. For answer synthesis, configure a model deployment on the knowledge base and grant the Search service's managed identity access to that model, as shown in [Knowledge Base Configuration](./KnowledgeBaseConfiguration.md). The caller needs **Search Index Data Reader** on the Search service.

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeRetrievalResponse_Namespaces
using Azure.Identity;
using Azure.Core;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Retrieve with Activity Records

Enable `IncludeActivity` to inspect search-index retrieval and answer-synthesis activity records alongside references to the source documents. This example supplies an explicit semantic intent, which bypasses model query planning. It reports the knowledge source and relevant document count, plus the synthesis model and token usage.

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeRetrievalResponse_WithActivity
// Get the service endpoint and authenticate with Microsoft Entra ID
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

// Create a KnowledgeBaseRetrievalClient
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Build a retrieval request:
// - maxOutputDocuments to limit the number of documents returned
// - includeActivity to get detailed activity records with model names
// - outputMode to control the response format
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    MaxOutputDocuments = 5,
    IncludeActivity = true,
    OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

// Retrieve relevant content from the knowledge base
Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

// Display the synthesized response
foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
{
    foreach (KnowledgeBaseMessageContent content in message.Content)
    {
        if (content is KnowledgeBaseMessageTextContent textContent)
        {
            Console.WriteLine($"Response: {textContent.Text}");
        }
    }
}

// Display activity records with model names (available when includeActivity = true)
foreach (KnowledgeBaseActivityRecord activity in retrievalResponse.Activity)
{
    Console.WriteLine($"Activity ID: {activity.Id}, Elapsed: {activity.ElapsedMs}ms");

    if (activity is KnowledgeBaseSearchIndexActivityRecord searchIndex)
    {
        Console.WriteLine($"  Knowledge source: {searchIndex.KnowledgeSourceName}");
        Console.WriteLine($"  Relevant documents: {searchIndex.Count}");
    }
    else if (activity is KnowledgeBaseModelAnswerSynthesisActivityRecord answerSynthesis)
    {
        Console.WriteLine($"  Answer Synthesis - Model: {answerSynthesis.Model?.ModelName}");
        Console.WriteLine($"  Input tokens: {answerSynthesis.InputTokens}, Output tokens: {answerSynthesis.OutputTokens}");
    }
}

// Display references to the source documents
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}, Score: {reference.RerankerScore}");

    if (reference is KnowledgeBaseSearchIndexReference searchIndexRef)
    {
        Console.WriteLine($"  Document key: {searchIndexRef.DocKey}");
    }
}
```

## Retrieve with Extractive Data Mode

Use `ExtractiveData` output mode to return raw extracted content without LLM synthesis for further processing. Set `KNOWLEDGE_SOURCE_NAME` to the search-index knowledge source attached to the knowledge base. Request both references and their structured source data explicitly so the example can inspect the returned document fields.

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeRetrievalResponse_ExtractiveData
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");
string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Use ExtractiveData mode to return raw data without LLM synthesis
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    MaxOutputDocuments = 3,
    IncludeActivity = true,
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find budget hotels"));
request.KnowledgeSourceParams.Add(new SearchIndexKnowledgeSourceParams(knowledgeSourceName)
{
    IncludeReferences = true,
    IncludeReferenceSourceData = true
});

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

// In ExtractiveData mode, the response contains raw extracted content
foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
{
    foreach (KnowledgeBaseMessageContent content in message.Content)
    {
        if (content is KnowledgeBaseMessageTextContent textContent)
        {
            Console.WriteLine($"Extracted content: {textContent.Text}");
        }
    }
}

// References are still available with source data
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");
    foreach (var kvp in reference.SourceData)
    {
        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
    }
}
```

## Read Search-Owned Citation URLs

Search Index, Azure Blob, File, indexed SharePoint, indexed OneLake, and indexed SQL references can expose an absolute `CitationUrl`. This URL points to the Search-owned backing document, not directly to the original source URL. Callers must use the required Search authorization when following it.

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeRetrievalResponse_CitationUrls
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest();
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find relevant documents"));

KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
foreach (KnowledgeBaseReference reference in response.References)
{
    Uri citationUrl = reference switch
    {
        KnowledgeBaseSearchIndexReference searchIndex => searchIndex.CitationUrl,
        KnowledgeBaseAzureBlobReference azureBlob => azureBlob.CitationUrl,
        KnowledgeBaseIndexedSharePointReference sharePoint => sharePoint.CitationUrl,
        KnowledgeBaseIndexedOneLakeReference oneLake => oneLake.CitationUrl,
        KnowledgeBaseFileReference file => file.CitationUrl,
        KnowledgeBaseIndexedSqlReference sql => sql.CitationUrl,
        _ => null
    };

    if (citationUrl is null)
    {
        // Some reference kinds do not provide citation URLs.
        continue;
    }

    if (!citationUrl.IsAbsoluteUri || citationUrl.Host != endpoint.Host)
    {
        throw new InvalidDataException("Expected an absolute Search-owned citation URL.");
    }

    Console.WriteLine($"{reference.GetType().Name}: {citationUrl}");
}
```
