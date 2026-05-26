# Copy an analyzer

This sample demonstrates how to copy an analyzer from source to target within the same Microsoft Foundry resource using the `CopyAnalyzer` API. This is useful for creating copies of analyzers for testing, staging, or production deployment.

## About copying analyzers

The `CopyAnalyzer` API allows you to copy an analyzer within the same Azure resource:

- **Same-resource copy**: Copies an analyzer from one ID to another within the same resource
- **Exact copy**: The target analyzer is an exact copy of the source analyzer

**Note**: For cross-resource copying (copying between different Azure resources or subscriptions), use the [GrantCopyAuth sample][sample15] instead.

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

## Copy an analyzer

Create a source analyzer and copy it to a target. First, create the source analyzer (see [Sample 04][sample04] for details on creating analyzers), then copy it:

```C# Snippet:ContentUnderstandingCopyAnalyzer
await client.CopyAnalyzerAsync(
    WaitUntil.Completed,
    targetAnalyzerId,
    sourceAnalyzerId);
```

After copying, get the target analyzer, update it with a production tag, and verify the update:

```C# Snippet:ContentUnderstandingUpdateAndVerifyAnalyzer
// Get the target analyzer first to get its BaseAnalyzerId
var targetResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
ContentAnalyzer targetAnalyzer = targetResponse.Value;

// Update the target analyzer with a production tag
var updatedAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = targetAnalyzer.BaseAnalyzerId
};
updatedAnalyzer.Tags["modelType"] = "model_in_production";

await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedAnalyzer);

// Get the target analyzer again to verify the update
var updatedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
ContentAnalyzer updatedTargetAnalyzer = updatedResponse.Value;
Console.WriteLine($"Updated target analyzer description: {updatedTargetAnalyzer.Description}");
Console.WriteLine($"Updated target analyzer tag: {updatedTargetAnalyzer.Tags["modelType"]}");
```

Finally, clean up by deleting both analyzers:

```C# Snippet:ContentUnderstandingDeleteCopiedAnalyzers
try
{
    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
}
catch
{
    // Ignore cleanup errors
}

try
{
    await client.DeleteAnalyzerAsync(targetAnalyzerId);
    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
}
catch
{
    // Ignore cleanup errors
}
```

## Next steps

- [Sample 15: Grant copy authorization][sample15] - Learn how to copy analyzers across resources
- [Sample 04: Create analyzer][sample04] - Learn more about creating custom analyzers
- [Sample 09: Delete analyzer][sample09] - Learn about analyzer lifecycle management

## Learn more

- [Content Understanding documentation][cu-docs]
- [Analyzer management][analyzer-docs] - Learn about managing analyzers

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample09]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[sample15]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample15_GrantCopyAuth.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[analyzer-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference

