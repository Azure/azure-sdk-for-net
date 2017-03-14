// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Hyak.Common.Internals;
using Hyak.Common.TransientFaultHandling;

namespace Hyak.Common
{
    /// <summary>
    /// The base ServiceClient class used to call REST services.
    /// </summary>
    /// <typeparam name="T">Type of the ServiceClient.</typeparam>
    public abstract class ServiceClient<T>
        : IDisposable
        where T : ServiceClient<T>
    {

        /// <summary>
        /// A value indicating whether or not the ServiceClient has already
        /// been disposed.
        /// </summary>
        internal bool _disposed = false;

        /// <summary>
        /// Reference to the delegated handler of our handler (so we can
        /// maintain a proper reference count).
        /// </summary>
        internal DisposableReference<HttpMessageHandler> _innerHandler = null;
        
        /// <summary>
        /// Reference to our HTTP handler (which is the start of our HTTP
        /// pipeline).
        /// </summary>
        internal DisposableReference<HttpMessageHandler> _handler = null;

        /// <summary>
        /// Gets the HttpClient used for making HTTP requests.
        /// </summary>
        public HttpClient HttpClient { get; set; }
        
        /// <summary>
        /// Gets a reference to our HTTP handler (which is the start of our
        /// HTTP pipeline).
        /// </summary>
        protected internal HttpMessageHandler HttpMessageHandler
        {
            get { return _handler.Reference; }
        }

        /// <summary>
        /// Gets the UserAgent collection which can be augmented with custom
        /// user agent strings.
        /// </summary>
        public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent
        {
            get { return HttpClient.DefaultRequestHeaders.UserAgent; }
        }


        /// <summary>
        /// Initializes a new instance of the ServiceClient class.
        /// </summary>
        public ServiceClient()
        {
            // Create our root handler
#if NET45
            HttpClientHandler handler = new WebRequestHandler();
#else
            HttpClientHandler handler = new HttpClientHandler();
#endif
            InitializeHttpClient(handler);
        }

        /// <summary>
        /// Initializes a new instance of the ServiceClient class.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public ServiceClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// Dispose the ServiceClient.
        /// </summary>
        public virtual void Dispose()
        {
            // Only dispose once
            if (!_disposed)
            {
                _disposed = true;

                // Dispose the client
                HttpClient.Dispose();
                HttpClient = null;

                // Release the reference to our inner handler
                if (_innerHandler != null)
                {
                    _innerHandler.ReleaseReference();
                    _innerHandler = null;
                }
                
                // Release the reference to our root handler
                _handler.ReleaseReference();
                _handler = null;
            }
        }

        public virtual T WithHandler(DelegatingHandler handler)
        {
            return (T)WithHandler(Activator.CreateInstance(typeof(T)) as T, handler);
        }

        public T WithHandlers(IEnumerable<DelegatingHandler> handlers)
        {
            T currentClient = (T)this;

            foreach (DelegatingHandler handler in handlers)
            {
                T newClient = currentClient.WithHandler(handler);
                if (currentClient != this)
                {
                    currentClient.Dispose();
                }

                currentClient = newClient;
            }

            return currentClient;
        }

        /// <summary>
        /// Get the HTTP pipeline for the given service client.
        /// </summary>
        /// <returns>The client's HTTP pipeline.</returns>
        public IEnumerable<HttpMessageHandler> GetHttpPipeline()
        {
            var handler = this.HttpMessageHandler;

            while (handler != null)
            {
                yield return handler;

                DelegatingHandler delegating = handler as DelegatingHandler;
                handler = delegating != null ? delegating.InnerHandler : null;
            }
        }

        /// <summary>
        /// Add a handler to the end of the client's HTTP pipeline.
        /// </summary>
        /// <param name="handler">The handler to add.</param>
        public void AddHandlerToPipeline(DelegatingHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }

            // Get our handler references
            DisposableReference<HttpMessageHandler> inner = this._innerHandler;
            DisposableReference<HttpMessageHandler> current = this._handler;
            DisposableReference<HttpMessageHandler> next = new DisposableReference<HttpMessageHandler>(handler);

            // Drop the current inner handler (note that current will still
            // maintain a reference via its pipeline to prevent its disposal)
            if (inner != null)
            {
                this._innerHandler = null;
                inner.ReleaseReference();
                inner = null;
            }

            // Associate the next handler with the current handler (and take a
            // reference on it)
            handler.InnerHandler = new IndisposableDelegatingHandler(current.Reference);
            current.AddReference();

            // Update the client's handler references
            this._innerHandler = current;
            this._handler = next;

            // Recreate our HttpClient with the new root of our pipeline
            HttpClient oldClient = this.HttpClient;
            this.HttpClient = new HttpClient(handler, false);
            ServiceClient<T>.CloneHttpClient(oldClient, this.HttpClient);
        }

