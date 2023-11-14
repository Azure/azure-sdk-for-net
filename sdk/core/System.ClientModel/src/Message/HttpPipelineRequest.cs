// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace System.ClientModel.Internal.Primitives;

// This adds the Http dependency, and some implementation

public class HttpPipelineRequest : PipelineRequest, IDisposable
{
    private const string AuthorizationHeaderName = "Authorization";

    private Uri? _uri;
    private InputContent? _content;

    private readonly PipelineRequestHeaders _headers;

    protected internal HttpPipelineRequest()
    {
        Method = HttpMethod.Get.Method;
        _headers = new PipelineRequestHeaders();
    }

    public override Uri Uri
    {
        get
        {
            if (_uri is null)
            {
                throw new InvalidOperationException("Uri has not be set on HttpMessageRequest instance.");
            }

            return _uri;
        }

        set => _uri = value;
    }

    public override InputContent? Content
    {
        get => _content;
        set => _content = value;
    }

    public override string Method
    {
        get;
        set;
    }

    public override PipelineMessageHeaders Headers => _headers;

    // PATCH value needed for compat with pre-net5.0 TFMs
    private static readonly HttpMethod _patchMethod = new HttpMethod("PATCH");

    private static HttpMethod ToHttpMethod(string method)
    {
        return method switch
        {
            "GET" => HttpMethod.Get,
            "POST" => HttpMethod.Post,
            "PUT" => HttpMethod.Put,
            "HEAD" => HttpMethod.Head,
            "DELETE" => HttpMethod.Delete,
            "PATCH" => _patchMethod,
            _ => new HttpMethod(method),
        }; ;
    }

    internal HttpRequestMessage BuildRequestMessage(CancellationToken cancellationToken)
    {
        // TODO: this is confusing where we are passing in message and also
        // using private members on the request.

        HttpMethod method = ToHttpMethod(Method);
        Uri uri = Uri;
        HttpRequestMessage httpRequest = new HttpRequestMessage(method, uri);

        MessageBodyAdapter? httpContent = _content != null ? new MessageBodyAdapter(_content, cancellationToken) : null;
        httpRequest.Content = httpContent;
#if NETSTANDARD
        httpRequest.Headers.ExpectContinue = false;
#endif

        // TODO: Come back and address this implementation per switching on string/list
        // header values once we reimplement assignment of headers to ResponseHeader directly.
        Headers.TryGetHeaders(out IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers);
        foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
        {
            object headerValue = header.Value.Count() == 1 ? header.Value.First() : header.Value;
            switch (headerValue)
            {
                case string stringValue:
                    // Authorization is special cased because it is in the hot path for auth polices that set this header on each request and retry.
                    if (header.Key == AuthorizationHeaderName && AuthenticationHeaderValue.TryParse(stringValue, out var authHeader))
                    {
                        httpRequest.Headers.Authorization = authHeader;
                    }
                    else if (!httpRequest.Headers.TryAddWithoutValidation(header.Key, stringValue))
                    {
                        if (httpContent != null && !httpContent.Headers.TryAddWithoutValidation(header.Key, stringValue))
                        {
                            throw new InvalidOperationException($"Unable to add header {header.Key} to header collection.");
                        }
                    }
                    break;

                case List<string> listValue:
                    if (!httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value))
                    {
                        if (httpContent != null && !httpContent.Headers.TryAddWithoutValidation(header.Key, header.Value))
                        {
                            throw new InvalidOperationException($"Unable to add header {header.Key} to header collection.");
                        }
                    }
                    break;
            }
        }

        return httpRequest;
    }

    private sealed class MessageBodyAdapter : HttpContent
    {
        private readonly InputContent _content;
        private readonly CancellationToken _cancellationToken;

        public MessageBodyAdapter(InputContent content, CancellationToken cancellationToken)
        {
            ClientUtilities.AssertNotNull(content, nameof(content));

            _content = content;
            _cancellationToken = cancellationToken;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            => await _content.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

        protected override bool TryComputeLength(out long length)
            => _content.TryComputeLength(out length);

#if NET5_0_OR_GREATER
        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
            => await _content!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);

        protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
            => _content.WriteTo(stream, cancellationToken);
#endif
    }

    public override void Dispose()
    {
        var content = _content;
        if (content != null)
        {
            _content = null;
            content.Dispose();
        }

        GC.SuppressFinalize(this);
    }

    public override string ToString() => BuildRequestMessage(default).ToString();
}
