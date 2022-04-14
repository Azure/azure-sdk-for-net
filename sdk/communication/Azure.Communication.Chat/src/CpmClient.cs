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
    /// The Cross Platform Messaging Services client.
    /// </summary>
    public class CpmClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly CpmRestClient _cpmRestClient;
        private readonly Uri _endpointUrl;
        private readonly CommunicationTokenCredential _communicationTokenCredential;

        /// <summary> Initializes a new instance of <see cref="CpmClient"/>.</summary>
        /// <param name="endpoint">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CpmClient(Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default)
        {
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ChatClientOptions();
            _communicationTokenCredential = communicationTokenCredential;
            _endpointUrl = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = CreatePipelineFromOptions(options, communicationTokenCredential);
            _cpmRestClient = new CpmRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>Initializes a new instance of <see cref="CpmClient"/> for mocking.</summary>
        protected CpmClient()
        {
            _clientDiagnostics = null!;
            _cpmRestClient = null;
            _endpointUrl = null!;
            _communicationTokenCredential = null!;
        }

        #region CPM Operations
        /// <summary> Sends a fire and forget message to CPM asynchronously. </summary>
        /// <param name="content"> Chat message content. </param>
        /// <param name="senderDisplayName"> The display name of the chat message sender. This property is used to populate sender name for push notifications. </param>
        /// <param name="type"> The chat message type. </param>
        /// <param name="from"> The from identifier that is owned by the authenticated account. </param>
        /// <param name="recipients"> The channel user identifiers of the recipients. </param>
        /// <param name="metadata"> Message metadata. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendCpmChatMessageResult>> SendCpmMessageAsync(string content, string senderDisplayName = null, ChatMessageType? type = null, string @from = null, IEnumerable<string> recipients = null, IDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CpmClient)}.{nameof(SendCpmMessage)}");
            scope.Start();
            try
            {
                return await _cpmRestClient.SendChatMessageAsync(content, senderDisplayName, type, @from, recipients, metadata ?? new Dictionary<string, string>(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a fire and forget message to CPM. </summary>
        /// <param name="content"> Chat message content. </param>
        /// <param name="senderDisplayName"> The display name of the chat message sender. This property is used to populate sender name for push notifications. </param>
        /// <param name="type"> The chat message type. </param>
        /// <param name="from"> The from identifier that is owned by the authenticated account. </param>
        /// <param name="recipients"> The channel user identifiers of the recipients. </param>
        /// <param name="metadata"> Message metadata. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendCpmChatMessageResult> SendCpmMessage(string content, string senderDisplayName = null, ChatMessageType? type = null, string @from = null, IEnumerable<string> recipients = null, IDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CpmClient)}.{nameof(SendCpmMessage)}");
            scope.Start();
            try
            {
                return _cpmRestClient.SendChatMessage(content, senderDisplayName, type, @from, recipients, metadata ?? new Dictionary<string, string>(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets message delivery status by id asynchronously. </summary>
        /// <param name="chatMessageId"> The message id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<GetCpmChatMessageStatusResult>> GetChatMessageStatusAsync(string chatMessageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CpmClient)}.{nameof(GetChatMessageStatus)}");
            scope.Start();
            try
            {
                return await _cpmRestClient.GetChatMessageStatusAsync(chatMessageId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets message delivery status by id. </summary>
        /// <param name="chatMessageId"> The message id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<GetCpmChatMessageStatusResult> GetChatMessageStatus(string chatMessageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CpmClient)}.{nameof(GetChatMessageStatus)}");
            scope.Start();
            try
            {
                return _cpmRestClient.GetChatMessageStatus(chatMessageId, cancellationToken);
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
