# ContentSource — Field grounding references

This sample demonstrates how to access **grounding source references** from analysis results. When the service extracts a field value (e.g., a customer name or invoice total), it also reports *where* in the original content that value was found. These locations are exposed as `ContentSource` objects.

## ContentSource hierarchy

| Class | Wire format | Use case |
|-------|------------|----------|
| `ContentSource` (abstract) | — | Base class; use `ContentSource.Parse()` to create typed instances |
| `DocumentSource` | `D(page,x1,y1,...,xN,yN)` or `D(page)` | Document/image: page number + polygon coordinates + computed `BoundingBox` |

Multiple source regions are separated by `;` in the raw string. `ContentSource.Parse()` splits them and returns a typed array. For example, a field spanning two regions on page 1:

```
D(1,0.10,0.20,0.50,0.20,0.50,0.25,0.10,0.25);D(1,0.10,0.30,0.50,0.30,0.50,0.35,0.10,0.35)
```

```csharp
// Parse a multi-segment source string into individual DocumentSource instances.
string rawSource = field.Sources.ToRawString();    // e.g. "D(1,...);D(1,...)"
ContentSource[] sources = ContentSource.Parse(rawSource);
// sources.Length == 2, each is a DocumentSource with its own page + polygon
```

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00].

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

## Accessing sources from analysis results

Analyze a document (e.g., an invoice) and iterate over fields to access their grounding sources. Each source identifies the page and precise region where the extracted value appears.

```C# Snippet:ContentUnderstandingContentSourceFromAnalysis
// Analyze an invoice to get fields with grounding sources.
Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");
Operation<AnalysisResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-invoice",
    inputs: new[] { new AnalysisInput { Uri = invoiceUrl } });

AnalysisResult result = operation.Value;
DocumentContent documentContent = (DocumentContent)result.Contents!.First();

// Iterate over all fields and access their grounding sources.
foreach (var kvp in documentContent.Fields)
{
    string fieldName = kvp.Key;
    ContentField field = kvp.Value;

    Console.WriteLine($"Field: {fieldName} = {field.Value}");

    // Sources identify where the field value appears in the original content.
    // For documents, each source is a DocumentSource with page number and polygon.
    if (field.Sources != null)
    {
        foreach (ContentSource source in field.Sources)
        {
            if (source is DocumentSource docSource)
            {
                Console.WriteLine($"  Source: page {docSource.PageNumber}");

                // Polygon: the precise region (rotated quadrilateral) around the text.
                if (docSource.Polygon != null)
                {
                    string coords = string.Join(", ", docSource.Polygon.Select(p => $"({p.X:F4},{p.Y:F4})"));
                    Console.WriteLine($"  Polygon: [{coords}]");
                }

                // BoundingBox: axis-aligned rectangle computed from the polygon —
                // convenient for drawing highlight overlays.
                if (docSource.BoundingBox.HasValue)
                {
                    RectangleF bbox = docSource.BoundingBox.Value;
                    Console.WriteLine($"  BoundingBox: x={bbox.X:F4}, y={bbox.Y:F4}, w={bbox.Width:F4}, h={bbox.Height:F4}");
                }
            }
        }
    }
}
```

## Round-tripping source strings with Parse and ToRawString

Use `ToRawString()` to convert parsed `ContentSource` objects back to their wire format, and `ContentSource.Parse()` to re-parse them. This is useful when serializing source references for storage or transmission.

```C# Snippet:ContentUnderstandingContentSourceParse
// Get the grounding source from a real analysis result and round-trip it.
// Find a field that has grounding sources.
ContentField fieldWithSource = documentContent.Fields.Values
    .First(f => f.Sources != null);

// Convert the parsed sources back to their wire-format string using ToRawString().
string sourceString = fieldWithSource.Sources!.ToRawString();
Console.WriteLine($"Source wire format: {sourceString}");

// Parse the wire-format string back into typed ContentSource instances.
ContentSource[] roundTripped = ContentSource.Parse(sourceString);
DocumentSource roundTrippedDoc = (DocumentSource)roundTripped[0];
Console.WriteLine($"Round-tripped: page {roundTrippedDoc.PageNumber}, polygon points: {roundTrippedDoc.Polygon?.Count ?? 0}");
Console.WriteLine($"  BoundingBox: {roundTrippedDoc.BoundingBox}");

// Find a field with multiple source segments (e.g., multi-line addresses).
ContentField multiSourceField = documentContent.Fields.Values
    .First(f => f.Sources != null && f.Sources.Length > 1);
string multiSourceString = multiSourceField.Sources!.ToRawString();
Console.WriteLine($"Multi-segment wire format: {multiSourceString}");

ContentSource[] multiParsed = ContentSource.Parse(multiSourceString);
Console.WriteLine($"Multi-segment: {multiParsed.Length} sources on pages {string.Join(", ", multiParsed.OfType<DocumentSource>().Select(s => s.PageNumber))}");

// ContentSource.Parse() also handles page-only format (no polygon coordinates).
// Construct a page-only source string from a real field's page number.
int realPageNumber = ((DocumentSource)fieldWithSource.Sources![0]).PageNumber;
ContentSource[] pageOnlySources = ContentSource.Parse($"D({realPageNumber})");
DocumentSource pageOnly = (DocumentSource)pageOnlySources[0];
Console.WriteLine($"Page-only source: page {pageOnly.PageNumber}, polygon: {(pageOnly.Polygon != null ? "yes" : "none")}");
```

[sample00]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
