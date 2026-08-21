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
    [CodeGenSuppress(nameof(RetrieveStreamAsync), typeof(KnowledgeBaseRetrievalRequest), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(RetrieveStreamAsync), typeof(RequestContent), typeof(string), typeof(string), typeof(RequestContext))]
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

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        /// <summary> Retrieves relevant data and streams raw server-sent events. </summary>
        public virtual async Task<AsyncStreamingClientResult<SseItem<BinaryData>>> RetrieveStreamAsync(
            RequestContent content,
            string querySourceAuthorization = default,
            string queryWorkIQSourceAuthorization = default,
            RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.RetrieveStream");
            scope.Start();
            HttpMessage message = null;
            Stream extractedContent = null;
            try
            {
                Argument.AssertNotNull(content, nameof(content));

                message = CreateRetrieveStreamRequest(
                    content,
                    querySourceAuthorization,
                    queryWorkIQSourceAuthorization,
                    context);
                message.BufferResponse = false;
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);

                extractedContent = message.ExtractResponseContent()
                    ?? throw new InvalidOperationException("The streaming response did not contain a content stream.");
                StreamingPipelineResponse pipelineResponse = new StreamingPipelineResponse(response, extractedContent);
                extractedContent = null;
                message.Dispose();
                message = null;

                return AsyncStreamingClientResult.CreateSse(pipelineResponse);
            }
            catch (Exception exception)
            {
                extractedContent?.Dispose();
                message?.Dispose();
                scope.Failed(exception);
                throw;
            }
        }
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

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
    [ForwardsClientCalls(true)]
        public virtual async IAsyncEnumerable<SseItem<KnowledgeBaseRetrievalStreamEvent>> RetrieveStreamAsync(
            KnowledgeBaseRetrievalRequest retrievalRequest,
            string querySourceAuthorization = default,
            string queryWorkIQSourceAuthorization = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result = await RetrieveStreamAsync(
                retrievalRequest,
                querySourceAuthorization,
                queryWorkIQSourceAuthorization,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

            await using (((IAsyncDisposable)result).ConfigureAwait(false))
            {
                await foreach (SseItem<BinaryData> item in result.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    if (item.Data.ToMemory().Span.SequenceEqual("[DONE]"u8))
                    {
                        yield break;
                    }

                    KnowledgeBaseRetrievalStreamEvent value = KnowledgeBaseRetrievalStreamEvent.Deserialize(item.EventType, item.Data);
                    yield return new SseItem<KnowledgeBaseRetrievalStreamEvent>(value, item.EventType)
                    {
                        EventId = item.EventId,
                        ReconnectionInterval = item.ReconnectionInterval,
                    };

                    if (value.IsTerminal)
                    {
                        yield break;
                    }
                }
            }

            throw new InvalidDataException("The retrieval stream ended before a terminal event was received.");
        }
#pragma warning restore AZC0015
#pragma warning restore AZC0004

        private sealed class StreamingPipelineResponse : PipelineResponse
        {
            private readonly int _status;
            private readonly string _reasonPhrase;
            private readonly StreamingPipelineResponseHeaders _headers;
            private Stream _contentStream;
            private BinaryData _content;

            public StreamingPipelineResponse(Response response, Stream contentStream)
            {
                _status = response.Status;
                _reasonPhrase = response.ReasonPhrase;
                _headers = new StreamingPipelineResponseHeaders(response.Headers);
                _contentStream = contentStream;
            }

            public override int Status => _status;

            public override string ReasonPhrase => _reasonPhrase;

            protected override PipelineResponseHeaders HeadersCore => _headers;

            public override Stream ContentStream
            {
                get => _contentStream;
                set => _contentStream = value;
            }

            public override BinaryData Content =>
                _content ?? throw new InvalidOperationException("The streaming response has not been buffered.");

            public override BinaryData BufferContent(CancellationToken cancellationToken = default)
            {
                cancellationToken.ThrowIfCancellationRequested();
                MemoryStream buffered = new MemoryStream();
                _contentStream?.CopyTo(buffered);
                buffered.Position = 0;
                _content = BinaryData.FromStream(buffered);
                buffered.Position = 0;
                _contentStream?.Dispose();
                _contentStream = buffered;
                return _content;
            }

            public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
            {
                MemoryStream buffered = new MemoryStream();
                if (_contentStream != null)
                {
                    await _contentStream.CopyToAsync(buffered, 81920, cancellationToken).ConfigureAwait(false);
                }
                buffered.Position = 0;
                _content = BinaryData.FromStream(buffered);
                buffered.Position = 0;
                _contentStream?.Dispose();
                _contentStream = buffered;
                return _content;
            }

            public override void Dispose()
            {
                _contentStream?.Dispose();
                _contentStream = null;
            }
        }

        private sealed class StreamingPipelineResponseHeaders : PipelineResponseHeaders
        {
            private readonly Dictionary<string, string> _headers =
                new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            public StreamingPipelineResponseHeaders(ResponseHeaders headers)
            {
                foreach (HttpHeader header in headers)
                {
                    _headers[header.Name] = header.Value;
                }
            }

            public override bool TryGetValue(string name, out string value) =>
                _headers.TryGetValue(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string> values)
            {
                if (_headers.TryGetValue(name, out string value))
                {
                    values = new[] { value };
                    return true;
                }

                values = null;
                return false;
            }

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator() =>
                _headers.GetEnumerator();
        }
    }
}
