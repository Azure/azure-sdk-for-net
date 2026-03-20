# ContentSource — Field grounding references

This sample demonstrates how to access **grounding source references** from analysis results. When the service extracts a field value (e.g., a customer name or invoice total), it also reports *where* in the original content that value was found. These locations are exposed as `ContentSource` objects.

## ContentSource hierarchy

| Class | Wire format | Use case |
|-------|------------|----------|
| `ContentSource` (abstract) | — | Base class; use `ContentSource.Parse()` to create typed instances |
| `DocumentSource` | `D(page,x1,y1,...,xN,yN)` or `D(page)` | Document/image: page number + polygon coordinates + computed `BoundingBox` |
| `AudioVisualSource` | `AV(time[,x,y,w,h])` | Audio/video: timestamp (ms) + optional bounding box |

Multiple source regions are separated by `;` in the raw string. `ContentSource.Parse()` splits them and returns a typed array.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00].

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

## Accessing sources from analysis results

Analyze a document (e.g., an invoice) and iterate over fields to access their grounding sources. Each source identifies the page and precise region where the extracted value appears.

```C# Snippet:ContentUnderstandingContentSourceFromAnalysis
// Analyze an invoice to get fields with grounding sources.
Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");
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

## Parsing raw source strings

`ContentSource.Parse()` converts raw wire-format strings into strongly-typed `DocumentSource` or `AudioVisualSource` instances. This is useful when working with source strings from JSON responses or external storage.

```C# Snippet:ContentUnderstandingContentSourceParse
// ContentSource.Parse() can parse raw source strings into typed instances.
// The raw format uses prefixes: D(...) for documents, AV(...) for audio/video.

// Parse a single document source: page 1 with a 4-point polygon
ContentSource[] docSources = ContentSource.Parse("D(1,0.5712,0.3381,0.7276,0.3381,0.7276,0.3534,0.5712,0.3534)");
DocumentSource doc = (DocumentSource)docSources[0];
Console.WriteLine($"Parsed document source: page {doc.PageNumber}, {doc.Polygon!.Count} polygon points");
Console.WriteLine($"  BoundingBox: {doc.BoundingBox}");

// Parse a page-only document source (no coordinates)
ContentSource[] pageOnlySources = ContentSource.Parse("D(3)");
DocumentSource pageOnly = (DocumentSource)pageOnlySources[0];
Console.WriteLine($"Page-only source: page {pageOnly.PageNumber}, polygon: {(pageOnly.Polygon != null ? "yes" : "none")}");

// Parse an audio/visual source: timestamp at 5000 ms (no bounding box)
ContentSource[] avSources = ContentSource.Parse("AV(5000)");
AudioVisualSource av = (AudioVisualSource)avSources[0];
Console.WriteLine($"Audio/visual source: time {av.Time.TotalMilliseconds} ms, bbox: {(av.BoundingBox.HasValue ? "yes" : "none")}");

// Parse an audio/visual source with bounding box: 5000 ms at (100,200) size 50x60
ContentSource[] avWithBbox = ContentSource.Parse("AV(5000,100,200,50,60)");
AudioVisualSource avBbox = (AudioVisualSource)avWithBbox[0];
Console.WriteLine($"AV with bbox: time {avBbox.Time.TotalMilliseconds} ms, bbox: {avBbox.BoundingBox}");

// Parse multiple segments separated by semicolons
ContentSource[] multiSources = ContentSource.Parse("D(1,0.1,0.2,0.3,0.2,0.3,0.4,0.1,0.4);D(2,0.5,0.6,0.7,0.6,0.7,0.8,0.5,0.8)");
Console.WriteLine($"Multi-segment: {multiSources.Length} sources across pages {((DocumentSource)multiSources[0]).PageNumber} and {((DocumentSource)multiSources[1]).PageNumber}");

// Reconstruct the wire format from parsed sources
string wireFormat = multiSources.ToRawString();
Console.WriteLine($"Reconstructed wire format: {wireFormat}");
```

[sample00]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
