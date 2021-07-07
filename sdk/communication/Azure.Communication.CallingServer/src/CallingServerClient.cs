// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Calling Server client.
    /// </summary>
    public class CallingServerClient
    {
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;
        internal readonly string _resourceEndpoint;
        internal readonly ContentDownloader _contentDownloader;

        internal CallConnectionsRestClient CallConnectionRestClient { get; }
        internal ServerCallsRestClient ServerCallRestClient { get; }

        #region public constructors
        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public CallingServerClient(string connectionString)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  new CallingServerClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(string connectionString, CallingServerClientOptions options)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  Argument.CheckNotNull(options, nameof(options)))
        { }

        #endregion

        #region private constructors

        private CallingServerClient(ConnectionString connectionString, CallingServerClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallingServerClient(string endpoint, HttpPipeline httpPipeline, CallingServerClientOptions options)
        {
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            _contentDownloader = new(this);
            CallConnectionRestClient = new CallConnectionsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ServerCallRestClient = new ServerCallsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallingServerClient()
        {
            _pipeline = null;
            _resourceEndpoint = null;
            _clientDiagnostics = null;
            _contentDownloader = new(this);
            CallConnectionRestClient = null;
            ServerCallRestClient = null;
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response<CallConnection>> CreateCallConnectionAsync(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCallConnection)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(options, nameof(options));

                var createCallResponse = await CallConnectionRestClient.CreateCallAsync(
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    callbackUri: options.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: options.RequestedMediaTypes,
                    requestedCallEvents: options.RequestedCallEvents,
                    alternateCallerId: options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber),
                    subject: options.Subject,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnection(createCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response<CallConnection> CreateCallConnection(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCallConnection)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(options, nameof(options));

                var createCallResponse = CallConnectionRestClient.CreateCall(
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    callbackUri: options.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: options.RequestedMediaTypes,
                    requestedCallEvents: options.RequestedCallEvents,
                    alternateCallerId: options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber),
                    subject: options.Subject,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(
                    new CallConnection(createCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Join the call using server call id.
        /// <param name="serverCallId"> The server call id. </param>
        /// <param name="source"> The source identity. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serverCallId"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual async Task<Response<CallConnection>> JoinCallAsync(string serverCallId, CommunicationIdentifier source, JoinCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(JoinCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                var joinCallResponse = await ServerCallRestClient.JoinCallAsync(
                    serverCallId: serverCallId,
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: callOptions.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: callOptions.RequestedMediaTypes,
                    requestedCallEvents: callOptions.RequestedCallEvents,
                    subject: null,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnection(joinCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    joinCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Join the call using server call id.
        /// <param name="serverCallId"> The server call id. </param>
        /// <param name="source"> The source identity. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serverCallId"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual Response<CallConnection> JoinCall(string serverCallId, CommunicationIdentifier source, JoinCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(JoinCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                var joinCallResponse = ServerCallRestClient.JoinCall(
                    serverCallId: serverCallId,
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: callOptions.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: callOptions.RequestedMediaTypes,
                    requestedCallEvents: callOptions.RequestedCallEvents,
                    subject: null,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(
                    new CallConnection(joinCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    joinCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallConnection. <see cref="CallConnection"/>.</summary>
        /// <param name="callConnectionId"> The thread id for the ChatThreadClient instance. </param>
        public virtual CallConnection GetCallConnection(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CallingServerClient)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callConnectionId, nameof(callConnectionId));

                return new CallConnection(callConnectionId, CallConnectionRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initializes a server call.
        /// </summary>
        /// <param name="serverCallId">The server call id. </param>
        /// <returns></returns>
        public virtual ServerCall InitializeServerCall(string serverCallId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(InitializeServerCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(serverCallId, nameof(serverCallId));

                return new ServerCall(serverCallId, ServerCallRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadStreamingAsync(Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="sourceEndpoint">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Stream}"/> containing the
        /// downloaded content.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<Stream>> DownloadStreamingAsync(
            Uri sourceEndpoint,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            await _contentDownloader.DownloadStreamingInternal(
                sourceEndpoint,
                range,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadStreaming(Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="sourceEndpoint">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Stream}"/> containing the
        /// downloaded content.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<Stream> DownloadStreaming(
            Uri sourceEndpoint,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            _contentDownloader.DownloadStreamingInternal(
                sourceEndpoint,
                range,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadTo(Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationStream">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Uri sourceEndpoint, Stream destinationStream,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            _contentDownloader.StagedDownloadAsync(sourceEndpoint, destinationStream, transferOptions, async: false, cancellationToken: cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadToAsync(Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationStream">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Uri sourceEndpoint, Stream destinationStream, ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            await _contentDownloader.StagedDownloadAsync(sourceEndpoint, destinationStream, transferOptions, async: true, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Uri sourceEndpoint, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return _contentDownloader.StagedDownloadAsync(sourceEndpoint, destination, transferOptions,
                async: false, cancellationToken: cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Uri sourceEndpoint, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return await _contentDownloader.StagedDownloadAsync(sourceEndpoint, destination, transferOptions,
                async: true, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
