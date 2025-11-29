# Azure ContentUnderstanding client library for .NET

Azure AI Content Understanding is a multimodal AI service that extracts semantic content from documents, audio, and video files. It transforms unstructured content into structured, machine-readable data optimized for retrieval-augmented generation (RAG) and automated workflows.

Use the client library for Azure AI Content Understanding to:

* **Extract document content** - Extract text, tables, figures, layout information, and structured markdown from documents (PDF, images, Office documents)
* **Transcribe and analyze audio** - Convert audio content into searchable transcripts with speaker diarization and timing information
* **Analyze video content** - Extract visual frames, transcribe audio tracks, and generate structured summaries from video files
* **Create custom analyzers** - Build domain-specific analyzers for specialized content extraction needs
* **Classify documents** - Automatically categorize and organize documents by type or content

[Source code][source_code] | [Package (NuGet)] | [API reference documentation][api_reference] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.ContentUnderstanding --prerelease
```

### Prerequisites

> You must have an [Azure subscription][azure_subscription] and a **Microsoft Foundry resource**. To create a Microsoft Foundry resource, follow the steps in the [Azure Content Understanding quickstart][cu_quickstart]. In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK][dotnet_sdk] 3.0 or higher with a [language version][csharp_lang_version] of `latest`.

### Configuring Microsoft Foundry Resource

Before using the Content Understanding SDK, you need to set up a Microsoft Foundry resource and deploy the required GPT models.

#### Step 1: Create Microsoft Foundry Resource

> **Important:** You must create your Microsoft Foundry resource in a region that supports Content Understanding. For a list of available regions, see [Azure Content Understanding region and language support][cu_region_support].

1. Follow the steps in the [Azure Content Understanding quickstart][cu_quickstart] to create a Microsoft Foundry resource in the Azure portal
2. Get your Foundry resource's endpoint URL from Azure Portal:
   - Go to [Azure Portal][azure_portal]
   - Navigate to your Microsoft Foundry resource
   - Go to **Resource Management** > **Keys and Endpoint**
   - Copy the **Endpoint** URL (typically `https://<your-resource-name>.services.ai.azure.com/`)

**Important: Grant Required Permissions**

After creating your Microsoft Foundry resource, you must grant yourself the **Cognitive Services User** role to enable API calls for setting default GPT deployments:

1. Go to [Azure Portal][azure_portal]
2. Navigate to your Microsoft Foundry resource
3. Go to **Access Control (IAM)** in the left menu
4. Click **Add** > **Add role assignment**
5. Select the **Cognitive Services User** role
6. Assign it to yourself (or the user/service principal that will run the application)

> **Note:** This role assignment is required even if you are the owner of the resource. Without this role, you will not be able to call the Content Understanding API to configure model deployments for prebuilt analyzers.

#### Step 2: Deploy Required Models

**Important:** The prebuilt analyzers require model deployments. You must deploy these models before using prebuilt analyzers:
- `prebuilt-documentSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch` require **GPT-4.1-mini** and **text-embedding-3-large**
- Other prebuilt analyzers like `prebuilt-invoice`, `prebuilt-receipt` require **GPT-4.1** and **text-embedding-3-large**

1. **Deploy GPT-4.1:**
   - In Microsoft Foundry, go to **Deployments** > **Deploy model** > **Deploy base model**
   - Search for and select **gpt-4.1**
   - Complete the deployment with your preferred settings
   - Note the deployment name (by convention, use `gpt-4.1`)

2. **Deploy GPT-4.1-mini:**
   - In Microsoft Foundry, go to **Deployments** > **Deploy model** > **Deploy base model**
   - Search for and select **gpt-4.1-mini**
   - Complete the deployment with your preferred settings
   - Note the deployment name (by convention, use `gpt-4.1-mini`)

3. **Deploy text-embedding-3-large:**
   - In Microsoft Foundry, go to **Deployments** > **Deploy model** > **Deploy base model**
   - Search for and select **text-embedding-3-large**
   - Complete the deployment with your preferred settings
   - Note the deployment name (by convention, use `text-embedding-3-large`)

For more information on deploying models, see [Create model deployments in Microsoft Foundry portal][deploy_models_docs].

#### Step 3: Configure Model Deployments (Required for Prebuilt Analyzers)

> **IMPORTANT:** Before using prebuilt analyzers, you must configure the model deployments. This is a **one-time setup per Microsoft Foundry resource** that maps your deployed models to the prebuilt analyzers.

You need to configure the default model mappings in your Microsoft Foundry resource. This can be done programmatically using the SDK or through the Azure Portal. The configuration maps your deployed models (GPT-4.1, GPT-4.1-mini, and text-embedding-3-large) to the prebuilt analyzers that require them.

> **Note:** The configuration is persisted in your Microsoft Foundry resource, so you only need to run this once per resource (or whenever you change your deployment names). If you have multiple Microsoft Foundry resources, you need to configure each one separately.

### Authenticate the client

To authenticate the client, you need your Microsoft Foundry resource endpoint and credentials. You can use either an API key or Azure Active Directory (Azure AD) authentication.

#### Using DefaultAzureCredential

The simplest way to authenticate is using `DefaultAzureCredential`, which supports multiple authentication methods and works well in both local development and production environments:

```C# Snippet:CreateContentUnderstandingClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

#### Using API Key

You can also authenticate using an API key from your Microsoft Foundry resource:

```C# Snippet:CreateContentUnderstandingClientApiKey
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

