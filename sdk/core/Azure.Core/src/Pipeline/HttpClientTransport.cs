// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        /// <summary>
        /// Reference-counted wrapper around HttpClient to ensure safe disposal during concurrent access.
        /// </summary>
        private sealed class HttpClientWrapper
        {
            private readonly HttpClient _client;
            private volatile int _refCount = 1; // Start with 1 reference (the transport itself)

            public HttpClientWrapper(HttpClient client, bool disableRefCounting = false)
            {
                _client = client ?? throw new ArgumentNullException(nameof(client));
                IsRefCountingEnabled = !disableRefCounting;
            }

            public HttpClient Client => _client;

            public bool IsRefCountingEnabled { get; set; }

            /// <summary>
            /// Atomically increment reference count if not disposed.
            /// </summary>
            /// <returns>True if reference was successfully added, false if already disposed.</returns>
            public bool TryAddRef()
            {
                int currentCount;
                do
                {
                    currentCount = _refCount;
                    if (currentCount == 0) return false; // Already disposed
                }
                while (Interlocked.CompareExchange(ref _refCount, currentCount + 1, currentCount) != currentCount);

                return true;
            }

            /// <summary>
            /// Atomically decrement reference count and dispose if needed.
            /// </summary>
            public void Release()
            {
                if (Interlocked.Decrement(ref _refCount) == 0)
                {
                    _client.Dispose();
                }
            }
        }

        /// <summary>
        /// A shared instance of <see cref="HttpClientTransport"/> with default parameters.
        /// </summary>
        public static readonly HttpClientTransport Shared = new HttpClientTransport();

        private volatile HttpClientWrapper _clientWrapper;

        // The transport's private HttpClient is internal because it is used by tests.
        internal HttpClient Client => _clientWrapper.Client ?? throw new ObjectDisposedException(nameof(HttpClientTransport));

        internal Func<HttpPipelineTransportOptions, HttpClient>? _clientFactory { get; }
        internal Func<HttpPipelineTransportOptions, HttpMessageHandler>? _handlerFactory { get; }

        /// <summary>
        /// Internal property for testing: indicates whether reference counting is enabled for this transport instance.
        /// </summary>
        internal bool IsRefCountingEnabled => _clientWrapper?.IsRefCountingEnabled ?? false;

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        public HttpClientTransport() : this(CreateDefaultClient())
        {
            _clientFactory = CreateDefaultClient;
            _clientWrapper.IsRefCountingEnabled = true;
        }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        /// <param name="options">The <see cref="HttpPipelineTransportOptions"/> that to configure the behavior of the transport.</param>
        internal HttpClientTransport(HttpPipelineTransportOptions? options = null)
            : this(_ => CreateDefaultClient(options))
        { }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="messageHandler">The instance of <see cref="HttpMessageHandler"/> to use.</param>
        public HttpClientTransport(HttpMessageHandler messageHandler)
        {
            var client = new HttpClient(messageHandler ?? throw new ArgumentNullException(nameof(messageHandler)));
            _clientWrapper = new HttpClientWrapper(client, true);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided handler factory.
        /// </summary>
        /// <param name="handlerFactory">The factory function to create the message handler.</param>
        public HttpClientTransport(Func<HttpPipelineTransportOptions, HttpMessageHandler> handlerFactory)
            : this(handlerFactory.Invoke(new HttpPipelineTransportOptions()))
        {
            _handlerFactory = handlerFactory;
            _clientWrapper.IsRefCountingEnabled = true;
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="client">The instance of <see cref="HttpClient"/> to use.</param>
        public HttpClientTransport(HttpClient client)
        {
            _clientWrapper = new HttpClientWrapper(client ?? throw new ArgumentNullException(nameof(client)), true);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided factory.
        /// </summary>
        /// <param name="clientFactory">The factory function to create the client.</param>
        public HttpClientTransport(Func<HttpPipelineTransportOptions, HttpClient> clientFactory) : this(clientFactory.Invoke(new HttpPipelineTransportOptions()))
        {
            _clientFactory = clientFactory;
            _clientWrapper.IsRefCountingEnabled = true;
        }

        /// <inheritdoc />
        public override void Update(HttpPipelineTransportOptions options)
        {
            if (this == Shared)
            {
                throw new InvalidOperationException("Cannot update the shared HttpClientTransport instance.");
            }

            HttpClient? newClient = null;
            if (_clientFactory != null && _clientFactory != CreateDefaultClient)
            {
                newClient = _clientFactory(options);
            }
            else if (_handlerFactory != null)
            {
                var handler = _handlerFactory(options);
                newClient = new HttpClient(handler);
            }
            else
            {
                // No factory to create a new client, so we cannot update.
                if (_clientFactory != CreateDefaultClient)
                {
                    AzureCoreEventSource.Singleton.FailedToUpdateTransport("No factory available to create a new HttpClient instance.");
                } else
                {
                    AzureCoreEventSource.Singleton.FailedToUpdateTransport("Skipping transport update because no custom factory is available to create a new HttpClient instance.");
                }
                return;
            }

            var newWrapper = new HttpClientWrapper(newClient);
            var oldWrapper = Interlocked.Exchange(ref _clientWrapper!, newWrapper);

            // Release the transport's reference to the old client
            oldWrapper?.Release();
        }

        /// <inheritdoc />
        public sealed override Request CreateRequest()
            => new HttpClientTransportRequest();

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
#if NET5_0_OR_GREATER
            ProcessSyncOrAsync(message, async: false).EnsureCompleted();
#else
            // Intentionally blocking here
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            ProcessAsync(message).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
#endif
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message)
            => ProcessSyncOrAsync(message, async: true);

#pragma warning disable CA1801 // async parameter unused on netstandard
        private async ValueTask ProcessSyncOrAsync(HttpMessage message, bool async)
#pragma warning restore CA1801
        {
            using HttpRequestMessage httpRequest = BuildRequestMessage(message);
            HttpResponseMessage responseMessage;
            Stream? contentStream = null;
            message.ClearResponse();

            // Get reference-counted access to the client
            var clientWrapper = _clientWrapper;
            if (clientWrapper.IsRefCountingEnabled && !clientWrapper.TryAddRef())
            {
                throw new ObjectDisposedException(nameof(HttpClientTransport));
            }

            try
            {
                var localClient = clientWrapper.Client;
#if NET5_0_OR_GREATER
                if (!async)
                {
                    // Sync HttpClient.Send is not supported on browser but neither is the sync-over-async
                    // HttpClient.Send would throw a NotSupported exception instead of GetAwaiter().GetResult()
                    // throwing a System.Threading.SynchronizationLockException: Cannot wait on monitors on this runtime.
#pragma warning disable CA1416 // 'HttpClient.Send(HttpRequestMessage, HttpCompletionOption, CancellationToken)' is unsupported on 'browser'
                    responseMessage = localClient.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken);
#pragma warning restore CA1416
                }
                else
#endif
                {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    responseMessage = await localClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken)
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                        .ConfigureAwait(false);
                }

                if (responseMessage.Content != null)
                {
#if NET5_0_OR_GREATER
                    if (async)
                    {
                        contentStream = await responseMessage.Content.ReadAsStreamAsync(message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        contentStream = responseMessage.Content.ReadAsStream(message.CancellationToken);
                    }
#else
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    contentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
#endif
                }
            }
            // HttpClient on NET5 throws OperationCanceledException from sync call sites, normalize to TaskCanceledException
            catch (OperationCanceledException e) when (CancellationHelper.ShouldWrapInOperationCanceledException(e, message.CancellationToken))
            {
                throw CancellationHelper.CreateOperationCanceledException(e, message.CancellationToken);
            }
            catch (HttpRequestException e)
            {
                throw new RequestFailedException(e.Message, e);
            }
            finally
            {
                if (clientWrapper.IsRefCountingEnabled)
                {
                    // Release the reference to the client wrapper
                    clientWrapper.Release();
                }
            }

            message.Response = new HttpClientTransportResponse(message.Request.ClientRequestId, responseMessage, contentStream);
        }

        private static HttpClient CreateDefaultClient(HttpPipelineTransportOptions? options = null)
        {
            var httpMessageHandler = CreateDefaultHandler(options);
            SetProxySettings(httpMessageHandler);
            ServicePointHelpers.SetLimits(httpMessageHandler);

            return new HttpClient(httpMessageHandler)
            {
                // Timeouts are handled by the pipeline
                Timeout = Timeout.InfiniteTimeSpan,
            };
        }

        private static HttpMessageHandler CreateDefaultHandler(HttpPipelineTransportOptions? options = null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                // UseCookies is not supported on "browser"
                return new HttpClientHandler();
            }

#if NETCOREAPP
            return ApplyOptionsToHandler(new SocketsHttpHandler { AllowAutoRedirect = false, UseCookies = UseCookies() }, options);
#else
            return ApplyOptionsToHandler(new HttpClientHandler { AllowAutoRedirect = false, UseCookies = UseCookies() }, options);
#endif
        }

        private static void SetProxySettings(HttpMessageHandler messageHandler)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                return;
            }

            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                switch (messageHandler)
                {
#if NETCOREAPP
                    case SocketsHttpHandler socketsHttpHandler:
                        socketsHttpHandler.Proxy = webProxy;
                        break;
#endif
                    case HttpClientHandler httpClientHandler:
                        httpClientHandler.Proxy = webProxy;
                        break;
                    default:
                        Debug.Assert(false, "Unknown handler type");
                        break;
                }
            }
        }

