// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ServiceModel.Rest.Experimental;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

// This adds the Http dependency, and some implementation

public class RestRequest : PipelineRequest, IDisposable
{
    private HttpMethod? _method;
    private Uri? _uri;
    private RequestBody? _content;

    private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;

    public RestRequest()
    {
        _headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
    }

    public override void SetContent(RequestBody content)
        => _content = content;

    public override RequestBody? GetContent()
        => _content;

    public override void SetHeaderValue(string name, string value)
        => SetHeader(name, value);

    public override void SetMethod(string method)
        => _method = new HttpMethod(method);

    public virtual void SetMethod(HttpMethod method)
        => _method = method;

    // TODO: work out the details of when method is set, e.g. constructor/mutability
    public override string GetMethod() => _method!.ToString();

    public override Uri SetUri(Uri uri)
        => _uri = uri;

    // TODO: work out the details of when Uri is set, e.g. constructor/mutability
    public override Uri GetUri() => _uri!;

    #region Header implementation

    protected virtual void SetHeader(string name, string value)
    {
        _headers.Set(new IgnoreCaseString(name), value);
    }

    protected virtual void AddHeader(string name, string value)
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

    protected virtual IEnumerable<string> GetHeaderNames()
    {
        for (int i = 0; i < _headers.Count; i++)
        {
            _headers.GetAt(i, out var name, out var _);
            yield return name;
        }
    }

    protected virtual bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
    {
        if (_headers.TryGetValue(new IgnoreCaseString(name), out var headerValue))
        {
            value = GetHttpHeaderValue(name, headerValue);
            return true;
        }

        value = default;
        return false;
    }

    protected virtual bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
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

    protected virtual bool ContainsHeader(string name) => _headers.TryGetValue(new IgnoreCaseString(name), out _);

    protected virtual bool RemoveHeader(string name) => _headers.TryRemove(new IgnoreCaseString(name));

    private static string GetHttpHeaderValue(string headerName, object value) => value switch
    {
        string headerValue => headerValue,
        List<string> headerValues => string.Join(",", headerValues),
        _ => throw new InvalidOperationException($"Unexpected type for header {headerName}: {value?.GetType()}")
    };

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
    #endregion

    #region Construction for transport

    internal HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
    {
        HttpRequestMessage currentRequest = new HttpRequestMessage(_method!, _uri!);

        PipelineContentAdapter? currentContent = _content != null ? new PipelineContentAdapter(_content, cancellation) : null;
        currentRequest.Content = currentContent;
#if NETFRAMEWORK
        currentRequest.Headers.ExpectContinue = false;
#endif

        for (int i = 0; i < _headers.Count; i++)
        {
            _headers.GetAt(i, out IgnoreCaseString headerName, out object value);

            switch (value)
            {
                case string stringValue:
                    // Authorization is special cased because it is in the hot path for auth polices that set this header on each request and retry.

                    // TODO: use a constant declaration
                    if (headerName == "Authorization" && AuthenticationHeaderValue.TryParse(stringValue, out var authHeader))
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
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
        {
            SetPropertiesOrOptions(currentRequest, "WebAssemblyFetchOptions", new Dictionary<string, object> { { "cache", "no-store" } });
            SetPropertiesOrOptions(currentRequest, "WebAssemblyEnableStreamingResponse", true);
        }
    }

    private static void SetPropertiesOrOptions<T>(HttpRequestMessage httpRequest, string name, T value)
    {
#if NET5_0_OR_GREATER
        httpRequest.Options.Set(new HttpRequestOptionsKey<T>(name), value);
#else
            httpRequest.Properties[name] = value;
#endif
    }

    private sealed class PipelineContentAdapter : HttpContent
    {
        private readonly RequestBody _pipelineContent;
        private readonly CancellationToken _cancellationToken;

        public PipelineContentAdapter(RequestBody pipelineContent, CancellationToken cancellationToken)
        {
            _pipelineContent = pipelineContent;
            _cancellationToken = cancellationToken;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            => await _pipelineContent.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

        protected override bool TryComputeLength(out long length)
            => _pipelineContent.TryComputeLength(out length);

#if NET5_0_OR_GREATER
        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
            => await _pipelineContent!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

        protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
            => _pipelineContent.WriteTo(stream, cancellationToken);
#endif
    }

    #endregion

    public virtual void Dispose()
    {
        _headers.Dispose();
        var content = _content;
        if (content != null)
        {
            _content = null;
            content.Dispose();
        }
    }

    public override string ToString() => BuildRequestMessage(default).ToString();
}
