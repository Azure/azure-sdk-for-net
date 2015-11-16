// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.Rest;

    public partial class SearchServiceClient
    {
        private const string ClientRequestIdHeaderName = "client-request-id";

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
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
        public SearchServiceClient(
            string searchServiceName, 
            SearchCredentials credentials, 
            HttpClientHandler rootHandler, 
            params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (searchServiceName == null)
            {
                throw new ArgumentNullException("searchServiceName");
            }
            
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            this.Credentials = credentials;
            this.BaseUri = BuildBaseUriForService(searchServiceName);

            this.Credentials.InitializeServiceClient(this);
        }

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class.
        /// </summary>
        /// <param name='searchServiceName'>Required. The name of the Azure Search service.</param>
        /// <param name='credentials'>Required. The credentials used to authenticate to an Azure Search service.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </param>
        public SearchServiceClient(string searchServiceName, SearchCredentials credentials)
            : this()
        {
            if (searchServiceName == null)
            {
                throw new ArgumentNullException("searchServiceName");
            }

            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            
            this.Credentials = credentials;
            this.BaseUri = BuildBaseUriForService(searchServiceName);

            this.Credentials.InitializeServiceClient(this);
        }

        /// <inheritdoc />
        public SearchCredentials SearchCredentials
        {
            get { return (SearchCredentials)this.Credentials; }
        }

        private static Uri BuildBaseUriForService(string searchServiceName)
        {
            return TypeConversion.TryParseUri("https://" + searchServiceName + ".search.windows.net/");
        }
    }
}
