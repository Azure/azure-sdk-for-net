// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The Azure Communication Services Calling Server client.
    /// </summary>
    public class CallClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallRestClient RestClient { get; }

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallClient(Uri endpoint, AzureKeyCredential keyCredential, CallClientOptions? options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)),
                options ?? new CallClientOptions(),
                AssertNotNull(keyCredential, nameof(keyCredential)))
        { }

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallClient(string connectionString, CallClientOptions? options = default)
            : this(
                  options ?? new CallClientOptions(),
                  ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))))
        { }

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallClient(Uri endpoint, TokenCredential tokenCredential, CallClientOptions? options = default)
            : this(
                  endpoint,
                  options ?? new CallClientOptions(),
                  tokenCredential)
        { }

        /// <summary>Initializes a new instance of <see cref="CallClient"/> for mocking.</summary>
        protected CallClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        private CallClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpointUrl)
        {
            RestClient = new CallRestClient(clientDiagnostics, pipeline, endpointUrl);
            _clientDiagnostics = clientDiagnostics;
        }

        private CallClient(CallClientOptions options, ConnectionString connectionString)
            : this(
                  clientDiagnostics: new ClientDiagnostics(options),
                  pipeline: options.BuildHttpPipeline(connectionString),
                  endpointUrl: connectionString.GetRequired("endpoint"))
        { }

        private CallClient(Uri endpoint, CallClientOptions options, TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new CallRestClient(
                _clientDiagnostics,
                options.BuildHttpPipeline(tokenCredential),
                endpoint.AbsoluteUri);
        }

        private CallClient(Uri endpoint, CallClientOptions options, AzureKeyCredential credential)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new CallRestClient(
                _clientDiagnostics,
                options.BuildHttpPipeline(credential),
                endpoint.AbsoluteUri);
        }

        /// Create a Call Requestion from source identity to targets identity asynchronously.
        /// <param name="source"> The source of the call. </param>
        /// <param name="targets"> The targets of the call. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual async Task<Response<CreateCallResponse>> CreateCallAsync(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                CreateCallRequestInternal request = new CreateCallRequestInternal(
                    CommunicationIdentifierSerializer.Serialize(source),
                    targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    callOptions.CallbackUri?.AbsoluteUri,
                    callOptions.RequestedModalities,
                    callOptions.RequestedCallEvents);

                if (callOptions.AlternateCallerId != null)
                {
                    request.SourceAlternateIdentity = new PhoneNumberIdentifierModel(callOptions.AlternateCallerId?.PhoneNumber);
                }

                return await RestClient.CreateCallAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Create a Call Requestion from source identity to targets identity.
        /// <param name="source"> The source of the call. </param>
        /// <param name="targets"> The targets of the call. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual Response<CreateCallResponse> CreateCall(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                CreateCallRequestInternal request = new CreateCallRequestInternal(
                    CommunicationIdentifierSerializer.Serialize(source),
                    targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    callOptions.CallbackUri.AbsoluteUri,
                    callOptions.RequestedModalities,
                    callOptions.RequestedCallEvents);

                if (callOptions.AlternateCallerId != null)
                {
                    request.SourceAlternateIdentity = new PhoneNumberIdentifierModel(callOptions.AlternateCallerId?.PhoneNumber);
                }

                return RestClient.CreateCall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a call asynchronously. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callLegId"/> is null.</exception>
        public virtual async Task<Response> DeleteCallAsync(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(DeleteCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));

                return await RestClient.DeleteCallAsync(callLegId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a call. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callLegId"/> is null.</exception>
        public virtual Response DeleteCall(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(DeleteCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));

                return RestClient.DeleteCall(callLegId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Disconnect the current caller in a Group-call or end a p2p-call asynchronously.</summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callLegId"/> is null.</exception>
        public virtual async Task<Response> HangupCallAsync(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(HangupCallAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                return await RestClient.HangupCallAsync(callLegId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Disconnect the current caller in a Group-call or end a p2p-call. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callLegId"/> is null.</exception>
        public virtual Response HangupCall(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(HangupCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                return RestClient.HangupCall(callLegId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /*

        /// <summary> Subscribe to tone.</summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callLegId"/> is null.</exception>
        public virtual async Task<Response> SubscribeToToneAsync(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(SubscribeToToneAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                return await RestClient.SubscribeToToneAsync(callLegId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Subscribe to tone.</summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callLegId"/> is null.</exception>
        public virtual Response SubscribeToTone(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(SubscribeToTone)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                return RestClient.SubscribeToTone(callLegId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        */

        /// <summary> Cancel Media Processing. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="operationContext"/> is null. </exception>
        public virtual async Task<Response<CancelMediaProcessingResponse>> CancelMediaProcessingAsync(string callLegId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CancelMediaProcessingAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                return await RestClient.CancelMediaProcessingAsync(callLegId, new CancelMediaProcessingRequest() { OperationContext = operationContext }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Media Processing. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="operationContext"/> is null. </exception>
        public virtual Response<CancelMediaProcessingResponse> CancelMediaProcessing(string callLegId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CancelMediaProcessingAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                return RestClient.CancelMediaProcessing(callLegId, new CancelMediaProcessingRequest() { OperationContext = operationContext }, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play Audio. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="request"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="request"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string callLegId, PlayAudioRequest request, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(PlayAudioAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNull(request, nameof(request));

                return await RestClient.PlayAudioAsync(callLegId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play Audio. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="request"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="request"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(string callLegId, PlayAudioRequest request, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNull(request, nameof(request));

                return RestClient.PlayAudio(callLegId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play Audio. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="loop">The flag to indicate if audio file need to be played in a loop.</param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="audioFileUri"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string callLegId, Uri audioFileUri, bool loop, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(PlayAudioAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                PlayAudioRequest request = new PlayAudioRequest()
                {
                    AudioFileUri = audioFileUri.AbsoluteUri,
                    Loop = loop,
                    OperationContext = operationContext
                };

                return await RestClient.PlayAudioAsync(callLegId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play Audio. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="loop">The flag to indicate if audio file need to be played in a loop.</param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="audioFileUri"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(string callLegId, Uri audioFileUri, bool loop, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                PlayAudioRequest request = new PlayAudioRequest()
                {
                    AudioFileUri = audioFileUri.AbsoluteUri,
                    Loop = loop,
                    OperationContext = operationContext
                };

                return RestClient.PlayAudio(callLegId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Invite participants to a call. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="participants"> The uri of the audio file. </param>
        /// <param name="alternateCallerId">The flag to indicate if audio file need to be played in a loop.</param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="participants"/> is null. </exception>
        public virtual async Task<Response> InviteParticipantsAsync(string callLegId, IEnumerable<CommunicationIdentifier> participants, string operationContext, string? alternateCallerId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(InviteParticipantsAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNullOrEmpty(participants, nameof(participants));

                var participantsInternal = participants.Select(p => CommunicationIdentifierSerializer.Serialize(p));
                InviteParticipantsRequestInternal request = new InviteParticipantsRequestInternal(participantsInternal)
                {
                    OperationContext = operationContext
                };

                if (!string.IsNullOrEmpty(alternateCallerId))
                {
                    request.AlternateCallerId = new PhoneNumberIdentifierModel(alternateCallerId);
                }

                return await RestClient.InviteParticipantsAsync(callLegId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Invite participants to a call. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="participants"> The uri of the audio file. </param>
        /// <param name="alternateCallerId">The flag to indicate if audio file need to be played in a loop.</param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="participants"/> is null. </exception>
        public virtual Response InviteParticipants(string callLegId, IEnumerable<CommunicationIdentifier> participants, string operationContext, string? alternateCallerId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(InviteParticipantsAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNullOrEmpty(participants, nameof(participants));

                var participantsInternal = participants.Select(p => CommunicationIdentifierSerializer.Serialize(p));
                InviteParticipantsRequestInternal request = new InviteParticipantsRequestInternal(participantsInternal)
                {
                    OperationContext = operationContext
                };

                if (!string.IsNullOrEmpty(alternateCallerId))
                {
                    request.AlternateCallerId = new PhoneNumberIdentifierModel(alternateCallerId);
                }

                return RestClient.InviteParticipants(callLegId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a participants from the call. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="participantId"> The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="participantId"/> is null. </exception>
        public virtual async Task<Response> RemoveParticipantAsync(string callLegId, string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNullOrEmpty(participantId, nameof(participantId));

                return await RestClient.RemoveParticipantAsync(callLegId, participantId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a participants from the call. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="participantId"> The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="callLegId"/> or <paramref name="participantId"/> is null. </exception>
        public virtual Response RemoveParticipant(string callLegId, string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callLegId, nameof(callLegId));
                Argument.AssertNotNullOrEmpty(participantId, nameof(participantId));

                return RestClient.RemoveParticipant(callLegId, participantId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static T AssertNotNull<T>(T argument, string argumentName)
            where T : class
        {
            Argument.AssertNotNull(argument, argumentName);
            return argument;
        }

        private static string AssertNotNullOrEmpty(string argument, string argumentName)
        {
            Argument.AssertNotNullOrEmpty(argument, argumentName);
            return argument;
        }
    }
}
