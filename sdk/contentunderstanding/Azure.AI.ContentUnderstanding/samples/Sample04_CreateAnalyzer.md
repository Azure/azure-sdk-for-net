# Create a custom analyzer

This sample demonstrates how to create a custom analyzer with a field schema to extract structured data from documents. While this sample shows document modalities, custom analyzers can also be created for video, audio, and image content. The same concepts apply across all modalities.

Alternatively, you can create custom analyzers using [Content Understanding Studio][content-understanding-studio-docs], a web-based UI that provides a convenient way to build and test analyzers in the same interface. Content Understanding Studio also allows you to opt-in to in-context learning by providing a knowledge base of labeled data, which can further improve model quality for document-based analyzers.

## About custom analyzers

Custom analyzers allow you to define a field schema that specifies what structured data to extract from documents. You can:
- Define custom fields (string, number, date, object, array)
- Specify extraction methods to control how field values are extracted (see [method][method-docs] for details):
  - **`generate`** - Values are generated freely based on the content using AI models (best for complex or variable fields requiring interpretation)
  - **`classify`** - Values are classified against a predefined set of categories (best when using `enum` with a fixed set of possible values)
  - **`extract`** - Values are extracted as they appear in the content (best for literal text extraction from specific locations). **Note**: This method is only available for document content. Requires `estimateSourceAndConfidence` to be set to `true` for the field.

  When not specified, the system automatically determines the best method based on the field type and description. For more details, see the [Analyzer reference documentation][analyzer-reference-docs].
- Use prebuilt analyzers as a base (see [baseAnalyzerId][baseanalyzerid-docs] for details). Supported base analyzers include:
  - `prebuilt-document` - for document-based custom analyzers
  - `prebuilt-audio` - for audio-based custom analyzers
  - `prebuilt-video` - for video-based custom analyzers
  - `prebuilt-image` - for image-based custom analyzers

  For the complete and up-to-date list of supported base analyzers, see the [Analyzer reference documentation][analyzer-reference-docs].
- Configure analysis options (OCR, layout, formulas)
- Enable source and confidence tracking: Set `estimateFieldSourceAndConfidence` to `true` at the analyzer level (in `ContentAnalyzerConfig`) or `estimateSourceAndConfidence` to `true` at the field level to get source location (page number, bounding box) and confidence scores for extracted field values. This is required for fields with `method` = `extract` and is useful for validation, quality assurance, debugging, and highlighting source text in user interfaces. Field-level settings override analyzer-level settings. For more information, see [estimateSourceAndConfidence][estimate-source-confidence-docs].

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

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

## Create a custom analyzer

`ContentAnalyzer` is the key class to define a custom analyzer. It must be created and passed to `ContentUnderstandingClient.CreateAnalyzerAsync()` to create a custom analyzer.

To define a `ContentAnalyzer`, it requires:
- A `BaseAnalyzerId` (e.g., `"prebuilt-document"`, `"prebuilt-audio"`, `"prebuilt-video"`, `"prebuilt-image"`)
- A unique analyzer ID inside an AI Foundry resource (passed as a separate parameter to `CreateAnalyzerAsync`)
- Optional `Name` (display name for the analyzer)
- Optional `Description` (used as context by the AI model for field extraction, so clear descriptions improve accuracy)
- Required: Define field schema (specifies what structured data to extract)
- Required: Define the configuration (controls how content is processed, such as enabling OCR, layout extraction, etc.)
- Required: Define supported large language models using model names (not model deployments)

For detailed information about analyzer configuration structure, see the [Analyzer reference documentation][analyzer-reference-docs].

Create a custom analyzer with a field schema:

```C# Snippet:ContentUnderstandingCreateAnalyzer
// Generate a unique analyzer ID
string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Define field schema with custom fields
// This example demonstrates three extraction methods:
// - extract: Literal text extraction (requires estimateSourceAndConfidence)
// - generate: AI-generated values based on content interpretation
// - classify: Classification against predefined categories
var fieldSchema = new ContentFieldSchema(
    new Dictionary<string, ContentFieldDefinition>
    {
        ["company_name"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Name of the company"
        },
        ["total_amount"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.Number,
            Method = GenerationMethod.Extract,
            Description = "Total amount on the document"
        },
        ["document_summary"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Generate,
            Description = "A brief summary of the document content"
        },
        ["document_type"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Classify,
            Description = "Type of document"
        }
    })
{
    Name = "company_schema",
    Description = "Schema for extracting company information"
};

// Add enum values for the classify field
fieldSchema.Fields["document_type"].Enum.Add("invoice");
fieldSchema.Fields["document_type"].Enum.Add("receipt");
fieldSchema.Fields["document_type"].Enum.Add("contract");
fieldSchema.Fields["document_type"].Enum.Add("report");
fieldSchema.Fields["document_type"].Enum.Add("other");

// Create analyzer configuration
var config = new ContentAnalyzerConfig
{
    EnableFormula = true,
    EnableLayout = true,
    EnableOcr = true,
    EstimateFieldSourceAndConfidence = true,
    ReturnDetails = true
};

// Create the custom analyzer
var customAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Custom analyzer for extracting company information",
    Config = config,
    FieldSchema = fieldSchema
};

// Add model mappings for supported large language models (required for custom analyzers)
// Maps model roles (completion, embedding) to specific model names
customAnalyzer.Models["completion"] = "gpt-4.1";
customAnalyzer.Models["embedding"] = "text-embedding-3-large";

// Create the analyzer
var operation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    customAnalyzer);

ContentAnalyzer result = operation.Value;
Console.WriteLine($"Analyzer '{analyzerId}' created successfully!");
```

