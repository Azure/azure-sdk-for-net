// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Rest;

    /// <summary>
    /// Credentials used to authenticate to an Azure Search service.
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/"/>
    /// </summary>
    /// <remarks>
    /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/> for more information about API keys in Azure Search.
    /// </remarks>
    public class SearchCredentials : ServiceClientCredentials
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
            Throw.IfArgumentNullOrEmpty(apiKey, "apiKey");
            ApiKey = apiKey;
        }
        
        /// <summary>
        /// api-key used to authenticate to an Azure Search service. Can be either a query key for querying only, or
        /// an admin key that enables index and document management as well.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Adds the credentials to the given HTTP request.
        /// </summary>
        /// <param name="request">HTTP request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A Task to track the progress of the async operation.</returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Throw.IfArgumentNull(request, "request");

            request.Headers.Add("api-key", ApiKey);

            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
