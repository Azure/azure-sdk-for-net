# Delete analysis results

This sample demonstrates how to delete analysis results using the `DeleteResult` API. This is useful for removing temporary or sensitive analysis results immediately, rather than waiting for automatic deletion after 24 hours.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 01: Analyze a document from binary data][sample01] - Basic analysis concepts
- [Sample 12: Get result files][sample12] - Understanding operation IDs

## About deleting results

Analysis results are stored temporarily and can be deleted using the `DeleteResult` API:

- **Immediate deletion**: Results are marked for deletion and permanently removed
- **Automatic deletion**: Results are automatically deleted after 24 hours if not manually deleted
- **Operation ID required**: You need the operation ID from the analysis operation to delete the resulthttps://learn.microsoft.com/azure/ai-services/content-understanding/concepts/operations

**Important**: Once deleted, results cannot be recovered. Make sure you have saved any data you need before deleting.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Analyze and delete result

Analyze a document and then delete the result:

```C# Snippet:ContentUnderstandingAnalyzeAndDeleteResult
Uri documentUrl = new Uri("<documentUrl>");

// Step 1: Start the analysis operation
var analyzeOperation = await client.AnalyzeAsync(
    WaitUntil.Started,
    "prebuilt-invoice",
    inputs: new[] { new AnalyzeInput { Url = documentUrl } });
// Get the operation ID from the operation (available after Started)
string operationId = analyzeOperation.Id;
Console.WriteLine($"Operation ID: {operationId}");

// Wait for completion
await analyzeOperation.WaitForCompletionAsync();
AnalyzeResult result = analyzeOperation.Value;
Console.WriteLine("Analysis completed successfully!");

// Display some sample results
if (result.Contents?.FirstOrDefault() is DocumentContent docContent && docContent.Fields != null)
{
    Console.WriteLine($"Total fields extracted: {docContent.Fields.Count}");
    if (docContent.Fields.TryGetValue("CustomerName", out var customerNameField) && customerNameField is StringField sf)
    {
        Console.WriteLine($"Customer Name: {sf.ValueString ?? "(not found)"}");
    }
}

// Step 2: Delete the analysis result
Console.WriteLine($"Deleting analysis result (Operation ID: {operationId})...");
await client.DeleteResultAsync(operationId);
Console.WriteLine("Analysis result deleted successfully!");
```

## When to delete results

Delete results when you need to:
- **Remove sensitive data immediately**: Ensure sensitive information is not retained longer than necessary
- **Free up storage**: Remove results that are no longer needed
- **Comply with data retention policies**: Meet requirements for data deletion

**Note**: Results are automatically deleted after 24 hours if not manually deleted. Manual deletion is only needed if you want to remove results immediately.

## Next Steps

- [Sample 12: Get result files][sample12] - Learn how to retrieve result files using operation IDs
- [Sample 01: Analyze binary][sample01] - Learn more about basic document analysis

## Learn More

- [Content Understanding Documentation][cu-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_ConfigureDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample12]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample12_GetResultFile.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/

