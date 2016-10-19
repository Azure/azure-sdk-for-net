// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;

namespace Microsoft.Rest.Azure
{
    /// Base class capturing the current Http state needed to communicate with Azure
    public sealed class AzureContext : IAzureContext
    {
        private readonly bool _disposeInnerHandlers;
        private bool _credentialsInitialized = false;
        private int _disposed = 0;
        private HttpClientReference _httpClient;
        private HttpMessageHandler _handler;
        private IDictionary<Type, IDisposable> _clients = new ConcurrentDictionary<Type, IDisposable>();

        /// <summary>
        /// The default context for the Azure cloud
        /// </summary>
        public static IAzureContext Default => new AzureContext(new Uri("https://management.azure.com/"));

        /// <summary>
        /// The default context for the Azure China cloud
        /// </summary>
        public static IAzureContext ChinaCloud => new AzureContext(new Uri("https://management.chinacloudapi.cn/"));

        /// <summary>
        /// The default context for the Azure German Cloud
        /// </summary>
        public static IAzureContext GermanCloud  => new AzureContext(new Uri("https://management.microsoftazure.de/"));

        /// <summary>
        /// The default context for the Azure German Cloud
        /// </summary>
        public static IAzureContext USGovernmentCloud = new AzureContext(new Uri("https://management.usgovcloudapi.net/"));

        /// <summary>
        /// The Azure subscription to target. The value should be in the form of a globally-unique identifier (GUID).
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The Azure tenant id to target.  The value should be in the form of a globally-unique identifier (GUID).
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The credentials to use when authenticationg with Azure endpoints.
        /// </summary>
        public ServiceClientCredentials Credentials { get; set; }

        /// <summary>
        /// The HttpClient used for communicating with Azure.
        /// </summary>
        public HttpClient HttpClient => _httpClient.GetReference();

        /// <summary>
        /// The maximum time to spend in retrying transient HTTP errors.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// Determines whether clients should automatically generate a client request id.  This id can be used to 
        /// retrieve logs for operations.
        /// </summary>
        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// The message handler stack used in Http communication with Azure.
        /// </summary>
        public HttpMessageHandler Handler => _handler;

        /// <summary>
        /// The HttpClientHandler used to communicate with Azure.
        /// </summary>
        public HttpClientHandler RootHandler { get; private set; }

        /// <summary>
        /// Extended properties to set on created clients.  Clients created from this context will have access to these properties.
        /// </summary>
        public IDictionary<string, object> ExtendedProperties { get; } = new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Create an AzureContext with the given baseUri and credentials.
        /// </summary>
        /// <param name="baseUri">The baseUri of the azure endpoints.</param>
        public AzureContext(Uri baseUri) : this(baseUri, null)
        {
        }

        /// <summary>
        /// Create an AzureContext with the given baseUri and credentials.
        /// </summary>
        /// <param name="baseUri">The baseUri of the azure endpoints.</param>
        /// <param name="credentials">The credentials to use when communicating with Azure</param>
        public AzureContext(Uri baseUri, ServiceClientCredentials credentials) : this(baseUri, credentials, null)
        {
        }

        /// <summary>
        /// Create an AzureContext with the given baseUri, credentials, and HttpHandler stack.
        /// </summary>
        /// <param name="baseUri">The baseUri of the azure endpoints.</param>
        /// <param name="credentials">The credentials to use when communicating with Azure</param>
        /// <param name="handler">The handler stack to use with the Http client</param>
        public AzureContext(Uri baseUri, ServiceClientCredentials credentials, HttpMessageHandler handler)
        {
            _disposeInnerHandlers = false;
            if (null == baseUri)
            {
                throw new ArgumentNullException(nameof(baseUri));
            }

            if (null == handler)
            {
                handler = new HttpClientHandler();
                _disposeInnerHandlers = true;
            }

            Credentials = credentials;
            RootHandler = GetRootHandler(handler);
            _handler = GetDefaultDelegatingHandler(handler);
            _httpClient = CreateHttpClient(Handler, baseUri);
        }

        private static HttpClientReference CreateHttpClient(HttpMessageHandler handler, Uri baseUri)
        {
            var client = new HttpClientReference(handler, false);
            client.BaseAddress = baseUri;
            return client;
        }

        private static RetryDelegatingHandler GetDefaultDelegatingHandler(HttpMessageHandler innerHandler)
        {
            var retry = new RetryDelegatingHandler();
            retry.InnerHandler = innerHandler;
            return retry;
        }

        /// <summary>
        /// Release any resources held in this context.
        /// </summary>
        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 0) == 0)
            {
                var disposableClients = Interlocked.Exchange(ref _clients, null);
                foreach (var disposableClient in disposableClients.Values)
                {
                    disposableClient.Dispose();
                }

                var client = Interlocked.Exchange(ref _httpClient, null);
                if (client != null)
                {
                    client.ResetReferences();
                    client.Dispose();
                }

                var handler = Interlocked.Exchange(ref _handler, null);
                if (handler != null)
                {
                    var delegatingHandler = handler as DelegatingHandler;
                    if (!_disposeInnerHandlers && delegatingHandler != null)
                    {
                        delegatingHandler.InnerHandler = null;
                    }

                    handler.Dispose();
                }
            }
        }

        /// <summary>
        /// Initialize a ServiceClient with the properties of this context.  This will set the SubscriptionId, ClientId, 
        /// and any extended properties used by the client
        /// </summary>
        /// <typeparam name="T">The type of the client to initialize</typeparam>
        /// <param name="clientCreator">The client constructor.</param>
        public T InitializeServiceClient<T>(Func<IClientContext, T> clientCreator) where T : ServiceClient<T>
        {
            if (!_clients.ContainsKey(typeof(T)))
            {

                var client = clientCreator(this);
                _clients[typeof(T)] = client;
                if (!_credentialsInitialized && Credentials != null)
                {
                    Credentials.InitializeServiceClient<T>(client);
                }

                if (SubscriptionId != null)
                {
                    TrySetProperty(client, nameof(SubscriptionId), SubscriptionId);
                }

                if (TenantId != null)
                {
                    TrySetProperty(client, nameof(TenantId), TenantId);
                }

                foreach (var propertyName in ExtendedProperties.Keys)
                {
                    TrySetProperty(client, propertyName, ExtendedProperties[propertyName]);
                }

                var azureClient = client as IAzureClient;
                if (azureClient != null)
                {
                    azureClient.LongRunningOperationRetryTimeout = LongRunningOperationRetryTimeout;
                    azureClient.GenerateClientRequestId = GenerateClientRequestId;
                }
            }

            return _clients[typeof(T)] as T;
        }

        private static void TrySetProperty<T>(ServiceClient<T> client, string name, object value) where T : ServiceClient<T>
        {
            var properties = typeof(T).GetProperties();
            if (properties.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    var property =
                        properties.First(
                            p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && p.SetMethod != null);
                    property.SetValue(client, value);
                }
                catch
                {
                }
            }
        }

        private static HttpClientHandler GetRootHandler(HttpMessageHandler handler)
        {
            var delegatingHandler = handler as DelegatingHandler;
            while (delegatingHandler != null)
            {
                handler = delegatingHandler.InnerHandler;
                delegatingHandler = handler as DelegatingHandler;
            }

            var result = handler as HttpClientHandler;
            if (result == null)
            {
                throw new ArgumentException($"{nameof(handler)} is not a valid http message handler chain.  There is no client handler in the chain.");
            }

            return result;
        }
    }
}
