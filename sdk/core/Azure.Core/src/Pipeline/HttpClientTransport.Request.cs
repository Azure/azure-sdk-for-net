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
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        /// <summary>
        /// This is a transport-specific implementation of <see cref="Request"/>.
        ///
        /// It uses the System.ClientModel HttpClient-based transport
        /// implementation <see cref="HttpClientPipelineTransport"/> and adapts
        /// that transport's private nested HttpClientPipelineTransportRequest
        /// type to the Azure.Core <see cref="Request"/> interface so that it
        /// can reuse the ClientModel implementation but treat it as an
        /// Azure.Core Request in Azure.Core-based clients.
        /// </summary>
        private sealed class HttpClientTransportRequest : Request
        {
            // In this implementation of the abstract Azure.Core.Request type,
            // ther are two fields for each of the public properties -- one on
            // the base Request implementation and one in the adapted
            // PipelineRequest implementation. Because of this, the
            // implementation of this type is a bit complex in that we must
            // keep both sets of fields in sync with each other when they are
            // set from either property on Request or PipelineRequest, so they
            // will have the same value regardless of whether they are accessed
            // from the instance as a Azure.Core Request or as a
            // System.ClientModel PipelineRequest.

            private readonly PipelineRequest _pipelineRequest;
            private string? _clientRequestId;

            public HttpClientTransportRequest(PipelineRequest request)
            {
                _pipelineRequest = request;

                // Initialize duplicated fields on the base instance
                // from the adapted request instance.
                base.MethodCore = request.Method;
                base.ContentCore = request.Content;

                if (request.Uri is not null)
                {
                    base.UriCore = request.Uri;
                }
            }

            #region Implement Azure.Core Request abstract methods

            public override string ClientRequestId
            {
                get => _clientRequestId ??= Guid.NewGuid().ToString();
                set
                {
                    Argument.AssertNotNull(value, nameof(value));
                    _clientRequestId = value;
                }
            }

            protected internal override void AddHeader(string name, string value)
                => _pipelineRequest.Headers.Add(name, value);

            protected internal override bool ContainsHeader(string name)
                => _pipelineRequest.Headers.TryGetValue(name, out _);

            protected internal override bool RemoveHeader(string name)
                => _pipelineRequest.Headers.Remove(name);

            protected internal override void SetHeader(string name, string value)
                => _pipelineRequest.Headers.Set(name, value);

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => _pipelineRequest.Headers.TryGetValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => _pipelineRequest.Headers.TryGetValues(name, out values);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (KeyValuePair<string, string> header in _pipelineRequest.Headers)
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }

            #endregion

            #region Overrides for "Core" methods from the PipelineRequest Template pattern

            protected override string MethodCore
            {
                get => _pipelineRequest.Method;
                set
                {
                    // Update fields on both Request and PipelineRequest.
                    base.MethodCore = value;
                    _pipelineRequest.Method = value;
                }
            }

            protected override Uri? UriCore
            {
                get
                {
                    Uri uri = Uri.ToUri();

                    // Lazily update the value on the adapted PipelineRequest.
                    UriCore = uri;

                    return uri;
                }

                set
                {
                    // Update fields on both Request and PipelineRequest.
                    base.UriCore = value;
                    _pipelineRequest.Uri = value;
                }
            }

            protected override PipelineRequestHeaders HeadersCore
                => _pipelineRequest.Headers;

            protected override BinaryContent? ContentCore
            {
                get => _pipelineRequest.Content;
                set
                {
                    // Update Content fields on both Request and PipelineRequest.
                    base.ContentCore = value;
                    _pipelineRequest.Content = value;
                }
            }

            #endregion

            #region Azure.Core extensions of ClientModel HttpClientPipelineTransportRequest functionality

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
