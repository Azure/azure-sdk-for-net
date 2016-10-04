// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using System.Net.Http;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public class AzureConfigurable<T> : IAzureConfigurable<T>
        where T : class, IAzureConfigurable<T>
    {
        private RestClient.RestClientBuilder.IBuildable restClientBuilder;
        protected AzureConfigurable()
        {
            restClientBuilder = RestClient
                .Configure()
                .withEnvironment(AzureEnvironment.AzureGlobalCloud);
        }

        public T WithDelegatingHandler(DelegatingHandler delegatingHandler)
        {
            restClientBuilder.withDelegatingHandler(delegatingHandler);
            return this as T;
        }

        public T WithLogLevel(HttpLoggingDelegatingHandler.Level level)
        {
            restClientBuilder.withLogLevel(level);
            return this as T;
        }

        public T WithRetryPolicy(RetryPolicy retryPolicy)
        {
            restClientBuilder.withRetryPolicy(retryPolicy);
            return this as T;
        }

        public T WithUserAgent(string product, string version)
        {
            restClientBuilder.withUserAgent(product, version);
            return this as T;
        }

        protected RestClient BuildRestClient(AzureCredentials credentials)
        {
            return restClientBuilder
                .withCredentials(credentials)
                .withEnvironment(credentials.Environment)
                .build();
        }

        protected RestClient BuildRestClientForGraph(AzureCredentials credentials)
        {
            return restClientBuilder
                .withCredentials(credentials)
                .withBaseUri(credentials.Environment.GraphEndpoint)
                .build();
        }
    }
}
