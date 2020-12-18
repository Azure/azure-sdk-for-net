// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// The Azure Communication Services Chat client.
    /// </summary>
    public class ChatClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ChatRestClient _chatRestClient;
        private readonly Uri _endpointUrl;
        private readonly CommunicationTokenCredential _communicationTokenCredential;
        private readonly ChatClientOptions _chatClientOptions;
        private const string MultiStatusThreadResourceType = "THREAD";

        /// <summary> Initializes a new instance of <see cref="ChatClient"/>.</summary>
        /// <param name="endpointUrl">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ChatClient(Uri endpointUrl, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions? options = default)
        {
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpointUrl, nameof(endpointUrl));
            _chatClientOptions = options ?? new ChatClientOptions();
            _communicationTokenCredential = communicationTokenCredential;
            _endpointUrl = endpointUrl;
            _clientDiagnostics = new ClientDiagnostics(_chatClientOptions);
            HttpPipeline pipeline = CreatePipelineFromOptions(_chatClientOptions, communicationTokenCredential);
            _chatRestClient = new ChatRestClient(_clientDiagnostics, pipeline, endpointUrl.AbsoluteUri, _chatClientOptions.ApiVersion);
        }

        /// <summary>Initializes a new instance of <see cref="ChatClient"/> for mocking.</summary>
        protected ChatClient()
        {
            _clientDiagnostics = null!;
            _chatRestClient = null!;
            _endpointUrl = null!;
            _communicationTokenCredential = null!;
            _chatClientOptions = null!;
        }

        #region Thread Operations
        /// <summary>Creates a ChatThreadClient asynchronously. <see cref="ChatThreadClient"/>.</summary>
        /// <param name="topic">Topic for the chat thread</param>
        /// <param name="members">Members to be included in the chat thread</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "ChatThreadClient needs to be created by the ChatClient parent object")]
        public virtual async Task<ChatThreadClient> CreateChatThreadAsync(string topic, IEnumerable<ChatThreadMember> members, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(CreateChatThread)}");
            scope.Start();
            try
            {
                Response<MultiStatusResponse> threadResponse =  await _chatRestClient.CreateChatThreadAsync(topic, members.Select(x => x.ToChatThreadMemberInternal()), cancellationToken).ConfigureAwait(false);
                string threadId = threadResponse.Value.MultipleStatus.First(x => x.Type.ToUpperInvariant() == MultiStatusThreadResourceType).Id;
                return new ChatThreadClient(threadId, _endpointUrl, _communicationTokenCredential, _chatClientOptions);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Creates a ChatThreadClient synchronously.<see cref="ChatThreadClient"/>.</summary>
        /// <param name="topic">Topic for the chat thread</param>
        /// <param name="members">Members to be included in the chat thread</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual ChatThreadClient CreateChatThread(string topic, IEnumerable<ChatThreadMember> members, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(CreateChatThread)}");
            scope.Start();
            try
            {
                Response<MultiStatusResponse> threadResponse =  _chatRestClient.CreateChatThread(topic, members.Select(x=>x.ToChatThreadMemberInternal()), cancellationToken);
                string threadId = threadResponse.Value.MultipleStatus.First(x => x.Type.ToUpperInvariant() == MultiStatusThreadResourceType).Id;
                return new ChatThreadClient(threadId, _endpointUrl, _communicationTokenCredential, _chatClientOptions);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of ChatThreadClient. <see cref="ChatThreadClient"/>.</summary>
        /// <param name="threadId"> The thread id for the ChatThreadClient instance. </param>
        public virtual ChatThreadClient GetChatThreadClient(string threadId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreadClient)}");
            scope.Start();
            try
            {
                return new ChatThreadClient(threadId, _endpointUrl, _communicationTokenCredential, _chatClientOptions);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a chat thread asynchronously. </summary>
        /// <param name="threadId"> Thread id of the chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ChatThread>> GetChatThreadAsync(string threadId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThread)}");
            scope.Start();
            try
            {
                Response<ChatThreadInternal> chatThreadInternal = await _chatRestClient.GetChatThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ChatThread(chatThreadInternal.Value), chatThreadInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a chat thread. </summary>
        /// <param name="threadId"> Thread id of the chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ChatThread> GetChatThread(string threadId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThread)}");
            scope.Start();
            try
            {
                Response<ChatThreadInternal> chatThreadInternal = _chatRestClient.GetChatThread(threadId, cancellationToken);
                return Response.FromValue(new ChatThread(chatThreadInternal.Value), chatThreadInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the list of chat threads of a user<see cref="ChatThreadInfo"/> asynchronously.</summary>
        /// <param name="startTime"> The earliest point in time to get chat threads up to. The timestamp should be in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ChatThreadInfo> GetChatThreadsInfoAsync(DateTimeOffset? startTime = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ChatThreadInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreadsInfo)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsInfoCollection> response = await _chatRestClient.ListChatThreadsAsync(pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ChatThreadInfo>> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreadsInfo)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsInfoCollection> response = await _chatRestClient.ListChatThreadsNextPageAsync(nextLink, pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the list of chat threads of a user<see cref="ChatThreadInfo"/>.</summary>
        /// <param name="startTime"> The earliest point in time to get chat threads up to. The timestamp should be in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ChatThreadInfo> GetChatThreadsInfo(DateTimeOffset? startTime = null, CancellationToken cancellationToken = default)
        {
            Page<ChatThreadInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreadsInfo)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsInfoCollection> response = _chatRestClient.ListChatThreads(pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ChatThreadInfo> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(GetChatThreadsInfo)}");
                scope.Start();

                try
                {
                    Response<ChatThreadsInfoCollection> response = _chatRestClient.ListChatThreadsNextPage(nextLink, pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Deletes a thread asynchronously. </summary>
        /// <param name="threadId"> Thread id to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteChatThreadAsync(string threadId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(DeleteChatThread)}");
            scope.Start();
            try
            {
                return await _chatRestClient.DeleteChatThreadAsync(threadId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a thread. </summary>
        /// <param name="threadId"> Thread id to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteChatThread(string threadId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatClient)}.{nameof(DeleteChatThread)}");
            scope.Start();
            try
            {
                return _chatRestClient.DeleteChatThread(threadId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion

        private static HttpPipeline CreatePipelineFromOptions(ChatClientOptions options, CommunicationTokenCredential communicationTokenCredential)
        {
            var bearerTokenCredential = new CommunicationBearerTokenCredential(communicationTokenCredential);
            var authenticationPolicy = new BearerTokenAuthenticationPolicy(bearerTokenCredential, "");
            return HttpPipelineBuilder.Build(options, authenticationPolicy);
        }
    }
}
