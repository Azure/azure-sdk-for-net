# Analyze a document from binary data

This sample demonstrates how to analyze a PDF file from disk using the `prebuilt-documentSearch` analyzer.

## About Content Understanding

Content Understanding supports multiple content types:

- **Documents** - Extract text, tables, figures, layout information, and structured markdown from PDFs, images, and Office documents
- **Images** - Analyze standalone images to generate descriptions, extract visual features, and identify objects and scenes within images
- **Audio** - Transcribe audio content with speaker diarization, timing information, and conversation summaries
- **Video** - Analyze video content with visual frame extraction, audio transcription, and structured summaries

This sample focuses on **document analysis**. For image, audio, and video analysis examples, see other samples in the [samples directory][samples-directory].

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [README][README] for prerequisites and instructions.

### ⚠️ IMPORTANT: Configure Model Deployments First

> **Before using prebuilt analyzers, you MUST configure model deployments for your Microsoft Foundry resource.** This is a **one-time setup per resource** that maps your deployed GPT models to the models required by the prebuilt analyzers. This configuration is persisted in your Microsoft Foundry resource, so you only need to run this once per resource (or whenever you change your deployment names).

The `prebuilt-documentSearch` analyzer requires **GPT-4.1-mini** and **text-embedding-3-large** model deployments. See the [README][README] for detailed instructions on configuring model deployments.

## Prebuilt Analyzers

Content Understanding provides prebuilt analyzers that are ready to use without any configuration. These analyzers use the `*Search` naming pattern:

- **`prebuilt-documentSearch`** - Extracts content from documents (PDF, images, Office documents) with layout preservation, table detection, figure analysis, and structured markdown output. Optimized for RAG scenarios.
- **`prebuilt-imageSearch`** - Analyzes standalone images to generate descriptions, extract visual features, and identify objects and scenes within images. Optimized for image understanding and search scenarios. Note: Image analysis is not optimized for text extraction; use `prebuilt-documentSearch` for documents containing text.
- **`prebuilt-audioSearch`** - Transcribes audio content with speaker diarization, timing information, and conversation summaries. Supports multilingual transcription.
- **`prebuilt-videoSearch`** - Analyzes video content with visual frame extraction, audio transcription, and structured summaries. Provides temporal alignment of visual and audio content.

This sample uses **`prebuilt-documentSearch`** to extract structured content from PDF documents.

## Creating a `ContentUnderstandingClient`

To create a new `ContentUnderstandingClient` you need the endpoint and credentials from your resource. You can authenticate using either `DefaultAzureCredential` (recommended) or an API key.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

### Using DefaultAzureCredential (Recommended)

The simplest way to authenticate is using `DefaultAzureCredential`, which supports multiple authentication methods and works well in both local development and production environments:

```C# Snippet:CreateContentUnderstandingClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

### Using API Key

> **⚠️ Security Warning:** API key authentication is **not secure** for production use. API keys are sensitive credentials that should not be hardcoded or committed to source control. This method is **only recommended for testing purposes with test resources**. For production applications, use `DefaultAzureCredential` or other Azure AD-based authentication methods.

You can authenticate using an API key from your Microsoft Foundry resource:

```C# Snippet:CreateContentUnderstandingClientApiKey
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Analyze a document from binary data

The `prebuilt-documentSearch` analyzer transforms unstructured documents into structured, machine-readable data optimized for RAG scenarios.

To analyze a document from binary data, use the `AnalyzeBinaryAsync` method. The returned value is an `AnalyzeResult` object containing data about the submitted document. Since we're analyzing a document, we'll pass the analyzer ID `prebuilt-documentSearch` to the method.

> **Note:** Content Understanding operations are asynchronous long-running operations. The SDK handles polling automatically when using `WaitUntil.Completed`.

```C# Snippet:ContentUnderstandingAnalyzeBinaryAsync
string filePath = "<filePath>";
byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
BinaryData bytesSource = BinaryData.FromBytes(fileBytes);

Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    "application/pdf",
    bytesSource);

AnalyzeResult result = operation.Value;
```

## Extract Markdown Content

