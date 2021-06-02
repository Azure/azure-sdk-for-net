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

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public CallClient(string connectionString)
            : this(
                  ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                  new CallClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallClient(string connectionString, CallClientOptions options = default)
            : this(
                  ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                  options ?? new CallClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallClient(Uri endpoint, AzureKeyCredential keyCredential, CallClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CallClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallClient(Uri endpoint, TokenCredential tokenCredential, CallClientOptions options = default)
            : this(
                  AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                  AssertNotNull(tokenCredential, nameof(tokenCredential)),
                  options ?? new CallClientOptions())
        { }

        #endregion

        #region private constructors

        private CallClient(ConnectionString connectionString, CallClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallClient(string endpoint, TokenCredential tokenCredential, CallClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CallClient(string endpoint, AzureKeyCredential keyCredential, CallClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private CallClient(string endpoint, HttpPipeline httpPipeline, CallClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new CallRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CallClient"/> for mocking.</summary>
        protected CallClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        /// Create a Call Requestion from source identity to targets identity asynchronously.
        /// <param name="source"> The source of the call. </param>
        /// <param name="targets"> The targets of the call. </param>
        /// <param name="options"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response<CreateCallResponse>> CreateCallAsync(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(options, nameof(options));

                var sourceAlternateIdentity = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                return await RestClient.CreateCallAsync(
                    targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    CommunicationIdentifierSerializer.Serialize(source),
                    options.CallbackUri?.AbsoluteUri,
                    options.RequestedModalities,
                    options.RequestedCallEvents,
                    sourceAlternateIdentity,
                    options.Subject,
                    cancellationToken
                    ).ConfigureAwait(false);
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
        /// <param name="options"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response<CreateCallResponse> CreateCall(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(options, nameof(options));

                var sourceAlternateIdentity = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                return  RestClient.CreateCall(
                    targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    CommunicationIdentifierSerializer.Serialize(source),
                    options.CallbackUri?.AbsoluteUri,
                    options.RequestedModalities,
                    options.RequestedCallEvents,
                    sourceAlternateIdentity,
                    options.Subject,
                    cancellationToken
                    );
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
        public virtual async Task<Response> DeleteCallAsync(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(DeleteCall)}");
            scope.Start();
            try
            {
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
        public virtual Response DeleteCall(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(DeleteCall)}");
            scope.Start();
            try
            {
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
        public virtual async Task<Response> HangupCallAsync(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(HangupCall)}");
            scope.Start();
            try
            {
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
        public virtual Response HangupCall(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(HangupCall)}");
            scope.Start();
            try
            {
                return RestClient.HangupCall(callLegId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Media Operations. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CancelMediaOperationsResponse>> CancelMediaOperationsAsync(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CancelMediaOperations)}");
            scope.Start();
            try
            {
                return await RestClient.CancelMediaOperationsAsync(callLegId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Media Operations. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CancelMediaOperationsResponse> CancelMediaOperations(string callLegId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(CancelMediaOperations)}");
            scope.Start();
            try
            {
                return RestClient.CancelMediaOperations(callLegId, cancellationToken);
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
        /// <param name="loop">The flag to indicate if audio file need to be played in a loop or not.</param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="audioFileUri"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string callLegId, Uri audioFileUri, bool? loop, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => await PlayAudioAsync(callLegId, new PlayAudioOptions { AudioFileUri = audioFileUri, Loop = loop, AudioFileId = audioFileId, CallbackUri = callbackUri, OperationContext = operationContext }, cancellationToken).ConfigureAwait(false);

        /// <summary> Play Audio. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string callLegId, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                return await RestClient.PlayAudioAsync(callLegId, options.AudioFileUri?.AbsoluteUri, options.Loop, options.AudioFileId, options.CallbackUri?.AbsoluteUri, options.OperationContext, cancellationToken).ConfigureAwait(false);
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
        /// <param name="loop">The flag to indicate if audio file need to be played in a loop or not.</param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="audioFileUri"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(string callLegId, Uri audioFileUri, bool? loop, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => PlayAudio(
                callLegId,
                new PlayAudioOptions {
                    AudioFileUri = audioFileUri,
                    Loop = loop,
                    AudioFileId = audioFileId,
                    CallbackUri = callbackUri,
                    OperationContext = operationContext
                },
                cancellationToken);

        /// <summary> Play Audio. </summary>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(string callLegId, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                return RestClient.PlayAudio(callLegId, options.AudioFileUri?.AbsoluteUri, options.Loop, options.OperationContext, options.AudioFileId, options.CallbackUri?.AbsoluteUri, cancellationToken);
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
        /// <exception cref="ArgumentNullException"> <paramref name="participants"/> is null. </exception>
        public virtual async Task<Response> InviteParticipantsAsync(string callLegId, IEnumerable<CommunicationIdentifier> participants, string alternateCallerId = default, string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(InviteParticipants)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(participants, nameof(participants));
                Argument.AssertNotNullOrEmpty(alternateCallerId, nameof(alternateCallerId));

                return await RestClient.InviteParticipantsAsync(callLegId,
                    participants.Select(p => CommunicationIdentifierSerializer.Serialize(p)),
                    new PhoneNumberIdentifierModel(alternateCallerId),
                    operationContext,
                    null,
                    cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentNullException"> <paramref name="participants"/> is null. </exception>
        public virtual Response InviteParticipants(string callLegId, IEnumerable<CommunicationIdentifier> participants, string alternateCallerId = default, string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(InviteParticipants)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(participants, nameof(participants));
                Argument.AssertNotNullOrEmpty(alternateCallerId, nameof(alternateCallerId));

                return RestClient.InviteParticipants(callLegId,
                    participants.Select(p => CommunicationIdentifierSerializer.Serialize(p)),
                    new PhoneNumberIdentifierModel(alternateCallerId),
                    operationContext,
                    null,
                    cancellationToken);
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
        /// <exception cref="ArgumentNullException"> <paramref name="participantId"/> is null. </exception>
        public virtual async Task<Response> RemoveParticipantAsync(string callLegId, string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
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
        /// <exception cref="ArgumentNullException"> <paramref name="participantId"/> is null. </exception>
        public virtual Response RemoveParticipant(string callLegId, string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
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
