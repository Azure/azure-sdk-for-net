// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;

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
        }
    }
}
