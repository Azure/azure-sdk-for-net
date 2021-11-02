// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The <see cref="ConversationAnalysisClient"/> allows you analyze conversations.
    /// </summary>
    public class ConversationAnalysisClient
    {
        internal const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        private readonly ConversationAnalysisRestClient _analysisRestClient;

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

            Endpoint = endpoint;
            options ??= new ConversationAnalysisClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            Pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            _analysisRestClient = new(Diagnostics, Pipeline, Endpoint, options.Version);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected ConversationAnalysisClient()
        {
        }

        /// <summary>
        /// Get the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the <see cref="ClientDiagnostics"/> for this client.
        /// </summary>
        private protected virtual ClientDiagnostics Diagnostics { get; }

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> for this client.
        /// </summary>
        private protected virtual HttpPipeline Pipeline { get; }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="query">The conversation utterance to be analyzed.</param>
        /// <param name="conversationsProject">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="conversationsProject"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnalyzeConversationResult>> AnalyzeConversationAsync(string query, ConversationsProject conversationsProject, CancellationToken cancellationToken = default) =>
            AnalyzeConversationAsync(conversationsProject, new AnalyzeConversationOptions(query), cancellationToken);

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="conversationsProject">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="options">
        /// An <see cref="AnalyzeConversationOptions"/> containing the <see cref="AnalyzeConversationOptions.Query"/>,
        /// <see cref="AnalyzeConversationOptions.Language"/>, and other options to analyze.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="conversationsProject"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnalyzeConversationResult>> AnalyzeConversationAsync(ConversationsProject conversationsProject, AnalyzeConversationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(conversationsProject, nameof(conversationsProject));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute("projectName", conversationsProject.ProjectName);
            scope.AddAttribute("deploymentName", conversationsProject.DeploymentName);
            scope.Start();

            try
            {
                return await _analysisRestClient.AnalyzeConversationAsync(conversationsProject.ProjectName, conversationsProject.DeploymentName, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="query">The conversation utterance to be analyzed.</param>
        /// <param name="conversationsProject">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="conversationsProject"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationResult> AnalyzeConversation(string query, ConversationsProject conversationsProject, CancellationToken cancellationToken = default) =>
            AnalyzeConversation(conversationsProject, new AnalyzeConversationOptions(query), cancellationToken);

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="conversationsProject">The <see cref="ConversationsProject"/> used for conversation analysis.</param>
        /// <param name="options">
        /// An <see cref="AnalyzeConversationOptions"/> containing the <see cref="AnalyzeConversationOptions.Query"/>,
        /// <see cref="AnalyzeConversationOptions.Language"/>, and other options to analyze.
        /// </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationResult> AnalyzeConversation(ConversationsProject conversationsProject, AnalyzeConversationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(conversationsProject, nameof(conversationsProject));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute("projectName", conversationsProject.ProjectName);
            scope.AddAttribute("deploymentName", conversationsProject.DeploymentName);
            scope.Start();

            try
            {
                return _analysisRestClient.AnalyzeConversation(conversationsProject.ProjectName, conversationsProject.DeploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
