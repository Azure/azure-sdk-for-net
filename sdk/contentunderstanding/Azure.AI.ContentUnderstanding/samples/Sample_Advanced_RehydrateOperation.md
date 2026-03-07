# Rehydrate a long-running operation

This sample demonstrates how to use **rehydration tokens** to persist the state of a long-running analysis operation and resume polling from a different process or after a restart. This is an advanced scenario useful for building resilient, distributed systems.

## When to use rehydration

Rehydration is valuable when:

- **You can't keep the process alive** — The analysis might take seconds to minutes, and you need to free the calling thread (e.g., a web API request handler).
- **You need cross-process handoff** — Start the operation in one service (e.g., a web API) and poll for completion in another (e.g., a background worker or Azure Function).
- **You want crash resilience** — Persist the operation state so it survives application restarts.

## How it works

1. Start the analysis with `WaitUntil.Started` (returns immediately after the server accepts the request).
2. Call `GetRehydrationToken()` on the returned operation to capture the polling state.
3. Serialize and persist the token (e.g., to a database, queue message, or file).
4. In another process (or after a restart), call `Operation.RehydrateAsync()` with the saved token to reconstruct the operation and resume polling.

The `RehydrationToken` is a lightweight struct (~300 bytes serialized as JSON) that contains the polling URI, operation ID, HTTP method, and other metadata needed to reconstruct the operation's state machine.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00].

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

## Two-process rehydration example

This example shows two separate programs: **Process A** starts the analysis and saves the rehydration token to a file, then **Process B** (which could be a completely different application) reads the token and resumes polling.

### Process A — Start analysis and save token

This process starts the analysis, gets the rehydration token, and writes it to a shared file. After saving the token, it can exit — the operation continues running on the server.

```csharp
// ProcessA/Program.cs — Start the operation and save the rehydration token to a file
using System.ClientModel.Primitives;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;

string endpoint = "<endpoint>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());

Uri documentUrl = new Uri("https://example.com/my-document.pdf");

// Start the analysis without waiting for completion.
Operation<AnalysisResult> operation = await client.AnalyzeAsync(
    WaitUntil.Started,
    "prebuilt-read",
    inputs: new[] { new AnalysisInput { Uri = documentUrl } });

Console.WriteLine($"Operation started with ID: {operation.Id}");

// Get the rehydration token — captures the full operation state.
RehydrationToken tokenValue = operation.GetRehydrationToken()!.Value;

// Save the token to a file. In production, you might use a database or message queue.
string tokenFilePath = Path.Combine(Path.GetTempPath(), $"cu-operation-{operation.Id}.json");
File.WriteAllText(tokenFilePath, ModelReaderWriter.Write(tokenValue).ToString());
Console.WriteLine($"Token saved to: {tokenFilePath}");

// Process A can now exit. The operation continues running on the server.
```

### Process B — Read token, resume polling, and get results

This process reads the token file written by Process A, rehydrates the operation, resumes polling, and accesses the extracted markdown content.

```csharp
// ProcessB/Program.cs — Read the saved token, resume polling, and get the results
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

string endpoint = "<endpoint>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());

// Read the token from the file saved by Process A.
string tokenFilePath = args[0]; // Pass the token file path as a command-line argument
string savedToken = File.ReadAllText(tokenFilePath);

// Deserialize the token back into a RehydrationToken struct.
RehydrationToken restoredToken = ModelReaderWriter
    .Read<RehydrationToken>(BinaryData.FromString(savedToken))!;
Console.WriteLine($"Token loaded. Operation ID: {restoredToken.Id}");

// Rehydrate the operation — reconstructs the polling state machine
// without re-sending the original request.
Operation rehydratedOp = await Operation.RehydrateAsync(client.Pipeline, restoredToken);
Console.WriteLine($"Operation rehydrated. Completed: {rehydratedOp.HasCompleted}");

// Resume polling until the operation completes.
Response completionResponse = await rehydratedOp.WaitForCompletionResponseAsync();
Console.WriteLine($"Operation completed: {rehydratedOp.HasCompleted}");

// Parse the result from the response body.
// The LRO response contains a "result" property with the AnalysisResult.
using JsonDocument document = JsonDocument.Parse(completionResponse.Content);
JsonElement resultElement = document.RootElement.GetProperty("result");
AnalysisResult result = ModelReaderWriter.Read<AnalysisResult>(
    BinaryData.FromString(resultElement.GetRawText()))!;

// Access the extracted markdown content.
foreach (AnalysisContent content in result.Contents!)
{
    Console.WriteLine($"--- Content (MIME: {content.MimeType}) ---");
    Console.WriteLine(content.Markdown);
}

// Clean up.
File.Delete(tokenFilePath);
```

### Running the example

```bash
# Terminal 1 — Start the operation
dotnet run --project ProcessA

# Terminal 2 — Resume polling (pass the token file path printed by Process A)
dotnet run --project ProcessB -- /tmp/cu-operation-<id>.json
```

## Next steps

- **[Sample 02: Analyze content from URLs][sample02]** - Analyze documents, images, audio, and video from URLs
- **[Sample 12: Get result files][sample12]** - Retrieve generated files (e.g., keyframes) from analysis results
- Explore more scenarios in the [samples directory][samples-directory]

## Learn more

- **[Content Understanding overview][cu-overview]** - Service capabilities and scenarios
- **[Azure SDK long-running operations][azure-sdk-lro]** - How the Azure SDK handles long-running operations
- **[RehydrationToken API reference][rehydration-token-ref]** - API reference for `RehydrationToken`

[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample02]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[sample12]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample12_GetResultFile.md
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[cu-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/overview
[azure-sdk-lro]: https://devblogs.microsoft.com/azure-sdk/updated-guidance-on-azure-long-running-operations/
[rehydration-token-ref]: https://learn.microsoft.com/dotnet/api/azure.core.rehydrationtoken?view=azure-dotnet
