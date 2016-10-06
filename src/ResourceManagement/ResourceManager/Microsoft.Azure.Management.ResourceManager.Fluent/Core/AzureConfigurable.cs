// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using System.Net.Http;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public class AzureConfigurable<T> : IAzureConfigurable<T>
        where T : class, IAzureConfigurable<T>
    {
        private RestClient.RestClientBuilder.IBuildable restClientBuilder;
        protected AzureConfigurable()
        {
            restClientBuilder = RestClient
                .Configure()
                .WithEnvironment(AzureEnvironment.AzureGlobalCloud);
        }

        public T WithDelegatingHandler(DelegatingHandler delegatingHandler)
        {
            restClientBuilder.WithDelegatingHandler(delegatingHandler);
            return this as T;
        }

        public T WithLogLevel(HttpLoggingDelegatingHandler.Level level)
        {
            restClientBuilder.WithLogLevel(level);
            return this as T;
        }

        public T WithRetryPolicy(RetryPolicy retryPolicy)
        {
            restClientBuilder.WithRetryPolicy(retryPolicy);
            return this as T;
        }

        public T WithUserAgent(string product, string version)
        {
            restClientBuilder.WithUserAgent(product, version);
            return this as T;
        }

        protected RestClient BuildRestClient(AzureCredentials credentials)
        {
            return restClientBuilder
                .WithCredentials(credentials)
                .WithEnvironment(credentials.Environment)
                .Build();
        }

        protected RestClient BuildRestClientForGraph(AzureCredentials credentials)
        {
            return restClientBuilder
                .WithCredentials(credentials)
                .WithBaseUri(credentials.Environment.GraphEndpoint)
                .Build();
        }
    }
}
