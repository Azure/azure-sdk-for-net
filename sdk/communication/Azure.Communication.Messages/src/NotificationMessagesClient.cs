// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
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
    public partial class NotificationMessagesClient
    {
        #region public constructors

        /// <summary>
        /// Initializes a new instance of <see cref="NotificationMessagesClient"/>.
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
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public NotificationMessagesClient(Uri endpoint, AzureKeyCredential credential, CommunicationMessagesClientOptions options = default)
             : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        /// <summary>Initializes a new instance of <see cref="NotificationMessagesClient"/> for mocking.</summary>
        protected NotificationMessagesClient()
        {
            ClientDiagnostics = null!;
        }

        #endregion

        #region private constructors
        private NotificationMessagesClient(ConnectionString connectionString, CommunicationMessagesClientOptions options)
           : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private NotificationMessagesClient(string endpoint, AzureKeyCredential credential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(credential), options)
        {
            _keyCredential = credential;
        }

        private NotificationMessagesClient(Uri endpoint, HttpPipeline httpPipeline, CommunicationMessagesClientOptions options)
        {
            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = httpPipeline;
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        #endregion

        #region Download Media Operations
        /// <summary> Download the Media payload from a User to Business message asynchronously. </summary>
        /// <param name="mediaContentId">The Media Identifier contained in the User to Business message event.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<Stream>> DownloadMediaAsync(string mediaContentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(DownloadMedia)}");
            scope.Start();
            _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await DownloadMediaInternalAsync(mediaContentId, context).ConfigureAwait(false);
                return Response.FromValue(response.Content.ToStream(), response);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(DownloadMedia)}");
            scope.Start();
            _ = mediaContentId ?? throw new ArgumentNullException(nameof(mediaContentId));

            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = DownloadMediaInternal(mediaContentId, context);
                return Response.FromValue(response.Content.ToStream(), response);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(DownloadMediaTo)}");
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(DownloadMediaTo)}");
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(DownloadMediaTo)}");
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(NotificationMessagesClient)}.{nameof(DownloadMediaTo)}");
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
            Response<Stream> initialResponse = await DownloadMediaAsync(mediaContentId, cancellationToken).ConfigureAwait(false);
            await CopyToAsync(initialResponse, destinationStream).ConfigureAwait(false);
            return initialResponse.GetRawResponse();
        }

        private Response DownloadMediaToInternal(string mediaContentId, Stream destinationStream, CancellationToken cancellationToken = default)
        {
            Response<Stream> initialResponse = DownloadMedia(mediaContentId, cancellationToken);
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
    }
}
