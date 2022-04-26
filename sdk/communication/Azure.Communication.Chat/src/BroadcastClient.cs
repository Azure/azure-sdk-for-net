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
    public class BroadcastClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly BroadcastRestClient _broadcastRestClient;
        private readonly Uri _endpointUrl;
        private readonly CommunicationTokenCredential _communicationTokenCredential;

        /// <summary> Initializes a new instance of <see cref="BroadcastClient"/>.</summary>
        /// <param name="endpoint">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public BroadcastClient(Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default)
        {
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ChatClientOptions();
            _communicationTokenCredential = communicationTokenCredential;
            _endpointUrl = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = CreatePipelineFromOptions(options, communicationTokenCredential);
            _broadcastRestClient = new BroadcastRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>Initializes a new instance of <see cref="BroadcastClient"/> for mocking.</summary>
        protected BroadcastClient()
        {
            _clientDiagnostics = null!;
            _broadcastRestClient = null;
            _endpointUrl = null!;
            _communicationTokenCredential = null!;
        }

        #region Broadcast Messaging Operations
        /// <summary> Sends a Fire and Forget/Threadless/CPM message asynchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendBroadcastChatMessageResult>> SendMessageAsync(SendBroadcastMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(BroadcastClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return await _broadcastRestClient.SendChatMessageAsync(options.From, options.To, options.Type, options.Content, options.Media, options.Template, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a Fire and Forget/Threadless/CPM message. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
       public virtual Response<SendBroadcastChatMessageResult> SendMessage(SendBroadcastMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(BroadcastClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return _broadcastRestClient.SendChatMessage(options.From, options.To, options.Type, options.Content, options.Media, options.Template, cancellationToken);
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
