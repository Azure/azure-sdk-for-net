// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Net.Http;

    public partial class SearchIndexClient
    {
        private const string ClientRequestIdHeaderName = "client-request-id";

        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
        /// <param name='indexName'>Required. The name of the Azure Search index.</param>
        /// <param name='credentials'>Required. The credentials used to authenticate to an Azure Search service.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx" />
        /// </param>
        public SearchIndexClient(string searchServiceName, string indexName, SearchCredentials credentials)
            : this()
        {
            var validatedSearchServiceName = new SearchServiceName(searchServiceName);
            var validatedIndexName = new IndexName(indexName);
            Throw.IfArgumentNull(credentials, "credentials");

            this.Credentials = credentials;
            this.BaseUri = validatedSearchServiceName.BuildBaseUriWithIndex(validatedIndexName);

            this.Credentials.InitializeServiceClient(this);
        }

        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
        /// <param name='indexName'>Required. The name of the Azure Search index.</param>
        /// <param name='credentials'>Required. The credentials used to authenticate to an Azure Search service.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx" />
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
            var validatedSearchServiceName = new SearchServiceName(searchServiceName);
            var validatedIndexName = new IndexName(indexName);

            Throw.IfArgumentNull(credentials, "credentials");

            this.Credentials = credentials;
            this.BaseUri = validatedSearchServiceName.BuildBaseUriWithIndex(validatedIndexName);

            this.Credentials.InitializeServiceClient(this);
        }

        /// <inheritdoc />
        public SearchCredentials SearchCredentials
        {
            get { return (SearchCredentials)this.Credentials; }
        }

        /// <inheritdoc />
        public bool UseHttpGetForQueries { get; set; }
    }
}
