# Work IQ Knowledge Source

This sample demonstrates how to create and use a Work IQ knowledge source. Work IQ connects a knowledge base to Microsoft 365 work data, enabling retrieval from emails, documents, and other M365 content. Work IQ queries may take 40–60 seconds, so a generous `MaxRuntimeInSeconds` is recommended.

The customer-owned Microsoft Entra application must grant the required delegated Work IQ permission and configure a federated credential that Azure AI Search can use without storing a client secret. The Search service identity and federated credential configuration must satisfy the service requirements before retrieval can succeed. Creating or reading the knowledge source confirms only that the configuration was persisted; it does not prove federation or token exchange.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
```

## Create a Work IQ Knowledge Source

Create a Work IQ knowledge source with customer-owned Entra application authentication. Omit `TenantId` only when the app registration and Search service are in the same tenant; set it for cross-tenant registrations.

```C# Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a Work IQ knowledge source.
// Work IQ connects the knowledge base to Microsoft 365 work data,
// enabling retrieval from emails, documents, and other M365 content.
string knowledgeSourceName = "my-workiq-source";

EntraAppAuthentication entraAuthentication = new EntraAppAuthentication(
    applicationId: Guid.Parse("00000000-0000-0000-0000-000000000000"),
    federatedCredentialId: Guid.Parse("00000000-0000-0000-0000-000000000000"));

// TenantId is optional when the app and Search service use the same
// tenant. Set it explicitly for a cross-tenant app registration.
string tenantId = Environment.GetEnvironmentVariable("WORK_IQ_TENANT_ID");
if (!string.IsNullOrEmpty(tenantId))
{
    entraAuthentication.TenantId = Guid.Parse(tenantId);
}

WorkIQKnowledgeSourceParameters workIqParameters = new WorkIQKnowledgeSourceParameters(entraAuthentication);

WorkIQKnowledgeSource workIqSource = new WorkIQKnowledgeSource(knowledgeSourceName, workIqParameters)
{
    Description = "Work IQ knowledge source for M365 content"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(workIqSource);
Console.WriteLine($"Created Work IQ knowledge source '{createdSource.Name}'");
Console.WriteLine($"  Tenant: {workIqParameters.EntraAppAuthentication.TenantId?.ToString() ?? "Search service tenant"}");
```

## Get and List Work IQ Knowledge Sources

Retrieve a specific Work IQ knowledge source and list all knowledge sources on the service.

```C# Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_GetAndList
// Get the Work IQ knowledge source back
KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

if (retrievedSource is WorkIQKnowledgeSource)
{
    Console.WriteLine($"  Kind: WorkIQ");
}

// List all knowledge sources
await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
{
    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
}
```

## Attach to a Knowledge Base

Create a knowledge base that uses the Work IQ source with extractive data output mode.

```C# Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_AttachToKB
// Create a knowledge base that uses the Work IQ source
string knowledgeBaseName = "my-workiq-kb";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base with Work IQ data",
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
};

string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");
    knowledgeBase.Models.Add(
        new KnowledgeBaseAzureOpenAIModel(
            new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(openAIEndpoint),
                ApiKey = openAIKey,
                DeploymentName = "gpt-5.4-mini",
                ModelName = AzureOpenAIModelName.Gpt54Mini
            }));

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}' with Work IQ source");
```

## Retrieve from the Knowledge Base

Retrieve content from the knowledge base. Work IQ queries M365 data and may take 40–60 seconds. Use `MaxRuntimeInSeconds = 120` and `WorkIQKnowledgeSourceParams` with references enabled. Search query-source authorization and the Work IQ user assertion protect different resources and must be acquired and passed separately.

```C# Snippet:Azure_Search_Tests_Samples_Sample19_WorkIqKS_Retrieve
// Retrieve from the knowledge base — Work IQ queries M365 data.
// Note: Work IQ may take 40-60 seconds, so set a generous maxRuntimeInSeconds.
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true,
    MaxRuntimeInSeconds = 120
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Find recent project status updates"));

// Add per-source runtime parameters with references enabled
request.KnowledgeSourceParams.Add(
    new WorkIQKnowledgeSourceParams(knowledgeSourceName)
    {
        IncludeReferences = true,
        IncludeReferenceSourceData = true
    });

// Search query-source authorization enforces Search document access.
// It is separate from the Work IQ user assertion.
string querySourceAuthorization = Environment.GetEnvironmentVariable("SEARCH_QUERY_SOURCE_AUTH");

// The Work IQ user assertion represents the user for on-behalf-of
// authentication to Work IQ. Do not reuse a Search access token here.
string queryWorkIQSourceAuthorization = Environment.GetEnvironmentVariable("WORK_IQ_USER_ASSERTION");

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(
    request,
    querySourceAuthorization: querySourceAuthorization,
    queryWorkIQSourceAuthorization: queryWorkIQSourceAuthorization);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

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

// Work IQ references point back to M365 content
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");

    if (reference is KnowledgeBaseWorkIQReference workIqRef)
    {
        Console.WriteLine($"  Work IQ reference data:");
        foreach (var kvp in workIqRef.SourceData)
        {
            Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
        }
    }
}
```
