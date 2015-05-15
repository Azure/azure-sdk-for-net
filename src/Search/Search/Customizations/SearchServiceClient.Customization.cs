﻿// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Hyak.Common.Internals;

namespace Microsoft.Azure.Search
{
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
        /// <param name='httpClient'>The Http client</param>
        public SearchServiceClient(string searchServiceName, SearchCredentials credentials, HttpClient httpClient)
            : this(httpClient)
        {
            if (searchServiceName == null)
            {
                throw new ArgumentNullException("searchServiceName");
            }
            
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            this._credentials = credentials;
            this._baseUri = BuildBaseUriForService(searchServiceName);

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
            
            this._credentials = credentials;
            this._baseUri = BuildBaseUriForService(searchServiceName);

            this.Credentials.InitializeServiceClient(this);
        }

        /// <inheritdoc />
        public void SetClientRequestId(Guid guid)
        {
            HttpRequestHeaders headers = HttpClient.DefaultRequestHeaders;

            if (headers.Contains(ClientRequestIdHeaderName))
            {
                headers.Remove(ClientRequestIdHeaderName);
            }

            headers.Add(ClientRequestIdHeaderName, guid.ToString());
        }

        private static Uri BuildBaseUriForService(string searchServiceName)
        {
            return TypeConversion.TryParseUri("https://" + searchServiceName + ".search.windows.net/");
        }
    }
}
