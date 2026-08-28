# Fabric Ontology Knowledge Source

This sample demonstrates how to create and use a Fabric Ontology knowledge source. This source connects a knowledge base to a Microsoft Fabric ontology, enabling retrieval over structured business data models. A workspace ID and ontology ID identify the Fabric resource.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Fabric Ontology Knowledge Source

Create a Fabric Ontology knowledge source by providing the Fabric workspace ID and ontology ID.

```C# Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a Fabric Ontology knowledge source.
// This connects the knowledge base to a Microsoft Fabric ontology,
// enabling retrieval over structured business data models.
string knowledgeSourceName = "my-fabric-ontology-source";

// Provide the Fabric workspace ID and ontology ID
string fabricWorkspaceId = Environment.GetEnvironmentVariable("FABRIC_WORKSPACE_ID");
string fabricOntologyId = Environment.GetEnvironmentVariable("FABRIC_ONTOLOGY_ID");

FabricOntologyKnowledgeSource fabricOntologySource = new FabricOntologyKnowledgeSource(
    knowledgeSourceName,
    new FabricOntologyKnowledgeSourceParameters(
        workspaceId: fabricWorkspaceId,
        ontologyId: fabricOntologyId))
{
    Description = "Fabric Ontology knowledge source for business data models"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(fabricOntologySource);
Console.WriteLine($"Created Fabric Ontology knowledge source '{createdSource.Name}'");
```

## Get and List Fabric Ontology Knowledge Sources

Retrieve the Fabric Ontology knowledge source and inspect its workspace and ontology identifiers.

```C# Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_GetAndList
// Get the Fabric Ontology knowledge source back
KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

if (retrievedSource is FabricOntologyKnowledgeSource retrievedOntology)
{
    Console.WriteLine($"  Kind: Fabric Ontology");
    Console.WriteLine($"  Workspace ID: {retrievedOntology.FabricOntologyParameters.WorkspaceId}");
    Console.WriteLine($"  Ontology ID: {retrievedOntology.FabricOntologyParameters.OntologyId}");
}

// List all knowledge sources
await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
{
    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
}
```

## Attach to a Knowledge Base

Create a knowledge base that uses the Fabric Ontology source with a GPT-5.4 model and extractive data output mode.

```C# Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_AttachToKB
// Create a knowledge base that uses the Fabric Ontology source
string knowledgeBaseName = "my-fabric-ontology-kb";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base with Fabric Ontology data",
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
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
Console.WriteLine($"Created knowledge base '{createdBase.Name}' with Fabric Ontology source");
```

## Retrieve from the Knowledge Base

Retrieve content from the knowledge base. Fabric Ontology references include workspace and ontology identifiers. Use `FabricOntologyKnowledgeSourceParams` to enable references.

```C# Snippet:Azure_Search_Tests_Samples_Sample20_FabricOntologyKS_Retrieve
// Retrieve from the knowledge base — queries the Fabric ontology
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the key business entities?"));

// Add per-source runtime parameters with references enabled
request.KnowledgeSourceParams.Add(
    new FabricOntologyKnowledgeSourceParams(knowledgeSourceName)
    {
        IncludeReferences = true,
        IncludeReferenceSourceData = true
    });

// Fabric sources require a query source authorization token.
// Obtain an access token scoped to the search service:
// az account get-access-token --resource https://search.azure.com
string querySourceAuthorization = Environment.GetEnvironmentVariable("SEARCH_QUERY_SOURCE_AUTH");

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(
    request, querySourceAuthorization);
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

// Fabric Ontology references include workspace and ontology identifiers
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");

    if (reference is KnowledgeBaseFabricOntologyReference ontologyRef)
    {
        Console.WriteLine($"  Workspace ID: {ontologyRef.WorkspaceId}");
        Console.WriteLine($"  Ontology ID: {ontologyRef.OntologyId}");
    }
}
```
