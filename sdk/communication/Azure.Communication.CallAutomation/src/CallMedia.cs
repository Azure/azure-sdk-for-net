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
        /// Plays audio to specified participant(s) async.
        /// </summary>
        /// <param name="playSources"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayAsync(IEnumerable<PlaySource> playSources, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                var playOptions = new PlayOptions(playSources, playTo)
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

        /// <summary>
        /// Plays a file.
        /// </summary>
        /// <param name="playSources"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> Play(IEnumerable<PlaySource> playSources, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
            scope.Start();
            try
            {
                var playOptions = new PlayOptions(playSources, playTo)
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
            PlayRequestInternal request = new PlayRequestInternal(options.PlaySources.Select(t => TranslatePlaySourceToInternal(t)).ToList());

            request.PlayTo = options.PlayTo.Select(t => CommunicationIdentifierSerializer_2025_06_30.Serialize(t)).ToList();

            if (options != null)
            {
                request.PlayOptions = new PlayOptionsInternal(options.Loop);
                request.InterruptCallMediaOperation = options.InterruptCallMediaOperation;
                request.OperationContext = options.OperationContext;
                request.OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri;
            }

            if (request.OperationContext == default)
            {
                request.OperationContext = Guid.NewGuid().ToString();
            }

            return request;
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
                PlayOptions playOptions = new PlayOptions(options.PlaySources, Enumerable.Empty<CommunicationIdentifier>());
                playOptions.OperationContext = options.OperationContext;
                playOptions.Loop = options.Loop;
                playOptions.OperationCallbackUri = options.OperationCallbackUri;
                playOptions.InterruptCallMediaOperation = options.InterruptCallMediaOperation;
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
        /// Play to all participants async.
        /// </summary>
        /// <param name="playSources"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual async Task<Response<PlayResult>> PlayToAllAsync(IEnumerable<PlaySource> playSources, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return await PlayAsync(playSources, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken).ConfigureAwait(false);
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
                PlayOptions playOptions = new PlayOptions(options.PlaySources, Enumerable.Empty<CommunicationIdentifier>());
                playOptions.OperationContext = options.OperationContext;
                playOptions.Loop = options.Loop;
                playOptions.OperationCallbackUri = options.OperationCallbackUri;
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
        /// Play to all participants.
        /// </summary>
        /// <param name="playSources"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns <see cref="PlayResult"/>, which can be used to wait for Play's related events.</returns>
        public virtual Response<PlayResult> PlayToAll(IEnumerable<PlaySource> playSources, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return Play(playSources, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken);
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

        /// <summary>
        /// Hold participant from the call.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> HoldAsync(HoldOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(HoldAsync)}");
            scope.Start();
            try
            {
                var request = new HoldRequestInternal(
                    CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    PlaySourceInfo = TranslatePlaySourceToInternal(options.PlaySource),
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                };

                return await CallMediaRestClient.HoldAsync(CallConnectionId, request, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Hold participant from the call.
        /// </summary>
        /// <param name="targetParticipant">The targetParticipant.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> HoldAsync(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(HoldAsync)}");
            scope.Start();
            try
            {
                var request = new HoldRequestInternal(
                    CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return await CallMediaRestClient.HoldAsync(CallConnectionId, request, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Hold participant from the call.
        /// </summary>
        /// <param name="targetParticipant">The targetParticipant.</param>
        /// <param name="playSource">The playsource.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> HoldAsync(CommunicationIdentifier targetParticipant, PlaySource playSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(HoldAsync)}");
            scope.Start();
            try
            {
                var request = new HoldRequestInternal(
                    CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant))
                {
                    PlaySourceInfo = TranslatePlaySourceToInternal(playSource),
                };

                return await CallMediaRestClient.HoldAsync(CallConnectionId, request, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Hold participant from the call.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response Hold(HoldOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Hold)}");
            scope.Start();
            try
            {
                var request = new HoldRequestInternal(
                    CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    PlaySourceInfo = TranslatePlaySourceToInternal(options.PlaySource),
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                };

                return CallMediaRestClient.Hold(CallConnectionId, request, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Hold participant from the call.
        /// </summary>
        /// <param name="targetParticipant">The targetParticipant.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response Hold(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Hold)}");
            scope.Start();
            try
            {
                var request = new HoldRequestInternal(
                    CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return CallMediaRestClient.Hold(CallConnectionId, request, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Hold participant from the call.
        /// </summary>
        /// <param name="targetParticipant">The targetParticipant.</param>
        /// <param name="playSource">The playsource.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response Hold(CommunicationIdentifier targetParticipant, PlaySource playSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Hold)}");
            scope.Start();
            try
            {
                var request = new HoldRequestInternal(
                    CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant))
                {
                    PlaySourceInfo = TranslatePlaySourceToInternal(playSource),
                };

                return CallMediaRestClient.Hold(CallConnectionId, request, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove hold from participant.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> UnholdAsync(UnholdOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(UnholdAsync)}");
            scope.Start();
            try
            {
                var request = new UnholdRequestInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                    OperationContext = options.OperationContext
                };

                return await CallMediaRestClient.UnholdAsync(CallConnectionId, request, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove hold from participant.
        /// </summary>
        /// <param name="targetParticipant">The targetParticipant.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> UnholdAsync(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(UnholdAsync)}");
            scope.Start();
            try
            {
                var request = new UnholdRequestInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return await CallMediaRestClient.UnholdAsync(CallConnectionId, request, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove hold from participant.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response Unhold(UnholdOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Unhold)}");
            scope.Start();
            try
            {
                var request = new UnholdRequestInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                    OperationContext = options.OperationContext
                };

                return CallMediaRestClient.Unhold(CallConnectionId, request, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove hold from participant.
        /// </summary>
        /// <param name="targetParticipant">The targetParticipant.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response Unhold(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Unhold)}");
            scope.Start();
            try
            {
                var request = new UnholdRequestInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return CallMediaRestClient.Unhold(CallConnectionId, request, cancellationToken: cancellationToken);
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

                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(recognizeDtmfOptions.TargetParticipant))
                {
                    DtmfOptions = dtmfConfigurations,
                    InterruptPrompt = recognizeDtmfOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeDtmfOptions.InitialSilenceTimeout.TotalSeconds
                };

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeDtmfOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeDtmfOptions.Prompt);
                if (recognizeOptions.PlayPrompts != null && recognizeOptions.PlayPrompts.Any())
                    request.PlayPrompts = recognizeOptions.PlayPrompts.Select(t => TranslatePlaySourceToInternal(t)).ToList();
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;
                request.OperationCallbackUri = recognizeOptions.OperationCallbackUri?.AbsoluteUri;

                return request;
            }
            else if (recognizeOptions is CallMediaRecognizeChoiceOptions recognizeChoiceOptions)
            {
                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(recognizeChoiceOptions.TargetParticipant))
                {
                    InterruptPrompt = recognizeChoiceOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeChoiceOptions.InitialSilenceTimeout.TotalSeconds
                };

                recognizeChoiceOptions.Choices
                    .ToList().ForEach(t => recognizeConfigurationsInternal.Choices.Add(t));

                if (!String.IsNullOrEmpty(recognizeChoiceOptions.SpeechLanguage))
                {
                    recognizeConfigurationsInternal.SpeechLanguage = recognizeChoiceOptions.SpeechLanguage;
                }

                if (!String.IsNullOrEmpty(recognizeChoiceOptions.SpeechModelEndpointId))
                {
                    recognizeConfigurationsInternal.SpeechRecognitionModelEndpointId = recognizeChoiceOptions.SpeechModelEndpointId;
                }

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeChoiceOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeChoiceOptions.Prompt);
                if (recognizeOptions.PlayPrompts != null && recognizeOptions.PlayPrompts.Any())
                    request.PlayPrompts = recognizeOptions.PlayPrompts.Select(t => TranslatePlaySourceToInternal(t)).ToList();
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;
                request.OperationCallbackUri = recognizeOptions.OperationCallbackUri?.AbsoluteUri;

                return request;
            }
            else if (recognizeOptions is CallMediaRecognizeSpeechOptions recognizeSpeechOptions)
            {
                SpeechOptionsInternal speechConfigurations = new SpeechOptionsInternal()
                {
                    EndSilenceTimeoutInMs = (long)recognizeSpeechOptions.EndSilenceTimeout.TotalMilliseconds
                };

                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(recognizeSpeechOptions.TargetParticipant))
                {
                    InterruptPrompt = recognizeSpeechOptions.InterruptPrompt,
                    InitialSilenceTimeoutInSeconds = (int)recognizeSpeechOptions.InitialSilenceTimeout.TotalSeconds,
                    SpeechOptions = speechConfigurations
                };

                if (!String.IsNullOrEmpty(recognizeSpeechOptions.SpeechLanguage))
                {
                    recognizeConfigurationsInternal.SpeechLanguage = recognizeSpeechOptions.SpeechLanguage;
                }

                if (!String.IsNullOrEmpty(recognizeSpeechOptions.SpeechModelEndpointId))
                {
                    recognizeConfigurationsInternal.SpeechRecognitionModelEndpointId = recognizeSpeechOptions.SpeechModelEndpointId;
                }

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeSpeechOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeSpeechOptions.Prompt);
                if (recognizeOptions.PlayPrompts != null && recognizeOptions.PlayPrompts.Any())
                    request.PlayPrompts = recognizeOptions.PlayPrompts.Select(t => TranslatePlaySourceToInternal(t)).ToList();
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;
                request.OperationCallbackUri = recognizeOptions.OperationCallbackUri?.AbsoluteUri;

                return request;
            }
            else if (recognizeOptions is CallMediaRecognizeSpeechOrDtmfOptions recognizeSpeechOrDtmfOptions)
            {
                SpeechOptionsInternal speechConfigurations = new SpeechOptionsInternal()
                {
                    EndSilenceTimeoutInMs = (long)recognizeSpeechOrDtmfOptions.EndSilenceTimeout.TotalMilliseconds
                };

                DtmfOptionsInternal dtmfConfigurations = new DtmfOptionsInternal()
                {
                    InterToneTimeoutInSeconds = (int)recognizeSpeechOrDtmfOptions.InterToneTimeout.TotalSeconds,
                    MaxTonesToCollect = recognizeSpeechOrDtmfOptions.MaxTonesToCollect,
                    StopTones = recognizeSpeechOrDtmfOptions.StopTones.ToList()
                };

                RecognizeOptionsInternal recognizeConfigurationsInternal = new RecognizeOptionsInternal(CommunicationIdentifierSerializer_2025_06_30.Serialize(recognizeSpeechOrDtmfOptions.TargetParticipant))
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

                if (!String.IsNullOrEmpty(recognizeSpeechOrDtmfOptions.SpeechModelEndpointId))
                {
                    recognizeConfigurationsInternal.SpeechRecognitionModelEndpointId = recognizeSpeechOrDtmfOptions.SpeechModelEndpointId;
                }

                RecognizeRequestInternal request = new RecognizeRequestInternal(recognizeSpeechOrDtmfOptions.InputType, recognizeConfigurationsInternal);

                request.PlayPrompt = TranslatePlaySourceToInternal(recognizeSpeechOrDtmfOptions.Prompt);
                if (recognizeOptions.PlayPrompts != null && recognizeOptions.PlayPrompts.Any())
                    request.PlayPrompts = recognizeOptions.PlayPrompts.Select(t => TranslatePlaySourceToInternal(t)).ToList();
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext == default ? Guid.NewGuid().ToString() : recognizeOptions.OperationContext;
                request.OperationCallbackUri = recognizeOptions.OperationCallbackUri?.AbsoluteUri;

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
                sourceInternal.File = new FileSourceInternal(fileSource.FileUri.AbsoluteUri);
                sourceInternal.PlaySourceCacheId = fileSource.PlaySourceCacheId;
                return sourceInternal;
            }
            else if (playSource != null && playSource is TextSource textSource)
            {
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.Text);
                sourceInternal.Text = new TextSourceInternal(textSource.Text);
                sourceInternal.Text.SourceLocale = textSource.SourceLocale ?? null;
                sourceInternal.Text.VoiceKind = textSource.VoiceKind ?? VoiceKind.Male;
                sourceInternal.Text.VoiceName = textSource.VoiceName ?? null;
                sourceInternal.Text.CustomVoiceEndpointId = textSource.CustomVoiceEndpointId ?? null;
                sourceInternal.PlaySourceCacheId = textSource.PlaySourceCacheId;
                return sourceInternal;
            }
            else if (playSource != null && playSource is SsmlSource ssmlSource)
            {
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.Ssml);
                sourceInternal.Ssml = new SsmlSourceInternal(ssmlSource.SsmlText);
                sourceInternal.Ssml.CustomVoiceEndpointId = ssmlSource.CustomVoiceEndpointId ?? null;
                sourceInternal.PlaySourceCacheId = ssmlSource.PlaySourceCacheId;
                return sourceInternal;
            }
            else
            { return null; }
        }

        /// <summary>
        /// Starts continuous Dtmf recognition with continuousDtmfRecognition options and configurations.
        /// </summary>
        /// <param name="options">An optional object containing continuousDtmfRecognition options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StartContinuousDtmfRecognition(ContinuousDtmfRecognitionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
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
        /// Starts continuous Dtmf recognition.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for starting continuous Dtmf recognition.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StartContinuousDtmfRecognition(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return CallMediaRestClient.StartContinuousDtmfRecognition(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts continuous Dtmf recognition in async mode  with continuousDtmfRecognition options and configurations.
        /// </summary>
        /// <param name="options">An optional object containing continuousDtmfRecognition options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StartContinuousDtmfRecognitionAsync(ContinuousDtmfRecognitionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
                };
                return await CallMediaRestClient.StartContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StartContinuousDtmfRecognitionAsync(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return await CallMediaRestClient.StartContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        /// <summary>
        /// Stops continuous Dtmf recognition with continuousDtmfRecognition options and configurations.
        /// </summary>
        /// <param name="options">An optional object containing continuousDtmfRecognition options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StopContinuousDtmfRecognition(ContinuousDtmfRecognitionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
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
        /// Stops continuous Dtmf recognition.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for stopping continuous Dtmf recognition.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StopContinuousDtmfRecognition(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return CallMediaRestClient.StopContinuousDtmfRecognition(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops continuous Dtmf recognition in async mode  with continuousDtmfRecognition options and configurations.
        /// </summary>
        /// <param name="options">An optional object containing continuousDtmfRecognition options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StopContinuousDtmfRecognitionAsync(ContinuousDtmfRecognitionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
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
        /// Stops continuous Dtmf recognition in async mode.
        /// </summary>
        /// <param name="targetParticipant">A target participant identifier for stopping continuous Dtmf recognition.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 200 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StopContinuousDtmfRecognitionAsync(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopContinuousDtmfRecognition)}");
            scope.Start();
            try
            {
                ContinuousDtmfRecognitionRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                return await CallMediaRestClient.StopContinuousDtmfRecognitionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Send Dtmf tones in async mode with sendDtmfTonesOptions and configurations.
        /// </summary>
        /// <param name="options">An optional object containing SendDtmfTones options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns a Response containing a SendDtmfResult object indicating the result of the send operation.</returns>
        public virtual async Task<Response<SendDtmfTonesResult>> SendDtmfTonesAsync(SendDtmfTonesOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(SendDtmfTones)}");
            scope.Start();
            try
            {
                SendDtmfTonesRequestInternal request = new(options.Tones, CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
                };

                var response = await CallMediaRestClient.SendDtmfTonesAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new SendDtmfTonesResult(response.Value.OperationContext);
                result.SetEventProcessor(EventProcessor, CallConnectionId, response.Value.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
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
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns a Response containing a SendDtmfResult object indicating the result of the send operation.</returns>
        public virtual async Task<Response<SendDtmfTonesResult>> SendDtmfTonesAsync(IEnumerable<DtmfTone> tones, CommunicationIdentifier targetParticipant,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(SendDtmfTones)}");
            scope.Start();
            try
            {
                SendDtmfTonesRequestInternal request = new(tones, CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                var response = await CallMediaRestClient.SendDtmfTonesAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new SendDtmfTonesResult(response.Value.OperationContext);
                result.SetEventProcessor(EventProcessor, CallConnectionId, response.Value.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Send Dtmf tones with sendDtmfTonesOptions and configurations.
        /// </summary>
        /// <param name="options">An optional object containing SendDtmfTones options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns a Response containing a SendDtmfResult object indicating the result of the send operation.</returns>
        public virtual Response<SendDtmfTonesResult> SendDtmfTones(SendDtmfTonesOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(SendDtmfTones)}");
            scope.Start();
            try
            {
                SendDtmfTonesRequestInternal request = new(options.Tones, CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant))
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
                };

                var response = CallMediaRestClient.SendDtmfTones(CallConnectionId, request, cancellationToken);

                var result = new SendDtmfTonesResult(response.Value.OperationContext);
                result.SetEventProcessor(EventProcessor, CallConnectionId, response.Value.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
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
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns a Response containing a SendDtmfResult object indicating the result of the send operation.</returns>
        public virtual Response<SendDtmfTonesResult> SendDtmfTones(IEnumerable<DtmfTone> tones, CommunicationIdentifier targetParticipant,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(SendDtmfTones)}");
            scope.Start();
            try
            {
                SendDtmfTonesRequestInternal request = new(tones, CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant));

                var response = CallMediaRestClient.SendDtmfTones(CallConnectionId, request, cancellationToken);

                var result = new SendDtmfTonesResult(response.Value.OperationContext);
                result.SetEventProcessor(EventProcessor, CallConnectionId, response.Value.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts transcription in the call.
        /// </summary>
        /// <param name="options">An optional object containing start transcription options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StartTranscription(StartTranscriptionOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartTranscription)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StartTranscriptionRequestInternal()
                    : new StartTranscriptionRequestInternal() { Locale = options.Locale, OperationContext = options.OperationContext, OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri, SpeechRecognitionModelEndpointId = options.SpeechRecognitionModelEndpointId };

                return CallMediaRestClient.StartTranscription(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts transcription in the call.
        /// </summary>
        /// <param name="options">An optional object containing start transcription options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StartTranscriptionAsync(StartTranscriptionOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartTranscription)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StartTranscriptionRequestInternal()
                    : new StartTranscriptionRequestInternal() { Locale = options.Locale, OperationContext = options.OperationContext, OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri, SpeechModelEndpointId = options.SpeechRecognitionModelEndpointId };

                return await CallMediaRestClient.StartTranscriptionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops transcription in the call.
        /// </summary>
        /// <param name="options">An optional object containing stop transcription options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StopTranscription(StopTranscriptionOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopTranscription)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StopTranscriptionRequestInternal()
                    : new StopTranscriptionRequestInternal() { OperationContext = options.OperationContext, OperationCallbackUri = options.OperationCallbackUri };

                return CallMediaRestClient.StopTranscription(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops transcription in the call.
        /// </summary>
        /// <param name="options">An optional object containing stop transcription options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StopTranscriptionAsync(StopTranscriptionOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopTranscription)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StopTranscriptionRequestInternal()
                    : new StopTranscriptionRequestInternal() { OperationContext = options.OperationContext, OperationCallbackUri = options.OperationCallbackUri };

                return await CallMediaRestClient.StopTranscriptionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// API to change transcription language.
        /// </summary>
        /// <param name="locale">Defines new locale for transcription.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response UpdateTranscription(string locale, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(UpdateTranscription)}");
            scope.Start();
            try
            {
                UpdateTranscriptionRequestInternal request = new UpdateTranscriptionRequestInternal(
                    locale: locale,
                    speechModelEndpointId: null,
                    operationContext: null,
                    operationCallbackUri: null);
                return CallMediaRestClient.UpdateTranscription(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// API to change transcription language.
        /// </summary>
        /// <param name="options">An optional object containing update transcription options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response UpdateTranscription(UpdateTranscriptionOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(UpdateTranscription)}");
            scope.Start();
            try
            {
                UpdateTranscriptionRequestInternal request = new(options.Locale, options.SpeechRecognitionModelEndpointId, options.OperationContext, options.OperationCallbackUri?.AbsoluteUri);

                return CallMediaRestClient.UpdateTranscription(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// API to change transcription language.
        /// </summary>
        /// <param name="locale">Defines new locale for transcription.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> UpdateTranscriptionAsync(string locale, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(UpdateTranscription)}");
            scope.Start();
            try
            {
                UpdateTranscriptionRequestInternal request = new UpdateTranscriptionRequestInternal(
                    locale: locale,
                    speechModelEndpointId: null,
                    operationContext: null,
                    operationCallbackUri: null);
                return await CallMediaRestClient.UpdateTranscriptionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// API to change transcription language.
        /// </summary>
        /// <param name="options">An optional object containing update transcription options and configurations.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> UpdateTranscriptionAsync(UpdateTranscriptionOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(UpdateTranscription)}");
            scope.Start();
            try
            {
                UpdateTranscriptionRequestInternal request = new(options.Locale, options.SpeechRecognitionModelEndpointId, options.OperationContext, options.OperationCallbackUri?.AbsoluteUri);

                return await CallMediaRestClient.UpdateTranscriptionAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts media streaming in the call.
        /// </summary>
        /// <param name="options">An optional object containing start media streaming options.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StartMediaStreaming(StartMediaStreamingOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartMediaStreaming)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StartMediaStreamingRequestInternal()
                    : new StartMediaStreamingRequestInternal() { OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri, OperationContext = options.OperationContext };

                return CallMediaRestClient.StartMediaStreaming(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Starts media streaming in the call.
        /// </summary>
        /// <param name="options">An optional object containing start media streaming options.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StartMediaStreamingAsync(StartMediaStreamingOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartMediaStreaming)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StartMediaStreamingRequestInternal()
                    : new StartMediaStreamingRequestInternal() { OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri, OperationContext = options.OperationContext };

                return await CallMediaRestClient.StartMediaStreamingAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops media streaming in the call.
        /// </summary>
        /// <param name="options">An optional object containing stop media streaming options.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual Response StopMediaStreaming(StopMediaStreamingOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopMediaStreaming)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StopMediaStreamingRequestInternal()
                    : new StopMediaStreamingRequestInternal() { OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri, OperationContext = options.OperationContext };

                return CallMediaRestClient.StopMediaStreaming(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stops media streaming in the call.
        /// </summary>
        /// <param name="options">An optional object containing stop media streaming options.</param>
        /// <param name="cancellationToken">An optional CancellationToken to cancel the request.</param>
        /// <returns>Returns an HTTP response with a 202 status code for success, or an HTTP failure error code in case of an error.</returns>
        public virtual async Task<Response> StopMediaStreamingAsync(StopMediaStreamingOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopMediaStreaming)}");
            scope.Start();
            try
            {
                var request = options == default
                    ? new StopMediaStreamingRequestInternal()
                    : new StopMediaStreamingRequestInternal() { OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri }; // OperationContext = options.OperationContext

                return await CallMediaRestClient.StopMediaStreamingAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
