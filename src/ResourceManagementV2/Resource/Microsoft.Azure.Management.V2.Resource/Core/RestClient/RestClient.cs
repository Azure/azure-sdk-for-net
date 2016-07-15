using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// The RestClient
    /// </summary>
    public class RestClient
    {
        private List<DelegatingHandler> handlers;

        private RestClient(HttpClientHandler httpClientHandler, List<DelegatingHandler> handlers)
        {
            RootHttpHandler = httpClientHandler;
            this.handlers = handlers;
        }

        public string BaseUri
        {
            get; private set;
        }

        public ServiceClientCredentials Credentials
        {
            get; private set;
        }

        public RetryPolicy RetryPolicy
        {
            get; private set;
        }

        public IReadOnlyCollection<DelegatingHandler> Handlers
        {
            get
            {
                return new ReadOnlyCollection<DelegatingHandler>(handlers);
            }
        }

        public HttpClientHandler RootHttpHandler
        {
            get; private set;
        }

        /// <summary>
        /// Builder to configure and build a RestClient.
        /// </summary>
        /// <returns></returns>
        public static RestClientBuilder.IBlank Configure()
        {
            return new RestClientBuilder();
        }

        // The builder for <RestClient cref="RestClient" />
        public class RestClientBuilder : RestClientBuilder.IBlank, RestClientBuilder.IBuildable
        {
            private string baseUri;
            private ServiceClientCredentials credentials;
            private List<DelegatingHandler> handlers;
            private RetryPolicy retryPolicy;
            private HttpLoggingDelegatingHandler loggingDelegatingHandler;
            private UserAgentDelegatingHandler userAgentDelegatingHandler;

            /// <summary>
            /// Restrict access so that for users it can be created only by <HttpClient cref="RestClient.Configure" />
            /// </summary>
            internal RestClientBuilder()
            {
                handlers = new List<DelegatingHandler>();
            }

            #region Fluent builder interfaces
            public interface IBlank : IWithBaseUri, IWithEnvironment
            {
            }

            public interface IWithBaseUri
            {
                IBuildable withBaseUri(string baseUri);
            }

            public interface IWithEnvironment
            {
                IBuildable withEnvironment(AzureEnvironment environment);
            }

            public interface IBuildable
            {
                IBuildable withUserAgent(string product, string version);
                IBuildable withRetryPolicy(RetryPolicy retryPolicy);
                IBuildable withDelegatingHandler(DelegatingHandler delegatingHandler);
                IBuildable withLogLevel(HttpLoggingDelegatingHandler.Level level);
                IBuildable withCredentials(ServiceClientCredentials credentials);
                RestClient build();
            }
            #endregion

            public IBuildable withBaseUri(string baseUri)
            {
                this.baseUri = baseUri;
                return this;
            }

            public IBuildable withEnvironment(AzureEnvironment environment)
            {
                return withBaseUri(environment.ResourceManagerEndpoint);
            }

            public IBuildable withUserAgent(string product, string version)
            {
                if (userAgentDelegatingHandler == null)
                {
                    userAgentDelegatingHandler = new UserAgentDelegatingHandler();
                    withDelegatingHandler(userAgentDelegatingHandler);
                }
                userAgentDelegatingHandler.appendUserAgent(product + "/" + version);
                return this;
            }

            public IBuildable withDelegatingHandler(DelegatingHandler delegatingHandler)
            {
                handlers.Add(delegatingHandler);
                return this;
            }

            public IBuildable withRetryPolicy(RetryPolicy retryPolicy)
            {
                this.retryPolicy = retryPolicy;
                return this;
            }

            public IBuildable withLogLevel(HttpLoggingDelegatingHandler.Level level)
            {
                if (loggingDelegatingHandler == null)
                {
                    loggingDelegatingHandler = new HttpLoggingDelegatingHandler();
                    withDelegatingHandler(loggingDelegatingHandler);
                }
                loggingDelegatingHandler.LogLevel = level;
                return this;
            }

            public IBuildable withCredentials(ServiceClientCredentials credentials)
            {
                this.credentials = credentials;
                return this;
            }

            public RestClient build()
            {
#if NET45
                HttpClientHandler httpClientHandler = new WebRequestHandler();
#else
                HttpClientHandler httpClientHandler = new HttpClientHandler();
#endif
                return new RestClient(httpClientHandler, handlers)
                {
                    BaseUri = baseUri,
                    Credentials = credentials,
                    RetryPolicy = retryPolicy
                };
            }
        }
    }
}
