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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.KnowledgeBases
{
    // Keep the October GA signatures when the preview spec adds a WorkIQ parameter.
    [CodeGenSuppress(nameof(Retrieve), typeof(RequestContent), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress(nameof(RetrieveAsync), typeof(RequestContent), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress(nameof(Retrieve), typeof(KnowledgeBaseRetrievalRequest), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(RetrieveAsync), typeof(KnowledgeBaseRetrievalRequest), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(RetrieveStreamAsync), typeof(RequestContent), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress(nameof(RetrieveStreamAsync), typeof(KnowledgeBaseRetrievalRequest), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class KnowledgeBaseRetrievalClient
    {
        /// <summary>
        /// [Protocol Method] KnowledgeBase retrieves relevant data from backing stores.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response Retrieve(RequestContent content, string querySourceAuthorization = default, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.Retrieve");
            scope.Start();
            try
            {
                Argument.AssertNotNull(content, nameof(content));

                using HttpMessage message = CreateRetrieveRequest(content, querySourceAuthorization, null, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] KnowledgeBase retrieves relevant data from backing stores.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> RetrieveAsync(RequestContent content, string querySourceAuthorization = default, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.Retrieve");
            scope.Start();
            try
            {
                Argument.AssertNotNull(content, nameof(content));

                using HttpMessage message = CreateRetrieveRequest(content, querySourceAuthorization, null, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> KnowledgeBase retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<KnowledgeBaseRetrievalResponse> Retrieve(KnowledgeBaseRetrievalRequest retrievalRequest, string querySourceAuthorization = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));

            Response result = Retrieve(retrievalRequest, querySourceAuthorization, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeBaseRetrievalResponse)result, result);
        }

        /// <summary> KnowledgeBase retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<KnowledgeBaseRetrievalResponse>> RetrieveAsync(KnowledgeBaseRetrievalRequest retrievalRequest, string querySourceAuthorization = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(retrievalRequest, nameof(retrievalRequest));

            Response result = await RetrieveAsync(retrievalRequest, querySourceAuthorization, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeBaseRetrievalResponse)result, result);
        }

        /// <summary>
        /// [Protocol Method] Retrieves relevant data from backing stores and streams progress and results as server-sent
        /// events.
        /// Process the response incrementally using server-sent event framing. Each event contains an
        /// event name and a JSON-encoded data payload. The stream ends with either a `response.completed`
        /// event or an `error` event. OpenAPI 2.0 represents the response body as a string, so generated
        /// clients may expose the raw response without typed event parsing. Do not deserialize the
        /// complete response body as a single JSON document.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="querySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<AsyncStreamingResult<SseItem<BinaryData>>> RetrieveStreamAsync(RequestContent content, string querySourceAuthorization = default, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("KnowledgeBaseRetrievalClient.RetrieveStream");
            scope.Start();
            try
            {
                Argument.AssertNotNull(content, nameof(content));

                using HttpMessage message = CreateRetrieveStreamRequest(content, querySourceAuthorization, null, context);
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

        /// <summary>
        /// [Protocol Method] KnowledgeBase retrieves relevant data from backing stores.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Retrieve(RequestContent content, RequestContext context)
        {
            return Retrieve(content: content, querySourceAuthorization: default, context: context);
        }

        /// <summary>
        /// [Protocol Method] KnowledgeBase retrieves relevant data from backing stores.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response> RetrieveAsync(RequestContent content, RequestContext context)
        {
            return RetrieveAsync(content: content, querySourceAuthorization: default, context: context);
        }

        /// <summary> KnowledgeBase retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
#pragma warning disable AZC0002 // Back-compat overload preserves the previous method signature where CancellationToken was the trailing parameter. Making it optional would introduce an ambiguous call with the new method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KnowledgeBaseRetrievalResponse> Retrieve(KnowledgeBaseRetrievalRequest retrievalRequest, CancellationToken cancellationToken)
        {
            return Retrieve(retrievalRequest: retrievalRequest, querySourceAuthorization: default, cancellationToken: cancellationToken);
        }
#pragma warning restore AZC0002 // Back-compat overload preserves the previous method signature where CancellationToken was the trailing parameter. Making it optional would introduce an ambiguous call with the new method.

        /// <summary> KnowledgeBase retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
#pragma warning disable AZC0002 // Back-compat overload preserves the previous method signature where CancellationToken was the trailing parameter. Making it optional would introduce an ambiguous call with the new method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KnowledgeBaseRetrievalResponse>> RetrieveAsync(KnowledgeBaseRetrievalRequest retrievalRequest, CancellationToken cancellationToken)
        {
            return RetrieveAsync(retrievalRequest: retrievalRequest, querySourceAuthorization: default, cancellationToken: cancellationToken);
        }
#pragma warning restore AZC0002 // Back-compat overload preserves the previous method signature where CancellationToken was the trailing parameter. Making it optional would introduce an ambiguous call with the new method.
    }
}
