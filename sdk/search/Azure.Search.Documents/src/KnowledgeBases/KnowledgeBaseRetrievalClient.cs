// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.KnowledgeBases.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable AZC0004, AZC0015

namespace Azure.Search.Documents.KnowledgeBases
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an knowledge base.
    /// </summary>
    [CodeGenSuppress(nameof(RetrieveStreamAsync), typeof(KnowledgeBaseRetrievalRequest), typeof(string), typeof(CancellationToken))] // Keep the typed streaming convenience overload.
    public partial class KnowledgeBaseRetrievalClient
    {
        /// <summary>
        /// Gets the URI endpoint of the Search service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// Gets the name of the knowledge base.
        /// </summary>
        public virtual string KnowledgeBaseName => _knowledgeBaseName;

        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient. </summary>
        /// <param name="authenticationPolicy"> The authentication policy to use for pipeline creation. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal KnowledgeBaseRetrievalClient(HttpPipelinePolicy authenticationPolicy, Uri endpoint, string knowledgeBaseName, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

            options ??= new SearchClientOptions();

            _endpoint = endpoint;
            _knowledgeBaseName = knowledgeBaseName;
            if (authenticationPolicy != null)
            {
                Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { authenticationPolicy });
            }
            else
            {
                Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>());
            }
            _apiVersion = options.Version.ToVersionString();
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary>
        /// KnowledgeBase retrieves relevant data from backing stores, streaming progress and results as
        /// server-sent events on the same connection as they become available, instead of waiting for the
        /// full retrieval to complete.
        /// </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the request or stream enumeration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <exception cref="InvalidOperationException"> The streaming response did not contain a content stream. </exception>
        /// <returns>
        /// The server-sent events returned by the service. The event name is available from
        /// <see cref="SseItem{T}.EventType"/> and the typed event payload is available from
        /// <see cref="SseItem{T}.Data"/>.
        /// </returns>
#pragma warning disable AZC0004 // Streaming APIs are async-only.
#pragma warning disable AZC0015 // IAsyncEnumerable<T> is the temporary streaming convenience shape.
        [ForwardsClientCalls(true)]
        public virtual async IAsyncEnumerable<SseItem<KnowledgeBaseRetrievalStreamEvent>> RetrieveStreamAsync(
                KnowledgeBaseRetrievalRequest retrievalRequest,
                string querySourceAuthorization = default,
                [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));

            AsyncStreamingResult<SseItem<BinaryData>> result = await RetrieveStreamAsync(
                RequestContent.Create(retrievalRequest),
                querySourceAuthorization,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);

            await using (((IAsyncDisposable)result).ConfigureAwait(false))
            {
                await foreach (SseItem<BinaryData> item in result.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    if (item.Data.ToMemory().Span.SequenceEqual("[DONE]"u8))
                    {
                        yield break;
                    }

                    KnowledgeBaseRetrievalStreamEvent value = DeserializeStreamEvent(item.EventType, item.Data);
                    yield return new SseItem<KnowledgeBaseRetrievalStreamEvent>(value, item.EventType)
                    {
                        EventId = item.EventId,
                        ReconnectionInterval = item.ReconnectionInterval,
                    };

                    if (item.EventType is "response.completed" or "error")
                    {
                        yield break;
                    }
                }
            }

            throw new InvalidDataException("The retrieval stream ended before a terminal event was received.");
        }
#pragma warning restore AZC0015
#pragma warning restore AZC0004

        private static KnowledgeBaseRetrievalStreamEvent DeserializeStreamEvent(string eventName, BinaryData data)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement element = document.RootElement;
            var options = ModelSerializationExtensions.WireOptions;

            // SSE data contains the payload itself, not the generated envelope's JSON "value" property.
            return eventName switch
            {
                "retrieval.started" => new KnowledgeBaseRetrievalStartedStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: KnowledgeBaseRetrievalStartedEvent.DeserializeKnowledgeBaseRetrievalStartedEvent(element, options)),
                "activity.started" => new KnowledgeBaseActivityStartedStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: KnowledgeBaseActivityStartedEvent.DeserializeKnowledgeBaseActivityStartedEvent(element, options)),
                "activity.completed" => new KnowledgeBaseActivityCompletedStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: KnowledgeBaseActivityRecord.DeserializeKnowledgeBaseActivityRecord(element, options)),
                "answer.completed" => new KnowledgeBaseAnswerCompletedStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: KnowledgeBaseAnswerCompletedEvent.DeserializeKnowledgeBaseAnswerCompletedEvent(element, options)),
                "references.completed" => new KnowledgeBaseReferencesCompletedStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: DeserializeStreamReferences(element)),
                "error" => new KnowledgeBaseErrorStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: KnowledgeBaseStreamErrorEvent.DeserializeKnowledgeBaseStreamErrorEvent(element, options)),
                "response.completed" => new KnowledgeBaseResponseCompletedStreamEvent(
                    additionalBinaryDataProperties: null,
                    value: KnowledgeBaseResponseCompletedEvent.DeserializeKnowledgeBaseResponseCompletedEvent(element, options)),
                _ => new UnknownKnowledgeBaseRetrievalStreamEvent(eventName, data),
            };
        }

        private static List<KnowledgeBaseReference> DeserializeStreamReferences(JsonElement element)
        {
            if (element.ValueKind != JsonValueKind.Array)
            {
                throw new JsonException("The references.completed event payload must be a JSON array.");
            }

            List<KnowledgeBaseReference> references = new();
            foreach (JsonElement item in element.EnumerateArray())
            {
                references.Add(KnowledgeBaseReference.DeserializeKnowledgeBaseReference(item, ModelSerializationExtensions.WireOptions));
            }
            return references;
        }
    }
}
