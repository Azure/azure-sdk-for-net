// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Call Media Client.
    /// </summary>
    public class CallMedia
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallMediaRestClient CallMediaRestClient { get; }
        internal CallAutomationEventProcessor EventProcessor { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallMedia(string callConnectionId, CallMediaRestClient callCallMediaRestClient, ClientDiagnostics clientDiagnostics, CallAutomationEventProcessor eventProcessor)
        {
            CallConnectionId = callConnectionId;
            CallMediaRestClient = callCallMediaRestClient;
            _clientDiagnostics = clientDiagnostics;
            EventProcessor = eventProcessor;
        }

        /// <summary>Initializes a new instance of <see cref="CallMedia"/> for mocking.</summary>
        protected CallMedia()
        {
            _clientDiagnostics = null;
            CallMediaRestClient = null;
            CallConnectionId = null;
        }

        /// <summary>
        /// Plays a file async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <param name="playOptions"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayAsync(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(playSource, playTo, playOptions);

                var response = await CallMediaRestClient.PlayAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new PlayResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
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
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> Play(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(playSource, playTo, playOptions);

                var response = CallMediaRestClient.Play(CallConnectionId, request, cancellationToken);

                var result = new PlayResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static PlayRequestInternal CreatePlayRequest(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, PlayOptions options)
        {
            PlaySourceInternal sourceInternal = TranslatePlaySourceToInternal(playSource);

            if (sourceInternal != null)
            {
                PlayRequestInternal request = new PlayRequestInternal(sourceInternal);
                request.PlayTo = playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList();

                if (options != null)
                {
                    request.PlayOptions = new PlayOptionsInternal(options.Loop);
                    request.OperationContext = options.OperationContext;
                }

                if (request.OperationContext == default)
                {
                    request.OperationContext = Guid.NewGuid().ToString();
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
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayToAllAsync(PlaySource playSource, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
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
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> PlayToAll(PlaySource playSource, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
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
        /// <returns>Returns <see cref="CancelAllMediaOperationsResult"/>, which can be used to wait for CancelAllMediaOperations' related events.</returns>
        public virtual async Task<Response<CancelAllMediaOperationsResult>> CancelAllMediaOperationsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                var response = await CallMediaRestClient.CancelAllMediaOperationsAsync(CallConnectionId, cancellationToken).ConfigureAwait(false);

                var result = new CancelAllMediaOperationsResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, null);

                return Response.FromValue(result, response);
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
        /// <returns>Returns <see cref="CancelAllMediaOperationsResult"/>, which can be used to wait for CancelAllMediaOperations' related events.</returns>
        public virtual Response<CancelAllMediaOperationsResult> CancelAllMediaOperations(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                var response = CallMediaRestClient.CancelAllMediaOperations(CallConnectionId, cancellationToken);

                var result = new CancelAllMediaOperationsResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, null);

                return Response.FromValue(result, response);
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
        /// <returns>Returns <see cref="StartRecognizingResult"/>, which can be used to wait for StartRecognizing's related events.</returns>
        public virtual async Task<Response<StartRecognizingResult>> StartRecognizingAsync(CallMediaRecognizeOptions recognizeOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartRecognizing)}");
            scope.Start();
            try
            {
                RecognizeRequestInternal request = CreateRecognizeRequest(recognizeOptions);

                var response = await CallMediaRestClient.RecognizeAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new StartRecognizingResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
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
        /// <returns>Returns <see cref="StartRecognizingResult"/>, which can be used to wait for StartRecognizing's related events.</returns>
        public virtual Response<StartRecognizingResult> StartRecognizing(CallMediaRecognizeOptions recognizeOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartRecognizing)}");
            scope.Start();
            try
            {
                RecognizeRequestInternal request = CreateRecognizeRequest(recognizeOptions);

                var response = CallMediaRestClient.Recognize(CallConnectionId, request, cancellationToken);

                var result = new StartRecognizingResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static RecognizeRequestInternal CreateRecognizeRequest(CallMediaRecognizeOptions recognizeOptions)
        {
            if (recognizeOptions == null)
                throw new ArgumentNullException(nameof(recognizeOptions));

            if (recognizeOptions is CallMediaRecognizeDtmfOptions recognizeDtmfOptions)
            {
                DtmfOptionsInternal dtmfConfigurations = new DtmfOptionsInternal()
                {
                    InterToneTimeoutInSeconds = (int)recognizeDtmfOptions.InterToneTimeout.TotalSeconds,
                    MaxTonesToCollect = recognizeDtmfOptions.MaxTonesToCollect,
                    StopTones = recognizeDtmfOptions.StopTones
                };

                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer.Serialize(recognizeDtmfOptions.TargetParticipant))
                {
                    DtmfOptions = dtmfConfigurations,
                    InterruptPrompt = recognizeDtmfOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeDtmfOptions.InitialSilenceTimeout.TotalSeconds
                };

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeDtmfOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeDtmfOptions.Prompt);
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;

                return request;
            }
            else if (recognizeOptions is CallMediaRecognizeChoiceOptions recognizeChoiceOptions)
            {
                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer.Serialize(recognizeChoiceOptions.TargetParticipant))
                {
                    InterruptPrompt = recognizeChoiceOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeChoiceOptions.InitialSilenceTimeout.TotalSeconds
                };

                recognizeChoiceOptions.RecognizeChoices
                    .ToList().ForEach(t => recognizeConfigurationsInternal.Choices.Add(t));

                if (!String.IsNullOrEmpty(recognizeChoiceOptions.SpeechLanguage))
                {
                    recognizeConfigurationsInternal.SpeechLanguage = recognizeChoiceOptions.SpeechLanguage;
                }

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeChoiceOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeChoiceOptions.Prompt);
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;

                return request;
            }
            else
            {
                throw new NotSupportedException(recognizeOptions.GetType().Name);
            }
        }

        private static PlaySourceInternal TranslatePlaySourceToInternal(PlaySource playSource)
        {
            PlaySourceInternal sourceInternal;

            if (playSource != null && playSource is FileSource fileSource)
            {
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.File);
                sourceInternal.FileSource = new FileSourceInternal(fileSource.FileUri.AbsoluteUri);
                sourceInternal.PlaySourceId = fileSource.PlaySourceId;
                return sourceInternal;
            }
            else if (playSource != null && playSource is TextSource textSource)
            {
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.Text);
                sourceInternal.TextSource = new TextSourceInternal(textSource.Text);
                sourceInternal.TextSource.SourceLocale = textSource.SourceLocale ?? null;
                sourceInternal.TextSource.VoiceGender = textSource.VoiceGender ?? GenderType.Male;
                sourceInternal.TextSource.VoiceName = textSource.VoiceName ?? null;
                sourceInternal.PlaySourceId = textSource.PlaySourceId;
                return sourceInternal;
            }
            else
            { return null; }
        }

        /// <summary>
        /// Starts recognizing Dtmf tones continuously in async mode.
        /// </summary>
        /// <param name="continuousDtmfOptions">Configuration attributes to start continuous Dtmf Recognition.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<StartContinuousDtmfRecognizingResult>> StartContinuousDtmfRecognizingAsync(ContinuousDtmfRecognizeOptions continuousDtmfOptions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognizing)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = CreateContinuousDtmfRequest(continuousDtmfOptions);

                var response = await CallMediaRestClient.StartContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new StartContinuousDtmfRecognizingResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts recognizing Dtmf tones continuously.
        /// </summary>
        /// <param name="continuousDtmfOptions">Configuration attributes to start continuous Dtmf Recognition.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<StartContinuousDtmfRecognizingResult> StartContinuousDtmfRecognizing(ContinuousDtmfRecognizeOptions continuousDtmfOptions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognizing)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = CreateContinuousDtmfRequest(continuousDtmfOptions);

                var response = CallMediaRestClient.StartContinuousDtmfRecognition(CallConnectionId, request, cancellationToken);

                var result = new StartContinuousDtmfRecognizingResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

