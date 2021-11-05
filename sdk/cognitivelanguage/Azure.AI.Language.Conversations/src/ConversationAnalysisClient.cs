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
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "production".</param>
        /// <param name="query">The conversation utterance to be analyzed.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/>, <paramref name="deploymentName"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Task<Response<AnalyzeConversationResult>> AnalyzeConversationAsync(string projectName, string deploymentName, string query, CancellationToken cancellationToken = default) =>
            AnalyzeConversationAsync(new AnalyzeConversationOptions(projectName, deploymentName, query), cancellationToken);

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="options">
        /// An <see cref="AnalyzeConversationOptions"/> containing the <see cref="AnalyzeConversationOptions.ProjectName"/>,
        /// <see cref="AnalyzeConversationOptions.DeploymentName"/>, <see cref="AnalyzeConversationOptions.Query"/>, and other options to analyze.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnalyzeConversationResult>> AnalyzeConversationAsync(AnalyzeConversationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute("projectName", options.ProjectName);
            scope.AddAttribute("deploymentName", options.DeploymentName);
            scope.Start();

            try
            {
                return await _analysisRestClient.AnalyzeConversationAsync(options.ProjectName, options.DeploymentName, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "production".</param>
        /// <param name="query">The conversation utterance to be analyzed.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/>, <paramref name="deploymentName"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationResult> AnalyzeConversation(string projectName, string deploymentName, string query, CancellationToken cancellationToken = default) =>
            AnalyzeConversation(new AnalyzeConversationOptions(projectName, deploymentName, query), cancellationToken);

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="options">
        /// An <see cref="AnalyzeConversationOptions"/> containing the <see cref="AnalyzeConversationOptions.ProjectName"/>,
        /// <see cref="AnalyzeConversationOptions.DeploymentName"/>, <see cref="AnalyzeConversationOptions.Query"/>, and other options to analyze.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationResult> AnalyzeConversation(AnalyzeConversationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute("projectName", options.ProjectName);
            scope.AddAttribute("deploymentName", options.DeploymentName);
            scope.Start();

            try
            {
                return _analysisRestClient.AnalyzeConversation(options.ProjectName, options.DeploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
