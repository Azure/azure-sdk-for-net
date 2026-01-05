# Return raw JSON from analysis

This sample demonstrates how to access the raw JSON response from analysis operations using the convenience method and `GetRawResponse()`. This is useful for scenarios where you need to inspect the full response structure exactly as returned by the service.

## About returning raw JSON

The Content Understanding SDK provides a convenient object model approach (shown in [Sample 03][sample03]) that returns `AnalyzeResult` objects with deeper navigation through the object model. However, sometimes you may need access to the raw JSON response for:

- **Easy inspection**: View the complete response structure in the exact format returned by the service, making it easier to understand the full data model and discover available fields
- **Debugging**: Inspect the raw response to troubleshoot issues, verify service behavior, or understand unexpected results
- **Advanced scenarios**: Work with response structures that may change or include additional metadata not captured in the typed model

**Note**: For most production scenarios, the object model approach is recommended as it provides type safety, IntelliSense support, and easier navigation. Use raw JSON access when you specifically need the benefits listed above.

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

## Analyze and return raw JSON

Use the convenience method and then access the raw response using `GetRawResponse()`:

```C# Snippet:ContentUnderstandingAnalyzeReturnRawJson
string filePath = "<filePath>";
byte[] fileBytes = File.ReadAllBytes(filePath);

// Use convenience method to analyze the document
var operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    BinaryData.FromBytes(fileBytes));

// Get the raw JSON response
var rawResponse = operation.GetRawResponse();
string rawJson = rawResponse.Content.ToString();
```

## Pretty-print raw JSON

Format and display the raw JSON response:

```C# Snippet:ContentUnderstandingParseRawJson
// Pretty-print the raw JSON response
using var jsonDoc = JsonDocument.Parse(rawJson);
string prettyJson = JsonSerializer.Serialize(jsonDoc.RootElement, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(prettyJson);
```

## Next steps

- [Sample 01: Analyze binary][sample01] - Learn the recommended object model approach
- [Sample 10: Analyze configs][sample10] - Learn about extracting features from results

## Learn more

- [Content Understanding documentation][cu-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample10]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[sample03]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
