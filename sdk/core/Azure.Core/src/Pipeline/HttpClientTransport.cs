// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        internal const string MessageForServerCertificateCallback = "MessageForServerCertificateCallback";

        // Internal for testing
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

        /// <summary>
        /// A shared instance of <see cref="HttpClientTransport"/> with default parameters.
        /// </summary>
        public static readonly HttpClientTransport Shared = new HttpClientTransport();

        /// <inheritdoc />
        public sealed override Request CreateRequest()
            => new PipelineRequest();

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
#if NET5_0_OR_GREATER
            ProcessAsync(message, false).EnsureCompleted();
#else
            // Intentionally blocking here
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            ProcessAsync(message).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
#endif
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message) => ProcessAsync(message, true);

#pragma warning disable CA1801 // async parameter unused on netstandard
        private async ValueTask ProcessAsync(HttpMessage message, bool async)
#pragma warning restore CA1801
        {
            using HttpRequestMessage httpRequest = BuildRequestMessage(message);
            SetPropertiesOrOptions<HttpMessage>(httpRequest, MessageForServerCertificateCallback, message);
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

            message.Response = new PipelineResponse(message.Request.ClientRequestId, responseMessage, contentStream);
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

        private static HttpRequestMessage BuildRequestMessage(HttpMessage message)
        {
            if (!(message.Request is PipelineRequest pipelineRequest))
            {
                throw new InvalidOperationException("the request is not compatible with the transport");
            }
            return pipelineRequest.BuildRequestMessage(message.CancellationToken);
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out string? value)
        {
#if NET6_0_OR_GREATER
            if (headers.NonValidated.TryGetValues(name, out HeaderStringValues values) ||
                content is not null && content.Headers.NonValidated.TryGetValues(name, out values))
            {
                value = JoinHeaderValues(values);
                return true;
            }
#else
            if (TryGetHeader(headers, content, name, out IEnumerable<string>? values))
            {
                value = JoinHeaderValues(values);
                return true;
            }
#endif
            value = null;
            return false;
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
#if NET6_0_OR_GREATER
            if (headers.NonValidated.TryGetValues(name, out HeaderStringValues headerStringValues) ||
                content != null &&
                content.Headers.NonValidated.TryGetValues(name, out headerStringValues))
            {
                values = headerStringValues;
                return true;
            }

            values = null;
            return false;
#else
            return headers.TryGetValues(name, out values) ||
                   content != null &&
                   content.Headers.TryGetValues(name, out values);
#endif

        }

        internal static IEnumerable<HttpHeader> GetHeaders(HttpHeaders headers, HttpContent? content)
        {
#if NET6_0_OR_GREATER
            foreach (var (key, value) in headers.NonValidated)
            {
                yield return new HttpHeader(key, JoinHeaderValues(value));
            }

            if (content is not null)
            {
                foreach (var (key, value) in content.Headers.NonValidated)
                {
                    yield return new HttpHeader(key, JoinHeaderValues(value));
                }
            }
#else
            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
            }

            if (content != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
                {
                    yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
                }
            }
#endif

        }

        internal static bool RemoveHeader(HttpHeaders headers, HttpContent? content, string name)
        {
            // .Remove throws on invalid header name so use TryGet here to check
#if NET6_0_OR_GREATER
            if (headers.NonValidated.Contains(name) && headers.Remove(name))
            {
                return true;
            }

            return content is not null && content.Headers.NonValidated.Contains(name) && content.Headers.Remove(name);
#else
            if (headers.TryGetValues(name, out _) && headers.Remove(name))
            {
                return true;
            }

            return content?.Headers.TryGetValues(name, out _) == true && content.Headers.Remove(name);
#endif
        }

        internal static bool ContainsHeader(HttpHeaders headers, HttpContent? content, string name)
        {
            // .Contains throws on invalid header name so use TryGet here
#if NET6_0_OR_GREATER
            return headers.NonValidated.Contains(name) || content is not null && content.Headers.NonValidated.Contains(name);
#else
            if (headers.TryGetValues(name, out _))
            {
                return true;
            }

            return content?.Headers.TryGetValues(name, out _) == true;
#endif
        }

