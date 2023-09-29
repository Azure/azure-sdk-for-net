// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class HttpClientTransportResponse : Response
        {
            private readonly HttpResponseMessage _responseMessage;
            private readonly HttpContent _responseContent;

#pragma warning disable CA2213 // Content stream is intentionally not disposed
            private Stream? _contentStream;
#pragma warning restore CA2213

            public HttpClientTransportResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
                _contentStream = contentStream;
                _responseContent = _responseMessage.Content;
            }

            public override int Status => (int)_responseMessage.StatusCode;

            public override string ReasonPhrase => _responseMessage.ReasonPhrase ?? string.Empty;

            public override Stream? ContentStream
            {
                get => _contentStream;
                set
                {
                    // Make sure we don't dispose the content if the stream was replaced
                    _responseMessage.Content = null;

                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => TryGetHeader(_responseMessage.Headers, _responseContent, name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => TryGetHeader(_responseMessage.Headers, _responseContent, name, out values);

            protected internal override bool ContainsHeader(string name)
                => ContainsHeader(_responseMessage.Headers, _responseContent, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
                => GetHeaders(_responseMessage.Headers, _responseContent);

            private static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out string? value)
            {
#if NET6_0_OR_GREATER
            if (headers.NonValidated.TryGetValues(name, out HeaderStringValues values) ||
                content is not null && content.Headers.NonValidated.TryGetValues(name, out values))
            {
                value = JoinHeaderValues(values);
                return true;
            }
#else
                if (TryGetHeader(headers, content, name, out IEnumerable<string>? values))
                {
                    value = JoinHeaderValues(values);
                    return true;
                }
#endif
                value = null;
                return false;
            }

            private static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
#if NET6_0_OR_GREATER
            if (headers.NonValidated.TryGetValues(name, out HeaderStringValues headerStringValues) ||
                content != null &&
                content.Headers.NonValidated.TryGetValues(name, out headerStringValues))
            {
                values = headerStringValues;
                return true;
            }

            values = null;
            return false;
#else
                return headers.TryGetValues(name, out values) ||
                       content != null &&
                       content.Headers.TryGetValues(name, out values);
#endif

            }

#if NET6_0_OR_GREATER
        private static string JoinHeaderValues(HeaderStringValues values)
        {
            var count = values.Count;
            if (count == 0)
            {
                return string.Empty;
            }

            // Special case when HeaderStringValues.Count == 1, because HttpHeaders also special cases it and creates HeaderStringValues instance from a single string
            // https://github.com/dotnet/runtime/blob/ef5e27eacecf34a36d72a8feb9082f408779675a/src/libraries/System.Net.Http/src/System/Net/Http/Headers/HttpHeadersNonValidated.cs#L150
            // https://github.com/dotnet/runtime/blob/ef5e27eacecf34a36d72a8feb9082f408779675a/src/libraries/System.Net.Http/src/System/Net/Http/Headers/HttpHeaders.cs#L1105
            // Which is later used in HeaderStringValues.ToString:
            // https://github.com/dotnet/runtime/blob/729bf92e6e2f91aa337da9459bef079b14a0bf34/src/libraries/System.Net.Http/src/System/Net/Http/Headers/HeaderStringValues.cs#L47
            if (count == 1)
            {
                return values.ToString();
            }

            // While HeaderStringValueToStringVsEnumerator performance test shows that `HeaderStringValues.ToString` is faster than DefaultInterpolatedStringHandler,
            // we can't use it here because it uses ", " as default separator and doesn't allow customization.
            var interpolatedStringHandler = new DefaultInterpolatedStringHandler(count-1, count);
            var isFirst = true;
            foreach (var str in values)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    interpolatedStringHandler.AppendLiteral(",");
                }
                interpolatedStringHandler.AppendFormatted(str);
            }
            return string.Create(null, ref interpolatedStringHandler);
        }
#else
            private static string JoinHeaderValues(IEnumerable<string> values)
            {
                return string.Join(",", values);
            }
#endif
            private static bool ContainsHeader(HttpHeaders headers, HttpContent? content, string name)
            {
                // .Contains throws on invalid header name so use TryGet here
#if NET6_0_OR_GREATER
            return headers.NonValidated.Contains(name) || content is not null && content.Headers.NonValidated.Contains(name);
#else
                if (headers.TryGetValues(name, out _))
                {
                    return true;
                }

                return content?.Headers.TryGetValues(name, out _) == true;
#endif
            }

            private static IEnumerable<HttpHeader> GetHeaders(HttpHeaders headers, HttpContent? content)
            {
#if NET6_0_OR_GREATER
            foreach (var (key, value) in headers.NonValidated)
            {
                yield return new HttpHeader(key, JoinHeaderValues(value));
            }

            if (content is not null)
            {
                foreach (var (key, value) in content.Headers.NonValidated)
                {
                    yield return new HttpHeader(key, JoinHeaderValues(value));
                }
            }
#else
                foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
                {
                    yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
                }

                if (content != null)
                {
                    foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
                    {
                        yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
                    }
                }
#endif

            }

            public override void Dispose()
            {
                _responseMessage?.Dispose();
                DisposeStreamIfNotBuffered(ref _contentStream);

                base.Dispose();
            }

            public override string ToString() => _responseMessage.ToString();
        }
    }
}
