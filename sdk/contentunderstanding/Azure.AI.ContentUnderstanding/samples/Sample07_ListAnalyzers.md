# List all analyzers

This sample demonstrates how to list all available analyzers in your Microsoft Foundry resource, including both prebuilt and custom analyzers.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 04: Create a custom analyzer][sample04] - Understanding custom analyzers
- [Sample 06: Get analyzer information][sample06] - Understanding analyzer details

## About listing analyzers

The `GetAnalyzersAsync` method returns an async enumerable of all analyzers in your resource, including:
- **Prebuilt analyzers**: System-provided analyzers like `prebuilt-documentSearch`, `prebuilt-invoice`, etc.
- **Custom analyzers**: Analyzers you've created

This is useful for:
- **Discovery**: See what analyzers are available in your resource
- **Management**: Get an overview of all your custom analyzers
- **Debugging**: Verify that analyzers were created successfully

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## List all analyzers

Iterate through all available analyzers:

```C# Snippet:ContentUnderstandingListAnalyzers
// List all analyzers
var analyzers = new List<ContentAnalyzer>();
await foreach (var analyzer in client.GetAnalyzersAsync())
{
    analyzers.Add(analyzer);
}

Console.WriteLine($"Found {analyzers.Count} analyzer(s)");

// Display summary
var prebuiltCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") == true);
var customCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") != true);
Console.WriteLine($"  Prebuilt analyzers: {prebuiltCount}");
Console.WriteLine($"  Custom analyzers: {customCount}");

// Display details for each analyzer
foreach (var analyzer in analyzers)
{
    Console.WriteLine($"  ID: {analyzer.AnalyzerId}");
    Console.WriteLine($"  Description: {analyzer.Description ?? "(none)"}");
    Console.WriteLine($"  Status: {analyzer.Status}");

    if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
    {
        Console.WriteLine("  Type: Prebuilt analyzer");
    }
    else
    {
        Console.WriteLine("  Type: Custom analyzer");
    }
}
```

## Next Steps

- [Sample 08: Update analyzer][sample08] - Learn how to update an existing analyzer
- [Sample 09: Delete analyzer][sample09] - Learn how to delete an analyzer

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Prebuilt Analyzers Documentation][prebuilt-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_ConfigureDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample08]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample08_UpdateAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[prebuilt-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers



