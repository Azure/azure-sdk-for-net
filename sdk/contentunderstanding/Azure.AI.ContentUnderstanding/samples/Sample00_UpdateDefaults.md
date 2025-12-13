# Configure model deployment defaults

This sample demonstrates how to configure and retrieve default model deployment settings for your Microsoft Foundry resource. This is a **required one-time setup per Microsoft Foundry resource** before using prebuilt or custom analyzers.

## About model deployment configuration

Content Understanding prebuilt analyzers and custom analyzers require specific large language model deployments to function. Currently, Content Understanding uses OpenAI GPT models:

- **gpt-4.1** - Used by most prebuilt analyzers (e.g., `prebuilt-invoice`, `prebuilt-receipt`, `prebuilt-idDocument`)
- **gpt-4.1-mini** - Used by RAG analyzers (e.g., `prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch`)
- **text-embedding-3-large** - Used for semantic search and embeddings

This configuration is **per Microsoft Foundry resource** and persists across sessions. You only need to configure it once per Microsoft Foundry resource (or when you change deployment names).

## Prerequisites

To get started you'll need:

1. An Azure subscription and a **Microsoft Foundry resource**. To create a Microsoft Foundry resource, follow the steps in the [Azure Content Understanding quickstart][cu_quickstart]. You must create your Microsoft Foundry resource in a region that supports Content Understanding. For a list of available regions, see [Azure Content Understanding region and language support][cu_region_support].

2. After creating your Microsoft Foundry resource, you must grant yourself the **Cognitive Services User** role to enable API calls for setting default model deployments. This role assignment is required even if you are the owner of the resource.

3. **Important**: Take note of your Microsoft Foundry resource endpoint and, if you plan to use key-based authentication, the API key. In the Azure Portal, navigate to your Microsoft Foundry resource, go to the "Keys and Endpoint" section, and copy the endpoint URL and API key. A typical endpoint looks like: `https://your-foundry.services.ai.azure.com`. You'll use the endpoint (and API key if using key-based auth) in the "Creating a ContentUnderstandingClient" section below.

4. If you plan to use `DefaultAzureCredential` for authentication, you will need to log in to Azure first. Typically, you can do this by running `az login` (Azure CLI) or `azd login` (Azure Developer CLI) in your terminal.

5. Deploy the following models in Microsoft Foundry:
   - gpt-4.1
   - gpt-4.1-mini
   - text-embedding-3-large


6. **Important**: Take note of the deployment names used for each model. The convention is to use the model names (e.g., "gpt-4.1", "gpt-4.1-mini", "text-embedding-3-large"), but you can change these during deployment. You'll use these deployment names in the "Configure model deployments" section below when configuring defaults.

For detailed instructions on deploying models, see [Create model deployments in Microsoft Foundry portal][deploy_models_docs].

## Creating a `ContentUnderstandingClient`

The `ContentUnderstandingClient` is the main interface for interacting with the Content Understanding service. In this sample, you'll use the client to:
- Update model deployment mappings (`UpdateDefaultsAsync`)
- Retrieve current model deployment defaults (`GetDefaultsAsync`)

To create a new `ContentUnderstandingClient`, use the endpoint (and API key if using key-based authentication) that you noted in step 3. If you plan to use `DefaultAzureCredential`, make sure you have completed step 4 to log in to Azure. You can authenticate using either `DefaultAzureCredential` (recommended) or an API key.

### Using DefaultAzureCredential (recommended)

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

### Using API key

```C# Snippet:CreateContentUnderstandingClientApiKey
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```
> **⚠️ Security Warning**: API key authentication is less secure and is only recommended for testing purposes with test resources. For production, use `DefaultAzureCredential` or other secure authentication methods.

## Configure model deployments

Before you can use prebuilt analyzers or custom analyzers, you need to map your deployed large language models to the models required by these analyzers. Use the endpoint from step 3 and the deployment names from step 6.

The code below defines a dictionary that maps Large Language model names (used by prebuilt analyzers and custom analyzers) to the deployment names that you noted in step 6. The dictionary keys are the model names required by the analyzers, and the values are your actual deployment names.

The models shown below (`gpt-4.1`, `gpt-4.1-mini`, and `text-embedding-3-large`) are the most commonly used models and can be used to run all samples in the SDK. However, each prebuilt analyzer can use different models, and you should consult the [prebuilt analyzers documentation][prebuilt-analyzers-docs] for specific model requirements. When creating your own custom analyzers, you can choose different models based on performance and cost considerations.

The `UpdateDefaultsAsync()` method will take the mapping in the dictionary and update your Microsoft Foundry resource to provide the default deployment for each specific model required by analyzers. Currently, Content Understanding uses OpenAI GPT models:

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
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
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
        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
    }
}
else
{
    Console.WriteLine("  No model deployments configured yet.");
}
```

## Troubleshooting

If the call to `UpdateDefaultsAsync()` fails, the most common reason is that the logged-in credential does not have the **Cognitive Services User** role assigned to your Microsoft Foundry resource. Make sure you have completed step 2 in the Prerequisites section to grant yourself this role.

If you are using `DefaultAzureCredential` for authentication, ensure you have logged in to Azure by running `az login` (Azure CLI) or `azd login` (Azure Developer CLI) as mentioned in step 4.

## Next steps

After configuring model deployments, you can use prebuilt analyzers. See:
- [Sample 01: Analyze a document from binary data][sample01] to analyze PDF files
- [Sample 02: Analyze content from URLs across modalities][sample02] to analyze documents, images, audio, and video from URLs using prebuilt RAG analyzers

## Learn more
- [Content Understanding documentation][cu-docs]
- [Model deployment configuration][model-deployment-docs]

[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample02]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[cu_quickstart]: https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=portal%2Cdocument
[cu_region_support]: https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support
[deploy_models_docs]: https://learn.microsoft.com/azure/ai-studio/how-to/deploy-models-openai
[model-deployment-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=rest-api%2Cdocument
[prebuilt-analyzers-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers


