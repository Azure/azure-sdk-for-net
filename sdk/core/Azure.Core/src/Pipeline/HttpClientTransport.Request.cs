// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class HttpClientTransportRequest : Request
        {
            private readonly PipelineRequest _request;

            public HttpClientTransportRequest(PipelineRequest request)
            {
                _request = request;
            }

            public override RequestMethod Method
            {
                get => RequestMethod.Parse(_request.Method);
                set => _request.Method = value.Method;
            }

            public override RequestContent? Content
            {
                get => (RequestContent?)_request.Content;
                set => _request.Content = value;
            }

            public override void Dispose() => _request.Dispose();

            protected internal override void AddHeader(string name, string value)
                => _request.Headers.Add(name, value);

            protected internal override bool ContainsHeader(string name)
                => _request.Headers.TryGetValue(name, out _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                _request.Headers.TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);
                foreach (KeyValuePair<string, string> header in headers)
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }

            protected internal override bool RemoveHeader(string name)
                => _request.Headers.Remove(name);

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => _request.Headers.TryGetValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => _request.Headers.TryGetValues(name, out values);

            private const string MessageForServerCertificateCallback = "MessageForServerCertificateCallback";

            internal static void AddAzureProperties(HttpMessage message, HttpRequestMessage httpRequest)
            {
                SetPropertiesOrOptions(httpRequest, MessageForServerCertificateCallback, message);

                AddPropertiesForBlazor(httpRequest);
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

            private static void SetPropertiesOrOptions<T>(HttpRequestMessage httpRequest, string name, T value)
            {
#if NET5_0_OR_GREATER
                httpRequest.Options.Set(new HttpRequestOptionsKey<T>(name), value);
#else
                httpRequest.Properties[name] = value;
#endif
            }
        }
    }
}
