// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
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

#pragma warning disable AZC0004, AZC0015

namespace Azure.Search.Documents.KnowledgeBases
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an knowledge base.
    /// </summary>
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

        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient from a <see cref="KnowledgeBaseRetrievalClientSettings"/>. </summary>
        /// <param name="settings"> The settings for KnowledgeBaseRetrievalClient. </param>
        [Experimental("SCME0002")]
        public KnowledgeBaseRetrievalClient(KnowledgeBaseRetrievalClientSettings settings) : this(settings?.Endpoint, settings?.KnowledgeBaseName, settings?.CredentialProvider as TokenCredential, settings?.Options)
        {
        }

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
        /// KnowledgeBase retrieves relevant data from backing stores.
        /// </summary>
        /// <param name="content">The content to send as the body of the request.</param>
        /// <param name="context">The request context.</param>
        /// <returns>The response returned from the service.</returns>
        [ForwardsClientCalls]
        public virtual Response Retrieve(RequestContent content, RequestContext context) =>
            Retrieve(content, querySourceAuthorization: null, context: context);

        /// <summary>
        /// KnowledgeBase retrieves relevant data from backing stores.
        /// </summary>
        /// <param name="content">The content to send as the body of the request.</param>
        /// <param name="context">The request context.</param>
        /// <returns>The response returned from the service.</returns>
        [ForwardsClientCalls]
        public virtual Task<Response> RetrieveAsync(RequestContent content, RequestContext context) =>
            RetrieveAsync(content, querySourceAuthorization: null, context: context);

        /// <summary>
        /// KnowledgeBase retrieves relevant data from backing stores, streaming progress and results as
        /// server-sent events on the same connection as they become available, instead of waiting for the
        /// full retrieval to complete.
        /// </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="queryWorkIQSourceAuthorization"> User assertion token for a customer-owned Entra app registration configured on a Work IQ knowledge source. Used for on-behalf-of authentication to the Work IQ API. </param>
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
        public virtual async IAsyncEnumerable<SseItem<KnowledgeBaseRetrievalStreamEvent>> RetrieveStreamAsync(
            KnowledgeBaseRetrievalRequest retrievalRequest,
            string querySourceAuthorization = default,
            string queryWorkIQSourceAuthorization = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.RetrieveStream");
            scope.Start();

            HttpMessage message = null;
            Response response = null;
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                message = CreateRetrieveStreamRequest(retrievalRequest, querySourceAuthorization, queryWorkIQSourceAuthorization, context);
                message.BufferResponse = false;
                response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                message?.Dispose();
                response?.Dispose();
                scope.Failed(e);
                throw;
            }

            using (message)
            using (response)
            {
                Stream contentStream = response.ContentStream
                    ?? throw new InvalidOperationException("The streaming response did not contain a content stream.");
                IAsyncEnumerator<SseItem<byte[]>> enumerator = SseParser
                    .Create(contentStream, static (_, bytes) => bytes.ToArray())
                    .EnumerateAsync(cancellationToken)
                    .GetAsyncEnumerator(cancellationToken);

                await using (enumerator.ConfigureAwait(false))
                {
                    while (true)
                    {
                        bool hasNext;
                        try
                        {
                            hasNext = await enumerator.MoveNextAsync().ConfigureAwait(false);
                        }
                        catch (Exception e)
                        {
                            scope.Failed(e);
                            throw;
                        }

                        if (!hasNext)
                        {
                            throw new InvalidDataException("The retrieval stream ended before a terminal event was received.");
                        }

                        SseItem<byte[]> item = enumerator.Current;
                        if (item.Data.AsSpan().SequenceEqual("[DONE]"u8))
                        {
                            yield break;
                        }

                        KnowledgeBaseRetrievalStreamEvent value;
                        try
                        {
                            value = DeserializeStreamEvent(item.EventType, BinaryData.FromBytes(item.Data));
                        }
                        catch (Exception e)
                        {
                            scope.Failed(e);
                            throw;
                        }

                        yield return new SseItem<KnowledgeBaseRetrievalStreamEvent>(value, item.EventType)
                        {
                            EventId = item.EventId,
                            ReconnectionInterval = item.ReconnectionInterval,
                        };

                        if (item.EventType is "error" or "response.completed")
                        {
                            yield break;
                        }
                    }
                }
            }
        }
#pragma warning restore AZC0015
#pragma warning restore AZC0004

        private static KnowledgeBaseRetrievalStreamEvent DeserializeStreamEvent(string eventType, BinaryData data)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement element = document.RootElement;
            ModelReaderWriterOptions options = ModelSerializationExtensions.WireOptions;

            return eventType switch
            {
                "retrieval.started" => KnowledgeBaseRetrievalStartedEvent.DeserializeKnowledgeBaseRetrievalStartedEvent(element, options),
                "activity.started" => KnowledgeBaseActivityStartedEvent.DeserializeKnowledgeBaseActivityStartedEvent(element, options),
                "activity.completed" => KnowledgeBaseActivityRecord.DeserializeKnowledgeBaseActivityRecord(element, options),
                "answer.completed" => KnowledgeBaseAnswerCompletedEvent.DeserializeKnowledgeBaseAnswerCompletedEvent(element, options),
                "references.completed" => DeserializeReferencesCompletedEvent(element, options),
                "error" => KnowledgeBaseStreamErrorEvent.DeserializeKnowledgeBaseStreamErrorEvent(element, options),
                "response.completed" => KnowledgeBaseResponseCompletedEvent.DeserializeKnowledgeBaseResponseCompletedEvent(element, options),
                _ => new UnknownKnowledgeBaseRetrievalStreamEvent(data),
            };
        }

        private static KnowledgeBaseReferencesCompletedEvent DeserializeReferencesCompletedEvent(
            JsonElement element,
            ModelReaderWriterOptions options)
        {
            if (element.ValueKind != JsonValueKind.Array)
            {
                throw new JsonException("The references.completed event payload must be a JSON array.");
            }

            List<KnowledgeBaseReference> references = new();
            foreach (JsonElement item in element.EnumerateArray())
            {
                references.Add(KnowledgeBaseReference.DeserializeKnowledgeBaseReference(item, options));
            }

            return new KnowledgeBaseReferencesCompletedEvent(references);
        }
    }
}
