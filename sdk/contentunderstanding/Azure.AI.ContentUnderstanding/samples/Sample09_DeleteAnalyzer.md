# Delete an analyzer

This sample demonstrates how to delete a custom analyzer.

## About deleting analyzers

The `DeleteAnalyzerAsync` method permanently removes a custom analyzer from your resource. This operation cannot be undone.

**Important notes**:
- Only custom analyzers can be deleted. Prebuilt analyzers cannot be deleted.

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

## Create a simple analyzer

First, create a simple analyzer that we'll delete:

```C# Snippet:ContentUnderstandingCreateSimpleAnalyzer
// First create a simple analyzer to delete
// Generate a unique analyzer ID
string analyzerId = $"my_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

// Create a simple analyzer
var analyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Simple analyzer for deletion example",
    Config = new ContentAnalyzerConfig
    {
        ReturnDetails = true
    }
};
analyzer.Models["completion"] = "gpt-4.1";

await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    analyzer,
    allowReplace: true);

Console.WriteLine($"Analyzer '{analyzerId}' created successfully.");
```

## Delete an analyzer

Delete the custom analyzer:

```C# Snippet:ContentUnderstandingDeleteAnalyzer
            // Delete an analyzer
await client.DeleteAnalyzerAsync(analyzerId);
Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
```

## Next steps

You've completed the analyzer management samples! Consider exploring:
- [Sample 01: Analyze binary][sample01] - Analyze documents from files
- [Sample 02: Analyze URL][sample02] - Analyze documents from URLs
- [Sample 03: Analyze invoice][sample03] - Use prebuilt analyzers

## Learn more

- [Content Understanding documentation][cu-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample02]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[sample03]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample08]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample08_UpdateAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/

