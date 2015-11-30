namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Retries;

    /// <summary>
    /// A configuration object for <see cref="HttpRestClient{TServiceInterface}"/>.
    /// </summary>
    public class HttpRestClientConfiguration
    {
        private IReadOnlyList<DelegatingHandler> _additionalDelegatingHandlers;
        private readonly TimeSpan _httpRequestTimeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRestClientConfiguration" /> class.
        /// </summary>
        /// <param name="defaultHttpClientHandler">The default HTTP client handler.</param>
        /// <param name="messageProcessingHandlers">The message processing handlers.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="httpRequestTimeout">The HTTP request timeout. Defaults to 1 minute.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Good design.")]
        public HttpRestClientConfiguration(HttpMessageHandler defaultHttpClientHandler = null,
            IEnumerable<DelegatingHandler> messageProcessingHandlers = null,
            IRetryPolicy retryPolicy = null, 
            TimeSpan? httpRequestTimeout = null)
        {
            this._httpRequestTimeout = httpRequestTimeout ?? TimeSpan.FromMinutes(1);
            this.HttpMessageHandler = defaultHttpClientHandler ?? new HttpClientHandler();
            if (messageProcessingHandlers == null)
            {
                this._additionalDelegatingHandlers = new ReadOnlyCollection<DelegatingHandler>(new List<DelegatingHandler>());
            }
            else
            {
                this._additionalDelegatingHandlers = new ReadOnlyCollection<DelegatingHandler>(messageProcessingHandlers.ToList());
            }

            this.RetryPolicy = retryPolicy ?? new NoRetryPolicy();

            //Here we chain the delegating handlers such that each delegating handler has the next one as its inner handler
            for (int i = this.DelegatingHandlers.Count - 1; i >= 0; i--)
            {
                if (i - 1 >= 0)
                {
                    this.DelegatingHandlers[i - 1].InnerHandler = this.DelegatingHandlers[i];
                }
            }

            //the first delegating handler has the default defaultHttpClientHandler as its inner handler
            if (this.DelegatingHandlers.Any())
            {
                this.DelegatingHandlers.Last().InnerHandler = this.HttpMessageHandler;
            }

        }

        /// <summary>
        /// Gets the root handler in the Http handler chain.
        /// </summary>
        /// <value>
        /// The root handler.
        /// </value>
        internal HttpMessageHandler RootHandler
        {
            get
            {
                if (this.DelegatingHandlers.Any())
                {
                    return this.DelegatingHandlers.First();
                }
                return this.HttpMessageHandler;
            }
        }

        /// <summary>
        /// Gets the retry policy.
        /// </summary>
        /// <value>
        /// The retry policy.
        /// </value>
        public IRetryPolicy RetryPolicy { get; private set; }

        /// <summary>
        /// Gets the default HTTP client handler.
        /// </summary>
        /// <value>
        /// The default HTTP client handler.
        /// </value>
        public HttpMessageHandler HttpMessageHandler
        {
            get; private set;
        }

        /// <summary>
        /// Gets the delegating handlers.
        /// </summary>
        /// <value>
        /// The delegating handlers.
        /// </value>
        public IReadOnlyList<DelegatingHandler> DelegatingHandlers
        {
            get
            {
                return this._additionalDelegatingHandlers;
            }
        }

        /// <summary>
        /// Gets the HTTP request timeout. The default value is 1 minute. This conforms to the HttpClient RequestTimeout default.
        /// </summary>
        /// <value>
        /// The HTTP request timeout.
        /// </value>
        public TimeSpan HttpRequestTimeout
        {
            get
            {
                return this._httpRequestTimeout;
            }
        }
    }
}
