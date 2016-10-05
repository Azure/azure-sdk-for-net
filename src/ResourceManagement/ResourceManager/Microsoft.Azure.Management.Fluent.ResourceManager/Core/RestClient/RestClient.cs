// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    /// <summary>
    /// The RestClient
    /// </summary>
    public class RestClient
    {
        private List<IRequestInterceptor> interceptors;

        private RestClient(HttpClientHandler httpClientHandler, List<IRequestInterceptor> interceptors)
        {
            RootHttpHandler = httpClientHandler;
            this.interceptors = interceptors;
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
                IList<InterceptorWrapperDelegateHandler> handlers = new List<InterceptorWrapperDelegateHandler>();
                foreach(var interceptor in this.interceptors)
                {
                    handlers.Add(new InterceptorWrapperDelegateHandler(interceptor));
                } 

                return new ReadOnlyCollection<InterceptorWrapperDelegateHandler>(handlers);
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
            private List<IRequestInterceptor> interceptors;
            private RetryPolicy retryPolicy;
            private HttpLoggingInterceptor loggingInterceptor;
            private UserAgentInterceptor userAgentInterceptor;

            /// <summary>
            /// Restrict access so that for users it can be created only by <HttpClient cref="RestClient.Configure" />
            /// </summary>
            internal RestClientBuilder()
            {
                interceptors = new List<IRequestInterceptor>();
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

                IBuildable WithRequestInterceptor(IRequestInterceptor interceptor);

                IBuildable WithLogLevel(HttpLoggingInterceptor.Level level);

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
                if (userAgentInterceptor == null)
                {
                    userAgentInterceptor = new UserAgentInterceptor();
                    WithRequestInterceptor(userAgentInterceptor);
                }
                userAgentInterceptor.AppendUserAgent(product + "/" + version);
                return this;
            }

            public IBuildable WithRequestInterceptor(IRequestInterceptor interceptor)
            {
                interceptors.Add(interceptor);
                return this;
            }

            public IBuildable WithRetryPolicy(RetryPolicy retryPolicy)
            {
                this.retryPolicy = retryPolicy;
                return this;
            }

            public IBuildable WithLogLevel(HttpLoggingInterceptor.Level level)
            {
                if (loggingInterceptor == null)
                {
                    loggingInterceptor = new HttpLoggingInterceptor();
                    WithRequestInterceptor(loggingInterceptor);
                }
                loggingInterceptor.LogLevel = level;
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
                return new RestClient(httpClientHandler, interceptors)
                {
                    BaseUri = baseUri,
                    Credentials = credentials,
                    RetryPolicy = retryPolicy
                };
            }
        }

        private class InterceptorWrapperDelegateHandler : DelegatingHandler
        {
            private readonly IRequestInterceptor interceptor;

            public InterceptorWrapperDelegateHandler(IRequestInterceptor interceptor)
            {
                this.interceptor = interceptor;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return await this.interceptor.SendAsync(base.SendAsync, request, cancellationToken);
            }
        }
    }
}