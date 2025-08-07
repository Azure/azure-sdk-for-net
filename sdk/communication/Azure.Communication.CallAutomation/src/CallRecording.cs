// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Call Recording client.
    /// </summary>
    public class CallRecording
    {
        internal readonly string _resourceEndpoint;
        internal readonly ContentDownloader _contentDownloader;
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;
        internal readonly CallRecordingRestClient _callRecordingRestClient;

        internal CallRecording(string resourceEndpoint, CallRecordingRestClient callRecordingRestClient, ClientDiagnostics clientDiagnostics, HttpPipeline httpPipeline)
        {
            _resourceEndpoint = resourceEndpoint;
            _callRecordingRestClient = callRecordingRestClient;
            _contentDownloader = new(this);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = httpPipeline;
        }

        /// <summary>Initializes a new instance of <see cref="CallRecording"/> for mocking.</summary>
        protected CallRecording()
        {
            _resourceEndpoint = null;
            _callRecordingRestClient = null;
            _contentDownloader = new(this);
            _clientDiagnostics = null;
            _pipeline = null;
        }

        /// <summary>
        /// Start recording of the call.
        /// </summary>
        /// <param name="options">Options for start recording</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<RecordingStateResult> Start(StartRecordingOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Start)}");
            scope.Start();
            try
            {
                StartCallRecordingRequestInternal request = new StartCallRecordingRequestInternal()
                {
                    RecordingStateCallbackUri = options.RecordingStateCallbackUri?.AbsoluteUri,
                    RecordingChannelType = options.RecordingChannel,
                    RecordingContentType = options.RecordingContent,
                    RecordingFormatType = options.RecordingFormat,
                    PauseOnStart = options.PauseOnStart
                };

                if (options.CallLocator != null)
                {
                    request.CallLocator = CallLocatorSerializer.Serialize(options.CallLocator);
                }
                else if (options.CallConnectionId != null)
                {
                    request.CallConnectionId = options.CallConnectionId;
                }

                if (options.AudioChannelParticipantOrdering != null && options.AudioChannelParticipantOrdering.Any())
                {
                    foreach (var c in options.AudioChannelParticipantOrdering)
                    {
                        request.AudioChannelParticipantOrdering.Add(CommunicationIdentifierSerializer_2025_06_30.Serialize(c));
                    }
                }

                if (options.ChannelAffinity != null && options.ChannelAffinity.Any())
                {
                    foreach (var c in options.ChannelAffinity)
                    {
                        ChannelAffinityInternal newChannelAffinity = new ChannelAffinityInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(c.Participant));
                        if (c.Channel != null)
                        {
                            newChannelAffinity.Channel = c.Channel;
                        }
                        request.ChannelAffinity.Add(newChannelAffinity);
                    }
                }

                if (options.RecordingStorage != null)
                {
                    // This is required only when blob storage in use
                    if (options.RecordingStorage is AzureBlobContainerRecordingStorage blobStorage)
                    {
                        request.ExternalStorage = new RecordingStorageInternal(blobStorage.RecordingStorageKind, blobStorage.RecordingDestinationContainerUri);
                    }
                }

                return _callRecordingRestClient.StartRecording(request, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Start recording of the call.
        /// </summary>
        /// <param name="options">Options for start recording</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<RecordingStateResult>> StartAsync(StartRecordingOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Start)}");
            scope.Start();
            try
            {
                StartCallRecordingRequestInternal request = new StartCallRecordingRequestInternal()
                {
                    RecordingStateCallbackUri = options.RecordingStateCallbackUri?.AbsoluteUri,
                    RecordingChannelType = options.RecordingChannel,
                    RecordingContentType = options.RecordingContent,
                    RecordingFormatType = options.RecordingFormat,
                    PauseOnStart = options.PauseOnStart
                };

                if (options.CallLocator != null)
                {
                    request.CallLocator = CallLocatorSerializer.Serialize(options.CallLocator);
                }
                else if (options.CallConnectionId != null)
                {
                    request.CallConnectionId = options.CallConnectionId;
                }

                if (options.AudioChannelParticipantOrdering != null && options.AudioChannelParticipantOrdering.Any())
                {
                    foreach (var c in options.AudioChannelParticipantOrdering)
                    {
                        request.AudioChannelParticipantOrdering.Add(CommunicationIdentifierSerializer_2025_06_30.Serialize(c));
                    }
                };

                if (options.ChannelAffinity != null && options.ChannelAffinity.Any())
                {
                    foreach (var c in options.ChannelAffinity)
                    {
                        ChannelAffinityInternal newChannelAffinity = new ChannelAffinityInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(c.Participant));
                        if (c.Channel != null)
                        {
                            newChannelAffinity.Channel = c.Channel;
                        }
                        request.ChannelAffinity.Add(newChannelAffinity);
                    }
                }

                if (options.RecordingStorage != null)
                {
                    // This is required only when blob storage in use
                    if (options.RecordingStorage is AzureBlobContainerRecordingStorage blobStorage)
                    {
                        request.ExternalStorage = new RecordingStorageInternal(blobStorage.RecordingStorageKind, blobStorage.RecordingDestinationContainerUri);
                    }
                }

                return await _callRecordingRestClient.StartRecordingAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get the current recording state by recording id.
        /// </summary>
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<RecordingStateResult> GetState(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(GetState)}");
            scope.Start();
            try
            {
                return _callRecordingRestClient.GetRecordingProperties(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get the current recording state by recording id.
        /// </summary>
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<RecordingStateResult>> GetStateAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(GetState)}");
            scope.Start();
            try
            {
                return await _callRecordingRestClient.GetRecordingPropertiesAsync(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop recording of the call.
        /// </summary>
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response Stop(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Stop)}");
            scope.Start();
            try
            {
                return _callRecordingRestClient.StopRecording(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop recording of the call.
        /// </summary>
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> StopAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Stop)}");
            scope.Start();
            try
            {
                return await _callRecordingRestClient.StopRecordingAsync(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Pause recording of the call.
        /// </summary>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> PauseAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Pause)}");
            scope.Start();
            try
            {
                return await _callRecordingRestClient.PauseRecordingAsync(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Pause recording of the call.
        /// </summary>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response Pause(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Pause)}");
            scope.Start();
            try
            {
                return _callRecordingRestClient.PauseRecording(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resume recording of the call.
        /// </summary>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> ResumeAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Resume)}");
            scope.Start();
            try
            {
                return await _callRecordingRestClient.ResumeRecordingAsync(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// resume recording of the call.
        /// </summary>
        /// <param name="recordingId">The recording id to resume.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response Resume(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Resume)}");
            scope.Start();
            try
            {
                return _callRecordingRestClient.ResumeRecording(
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
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
        /// <param name="sourceLocation">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
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
            Uri sourceLocation,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            await _contentDownloader.DownloadStreamingInternal(
                sourceLocation,
                range,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadStreaming(Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="sourceLocation">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
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
            Uri sourceLocation,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            _contentDownloader.DownloadStreamingInternal(
                sourceLocation,
                range,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadTo(Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="sourceLocation">
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
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Uri sourceLocation, Stream destinationStream,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            _contentDownloader.StagedDownloadAsync(sourceLocation, destinationStream, transferOptions, async: false, cancellationToken: cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadToAsync(Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="sourceLocation">
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
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Uri sourceLocation, Stream destinationStream, ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            await _contentDownloader.StagedDownloadAsync(sourceLocation, destinationStream, transferOptions, async: true, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="sourceLocation">
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
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Uri sourceLocation, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return _contentDownloader.StagedDownloadAsync(sourceLocation, destination, transferOptions,
                async: false, cancellationToken: cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="sourceLocation">
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
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Uri sourceLocation, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return await _contentDownloader.StagedDownloadAsync(sourceLocation, destination, transferOptions,
                async: true, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="Delete(Uri, CancellationToken)"/>
        /// operation deletes the specified content from storage.
        /// </summary>
        /// <param name="recordingLocation">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response Delete(Uri recordingLocation, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                HttpMessage message = AmsDirectRequestHelpers.GetHttpMessage(this, recordingLocation, RequestMethod.Delete);
                _pipeline.Send(message, cancellationToken);

                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DeleteAsync(Uri, CancellationToken)"/>
        /// operation deletes the specified content from storage
        /// using parallel requests.
        /// </summary>
        /// <param name="recordingLocation">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(Uri recordingLocation, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallRecording)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                HttpMessage message = AmsDirectRequestHelpers.GetHttpMessage(this, recordingLocation, RequestMethod.Delete);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
