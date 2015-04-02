// 
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
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;

namespace Microsoft.Azure.Search
{
    /// <summary>
    /// Credentials used to authenticate to an Azure Search service.  (see 
    /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/> for more information)
    /// </summary>
    public sealed class SearchCredentials : CloudCredentials
    {
        /// <summary>
        /// Initializes a new instance of the SearchCredentials class with a query key or an admin key. Use a query
        /// key if your application does not require write access to the Search Service or index.
        /// </summary>
        /// <param name="apiKey">api-key used to authenticate to the Azure Search service.</param>
        /// <remarks>
        /// If your application performs only query operations on an index, we recommend passing a query key for the
        /// <paramref name="apiKey"/> parameter. This ensures that you have read-only access to the index, which is
        /// consistent with the principle of least privilege.
        /// </remarks>
        public SearchCredentials(string apiKey)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException("apiKey");
            }

            if (apiKey.Length == 0)
            {
                throw new ArgumentException("apiKey");
            }

            this.ApiKey = apiKey;
        }
        
        /// <summary>
        /// api-key used to authenticate to an Azure Search service. Can be either a query key for querying only, or
        /// an admin key that enables index and document management as well.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Adds the credentials to the given HTTP request.
        /// </summary>
        /// <param name="request">HTTP request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A Task to track the progress of the async operation.</returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Headers.Add("api-key", ApiKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
