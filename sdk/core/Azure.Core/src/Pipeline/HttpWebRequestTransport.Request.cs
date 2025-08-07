// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Azure.Core.Pipeline
{
#if NETFRAMEWORK
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    internal partial class HttpWebRequestTransport : HttpPipelineTransport
    {
        private sealed class HttpWebRequestTransportRequest : Request
        {
            public HttpWebRequestTransportRequest()
            {
                Method = RequestMethod.Get;
            }

            private string? _clientRequestId;
            private readonly DictionaryHeaders _headers = new();

            protected internal override void SetHeader(string name, string value) => _headers.SetHeader(name, value);

            protected internal override void AddHeader(string name, string value) => _headers.AddHeader(name, value);

            protected internal override bool TryGetHeader(string name, out string value) => _headers.TryGetHeader(name, out value);

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => _headers.TryGetHeaderValues(name, out values);

            protected internal override bool ContainsHeader(string name) => _headers.TryGetHeaderValues(name, out _);

            protected internal override bool RemoveHeader(string name) => _headers.RemoveHeader(name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.EnumerateHeaders();

            public override string ClientRequestId
            {
                get => _clientRequestId ??= Guid.NewGuid().ToString();
                set
                {
                    Argument.AssertNotNull(value, nameof(value));
                    _clientRequestId = value;
                }
            }

            public override RequestContent? Content { get; set; }

            public override void Dispose()
            {
                var content = Content;
                if (content != null)
                {
                    Content = null;
                    content.Dispose();
                }
            }
        }

        private HttpWebRequest CreateRequest(Request messageRequest)
        {
            var request = WebRequest.CreateHttp(messageRequest.Uri.ToUri());

            // Timeouts are handled by the pipeline
            request.Timeout = Timeout.Infinite;
            request.ReadWriteTimeout = Timeout.Infinite;

            // Redirect is handled by the pipeline
            request.AllowAutoRedirect = false;

            // Don't disable the default proxy when there is no environment proxy configured
            if (_environmentProxy != null)
            {
                request.Proxy = _environmentProxy;
            }

            request.ServicePoint.Expect100Continue = false;

            _configureRequest(request);

            request.Method = messageRequest.Method.Method;
            foreach (var messageRequestHeader in messageRequest.Headers)
            {
                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.ContentLength, StringComparison.OrdinalIgnoreCase))
                {
                    request.ContentLength = long.Parse(messageRequestHeader.Value, CultureInfo.InvariantCulture);
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Host, StringComparison.OrdinalIgnoreCase))
                {
                    request.Host = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Date, StringComparison.OrdinalIgnoreCase))
                {
                    request.Date = DateTime.Parse(messageRequestHeader.Value, CultureInfo.InvariantCulture);
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.ContentType, StringComparison.OrdinalIgnoreCase))
                {
                    request.ContentType = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.UserAgent, StringComparison.OrdinalIgnoreCase))
                {
                    request.UserAgent = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Accept, StringComparison.OrdinalIgnoreCase))
                {
                    request.Accept = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Referer, StringComparison.OrdinalIgnoreCase))
                {
                    request.Referer = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.IfModifiedSince, StringComparison.OrdinalIgnoreCase))
                {
                    request.IfModifiedSince = DateTime.Parse(messageRequestHeader.Value, CultureInfo.InvariantCulture);
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, "Expect", StringComparison.OrdinalIgnoreCase))
                {
                    if (messageRequestHeader.Value == "100-continue")
                    {
                        request.ServicePoint.Expect100Continue = true;
                    }
                    else
                    {
                        request.Expect = messageRequestHeader.Value;
                    }
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
                {
                    request.TransferEncoding = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Range, StringComparison.OrdinalIgnoreCase))
                {
                    var value = RangeHeaderValue.Parse(messageRequestHeader.Value);
                    if (value.Unit != "bytes")
                    {
                        throw new InvalidOperationException("Only ranges with bytes unit supported.");
                    }

                    foreach (var rangeItem in value.Ranges)
                    {
                        if (rangeItem.From == null)
                        {
                            throw new InvalidOperationException("Only ranges with Offset supported.");
                        }

                        if (rangeItem.To == null)
                        {
                            request.AddRange(rangeItem.From.Value);
                        }
                        else
                        {
                            request.AddRange(rangeItem.From.Value, rangeItem.To.Value);
                        }
                    }
                    continue;
                }

                request.Headers.Add(messageRequestHeader.Name, messageRequestHeader.Value);
            }

            if (request.ContentLength == -1 &&
                messageRequest.Content != null &&
                messageRequest.Content.TryComputeLength(out var length))
            {
                request.ContentLength = length;
            }

            if (request.ContentLength != -1)
            {
                // disable buffering when the content length is known
                // as the content stream is re-playable and we don't want to allocate extra buffers
                request.AllowWriteStreamBuffering = false;
            }
            return request;
        }

        private static void ApplyOptionsToRequest(HttpWebRequest request, HttpPipelineTransportOptions options)
        {
            if (options == null)
            {
                return;
            }

            // ServerCertificateCustomValidationCallback
            if (options.ServerCertificateCustomValidationCallback != null)
            {
                request.ServerCertificateValidationCallback =
                    (request, certificate, x509Chain, sslPolicyErrors) => options.ServerCertificateCustomValidationCallback(
                        new ServerCertificateCustomValidationArgs(
                            new X509Certificate2(certificate),
                            x509Chain,
                            sslPolicyErrors));
            }
            // Set ClientCertificates
            foreach (var cert in options.ClientCertificates)
            {
                request.ClientCertificates.Add(cert);
            }
        }
    }
#endif
}
