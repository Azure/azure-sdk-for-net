// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class HttpClientTransportRequest : Request
        {
            private const string MessageForServerCertificateCallback = "MessageForServerCertificateCallback";

            private string? _clientRequestId;

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
                TryGetHeaderNames(out IEnumerable<string> headerNames);
                foreach (string name in headerNames)
                {
                    if (!TryGetHeader(name, out string? value))
                    {
                        throw new InvalidOperationException("Enumerator returned a header name that was not present in the collection.");
                    }

                    yield return new HttpHeader(name, value!);
                }
            }

            protected override void OnSending(PipelineMessage message, HttpRequestMessage httpRequest)
            {
                if (message is not HttpMessage httpMessage)
                {
                    throw new InvalidOperationException($"Unsupported message type: '{message?.GetType()}'.");
                }

                SetPropertiesOrOptions(httpRequest, MessageForServerCertificateCallback, httpMessage);

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
