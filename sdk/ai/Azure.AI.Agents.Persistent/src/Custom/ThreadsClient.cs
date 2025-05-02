// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenClient("Threads")]
    public partial class ThreadsClient
    {
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

        ///// <inheritdoc cref="InternalGetThreads(int?, ListSortOrder?, string, string, CancellationToken)"/>
        //public virtual Response<PageableList<PersistentAgentThread>> GetThreads(
        //    int? limit = null,
        //    ListSortOrder? order = null,
        //    string after = null,
        //    string before = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.GetThreads");
        //    scope.Start();
        //    Response<OpenAIPageableListOfAgentThread> baseResponse
        //        = InternalGetThreads(limit, order, after, before, cancellationToken);
        //    return Response.FromValue(PageableList<PersistentAgentThread>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        //}

        ///// <inheritdoc cref="InternalGetThreadsAsync(int?, ListSortOrder?, string, string, CancellationToken)"/>
        //public virtual async Task<Response<PageableList<PersistentAgentThread>>> GetThreadsAsync(
        //    int? limit = null,
        //    ListSortOrder? order = null,
        //    string after = null,
        //    string before = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.GetThreads");
        //    scope.Start();
        //    Response<OpenAIPageableListOfAgentThread> baseResponse
        //        = await InternalGetThreadsAsync(limit, order, after, before, cancellationToken).ConfigureAwait(false);
        //    return Response.FromValue(PageableList<PersistentAgentThread>.Create(baseResponse.Value), baseResponse.GetRawResponse());
        //}
    }
}
