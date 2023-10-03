// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;

    // TODO: understand better why this is handled separately
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

    public override string ReasonPhrase => _httpResponse.ReasonPhrase ?? string.Empty;

    public override Stream? ContentStream
    {
        get => _contentStream;
        set
        {
            // TODO: grok this - why?

            // Make sure we don't dispose the content if the stream was replaced
            _httpResponse.Content = null;

            _contentStream = value;
        }
    }

    public override BinaryData Content => throw new NotImplementedException();

    public override bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value)
        => TryGetHeader(name, out value);

    protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
    => TryGetHeader(_httpResponse.Headers, _httpContent, name, out value);

    protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        => TryGetHeader(_httpResponse.Headers, _httpContent, name, out values);

    protected override bool ContainsHeader(string name)
        => ContainsHeader(_httpResponse.Headers, _httpContent, name);

    protected IEnumerable<string> GetHeaderNames()
    {
        foreach (var header in _httpResponse.Headers)
        {
            yield return header.Key;
        }
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

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var netResponse = _httpResponse;
            netResponse?.Dispose();

            var contentStream = _contentStream;
            contentStream?.Dispose();

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
