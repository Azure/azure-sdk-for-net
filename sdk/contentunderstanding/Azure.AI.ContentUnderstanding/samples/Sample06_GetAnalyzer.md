# Get analyzer information

This sample demonstrates how to retrieve information about analyzers, including prebuilt analyzers and custom analyzers.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 04: Create a custom analyzer][sample04] - Understanding custom analyzers
- [Sample 05: Create and use a classifier][sample05] - Understanding classifiers

## About getting analyzer information

The `GetAnalyzerAsync` method allows you to retrieve detailed information about any analyzer, including:
- **Prebuilt analyzers**: System-provided analyzers like `prebuilt-documentSearch`, `prebuilt-invoice`, etc.
- **Custom analyzers**: Analyzers you've created with custom field schemas or classifiers

This is useful for:
- **Verifying analyzer configuration**: Check the current state of an analyzer
- **Inspecting prebuilt analyzers**: Learn about available prebuilt analyzers and their capabilities
- **Debugging**: Understand why an analyzer behaves a certain way

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Get prebuilt analyzer information

Retrieve information about a prebuilt analyzer and display the full JSON:

```C# Snippet:ContentUnderstandingGetPrebuiltAnalyzer
// Get information about a prebuilt analyzer
var response = await client.GetAnalyzerAsync("prebuilt-documentSearch");
ContentAnalyzer analyzer = response.Value;

// Display full analyzer JSON
var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
};
string analyzerJson = JsonSerializer.Serialize(analyzer, jsonOptions);
Console.WriteLine("Prebuilt-documentSearch Analyzer:");
Console.WriteLine(analyzerJson);
```

You can also get information about other prebuilt analyzers, such as `prebuilt-invoice`:

```C# Snippet:ContentUnderstandingGetPrebuiltInvoice
// Get information about prebuilt-invoice analyzer
var invoiceResponse = await client.GetAnalyzerAsync("prebuilt-invoice");
ContentAnalyzer invoiceAnalyzer = invoiceResponse.Value;

// Display full analyzer JSON
var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
};
string invoiceAnalyzerJson = JsonSerializer.Serialize(invoiceAnalyzer, jsonOptions);
Console.WriteLine("Prebuilt-invoice Analyzer:");
Console.WriteLine(invoiceAnalyzerJson);
```

## Get custom analyzer information

Create a custom analyzer, retrieve its information, and display the full JSON:

```C# Snippet:ContentUnderstandingGetCustomAnalyzer
// First, create a custom analyzer (see Sample 04 for details)
string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

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

var config = new ContentAnalyzerConfig
{
    ReturnDetails = true
};

var analyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Test analyzer for GetAnalyzer sample",
    Config = config,
    FieldSchema = fieldSchema
};
analyzer.Models.Add("completion", "gpt-4.1");

// Create the analyzer
await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    analyzer);

// Get information about the custom analyzer
var response = await client.GetAnalyzerAsync(analyzerId);
ContentAnalyzer retrievedAnalyzer = response.Value;

// Display full analyzer JSON
var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
};
string analyzerJson = JsonSerializer.Serialize(retrievedAnalyzer, jsonOptions);
Console.WriteLine("Custom Analyzer:");
Console.WriteLine(analyzerJson);
```

## Next Steps

- [Sample 07: List analyzers][sample07] - Learn how to list all analyzers
- [Sample 08: Update analyzer][sample08] - Learn how to update an existing analyzer
- [Sample 09: Delete analyzer][sample09] - Learn how to delete an analyzer

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Prebuilt Analyzers Documentation][prebuilt-docs]

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample04]: Sample04_CreateAnalyzer.md
[sample05]: Sample05_CreateClassifier.md
[sample07]: Sample07_ListAnalyzers.md
[sample08]: Sample08_UpdateAnalyzer.md
[sample09]: Sample09_DeleteAnalyzer.md
[cu-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/
[prebuilt-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/prebuilt-analyzer