#if NET6_0_OR_GREATER
        private static string JoinHeaderValues(HeaderStringValues values)
        {
            return values.Count switch
            {
                0 => string.Empty,
                1 => values.ToString(),
                _ => string.Join(",", values)
            };
        }
#else
        private static string JoinHeaderValues(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }
#endif

        private sealed class PipelineRequest : Request
        {
            private string? _clientRequestId;
            private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;

            public PipelineRequest()
            {
                Method = RequestMethod.Get;
                _headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
            }

            public override string ClientRequestId
            {
                get => _clientRequestId ??= Guid.NewGuid().ToString();
                set
                {
                    Argument.AssertNotNull(value, nameof(value));
                    _clientRequestId = value;
                }
            }

            protected internal override void SetHeader(string name, string value)
            {
                _headers.Set(new IgnoreCaseString(name), value);
            }

            protected internal override void AddHeader(string name, string value)
            {
                if (_headers.TryAdd(new IgnoreCaseString(name), value, out var existingValue))
                {
                    return;
                }

                switch (existingValue)
                {
                    case string stringValue:
                        _headers.Set(new IgnoreCaseString(name), new List<string> { stringValue, value });
                        break;
                    case List<string> listValue:
                        listValue.Add(value);
                        break;
                }
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                if (_headers.TryGetValue(new IgnoreCaseString(name), out var headerValue))
                {
                    value = GetHttpHeaderValue(name, headerValue);
                    return true;
                }

                value = default;
                return false;
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                if (_headers.TryGetValue(new IgnoreCaseString(name), out var value))
                {
                    values = value switch
                    {
                        string headerValue => new[]{ headerValue },
                        List<string> headerValues => headerValues,
                        _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value.GetType()}")
                    };
                    return true;
                }

                values = default;
                return false;
            }

            protected internal override bool ContainsHeader(string name) => _headers.TryGetValue(new IgnoreCaseString(name), out _);

            protected internal override bool RemoveHeader(string name) => _headers.TryDelete(new IgnoreCaseString(name));

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                for (int i = 0; i < _headers.Count; i++)
                {
                    _headers.GetAt(i, out var headerName, out var headerValue);
                    yield return new HttpHeader(headerName, GetHttpHeaderValue(headerName, headerValue));
                }
            }

            public HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
            {
                var method = ToHttpClientMethod(Method);
                var uri = Uri.ToUri();
                var currentRequest = new HttpRequestMessage(method, uri);
                var currentContent = Content != null ? new PipelineContentAdapter(Content, cancellation) : null;
                currentRequest.Content = currentContent;
#if NETFRAMEWORK
                currentRequest.Headers.ExpectContinue = false;
#endif
                for (int i = 0; i < _headers.Count; i++)
                {
                    _headers.GetAt(i, out var headerName, out var value);
                    switch (value)
                    {
                        case string stringValue:
                            // Authorization is special cased because it is in the hot path for auth polices that set this header on each request and retry.
                            if (headerName == HttpHeader.Names.Authorization && AuthenticationHeaderValue.TryParse(stringValue, out var authHeader))
                            {
                                currentRequest.Headers.Authorization = authHeader;
                            }
                            else if (!currentRequest.Headers.TryAddWithoutValidation(headerName, stringValue))
                            {
                                if (currentContent != null && !currentContent.Headers.TryAddWithoutValidation(headerName, stringValue))
                                {
                                    throw new InvalidOperationException($"Unable to add header {headerName} to header collection.");
                                }
                            }
                            break;
                        case List<string> listValue:
                            if (!currentRequest.Headers.TryAddWithoutValidation(headerName, listValue))
                            {
                                if (currentContent != null && !currentContent.Headers.TryAddWithoutValidation(headerName, listValue))
                                {
                                    throw new InvalidOperationException($"Unable to add header {headerName} to header collection.");
                                }
                            }
                            break;
                    }
                }

                AddPropertiesForBlazor(currentRequest);

                return currentRequest;
            }

            private static void AddPropertiesForBlazor(HttpRequestMessage currentRequest)
            {
                // Disable response caching and enable streaming in Blazor apps
                // see https://github.com/dotnet/aspnetcore/blob/3143d9550014006080bb0def5b5c96608b025a13/src/Components/WebAssembly/WebAssembly/src/Http/WebAssemblyHttpRequestMessageExtensions.cs
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
                {
                    SetPropertiesOrOptions(currentRequest, "WebAssemblyFetchOptions", new Dictionary<string, object> { { "cache", "no-store" } });
                    SetPropertiesOrOptions(currentRequest, "WebAssemblyEnableStreamingResponse", true);
                }
            }

            private static string GetHttpHeaderValue(string headerName, object value) => value switch
            {
                string headerValue => headerValue,
                List<string> headerValues => string.Join(",", headerValues),
                _ => throw new InvalidOperationException($"Unexpected type for header {headerName}: {value.GetType()}")
            };

            public override void Dispose()
            {
                _headers.Dispose();
                Content?.Dispose();
            }

            public override string ToString() => BuildRequestMessage(default).ToString();

            private static readonly HttpMethod s_patch = new HttpMethod("PATCH");

            private static HttpMethod ToHttpClientMethod(RequestMethod requestMethod)
            {
                var method = requestMethod.Method;

                // Fast-path common values
                if (method.Length == 3)
                {
                    if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Get;
                    }

                    if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Put;
                    }
                }
                else if (method.Length == 4)
                {
                    if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Post;
                    }
                    if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Head;
                    }
                }
                else
                {
                    if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
                    {
                        return s_patch;
                    }
                    if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Delete;
                    }
                }

                return new HttpMethod(method);
            }

            private readonly struct IgnoreCaseString : IEquatable<IgnoreCaseString>
            {
                private readonly string _value;

                public IgnoreCaseString(string value)
                {
                    _value = value;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool Equals(IgnoreCaseString other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
                public override bool Equals(object? obj) => obj is IgnoreCaseString other && Equals(other);
                public override int GetHashCode() => _value.GetHashCode();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool operator ==(IgnoreCaseString left, IgnoreCaseString right) => left.Equals(right);
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool operator !=(IgnoreCaseString left, IgnoreCaseString right) => !left.Equals(right);
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static implicit operator string(IgnoreCaseString ics) => ics._value;
            }

            private sealed class PipelineContentAdapter : HttpContent
            {
                private readonly RequestContent _pipelineContent;
                private readonly CancellationToken _cancellationToken;

                public PipelineContentAdapter(RequestContent pipelineContent, CancellationToken cancellationToken)
                {
                    _pipelineContent = pipelineContent;
                    _cancellationToken = cancellationToken;
                }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context) => await _pipelineContent.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

                protected override bool TryComputeLength(out long length) => _pipelineContent.TryComputeLength(out length);

#if NET5_0_OR_GREATER
                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    await _pipelineContent!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
                }

                protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    _pipelineContent.WriteTo(stream, cancellationToken);
                }
#endif
            }
        }

        private sealed class PipelineResponse : Response
        {
            private readonly HttpResponseMessage _responseMessage;

            private readonly HttpContent _responseContent;

#pragma warning disable CA2213 // Content stream is intentionally not disposed
            private Stream? _contentStream;
#pragma warning restore CA2213

            public PipelineResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
                _contentStream = contentStream;
                _responseContent = _responseMessage.Content;
            }

            public override int Status => (int)_responseMessage.StatusCode;

            public override string ReasonPhrase => _responseMessage.ReasonPhrase ?? string.Empty;

            public override Stream? ContentStream
            {
                get => _contentStream;
                set
                {
                    // Make sure we don't dispose the content if the stream was replaced
                    _responseMessage.Content = null;

                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseContent, name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseContent, name, out values);

            protected internal override bool ContainsHeader(string name) => HttpClientTransport.ContainsHeader(_responseMessage.Headers, _responseContent, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => GetHeaders(_responseMessage.Headers, _responseContent);

            public override void Dispose()
            {
                _responseMessage?.Dispose();
                DisposeStreamIfNotBuffered(ref _contentStream);
            }

            public override string ToString() => _responseMessage.ToString();
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
