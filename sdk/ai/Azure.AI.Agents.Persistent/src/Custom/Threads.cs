// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.AI.Agents.Persistent.Telemetry;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    public partial class Threads
    {
        /// <summary>
        /// [Protocol Method] Creates a new thread. Threads contain messages and can be run by agents.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateThreadAsync(IEnumerable{ThreadMessageOptions},ToolResources,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CreateThreadAsync(RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateThread(content, _endpoint);
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateThreadRequest(content, context);
                var response = await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                otelScope?.RecordCreateThreadResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new thread. Threads contain messages and can be run by agents.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateThread(IEnumerable{ThreadMessageOptions},ToolResources,IReadOnlyDictionary{string,string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CreateThread(RequestContent content, RequestContext context = null)
        {
            using var otelScope = OpenTelemetryScope.StartCreateThread(content, _endpoint);
            Argument.AssertNotNull(content, nameof(content));

            try
            {
                using HttpMessage message = CreateCreateThreadRequest(content, context);
                var response = _pipeline.ProcessMessage(message, context);
                otelScope?.RecordCreateThreadResponse(response);
                return response;
            }
            catch (Exception e)
            {
                otelScope?.RecordError(e);
                throw;
            }
        }
        /// <summary> Deletes a thread. </summary>
        /// <param name="threadId"> The ID of the thread to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteThread(
            string threadId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteThread");
            scope.Start();
            Response<ThreadDeletionStatus> baseResponse
                = InternalDeleteThread(threadId, cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Deletes a thread. </summary>
        /// <param name="threadId"> The ID of the thread to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threadId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="threadId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteThreadAsync(
            string threadId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteThread");
            scope.Start();
            Response<ThreadDeletionStatus> baseResponse
                = await InternalDeleteThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Gets a list of threads that were previously created. </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PersistentAgentThread> GetThreadsAsync(int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetThreadsRequest(
                limit:limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context:context);
            return new ContinuationTokenPageableAsync<PersistentAgentThread>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgentThread.DeserializePersistentAgentThread(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                after: after
            );
        }

        /// <summary> Gets a list of threads that were previously created. </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PersistentAgentThread> GetThreads(int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetThreadsRequest(
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            return new ContinuationTokenPageable<PersistentAgentThread>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgentThread.DeserializePersistentAgentThread(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                after: after
            );
        }

        /// <summary>
        /// [Protocol Method] Gets a list of threads that were previously created.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetThreadsAsync(int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual AsyncPageable<BinaryData> GetThreadsAsync(int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetThreadsRequest(limit, order, after, before, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ThreadsClient.GetThreads", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Gets a list of threads that were previously created.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetThreads(int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual Pageable<BinaryData> GetThreads(int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetThreadsRequest(limit, order, after, before, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ThreadsClient.GetThreads", "data", null, context);
        }
    }
}
