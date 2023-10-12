// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.ServiceModel.Rest.Core.Pipeline;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        // TODO: is there a way to still do this with this private?  Come back to this.
        internal sealed class HttpClientTransportRequest : HttpPipelineRequest
        {
            private RequestUriBuilder? _uriBuilder;

            public override Uri Uri
            {
                get
                {
                    if (_uriBuilder is null)
                    {
                        throw new InvalidOperationException("RequestUriBuilder has not been initialized; please call SetUriBuilder()");
                    }

                    return _uriBuilder.ToUri();
                }
                set
                {
                    if (_uriBuilder is null)
                    {
                        throw new InvalidOperationException("RequestUriBuilder has not been initialized; please call SetUriBuilder()");
                    }

                    _uriBuilder.Reset(value);
                }
            }

            public RequestUriBuilder UriBuilder
            {
                get => _uriBuilder ??= new RequestUriBuilder();
                set
                {
                    Argument.AssertNotNull(value, nameof(value));
                    _uriBuilder = value;
                }
            }

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
