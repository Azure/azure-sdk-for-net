// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Messaging
{
    /// <summary>
    /// The Azure Communication Services Notification client.
    /// </summary>
    public class NotificationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly CommunicationNotificationRestClient _notificationRestClient;
        private readonly NotificationClientOptions _notificationClientOptions;
        private readonly ConnectionString _connectionString;
        private readonly Uri _endpointUrl;

        /// <summary> Initializes a new instance of <see cref="NotificationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Messaging client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public NotificationClient(string connectionString, NotificationClientOptions options = default)
        {
            _connectionString = ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString)));
            _endpointUrl = new Uri(_connectionString.GetRequired("endpoint"));
            _notificationClientOptions = options ?? new NotificationClientOptions();
            _clientDiagnostics = new ClientDiagnostics(_notificationClientOptions);
            HttpPipeline pipeline = CreatePipelineFromOptions(_connectionString, _notificationClientOptions);
            _notificationRestClient = new CommunicationNotificationRestClient(_clientDiagnostics, pipeline, _endpointUrl.AbsoluteUri, _notificationClientOptions.ApiVersion);
        }

        /// <summary>Initializes a new instance of <see cref="NotificationClient"/> for mocking.</summary>
        protected NotificationClient()
        {
            _clientDiagnostics = null!;
            _notificationRestClient = null!;
        }

        #region External messaging Operations
        /// <summary> Sends a Fire and Forget/Threadless/CPM external notification message asynchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendMessageResponse>> SendMessageAsync(SendMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(NotificationClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return await _notificationRestClient.SendMessageAsync(options.ChannelRegistrationId, options.To, options.MessageType, options.Content, options.MediaUri?.AbsoluteUri, options.Template, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<SendMessageResponse> SendMessage(SendMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(NotificationClient)}.{nameof(SendMessage)}");
            scope.Start();
            try
            {
                return _notificationRestClient.SendMessage(options.ChannelRegistrationId, options.To, options.MessageType, options.Content, options.MediaUri?.AbsoluteUri, options.Template, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        private static HttpPipeline CreatePipelineFromOptions(ConnectionString connectionString, NotificationClientOptions options)
        {
            return options.BuildHttpPipeline(connectionString);
        }
    }
}
