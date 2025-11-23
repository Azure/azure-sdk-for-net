# Analyze a document from a URL

This sample demonstrates how to analyze a document from a URL using the `prebuilt-documentSearch` analyzer.

> **Before you begin**: This sample builds on concepts introduced in [Sample01_AnalyzeBinary][sample01-analyze-binary]. If you're new to Content Understanding, start with that sample to learn about:
> - Prerequisites and model deployment configuration
> - Creating a `ContentUnderstandingClient` with authentication
> - Extracting markdown content from analysis results
> - Accessing document properties with type-safe APIs

## What's Different from Sample01

This sample shows how to analyze a document from a **publicly accessible URL** instead of a local file. The main difference is using `AnalyzeAsync` with `AnalyzeInput` instead of `AnalyzeBinaryAsync`.

## Analyze a document from a URL

To analyze a document from a URL, use the `AnalyzeAsync` method with an `AnalyzeInput` that specifies the document URL. The returned value is an `AnalyzeResult` object containing data about the submitted document.

> **Note:** Content Understanding operations are asynchronous long-running operations. The SDK handles polling automatically when using `WaitUntil.Completed`.

```C# Snippet:ContentUnderstandingAnalyzeUrlAsync
Uri uriSource = new Uri("<uriSource>");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;
```

After getting the result, you can extract markdown content and access document properties using the same code patterns shown in [Sample01_AnalyzeBinary][sample01-analyze-binary]. The result structure is identical regardless of whether you analyze from binary data or a URL.

The generated sample includes code for extracting markdown and accessing document properties (using the same snippets as Sample01), but this markdown focuses on the URL-specific analysis method.

## Next Steps

- Try analyzing different document types (images, Office documents) from URLs
- Explore other samples in the [samples directory][samples-directory] for more advanced scenarios
- Learn about creating custom analyzers and classifiers

## Learn More

- **[Sample01_AnalyzeBinary][sample01-analyze-binary]** - Learn the basics of document analysis, authentication, and result processing
- **[Content Understanding Overview][cu-overview]** - Comprehensive introduction to the service
- **[Document Overview][cu-document-overview]** - Document analysis capabilities and use cases
- **[Document Markdown][cu-document-markdown]** - Markdown format and structure for document content
- **[Document Elements][cu-document-elements]** - Detailed documentation on document extraction

[sample01-analyze-binary]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[cu-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/overview
[cu-document-overview]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/overview
[cu-document-markdown]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/markdown
[cu-document-elements]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/elements
