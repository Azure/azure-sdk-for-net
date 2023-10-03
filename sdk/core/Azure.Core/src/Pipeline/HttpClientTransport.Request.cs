// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel.Rest.Core.Pipeline;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class RestRequestAdapter : Request
        {
            private HttpPipelineRequest _request;
            private string? _clientRequestId;

            public RestRequestAdapter(HttpPipelineRequest request)
            {
                _request = request;
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

        //private sealed class HttpClientTransportRequest : Request
        //{
        //    private string? _clientRequestId;

        //    public HttpClientTransportRequest()
        //    {
        //        Method = RequestMethod.Get;
        //    }

        //    public override string ClientRequestId
        //    {
        //        get => _clientRequestId ??= Guid.NewGuid().ToString();
        //        set
        //        {
        //            Argument.AssertNotNull(value, nameof(value));
        //            _clientRequestId = value;
        //        }
        //    }

        //    protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
        //    {
        //        foreach (var name in GetHeaderNames())
        //        {
        //            if (!TryGetHeader(name, out string? value))
        //            {
        //                throw new InvalidOperationException("Why?");
        //            }

        //            yield return new HttpHeader(name, value!);
        //        }
        //    }

        //    private static readonly HttpMethod s_patch = new HttpMethod("PATCH");
        //    private static HttpMethod ToHttpClientMethod(RequestMethod requestMethod)
        //    {
        //        var method = requestMethod.Method;

        //        // Fast-path common values
        //        if (method.Length == 3)
        //        {
        //            if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return HttpMethod.Get;
        //            }

        //            if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return HttpMethod.Put;
        //            }
        //        }
        //        else if (method.Length == 4)
        //        {
        //            if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return HttpMethod.Post;
        //            }
        //            if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return HttpMethod.Head;
        //            }
        //        }
        //        else
        //        {
        //            if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return s_patch;
        //            }
        //            if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return HttpMethod.Delete;
        //            }
        //        }

        //        return new HttpMethod(method);
        //    }
        //}
    }
}
