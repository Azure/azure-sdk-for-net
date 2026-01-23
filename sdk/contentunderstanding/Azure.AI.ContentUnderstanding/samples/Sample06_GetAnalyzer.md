# Get analyzer information

This sample demonstrates how to retrieve information about analyzers, including prebuilt analyzers and custom analyzers.

## About getting analyzer information

The `GetAnalyzerAsync` method allows you to retrieve detailed information about any analyzer, including:
- **Prebuilt analyzers**: System-provided analyzers like `prebuilt-documentSearch`, `prebuilt-invoice`, etc.
- **Custom analyzers**: Analyzers you've created with custom field schemas or classifiers

This is useful for:
- **Verifying analyzer configuration**: Check the current state of an analyzer
- **Inspecting prebuilt analyzers**: Learn about available prebuilt analyzers and their capabilities
- **Debugging**: Understand why an analyzer behaves a certain way

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

## Get prebuilt analyzer information

Retrieve information about a prebuilt analyzer and display the raw response JSON:

```C# Snippet:ContentUnderstandingGetPrebuiltAnalyzer
// Get information about a prebuilt analyzer
var response = await client.GetAnalyzerAsync("prebuilt-documentSearch");
ContentAnalyzer analyzer = response.Value;

// Print a few properties from ContentAnalyzer
Console.WriteLine($"Analyzer ID: {analyzer.AnalyzerId}");
Console.WriteLine($"Base Analyzer ID: {analyzer.BaseAnalyzerId}");
Console.WriteLine($"Description: {analyzer.Description}");
Console.WriteLine($"Enable OCR: {analyzer.Config.EnableOcr}");
Console.WriteLine($"Enable Layout: {analyzer.Config.EnableLayout}");
Console.WriteLine($"Models: {string.Join(", ", analyzer.Models.Select(m => $"{m.Key}={m.Value}"))}");

// Get raw response JSON and format it for nice printing
var rawResponseForJson = response.GetRawResponse();
string rawJson = rawResponseForJson.Content.ToString();
using (JsonDocument doc = JsonDocument.Parse(rawJson))
{
    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
    string formattedJson = JsonSerializer.Serialize(doc, jsonOptions);
    Console.WriteLine("\nPrebuilt-documentSearch Analyzer (Raw JSON):");
    Console.WriteLine(formattedJson);
}
```

You can also get information about other prebuilt analyzers, such as `prebuilt-invoice`. This is particularly useful for inspecting the analyzer's schema to understand its fields and capabilities, including field names, types, and how to access them:

```C# Snippet:ContentUnderstandingGetPrebuiltInvoice
// Get information about prebuilt-invoice analyzer
var invoiceResponse = await client.GetAnalyzerAsync("prebuilt-invoice");
ContentAnalyzer invoiceAnalyzer = invoiceResponse.Value;

// Get raw response JSON and format it for nice printing
var rawResponseForJson = invoiceResponse.GetRawResponse();
string rawJson = rawResponseForJson.Content.ToString();
using (JsonDocument doc = JsonDocument.Parse(rawJson))
{
    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
    string formattedJson = JsonSerializer.Serialize(doc, jsonOptions);
    Console.WriteLine(formattedJson);
}
```

## Get custom analyzer information

Create a custom analyzer, retrieve its information, and display the raw response JSON:

```C# Snippet:ContentUnderstandingGetCustomAnalyzer
string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Define field schema with custom fields
var fieldSchema = new ContentFieldSchema(
    new Dictionary<string, ContentFieldDefinition>
    {
        ["company_name"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Name of the company"
        }
    })
{
    Name = "test_schema",
    Description = "Test schema for GetAnalyzer sample"
};

// Create analyzer configuration
var config = new ContentAnalyzerConfig
{
    ReturnDetails = true
};

// Create the custom analyzer
var analyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Test analyzer for GetAnalyzer sample",
    Config = config,
    FieldSchema = fieldSchema
};
analyzer.Models["completion"] = "gpt-4.1";

// Create the analyzer
await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    analyzer);

try
{
    // Get information about the custom analyzer
    var response = await client.GetAnalyzerAsync(analyzerId);
    ContentAnalyzer retrievedAnalyzer = response.Value;

    // Get raw response JSON and format it for nice printing
    var rawResponseForJson = response.GetRawResponse();
    string rawJson = rawResponseForJson.Content.ToString();
    using (JsonDocument doc = JsonDocument.Parse(rawJson))
    {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string formattedJson = JsonSerializer.Serialize(doc, jsonOptions);
        Console.WriteLine(formattedJson);
    }
```

## Next steps

- [Sample 07: List analyzers][sample07] - Learn how to list all analyzers
- [Sample 08: Update analyzer][sample08] - Learn how to update an existing analyzer
- [Sample 09: Delete analyzer][sample09] - Learn how to delete an analyzer

## Learn more

- [Content Understanding documentation][cu-docs]
- [Prebuilt analyzers documentation][prebuilt-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample05]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample05_CreateClassifier.md
[sample07]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample07_ListAnalyzers.md
[sample08]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample08_UpdateAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[prebuilt-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers

