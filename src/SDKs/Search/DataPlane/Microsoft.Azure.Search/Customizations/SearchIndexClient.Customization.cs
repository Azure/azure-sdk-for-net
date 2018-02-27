// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Net.Http;

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

        /// <inheritdoc />
        public SearchCredentials SearchCredentials => (SearchCredentials)Credentials;

        /// <inheritdoc />
        public bool UseHttpGetForQueries { get; set; }

        /// <inheritdoc />
        [Obsolete("This method is deprecated. Please set the IndexName property instead.")]
        public void TargetDifferentIndex(string newIndexName)
        {
            var validatedIndexName = new IndexName(newIndexName);
            IndexName = validatedIndexName;
        }

        internal IDocumentsProxyOperations DocumentsProxy { get; private set; }

        partial void CustomInitialize()
        {
            DocumentsProxy = new DocumentsProxyOperations(this);
        }

        private void Initialize(string searchServiceName, string indexName, SearchCredentials credentials)
        {
            Throw.IfArgumentNull(credentials, nameof(credentials));

            var validatedSearchServiceName = new SearchServiceName(searchServiceName);
            var validatedIndexName = new IndexName(indexName);

            validatedSearchServiceName.TryBuildUriWithIndex(validatedIndexName);

            SearchServiceName = validatedSearchServiceName;
            IndexName = validatedIndexName;

            Credentials = credentials;
            Credentials.InitializeServiceClient(this);
        }
    }
}
