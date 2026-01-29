# Delete analysis results

This sample demonstrates how to delete analysis results using the `DeleteResult` API. This is useful for removing temporary or sensitive analysis results immediately, rather than waiting for automatic deletion after 24 hours.

## About deleting results

Analysis results from `AnalyzeAsync` or `AnalyzeBinaryAsync` are automatically deleted after 24 hours. However, you may want to delete results earlier in certain cases:

- **Remove sensitive data immediately**: Ensure sensitive information is not retained longer than necessary
- **Comply with data retention policies**: Meet requirements for data deletion

To delete results earlier than the 24-hour automatic deletion, use `ContentUnderstandingClient.DeleteResultAsync`. This method requires the operation ID from the analysis operation (obtained using `Operation<T>.Id`).

**Important**: Once deleted, results cannot be recovered. Make sure you have saved any data you need before deleting.

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

## Analyze and delete result

This sample uses the `prebuilt-invoice` analyzer to analyze an invoice document and extract structured data. After retrieving the analysis result, it uses `DeleteResultAsync` to immediately delete the result to prevent further access. To use `DeleteResultAsync`, you need the operation ID from the analysis operation, which is obtained using `Operation<T>.Id`.

```C# Snippet:ContentUnderstandingAnalyzeAndDeleteResult
// You can replace this URL with your own invoice file URL
Uri documentUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");

// Step 1: Analyze and wait for completion
var analyzeOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-invoice",
    inputs: new[] { new AnalyzeInput { Url = documentUrl } });

// Get the operation ID - this is needed to delete the result later
string operationId = analyzeOperation.Id;
Console.WriteLine($"Operation ID: {operationId}");
AnalyzeResult result = analyzeOperation.Value;
Console.WriteLine("Analysis completed successfully!");

// Display some sample results
DocumentContent documentContent = (DocumentContent)result.Contents!.First();
Console.WriteLine($"Total fields extracted: {documentContent.Fields?.Count ?? 0}");

// Step 2: Delete the analysis result
Console.WriteLine($"Deleting analysis result (Operation ID: {operationId})...");
await client.DeleteResultAsync(operationId);
Console.WriteLine("Analysis result deleted successfully!");
```

## Next steps

- [Sample 12: Get result files][sample12] - Learn how to retrieve result files using operation IDs
- [Sample 01: Analyze binary][sample01] - Learn more about basic document analysis

## Learn more

- [Content Understanding documentation][cu-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample12]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample12_GetResultFile.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/

