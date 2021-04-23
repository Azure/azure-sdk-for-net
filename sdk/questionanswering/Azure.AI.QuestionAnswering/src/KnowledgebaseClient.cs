// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.QuestionAnswering.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.QuestionAnswering
{
    /// <summary>
    /// The KnowlwedgebaseClient allows you to update and delete knowledgebases, and to ask questions using those knowledgebases.
    /// </summary>
    public class KnowledgebaseClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly KnowledgebaseRestClient _knowledgebaseRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgebaseClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="knowledgebaseId">The unique identifier of the knowledgebase to manage.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the <paramref name="endpoint"/>, such as <c>DefaultAzureCredential</c>.</param>
        /// <exception cref="ArgumentException"><paramref name="knowledgebaseId"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/>, <paramref name="knowledgebaseId"/>, or <paramref name="credential"/> is null.</exception>
        public KnowledgebaseClient(Uri endpoint, string knowledgebaseId, AzureKeyCredential credential) : this(endpoint, knowledgebaseId, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgebaseClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="knowledgebaseId">The unique identifier of the knowledgebase to manage.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the <paramref name="endpoint"/>, such as <c>DefaultAzureCredential</c>.</param>
        /// <param name="options">Optional <see cref="QuestionAnsweringClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentException"><paramref name="knowledgebaseId"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/>, <paramref name="knowledgebaseId"/>, or <paramref name="credential"/> is null.</exception>
        public KnowledgebaseClient(Uri endpoint, string knowledgebaseId, AzureKeyCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(knowledgebaseId, nameof(knowledgebaseId));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            KnowledgebaseId = knowledgebaseId;
            options ??= new QuestionAnsweringClientOptions();

            _diagnostics = new ClientDiagnostics(options);

            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, QuestionAnsweringServiceClient.AuthorizationHeader));

            // TODO: The api-version is hard-coded into the path and needs to be parameterized.
            _knowledgebaseRestClient = new KnowledgebaseRestClient(_diagnostics, pipeline, endpoint);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgebaseClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="knowledgebaseId">The unique identifier of the knowledgebase to manage.</param>
        /// <param name="knowledgebaseRestClient">An initialized <see cref="KnowledgebaseRestClient"/>.</param>
        internal KnowledgebaseClient(Uri endpoint, string knowledgebaseId, KnowledgebaseRestClient knowledgebaseRestClient)
        {
            Endpoint = endpoint;
            KnowledgebaseId = knowledgebaseId;
            _knowledgebaseRestClient = knowledgebaseRestClient;
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected KnowledgebaseClient()
        {
        }

        /// <summary>
        /// Gets the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the knowledgebase identifier for this client.
        /// </summary>
        public virtual string KnowledgebaseId { get; }

        /// <summary>
        /// Gets details about the knowledgebase with identifier <see cref="KnowledgebaseId"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A response containing a <see cref="Knowledgebase"/> with identifier <see cref="KnowledgebaseId"/>.</returns>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual Response<Knowledgebase> GetDetails(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KnowledgebaseClient)}.{nameof(GetDetails)}");
            scope.Start();

            try
            {
                return _knowledgebaseRestClient.GetDetails(KnowledgebaseId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets details about the knowledgebase with identifier <see cref="KnowledgebaseId"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A response containing a <see cref="Knowledgebase"/> with identifier <see cref="KnowledgebaseId"/>.</returns>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual async Task<Response<Knowledgebase>> GetDetailsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KnowledgebaseClient)}.{nameof(GetDetails)}");
            scope.Start();

            try
            {
                return await _knowledgebaseRestClient.GetDetailsAsync(KnowledgebaseId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
