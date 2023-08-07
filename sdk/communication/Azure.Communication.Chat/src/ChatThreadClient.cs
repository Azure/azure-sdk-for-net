// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly ChatThreadRestClient _chatThreadRestClient;

        /// <summary>
        /// Represents the unique identifier for the thread associated to this instance.
        /// </summary>
        public virtual string Id { get; }

        /// <summary> Initializes a new instance of <see cref="ChatThreadClient"/>.</summary>
        /// <param name="threadId"></param>
        /// <param name="endpoint">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        /// <exception cref="ArgumentNullException"> This occurs when one of the required arguments is null. </exception>

        public ChatThreadClient(string threadId, Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default)
        {
            Argument.AssertNotNull(threadId, nameof(threadId));
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ChatClientOptions();
            Id = threadId;
            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = CreatePipelineFromOptions(options, communicationTokenCredential);
            _chatThreadRestClient = new ChatThreadRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, options.ApiVersion);
        }

        /// <summary>Initializes a new instance of <see cref="ChatThreadClient"/> for mocking.</summary>
        protected ChatThreadClient()
        {
            _clientDiagnostics = null!;
            _chatThreadRestClient = null!;
            Id = null!;
        }

        #region Thread Operations
        /// <summary> Updates the thread's topic asynchronously. </summary>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateTopicAsync(string topic, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateTopic)}");
            scope.Start();
            try
            {
                return await _chatThreadRestClient.UpdateChatThreadPropertiesAsync(Id, topic, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates the thread's properties. </summary>
        /// <param name="options"> Chat thread options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateProperties(UpdateChatThreadPropertiesOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateProperties)}");
            scope.Start();
            try
            {
                return _chatThreadRestClient.UpdateChatThreadProperties(Id, options.Topic, options.Metadata.ToDictionary(pair => pair.Key, pair => pair.Value), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates the thread's properties asynchronously. </summary>
        /// <param name="options"> Chat thread options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdatePropertiesAsync(UpdateChatThreadPropertiesOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateProperties)}");
            scope.Start();
            try
            {
                return await _chatThreadRestClient.UpdateChatThreadPropertiesAsync(Id, options.Topic, options.Metadata, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates the thread's topic. </summary>
        /// <param name="topic"> Chat thread topic. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateTopic(string topic, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateTopic)}");
            scope.Start();
            try
            {
                return _chatThreadRestClient.UpdateChatThreadProperties(Id, topic, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a chat thread asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ChatThreadProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                Response<ChatThreadPropertiesInternal> chatThreadPropertiesInternal = await _chatThreadRestClient.GetChatThreadPropertiesAsync(Id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ChatThreadProperties(chatThreadPropertiesInternal.Value), chatThreadPropertiesInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a chat thread. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ChatThreadProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                Response<ChatThreadPropertiesInternal> chatThreadPropertiesInternal = _chatThreadRestClient.GetChatThreadProperties(Id, cancellationToken);
                return Response.FromValue(new ChatThreadProperties(chatThreadPropertiesInternal.Value), chatThreadPropertiesInternal.GetRawResponse());
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
        /// <param name="content"> Chat message content. </param>
        /// <param name="type"> The chat message type. </param>
        /// <param name="senderDisplayName"> The display name of the chat message sender. This property is used to populate sender name for push notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendChatMessageResult>> SendMessageAsync(string content, ChatMessageType type = default, string senderDisplayName = null, CancellationToken cancellationToken = default)
        {
            return await SendMessageAsync(new SendChatMessageOptions { Content = content, MessageType = type, SenderDisplayName = senderDisplayName }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Sends a message to a thread asynchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendChatMessageResult>> SendMessageAsync(SendChatMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                Response<SendChatMessageResultInternal> sendChatMessageResultInternal =
                    await _chatThreadRestClient.SendChatMessageAsync(Id, options.Content, options.SenderDisplayName, options.MessageType, options.Metadata ?? new Dictionary<string, string>(), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SendChatMessageResult(sendChatMessageResultInternal.Value), sendChatMessageResultInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a message to a thread. </summary>
        /// <param name="content"> Message content. </param>
        /// <param name="type"> The chat message type. </param>
        /// <param name="senderDisplayName"> The display name of the message sender. This property is used to populate sender name for push notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendChatMessageResult> SendMessage(string content, ChatMessageType type = default, string senderDisplayName = null, CancellationToken cancellationToken = default)
            => SendMessage(new SendChatMessageOptions { Content = content, MessageType = type, SenderDisplayName = senderDisplayName }, cancellationToken);

        /// <summary> Sends a message to a thread. </summary>
        /// <param name="options">Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendChatMessageResult> SendMessage(SendChatMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                Response<SendChatMessageResultInternal> sendChatMessageResultInternal =
                    _chatThreadRestClient.SendChatMessage(Id, options.Content, options.SenderDisplayName, options.MessageType, options.Metadata ?? new Dictionary<string, string>(), cancellationToken);
                return Response.FromValue(new SendChatMessageResult(sendChatMessageResultInternal.Value), sendChatMessageResultInternal.GetRawResponse());
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
                Response<ChatMessageInternal> chatMessageInternal = await _chatThreadRestClient.GetChatMessageAsync(Id, messageId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ChatMessage(chatMessageInternal.Value), chatMessageInternal.GetRawResponse());
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
                Response<ChatMessageInternal> chatMessageInternal = _chatThreadRestClient.GetChatMessage(Id, messageId, cancellationToken);
                return Response.FromValue(new ChatMessage(chatMessageInternal.Value), chatMessageInternal.GetRawResponse());
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
                    Response<ChatMessagesCollection> response = await _chatThreadRestClient.ListChatMessagesAsync(Id, pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessage(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ChatMessage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatMessagesCollection> response = await _chatThreadRestClient.ListChatMessagesNextPageAsync(nextLink, Id, pageSizeHint, startTime, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessage(x)), response.Value.NextLink, response.GetRawResponse());
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
                    Response<ChatMessagesCollection> response = _chatThreadRestClient.ListChatMessages(Id, pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessage(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ChatMessage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetMessages)}");
                scope.Start();

                try
                {
                    Response<ChatMessagesCollection> response = _chatThreadRestClient.ListChatMessagesNextPage(nextLink, Id, pageSizeHint, startTime, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessage(x)), response.Value.NextLink, response.GetRawResponse());
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
            return await UpdateMessageAsync(new UpdateChatMessageOptions { MessageId = messageId, Content = content }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Updates a message asynchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateMessageAsync(UpdateChatMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateMessage)}");
            scope.Start();
            try
            {
                return await _chatThreadRestClient.UpdateChatMessageAsync(Id, options.MessageId, options.Content, options.Metadata ?? new Dictionary<string, string>(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a message synchronously. </summary>
        /// <param name="messageId"> The message id. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateMessage(string messageId, string content, CancellationToken cancellationToken = default)
        {
            return UpdateMessage(new UpdateChatMessageOptions { MessageId = messageId, Content = content }, cancellationToken);
        }

        /// <summary> Updates a message synchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateMessage(UpdateChatMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(UpdateMessage)}");
            scope.Start();
            try
            {
                return _chatThreadRestClient.UpdateChatMessage(Id, options.MessageId, options.Content, options.Metadata ?? new Dictionary<string, string>(), cancellationToken);
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
                return await _chatThreadRestClient.DeleteChatMessageAsync(Id, messageId, cancellationToken).ConfigureAwait(false);
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
                return _chatThreadRestClient.DeleteChatMessage(Id, messageId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region Participants Operations
        /// <summary> Adds a participant to a thread asynchronously. If the participant already exist, no change occurs. </summary>
        /// <param name="participant"> Participant to add to a chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> AddParticipantAsync(ChatParticipant participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Response<AddChatParticipantsResult> addChatParticipantsResult = await _chatThreadRestClient.AddChatParticipantsAsync(Id, new[] { participant.ToChatParticipantInternal() }, cancellationToken).ConfigureAwait(false);
                if (addChatParticipantsResult.Value.InvalidParticipants.Count > 0)
                {
                    throw new RequestFailedException(addChatParticipantsResult.GetRawResponse());
                }
                return addChatParticipantsResult.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Adds participants to a thread. If participants already exist, no change occurs. </summary>
        /// <param name="participant"> Participants to add to a chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response AddParticipant(ChatParticipant participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Response<AddChatParticipantsResult> addChatParticipantsResult = _chatThreadRestClient.AddChatParticipants(Id, new[] { participant.ToChatParticipantInternal() }, cancellationToken);
                if (addChatParticipantsResult.Value.InvalidParticipants.Count > 0)
                {
                    throw new RequestFailedException(addChatParticipantsResult.GetRawResponse());
                }
                return addChatParticipantsResult.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Adds participants to a thread asynchronously. If participants already exist, no change occurs. </summary>
        /// <param name="participants"> Participants to add to a chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<AddChatParticipantsResult>> AddParticipantsAsync(IEnumerable<ChatParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                return await _chatThreadRestClient.AddChatParticipantsAsync(Id, participants.Select(x => x.ToChatParticipantInternal()), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Adds participants to a thread. If participants already exist, no change occurs. </summary>
        /// <param name="participants"> Participants to add to a chat thread. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<AddChatParticipantsResult> AddParticipants(IEnumerable<ChatParticipant> participants, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                return _chatThreadRestClient.AddChatParticipants(Id, participants.Select(x => x.ToChatParticipantInternal()), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the participants of a thread asynchronously. </summary>
        /// <param name="skip"> Skips participants up to a specified position in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ChatParticipant> GetParticipantsAsync(int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ChatParticipant>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetParticipants)}");
                scope.Start();

                try
                {
                    Response<ChatParticipantsCollection> response = await _chatThreadRestClient.ListChatParticipantsAsync(Id, pageSizeHint, skip, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatParticipant(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ChatParticipant>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetParticipants)}");
                scope.Start();

                try
                {
                    Response<ChatParticipantsCollection> response = await _chatThreadRestClient.ListChatParticipantsNextPageAsync(nextLink, Id, pageSizeHint, skip, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatParticipant(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the participants of a thread. </summary>
        /// <param name="skip"> Skips participants up to a specified position in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ChatParticipant> GetParticipants(int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ChatParticipant> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetParticipants)}");
                scope.Start();

                try
                {
                    Response<ChatParticipantsCollection> response = _chatThreadRestClient.ListChatParticipants(Id, pageSizeHint, skip, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatParticipant(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ChatParticipant> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetParticipants)}");
                scope.Start();

                try
                {
                    Response<ChatParticipantsCollection> response = _chatThreadRestClient.ListChatParticipantsNextPage(nextLink, Id, pageSizeHint, skip, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatParticipant(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Remove a participant from a thread asynchronously.</summary>
        /// <param name="identifier"><see cref="CommunicationIdentifier" /> to be removed from the chat thread participants.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> RemoveParticipantAsync(CommunicationIdentifier identifier, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                CommunicationIdentifierModel communicationIdentifierModel = CommunicationIdentifierSerializer.Serialize(identifier);
                return await _chatThreadRestClient.RemoveChatParticipantAsync(Id,
                    communicationIdentifierModel.Kind,
                    communicationIdentifierModel.RawId,
                    communicationIdentifierModel.CommunicationUser,
                    communicationIdentifierModel.PhoneNumber,
                    communicationIdentifierModel.MicrosoftTeamsUser,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a member from a thread .</summary>
        /// <param name="identifier"><see cref="CommunicationIdentifier" /> to be removed from the chat thread participants.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response RemoveParticipant(CommunicationIdentifier identifier, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                CommunicationIdentifierModel communicationIdentifierModel = CommunicationIdentifierSerializer.Serialize(identifier);
                return _chatThreadRestClient.RemoveChatParticipant(Id,
                    communicationIdentifierModel.Kind,
                    communicationIdentifierModel.RawId,
                    communicationIdentifierModel.CommunicationUser,
                    communicationIdentifierModel.PhoneNumber,
                    communicationIdentifierModel.MicrosoftTeamsUser,
                    cancellationToken);
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
                return await _chatThreadRestClient.SendTypingNotificationAsync(Id, null, cancellationToken).ConfigureAwait(false);
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
                return _chatThreadRestClient.SendTypingNotification(Id, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Posts a typing event to a thread, on behalf of a user asynchronously. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="options"> Typing notification options. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> SendTypingNotificationAsync(TypingNotificationOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendTypingNotification)}");
            scope.Start();
            try
            {
                return await _chatThreadRestClient.SendTypingNotificationAsync(Id, options.SenderDisplayName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Posts a typing event to a thread, on behalf of a user. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="options"> Typing notification options. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response SendTypingNotification(TypingNotificationOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(SendTypingNotification)}");
            scope.Start();
            try
            {
                return _chatThreadRestClient.SendTypingNotification(Id, options.SenderDisplayName, cancellationToken);
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
                return await _chatThreadRestClient.SendChatReadReceiptAsync(Id, messageId, cancellationToken).ConfigureAwait(false);
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
                return _chatThreadRestClient.SendChatReadReceipt(Id, messageId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets read receipts for a thread asynchronously. </summary>
        /// <param name="skip"> Skips chat message read receipts up to a specified position in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ChatMessageReadReceipt> GetReadReceiptsAsync(int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ChatMessageReadReceipt>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetReadReceipts)}");
                scope.Start();

                try
                {
                    Response<ChatMessageReadReceiptsCollection> response = await _chatThreadRestClient.ListChatReadReceiptsAsync(Id, pageSizeHint, skip, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessageReadReceipt(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ChatMessageReadReceipt>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetReadReceipts)}");
                scope.Start();

                try
                {
                    Response<ChatMessageReadReceiptsCollection> response = await _chatThreadRestClient.ListChatReadReceiptsNextPageAsync(nextLink, Id, pageSizeHint, skip, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessageReadReceipt(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets read receipts for a thread. </summary>
        /// <param name="skip"> Skips chat message read receipts up to a specified position in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ChatMessageReadReceipt> GetReadReceipts(int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ChatMessageReadReceipt> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetReadReceipts)}");
                scope.Start();

                try
                {
                    Response<ChatMessageReadReceiptsCollection> response = _chatThreadRestClient.ListChatReadReceipts(Id, pageSizeHint, skip, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessageReadReceipt(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ChatMessageReadReceipt> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ChatThreadClient)}.{nameof(GetReadReceipts)}");
                scope.Start();

                try
                {
                    Response<ChatMessageReadReceiptsCollection> response = _chatThreadRestClient.ListChatReadReceiptsNextPage(nextLink, Id, pageSizeHint, skip, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ChatMessageReadReceipt(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
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