#if NETCOREAPP
        private static SocketsHttpHandler ApplyOptionsToHandler(SocketsHttpHandler httpHandler, HttpPipelineTransportOptions? options)
        {
            if (options == null || RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                return httpHandler;
            }

#pragma warning disable CA1416 // 'X509Certificate2' is unsupported on 'browser'
            // ServerCertificateCustomValidationCallback
            if (options.ServerCertificateCustomValidationCallback != null)
            {
                httpHandler.SslOptions.RemoteCertificateValidationCallback = (_, certificate, x509Chain, sslPolicyErrors) =>
                    options.ServerCertificateCustomValidationCallback(
                        new ServerCertificateCustomValidationArgs(
                            certificate is { } ? new X509Certificate2(certificate) : null,
                            x509Chain,
                            sslPolicyErrors));
            }
            // Set ClientCertificates
            foreach (var cert in options.ClientCertificates)
            {
                httpHandler.SslOptions ??= new System.Net.Security.SslClientAuthenticationOptions();
                httpHandler.SslOptions.ClientCertificates ??= new X509CertificateCollection();
                httpHandler.SslOptions.ClientCertificates!.Add(cert);
            }
#pragma warning restore CA1416 // 'X509Certificate2' is unsupported on 'browser'
            return httpHandler;
        }
