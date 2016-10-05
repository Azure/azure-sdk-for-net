// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
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
                foreach (var handler in handlers)
                {
                    handler.InnerHandler = new HttpClientHandler();
                }
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
                IBuildable WithBaseUri(string baseUri);
            }

            public interface IWithEnvironment
            {
                IBuildable WithEnvironment(AzureEnvironment environment);
            }

            public interface IBuildable : IWithEnvironment, IWithBaseUri
            {
                IBuildable WithUserAgent(string product, string version);

                IBuildable WithRetryPolicy(RetryPolicy retryPolicy);

                IBuildable WithDelegatingHandler(DelegatingHandler delegatingHandler);

                IBuildable WithLogLevel(HttpLoggingDelegatingHandler.Level level);

                IBuildable WithCredentials(ServiceClientCredentials credentials);

                RestClient Build();
            }

            #endregion Fluent builder interfaces

            public IBuildable WithBaseUri(string baseUri)
            {
                this.baseUri = baseUri;
                return this;
            }

            public IBuildable WithEnvironment(AzureEnvironment environment)
            {
                return WithBaseUri(environment.ResourceManagerEndpoint);
            }

            public IBuildable WithUserAgent(string product, string version)
            {
                if (userAgentDelegatingHandler == null)
                {
                    userAgentDelegatingHandler = new UserAgentDelegatingHandler();
                    WithDelegatingHandler(userAgentDelegatingHandler);
                }
                userAgentDelegatingHandler.AppendUserAgent(product + "/" + version);
                return this;
            }

            public IBuildable WithDelegatingHandler(DelegatingHandler delegatingHandler)
            {
                handlers.Add(delegatingHandler);
                return this;
            }

            public IBuildable WithRetryPolicy(RetryPolicy retryPolicy)
            {
                this.retryPolicy = retryPolicy;
                return this;
            }

            public IBuildable WithLogLevel(HttpLoggingDelegatingHandler.Level level)
            {
                if (loggingDelegatingHandler == null)
                {
                    loggingDelegatingHandler = new HttpLoggingDelegatingHandler();
                    WithDelegatingHandler(loggingDelegatingHandler);
                }
                loggingDelegatingHandler.LogLevel = level;
                return this;
            }

            public IBuildable WithCredentials(ServiceClientCredentials credentials)
            {
                this.credentials = credentials;
                return this;
            }

            public RestClient Build()
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