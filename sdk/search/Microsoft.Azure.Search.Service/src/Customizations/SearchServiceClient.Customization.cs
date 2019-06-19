// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Net.Http;
    using Common;
    using Rest;

    public partial class SearchServiceClient
    {
        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
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
        public SearchServiceClient(
            string searchServiceName, 
            SearchCredentials credentials, 
            HttpClientHandler rootHandler, 
            params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            Initialize(searchServiceName, credentials);
        }

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
        /// <param name='credentials'>Required. The credentials used to authenticate to an Azure Search service.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/" />
        /// </param>
        public SearchServiceClient(string searchServiceName, SearchCredentials credentials)
            : this()
        {
            Initialize(searchServiceName, credentials);
        }

        /// <summary>
        /// Gets the credentials used to authenticate to an Azure Search service. This can be either a query API key or an admin API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/> for more information about API keys in Azure Search.
        /// </remarks>
        public SearchCredentials SearchCredentials => (SearchCredentials)Credentials;

        private void Initialize(string searchServiceName, SearchCredentials credentials)
        {
            Throw.IfArgumentNull(credentials, nameof(credentials));
            ValidateSearchServiceName(searchServiceName);

            Credentials = credentials;
            SearchServiceName = searchServiceName;

            Credentials.InitializeServiceClient(this);
        }

        private static void ValidateSearchServiceName(string searchServiceName)
        {
            Throw.IfNullOrEmptySearchServiceName(searchServiceName);

            Uri uri = TypeConversion.TryParseUri($"https://{searchServiceName}.search.windows.net/");

            if (uri == null)
            {
                throw new ArgumentException(
                    $"Invalid search service name: '{searchServiceName}' Name contains characters that are not valid in a URL.",
                    nameof(searchServiceName));
            }
        }
    }
}
