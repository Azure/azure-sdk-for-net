# Update an analyzer

This sample demonstrates how to update an existing custom analyzer, including updating its description and tags.

## About updating analyzers

The `UpdateAnalyzerAsync` method allows you to modify certain properties of an existing analyzer. The following properties can be updated:
- **Description**: Update the analyzer's description
- **Tags**: Add or update tags

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

// Update tags
updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
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

- [Content Understanding documentation][cu-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/






