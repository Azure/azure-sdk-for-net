# Knowledge Retrieval Preview Response

This sample demonstrates preview retrieval features including `maxOutputDocuments` to limit returned documents, `includeActivity` for detailed activity records with model names and token usage, Purview sensitivity labels on references, and switching between `AnswerSynthesis` and `ExtractiveData` output modes.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Retrieve with Activity Records and Purview Labels

Perform a retrieval with `includeActivity` enabled to get detailed activity records (query planning, answer synthesis) that include model names and token counts. Also inspect Purview sensitivity labels on references and the overall response.

```C# Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_WithActivity
// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

// Create a KnowledgeBaseRetrievalClient
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Build a retrieval request with preview features:
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

    if (activity is KnowledgeBaseModelQueryPlanningActivityRecord queryPlanning)
    {
        Console.WriteLine($"  Query Planning - Model: {queryPlanning.Model?.ModelName}");
        Console.WriteLine($"  Input tokens: {queryPlanning.InputTokens}, Output tokens: {queryPlanning.OutputTokens}");
    }
    else if (activity is KnowledgeBaseModelAnswerSynthesisActivityRecord answerSynthesis)
    {
        Console.WriteLine($"  Answer Synthesis - Model: {answerSynthesis.Model?.ModelName}");
        Console.WriteLine($"  Input tokens: {answerSynthesis.InputTokens}, Output tokens: {answerSynthesis.OutputTokens}");
    }
}

// Display references with Purview sensitivity label metadata when available
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}, Score: {reference.RerankerScore}");

    if (reference is KnowledgeBaseSearchIndexReference searchIndexRef)
    {
        Console.WriteLine($"  Document key: {searchIndexRef.DocKey}");

        // Purview sensitivity label metadata is available on search index references
        if (searchIndexRef.SearchSensitivityLabelInfo != null)
        {
            PurviewSensitivityLabelInfo label = searchIndexRef.SearchSensitivityLabelInfo;
            Console.WriteLine($"  Sensitivity label: {label.DisplayName} (ID: {label.SensitivityLabelId})");
            Console.WriteLine($"  Priority: {label.Priority}, Encrypted: {label.IsEncrypted}");
        }
    }
}

// Check for overall response sensitivity label info
if (retrievalResponse.ResponseSensitivityLabelInfo != null)
{
    PurviewSensitivityLabelInfo responseLabel = retrievalResponse.ResponseSensitivityLabelInfo;
    Console.WriteLine($"Response sensitivity label: {responseLabel.DisplayName}");
}
```

## Override Per-Source Retrieval Behavior

A knowledge source can persist `ResultsProcessing`, while a retrieve request can override that setting for one call. `AlwaysQuerySource` and `NeverQuerySource` are request-local controls on `KnowledgeSourceParams`; they do not modify source configuration or knowledge-base membership. Do not combine both controls on the same source.

```C# Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_SourceOverrides
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");
string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Add a second source so each request can exclude one source while
// leaving another source queryable.
string secondarySourceName = "my-secondary-hotels-source";
SearchIndexKnowledgeSource secondarySource = new SearchIndexKnowledgeSource(
    secondarySourceName,
    new SearchIndexKnowledgeSourceParameters(indexName))
{
    ResultsProcessing = KnowledgeSourceResultsProcessing.Rerank
};
KnowledgeSource createdSecondarySource = await indexClient.CreateKnowledgeSourceAsync(secondarySource);
secondarySourceName = createdSecondarySource.Name;

KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
knowledgeBase.KnowledgeSources.Add(new KnowledgeSourceReference(secondarySourceName));
await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);

// Store reranking as the primary source default.
KnowledgeSource primarySource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
primarySource.ResultsProcessing = KnowledgeSourceResultsProcessing.Rerank;
await indexClient.CreateOrUpdateKnowledgeSourceAsync(primarySource);

// Query only the primary source and override its stored reranking
// setting for this request.
KnowledgeBaseRetrievalRequest primaryRequest = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
};
primaryRequest.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find luxury hotels"));
primaryRequest.KnowledgeSourceParams.Add(
    new SearchIndexKnowledgeSourceParams(knowledgeSourceName)
    {
        AlwaysQuerySource = true,
        IncludeReferences = true,
        ResultsProcessing = KnowledgeSourceResultsProcessing.None
    });
primaryRequest.KnowledgeSourceParams.Add(
    new SearchIndexKnowledgeSourceParams(secondarySourceName)
    {
        NeverQuerySource = true
    });

KnowledgeBaseRetrievalResponse primaryResponse =
    await retrievalClient.RetrieveAsync(primaryRequest);

// Reverse the per-source controls for another request. The primary
// source is excluded while the secondary source remains queryable.
KnowledgeBaseRetrievalRequest secondaryRequest = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
};
secondaryRequest.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find luxury hotels"));
secondaryRequest.KnowledgeSourceParams.Add(
    new SearchIndexKnowledgeSourceParams(knowledgeSourceName)
    {
        NeverQuerySource = true
    });
secondaryRequest.KnowledgeSourceParams.Add(
    new SearchIndexKnowledgeSourceParams(secondarySourceName)
    {
        AlwaysQuerySource = true,
        IncludeReferences = true
    });

KnowledgeBaseRetrievalResponse secondaryResponse =
    await retrievalClient.RetrieveAsync(secondaryRequest);

KnowledgeSource persistedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
KnowledgeBase persistedBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
Console.WriteLine($"Stored processing remains: {persistedSource.ResultsProcessing}");
Console.WriteLine($"Knowledge-base source count remains: {persistedBase.KnowledgeSources.Count}");
```

## Retrieve with Extractive Data Mode

Use `ExtractiveData` output mode to return raw extracted content without LLM synthesis. This is useful when you want to process the raw data yourself.

```C# Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_ExtractiveData
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

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

Search Index, Azure Blob, indexed SharePoint, indexed OneLake, File, and indexed SQL references can expose an absolute `CitationUrl`. This URL points to the Search-owned backing document, not directly to the original source URL, and callers must use the required Search authorization when following it. Work IQ, Fabric, web, remote SharePoint, and MCP references are not positive citation-URL cases for this release.

The File citation case requires a package generated from a release input containing hotfix `ce948aaf`; do not claim or test File citation URLs against an unpatched release tip.

```C# Snippet:Azure_Search_Tests_Samples_Sample14_RetrievePreview_CitationUrls
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
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
        // Work IQ, Fabric, web, remote SharePoint, and MCP references
        // are not positive citation-URL cases for this release.
        continue;
    }

    if (!citationUrl.IsAbsoluteUri || citationUrl.Host != endpoint.Host)
    {
        throw new InvalidDataException("Expected an absolute Search-owned citation URL.");
    }

    Console.WriteLine($"{reference.GetType().Name}: {citationUrl}");
}
```