#else
        private static HttpClientHandler ApplyOptionsToHandler(HttpClientHandler httpHandler, HttpPipelineTransportOptions? options)
        {
            if (options == null || RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                return httpHandler;
            }

            // ServerCertificateCustomValidationCallback
            if (options.ServerCertificateCustomValidationCallback != null)
            {
                httpHandler.ServerCertificateCustomValidationCallback = (_, certificate2, x509Chain, sslPolicyErrors) =>
                {
                    return options.ServerCertificateCustomValidationCallback(
                        new ServerCertificateCustomValidationArgs(certificate2, x509Chain, sslPolicyErrors));
                };
            }
            // Set ClientCertificates
            foreach (var cert in options.ClientCertificates)
            {
                httpHandler.ClientCertificates.Add(cert);
            }
            return httpHandler;
        }
#endif
        /// <summary>
        /// Disposes the underlying <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            if (this != Shared)
            {
                _clientWrapper?.Release();
            }

            GC.SuppressFinalize(this);
        }

        private static void SetPropertiesOrOptions<T>(HttpRequestMessage httpRequest, string name, T value)
        {
#if NET5_0_OR_GREATER
            httpRequest.Options.Set(new HttpRequestOptionsKey<T>(name), value);
#else
            httpRequest.Properties[name] = value;
#endif
        }

        private static bool UseCookies() => AppContextSwitchHelper.GetConfigValue(
            "Azure.Core.Pipeline.HttpClientTransport.EnableCookies",
            "AZURE_CORE_HTTPCLIENT_ENABLE_COOKIES");
    }
}
