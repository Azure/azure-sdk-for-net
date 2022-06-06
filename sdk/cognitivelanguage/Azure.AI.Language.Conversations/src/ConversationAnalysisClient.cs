// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The <see cref="ConversationAnalysisClient"/> allows you analyze conversations.
    /// </summary>
    public partial class ConversationAnalysisClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Conversation Analysis endpoint on which to operate.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public ConversationAnalysisClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationAnalysisClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Conversation Analysis endpoint on which to operate.</param>
        /// <param name="credential">An <see cref="AzureKeyCredential"/> used to authenticate requests to the <paramref name="endpoint"/>.</param>
        /// <param name="options">Optional <see cref="ConversationAnalysisClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public ConversationAnalysisClient(Uri endpoint, AzureKeyCredential credential, ConversationAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            _endpoint = endpoint;
            options ??= new ConversationAnalysisClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, suppressNestedClientActivities: true);
            _pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            _keyCredential = credential;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected ConversationAnalysisClient()
        {
        }

        /// <summary>
        /// Gets the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="utterance">The conversation utterance to be analyzed.</param>
        /// <param name="project">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="options">Optional <see cref="AnalyzeConversationOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentException"><paramref name="utterance"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="utterance"/> or <paramref name="project"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnalyzeConversationTaskResult>> AnalyzeConversationAsync(string utterance, ConversationsProject project, AnalyzeConversationOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(utterance, nameof(utterance));
            Argument.AssertNotNull(project, nameof(project));

            ConversationTaskParameters conversationTaskParameters = new(project.ProjectName, project.DeploymentName)
            {
                IsLoggingEnabled = options?.IsLoggingEnabled,
                Verbose = options?.Verbose,
            };

            TextConversationItem textConversationItem = new("1", "1", utterance);

            options ??= new AnalyzeConversationOptions(textConversationItem);
            ConversationalTask customConversationalTask = new(options, conversationTaskParameters);

            Utf8JsonRequestContent content = new();
            content.JsonWriter.WriteObjectValue(customConversationalTask);

            Response response = await AnalyzeConversationAsync(content, new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);

            switch (response.Status)
            {
                case 200:
                    {
                        AnalyzeConversationTaskResult value = default;
                        using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, cancellationToken: cancellationToken).ConfigureAwait(false);
                        value = AnalyzeConversationTaskResult.DeserializeAnalyzeConversationTaskResult(document.RootElement);
                        return Response.FromValue(value, response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="utterance">The conversation utterance to be analyzed.</param>
        /// <param name="project">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="options">Optional <see cref="AnalyzeConversationOptions"/> with additional query options.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentException"><paramref name="utterance"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="utterance"/> or <paramref name="project"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationTaskResult> AnalyzeConversation(string utterance, ConversationsProject project, AnalyzeConversationOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(utterance, nameof(utterance));
            Argument.AssertNotNull(project, nameof(project));

            ConversationTaskParameters conversationTaskParameters = new(project.ProjectName, project.DeploymentName)
            {
                IsLoggingEnabled = options?.IsLoggingEnabled,
                Verbose = options?.Verbose,
            };

            TextConversationItem textConversationItem = new("1", "1", utterance);

            options ??= new AnalyzeConversationOptions(textConversationItem);
            ConversationalTask customConversationalTask = new(options, conversationTaskParameters);

            Utf8JsonRequestContent content = new();
            content.JsonWriter.WriteObjectValue(customConversationalTask);

            Response response = AnalyzeConversation(content, new RequestContext() { CancellationToken = cancellationToken });

            switch (response.Status)
            {
                case 200:
                    {
                        AnalyzeConversationTaskResult value = default;
                        using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                        value = AnalyzeConversationTaskResult.DeserializeAnalyzeConversationTaskResult(document.RootElement);
                        return Response.FromValue(value, response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(response);
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="input">The <see cref="ConversationInput"/> used for tasks input.</param>
        /// <param name="tasks"> <see cref="AnalyzeConversationLROTask"/> defines the tasks to be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="input"/> or <paramref name="tasks"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="input"/> or <paramref name="tasks"/> is empty.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Operation<AnalyzeConversationJobState>> StartAnalyzeConversationAsync(IEnumerable<ConversationInput> input, IEnumerable<AnalyzeConversationLROTask> tasks, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(input, nameof(input));
            Argument.AssertNotNull(tasks, nameof(tasks));

            MultiLanguageConversationAnalysisInput multiLanguageConversationAnalysisInput = new(input);

            AnalyzeConversationJobsInput analyzeConversationJobsInput = new(multiLanguageConversationAnalysisInput, tasks);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(StartAnalyzeConversation)}");
            scope.Start();

            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(analyzeConversationJobsInput);

            try
            {
                Operation<AnalyzeConversationJobState> response = await SubmitJobAsync(content, new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return response;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="input">The <see cref="ConversationInput"/> used for tasks input.</param>
        /// <param name="tasks"> <see cref="AnalyzeConversationLROTask"/> defines the tasks to be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="input"/> or <paramref name="tasks"/> or is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        /// <exception cref="ArgumentException"><paramref name="input"/> or <paramref name="tasks"/> is empty.</exception>
        public virtual Operation<AnalyzeConversationJobState> StartAnalyzeConversation(IEnumerable<ConversationInput> input, IEnumerable<AnalyzeConversationLROTask> tasks, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(input, nameof(input));
            Argument.AssertNotNull(tasks, nameof(tasks));

            MultiLanguageConversationAnalysisInput multiLanguageConversationAnalysisInput = new(input);

            AnalyzeConversationJobsInput analyzeConversationJobsInput = new(multiLanguageConversationAnalysisInput, tasks);

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(StartAnalyzeConversation)}");
            scope.Start();

            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(analyzeConversationJobsInput);

            try
            {
                Operation<AnalyzeConversationJobState> response = SubmitJob(content, new RequestContext() { CancellationToken = cancellationToken });
                return response;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static AnalyzeConversationJobState ConvertResponseToResult(Response response)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return AnalyzeConversationJobState.DeserializeAnalyzeConversationJobState(document.RootElement);
        }

        /// <summary> Submit a collection of conversations for analysis. Specify one or more unique tasks to be executed. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Operation<AnalyzeConversationJobState>> SubmitJobAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(SubmitJob)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSubmitJobRequest(content, context);
                return await LowLevelOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, $"{nameof(ConversationAnalysisClient)}.{nameof(SubmitJob)}", OperationFinalStateVia.Location, context, WaitUntil.Started, ConvertResponseToResult).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a collection of conversations for analysis. Specify one or more unique tasks to be executed. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Operation<AnalyzeConversationJobState> SubmitJob(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(SubmitJob)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSubmitJobRequest(content, context);
                return LowLevelOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, $"{nameof(ConversationAnalysisClient)}.{nameof(SubmitJob)}", OperationFinalStateVia.Location, context, WaitUntil.Started, ConvertResponseToResult);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> returns the authorization header. </summary>
        public static string GetAuthorizationHeader()
        {
            return AuthorizationHeader;
        }
    }
}
