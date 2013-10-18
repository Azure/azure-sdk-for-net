//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Common.Platform;

namespace Microsoft.WindowsAzure.Common
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
        /// Gets the Platform's IHttpTransportHandlerProvider which gives the
        /// default HttpHandler for sending web requests.
        /// </summary>
        private static IHttpTransportHandlerProvider _transportHandlerProvider = null;

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
        public HttpClient HttpClient { get; internal set; }
        
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
        /// Initialize the ServiceClient class.
        /// </summary>
        static ServiceClient()
        {
            _transportHandlerProvider = PortablePlatformAbstraction.Get<IHttpTransportHandlerProvider>(true);
        }

        /// <summary>
        /// Initializes a new instance of the ServiceClient class.
        /// </summary>
        public ServiceClient()
        {
            // Create our root handler
            HttpMessageHandler handler = _transportHandlerProvider.CreateHttpTransportHandler();
            _handler = new DisposableReference<HttpMessageHandler>(handler);

            // Create the HTTP client
            HttpClient = CreateHttpClient();
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
