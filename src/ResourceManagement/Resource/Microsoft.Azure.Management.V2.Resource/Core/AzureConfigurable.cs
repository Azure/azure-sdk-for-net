using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using System.Net.Http;

namespace Microsoft.Azure.Management.V2.Resource.Core
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

        public T withDelegatingHandler(DelegatingHandler delegatingHandler)
        {
            restClientBuilder.withDelegatingHandler(delegatingHandler);
            return this as T;
        }

        public T withLogLevel(HttpLoggingDelegatingHandler.Level level)
        {
            restClientBuilder.withLogLevel(level);
            return this as T;
        }

        public T withRetryPolicy(RetryPolicy retryPolicy)
        {
            restClientBuilder.withRetryPolicy(retryPolicy);
            return this as T;
        }

        public T withUserAgent(string product, string version)
        {
            restClientBuilder.withUserAgent(product, version);
            return this as T;
        }

        protected RestClient BuildRestClient(ServiceClientCredentials credentials)
        {
            return restClientBuilder
                .withCredentials(credentials)
                .build();
        }
    }
}
