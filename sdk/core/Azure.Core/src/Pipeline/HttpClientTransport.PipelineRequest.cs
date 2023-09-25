// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport
    {
        private sealed partial class PipelineRequest : Request
        {
            private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;
            private string? _clientRequestId;

            public PipelineRequest()
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
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
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
        }
    }
}
