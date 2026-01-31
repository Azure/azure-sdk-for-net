// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Search.Documents.KnowledgeBases.Models;

namespace Azure.Search.Documents.KnowledgeBases
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an knowledge base.
    /// </summary>
    public partial class KnowledgeBaseRetrievalClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SearchClientOptions.ServiceVersion _version;

        /// <summary>
        /// The HTTP pipeline for sending and receiving REST requests and responses.
        /// </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// Gets the URI endpoint of the Search service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the name of the knowledge base.
        /// </summary>
        public virtual string KnowledgeBaseName { get; }

        /// <summary>
        /// Gets the generated document operations to make requests.
        /// </summary>
        private KnowledgeRetrievalRestClient RestClient { get; }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the SearchClient class for
        /// mocking.
        /// </summary>
        protected KnowledgeBaseRetrievalClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgeBaseRetrievalClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, AzureKeyCredential credential) :
            this(endpoint, knowledgeBaseName, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgeBaseRetrievalClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, TokenCredential tokenCredential) :
            this(endpoint, knowledgeBaseName, tokenCredential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgeBaseRetrievalClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, AzureKeyCredential credential, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            KnowledgeBaseName = knowledgeBaseName;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(credential);
            _version = options.Version;

            RestClient = new KnowledgeRetrievalRestClient(
                _clientDiagnostics,
                _pipeline,
                endpoint.AbsoluteUri,
                KnowledgeBaseName,
                null,
                _version.ToVersionString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgeBaseRetrievalClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, TokenCredential tokenCredential, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            KnowledgeBaseName = knowledgeBaseName;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(tokenCredential);
            _version = options.Version;

            RestClient = new KnowledgeRetrievalRestClient(
                _clientDiagnostics,
                _pipeline,
                endpoint.AbsoluteUri,
                knowledgeBaseName,
                null,
                _version.ToVersionString());
        }
        #endregion ctors

        #region Service operations
        /// <summary> KnowledgeBase retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="xMsQuerySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        public virtual Response<KnowledgeBaseRetrievalResponse> Retrieve(KnowledgeBaseRetrievalRequest retrievalRequest, string xMsQuerySourceAuthorization = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(KnowledgeBaseRetrievalClient)}.{nameof(Retrieve)}");
            scope.Start();
            try
            {
                return RestClient.Retrieve(retrievalRequest, xMsQuerySourceAuthorization, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> KnowledgeBase retrieves relevant data from backing stores. </summary>
        /// <param name="retrievalRequest"> The retrieval request to process. </param>
        /// <param name="xMsQuerySourceAuthorization"> Token identifying the user for which the query is being executed. This token is used to enforce security restrictions on documents. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="retrievalRequest"/> is null. </exception>
        public virtual async Task<Response<KnowledgeBaseRetrievalResponse>> RetrieveAsync(KnowledgeBaseRetrievalRequest retrievalRequest, string xMsQuerySourceAuthorization = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(KnowledgeBaseRetrievalClient)}.{nameof(Retrieve)}");
            scope.Start();
            try
            {
                return await RestClient.RetrieveAsync(retrievalRequest, xMsQuerySourceAuthorization, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion Service operations
    }
}
