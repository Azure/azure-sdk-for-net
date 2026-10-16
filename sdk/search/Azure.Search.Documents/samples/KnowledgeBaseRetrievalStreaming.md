# Stream Knowledge Base Retrieval

This sample demonstrates how to consume typed server-sent events from a knowledge base retrieval using one streaming connection. Streaming retrieval is included in the stable `2026-10-01` API.

The stream reports retrieval and activity progress, completed answers and references, and one terminal event. A successful terminal event can report either complete (`200`) or partial (`206`) results. An `error` event is also terminal. The service does not emit token-delta events.

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeBaseRetrievalStreaming_Namespaces
using Azure.Identity;
using Azure.Core;
using System.Net.ServerSentEvents;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Consume Typed Streaming Events

Set `SEARCH_ENDPOINT` and `KNOWLEDGE_BASE_NAME` before running the sample. Authenticate with Microsoft Entra ID using `DefaultAzureCredential`; the knowledge base and its sources must already exist.

The SDK handles SSE framing and comment heartbeats. Enumerate the stream once, correlate activity events by their activity IDs, and continue until the SDK delivers a terminal completion or error event. Pass a cancellation token to stop the request and close the connection.

Known events use generated models whose `Value` property contains the original event payload.
Use `SseItem<T>.EventType` for the event name and to identify terminal `response.completed` or `error`
events. Unknown events retain their event name and raw JSON payload in
`UnknownKnowledgeBaseRetrievalStreamEvent`.

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeBaseRetrievalStreaming_Retrieve
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

KnowledgeBaseRetrievalClient client = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort(),
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Which hotels are best for a luxury stay?"));

Dictionary<int, KnowledgeBaseActivityStartedEvent> activeActivities = new();
string requestId = null;
bool terminalEventReceived = false;
KnowledgeBaseRetrievalStatusCode? completionStatus = null;
KnowledgeBaseErrorDetail streamError = null;
using CancellationTokenSource cancellationSource = new CancellationTokenSource();

try
{
    // RetrieveStreamAsync opens one connection and yields typed server-sent events.
    await foreach (SseItem<KnowledgeBaseRetrievalStreamEvent> item in
        client.RetrieveStreamAsync(request, cancellationToken: cancellationSource.Token))
    {
        switch (item.Data)
        {
            case KnowledgeBaseRetrievalStartedStreamEvent started:
                requestId = started.Value.RequestId;
                Console.WriteLine($"Retrieval {requestId} started for {started.Value.KnowledgeBaseName}.");
                break;

            case KnowledgeBaseActivityStartedStreamEvent activityStarted:
                activeActivities[activityStarted.Value.Id] = activityStarted.Value;
                Console.WriteLine($"Activity {activityStarted.Value.Id} started: {activityStarted.Value.Type}.");
                break;

            case KnowledgeBaseActivityCompletedStreamEvent activityCompleted:
                if (activeActivities.Remove(activityCompleted.Value.Id))
                {
                    Console.WriteLine($"Activity {activityCompleted.Value.Id} completed in {activityCompleted.Value.ElapsedMs} ms.");
                }
                break;

            case KnowledgeBaseAnswerCompletedStreamEvent answerCompleted:
                Console.WriteLine($"Answer message {answerCompleted.Value.MessageIndex} completed.");
                break;

            case KnowledgeBaseReferencesCompletedStreamEvent referencesCompleted:
                foreach (KnowledgeBaseReference reference in referencesCompleted.Value)
                {
                    Console.WriteLine($"Reference {reference.Id} came from activity {reference.ActivitySource}.");
                }
                break;

            case KnowledgeBaseResponseCompletedStreamEvent completed:
                if (completed.Value.StatusCode != KnowledgeBaseRetrievalStatusCode.OK &&
                    completed.Value.StatusCode != KnowledgeBaseRetrievalStatusCode.PartialContent)
                {
                    throw new InvalidDataException($"Unexpected completion status {completed.Value.StatusCode}.");
                }
                Console.WriteLine($"Retrieval completed with status {completed.Value.StatusCode}.");
                completionStatus = completed.Value.StatusCode;
                break;

            case KnowledgeBaseErrorStreamEvent error:
                Console.Error.WriteLine($"Retrieval failed: {error.Value.Error.Code}: {error.Value.Error.Message}");
                streamError = error.Value.Error;
                break;

            case UnknownKnowledgeBaseRetrievalStreamEvent unknown:
                // Preserve unknown events for forward compatibility.
                Console.WriteLine($"Unknown event '{unknown.EventName}': {unknown.Data}");
                break;
        }

        terminalEventReceived = item.EventType is "response.completed" or "error";

        // EventId and ReconnectionInterval contain optional SSE protocol metadata.
        if (!string.IsNullOrEmpty(item.EventId))
        {
            Console.WriteLine($"SSE event ID: {item.EventId}");
        }
        if (item.ReconnectionInterval.HasValue)
        {
            Console.WriteLine($"Suggested reconnect interval: {item.ReconnectionInterval.Value.TotalMilliseconds} ms");
        }
    }
}
catch (OperationCanceledException) when (cancellationSource.IsCancellationRequested)
{
    Console.WriteLine("Streaming retrieval was canceled.");
}
```

Unknown event wrappers preserve the wire event name and raw JSON data so applications can remain forward compatible with future service events.
