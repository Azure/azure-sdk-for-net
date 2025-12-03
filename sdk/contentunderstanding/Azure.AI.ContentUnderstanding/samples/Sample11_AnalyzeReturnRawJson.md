# Return raw JSON from analysis

This sample demonstrates how to access the raw JSON response from analysis operations using protocol methods. This is useful for advanced scenarios where you need direct access to the JSON structure.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 01: Analyze a document from binary data][sample01] - Basic analysis concepts

## About raw JSON responses

The Content Understanding SDK provides two approaches for accessing analysis results:

1. **Object model approach** (recommended): Returns strongly-typed `AnalyzeResult` objects that are easier to navigate and use. This is shown in [Sample 01][sample01].

2. **Protocol method approach**: Returns raw `BinaryData` containing the JSON response. This sample demonstrates this approach for advanced scenarios.

**Important**: For production use, prefer the object model approach as it provides:
- Type safety
- IntelliSense support
- Easier navigation of results
- Better error handling

Use raw JSON only when you need:
- Custom JSON processing
- Direct access to the raw response structure
- Integration with custom JSON parsers

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Analyze and return raw JSON

Use the protocol method to get raw JSON response:

```C# Snippet:ContentUnderstandingAnalyzeReturnRawJson
string filePath = "<filePath>";
byte[] fileBytes = File.ReadAllBytes(filePath);

// Use protocol method to get raw JSON response
// Note: For production use, prefer the object model approach (AnalyzeBinaryAsync with BinaryData)
// which returns AnalyzeResult objects that are easier to work with
var operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    "application/pdf",
    RequestContent.Create(BinaryData.FromBytes(fileBytes)));

BinaryData responseData = operation.Value;
```

## Parse raw JSON

Parse and format the raw JSON response:

```C# Snippet:ContentUnderstandingParseRawJson
// Parse the raw JSON response
using var jsonDocument = JsonDocument.Parse(responseData);

// Pretty-print the JSON
string prettyJson = JsonSerializer.Serialize(
    jsonDocument.RootElement,
    new JsonSerializerOptions { WriteIndented = true });

// Create output directory if it doesn't exist
string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
Directory.CreateDirectory(outputDir);

// Save to file
string outputFileName = $"analyze_result_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
string outputPath = Path.Combine(outputDir, outputFileName);
File.WriteAllText(outputPath, prettyJson);

Console.WriteLine($"Raw JSON response saved to: {outputPath}");
Console.WriteLine($"File size: {prettyJson.Length:N0} characters");
```

## Comparing approaches: Raw JSON vs object model

The following comparison highlights the difference between the protocol method (raw JSON) and the object model approach:

### Protocol method (raw JSON)

```csharp
// Get raw JSON response
var operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    "application/pdf",
    RequestContent.Create(BinaryData.FromBytes(fileBytes)));

BinaryData responseData = operation.Value;

// Parse JSON manually
using var jsonDocument = JsonDocument.Parse(responseData);
var resultElement = jsonDocument.RootElement.GetProperty("result");
var analyzerId = resultElement.GetProperty("analyzerId").GetString();
```

### Object model (recommended)

```csharp
// Get strongly-typed result
var operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    "application/pdf",
    BinaryData.FromBytes(fileBytes));

AnalyzeResult result = operation.Value;

// Access properties directly
string analyzerId = result.AnalyzerId;
var contents = result.Contents;
```

**Key differences:**
- **Raw JSON**: Requires manual JSON parsing, no type safety, more verbose
- **Object Model**: Strongly-typed properties, IntelliSense support, cleaner code

## Extract information from raw JSON

Extract key information from the parsed JSON:

```C# Snippet:ContentUnderstandingExtractFromRawJson
// Extract key information from raw JSON
var resultElement = jsonDocument.RootElement.GetProperty("result");

if (resultElement.TryGetProperty("analyzerId", out var analyzerIdElement))
{
    Console.WriteLine($"Analyzer ID: {analyzerIdElement.GetString()}");
}

if (resultElement.TryGetProperty("contents", out var contentsElement) &&
    contentsElement.ValueKind == JsonValueKind.Array)
{
    Console.WriteLine($"Contents count: {contentsElement.GetArrayLength()}");

    if (contentsElement.GetArrayLength() > 0)
    {
        var firstContent = contentsElement[0];
        if (firstContent.TryGetProperty("kind", out var kindElement))
        {
            Console.WriteLine($"Content kind: {kindElement.GetString()}");
        }
        if (firstContent.TryGetProperty("mimeType", out var mimeTypeElement))
        {
            Console.WriteLine($"MIME type: {mimeTypeElement.GetString()}");
        }
    }
}
```

## Next steps

- [Sample 01: Analyze binary][sample01] - Learn the recommended object model approach
- [Sample 10: Analyze configs][sample10] - Learn about extracting features from results

## Learn more

- [Content Understanding Documentation][cu-docs]
- [Protocol Methods][protocol-methods-docs] - Learn about protocol methods in Azure SDKs

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_ConfigureDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample10]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[protocol-methods-docs]: https://aka.ms/azsdk/net/protocol-methods

