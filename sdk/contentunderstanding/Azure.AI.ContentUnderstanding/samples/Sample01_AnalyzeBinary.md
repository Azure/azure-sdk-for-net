# Analyze a document from binary data

This sample demonstrates how to analyze a PDF file from disk using the `prebuilt-documentSearch` analyzer.

## About analyzing documents from binary data

One of the key values of Content Understanding is taking a content file and extracting the content for you in one call. The service returns an `AnalyzeResult` that contains an array of `MediaContent` items in `AnalyzeResult.Contents`. This sample starts with a document file, so each item is a `DocumentContent` (a subtype of `MediaContent`) that exposes markdown plus detailed structure such as pages, tables, figures, and paragraphs.

This sample focuses on **document analysis**. For prebuilt RAG analyzers covering images, audio, and video, see [Sample 02: Analyze content from URLs][sample02-analyze-url].

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Prebuilt analyzers

Content Understanding provides prebuilt RAG analyzers (the `prebuilt-*Search` analyzers, such as `prebuilt-documentSearch`) that return markdown and a one-paragraph `Summary` for each content item, making them useful for retrieval-augmented generation (RAG) and other downstream applications:

- **`prebuilt-documentSearch`** - Extracts content from documents (PDF, images, Office documents) with layout preservation, table detection, figure analysis, and structured markdown output. Optimized for RAG scenarios.
- **`prebuilt-audioSearch`** - Transcribes audio content with speaker diarization, timing information, and conversation summaries. Supports multilingual transcription.
- **`prebuilt-videoSearch`** - Analyzes video content with visual frame extraction, audio transcription, and structured summaries. Provides temporal alignment of visual and audio content.
- **`prebuilt-imageSearch`** - Analyzes standalone images and returns a one-paragraph `Summary` of the image content. For images that contain text (including hand-written text), use `prebuilt-documentSearch`.

This sample uses **`prebuilt-documentSearch`** to extract structured content from PDF documents.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00]. Quick reference snippets are below—pick the one that matches the authentication method you plan to use.

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

```C# Snippet:CreateContentUnderstandingClientApiKey
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Analyze a document from binary data

The `prebuilt-documentSearch` analyzer transforms unstructured documents into structured, machine-readable data optimized for RAG scenarios.

To analyze a document from binary data, use the `AnalyzeBinaryAsync` method. The returned value is an `AnalyzeResult` object containing data about the submitted document. Since we're analyzing a document, we'll pass the analyzer ID `prebuilt-documentSearch` to the method.

> **Note:** Content Understanding operations are asynchronous long-running operations. The SDK handles polling automatically when using `WaitUntil.Completed`.

Content Understanding supports many document types including PDF, Word, Excel, PowerPoint, images (including scanned image files with hand-written text), and more. For a complete list of supported file types and limits, see [Service limits][cu-service-limits].

```C# Snippet:ContentUnderstandingAnalyzeBinaryAsync
// Replace with the path to your local document file.
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

Content Understanding generates rich GitHub Flavored Markdown that is ideal for RAG (Retrieval-Augmented Generation) applications or other downstream applications. The markdown output preserves document structure and can include:

- **Structured text** maintaining content and layout
- **Tables** represented in HTML format (supporting merged cells and complex layouts)
- **Charts and diagrams** with charts converted to Chart.js syntax and diagrams to Mermaid.js syntax, including figure descriptions (requires `enableFigureDescription` and `enableFigureAnalysis` configuration)
- **Mathematical formulas** encoded in LaTeX (inline and display)
- **Hyperlinks, barcodes, annotations, and page metadata** for complete document representation (annotations require `returnDetails` configuration)

The `AnalyzeResult.Contents` collection holds the extracted content as `MediaContent` items. A PDF produces a single `MediaContent` entry (even when it has multiple pages), and each `MediaContent` exposes a `Markdown` property so you can read the markdown directly.

The `AnalyzeResult.Contents` collection holds the extracted content as `MediaContent` items. A PDF produces a single `MediaContent` entry (even when it has multiple pages), and each `MediaContent` exposes a `Markdown` property so you can read the markdown directly.

```C# Snippet:ContentUnderstandingExtractMarkdown
// A PDF file has only one content element even if it contains multiple pages
MediaContent content = result.Contents!.First();
Console.WriteLine(content.Markdown);
```

> **Note:** Each prebuilt analyzer and each custom analyzer use configuration to disable or enable different parts of the markdown output. The `prebuilt-documentSearch` analyzer has `enableFormula`, `enableLayout`, `enableOcr`, `enableFigureDescription`, `enableFigureAnalysis`, and `returnDetails` enabled by default, which enables extraction of charts with figure descriptions, formulas, hyperlinks, and annotations. For custom analyzers or to enable additional features, configure these options in `ContentAnalyzerConfig`. See [Sample 10: Analyze documents with configs][sample10] for more details.

This structured markdown format makes documents easily searchable and consumable by AI models while maintaining the original document's layout and semantic structure. For detailed information about all markdown elements and their representation, see [Document analysis: Markdown representation][cu-document-markdown].

## Access document properties

Since we're analyzing a PDF document, the content is a `DocumentContent` type, which provides access to document-specific properties. The extraction results are very rich and include many more properties than shown here. The following examples demonstrate just a few ways to access document properties, page information, and structural information like tables. For detailed information about all available document elements and properties, see [Document elements][cu-document-elements].

Use pattern matching to check if the content is `DocumentContent` to access document-specific properties such as pages, tables, and MIME type.

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
        foreach (DocumentTable table in documentContent.Tables)
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


[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding#getting-started
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample02-analyze-url]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[sample10]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md
[cu-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/overview
[cu-whats-new]: https://learn.microsoft.com/azure/ai-services/content-understanding/whats-new
[cu-document-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/overview
[cu-document-markdown]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/markdown
[cu-document-elements]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/elements
[cu-service-limits]: https://learn.microsoft.com/azure/ai-services/content-understanding/service-limits#document-and-text
