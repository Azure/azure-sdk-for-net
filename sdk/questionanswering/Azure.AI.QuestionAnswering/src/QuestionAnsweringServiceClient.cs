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
    /// The QuestionAnsweringClient allows you to manage Question Answering service-level features like endpoint keys, and create knowledgebases.
    /// </summary>
    public class QuestionAnsweringServiceClient
    {
        internal const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        private readonly EndpointKeysRestClient _endpointKeysClient;
        private readonly KnowledgebaseRestClient _knowledgebaseRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringServiceClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the <paramref name="endpoint"/>, such as <c>DefaultAzureCredential</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringServiceClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringServiceClient"/> class.
        /// </summary>
        /// <param name="endpoint">The Question Answering endpoint on which to operate.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the <paramref name="endpoint"/>, such as <c>DefaultAzureCredential</c>.</param>
        /// <param name="options">Optional <see cref="QuestionAnsweringClientOptions"/> to customize requests sent to the endpoint.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringServiceClient(Uri endpoint, AzureKeyCredential credential, QuestionAnsweringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            options ??= new QuestionAnsweringClientOptions();

            Diagnostics = new ClientDiagnostics(options);
            Pipeline = HttpPipelineBuilder.Build(
                options,
                new AzureKeyCredentialPolicy(credential, AuthorizationHeader));

            // TODO: The api-version is hard-coded into the path and needs to be parameterized.
            _endpointKeysClient = new EndpointKeysRestClient(Diagnostics, Pipeline, endpoint);
            _knowledgebaseRestClient = new KnowledgebaseRestClient(Diagnostics, Pipeline, endpoint);
        }

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected QuestionAnsweringServiceClient()
        {
        }

        /// <summary>
        /// Get the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the <see cref="ClientDiagnostics"/> for this client.
        /// </summary>
        internal virtual ClientDiagnostics Diagnostics { get; }

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> for this client.
        /// </summary>
        internal virtual HttpPipeline Pipeline { get; }

        #region Endpoint keys operations
        /// <summary>
        /// Gets keys for the given <see cref="Endpoint"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A response containing <see cref="EndpointKeys"/> for the given <see cref="Endpoint"/>.</returns>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual Response<EndpointKeys> GetEndpointKeys(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringServiceClient)}.{nameof(GetEndpointKeys)}");
            scope.Start();

            try
            {
                return _endpointKeysClient.GetKeys(cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets keys for the given <see cref="Endpoint"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A response containing <see cref="EndpointKeys"/> for the given <see cref="Endpoint"/>.</returns>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual async Task<Response<EndpointKeys>> GetEndpointKeysAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringServiceClient)}.{nameof(GetEndpointKeys)}");
            scope.Start();

            try
            {
                return await _endpointKeysClient.GetKeysAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Refreshes a specific key for the given <see cref="Endpoint"/>.
        /// </summary>
        /// <param name="keyType">The type of key to refresh.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A response containing <see cref="EndpointKeys"/> with the refreshed key.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyType"/> is null.</exception>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual Response<EndpointKeys> RefreshEndpointKeys(string keyType, CancellationToken cancellationToken = default)
        {
            // TODO: better describe what values keyType accepts. Can it be the name of EndpointKeys properties?

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringServiceClient)}.{nameof(RefreshEndpointKeys)}");
            scope.Start();

            try
            {
                return _endpointKeysClient.RefreshKeys(keyType, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Refreshes a specific key for the given <see cref="Endpoint"/>.
        /// </summary>
        /// <param name="keyType">The type of key to refresh.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A response containing <see cref="EndpointKeys"/> with the refreshed key.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyType"/> is null.</exception>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual async Task<Response<EndpointKeys>> RefreshEndpointKeysAsync(string keyType, CancellationToken cancellationToken = default)
        {
            // TODO: better describe what values keyType accepts. Can it be the name of EndpointKeys properties?

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringServiceClient)}.{nameof(RefreshEndpointKeys)}");
            scope.Start();

            try
            {
                return await _endpointKeysClient.RefreshKeysAsync(keyType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region Knowledgebase operations
        /// <summary>
        /// Creates a knowledgebase.
        /// </summary>
        /// <param name="parameters">Information about the knowledgebase to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A <see cref="KnowledgebaseOperation"/> to monitor the long-running operation of creating a knowledgebase.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual KnowledgebaseOperation CreateKnowledgebase(CreateKnowledgebaseParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringServiceClient)}.{nameof(CreateKnowledgebase)}");
            scope.Start();

            try
            {
                Response<KnowledgebaseOperation> response = _knowledgebaseRestClient.Create(parameters, cancellationToken);

                // TODO: Consider wrapping (originally named) Operation which makes it easier to pass in the response and not hide other members.
                return response.Value;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a knowledgebase.
        /// </summary>
        /// <param name="parameters">Information about the knowledgebase to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>A <see cref="KnowledgebaseOperation"/> to monitor the long-running operation of creating a knowledgebase.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="RequestFailedException">The request failed. Check the <see cref="RequestFailedException.ErrorCode"/> for details.</exception>
        public virtual async Task<KnowledgebaseOperation> CreateKnowledgebaseAsync(CreateKnowledgebaseParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = Diagnostics.CreateScope($"{nameof(QuestionAnsweringServiceClient)}.{nameof(CreateKnowledgebase)}");
            scope.Start();

            try
            {
                Response<KnowledgebaseOperation> response = await _knowledgebaseRestClient.CreateAsync(parameters, cancellationToken).ConfigureAwait(false);

                // TODO: Consider wrapping (originally named) Operation which makes it easier to pass in the response and not hide other members.
                return response.Value;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a <see cref="KnowledgebaseClient"/> for the given <paramref name="knowledgebaseId"/>.
        /// </summary>
        /// <param name="knowledgebaseId">The knowledgebase identifier to manage.</param>
        /// <returns>A <see cref="KnowledgebaseClient"/> for the given <paramref name="knowledgebaseId"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="knowledgebaseId"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgebaseId"/> is null.</exception>
        public virtual KnowledgebaseClient GetKnowledgebaseClient(string knowledgebaseId) =>
            new KnowledgebaseClient(Endpoint, knowledgebaseId, _knowledgebaseRestClient);
        #endregion
    }
}
