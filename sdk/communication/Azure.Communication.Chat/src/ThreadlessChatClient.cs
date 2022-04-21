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
    public class ThreadlessChatClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ThreadlessRestClient _threadlessRestClient;
        private readonly Uri _endpointUrl;
        private readonly CommunicationTokenCredential _communicationTokenCredential;

        /// <summary> Initializes a new instance of <see cref="ThreadlessChatClient"/>.</summary>
        /// <param name="endpoint">The uri for the Azure Communication Services Chat.</param>
        /// <param name="communicationTokenCredential">Instance of <see cref="CommunicationTokenCredential"/>.</param>
        /// <param name="options">Chat client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ThreadlessChatClient(Uri endpoint, CommunicationTokenCredential communicationTokenCredential, ChatClientOptions options = default)
        {
            Argument.AssertNotNull(communicationTokenCredential, nameof(communicationTokenCredential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ChatClientOptions();
            _communicationTokenCredential = communicationTokenCredential;
            _endpointUrl = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = CreatePipelineFromOptions(options, communicationTokenCredential);
            _threadlessRestClient = new ThreadlessRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>Initializes a new instance of <see cref="ThreadlessChatClient"/> for mocking.</summary>
        protected ThreadlessChatClient()
        {
            _clientDiagnostics = null!;
            _threadlessRestClient = null;
            _endpointUrl = null!;
            _communicationTokenCredential = null!;
        }

        #region Threadless Messaging Operations

        /// <summary> Sends a Fire and Forget/Threadless/CPM text message asynchronously. </summary>
        /// <param name="from"> The from identifier that is owned by the authenticated account. </param>
        /// <param name="to"> The channel user identifiers of the recipient. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendThreadlessChatMessageResult>> SendTextMessageAsync(string from, string to, string content, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ThreadlessChatClient)}.{nameof(SendTextMessage)}");
            scope.Start();
            try
            {
                return await _threadlessRestClient.SendChatMessageAsync(from, to, ThreadlessChatMessageType.Text, content, null, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a Fire and Forget/Threadless/CPM text message. </summary>
        /// <param name="from"> The from identifier that is owned by the authenticated account. </param>
        /// <param name="to"> The channel user identifiers of the recipient. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendThreadlessChatMessageResult> SendTextMessage(string from, string to, string content, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ThreadlessChatClient)}.{nameof(SendTextMessage)}");
            scope.Start();
            try
            {
                return _threadlessRestClient.SendChatMessage(from, to, ThreadlessChatMessageType.Text, content, null, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a Fire and Forget/Threadless/CPM template message asynchronously. </summary>
        /// <param name="from"> The from identifier that is owned by the authenticated account. </param>
        /// <param name="to"> The channel user identifiers of the recipient. </param>
        /// <param name="type"> The threadless chat message type. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="media"> The media Object. </param>
        /// <param name="template"> The template object used to create message templates. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendThreadlessChatMessageResult>> SendMessageAsync(string from, string to, ThreadlessChatMessageType type = default, string content = null, ChatMedia media = null, ChatTemplate template = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ThreadlessChatClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return await _threadlessRestClient.SendChatMessageAsync(from, to, type, content, media, template, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a Fire and Forget/Threadless/CPM message. </summary>
        /// <param name="from"> The from identifier that is owned by the authenticated account. </param>
        /// <param name="to"> The channel user identifiers of the recipient. </param>
        /// <param name="type"> The threadless chat message type. </param>
        /// <param name="content"> Chat message content. </param>
        /// <param name="media"> The media Object. </param>
        /// <param name="template"> The template object used to create message templates. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendThreadlessChatMessageResult> SendMessage(string from, string to, ThreadlessChatMessageType type = default, string content = null, ChatMedia media = null, ChatTemplate template = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ThreadlessChatClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return _threadlessRestClient.SendChatMessage(from, to, type, content, media, template, cancellationToken);
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
