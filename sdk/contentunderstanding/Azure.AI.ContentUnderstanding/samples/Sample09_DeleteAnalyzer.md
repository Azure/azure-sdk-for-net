# Delete an analyzer

This sample demonstrates how to delete a custom analyzer.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 04: Create a custom analyzer][sample04] - Understanding custom analyzers
- [Sample 08: Update analyzer][sample08] - Understanding analyzer management

## About deleting analyzers

The `DeleteAnalyzerAsync` method permanently removes a custom analyzer from your resource. This operation cannot be undone.

**Important notes**:
- Only custom analyzers can be deleted. Prebuilt analyzers cannot be deleted.
- Deleting an analyzer does not delete analysis results that were created using that analyzer.
- Once deleted, the analyzer ID cannot be reused immediately.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

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
analyzer.Models.Add("completion", "gpt-4.1");

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

## Next Steps

You've completed the analyzer management samples! Consider exploring:
- [Sample 01: Analyze binary][sample01] - Analyze documents from files
- [Sample 02: Analyze URL][sample02] - Analyze documents from URLs
- [Sample 03: Analyze invoice][sample03] - Use prebuilt analyzers

## Learn More

- [Content Understanding Documentation][cu-docs]

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample02]: Sample02_AnalyzeUrl.md
[sample03]: Sample03_AnalyzeInvoice.md
[sample04]: Sample04_CreateAnalyzer.md
[sample08]: Sample08_UpdateAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/

