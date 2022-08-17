// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Call Media Client.
    /// </summary>
    public class CallMedia
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ContentRestClient ContentRestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallMedia(string callConnectionId, ContentRestClient CallContentRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            ContentRestClient = CallContentRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallMedia"/> for mocking.</summary>
        protected CallMedia()
        {
            _clientDiagnostics = null;
            ContentRestClient = null;
            CallConnectionId = null;
        }

        /// <summary>
        /// Plays a file async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <param name="playOptions"></param>
        /// <returns></returns>
        public virtual async Task<Response> PlayAsync(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(playSource, playTo, playOptions);

                return await ContentRestClient.PlayAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Plays a file.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <param name="playOptions"></param>
        /// <returns></returns>
        public virtual Response Play(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(playSource, playTo, playOptions);

                return ContentRestClient.Play(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static PlayRequestInternal CreatePlayRequest(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, PlayOptions options)
        {
            if (playSource is FileSource fileSource)
            {
                PlaySourceInternal sourceInternal;
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.File);
                sourceInternal.FileSource = new FileSourceInternal(fileSource.FileUri.AbsoluteUri);
                sourceInternal.PlaySourceId = playSource.PlaySourceId;

                PlayRequestInternal request = new PlayRequestInternal(sourceInternal);
                request.PlayTo = playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList();

                if (options != null)
                {
                    request.PlayOptions = new PlayOptionsInternal(options.Loop);
                    request.OperationContext = options.OperationContext;
                }

                return request;
            }

            throw new NotSupportedException(playSource.GetType().Name);
        }

        /// <summary>
        /// Play to all participants async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="playOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> PlayToAllAsync(PlaySource playSource, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return await PlayAsync(playSource, Enumerable.Empty<CommunicationIdentifier>(), playOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Play to all participants.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="playOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response PlayToAll(PlaySource playSource, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return Play(playSource, Enumerable.Empty<CommunicationIdentifier>(), playOptions, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel any media operation to all participants.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> CancelAllMediaOperationsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return await ContentRestClient.CancelAllMediaOperationsAsync(CallConnectionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel any media operation to all participants.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response CancelAllMediaOperations(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return ContentRestClient.CancelAllMediaOperations(CallConnectionId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Recognize tones.
        /// </summary>
        /// <param name="recognizeOptions">Configuration attributes for recognize.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> RecognizeAsync(RecognizeOptions recognizeOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Recognize)}");
            scope.Start();
            try
            {
                RecognizeRequestInternal request = CreateRecognizeRequest(recognizeOptions);
                return await ContentRestClient.RecognizeAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Recognize tones.
        /// </summary>
        /// <param name="recognizeOptions">Configuration attributes for recognize.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response Recognize(RecognizeOptions recognizeOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Recognize)}");
            scope.Start();
            try
            {
                RecognizeRequestInternal request = CreateRecognizeRequest(recognizeOptions);
                return ContentRestClient.Recognize(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static RecognizeRequestInternal CreateRecognizeRequest(RecognizeOptions recognizeOptions)
        {
            if (recognizeOptions == null)
                throw new ArgumentNullException(nameof(recognizeOptions));
            RecognizeConfigurations recognizeConfigurations = recognizeOptions.RecognizeConfigurations;

            if (recognizeConfigurations == null)
                throw new ArgumentException(nameof(recognizeConfigurations));

            DtmfConfigurationsInternal dtmfConfigurations = null;
            if (recognizeConfigurations.DtmfConfigurations != null)
            {
                dtmfConfigurations = new DtmfConfigurationsInternal()
                {
                    InterToneTimeoutInSeconds = (int)recognizeConfigurations.DtmfConfigurations.InterToneTimeoutInSeconds.TotalSeconds,
                    MaxTonesToCollect = recognizeConfigurations.DtmfConfigurations.MaxTonesToCollect,
                    StopTones = (IList<StopTones>)recognizeConfigurations.DtmfConfigurations.StopTones
                };
            }

            RecognizeConfigurationsInternal recognizeConfigurationsInternal = new RecognizeConfigurationsInternal()
            {
                DtmfConfigurations = dtmfConfigurations,
                InterruptPromptAndStartRecognition = recognizeConfigurations.InterruptPromptAndStartRecognition,
                InitialSilenceTimeoutInSeconds = (int)recognizeConfigurations.InitialSilenceTimeoutInSeconds.TotalSeconds,
                TargetParticipant = CommunicationIdentifierSerializer.Serialize(recognizeConfigurations.TargetParticipant)
            };

            RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeOptions.RecognizeInputType, recognizeConfigurationsInternal);

            if (recognizeOptions.Prompt != null && recognizeOptions.Prompt is FileSource fileSource)
            {
                PlaySourceInternal sourceInternal;
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.File);
                sourceInternal.FileSource = new FileSourceInternal(fileSource.FileUri.AbsoluteUri);
                sourceInternal.PlaySourceId = recognizeOptions.Prompt.PlaySourceId;

                request.PlayPrompt = sourceInternal;
            }
            else if (recognizeOptions.Prompt != null)
            {
                throw new NotSupportedException(recognizeOptions.Prompt.GetType().Name);
            }

            request.StopCurrentOperations = recognizeOptions.StopCurrentOperations;
            request.OperationContext = recognizeOptions.OperationContext;

            return request;
        }
    }
}
