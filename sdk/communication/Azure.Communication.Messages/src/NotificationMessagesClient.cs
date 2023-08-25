// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The Azure Communication Services Notification Messages client.
    /// </summary>
    public class NotificationMessagesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NotificationMessagesRestClient _notificationMessagesRestClient;
        private readonly StreamRestClient _streamRestClient;

        #region public constructors

        /// <summary>
        /// Initializes a new instance of <see cref="NotificationMessagesClient"/>
        /// </summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public NotificationMessagesClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="NotificationMessagesClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public NotificationMessagesClient(string connectionString, CommunicationMessagesClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="NotificationMessagesClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public NotificationMessagesClient(Uri endpoint, AzureKeyCredential keyCredential, CommunicationMessagesClientOptions options = default)
             : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        #endregion

        #region private constructors
        private NotificationMessagesClient(ConnectionString connectionString, CommunicationMessagesClientOptions options)
           : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private NotificationMessagesClient(string endpoint, TokenCredential tokenCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(tokenCredential), options)
        { }

        private NotificationMessagesClient(string endpoint, AzureKeyCredential keyCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(keyCredential), options)
        { }

        private NotificationMessagesClient(Uri endpoint, HttpPipeline httpPipeline, CommunicationMessagesClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _notificationMessagesRestClient = new NotificationMessagesRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            _streamRestClient = new StreamRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="NotificationMessagesClient"/> for mocking.</summary>
        protected NotificationMessagesClient()
        {
            _clientDiagnostics = null!;
            _notificationMessagesRestClient = null!;
            _streamRestClient = null!;
        }

        #region Send Message Operations
        /// <summary> Sends a notification message asynchronously. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SendMessageResult>> SendMessageAsync(SendMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(SendMessage)}");
            scope.Start();
             _ = options ?? throw new ArgumentNullException(nameof(options));

            try
            {
                return await _notificationMessagesRestClient.SendMessageAsync(options.ChannelRegistrationId, options.To, options.MessageType, options.Content, options.MediaUri?.AbsoluteUri, options.Template?.ToMessageTemplateInternal(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends a notification message. </summary>
        /// <param name="options"> Options for the message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SendMessageResult> SendMessage(SendMessageOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(SendMessage)}");
            scope.Start();
            _ = options ?? throw new ArgumentNullException(nameof(options));

            try
            {
                return _notificationMessagesRestClient.SendMessage(options.ChannelRegistrationId, options.To, options.MessageType, options.Content, options.MediaUri?.AbsoluteUri, options.Template?.ToMessageTemplateInternal(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region Download Media Operations
        /// <summary> Download the Media payload from a User to Business message asynchronously. </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<Stream>> DownloadMediaAsync(string mediaContentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(StreamRestClient)}.{nameof(DownloadMediaAsync)}");
            scope.Start();
             _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            try
            {
                return await _streamRestClient.DownloadMediaAsync(mediaContentId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadMedia(string, CancellationToken)"/> downloads
        /// the Media payload from a User to Business message asynchronously.
        /// </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<Stream> DownloadMedia(string mediaContentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(StreamRestClient)}.{nameof(DownloadMedia)}");
            scope.Start();
             _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            try
            {
                return _streamRestClient.DownloadMedia(mediaContentId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadMediaToAsync(string, Stream, CancellationToken)"/> operation downloads the
        /// specified content asynchronously, and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="destinationStream"> A <see cref="Stream"/> to write the downloaded content to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DownloadMediaToAsync(string mediaContentId, Stream destinationStream, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(StreamRestClient)}.{nameof(DownloadMediaAsync)}");
            scope.Start();
             _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            try
            {
                return await DownloadMediaToAsyncInternal(mediaContentId, destinationStream, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadMediaTo(string, Stream, CancellationToken)"/> operation downloads the
        /// specified content, and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="destinationStream"> A <see cref="Stream"/> to write the downloaded content to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DownloadMediaTo(string mediaContentId, Stream destinationStream, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(StreamRestClient)}.{nameof(DownloadMedia)}");
            scope.Start();
             _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            try
            {
                return DownloadMediaToInternal(mediaContentId, destinationStream, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadMediaTo(string, string, CancellationToken)"/> operation downloads the
        /// specified content, and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="destinationPath"> A file path to write the downloaded content to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DownloadMediaToAsync(string mediaContentId, string destinationPath, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(StreamRestClient)}.{nameof(DownloadMediaAsync)}");
            scope.Start();
             _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            using Stream destinationStream = File.Create(destinationPath);

            try
            {
                return await DownloadMediaToAsyncInternal(mediaContentId, destinationStream, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadMediaTo(string, string, CancellationToken)"/> operation downloads the
        /// specified content, and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="destinationPath"> A file path to write the downloaded content to. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DownloadMediaTo(string mediaContentId, string destinationPath, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(StreamRestClient)}.{nameof(DownloadMedia)}");
            scope.Start();
             _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            using Stream destinationStream = File.Create(destinationPath);

            try
            {
                return DownloadMediaToInternal(mediaContentId, destinationStream, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<Response> DownloadMediaToAsyncInternal(string mediaContentId, Stream destinationStream, CancellationToken cancellationToken = default)
        {
            Response<Stream> initialResponse = await _streamRestClient.DownloadMediaAsync(mediaContentId, cancellationToken).ConfigureAwait(false);

            await CopyToAsync(initialResponse, destinationStream).ConfigureAwait(false);

            return initialResponse.GetRawResponse();
        }

        private Response DownloadMediaToInternal(string mediaContentId, Stream destinationStream, CancellationToken cancellationToken = default)
        {
            Response<Stream> initialResponse = _streamRestClient.DownloadMedia(mediaContentId, cancellationToken);

            CopyTo(initialResponse, destinationStream, cancellationToken);

            return initialResponse.GetRawResponse();
        }

        private static async Task CopyToAsync(Stream result, Stream destination)
        {
            await result.CopyToAsync(destination).ConfigureAwait(false);
        }

        private static void CopyTo(Stream result, Stream destination, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.CopyTo(destination);
            result.Dispose();
        }
        #endregion

        private static HttpPipeline CreatePipelineFromOptions(ConnectionString connectionString, CommunicationMessagesClientOptions options)
        {
            return options.BuildHttpPipeline(connectionString);
        }
    }
}
