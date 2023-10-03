// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class HttpClientTransportResponse : Response
        {
            public HttpClientTransportResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
                : base(responseMessage, contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
            }

            public override string ClientRequestId { get; set; }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (string name in GetHeaderNames())
                {
                    if (!TryGetHeader(name, out string? value))
                    {
                        throw new InvalidOperationException("Why?");
                    }

                    yield return new HttpHeader(name, value!);
                }
            }
        }
    }
}
