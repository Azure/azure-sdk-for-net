﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Plays audio to specified participant(s) async.
        /// </summary>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <param name="options">An optional object containing play options and configurations.</param>
        /// <returns>Returns a <see cref="PlayResult"/> object, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayAsync(PlayOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(options);

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
        /// Plays audio to specified participant(s) async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayAsync(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                var playOptions = new PlayOptions(playSource, playTo)
                {
                    Loop = false,
                    OperationContext = null
                };

                PlayRequestInternal request = CreatePlayRequest(playOptions);

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
        /// Plays audio to specified participant(s).
        /// </summary>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <param name="options">An optional object containing play options and configurations.</param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> Play(PlayOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(options);

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

        /// <summary>
        /// Plays a file.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> Play(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                var playOptions = new PlayOptions(playSource, playTo)
                {
                    Loop = false,
                    OperationContext = null
                };

                PlayRequestInternal request = CreatePlayRequest(playOptions);

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

        private static PlayRequestInternal CreatePlayRequest(PlayOptions options)
        {
            PlaySourceInternal sourceInternal = TranslatePlaySourceToInternal(options.PlaySource);

            if (sourceInternal != null)
            {
                PlayRequestInternal request = new PlayRequestInternal(sourceInternal);
                request.PlayTo = options.PlayTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList();

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

            throw new NotSupportedException(options.PlaySource.GetType().Name);
        }

        /// <summary>
        /// Play audio to all participants async.
        /// </summary>
        /// <param name="options">An optional object containing play options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayToAllAsync(PlayToAllOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                PlayOptions playOptions = new PlayOptions(options.PlaySource, Enumerable.Empty<CommunicationIdentifier>());
                playOptions.OperationContext = options.OperationContext;
                playOptions.Loop = options.Loop;
                return await PlayAsync(playOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Play to all participants async.
        /// </summary>
        /// <param name="playSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayToAllAsync(PlaySource playSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return await PlayAsync(playSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Play audio to all participants.
        /// </summary>
        /// <param name="options">An optional object containing play options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> PlayToAll(PlayToAllOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                PlayOptions playOptions = new PlayOptions(options.PlaySource, Enumerable.Empty<CommunicationIdentifier>());
                playOptions.OperationContext = options.OperationContext;
                playOptions.Loop = options.Loop;
                return Play(playOptions, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> PlayToAll(PlaySource playSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return Play(playSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken);
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
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
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
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
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
        /// <param name="options">Configuration attributes for recognize.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns <see cref="StartRecognizingCallMediaResult"/>, which can be used to wait for StartRecognizing's related events.</returns>
        public virtual async Task<Response<StartRecognizingCallMediaResult>> StartRecognizingAsync(CallMediaRecognizeOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartRecognizing)}");
            scope.Start();
            try
            {
                RecognizeRequestInternal request = CreateRecognizeRequest(options);

                var response = await CallMediaRestClient.RecognizeAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new StartRecognizingCallMediaResult();
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
        /// <param name="options">Configuration attributes for recognize.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns <see cref="StartRecognizingCallMediaResult"/>, which can be used to wait for StartRecognizing's related events.</returns>
        public virtual Response<StartRecognizingCallMediaResult> StartRecognizing(CallMediaRecognizeOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartRecognizing)}");
            scope.Start();
            try
            {
                RecognizeRequestInternal request = CreateRecognizeRequest(options);

                var response = CallMediaRestClient.Recognize(CallConnectionId, request, cancellationToken);

                var result = new StartRecognizingCallMediaResult();
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
                    StopTones = recognizeDtmfOptions.StopTones.ToList<DtmfTone>()
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
            else if (recognizeOptions is CallMediaRecognizeSpeechOptions recognizeSpeechOptions)
            {
                SpeechOptionsInternal speechConfigurations = new SpeechOptionsInternal()
                {
                    EndSilenceTimeoutInMs = (long)recognizeSpeechOptions.EndSilenceTimeoutInMs.TotalMilliseconds
                };

                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer.Serialize(recognizeSpeechOptions.TargetParticipant))
                {
                    InterruptPrompt = recognizeSpeechOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeSpeechOptions.InitialSilenceTimeout.TotalSeconds,
                    SpeechOptions = speechConfigurations
                };

                if (!String.IsNullOrEmpty(recognizeSpeechOptions.SpeechLanguage))
                {
                    recognizeConfigurationsInternal.SpeechLanguage = recognizeSpeechOptions.SpeechLanguage;
                }

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeSpeechOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeSpeechOptions.Prompt);
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;

                return request;
            }
            else if (recognizeOptions is CallMediaRecognizeSpeechOrDtmfOptions recognizeSpeechOrDtmfOptions)
            {
                SpeechOptionsInternal speechConfigurations = new SpeechOptionsInternal()
                {
                    EndSilenceTimeoutInMs = (long)recognizeSpeechOrDtmfOptions.EndSilenceTimeoutInMs.TotalMilliseconds
                };

                DtmfOptionsInternal dtmfConfigurations = new DtmfOptionsInternal()
                {
                    InterToneTimeoutInSeconds = (int)recognizeSpeechOrDtmfOptions.InterToneTimeout.TotalSeconds,
                    MaxTonesToCollect = recognizeSpeechOrDtmfOptions.MaxTonesToCollect,
                    StopTones = recognizeSpeechOrDtmfOptions.StopTones
                };

                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer.Serialize(recognizeSpeechOrDtmfOptions.TargetParticipant))
                {
                    InterruptPrompt = recognizeSpeechOrDtmfOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeSpeechOrDtmfOptions.InitialSilenceTimeout.TotalSeconds,
                    SpeechOptions = speechConfigurations,
                    DtmfOptions = dtmfConfigurations,
                };

                if (!String.IsNullOrEmpty(recognizeSpeechOrDtmfOptions.SpeechLanguage))
                {
                    recognizeConfigurationsInternal.SpeechLanguage = recognizeSpeechOrDtmfOptions.SpeechLanguage;
                }

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeSpeechOrDtmfOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeSpeechOrDtmfOptions.Prompt);
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
            else if (playSource != null && playSource is SsmlSource ssmlSource)
            {
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.Ssml);
                sourceInternal.SsmlSource = new SsmlSourceInternal(ssmlSource.SsmlText);
                sourceInternal.PlaySourceId = ssmlSource.PlaySourceId;
                return sourceInternal;
            }
            else
            { return null; }
        }

        /// <summary>
        /// Starts continuous Dtmf recognition.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for starting continuous Dtmf recognition.</param>
        /// <param name="operationContext">An optional context object containing information about the operation, such as a unique identifier or custom metadata.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StartContinuousDtmfRecognition(CommunicationIdentifier targetParticipant, string operationContext = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(targetParticipant))
                {
                    OperationContext = operationContext
                };

                return CallMediaRestClient.StartContinuousDtmfRecognition(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts continuous Dtmf recognition in async mode.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for starting continuous Dtmf recognition.</param>
        /// <param name="operationContext">An optional context object containing information about the operation, such as a unique identifier or custom metadata.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StartContinuousDtmfRecognitionAsync(CommunicationIdentifier targetParticipant, string operationContext = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(targetParticipant))
                {
                    OperationContext = operationContext
                };

                return await CallMediaRestClient.StartContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
                ;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops continuous Dtmf recognition.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for stopping continuous Dtmf recognition.</param>
        /// <param name="operationContext">An optional context object containing information about the operation, such as a unique identifier or custom metadata.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StopContinuousDtmfRecognition(CommunicationIdentifier targetParticipant, string operationContext = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(targetParticipant))
                {
                    OperationContext = operationContext
                };

                return CallMediaRestClient.StopContinuousDtmfRecognition(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops continuous Dtmf recognition in async mode.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for stopping continuous Dtmf recognition.</param>
        /// <param name="operationContext">An optional context object containing information about the operation, such as a unique identifier or custom metadata.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StopContinuousDtmfRecognitionAsync(CommunicationIdentifier targetParticipant, string operationContext = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(targetParticipant))
                {
                    OperationContext = operationContext
                };

                return await CallMediaRestClient.StopContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Send Dtmf tones in async mode.
        /// </summary>
        /// <param name="tones">A list of Tones to be sent.</param>
        /// <param name="targetParticipant">A target participant identifier for starting continuous Dtmf recognition.</param>
        /// <param name="operationContext">An optional context object containing information about the operation, such as a unique identifier or custom metadata.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns a Response containing a SendDtmfResult object indicating the result of the send operation.</returns>
        public virtual async Task<Response<SendDtmfResult>> SendDtmfAsync(IEnumerable<DtmfTone> tones, CommunicationIdentifier targetParticipant,
            string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(SendDtmf)}");
            scope.Start();
            try
            {
                SendDtmfRequestInternal request = request = new(tones, CommunicationIdentifierSerializer.Serialize(targetParticipant));

                request.OperationContext = operationContext;

                var response = await CallMediaRestClient.SendDtmfAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new SendDtmfResult();
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
        /// Send Dtmf tones.
        /// </summary>
        /// <param name="tones">A list of Tones to be sent.</param>
        /// <param name="targetParticipant">A target participant identifier for starting continuous Dtmf recognition.</param>
        /// <param name="operationContext">An optional context object containing information about the operation, such as a unique identifier or custom metadata.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns a Response containing a SendDtmfResult object indicating the result of the send operation.</returns>
        public virtual Response<SendDtmfResult> SendDtmf(IEnumerable<DtmfTone> tones, CommunicationIdentifier targetParticipant,
            string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(SendDtmf)}");
            scope.Start();
            try
            {
                SendDtmfRequestInternal request = new(tones, CommunicationIdentifierSerializer.Serialize(targetParticipant));

                request.OperationContext = operationContext;

                var response = CallMediaRestClient.SendDtmf(CallConnectionId, request, cancellationToken);

                var result = new SendDtmfResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
