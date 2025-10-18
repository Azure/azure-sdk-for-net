// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

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
            private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;

            public HttpClientTransportRequest()
            {
                Method = RequestMethod.Get;
                _headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
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

            protected internal override void SetHeader(string name, string value)
            {
                _headers.Set(new IgnoreCaseString(name), value);
            }

            protected internal override void AddHeader(string name, string value)
            {
                if (_headers.TryAdd(new IgnoreCaseString(name), value, out var existingValue))
                {
                    return;
                }

                switch (existingValue)
                {
                    case string stringValue:
                        _headers.Set(new IgnoreCaseString(name), new List<string> { stringValue, value });
                        break;
                    case List<string> listValue:
                        listValue.Add(value);
                        break;
                }
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                if (_headers.TryGetValue(new IgnoreCaseString(name), out var headerValue))
                {
                    value = GetHttpHeaderValue(name, headerValue);
                    return true;
                }

                value = default;
                return false;
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                if (_headers.TryGetValue(new IgnoreCaseString(name), out var value))
                {
                    values = value switch
                    {
                        string headerValue => new[] { headerValue },
                        List<string> headerValues => headerValues,
                        _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value.GetType()}")
                    };
                    return true;
                }

                values = default;
                return false;
            }

            protected internal override bool ContainsHeader(string name) => _headers.TryGetValue(new IgnoreCaseString(name), out _);

            protected internal override bool RemoveHeader(string name) => _headers.TryRemove(new IgnoreCaseString(name));

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                for (int i = 0; i < _headers.Count; i++)
                {
                    _headers.GetAt(i, out var headerName, out var headerValue);
                    yield return new HttpHeader(headerName, GetHttpHeaderValue(headerName, headerValue));
                }
            }

            public HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
            {
                var method = ToHttpClientMethod(Method);
                var uri = Uri.ToUri();
                var currentRequest = new HttpRequestMessage(method, uri);
                var currentContent = Content != null ? new PipelineContentAdapter(Content, cancellation) : null;
                currentRequest.Content = currentContent;
#if NETFRAMEWORK
                currentRequest.Headers.ExpectContinue = false;
#endif
                for (int i = 0; i < _headers.Count; i++)
                {
                    _headers.GetAt(i, out var headerName, out var value);
                    switch (value)
                    {
                        case string stringValue:
                            // Authorization is special cased because it is in the hot path for auth polices that set this header on each request and retry.
                            if (headerName == HttpHeader.Names.Authorization && AuthenticationHeaderValue.TryParse(stringValue, out var authHeader))
                            {
                                currentRequest.Headers.Authorization = authHeader;
                            }
                            else if (!currentRequest.Headers.TryAddWithoutValidation(headerName, stringValue))
                            {
                                if (currentContent != null && !currentContent.Headers.TryAddWithoutValidation(headerName, stringValue))
                                {
                                    throw new InvalidOperationException($"Unable to add header {headerName} to header collection.");
                                }
                            }
                            break;
                        case List<string> listValue:
                            if (!currentRequest.Headers.TryAddWithoutValidation(headerName, listValue))
                            {
                                if (currentContent != null && !currentContent.Headers.TryAddWithoutValidation(headerName, listValue))
                                {
                                    throw new InvalidOperationException($"Unable to add header {headerName} to header collection.");
                                }
                            }
                            break;
                    }
                }

                AddPropertiesForBlazor(currentRequest);

                return currentRequest;
            }

            private static void AddPropertiesForBlazor(HttpRequestMessage currentRequest)
            {
                // Disable response caching and enable streaming in Blazor apps
                // see https://github.com/dotnet/aspnetcore/blob/3143d9550014006080bb0def5b5c96608b025a13/src/Components/WebAssembly/WebAssembly/src/Http/WebAssemblyHttpRequestMessageExtensions.cs
                #if NET8_0_OR_GREATER
                if (OperatingSystem.IsBrowser())
                #else
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
                #endif
                {
                    SetPropertiesOrOptions(currentRequest, "WebAssemblyFetchOptions", new Dictionary<string, object> { { "cache", "no-store" } });
                    SetPropertiesOrOptions(currentRequest, "WebAssemblyEnableStreamingResponse", true);
                }
            }

            private static string GetHttpHeaderValue(string headerName, object value) => value switch
            {
                string headerValue => headerValue,
                List<string> headerValues => string.Join(",", headerValues),
                _ => throw new InvalidOperationException($"Unexpected type for header {headerName}: {value?.GetType()}")
            };

            public override void Dispose()
            {
                _headers.Dispose();
                var content = Content;
                if (content != null)
                {
                    Content = null;
                    content.Dispose();
                }
            }

            public override string ToString() => BuildRequestMessage(default).ToString();

            private static readonly HttpMethod s_patch = new HttpMethod("PATCH");

            private static HttpMethod ToHttpClientMethod(RequestMethod requestMethod)
            {
                var method = requestMethod.Method;

                // Fast-path common values
                if (method.Length == 3)
                {
                    if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Get;
                    }

                    if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Put;
                    }
                }
                else if (method.Length == 4)
                {
                    if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Post;
                    }
                    if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Head;
                    }
                }
                else
                {
                    if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
                    {
                        return s_patch;
                    }
                    if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Delete;
                    }
                }

                return new HttpMethod(method);
            }

            private readonly struct IgnoreCaseString : IEquatable<IgnoreCaseString>
            {
                private readonly string _value;

                public IgnoreCaseString(string value)
                {
                    _value = value;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool Equals(IgnoreCaseString other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
                public override bool Equals(object? obj) => obj is IgnoreCaseString other && Equals(other);
                public override int GetHashCode() => _value.GetHashCode();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool operator ==(IgnoreCaseString left, IgnoreCaseString right) => left.Equals(right);
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool operator !=(IgnoreCaseString left, IgnoreCaseString right) => !left.Equals(right);
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static implicit operator string(IgnoreCaseString ics) => ics._value;
            }

            private sealed class PipelineContentAdapter : HttpContent
            {
                private readonly RequestContent _pipelineContent;
                private readonly CancellationToken _cancellationToken;

                public PipelineContentAdapter(RequestContent pipelineContent, CancellationToken cancellationToken)
                {
                    _pipelineContent = pipelineContent;
                    _cancellationToken = cancellationToken;
                }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context) => await _pipelineContent.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

                protected override bool TryComputeLength(out long length) => _pipelineContent.TryComputeLength(out length);

#if NET5_0_OR_GREATER
                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    await _pipelineContent!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
                }

                protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    _pipelineContent.WriteTo(stream, cancellationToken);
                }
#endif
            }
        }

        private static HttpRequestMessage BuildRequestMessage(HttpMessage message)
        {
            if (!(message.Request is HttpClientTransportRequest pipelineRequest))
            {
                throw new InvalidOperationException("the request is not compatible with the transport");
            }
            return pipelineRequest.BuildRequestMessage(message.CancellationToken);
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out string? value)
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

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out IEnumerable<string>? values)
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

        internal static IEnumerable<HttpHeader> GetHeaders(HttpHeaders headers, HttpContent? content)
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

        internal static bool RemoveHeader(HttpHeaders headers, HttpContent? content, string name)
        {
            // .Remove throws on invalid header name so use TryGet here to check
#if NET6_0_OR_GREATER
            if (headers.NonValidated.Contains(name) && headers.Remove(name))
            {
                return true;
            }

            return content is not null && content.Headers.NonValidated.Contains(name) && content.Headers.Remove(name);
#else
            if (headers.TryGetValues(name, out _) && headers.Remove(name))
            {
                return true;
            }

            return content?.Headers.TryGetValues(name, out _) == true && content.Headers.Remove(name);
#endif
        }

        internal static bool ContainsHeader(HttpHeaders headers, HttpContent? content, string name)
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
    }
}
