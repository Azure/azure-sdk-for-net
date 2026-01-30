# Azure Content Understanding client library for .NET

Azure AI Content Understanding is a multimodal AI service that extracts semantic content from documents, video, audio, and image files. It transforms unstructured content into structured, machine-readable data optimized for retrieval-augmented generation (RAG) and automated workflows.

Use the client library for Azure AI Content Understanding to:

* **Extract document content** - Extract text, tables, figures, layout information, and structured markdown from documents (PDF, images with text or hand-written text, Office documents and more)
* **Transcribe and analyze audio** - Convert audio content into searchable transcripts with speaker diarization and timing information
* **Analyze video content** - Extract visual frames, transcribe audio tracks, and generate structured summaries from video files
* **Leverage prebuilt analyzers** - Use production-ready prebuilt analyzers across industries including finance and tax (invoices, receipts, tax forms), identity verification (passports, driver's licenses), mortgage and lending (loan applications, appraisals), procurement and contracts (purchase orders, agreements), and utilities (billing statements)
* **Create custom analyzers** - Build domain-specific analyzers for specialized content extraction needs across all four modalities (documents, video, audio, and images)
* **Classify documents and video** - Automatically categorize and extract information from documents and video by type

[Source code][source_code] | [Package (NuGet)] | [API reference documentation] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the client library for .NET with [NuGet][nuget]:

```bash
dotnet add package Azure.AI.ContentUnderstanding --prerelease
```

### Prerequisites

* An [Azure subscription][azure_subscription].
* A **Microsoft Foundry resource** to use this package.

### Configuring Microsoft Foundry resource

Before using the Content Understanding SDK, you need to set up a Microsoft Foundry resource and deploy the required large language models. Content Understanding currently uses OpenAI GPT models (such as gpt-4.1, gpt-4.1-mini, and text-embedding-3-large).

#### Step 1: Create Microsoft Foundry resource

> **Important:** You must create your Microsoft Foundry resource in a region that supports Content Understanding. For a list of available regions, see [Azure Content Understanding region and language support][cu_region_support].

1. Follow the steps in the [Azure Content Understanding quickstart][cu_quickstart] to create a Microsoft Foundry resource in the Azure portal
2. Get your Foundry resource's endpoint URL from Azure Portal:
   - Go to [Azure Portal][azure_portal]
   - Navigate to your Microsoft Foundry resource
   - Go to **Resource Management** > **Keys and Endpoint**
   - Copy the **Endpoint** URL (typically `https://<your-resource-name>.services.ai.azure.com/`)

**Important: Grant Required Permissions**

After creating your Microsoft Foundry resource, you must grant yourself the **Cognitive Services User** role to enable API calls for setting default model deployments:

1. Go to [Azure Portal][azure_portal]
2. Navigate to your Microsoft Foundry resource
3. Go to **Access Control (IAM)** in the left menu
4. Click **Add** > **Add role assignment**
5. Select the **Cognitive Services User** role
6. Assign it to yourself (or the user/service principal that will run the application)

> **Note:** This role assignment is required even if you are the owner of the resource. Without this role, you will not be able to call the Content Understanding API to configure model deployments for prebuilt analyzers and custom analzyers.

#### Step 2: Deploy required models

**Important:** The prebuilt and custom analyzers require large language model deployments. You must deploy at least these models before using prebuilt analyzers and custom analyzers:
- `prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch` require **gpt-4.1-mini** and **text-embedding-3-large**
- Other prebuilt analyzers like `prebuilt-invoice`, `prebuilt-receipt` require **gpt-4.1** and **text-embedding-3-large**

To deploy a model:

1. In Microsoft Foundry, go to **Deployments** > **Deploy model** > **Deploy base model**
2. Search for and select the model you want to deploy. Currently, prebuilt analyzers require models such as `gpt-4.1`, `gpt-4.1-mini`, and `text-embedding-3-large`
3. Complete the deployment with your preferred settings
4. Note the deployment name you chose (by convention, use the model name as the deployment name, e.g., `gpt-4.1` for the `gpt-4.1` model). You can use any deployment name you prefer, but you'll need to note it for use in Step 3 when configuring model deployments.

Repeat this process for each model required by your prebuilt analyzers.

For more information on deploying models, see [Create model deployments in Microsoft Foundry portal][deploy_models_docs].

#### Step 3: Configure model deployments (required for prebuilt analyzers)

> **IMPORTANT:**  This is a **one-time setup per Microsoft Foundry resource** that maps your deployed models to those required by the prebuilt analyzers and custom models. If you have multiple Microsoft Foundry resources, you need to configure each one separately.

You need to configure the default model mappings in your Microsoft Foundry resource. This can be done programmatically using the SDK. The configuration maps your deployed models (currently gpt-4.1, gpt-4.1-mini, and text-embedding-3-large) to the large language models required by prebuilt analyzers.

To configure model deployments using code, see [Sample 00: Configure model deployment defaults][sample00] for a complete example. The sample shows how to:
- Map your deployed models to the models required by prebuilt analyzers
- Retrieve the current default model deployment configuration


### Authenticate the client

In order to interact with the Content Understanding service, you'll need to create an instance of the `ContentUnderstandingClient` class. To authenticate the client, you need your Microsoft Foundry resource endpoint and credentials. You can use either an API key or Microsoft Entra ID authentication.

#### Using DefaultAzureCredential

The simplest way to authenticate is using `DefaultAzureCredential`, which supports multiple authentication methods and works well in both local development and production environments:

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

#### Using API key

You can also authenticate using an API key from your Microsoft Foundry resource:

```C# Snippet:CreateContentUnderstandingClientApiKey
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

> **⚠️ Security Warning**: API key authentication is less secure and is only recommended for testing purposes with test resources. For production, use `DefaultAzureCredential` or other secure authentication methods.

To get your API key:
1. Go to [Azure Portal][azure_portal]
2. Navigate to your Microsoft Foundry resource
3. Go to **Resource Management** > **Keys and Endpoint**
4. Copy one of the **Keys** (Key1 or Key2)

For more information on authentication, see [Azure Identity client library][azure_identity_readme].

## Key concepts

### Prebuilt analyzers

Content Understanding provides a rich set of prebuilt analyzers that are ready to use without any configuration. These analyzers are powered by knowledge bases of thousands of real-world document examples, enabling them to understand document structure and adapt to variations in format and content.

Prebuilt analyzers are organized into several categories:

* **RAG analyzers** - Optimized for retrieval-augmented generation scenarios with semantic analysis and markdown extraction. These analyzers return markdown and a one-paragraph `Summary` for each content item:
  * **`prebuilt-documentSearch`** - Extracts content from documents (PDF, images, Office documents) with layout preservation, table detection, figure analysis, and structured markdown output. Optimized for RAG scenarios.
  * **`prebuilt-imageSearch`** - Analyzes standalone images and returns a one-paragraph description of the image content. Optimized for image understanding and search scenarios. For images that contain text (including hand-written text), use `prebuilt-documentSearch`.
  * **`prebuilt-audioSearch`** - Transcribes audio content with speaker diarization, timing information, and conversation summaries. Supports multilingual transcription.
  * **`prebuilt-videoSearch`** - Analyzes video content with visual frame extraction, audio transcription, and structured summaries. Provides temporal alignment of visual and audio content and can return multiple segments per video.
* **Content extraction analyzers** - Focus on OCR and layout analysis (e.g., `prebuilt-read`, `prebuilt-layout`)
* **Base analyzers** - Fundamental content processing capabilities used as parent analyzers for custom analyzers (e.g., `prebuilt-document`, `prebuilt-image`, `prebuilt-audio`, `prebuilt-video`)
* **Domain-specific analyzers** - Preconfigured analyzers for common document categories including financial documents (invoices, receipts, bank statements), identity documents (passports, driver's licenses), tax forms, mortgage documents, and contracts
* **Utility analyzers** - Specialized tools for schema generation and field extraction (e.g., `prebuilt-documentFieldSchema`, `prebuilt-documentFields`)

For a complete list of available prebuilt analyzers and their capabilities, see the [Prebuilt analyzers documentation][prebuilt-analyzers-docs].

>
### Content types

The API returns different content types based on the input. Both `DocumentContent` and `AudioVisualContent` classes derive from `MediaContent` class, which provides basic information and markdown representation. Each derived class provides additional properties to access detailed information:

* **`DocumentContent`** - For document files (PDF, HTML, images, Office documents such as Word, Excel, PowerPoint, and more). Provides basic information such as page count and MIME type. Retrieve detailed information including pages, tables, figures, paragraphs, and many others.
* **`AudioVisualContent`** - For audio and video files. Provides basic information such as timing information (start/end times) and frame dimensions (for video). Retrieve detailed information including transcript phrases, timing information, and for video, key frame references and more.

### Asynchronous operations

Content Understanding operations are asynchronous long-running operations. The workflow is:

1. **Begin Analysis** - Start the analysis operation (returns immediately with an operation location)
2. **Poll for Results** - Poll the operation location until the analysis completes
3. **Process Results** - Extract and display the structured results

The SDK provides `Operation<T>` types that handle polling automatically when using `WaitUntil.Completed`. For analysis operations, the SDK returns `Operation<AnalyzeResult>` and provides access to the operation ID via the `Id` property. This operation ID can be used with `GetResultFile*` and `DeleteResult*` methods.

### Main classes

* **`ContentUnderstandingClient`** - The main client for analyzing content, as well as creating, managing, and configuring analyzers
* **`AnalyzeResult`** - Contains the structured results of an analysis operation, including content elements, markdown, and metadata

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

* **Configuration** - Configure model deployment defaults for prebuilt analyzers and custom analyzers
* **Document Content Extraction** - Extract structured markdown content from PDFs and images using `prebuilt-documentSearch`, optimized for RAG (Retrieval-Augmented Generation) applications
* **Multi-Modal Content Analysis** - Analyze content from URLs across all modalities: extract markdown and summaries from documents, images, audio, and video using `prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, and `prebuilt-videoSearch`
* **Domain-Specific Analysis** - Extract structured fields from invoices using `prebuilt-invoice`
* **Advanced Document Features** - Extract charts, hyperlinks, formulas, and annotations from documents
* **Custom Analyzers** - Create custom analyzers with field schemas for specialized extraction needs
* **Labeled Training Data** - [Create custom analyzers with labeled training data][sample16] for enhanced document extraction accuracy
* **Document Classification** - Create and use classifiers to categorize documents
* **Analyzer Management** - Get, list, update, copy, and delete analyzers
* **Result Management** - Retrieve result files from video analysis and delete analysis results

See the [samples directory][samples_directory] for complete examples.

## Troubleshooting

### Common issues

**Error: "Access denied due to invalid subscription key or wrong API endpoint"**
- Verify your `endpoint URL` is correct
- Ensure your `API key` is valid or that your Microsoft Entra ID credentials have the correct permissions
- Make sure you have the **Cognitive Services User** role assigned to your account

**Error: "Model deployment not found" or "Default model deployment not configured"**
- Ensure you have deployed the required models (gpt-4.1, gpt-4.1-mini, text-embedding-3-large) in Microsoft Foundry
- Verify you have configured the default model deployments (see [Configure Model Deployments](#step-3-configure-model-deployments-required-for-prebuilt-analyzers))
- Check that your deployment names match what you configured in the defaults

**Error: "Operation failed" or timeout**
- Content Understanding operations are asynchronous and may take time to complete
- Ensure you are properly polling for results using `WaitUntil.Completed` or manual polling
- Check the operation status for more details about the failure

### Enable logging

To enable logging for debugging, configure logging in your application:

```csharp
using Azure.Core.Diagnostics;

// Enable console logging
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

For more information, see [Diagnostics samples][diagnostics].

## Next steps

* [Sample 00: Configure model deployment defaults][sample00] - Required one-time setup to configure model deployments for prebuilt and custom analyzers
* [Sample 01: Analyze a document from binary data][sample01] - Analyze PDF files from disk using `prebuilt-documentSearch`
* Explore the [samples directory][samples_directory] for complete code examples
* Read the [Azure AI Content Understanding documentation][product_docs] for detailed service information

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][opencode_email] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding

[product_docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[nuget]: https://www.nuget.org/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cu_quickstart]: https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=portal%2Cdocument
[cu_region_support]: https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support
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
[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample16]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample16_CreateAnalyzerWithLabels.md
[prebuilt-analyzers-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[opencode_email]: mailto:opencode@microsoft.com
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