        /// <summary>
        /// Sets retry policy for the client.
        /// </summary>
        /// <param name="retryPolicy">Retry policy to set.</param>
        public void SetRetryPolicy(RetryPolicy retryPolicy)
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            RetryHandler handler = this.GetHttpPipeline().OfType<RetryHandler>().FirstOrDefault();
            if (handler != null)
            {
                handler.RetryPolicy = retryPolicy;
            }
            else
            {
                throw new InvalidOperationException(Properties.Resources.ExceptionRetryHandlerMissing);
            }
        }

        /// <summary>
        /// Initializes HttpClient.
        /// </summary>
        /// <param name="httpMessageHandler">Http message handler to use with Http client.</param>
        protected void InitializeHttpClient(HttpMessageHandler httpMessageHandler)
        {
            _handler = new DisposableReference<HttpMessageHandler>(httpMessageHandler);

            // Create the HTTP client
            HttpClient = CreateHttpClient();

            // Add retry handler
            this.AddHandlerToPipeline(new RetryHandler());
        }

        /// <summary>
        /// Create the HTTP client.
        /// </summary>
        /// <returns>The HTTP client.</returns>
        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient(_handler.Reference, false);

            Type type = this.GetType();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(type.FullName, this.GetAssemblyVersion()));

            return client;
        }

        /// <summary>
        /// Get the assembly version of a service client.
        /// </summary>
        /// <returns>The assembly version of the client.</returns>
        private string GetAssemblyVersion()
        {
            Type type = this.GetType();
            string version =
                type
                .GetTypeInfo()
                .Assembly
                .FullName
                .Split(',')
                .Select(c => c.Trim())
                .Where(c => c.StartsWith("Version="))
                .FirstOrDefault()
                .Substring("Version=".Length);
            return version;
        }

        /// <summary>
        /// Clone the service client.
        /// </summary>
        /// <param name="client">The client to clone.</param>
        protected virtual void Clone(ServiceClient<T> client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            // Copy over the HttpClient
            CloneHttpClient(HttpClient, client.HttpClient);
        }

        /// <summary>
        /// Clone HttpClient properties.
        /// </summary>
        /// <param name="source">The client to clone.</param>
        /// <param name="destination">The client to copy into.</param>
        internal static void CloneHttpClient(HttpClient source, HttpClient destination)
        {
            // Copy over the standard HttpClient members
            destination.Timeout = source.Timeout;
            destination.MaxResponseContentBufferSize = source.MaxResponseContentBufferSize;
            destination.BaseAddress = source.BaseAddress;

            // Copy over the UserAgent
            destination.DefaultRequestHeaders.UserAgent.Clear();
            foreach (ProductInfoHeaderValue agent in source.DefaultRequestHeaders.UserAgent)
            {
                destination.DefaultRequestHeaders.UserAgent.Add(agent);
            }

            // Copy over any other default headers
            foreach (KeyValuePair<string, IEnumerable<string>> header in
                source.DefaultRequestHeaders.Where(p => p.Key != "User-Agent"))
            {
                destination.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        /// <summary>
        /// Extend the ServiceClient with a new handler.
        /// </summary>
        /// <param name="newClient">The new client that will extend.</param>
        /// <param name="handler">The handler to extend with.</param>
        /// <returns>The extended client.</returns>
        protected virtual T WithHandler(ServiceClient<T> newClient, DelegatingHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }
            else if (newClient == null)
            {
                throw new ArgumentNullException("newClient");
            }

            // Chain together handlers
            newClient._handler = new DisposableReference<HttpMessageHandler>(handler);
            newClient._innerHandler = _handler;
            _handler.AddReference();

            // Wrap the InnerHandler in a special delegating handler that won't
            // automatically dispose the entire HTTP pipeline when it gets
            // disposed itself.
            handler.InnerHandler = new IndisposableDelegatingHandler(_handler.Reference);

            // Clone the HttpClient with our new handler
            newClient.HttpClient = new HttpClient(handler, false);
            Clone(newClient);

            return (T)newClient;
        }
    }
}
