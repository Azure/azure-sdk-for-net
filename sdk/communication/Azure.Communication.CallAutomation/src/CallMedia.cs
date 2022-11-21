// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Models;
using Azure.Communication.CallAutomation.Models.Misc;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Call Media Client.
    /// </summary>
    public class CallMedia
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ContentRestClient ContentRestClient { get; }
        internal CallConnectionsRestClient CallConnectionRestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallMedia(string callConnectionId, CallConnectionsRestClient callConnectionRestClient, ContentRestClient callContentRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            CallConnectionRestClient = callConnectionRestClient;
            ContentRestClient = callContentRestClient;
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(Play)}");
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

            else if (playSource is TextSource textSource)
            {
                PlaySourceInternal sourceInternal;
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.Text);
                sourceInternal.TextSource = new TextSourceInternal(textSource.Text);
                sourceInternal.TextSource.SourceLocale = textSource.SourceLocale ?? null;
                sourceInternal.TextSource.TargetLocale = textSource.TargetLocale ?? null;
                sourceInternal.TextSource.VoiceGender = textSource.VoiceGender ?? GenderType.M;
                sourceInternal.TextSource.VoiceName = textSource.VoiceName ?? null;
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
        /// <returns></returns>
        public virtual Response PlayToAll(PlaySource playSource, PlayOptions playOptions = default, CancellationToken cancellationToken = default)
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
        /// <returns></returns>
        public virtual async Task<Response> CancelAllMediaOperationsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(CancelAllMediaOperations)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(CancelAllMediaOperations)}");
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
        public virtual async Task<Response> StartRecognizingAsync(CallMediaRecognizeOptions recognizeOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartRecognizing)}");
            scope.Start();
            try
            {
                if (recognizeOptions is CallMediaRecognizeNluOptions nluRecognizeNluOptions)
                {
                    var isNuance = nluRecognizeNluOptions.NluRecognizer.Equals(NluRecognizer.Nuance);
                    var ivrBot = isNuance ? new CommunicationUserIdentifier("8:acs:4c3e963e-ab47-488f-a83a-d04994237db3_00000014-f2fc-1f19-28df-444822005ad8")
                        : new CommunicationUserIdentifier("8:acs:4c3e963e-ab47-488f-a83a-d04994237db3_00000015-1d2a-5fbd-3dfe-9c3a0d00e842");

                    var addParticipantOptions = new AddParticipantsOptions(new[] { ivrBot });
                    addParticipantOptions.RepeatabilityHeaders?.GenerateIfRepeatabilityHeadersNotProvided();
                    AddParticipantsRequestInternal addParticipantsRequest = CreateAddParticipantRequest(addParticipantOptions);

                    var addParticipantResponse = await CallConnectionRestClient.AddParticipantAsync(
                        callConnectionId: CallConnectionId,
                        addParticipantsRequest,
                        addParticipantOptions.RepeatabilityHeaders?.RepeatabilityRequestId,
                        addParticipantOptions.RepeatabilityHeaders?.GetRepeatabilityFirstSentString(),
                        cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                    var addParticipantResult = Response.FromValue(new AddParticipantsResult(addParticipantResponse), addParticipantResponse.GetRawResponse());
                    if (addParticipantResult.GetRawResponse().Status != 202) return addParticipantResponse.GetRawResponse();

                    var nluOptions = new NluOptionsInternal(nluRecognizeNluOptions.NluRecognizer)
                    {
                        PlayDialog = nluRecognizeNluOptions.PlayDialog,
                        PlayIntent = nluRecognizeNluOptions.PlayIntent,
                        SendNluUri = nluRecognizeNluOptions.CallbackUri
                    };

                    var recognizeResult = await ContentRestClient.RecognizeNluAsync(CallConnectionId, nluOptions, cancellationToken).ConfigureAwait(false);

                    for (var i = 0; i < 10 && recognizeResult.Status != 200; i++)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                        recognizeResult = await ContentRestClient.RecognizeNluAsync(CallConnectionId, nluOptions, cancellationToken).ConfigureAwait(false);
                    }

                    return recognizeResult;
                }

                RecognizeRequestInternal recognizeRequest = CreateRecognizeRequest(recognizeOptions);
                return await ContentRestClient.RecognizeAsync(CallConnectionId, recognizeRequest, cancellationToken).ConfigureAwait(false);
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
        public virtual Response StartRecognizing(CallMediaRecognizeOptions recognizeOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartRecognizing)}");
            scope.Start();
            try
            {
                if (recognizeOptions is CallMediaRecognizeNluOptions nluRecognizeNluOptions)
                {
                    var isNuance = nluRecognizeNluOptions.NluRecognizer.Equals(NluRecognizer.Nuance);
                    var ivrBot = isNuance
                        ? new CommunicationUserIdentifier(
                            "8:acs:4c3e963e-ab47-488f-a83a-d04994237db3_00000014-f2fc-1f19-28df-444822005ad8")
                        : new CommunicationUserIdentifier(
                            "8:acs:4c3e963e-ab47-488f-a83a-d04994237db3_00000015-1d2a-5fbd-3dfe-9c3a0d00e842");

                    var addParticipantOptions = new AddParticipantsOptions(new[] { ivrBot });
                    addParticipantOptions.RepeatabilityHeaders?.GenerateIfRepeatabilityHeadersNotProvided();
                    AddParticipantsRequestInternal addParticipantsRequest =
                        CreateAddParticipantRequest(addParticipantOptions);

                    var addParticipantResponse = CallConnectionRestClient.AddParticipant(
                        callConnectionId: CallConnectionId,
                        addParticipantsRequest,
                        addParticipantOptions.RepeatabilityHeaders?.RepeatabilityRequestId,
                        addParticipantOptions.RepeatabilityHeaders?.GetRepeatabilityFirstSentString(),
                        cancellationToken: cancellationToken
                    );

                    var addParticipantResult = Response.FromValue(new AddParticipantsResult(addParticipantResponse),
                        addParticipantResponse.GetRawResponse());
                    if (addParticipantResult.GetRawResponse().Status != 202)
                        return addParticipantResponse.GetRawResponse();

                    var nluOptions = new NluOptionsInternal(nluRecognizeNluOptions.NluRecognizer)
                    {
                        PlayDialog = nluRecognizeNluOptions.PlayDialog,
                        PlayIntent = nluRecognizeNluOptions.PlayIntent,
                        SendNluUri = nluRecognizeNluOptions.CallbackUri
                    };

                    var recognizeResult = ContentRestClient.RecognizeNlu(CallConnectionId, nluOptions, cancellationToken);

                    for (var i = 0; i < 10 && recognizeResult.Status != 200; i++)
                    {
                        new ManualResetEvent(false).WaitOne(TimeSpan.FromSeconds(1));
                        recognizeResult = ContentRestClient.RecognizeNlu(CallConnectionId, nluOptions, cancellationToken);
                    }

                    return recognizeResult;
                }

                RecognizeRequestInternal recognizeRequest = CreateRecognizeRequest(recognizeOptions);
                return ContentRestClient.Recognize(CallConnectionId, recognizeRequest, cancellationToken);
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

                if (recognizeDtmfOptions.Prompt != null && recognizeDtmfOptions.Prompt is FileSource fileSource)
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
                request.InterruptCallMediaOperation = recognizeOptions.InterruptCallMediaOperation;
                request.OperationContext = recognizeOptions.OperationContext;

                return request;
            }
            else
            {
                throw new NotSupportedException(recognizeOptions.GetType().Name);
            }
        }

        private static AddParticipantsRequestInternal CreateAddParticipantRequest(AddParticipantsOptions options)
        {
            // when add PSTN participants, the SourceCallerId must be provided.
            if (options.ParticipantsToAdd.Any(participant => participant is PhoneNumberIdentifier))
            {
                Argument.AssertNotNull(options.SourceCallerId, nameof(options.SourceCallerId));
            }

            // validate ParticipantsToAdd is not null or empty
            Argument.AssertNotNullOrEmpty(options.ParticipantsToAdd, nameof(options.ParticipantsToAdd));

            AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(options.ParticipantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList());

            request.SourceCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
            request.OperationContext = options.OperationContext;
            if (options.InvitationTimeoutInSeconds != null &&
                (options.InvitationTimeoutInSeconds < CallAutomationConstants.InputValidation.MinInvitationTimeoutInSeconds ||
                 options.InvitationTimeoutInSeconds > CallAutomationConstants.InputValidation.MaxInvitationTimeoutInSeconds))
            {
                throw new ArgumentException(CallAutomationErrorMessages.InvalidInvitationTimeoutInSeconds);
            }
            else
            {
                request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;
            }

            return request;
        }
    }
}