## Use the custom analyzer

After creating the analyzer, you can use it to analyze documents. **In production applications, analyzers are typically created once and reused for multiple document analyses.** They persist in your Content Understanding resource until explicitly deleted.

```C# Snippet:ContentUnderstandingUseCustomAnalyzer
var documentUrl = new Uri("<document_url>");
// Analyze a document using the custom analyzer
var analyzeOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    analyzerId,
    inputs: new[] { new AnalyzeInput { Url = documentUrl } });

var analyzeResult = analyzeOperation.Value;

// Extract custom fields from the result
// Since EstimateFieldSourceAndConfidence is enabled, we can access confidence scores and source information
if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent content)
{
    // Extract field (literal text extraction)
    if (content.Fields.TryGetValue("company_name", out var companyNameField))
    {
        var companyName = companyNameField is StringField sf ? sf.ValueString : null;
        Console.WriteLine($"Company Name (extract): {companyName ?? "(not found)"}");
        Console.WriteLine($"  Confidence: {companyNameField.Confidence?.ToString("F2") ?? "N/A"}");
        Console.WriteLine($"  Source: {companyNameField.Source ?? "N/A"}");
        if (companyNameField.Spans != null && companyNameField.Spans.Count > 0)
        {
            var span = companyNameField.Spans[0];
            Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
        }
    }

    // Extract field (literal text extraction)
    if (content.Fields.TryGetValue("total_amount", out var totalAmountField))
    {
        var totalAmount = totalAmountField is NumberField nf ? nf.ValueNumber : null;
        Console.WriteLine($"Total Amount (extract): {totalAmount?.ToString("F2") ?? "(not found)"}");
        Console.WriteLine($"  Confidence: {totalAmountField.Confidence?.ToString("F2") ?? "N/A"}");
        Console.WriteLine($"  Source: {totalAmountField.Source ?? "N/A"}");
        if (totalAmountField.Spans != null && totalAmountField.Spans.Count > 0)
        {
            var span = totalAmountField.Spans[0];
            Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
        }
    }

    // Generate field (AI-generated value)
    if (content.Fields.TryGetValue("document_summary", out var summaryField))
    {
        var summary = summaryField is StringField sf ? sf.ValueString : null;
        Console.WriteLine($"Document Summary (generate): {summary ?? "(not found)"}");
        Console.WriteLine($"  Confidence: {summaryField.Confidence?.ToString("F2") ?? "N/A"}");
        // Note: Generated fields may not have source information
        if (!string.IsNullOrEmpty(summaryField.Source))
        {
            Console.WriteLine($"  Source: {summaryField.Source}");
        }
    }

    // Classify field (classification against predefined categories)
    if (content.Fields.TryGetValue("document_type", out var documentTypeField))
    {
        var documentType = documentTypeField is StringField sf ? sf.ValueString : null;
        Console.WriteLine($"Document Type (classify): {documentType ?? "(not found)"}");
        Console.WriteLine($"  Confidence: {documentTypeField.Confidence?.ToString("F2") ?? "N/A"}");
        // Note: Classified fields may not have source information
        if (!string.IsNullOrEmpty(documentTypeField.Source))
        {
            Console.WriteLine($"  Source: {documentTypeField.Source}");
        }
    }
}
```

## Delete the analyzer (optional)

**Note:** In production code, you typically keep analyzers and reuse them for multiple analyses. Deletion is mainly useful for:
- Testing and development cleanup
- Removing analyzers that are no longer needed

If you need to delete an analyzer (for example, in test cleanup), you can do so as follows:

```C# Snippet:ContentUnderstandingDeleteCreatedAnalyzer
// Clean up: delete the analyzer (for testing purposes only)
// In production, analyzers are typically kept and reused
await client.DeleteAnalyzerAsync(analyzerId);
Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
```

## Next steps

- [Sample 06: Get analyzer information][sample06] - Learn how to retrieve analyzer details
- [Sample 07: List analyzers][sample07] - Learn how to list all analyzers
- [Sample 08: Update analyzer][sample08] - Learn how to update an existing analyzer
- [Sample 09: Delete analyzer][sample09] - Learn how to delete an analyzer

## Learn more

- [Content Understanding documentation][cu-docs]
- [Create and improve your custom analyzer in Content Understanding Studio][content-understanding-studio-docs] - Learn how to create custom analyzers using the web-based UI with testing and in-context learning capabilities
- [Content Understanding Studio Portal][content-understanding-studio-portal] - Access the web-based UI to create and manage custom analyzers
- [Analyzer reference documentation][analyzer-reference-docs] - Complete reference for analyzer configuration, extraction methods, and field schemas
- [baseAnalyzerId][baseanalyzerid-docs] - Learn about supported base analyzers for custom analyzers
- [method][method-docs] - Learn about extraction methods (extract, generate, classify)
- [estimateSourceAndConfidence][estimate-source-confidence-docs] - Learn about source location and confidence score tracking for extracted fields

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample07]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample07_ListAnalyzers.md
[sample08]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample08_UpdateAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[content-understanding-studio-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/how-to/customize-analyzer-content-understanding-studio?tabs=portal
[content-understanding-studio-portal]: https://contentunderstanding.ai.azure.com/home
[analyzer-reference-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#analyzer-configuration-structure
[baseanalyzerid-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#baseanalyzerid
[method-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#method
[estimate-source-confidence-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#estimatesourceandconfidence

