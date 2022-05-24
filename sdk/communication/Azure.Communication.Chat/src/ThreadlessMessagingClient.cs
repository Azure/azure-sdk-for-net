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
    public class ThreadlessMessagingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ThreadlessMessagingRestClient _ThreadlessMessagingRestClient;
        private readonly Uri _endpointUrl;
        private readonly CommunicationTokenCredential _communicationTokenCredential;

        /// <summary> Initializes a new instance of <see cref="ThreadlessMessagingClient"/>.</summary>
        /// <param name="endpoint">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ThreadlessMessagingClient(Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default)
        {
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ChatClientOptions();
            _communicationTokenCredential = communicationTokenCredential;
            _endpointUrl = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = CreatePipelineFromOptions(options, communicationTokenCredential);
            _ThreadlessMessagingRestClient = new ThreadlessMessagingRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>Initializes a new instance of <see cref="ThreadlessMessagingClient"/> for mocking.</summary>
        protected ThreadlessMessagingClient()
        {
            _clientDiagnostics = null!;
            _ThreadlessMessagingRestClient = null;
            _endpointUrl = null!;
            _communicationTokenCredential = null!;
        }

        #region Cross-platform threadless messaging Operations
        /// <summary> Sends a Fire and Forget/Threadless/CPM notification message asynchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendThreadlessMessageResult>> SendMessageAsync(SendThreadlessMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ThreadlessMessagingClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return await _ThreadlessMessagingRestClient.SendMessageAsync(options.From, options.To, options.Type, options.Content, options.Media, options.Template, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a Fire and Forget/Threadless/CPM notification message. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendThreadlessMessageResult> SendMessage(SendThreadlessMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ThreadlessMessagingClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return _ThreadlessMessagingRestClient.SendMessage(options.From, options.To, options.Type, options.Content, options.Media, options.Template, cancellationToken);
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