To get your API key:
1. Go to [Azure Portal][azure_portal]
2. Navigate to your Microsoft Foundry resource
3. Go to **Resource Management** > **Keys and Endpoint**
4. Copy one of the **Keys** (Key1 or Key2)

For more information on authentication, see [Azure Identity client library][azure_identity_readme].

## Key concepts

### Prebuilt Analyzers

Content Understanding provides prebuilt analyzers that are ready to use without any configuration. These analyzers use the `*Search` naming pattern:

* **`prebuilt-documentSearch`** - Extracts content from documents (PDF, images, Office documents) with layout preservation, table detection, figure analysis, and structured markdown output. Optimized for RAG scenarios.
* **`prebuilt-audioSearch`** - Transcribes audio content with speaker diarization, timing information, and conversation summaries. Supports multilingual transcription.
* **`prebuilt-videoSearch`** - Analyzes video content with visual frame extraction, audio transcription, and structured summaries. Provides temporal alignment of visual and audio content.

> **Note:** The prebuilt analyzers use the `prebuilt-{type}Search` naming pattern (not `prebuilt-{type}Analyzer`). This is a recent change in the Content Understanding service.

### Content Types

The API returns different content types based on the input:

* **`document`** - For document files (PDF, images, Office documents). Contains pages, tables, figures, paragraphs, and markdown representation.
* **`audioVisual`** - For audio and video files. Contains transcript phrases, timing information, and for video, visual frame references.

### Asynchronous Operations

Content Understanding operations are asynchronous long-running operations. The workflow is:

1. **Begin Analysis** - Start the analysis operation (returns immediately with an operation location)
2. **Poll for Results** - Poll the operation location until the analysis completes
3. **Process Results** - Extract and display the structured results

The SDK provides `Operation<T>` types that handle polling automatically when using `WaitUntil.Completed`. For analysis operations, the SDK returns `AnalyzeResultOperation`, which extends `Operation<AnalyzeResult>` and provides access to the operation ID via the `Id` property. This operation ID can be used with `GetResultFile*` and `DeleteResult*` methods.

### Main Classes

* **`ContentUnderstandingClient`** - The main client for analyzing content, as well as creating, managing, and configuring analyzers
* **`AnalyzeResult`** - Contains the structured results of an analysis operation, including content elements, markdown, and metadata
* **`AnalyzeResultOperation`** - A long-running operation wrapper for analysis results that provides access to the operation ID

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline][thread_safety_guideline]). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options][client_options] |
[Accessing the response][accessing_response] |
[Long-running operations][long_running_operations] |
[Handling failures][handling_failures] |
[Diagnostics][diagnostics] |
[Mocking][mocking] |
[Client lifetime][client_lifetime]
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples][samples_directory].

The samples demonstrate:

* **Document Analysis** - Extract content from PDFs and images using `prebuilt-documentSearch`
* **Audio Analysis** - Transcribe and analyze audio files using `prebuilt-audioSearch`
* **Video Analysis** - Analyze video content using `prebuilt-videoSearch`
* **Custom Analyzers** - Create domain-specific analyzers for specialized extraction needs
* **Document Classification** - Classify documents by type or content

See the [samples directory][samples_directory] for complete examples.

## Troubleshooting

### Common Issues

**Error: "Access denied due to invalid subscription key or wrong API endpoint"**
- Verify your endpoint URL is correct and includes the trailing slash
- Ensure your API key is valid or that your Azure AD credentials have the correct permissions
- Make sure you have the **Cognitive Services User** role assigned to your account

**Error: "Model deployment not found" or "Default model deployment not configured"**
- Ensure you have deployed the required models (GPT-4.1, GPT-4.1-mini, text-embedding-3-large) in Microsoft Foundry
- Verify you have configured the default model deployments (see [Configure Model Deployments](#step-3-configure-model-deployments-required-for-prebuilt-analyzers))
- Check that your deployment names match what you configured in the defaults

**Error: "Operation failed" or timeout**
- Content Understanding operations are asynchronous and may take time to complete
- Ensure you are properly polling for results using `WaitUntil.Completed` or manual polling
- Check the operation status for more details about the failure

### Enable Logging

To enable logging for debugging, configure logging in your application:

```csharp
using Azure.Core.Diagnostics;

// Enable console logging
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

For more information, see [Diagnostics samples][diagnostics].

## Next steps

* Explore the [samples directory][samples_directory] for complete code examples
* Read the [Azure AI Content Understanding documentation][product_docs] for detailed service information
* Check out the [API reference documentation][api_reference] for detailed API documentation

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][opencode_email] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/src
[api_reference]: https://azure.github.io/azure-sdk-for-net
[product_docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[nuget]: https://www.nuget.org/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cu_quickstart]: https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=portal%2Cdocument
[cu_region_support]: https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support
[dotnet_sdk]: https://dotnet.microsoft.com/download
[csharp_lang_version]: https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default
[azure_portal]: https://portal.azure.com/
[deploy_models_docs]: https://learn.microsoft.com/azure/ai-studio/how-to/deploy-models-openai
[azure_identity_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[thread_safety_guideline]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety
[client_options]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions
[accessing_response]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset
[long_running_operations]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt
[handling_failures]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception
[diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[mocking]: https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking
[client_lifetime]: https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/
[samples_directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[opencode_email]: mailto:opencode@microsoft.com
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
