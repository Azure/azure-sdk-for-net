// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives.Pipeline;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;
    private readonly HttpContent _httpContent;
    private Stream? _contentStream;

    private bool _disposed;

    public HttpPipelineResponse(HttpResponseMessage? httpResponse, Stream? contentStream)
    {
        _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
        _httpContent = httpResponse.Content;
        _contentStream = contentStream;
    }

    public override int Status => (int)_httpResponse.StatusCode;

    public override bool TryGetReasonPhrase(out string reasonPhrase)
    {
        if (_httpResponse.ReasonPhrase is not null)
        {
            reasonPhrase = _httpResponse.ReasonPhrase;
            return true;
        }

        reasonPhrase = string.Empty;
        return false;
    }

    public override Stream? ContentStream
    {
        get => _contentStream;
        set
        {
            // Make sure we don't dispose the content if the stream was replaced
            _httpResponse.Content = null;

            _contentStream = value;
        }
    }

    public override bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value)
        => TryGetHeader(_httpResponse.Headers, _httpContent, name, out value);

    public override bool TryGetHeaderValue(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        => TryGetHeader(_httpResponse.Headers, _httpContent, name, out values);

    public override bool TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers)
    {
        headers = GetHeaders(_httpResponse.Headers, _httpContent);
        return true;
    }

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
                    value = JoinHeaderValues(values!);
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

    private static IEnumerable<KeyValuePair<string, string>> GetHeaders(HttpHeaders headers, HttpContent? content)
    {
#if NET6_0_OR_GREATER
        foreach (var (key, value) in headers.NonValidated)
        {
            yield return new KeyValuePair<string, string>(key, JoinHeaderValues(value));
        }

        if (content is not null)
        {
            foreach (var (key, value) in content.Headers.NonValidated)
            {
                yield return new KeyValuePair<string, string>(key, JoinHeaderValues(value));
            }
        }
#else
            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                yield return new KeyValuePair<string, string>(header.Key, JoinHeaderValues(header.Value));
            }

            if (content != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
                {
                    yield return new KeyValuePair<string, string>(header.Key, JoinHeaderValues(header.Value));
                }
            }
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
        var interpolatedStringHandler = new DefaultInterpolatedStringHandler(count - 1, count);
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

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var httpResponse = _httpResponse;
            httpResponse?.Dispose();

            // We want to keep the ContentStream readable
            // even after the response is disposed but only if it's a
            // buffered memory stream otherwise we can leave a network
            // connection hanging open
            if (_contentStream is not MemoryStream)
            {
                var contentStream = _contentStream;
                contentStream?.Dispose();
                _contentStream = null;
            }

            _disposed = true;
        }
    }

    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
