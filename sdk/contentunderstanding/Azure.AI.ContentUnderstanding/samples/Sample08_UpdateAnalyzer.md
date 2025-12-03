# Update an analyzer

This sample demonstrates how to update an existing custom analyzer, including updating its description and tags.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 04: Create a custom analyzer][sample04] - Understanding custom analyzers
- [Sample 06: Get analyzer information][sample06] - Understanding analyzer details

## About updating analyzers

The `UpdateAnalyzerAsync` method allows you to modify certain properties of an existing analyzer:
- **Description**: Update the analyzer's description
- **Tags**: Add, update, or remove tags (set tag value to empty string to remove)

**Note**: Not all analyzer properties can be updated. Field schemas, models, and configuration typically cannot be changed after creation. To change these, you may need to delete and recreate the analyzer.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Update an analyzer

Update an analyzer's description and tags:

```C# Snippet:ContentUnderstandingUpdateAnalyzer
// First, get the current analyzer to preserve base analyzer ID
var currentAnalyzer = await client.GetAnalyzerAsync(analyzerId);

// Display current analyzer information
Console.WriteLine("Current analyzer information:");
Console.WriteLine($"  Description: {currentAnalyzer.Value.Description}");
Console.WriteLine($"  Tags: {string.Join(", ", currentAnalyzer.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

// Create an updated analyzer with new description and tags
var updatedAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = currentAnalyzer.Value.BaseAnalyzerId,
    Description = "Updated description"
};

// Update tags (empty string removes a tag)
updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
updatedAnalyzer.Tags["tag2"] = "";  // Remove tag2
updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add tag3

// Update the analyzer
await client.UpdateAnalyzerAsync(analyzerId, updatedAnalyzer);

// Verify the update
var updated = await client.GetAnalyzerAsync(analyzerId);
Console.WriteLine($"Description: {updated.Value.Description}");
Console.WriteLine($"Tags: {string.Join(", ", updated.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
```

## Next steps

- [Sample 09: Delete analyzer][sample09] - Learn how to delete an analyzer

## Learn more

- [Content Understanding Documentation][cu-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_ConfigureDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/






