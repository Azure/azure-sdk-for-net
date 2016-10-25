// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest
{
    /// <summary>
    /// ServiceClientCredentials is the abstraction for credentials used by ServiceClients accessing REST services.
    /// </summary>
    public abstract class ServiceClientCredentials
    {
        /// <summary>
        /// Initialize a ServiceClient instance for accessing REST APIs with these credentials. 
        /// </summary>
        /// <typeparam name="T">Type of ServiceClient.</typeparam>
        /// <param name="client">The ServiceClient.</param>
        public virtual void InitializeServiceClient<T>(ServiceClient<T> client)
            where T : ServiceClient<T>
        {
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has finished.
        /// </returns>
        public virtual Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Return an empty task by default
            return Task.FromResult<object>(null);
        }
    }
}