// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
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
        /// <param name="endpoint">The Converation Analysis endpoint on which to operate.</param>
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
        /// <param name="options">The utterance to query along with other options to analyze a conversation.</param>
        /// <param name="deploymentName">The optional deployment name of the project to use, such as "test" or "prod". The default is "prod".</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual async Task<Response<AnalyzeConversationResult>> AnalyzeConversationAsync(string projectName, AnalyzeConversationOptions options, string deploymentName = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(projectName, nameof(projectName));
            Argument.AssertNotNull(options, nameof(options));

            // BUGBUG: Work around https://github.com/Azure/azure-rest-api-specs/issues/16050
            deploymentName ??= "prod";

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute(nameof(projectName), projectName);
            scope.AddAttribute(nameof(deploymentName), deploymentName);
            scope.Start();

            try
            {
                return await _analysisRestClient.AnalyzeConversationsAsync(projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Analyzes a conversational utterance.</summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="options">The utterance to query along with other options to analyze a conversation.</param>
        /// <param name="deploymentName">The optional deployment name of the project to use, such as "test" or "prod". The default is "prod".</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> to cancel the request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">The service returned an error. The exception contains details of the service error.</exception>
        public virtual Response<AnalyzeConversationResult> AnalyzeConversation(string projectName, AnalyzeConversationOptions options, string deploymentName = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(projectName, nameof(projectName));
            Argument.AssertNotNull(options, nameof(options));

            // BUGBUG: Work around https://github.com/Azure/azure-rest-api-specs/issues/16050
            deploymentName ??= "prod";

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(ConversationAnalysisClient)}.{nameof(AnalyzeConversation)}");
            scope.AddAttribute(nameof(projectName), projectName);
            scope.AddAttribute(nameof(deploymentName), deploymentName);
            scope.Start();

            try
            {
                return _analysisRestClient.AnalyzeConversations(projectName, deploymentName, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
