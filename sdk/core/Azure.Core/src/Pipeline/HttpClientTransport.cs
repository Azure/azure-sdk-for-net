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

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        /// <summary>
        /// A shared instance of <see cref="HttpClientTransport"/> with default parameters.
        /// </summary>
        public static readonly HttpClientTransport Shared = new HttpClientTransport();

        // The transport's private HttpClient is internal because it is used by tests.
        internal HttpClient Client { get; }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        public HttpClientTransport() : this(CreateDefaultClient())
        { }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        /// <param name="options">The <see cref="HttpPipelineTransportOptions"/> that to configure the behavior of the transport.</param>
        internal HttpClientTransport(HttpPipelineTransportOptions? options = null) : this(CreateDefaultClient(options))
        { }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="messageHandler">The instance of <see cref="HttpMessageHandler"/> to use.</param>
        public HttpClientTransport(HttpMessageHandler messageHandler)
        {
            Client = new HttpClient(messageHandler) ?? throw new ArgumentNullException(nameof(messageHandler));
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="client">The instance of <see cref="HttpClient"/> to use.</param>
        public HttpClientTransport(HttpClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
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
            try
            {
#if NET5_0_OR_GREATER
                if (!async)
                {
                    // Sync HttpClient.Send is not supported on browser but neither is the sync-over-async
                    // HttpClient.Send would throw a NotSupported exception instead of GetAwaiter().GetResult()
                    // throwing a System.Threading.SynchronizationLockException: Cannot wait on monitors on this runtime.
#pragma warning disable CA1416 // 'HttpClient.Send(HttpRequestMessage, HttpCompletionOption, CancellationToken)' is unsupported on 'browser'
                    responseMessage = Client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken);
#pragma warning restore CA1416
                }
                else
#endif
                {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    responseMessage = await Client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken)
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
            return ApplyOptionsToHandler(CreateSocketsHttpHandler(), options);
#else
            return ApplyOptionsToHandler(CreateHttpClientHandler(), options);
#endif
        }

#if NETCOREAPP
        private static SocketsHttpHandler CreateSocketsHttpHandler()
        {
#pragma warning disable CA1416 // Validate platform compatibility - Browser platform check handled in CreateDefaultHandler
            var handler = new SocketsHttpHandler { UseCookies = UseCookies() };
            try
            {
                handler.AllowAutoRedirect = false;
            }
            catch (PlatformNotSupportedException)
            {
                // On some platforms (e.g., WebAssembly), setting AllowAutoRedirect is not supported
                // In such cases, we continue without setting it, as the default behavior should be acceptable
                // for most scenarios or will be handled by higher-level redirect policies
            }
#pragma warning restore CA1416 // Validate platform compatibility
            return handler;
        }
#endif

        private static HttpClientHandler CreateHttpClientHandler()
        {
#pragma warning disable CA1416 // Validate platform compatibility - Browser platform check handled in CreateDefaultHandler
            var handler = new HttpClientHandler { UseCookies = UseCookies() };
            try
            {
                handler.AllowAutoRedirect = false;
            }
            catch (PlatformNotSupportedException)
            {
                // On some platforms (e.g., WebAssembly), setting AllowAutoRedirect is not supported
                // In such cases, we continue without setting it, as the default behavior should be acceptable
                // for most scenarios or will be handled by higher-level redirect policies
            }
#pragma warning restore CA1416 // Validate platform compatibility
            return handler;
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
                Client.Dispose();
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
