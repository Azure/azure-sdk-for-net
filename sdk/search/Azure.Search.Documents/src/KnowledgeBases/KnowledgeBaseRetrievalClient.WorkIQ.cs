// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ComponentModel;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.KnowledgeBases.Models;

namespace Azure.Search.Documents.KnowledgeBases
{
    public partial class KnowledgeBaseRetrievalClient
    {
        // Retain the earlier two-argument signatures and forward through the GA virtual methods.
        /// <summary> Retrieves relevant data from backing stores. </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="context"> The request context. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Retrieve(RequestContent content, RequestContext context) =>
            Retrieve(content, querySourceAuthorization: null, context);

        /// <summary> Retrieves relevant data from backing stores. </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="context"> The request context. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response> RetrieveAsync(RequestContent content, RequestContext context) =>
            RetrieveAsync(content, querySourceAuthorization: null, context);

        /// <summary> Retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // Required token disambiguates the earlier GA signature.
        public virtual Response<KnowledgeBaseRetrievalResponse> Retrieve(KnowledgeBaseRetrievalRequest retrievalRequest, CancellationToken cancellationToken) =>
            Retrieve(retrievalRequest, querySourceAuthorization: null, cancellationToken);

        /// <summary> Retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KnowledgeBaseRetrievalResponse>> RetrieveAsync(KnowledgeBaseRetrievalRequest retrievalRequest, CancellationToken cancellationToken) =>
            RetrieveAsync(retrievalRequest, querySourceAuthorization: null, cancellationToken);
#pragma warning restore AZC0002

        // Require the full preview signature so GA calls with a trailing default literal stay unambiguous.
#pragma warning disable AZC0002 // A required token preserves GA source compatibility.
        /// <summary> Retrieves relevant data with Work IQ authorization. </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="querySourceAuthorization"> The user authorization token, or null when not needed. </param>
        /// <param name="queryWorkIQSourceAuthorization"> The Work IQ user assertion token. </param>
        /// <param name="context"> The request context. </param>
        public virtual Response Retrieve(RequestContent content, string querySourceAuthorization, string queryWorkIQSourceAuthorization, RequestContext context) =>
            queryWorkIQSourceAuthorization == null
                ? Retrieve(content, querySourceAuthorization, context)
                : RetrieveCoreAsync(content, querySourceAuthorization, queryWorkIQSourceAuthorization, context, false).EnsureCompleted();

        /// <summary> Retrieves relevant data with Work IQ authorization. </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="querySourceAuthorization"> The user authorization token, or null when not needed. </param>
        /// <param name="queryWorkIQSourceAuthorization"> The Work IQ user assertion token. </param>
        /// <param name="context"> The request context. </param>
        public virtual Task<Response> RetrieveAsync(RequestContent content, string querySourceAuthorization, string queryWorkIQSourceAuthorization, RequestContext context) =>
            queryWorkIQSourceAuthorization == null
                ? RetrieveAsync(content, querySourceAuthorization, context)
                : RetrieveCoreAsync(content, querySourceAuthorization, queryWorkIQSourceAuthorization, context, true).AsTask();

        /// <summary> Retrieves relevant data with Work IQ authorization. </summary>
        /// <param name="retrievalRequest"> The retrieval request. </param>
        /// <param name="querySourceAuthorization"> The user authorization token, or null when not needed. </param>
        /// <param name="queryWorkIQSourceAuthorization"> The Work IQ user assertion token. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<KnowledgeBaseRetrievalResponse> Retrieve(KnowledgeBaseRetrievalRequest retrievalRequest, string querySourceAuthorization, string queryWorkIQSourceAuthorization, CancellationToken cancellationToken)
        {
            if (queryWorkIQSourceAuthorization == null)
            {
                return Retrieve(retrievalRequest, querySourceAuthorization, cancellationToken);
            }
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));
            Response result = Retrieve((RequestContent)retrievalRequest, querySourceAuthorization, queryWorkIQSourceAuthorization, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeBaseRetrievalResponse)result, result);
        }

        /// <summary> Retrieves relevant data with Work IQ authorization. </summary>
        /// <param name="retrievalRequest"> The retrieval request. </param>
        /// <param name="querySourceAuthorization"> The user authorization token, or null when not needed. </param>
        /// <param name="queryWorkIQSourceAuthorization"> The Work IQ user assertion token. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual async Task<Response<KnowledgeBaseRetrievalResponse>> RetrieveAsync(KnowledgeBaseRetrievalRequest retrievalRequest, string querySourceAuthorization, string queryWorkIQSourceAuthorization, CancellationToken cancellationToken)
        {
            if (queryWorkIQSourceAuthorization == null)
            {
                return await RetrieveAsync(retrievalRequest, querySourceAuthorization, cancellationToken).ConfigureAwait(false);
            }
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));
            Response result = await RetrieveAsync((RequestContent)retrievalRequest, querySourceAuthorization, queryWorkIQSourceAuthorization, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeBaseRetrievalResponse)result, result);
        }

        /// <summary> Retrieves raw server-sent events with Work IQ authorization. </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="querySourceAuthorization"> The user authorization token, or null when not needed. </param>
        /// <param name="queryWorkIQSourceAuthorization"> The Work IQ user assertion token. </param>
        /// <param name="context"> The request context. </param>
        public virtual Task<AsyncStreamingResult<SseItem<BinaryData>>> RetrieveStreamAsync(RequestContent content, string querySourceAuthorization, string queryWorkIQSourceAuthorization, RequestContext context) =>
            queryWorkIQSourceAuthorization == null
                ? RetrieveStreamAsync(content, querySourceAuthorization, context)
                : RetrieveStreamCoreAsync(content, querySourceAuthorization, queryWorkIQSourceAuthorization, context);
#pragma warning restore AZC0002

        private async ValueTask<Response> RetrieveCoreAsync(RequestContent content, string querySourceAuthorization, string queryWorkIQSourceAuthorization, RequestContext context, bool async)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.Retrieve");
            scope.Start();
            try
            {
                Argument.AssertNotNull(content, nameof(content));
                using HttpMessage message = CreateRetrieveRequest(content, querySourceAuthorization, queryWorkIQSourceAuthorization, context);
                if (async)
                {
                    return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                }
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AsyncStreamingResult<SseItem<BinaryData>>> RetrieveStreamCoreAsync(RequestContent content, string querySourceAuthorization, string queryWorkIQSourceAuthorization, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.RetrieveStream");
            scope.Start();
            try
            {
                Argument.AssertNotNull(content, nameof(content));
                using HttpMessage message = CreateRetrieveStreamRequest(content, querySourceAuthorization, queryWorkIQSourceAuthorization, context);
                message.BufferResponse = false;
                await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return AsyncStreamingResult.CreateSse(new AzurePipelineResponse(message), null, context?.CancellationToken ?? default);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
