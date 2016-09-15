// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Linq;
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
            Initialize(searchServiceName, indexName, credentials);
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
            Initialize(searchServiceName, indexName, credentials);
        }

        /// <inheritdoc />
        public SearchCredentials SearchCredentials
        {
            get { return (SearchCredentials)this.Credentials; }
        }

        /// <inheritdoc />
        public bool UseHttpGetForQueries { get; set; }

        /// <inheritdoc />
        public void TargetDifferentIndex(string newIndexName)
        {
            // ASSUMPTION: BaseUri is set by every constructor.
            Tuple<string, string> hostAndFqdn = SplitHost(this.BaseUri.Host);
            string searchServiceName = hostAndFqdn.Item1;
            string fullyQualifiedDomainName = hostAndFqdn.Item2;
            SetBaseUri(searchServiceName, newIndexName, fullyQualifiedDomainName);
        }

        internal IDocumentsProxyOperations DocumentsProxy { get; private set; }

        partial void CustomInitialize()
        {
            DocumentsProxy = new DocumentsProxyOperations(this);
        }

        private static Tuple<string, string> SplitHost(string host)
        {
            int indexOfFirstDot = host.IndexOf('.');
            if (indexOfFirstDot == -1 || indexOfFirstDot == host.Length - 1)
            {
                return Tuple.Create(host, String.Empty);
            }
            else
            {
                return Tuple.Create(host.Substring(0, indexOfFirstDot), host.Substring(indexOfFirstDot + 1));
            }
        }

        private void Initialize(string searchServiceName, string indexName, SearchCredentials credentials)
        {
            Throw.IfArgumentNull(credentials, "credentials");

            this.SetBaseUri(searchServiceName, indexName);

            this.Credentials = credentials;
            this.Credentials.InitializeServiceClient(this);
        }

        private void SetBaseUri(string searchServiceName, string indexName, string fullyQualifiedDomainName = null)
        {
            var validatedSearchServiceName = new SearchServiceName(searchServiceName);
            var validatedIndexName = new IndexName(indexName);

            this.BaseUri = validatedSearchServiceName.BuildBaseUriWithIndex(validatedIndexName, fullyQualifiedDomainName);
        }
    }
}
