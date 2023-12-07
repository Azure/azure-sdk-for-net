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
            // In this implementation of the abstract Azure.Core.Request type,
            // we have two fields for each of the public properties -- one on the
            // Request implementation and one in the PipelineRequest implementation.
            // The implication of this is that we need to keep both sets of fields
            // in sync with each other when they are set from either property on
            // Request or PipelineRequest.

            private readonly PipelineRequest _pipelineRequest;

            public HttpClientTransportRequest(PipelineRequest request)
            {
                _pipelineRequest = request;

                // Initialize duplicated properties on base type from adapted request.
                base.SetMethodCore(request.Method);

                // Uri and Content are initialized to null in constructor
                // so don't need to be set here.
            }

            #region Adapt PipelineResponse to inherit functional implementation from ClientModel

            protected override string GetMethodCore()
                => _pipelineRequest.Method;

            protected override void SetMethodCore(string method)
            {
                // Update fields on both Request and PipelineRequest.
                base.SetMethodCore(method);
                _pipelineRequest.Method = method;
            }

            protected override Uri GetUriCore()
            {
                Uri uri = Uri.ToUri();

                // Lazily update the value on the adapted PipelineRequest.
                SetUriCore(uri);

                return uri;
            }

            protected override void SetUriCore(Uri uri)
            {
                // Update fields on both Request and PipelineRequest.
                base.SetUriCore(uri);
                _pipelineRequest.Uri = uri;
            }

            protected override InputContent? GetContentCore()
                => _pipelineRequest.Content;

            protected override void SetContentCore(InputContent? content)
            {
                // Update Content fields on both Request and PipelineRequest.
                base.SetContentCore(content);
                _pipelineRequest.Content = content;
            }

            protected override MessageHeaders GetHeadersCore()
                => _pipelineRequest.Headers;

            #endregion

            #region Implement Azure.Core Request abstract methods

            protected internal override void AddHeader(string name, string value)
                => _pipelineRequest.Headers.Add(name, value);

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => _pipelineRequest.Headers.TryGetValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => _pipelineRequest.Headers.TryGetValues(name, out values);

            protected internal override bool ContainsHeader(string name)
                => _pipelineRequest.Headers.TryGetValue(name, out _);

            protected internal override bool RemoveHeader(string name)
                => _pipelineRequest.Headers.Remove(name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                // TODO: revisit for perf
                foreach (KeyValuePair<string, IEnumerable<string>> header in _pipelineRequest.Headers)
                {
                    yield return new HttpHeader(header.Key, string.Join(",", header.Value));
                }
            }

            #endregion

            #region Azure.Core extensions of ClientModel functionality

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

            #endregion

            public override void Dispose()
                => _pipelineRequest.Dispose();
        }
    }
}
