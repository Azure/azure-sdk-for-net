# Configure model deployment defaults

This sample demonstrates how to configure and retrieve default model deployment settings for your Microsoft Foundry resource. This is a **required one-time setup per Microsoft Foundry resource** before using prebuilt or custom analyzers.

## About model deployment configuration

Content Understanding prebuilt analyzers and custom analyzers require generative model deployments to function. The service periodically adds support for more models, including the latest gpt-5.x models such as gpt-5.2, gpt-5.4-mini, gpt-5.5, and others.

- To see the current supported models and models being deprecated, see [Supported generative models][supported_generative_models].
- To see models being retired, see the [Foundry model retirement schedule][model_retirement_schedule].

In the following sample, we use **gpt-5.2** and **text-embedding-3-large** as an example.

This configuration is **per Microsoft Foundry resource** and persists across sessions. You only need to configure it once per Microsoft Foundry resource (or when you change deployment names).

## Prerequisites

To get started you'll need:

1. An Azure subscription and a **Microsoft Foundry resource**. To create a Microsoft Foundry resource, follow the steps in the [Azure Content Understanding quickstart][cu_quickstart]. You must create your Microsoft Foundry resource in a region that supports Content Understanding. For a list of available regions, see [Azure Content Understanding region and language support][cu_region_support].

2. After creating your Microsoft Foundry resource, you must grant yourself the **Cognitive Services User** role to enable API calls for setting default model deployments. This role assignment is required even if you are the owner of the resource.

3. **Important**: Take note of your Microsoft Foundry resource endpoint and, if you plan to use key-based authentication, the API key. In the Azure Portal, navigate to your Microsoft Foundry resource, go to the "Keys and Endpoint" section, and copy the endpoint URL and API key. A typical endpoint looks like: `https://your-foundry.services.ai.azure.com`. You'll use the endpoint (and API key if using key-based auth) in the "Creating a ContentUnderstandingClient" section below.

4. If you plan to use `DefaultAzureCredential` for authentication, you will need to log in to Azure first. Typically, you can do this by running `az login` (Azure CLI) or `azd login` (Azure Developer CLI) in your terminal.

5. Deploy supported generative models in Microsoft Foundry. This sample uses:
    - gpt-5.2
    - text-embedding-3-large

   For the current list of supported (and deprecated) models, see [Supported generative models][supported_generative_models].

6. **Important**: Take note of the deployment names used for each model. The convention is to use the model names (e.g., "gpt-5.2", "text-embedding-3-large"), but you can change these during deployment. You'll use these deployment names in the "Configure model deployments" section below when configuring defaults.

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

The code below defines a dictionary that maps model names and prebuilt analyzer aliases to the deployment names that you noted in step 6. The dictionary keys are the model names or aliases required by the analyzers, and the values are your actual deployment names.

The models shown below (`gpt-5.2` and `text-embedding-3-large`) are examples that can be used to run the samples in this SDK. Other supported gpt-5.x models may also work depending on current service support. Prebuilt analyzers reference aliases: most use `prebuilt-analyzer-completion`, `prebuilt-*Search` analyzers use `prebuilt-analyzer-completion-mini`, and analyzers requiring embeddings use `prebuilt-analyzer-embedding`. Map these aliases even when they point to the same deployments as the concrete model names. See [Supported generative models][supported_generative_models] and [model deployment guidance][model-deployment-docs] for current requirements.

The `UpdateDefaultsAsync()` method will take the mapping in the dictionary and update your Microsoft Foundry resource to provide the default deployment for each specific model required by analyzers.

```C# Snippet:ContentUnderstandingUpdateDefaults
// Map your deployed models to the models required by prebuilt analyzers
var modelDeployments = new Dictionary<string, string>
{
    ["gpt-5.2"] = "<your-gpt-5.2-deployment-name>",
    ["text-embedding-3-large"] = "<your-text-embedding-3-large-deployment-name>",
    ["prebuilt-analyzer-completion"] = "<your-gpt-5.2-deployment-name>",
    ["prebuilt-analyzer-completion-mini"] = "<your-gpt-5.2-deployment-name>",
    ["prebuilt-analyzer-embedding"] = "<your-text-embedding-3-large-deployment-name>"
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
- [Supported generative models][supported_generative_models]
- [Foundry model retirement schedule][model_retirement_schedule]

[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample02]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[cu_quickstart]: https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=portal%2Cdocument
[cu_region_support]: https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support
[deploy_models_docs]: https://learn.microsoft.com/azure/ai-studio/how-to/deploy-models-openai
[model-deployment-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/models-deployments
[supported_generative_models]: https://learn.microsoft.com/azure/ai-services/content-understanding/service-limits#supported-generative-models
[model_retirement_schedule]: https://learn.microsoft.com/azure/foundry/openai/concepts/model-retirement-schedule
[prebuilt-analyzers-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers


