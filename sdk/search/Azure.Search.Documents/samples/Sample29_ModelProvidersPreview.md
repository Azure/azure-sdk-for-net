# Compatible chat models and native GPT-6 retrieval

Use the [common preview setup and hotel corpus](Sample23_NovemberPreview.md).
The complete examples are `CompatibleChatRetrievesSeededEvidence` and
`NativeGpt6RetrievesSeededEvidence` in
[`Sample29_ModelProvidersPreview.cs`](../tests/Samples/Sample29_ModelProvidersPreview.cs).
They use existing deployments, never provision them.

## Select an OpenAI-compatible provider

Configure `AZURE_SEARCH_COMPATIBLE_CHAT_URI` as the **complete HTTPS POST URL**,
including its route and query string; Search does not append an API version/path.
Set `AZURE_SEARCH_COMPATIBLE_CHAT_MODEL` to its supported model profile. Use
exactly one matching authentication choice:
`AZURE_SEARCH_COMPATIBLE_CHAT_HEADERS_JSON` or
`AZURE_SEARCH_COMPATIBLE_CHAT_MI_AUDIENCE`. The latter is a bare third-party
application GUID and requires the Search service's existing identity permissions.
Never print header names/values or transfer a key to an unrelated destination.

```C# Snippet:Azure_Search_Documents_Sample29_CompatibleChat
KnowledgeBaseOpenAICompatibleParameters parameters = new KnowledgeBaseOpenAICompatibleParameters(
    new Uri(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_CHAT_URI")),
    RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_CHAT_MODEL"));
string audience = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_CHAT_MI_AUDIENCE");
string headers = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_CHAT_HEADERS_JSON");
if (!string.IsNullOrWhiteSpace(audience) == !string.IsNullOrWhiteSpace(headers))
{
    throw new InvalidOperationException("Configure exactly one compatible-provider authentication method.");
}
if (!string.IsNullOrWhiteSpace(audience))
{
    parameters.ManagedIdentityAudience = audience;
}
else
{
    foreach (KeyValuePair<string, string> header in JsonSerializer.Deserialize<Dictionary<string, string>>(headers))
    {
        parameters.Headers.Add(header.Key, header.Value);
    }
}
KnowledgeBaseOpenAICompatibleModel model = new KnowledgeBaseOpenAICompatibleModel(parameters);
```

The provider URI/gateway selects the actual model; retrieval omits `model` from
the outbound request body. Existing profiles use Chat Completions; GPT-6 profiles
require Responses with stateless tool continuation. A direct Azure OpenAI-backed
compatible endpoint exercises provider compatibility, **not an APIM gateway**.
An APIM deployment needs its own approved full URI and matching authentication.

## Alternatively select an existing native GPT-6 deployment

Set `SEARCH_GPT6_DEPLOYMENT_NAME` and `SEARCH_GPT6_MODEL_NAME` to the exact existing
deployment and supported profile, which may have different names.
`openAIEndpoint` is the resource root, not a Chat Completions URL.

```C# Snippet:Azure_Search_Documents_Sample29_NativeGpt6
// Use an existing deployment and its exact supported model profile, not a Chat Completions URL.
KnowledgeBaseAzureOpenAIModel model = new KnowledgeBaseAzureOpenAIModel(new AzureOpenAIVectorizerParameters
{
    ResourceUri = new Uri(openAIEndpoint),
    ApiKey = openAIKey,
    DeploymentName = RequiredPreviewSetting("SEARCH_GPT6_DEPLOYMENT_NAME"),
    ModelName = RequiredPreviewSetting("SEARCH_GPT6_MODEL_NAME")
});
string profile = model.AzureOpenAIParameters.ModelName.ToString();
if (!new[] { "gpt-6-astra", "gpt-6-sol", "gpt-6-luna", "gpt-6.1-sol" }.Contains(profile))
{
    throw new InvalidOperationException("Select the supported GPT-6 profile matching the deployment.");
}
```

## Create the source/KB and retrieve seeded evidence

Both alternatives run this same lifecycle using the selected `model`:

```C# Snippet:Azure_Search_Documents_Sample29_ModelRetrieval
await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(sourceName,
    new SearchIndexKnowledgeSourceParameters(indexName)
    {
        SemanticConfigurationName = "hotels",
        SourceDataFields = { new SearchIndexFieldReference("id"), new SearchIndexFieldReference("content") }
    }));
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName,
    new[] { new KnowledgeSourceReference(sourceName) })
{
    Models = { model },
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort(),
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(
    new KnowledgeBaseRetrievalRequest
    {
        Messages =
        {
            new KnowledgeBaseMessage(new[]
            {
                new KnowledgeBaseMessageTextContent("What hotel guest benefits are available?")
            }) { Role = "user" }
        },
        IncludeActivity = true,
        KnowledgeSourceParams =
        {
            new SearchIndexKnowledgeSourceParams(sourceName)
            {
                IncludeReferences = true,
                IncludeReferenceSourceData = true
            }
        }
    });
foreach (KnowledgeBaseSearchIndexReference reference in response.References.OfType<KnowledgeBaseSearchIndexReference>())
{
    Console.WriteLine($"Retrieved seeded hotel: {reference.DocKey}");
}
```

The complete examples check exact reference keys and source text against the
uploaded corpus, activity errors, and compatible-header redaction on GET. A live
retrieval pass verifies integration with that configured deployment; provider
traces, not this client, establish the server-to-provider transport details.
