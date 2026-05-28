// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;

    /// <summary>
    /// Allows authentication to the API using a basic apiKey mechanism
    /// </summary>
    public class EndpointKeyServiceClientCredentials : ServiceClientCredentials
    {
        private readonly string endpointKey;

        /// <summary>
        /// Creates a new instance of the EndpointKeyServiceClientCredentials class
        /// </summary>
        /// <param name="endpointKey">The Endpoint key to authenticate and authorize as</param>
        public EndpointKeyServiceClientCredentials(string endpointKey)
        {
            this.endpointKey = endpointKey;
        }

        /// <summary>
        /// Add the Basic Authentication Header to each outgoing request
        /// </summary>
        /// <param name="request">The outgoing request</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            request.Headers.Add("Authorization", $"EndpointKey {this.endpointKey}");

            return Task.FromResult<object>(null);
        }
    }
}
