// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The Azure Communication Services Conversation Client.
    /// </summary>
    public class ConversationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal RecordingRestClient RestClient { get; }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(Uri endpoint, AzureKeyCredential keyCredential, CallClientOptions? options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)),
                options ?? new CallClientOptions(),
                AssertNotNull(keyCredential, nameof(keyCredential)))
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(string connectionString, CallClientOptions? options = default)
            : this(
                  options ?? new CallClientOptions(),
                  ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))))
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(Uri endpoint, TokenCredential tokenCredential, CallClientOptions? options = default)
            : this(
                  endpoint,
                  options ?? new CallClientOptions(),
                  tokenCredential)
        { }

        /// <summary>Initializes a new instance of <see cref="ConversationClient"/> for mocking.</summary>
        protected ConversationClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        private ConversationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpointUrl)
        {
            RestClient = new RecordingRestClient(clientDiagnostics, pipeline, endpointUrl);
            _clientDiagnostics = clientDiagnostics;
        }

        private ConversationClient(CallClientOptions options, ConnectionString connectionString)
            : this(
                  clientDiagnostics: new ClientDiagnostics(options),
                  pipeline: options.BuildHttpPipeline(connectionString),
                  endpointUrl: connectionString.GetRequired("endpoint"))
        { }

        private ConversationClient(Uri endpoint, CallClientOptions options, TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new RecordingRestClient(
                _clientDiagnostics,
                options.BuildHttpPipeline(tokenCredential),
                endpoint.AbsoluteUri);
        }

        private ConversationClient(Uri endpoint, CallClientOptions options, AzureKeyCredential credential)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new RecordingRestClient(
                _clientDiagnostics,
                options.BuildHttpPipeline(credential),
                endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Start recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<StartCallRecordingResponse>> StartRecordingAsync(string conversationId, Uri recordingStateCallbackUri, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StartRecordingAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingStateCallbackUri, nameof(recordingStateCallbackUri));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                StartCallRecordingRequest request = new StartCallRecordingRequest()
                {
                    OperationContext = operationContext,
                    RecordingStateCallbackUri = recordingStateCallbackUri.AbsoluteUri
                };

                return await RestClient.StartRecordingAsync(conversationId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Start recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<StartCallRecordingResponse> StartRecording(string conversationId, Uri recordingStateCallbackUri, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingStateCallbackUri, nameof(recordingStateCallbackUri));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                StartCallRecordingRequest request = new StartCallRecordingRequest()
                {
                    OperationContext = operationContext,
                    RecordingStateCallbackUri = recordingStateCallbackUri.AbsoluteUri
                };

                return RestClient.StartRecording(conversationId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response> StopRecordingAsync(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StopRecordingAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                StopCallRecordingRequest request = new StopCallRecordingRequest()
                {
                    OperationContext = operationContext
                };

                return await RestClient.StopRecordingAsync(conversationId, recordingId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response StopRecording(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StopRecording)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                StopCallRecordingRequest request = new StopCallRecordingRequest()
                {
                    OperationContext = operationContext
                };

                return RestClient.StopRecording(conversationId, recordingId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Pause recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response> PauseRecordingAsync(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PauseRecordingAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                PauseCallRecordingRequest request = new PauseCallRecordingRequest()
                {
                    OperationContext = operationContext
                };

                return await RestClient.PauseRecordingAsync(conversationId, recordingId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Pause recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response PauseRecording(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PauseRecording)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                PauseCallRecordingRequest request = new PauseCallRecordingRequest()
                {
                    OperationContext = operationContext
                };

                return RestClient.PauseRecording(conversationId, recordingId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resume recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response> ResumeRecordingAsync(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ResumeRecordingAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                ResumeCallRecordingRequest request = new ResumeCallRecordingRequest()
                {
                    OperationContext = operationContext
                };

                return await RestClient.ResumeRecordingAsync(conversationId, recordingId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// resume recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to resume.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response ResumeRecording(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ResumeRecording)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                ResumeCallRecordingRequest request = new ResumeCallRecordingRequest()
                {
                    OperationContext = operationContext
                };

                return RestClient.ResumeRecording(conversationId, recordingId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get recording state
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<GetCallRecordingStateResponse>> GetRecordingStateAsync(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(GetRecordingStateAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                return await RestClient.RecordingStateAsync(conversationId, recordingId, operationContext, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// resume recording
        /// </summary>
        /// <param name="conversationId">The conversation id.</param>
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<GetCallRecordingStateResponse> GetRecordingState(string conversationId, string recordingId, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(conversationId, nameof(conversationId));
                Argument.AssertNotNull(recordingId, nameof(recordingId));
                Argument.AssertNotNull(operationContext, nameof(operationContext));

                return RestClient.RecordingState(conversationId, recordingId, operationContext, cancellationToken);
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