The most common use case for document analysis is extracting markdown content, which is optimized for RAG (Retrieval-Augmented Generation) scenarios. Markdown provides a structured, searchable representation of the document that preserves layout, formatting, and hierarchy while being easily consumable by AI models and search systems.

The `prebuilt-documentSearch` analyzer extracts:

1. **Content Analysis** - Text (printed and handwritten), selection marks, barcodes, mathematical formulas, hyperlinks, and annotations
2. **Figure Analysis** - Descriptions for images/charts/diagrams, converts charts to Chart.js syntax, and diagrams to Mermaid.js syntax
3. **Structure Analysis** - Paragraphs with contextual roles, tables with complex layouts, and hierarchical sections
4. **GitHub Flavored Markdown** - Richly formatted markdown that preserves document structure

```C# Snippet:ContentUnderstandingExtractMarkdown
// A PDF file has only one content element even if it contains multiple pages
MediaContent? content = null;
if (result.Contents == null || result.Contents.Count == 0)
{
    Console.WriteLine("(No content returned from analysis)");
}
else
{
    content = result.Contents.First();
    if (!string.IsNullOrEmpty(content.Markdown))
    {
        Console.WriteLine(content.Markdown);
    }
    else
    {
        Console.WriteLine("(No markdown content available)");
    }
}
```

The markdown output includes structured text with preserved formatting and hierarchy, table representations in markdown format, figure descriptions for images/charts/diagrams, and layout preservation maintaining document structure.

For more information about the markdown format, see [Document Markdown][cu-document-markdown].

## Access Document Properties with Type-Safe APIs

The SDK provides type-safe access to extraction results. Since we're analyzing a PDF document, the content is a `DocumentContent` type, which provides strongly-typed access to document-specific properties. The extraction results are very rich and include many more properties than shown here. The following examples demonstrate just a few ways to access document properties, page information, and structural information like tables. For complete API reference, see the [.NET API documentation][api-docs]. For detailed information about all available document elements and properties, see [Document Elements][cu-document-elements].

```C# Snippet:ContentUnderstandingAccessDocumentProperties
// Check if this is document content to access document-specific properties
if (content is DocumentContent documentContent)
{
    Console.WriteLine($"Document type: {documentContent.MimeType ?? "(unknown)"}");
    Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
    Console.WriteLine($"End page: {documentContent.EndPageNumber}");
    Console.WriteLine($"Total pages: {documentContent.EndPageNumber - documentContent.StartPageNumber + 1}");

    // Check for pages
    if (documentContent.Pages != null && documentContent.Pages.Count > 0)
    {
        Console.WriteLine($"Number of pages: {documentContent.Pages.Count}");
        foreach (var page in documentContent.Pages)
        {
            var unit = documentContent.Unit?.ToString() ?? "units";
            Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
        }
    }

    // Check for tables
    if (documentContent.Tables != null && documentContent.Tables.Count > 0)
    {
        Console.WriteLine($"Number of tables: {documentContent.Tables.Count}");
        int tableCounter = 1;
        foreach (var table in documentContent.Tables)
        {
            Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
            tableCounter++;
        }
    }
}
```

## Learn More

- **[Content Understanding Overview][cu-overview]** - Comprehensive introduction to the service
- **[What's New][cu-whats-new]** - Latest features and updates
- **[Document Overview][cu-document-overview]** - Document analysis capabilities and use cases
- **[Document Markdown][cu-document-markdown]** - Markdown format and structure for document content
- **[Document Elements][cu-document-elements]** - Detailed documentation on document extraction
- **[Audio Overview][cu-audio-overview]** - Audio capabilities and markdown format
- **[Video Overview][cu-video-overview]** - Video capabilities and elements
- **[Image Overview][cu-image-overview]** - Image analysis capabilities

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding#getting-started
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[cu-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/overview
[cu-whats-new]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/whats-new
[cu-document-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/overview
[cu-document-markdown]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/markdown
[cu-document-elements]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/elements
[cu-audio-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/audio/overview
[cu-video-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/video/overview
[cu-image-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/image/overview
[api-docs]: https://learn.microsoft.com/dotnet/api/azure.ai.contentunderstanding

