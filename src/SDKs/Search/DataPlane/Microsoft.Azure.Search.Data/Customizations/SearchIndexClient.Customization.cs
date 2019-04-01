// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Net.Http;
    using Microsoft.Azure.Search.Common;
    using Microsoft.Rest;

    public partial class SearchIndexClient
    {
        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
        /// <param name='indexName'>Required. The name of the Azure Search index.</param>
        /// <param name='credentials'>Required. The credentials used to authenticate to an Azure Search service.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/" />
        /// </param>
        public SearchIndexClient(string searchServiceName, string indexName, SearchCredentials credentials)
            : this()
        {
            Initialize(searchServiceName, indexName, credentials);
        }

        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
        /// <param name='indexName'>Required. The name of the Azure Search index.</param>
        /// <param name='credentials'>Required. The credentials used to authenticate to an Azure Search service.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/" />
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public SearchIndexClient(
            string searchServiceName, 
            string indexName,
            SearchCredentials credentials,
            HttpClientHandler rootHandler,
            params DelegatingHandler[] handlers)
            : this(rootHandler, handlers)
        {
            Initialize(searchServiceName, indexName, credentials);
        }

        /// <summary>
        /// Gets the credentials used to authenticate to an Azure Search service. This can be either a query API key or an admin API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/> for more information about API keys in Azure Search.
        /// </remarks>
        public SearchCredentials SearchCredentials => (SearchCredentials)Credentials;

        /// <summary>
        /// Indicates whether the index client should use HTTP GET for making Search and Suggest requests to the
        /// Azure Search REST API. The default is <c>false</c>, which indicates that HTTP POST will be used.
        /// </summary>
        public bool UseHttpGetForQueries { get; set; }

        /// <summary>
        /// Changes the BaseUri of this client to target a different index in the same Azure Search service. This method is NOT thread-safe; You
        /// must guarantee that no other threads are using the client before calling it.
        /// </summary>
        /// <param name="newIndexName">The name of the index to which all subsequent requests should be sent.</param>
        [Obsolete("This method is deprecated. Please set the IndexName property instead.")]
        public void TargetDifferentIndex(string newIndexName)
        {
            ThrowIfNullOrEmptyIndexName(newIndexName, nameof(newIndexName));
            IndexName = newIndexName;
        }

        internal IDocumentsProxyOperations DocumentsProxy { get; private set; }

        partial void CustomInitialize()
        {
            DocumentsProxy = new DocumentsProxyOperations(this);
        }

        private static void ValidateSearchServiceAndIndexNames(string searchServiceName, string indexName)
        {
            Throw.IfNullOrEmptySearchServiceName(searchServiceName);
            ThrowIfNullOrEmptyIndexName(indexName, nameof(indexName));

            Uri uri = TypeConversion.TryParseUri($"https://{searchServiceName}.search.windows.net/indexes('{indexName}')/");

            if (uri == null)
            {
                throw new ArgumentException(
                    $"Either the search service name '{searchServiceName}' or the index name '{indexName}' is invalid. Names must contain only characters that are valid in a URL.",
                    nameof(searchServiceName));
            }
        }

        private static void ThrowIfNullOrEmptyIndexName(string name, string paramName) =>
            Throw.IfArgumentNullOrEmpty(
                name,
                paramName,
                "Invalid index name. Name cannot be null or an empty string.");

        private void Initialize(string searchServiceName, string indexName, SearchCredentials credentials)
        {
            Throw.IfArgumentNull(credentials, nameof(credentials));
            ValidateSearchServiceAndIndexNames(searchServiceName, indexName);

            SearchServiceName = searchServiceName;
            IndexName = indexName;

            Credentials = credentials;
            Credentials.InitializeServiceClient(this);
        }
    }
}
