// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Search.Documents;

// TODO: Fix this in generator
// namespace Azure.Search.Documents.Indexes
namespace Azure.Azure.Search.Documents.Documents.Indexes
{
    /// <summary>
    /// Customizations for the generated <see cref="SearchIndexerClient"/>.
    /// Azure Cognitive Search client that can be used to manage and query
    /// indexes and documents, as well as manage other resources, on a Search
    /// Service.
    /// </summary>
    public partial class SearchIndexerClient
    {
        private SearchClientOptions.ServiceVersion _version;
        private ObjectSerializer _serializer;
        private string _serviceName;

        /// <summary>
        /// Gets the URI endpoint of the Search service. This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the name of the Search service.
        /// </summary>
        public virtual string ServiceName =>
            _serviceName ??= Endpoint.GetSearchServiceName();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class for mocking.
        /// </summary>
        protected SearchIndexerClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexerClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(Uri endpoint, AzureKeyCredential credential) :
            this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(Uri endpoint, TokenCredential tokenCredential) :
            this(endpoint, tokenCredential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexerClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(
            Uri endpoint,
            AzureKeyCredential credential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            ClientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            Pipeline = options.Build(credential);
            _version = options.Version.ToServiceVersion();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(
            Uri endpoint,
            TokenCredential tokenCredential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            ClientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = tokenCredential;
            Pipeline = options.Build(tokenCredential);
            _version = options.Version.ToServiceVersion();
        }
    }
}
