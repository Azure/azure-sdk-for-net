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

### ⚠️ IMPORTANT: Configure model deployments first

> **Before using prebuilt analyzers, you MUST configure model deployments for your Microsoft Foundry resource.** This is a **one-time setup per resource** that maps your deployed large language models to the models required by the prebuilt analyzers. Currently, Content Understanding uses OpenAI GPT models. This configuration is persisted in your Microsoft Foundry resource, so you only need to run this once per resource (or whenever you change your deployment names).

The `prebuilt-documentSearch` analyzer requires **gpt-4.1-mini** and **text-embedding-3-large** model deployments. See the [README][README] for detailed instructions on configuring model deployments.

## Prebuilt analyzers

Content Understanding provides prebuilt analyzers that are ready to use without any configuration. These analyzers use the `*Search` naming pattern:

- **`prebuilt-documentSearch`** - Extracts content from documents (PDF, images, Office documents) with layout preservation, table detection, figure analysis, and structured markdown output. Optimized for RAG scenarios.
- **`prebuilt-imageSearch`** - Analyzes standalone images to generate descriptions, extract visual features, and identify objects and scenes within images. Optimized for image understanding and search scenarios. Note: Image analysis is not optimized for text extraction; use `prebuilt-documentSearch` for documents containing text.
- **`prebuilt-audioSearch`** - Transcribes audio content with speaker diarization, timing information, and conversation summaries. Supports multilingual transcription.
- **`prebuilt-videoSearch`** - Analyzes video content with visual frame extraction, audio transcription, and structured summaries. Provides temporal alignment of visual and audio content.

This sample uses **`prebuilt-documentSearch`** to extract structured content from PDF documents.

## Creating a `ContentUnderstandingClient`

To create a new `ContentUnderstandingClient` you need the endpoint and credentials from your resource. You can authenticate using either `DefaultAzureCredential` (recommended) or an API key.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

### Using DefaultAzureCredential (recommended)

The simplest way to authenticate is using `DefaultAzureCredential`, which supports multiple authentication methods and works well in both local development and production environments:

```C# Snippet:CreateContentUnderstandingClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

### Using API key

> **⚠️ Security Warning:** API key authentication is **less secure** for production use. API keys are sensitive credentials that should not be hardcoded or committed to source control. This method is **only recommended for testing purposes with test resources**. For production applications, use `DefaultAzureCredential` or other Microsoft Entra ID-based authentication methods.

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
// Replace with the path to your local document file.
// Content Understanding supports many document types including PDF, Word, Excel, PowerPoint, images (including scanned image files with hand-written text), and more.
// For a complete list of supported file types and limits, see:
// https://learn.microsoft.com/azure/ai-services/content-understanding/service-limits#document-and-text
string filePath = "<localDocumentFilePath>";
byte[] fileBytes = File.ReadAllBytes(filePath);
BinaryData binaryData = BinaryData.FromBytes(fileBytes);

Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    binaryData);

AnalyzeResult result = operation.Value;
```

## Extract markdown content

The most common use case for document analysis is extracting markdown content, which is optimized for RAG (Retrieval-Augmented Generation) scenarios. Markdown provides a structured, searchable representation of the document that preserves layout, formatting, and hierarchy while being easily consumable by AI models and search systems.

The `prebuilt-documentSearch` analyzer extracts:

1. **Content Analysis** - Text (printed and handwritten), selection marks, barcodes, mathematical formulas, hyperlinks, and annotations
2. **Figure Analysis** - Descriptions for images/charts/diagrams, converts charts to Chart.js syntax, and diagrams to Mermaid.js syntax
3. **Structure Analysis** - Paragraphs with contextual roles, tables with complex layouts, and hierarchical sections
4. **GitHub Flavored Markdown** - Richly formatted markdown that preserves document structure

```C# Snippet:ContentUnderstandingExtractMarkdown
// A PDF file has only one content element even if it contains multiple pages
MediaContent content = result.Contents!.First();
Console.WriteLine(content.Markdown);
```

Content Understanding generates rich GitHub Flavored Markdown that is ideal for RAG (Retrieval-Augmented Generation) applications or other downstream applications. The markdown output preserves document structure and can include:

- **Structured text** maintaining content and layout
- **Tables** represented in HTML format (supporting merged cells and complex layouts)
- **Charts and diagrams** with charts converted to Chart.js syntax and diagrams to Mermaid.js syntax, including figure descriptions (requires `enableFigureDescription` and `enableFigureAnalysis` configuration)
- **Mathematical formulas** encoded in LaTeX (inline and display)
- **Hyperlinks, barcodes, annotations, and page metadata** for complete document representation (annotations require `returnDetails` configuration)

> **Note:** Each prebuilt analyzer and each custom analyzer use configuration to disable or enable different parts of the markdown output. The `prebuilt-documentSearch` analyzer has `enableFormula`, `enableLayout`, `enableOcr`, `enableFigureDescription`, `enableFigureAnalysis`, and `returnDetails` enabled by default, which enables extraction of charts with figure descriptions, formulas, hyperlinks, and annotations. For custom analyzers or to enable additional features, configure these options in `ContentAnalyzerConfig`. See [Sample 10: Analyze documents with configs][sample10] for more details.

This structured markdown format makes documents easily searchable and consumable by AI models while maintaining the original document's layout and semantic structure. For detailed information about all markdown elements and their representation, see [Document analysis: Markdown representation][cu-document-markdown].

## Access document properties

Since we're analyzing a PDF document, the content is a `DocumentContent` type, which provides access to document-specific properties. The extraction results are very rich and include many more properties than shown here. The following examples demonstrate just a few ways to access document properties, page information, and structural information like tables. For detailed information about all available document elements and properties, see [Document elements][cu-document-elements].

```C# Snippet:ContentUnderstandingAccessDocumentProperties
// Check if this is document content to access document-specific properties
if (content is DocumentContent documentContent)
{
    Console.WriteLine($"Document type: {documentContent.MimeType ?? "(unknown)"}");
    Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
    Console.WriteLine($"End page: {documentContent.EndPageNumber}");

    // Check for pages
    if (documentContent.Pages != null && documentContent.Pages.Count > 0)
    {
        Console.WriteLine($"Number of pages: {documentContent.Pages.Count}");
        foreach (DocumentPage page in documentContent.Pages)
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

## Next steps

- **[Sample02_AnalyzeUrl][sample02-analyze-url]** - Learn how to analyze documents from publicly accessible URLs
- Explore other samples in the [samples directory][samples-directory] for more advanced scenarios

## Learn more

- **[Content Understanding overview][cu-overview]** - Comprehensive introduction to the service
- **[What's new][cu-whats-new]** - Latest features and updates
- **[Document overview][cu-document-overview]** - Document analysis capabilities and use cases
- **[Document markdown][cu-document-markdown]** - Markdown format and structure for document content
- **[Document elements][cu-document-elements]** - Detailed documentation on document extraction
- **[Audio overview][cu-audio-overview]** - Audio capabilities and markdown format
- **[Video overview][cu-video-overview]** - Video capabilities and elements
- **[Image overview][cu-image-overview]** - Image analysis capabilities

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding#getting-started
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[sample02-analyze-url]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[sample10]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md
[cu-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/overview
[cu-whats-new]: https://learn.microsoft.com/azure/ai-services/content-understanding/whats-new
[cu-document-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/overview
[cu-document-markdown]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/markdown
[cu-document-elements]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/elements
[cu-audio-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/audio/overview
[cu-video-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/video/overview
[cu-image-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/image/overview
