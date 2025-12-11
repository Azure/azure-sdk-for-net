# Configure model deployment defaults

This sample demonstrates how to configure and retrieve default model deployment settings for your Microsoft Foundry resource. This is a **required one-time setup** before using prebuilt or custom analyzers.

## About model deployment configuration

Content Understanding prebuilt analyzers require specific large language model deployments to function. Currently, Content Understanding uses OpenAI GPT models:

- **gpt-4.1** - Used by most prebuilt analyzers (e.g., `prebuilt-invoice`, `prebuilt-receipt`, `prebuilt-idDocument`)
- **gpt-4.1-mini** - Used by RAG analyzers (e.g., `prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch`)
- **text-embedding-3-large** - Used for semantic search and embeddings

This configuration is **per Microsoft Foundry resource** and persists across sessions. You only need to configure it once per Microsoft Foundry resource (or when you change deployment names).

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [README][README] for prerequisites and instructions.

You also need to have deployed the following models in Microsoft Foundry:
- gpt-4.1
- gpt-4.1-mini
- text-embedding-3-large

## Creating a `ContentUnderstandingClient`

The `ContentUnderstandingClient` is the main interface for interacting with the Content Understanding service. In this sample, you'll use the client to:
- Retrieve current model deployment defaults (`GetDefaultsAsync`)
- Update model deployment mappings (`UpdateDefaultsAsync`)

To create a new `ContentUnderstandingClient` you need the endpoint and credentials from your Microsoft Foundry resource. You can authenticate using either `DefaultAzureCredential` (recommended) or an API key.

### Using DefaultAzureCredential (recommended)

```C# Snippet:CreateContentUnderstandingClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

### Using API key

```C# Snippet:CreateContentUnderstandingClientApiKey
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```
> **⚠️ Security Warning**: API key authentication is less secure and is only recommended for testing purposes with test resources. For production, use `DefaultAzureCredential` or other secure authentication methods.

## Configure model deployments

Before you can use prebuilt analyzers, you need to map your deployed large language models to the models required by the prebuilt analyzers. Currently, Content Understanding uses OpenAI GPT models:

```C# Snippet:ContentUnderstandingUpdateDefaults
// Map your deployed models to the models required by prebuilt analyzers
var modelDeployments = new Dictionary<string, string>
{
    ["gpt-4.1"] = "<your-gpt-4.1-deployment-name>",
    ["gpt-4.1-mini"] = "<your-gpt-4.1-mini-deployment-name>",
    ["text-embedding-3-large"] = "<your-text-embedding-3-large-deployment-name>"
};

var response = await client.UpdateDefaultsAsync(modelDeployments);
ContentUnderstandingDefaults updatedDefaults = response.Value;

Console.WriteLine("Model deployments configured successfully!");
foreach (var kvp in updatedDefaults.ModelDeployments)
{
    Console.WriteLine($"  {kvp.Key} → {kvp.Value}");
}
```

## Retrieve current defaults

You can retrieve the current default model deployment configuration:

```C# Snippet:ContentUnderstandingGetDefaults
var getResponse = await client.GetDefaultsAsync();
ContentUnderstandingDefaults defaults = getResponse.Value;

Console.WriteLine("Current model deployment mappings:");
if (defaults.ModelDeployments != null && defaults.ModelDeployments.Count > 0)
{
    foreach (var kvp in defaults.ModelDeployments)
    {
        Console.WriteLine($"  {kvp.Key} → {kvp.Value}");
    }
}
else
{
    Console.WriteLine("  No model deployments configured yet.");
}
```

## Next steps

After configuring model deployments, you can use prebuilt analyzers. See:
- [Sample 01: Analyze a document from binary data][sample01] to analyze PDF files
- [Sample 02: Analyze a document from URL][sample02] to analyze documents from URLs

## Learn more
- [Content Understanding documentation][cu-docs]
- [Model deployment configuration][model-deployment-docs]

[README]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/README.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample02]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[model-deployment-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=portal%2Cdocument

