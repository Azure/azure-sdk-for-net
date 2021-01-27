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
    /// The Azure Communication Services ChatThread client.
    /// </summary>
    public class ChatThreadClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ChatRestClient _chatRestClient;

        /// <summary>
        /// Represents the unique identifier for the thread associated to this instance.
        /// </summary>
        public virtual string Id { get; }

        /// <summary> Initializes a new instance of <see cref="ChatThreadClient"/>.</summary>
        /// <param name="threadId"></param>
        /// <param name="endpointUrl">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        /// <exception cref="ArgumentNullException"> This occurs when one of the required arguments is null. </exception>
        internal ChatThreadClient(string threadId, Uri endpointUrl, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions? options = default)
        {
            Argument.AssertNotNull(threadId, nameof(threadId));
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpointUrl, nameof(endpointUrl));
            options ??= new ChatClientOptions();
            Id = threadId;
            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = CreatePipelineFromOptions(options, communicationTokenCredential);
            _chatRestClient = new ChatRestClient(_clientDiagnostics, pipeline, endpointUrl.AbsoluteUri, options.ApiVersion);
        }

        /// <summary>Initializes a new instance of <see cref="ChatThreadClient"/> for mocking.</summary>
        protected ChatThreadClient()
        {
            _clientDiagnostics = null!;
            _chatRestClient = null!;
            Id = null!;
        }

        #region Thread Operations
        /// <summary> Updates thread's properties asynchronously. </summary>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateThreadAsync(string topic, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateThread)}");
            scope.Start();
            try
            {
                return await _chatRestClient.UpdateChatThreadAsync(Id, topic, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates thread's properties. </summary>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateThread(string topic, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateThread)}");
            scope.Start();
            try
            {
                return _chatRestClient.UpdateChatThread(Id, topic, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region Message Operations
        /// <summary> Sends a message to a thread asynchronously. </summary>
        /// <param name="content"> Message content. </param>
        /// <param name="priority"> Message priority. </param>
        /// <param name="senderDisplayName"> The display name of the message sender. This property is used to populate sender name for push notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendChatMessageResult>> SendMessageAsync(string content, ChatMessagePriority? priority = null, string senderDisplayName = null!, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return await _chatRestClient.SendChatMessageAsync(Id, content, priority, senderDisplayName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a message to a thread. </summary>
        /// <param name="content"> Message content. </param>
        /// <param name="priority"> Message priority. </param>
        /// <param name="senderDisplayName"> The display name of the message sender. This property is used to populate sender name for push notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendChatMessageResult> SendMessage(string content, ChatMessagePriority? priority = null, string senderDisplayName = null!, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return _chatRestClient.SendChatMessage(Id, content, priority, senderDisplayName, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a message by id asynchronously. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ChatMessage>> GetMessageAsync(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessage)}");
            scope.Start();
            try
            {
                return await _chatRestClient.GetChatMessageAsync(Id, messageId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a message by id. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ChatMessage> GetMessage(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessage)}");
            scope.Start();
            try
            {
                return _chatRestClient.GetChatMessage(Id, messageId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of messages from a thread asynchronously. </summary>
        /// <param name="startTime"> The earliest point in time to get messages up to. The timestamp should be in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ChatMessage> GetMessagesAsync(DateTimeOffset? startTime = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ChatMessage>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatMessagesCollection> response = await _chatRestClient.ListChatMessagesAsync(Id, pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ChatMessage>> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatMessagesCollection> response = await _chatRestClient.ListChatMessagesNextPageAsync(nextLink, Id, pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
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

        /// <summary> Gets a list of messages from a thread. </summary>
        /// <param name="startTime"> The earliest point in time to get messages up to. The timestamp should be in ISO8601 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ChatMessage> GetMessages(DateTimeOffset? startTime = null, CancellationToken cancellationToken = default)
        {
            Page<ChatMessage> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatMessagesCollection> response = _chatRestClient.ListChatMessages(Id, pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ChatMessage> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatMessagesCollection> response = _chatRestClient.ListChatMessagesNextPage(nextLink, Id, pageSizeHint, startTime, cancellationToken);
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

        /// <summary> Updates a message asynchronously. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateMessageAsync(string messageId, string content, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateMessage)}");
            scope.Start();
            try
            {
                return await _chatRestClient.UpdateChatMessageAsync(Id, messageId, content, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a message asynchronously. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateMessage(string messageId, string content, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateMessage)}");
            scope.Start();
            try
            {
                return _chatRestClient.UpdateChatMessage(Id, messageId, content, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a message. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteMessageAsync(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(DeleteMessage)}");
            scope.Start();
            try
            {
                return await _chatRestClient.DeleteChatMessageAsync(Id, messageId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a message. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteMessage(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(DeleteMessage)}");
            scope.Start();
            try
            {
                return _chatRestClient.DeleteChatMessage(Id, messageId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region Member Operations
        /// <summary> Adds thread members to a thread asynchronously. If members already exist, no change occurs. </summary>
        /// <param name="members"> Members to add to a chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> AddMembersAsync(IEnumerable<ChatThreadMember> members, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(AddMembers)}");
            scope.Start();
            try
            {
                return await _chatRestClient.AddChatThreadMembersAsync(Id, members.Select(x => x.ToChatThreadMemberInternal()), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Adds thread members to a thread. If members already exist, no change occurs. </summary>
        /// <param name="members"> Members to add to a chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response AddMembers(IEnumerable<ChatThreadMember> members, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(AddMembers)}");
            scope.Start();
            try
            {
                return _chatRestClient.AddChatThreadMembers(Id, members.Select(x => x.ToChatThreadMemberInternal()), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the members of a thread asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ChatThreadMember> GetMembersAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ChatThreadMember>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMembers)}");
                scope.Start();

                try
                {
                    Response<ChatThreadMembersCollection> response = await _chatRestClient.ListChatThreadMembersAsync(Id, cancellationToken).ConfigureAwait(false);
                    IEnumerable<ChatThreadMember> chatThreadMembers = response.Value.Value.Select(x => x.ToChatThreadMember());
                    return Page.FromValues(chatThreadMembers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Gets the members of a thread. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ChatThreadMember> GetMembers(CancellationToken cancellationToken = default)
        {
            Page<ChatThreadMember> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatThreadMembersCollection> response = _chatRestClient.ListChatThreadMembers(Id, cancellationToken);
                    IEnumerable<ChatThreadMember> chatThreadMembers = response.Value.Value.Select(x => x.ToChatThreadMember());
                    return Page.FromValues(chatThreadMembers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Remove a member from a thread asynchronously.</summary>
        /// <param name="user"><see cref="CommunicationUserIdentifier" /> to be removed from the chat thread members.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> RemoveMemberAsync(CommunicationUserIdentifier user, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(RemoveMember)}");
            scope.Start();
            try
            {
                return await _chatRestClient.RemoveChatThreadMemberAsync(Id, user.Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a member from a thread .</summary>
        /// <param name="user"><see cref="CommunicationUserIdentifier" /> to be removed from the chat thread members.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response RemoveMember(CommunicationUserIdentifier user, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(RemoveMember)}");
            scope.Start();
            try
            {
                return _chatRestClient.RemoveChatThreadMember(Id, user.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Posts a typing event to a thread, on behalf of a user asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> SendTypingNotificationAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendTypingNotification)}");
            scope.Start();
            try
            {
                return await _chatRestClient.SendTypingNotificationAsync(Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Posts a typing event to a thread, on behalf of a user. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response SendTypingNotification(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendTypingNotification)}");
            scope.Start();
            try
            {
                return _chatRestClient.SendTypingNotification(Id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a read receipt event to a thread, on behalf of a user asynchronously. </summary>
        /// <param name="messageId"> Id of the latest chat message read by the user. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> SendReadReceiptAsync(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendReadReceipt)}");
            scope.Start();
            try
            {
                return await _chatRestClient.SendChatReadReceiptAsync(Id, messageId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a read receipt event to a thread, on behalf of a user. </summary>
        /// <param name="messageId"> Id of the latest chat message read by the user. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response SendReadReceipt(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendReadReceipt)}");
            scope.Start();
            try
            {
                return _chatRestClient.SendChatReadReceipt(Id, messageId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets read receipts for a thread asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ReadReceipt> GetReadReceiptsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ReadReceipt>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetReadReceipts)}");
                scope.Start();

                try
                {
                    Response<ReadReceiptsCollection> response = await _chatRestClient.ListChatReadReceiptsAsync(Id, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Gets read receipts for a thread. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ReadReceipt> GetReadReceipts(CancellationToken cancellationToken = default)
        {
            Page<ReadReceipt> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetReadReceipts)}");
                scope.Start();

                try
                {
                    Response<ReadReceiptsCollection> response = _chatRestClient.ListChatReadReceipts(Id, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
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
