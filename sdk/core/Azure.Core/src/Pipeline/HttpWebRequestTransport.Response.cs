// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;

namespace Azure.Core.Pipeline
{
#if NETFRAMEWORK
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    internal partial class HttpWebRequestTransport : HttpPipelineTransport
    {
        private sealed class HttpWebRequestTransportResponse : Response
        {
            private readonly HttpWebResponse _webResponse;
            private Stream? _contentStream;
            private Stream? _originalContentStream;

            public HttpWebRequestTransportResponse(string clientRequestId, HttpWebResponse webResponse)
            {
                _webResponse = webResponse;
                _originalContentStream = _webResponse.GetResponseStream();
                _contentStream = _originalContentStream;
                ClientRequestId = clientRequestId;
            }

            public override int Status => (int)_webResponse.StatusCode;

            public override string ReasonPhrase => _webResponse.StatusDescription;

            public override Stream? ContentStream
            {
                get => _contentStream;
                set
                {
                    // Make sure we don't dispose the content if the stream was replaced
                    _originalContentStream = null;

                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            public override void Dispose()
            {
                // In the case of failed response the content stream would be
                // pre-buffered subclass of MemoryStream
                // keep it alive because the ResponseBodyPolicy won't re-buffer it
                DisposeStreamIfNotBuffered(ref _originalContentStream);
                DisposeStreamIfNotBuffered(ref _contentStream);
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                value = _webResponse.Headers.Get(name);
                return value != null;
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                values = _webResponse.Headers.GetValues(name);
                return values != null;
            }

            protected internal override bool ContainsHeader(string name)
            {
                return _webResponse.Headers.Get(name) != null;
            }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (var key in _webResponse.Headers.AllKeys)
                {
                    yield return new HttpHeader(key, _webResponse.Headers.Get(key));
                }
            }
        }
    }
#endif
}
