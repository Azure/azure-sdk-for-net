﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
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

        // The transport's private HttpClient has been made internal because it is used by tests.
        // TODO: move these tests into System.Rest? - can we make it private when we do?
        internal HttpClient Client { get; }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        public HttpClientTransport() : this(CreateDefaultClient())
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="messageHandler">The instance of <see cref="HttpMessageHandler"/> to use.</param>
        public HttpClientTransport(HttpMessageHandler messageHandler) : this(new HttpClient(messageHandler))
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="client">The instance of <see cref="HttpClient"/> to use.</param>
        public HttpClientTransport(HttpClient client) : base(client)
        {
            Client = client;
        }

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        /// <param name="options">The <see cref="HttpPipelineTransportOptions"/> that to configure the behavior of the transport.</param>
        internal HttpClientTransport(HttpPipelineTransportOptions? options = null) : this(CreateDefaultClient(options))
        { }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override Request CreateRequest() => new HttpClientTransportRequest();

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
            try
            {
                base.Process(message);
            }
            catch (MessageFailedException e)
            {
                if (message.HasResponse)
                {
                    throw new RequestFailedException(message.Response, e.InnerException);
                }
                else
                {
                    throw new RequestFailedException(e.Message, e.InnerException);
                }
            }
        }

        /// <inheritdoc />
        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            try
            {
                await base.ProcessAsync(message).ConfigureAwait(false);
            }
            catch (MessageFailedException e)
            {
                if (message.HasResponse)
                {
                    throw new RequestFailedException(message.Response, e.InnerException);
                }
                else
                {
                    throw new RequestFailedException(e.Message, e.InnerException);
                }
            }
        }

        /// <inheritdoc />
        protected override void OnSendingRequest(PipelineMessage message, HttpRequestMessage httpRequest)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
            }

            HttpClientTransportRequest.AddAzureProperties(httpMessage, httpRequest);

            httpMessage.ClearResponse();
        }

        /// <inheritdoc />
        protected override void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse, Stream? contentStream)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
            }

            string clientRequestId = httpMessage.Request.ClientRequestId;
            message.Response = new HttpClientTransportResponse(clientRequestId, httpResponse, contentStream);
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

        private static bool UseCookies() => AppContextSwitchHelper.GetConfigValue(
            "Azure.Core.Pipeline.HttpClientTransport.EnableCookies",
            "AZURE_CORE_HTTPCLIENT_ENABLE_COOKIES");

        /// <summary>
        /// Disposes the underlying <see cref="HttpClient"/>.
        /// </summary>
        public override void Dispose()
        {
            if (this != Shared)
            {
                Client.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
