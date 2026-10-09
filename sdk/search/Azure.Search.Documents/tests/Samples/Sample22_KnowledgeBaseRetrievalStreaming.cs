// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample22_Streaming_Namespaces
using System.Net.ServerSentEvents;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample22_Streaming_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_08_01_Preview)]
    public partial class Sample22_KnowledgeBaseRetrievalStreaming : SearchTestBase
    {
        public Sample22_KnowledgeBaseRetrievalStreaming(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        // The test proxy buffers recorded responses and cannot faithfully replay an incremental SSE stream,
        // including frame delivery, cancellation, and response-stream ownership. Keep this real-transport
        // sample live-only; deterministic SSE playback coverage uses MockTransport in
        // KnowledgeBaseRetrievalClientStreamingTests.
        [LiveOnly]
        public async Task StreamKnowledgeBaseRetrieval()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Tests_Samples_Sample22_Streaming_Retrieve
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
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
#if !SNIPPET
                    Console.WriteLine($"event: {item.EventType}");
                    Console.WriteLine($"type:  {item.Data.GetType().Name}");
                    Console.WriteLine($"data:  {SerializeEventPayload(item.Data)}");
                    Console.WriteLine();
#endif
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

                    terminalEventReceived = item.Data.IsTerminal;

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
            #endregion Snippet:Azure_Search_Tests_Samples_Sample22_Streaming_Retrieve

            Assert.That(requestId, Is.Not.Null.And.Not.Empty);
            Assert.That(activeActivities, Is.Empty);
            Assert.That(terminalEventReceived, Is.True);
            Assert.That(streamError, Is.Null);
            Assert.That(
                completionStatus == KnowledgeBaseRetrievalStatusCode.OK ||
                completionStatus == KnowledgeBaseRetrievalStatusCode.PartialContent,
                Is.True);
        }

        private static string SerializeEventPayload(KnowledgeBaseRetrievalStreamEvent streamEvent)
        {
            BinaryData data = streamEvent switch
            {
                KnowledgeBaseRetrievalStartedStreamEvent started =>
                    ModelReaderWriter.Write(started.Value, ModelReaderWriterOptions.Json),
                KnowledgeBaseActivityStartedStreamEvent activityStarted =>
                    ModelReaderWriter.Write(activityStarted.Value, ModelReaderWriterOptions.Json),
                KnowledgeBaseActivityCompletedStreamEvent activityCompleted =>
                    ModelReaderWriter.Write(activityCompleted.Value, ModelReaderWriterOptions.Json),
                KnowledgeBaseAnswerCompletedStreamEvent answerCompleted =>
                    ModelReaderWriter.Write(answerCompleted.Value, ModelReaderWriterOptions.Json),
                KnowledgeBaseReferencesCompletedStreamEvent referencesCompleted =>
                    BinaryData.FromString($"[{string.Join(",", referencesCompleted.Value.Select(reference => ModelReaderWriter.Write(reference, ModelReaderWriterOptions.Json).ToString()))}]"),
                KnowledgeBaseErrorStreamEvent error =>
                    ModelReaderWriter.Write(error.Value, ModelReaderWriterOptions.Json),
                KnowledgeBaseResponseCompletedStreamEvent completed =>
                    ModelReaderWriter.Write(completed.Value, ModelReaderWriterOptions.Json),
                UnknownKnowledgeBaseRetrievalStreamEvent unknown => unknown.Data,
                _ => throw new InvalidOperationException($"Unsupported streaming event type {streamEvent.GetType().Name}.")
            };

            using JsonDocument document = JsonDocument.Parse(data);
            return JsonSerializer.Serialize(document.RootElement, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