/*        /// <summary>
        /// Stops recognizing continuous Dtmf tones in async mode.
        /// </summary>
        /// <param name="continuousDtmfOptions">Configuration attributes to stop continuous Dtmf Recognition.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<StopContinuousDtmfRecognizingResult>> StopContinuousDtmfRecognizingAsync(ContinuousDtmfRecognizeOptions continuousDtmfOptions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognizing)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = CreateContinuousDtmfRequest(continuousDtmfOptions);

                var response = await CallMediaRestClient.StopContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new StopContinuousDtmfRecognizingResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops recognizing continuous Dtmf tones.
        /// </summary>
        /// <param name="continuousDtmfOptions">Configuration attributes to stop continuous Dtmf Recognition.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<StopContinuousDtmfRecognizingResult> StopContinuousDtmfRecognizing(ContinuousDtmfRecognizeOptions continuousDtmfOptions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognizing)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = CreateContinuousDtmfRequest(continuousDtmfOptions);

                var response = CallMediaRestClient.StopContinuousDtmfRecognition(CallConnectionId, request, cancellationToken);

                var result = new StopContinuousDtmfRecognizingResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }*/

        private ContinuousDtmfRecognitionRequestInternal CreateContinuousDtmfRequest(ContinuousDtmfRecognizeOptions continuousDtmfOptions)
        {
            if (continuousDtmfOptions == null)
            {
                throw new ArgumentNullException(nameof(continuousDtmfOptions));
            }

            ContinuousDtmfRecognitionOptionsInternal optionsInternal = new ContinuousDtmfRecognitionOptionsInternal
                (CommunicationIdentifierSerializer.Serialize(continuousDtmfOptions.TargetParticipant));

            return new ContinuousDtmfRecognitionRequestInternal(optionsInternal);
        }
    }
}
