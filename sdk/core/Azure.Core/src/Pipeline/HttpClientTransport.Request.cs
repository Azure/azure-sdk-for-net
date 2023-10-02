// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ServiceModel.Rest.Experimental;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class HttpClientTransportRequest : Request
        {
            private string? _clientRequestId;

            public HttpClientTransportRequest()
            {
                Method = RequestMethod.Get;
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

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (var name in GetHeaderNames())
                {
                    if (!TryGetHeader(name, out string? value))
                    {
                        throw new InvalidOperationException("Why?");
                    }

                    yield return new HttpHeader(name, value);
                }
            }

            internal HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
            {
                HttpMethod method = ToHttpClientMethod(Method);
                Uri uri = Uri.ToUri();
                HttpRequestMessage currentRequest = new HttpRequestMessage(method, uri);
                PipelineContentAdapter? currentContent = Content != null ? new PipelineContentAdapter(Content, cancellation) : null;
                currentRequest.Content = currentContent;
#if NETFRAMEWORK
                currentRequest.Headers.ExpectContinue = false;
#endif
                for (int i = 0; i < _headers.Count; i++)
                {
                    _headers.GetAt(i, out IgnoreCaseString headerName, out object value);

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

            public override void Dispose()
            {
                _headers.Dispose();
                var content = Content;
                if (content != null)
                {
                    Content = null;
                    content.Dispose();
                }
            }

            public override string ToString() => BuildRequestMessage(default).ToString();

            private sealed class PipelineContentAdapter : HttpContent
            {
                private readonly RequestContent _pipelineContent;
                private readonly CancellationToken _cancellationToken;

                public PipelineContentAdapter(RequestContent pipelineContent, CancellationToken cancellationToken)
                {
                    _pipelineContent = pipelineContent;
                    _cancellationToken = cancellationToken;
                }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
                    => await _pipelineContent.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

                protected override bool TryComputeLength(out long length)
                    => _pipelineContent.TryComputeLength(out length);

#if NET5_0_OR_GREATER
                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                    => await _pipelineContent!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

                protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                    => _pipelineContent.WriteTo(stream, cancellationToken);
#endif
            }
        }
    }
}
