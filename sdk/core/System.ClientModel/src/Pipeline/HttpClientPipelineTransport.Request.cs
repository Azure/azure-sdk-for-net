// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class HttpClientPipelineTransport
{
    private class HttpPipelineRequest : PipelineRequest
    {
        private const string AuthorizationHeaderName = "Authorization";

        private string _method;
        private Uri? _uri;
        private BinaryContent? _content;

        private readonly PipelineRequestHeaders _headers;

        private bool _disposed;

        protected internal HttpPipelineRequest()
        {
            _method = HttpMethod.Get.Method;
            _headers = new ArrayBackedRequestHeaders();
        }

        protected override string MethodCore
        {
            get => _method;
            set
            {
                Argument.AssertNotNull(value, nameof(value));

                _method = value;
            }
        }

        protected override Uri? UriCore
        {
            get => _uri;
            set
            {
                Argument.AssertNotNull(value, nameof(value));

                _uri = value;
            }
        }

        protected override BinaryContent? ContentCore
        {
            get => _content;
            set => _content = value;
        }

        protected override PipelineRequestHeaders HeadersCore => _headers;

        // PATCH value needed for compat with pre-net5.0 TFMs
        private static readonly HttpMethod _patchMethod = new HttpMethod("PATCH");

        private static HttpMethod ToHttpMethod(string method)
        {
            return method switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "HEAD" => HttpMethod.Head,
                "DELETE" => HttpMethod.Delete,
                "PATCH" => _patchMethod,
                _ => new HttpMethod(method),
            };
        }

        internal static HttpRequestMessage BuildHttpRequestMessage(PipelineRequest request, CancellationToken cancellationToken)
        {
            if (request.Uri is null)
            {
                throw new InvalidOperationException("Uri must be set on message request prior to sending message.");
            }

            HttpMethod method = ToHttpMethod(request.Method);
            Uri uri = request.Uri;
            HttpRequestMessage httpRequest = new HttpRequestMessage(method, uri);

            MessageBodyAdapter? httpContent = request.Content == null ? null :
                new MessageBodyAdapter(request.Content, cancellationToken);
            httpRequest.Content = httpContent;
#if NETSTANDARD
            httpRequest.Headers.ExpectContinue = false;
#endif

            if (request.Headers is not ArrayBackedRequestHeaders headers)
            {
                throw new InvalidOperationException($"Invalid type for request.Headers: '{request.Headers?.GetType()}'.");
            }

            int i = 0;
            while (headers.GetNextValue(i++, out string headerName, out object headerValue))
            {
                switch (headerValue)
                {
                    case string stringValue:
                        // Authorization is special cased because it is in the hot path for auth polices that set this header on each request and retry.
                        if (headerName == AuthorizationHeaderName && AuthenticationHeaderValue.TryParse(stringValue, out var authHeader))
                        {
                            httpRequest.Headers.Authorization = authHeader;
                        }
                        else if (!httpRequest.Headers.TryAddWithoutValidation(headerName, stringValue))
                        {
                            if (httpContent != null && !httpContent.Headers.TryAddWithoutValidation(headerName, stringValue))
                            {
                                throw new InvalidOperationException($"Unable to add header {headerName} to header collection.");
                            }
                        }
                        break;

                    case List<string> listValue:
                        if (!httpRequest.Headers.TryAddWithoutValidation(headerName, listValue))
                        {
                            if (httpContent != null && !httpContent.Headers.TryAddWithoutValidation(headerName, listValue))
                            {
                                throw new InvalidOperationException($"Unable to add header {headerName} to header collection.");
                            }
                        }
                        break;
                }
            }

            return httpRequest;
        }

        private sealed class MessageBodyAdapter : HttpContent
        {
            private readonly BinaryContent _content;
            private readonly CancellationToken _cancellationToken;

            public MessageBodyAdapter(BinaryContent content, CancellationToken cancellationToken)
            {
                Argument.AssertNotNull(content, nameof(content));

                _content = content;
                _cancellationToken = cancellationToken;
            }

            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
                => await _content.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

            protected override bool TryComputeLength(out long length)
                => _content.TryComputeLength(out length);

#if NET6_0_OR_GREATER
            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                => await _content!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

            protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                => _content.WriteTo(stream, cancellationToken);
#endif
        }

        public override string ToString() => BuildHttpRequestMessage(this, default).ToString();

        public sealed override void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                var content = _content;
                if (content != null)
                {
                    _content = null;
                    content.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
