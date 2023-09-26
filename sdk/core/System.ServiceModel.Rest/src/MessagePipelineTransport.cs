// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private HttpClient _transport;

    /// <summary>
    /// TBD.
    /// </summary>
    public MessagePipelineTransport()
    {
        // TODO:
        //   - SSL settings?
        //   - Proxy settings?
        //   - Cookies?

        HttpClientHandler handler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
        };

        _transport = new HttpClient(handler)
        {
            // TODO: Timeouts are handled by the pipeline
            Timeout = Timeout.InfiniteTimeSpan,
        };
    }

    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        PipelineRequest request = new MessagePipelineRequest();
        PipelineMessage message = new MessagePipelineMessage(request, classifier);
        return message;
    }

    public void Dispose()
    {
        _transport.Dispose();

        // TODO: do we need this?
        GC.SuppressFinalize(this);
    }

    public override void Process(PipelineMessage message)
    {
        // Intentionally blocking here
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        ProcessAsync(message).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public override async ValueTask ProcessAsync(PipelineMessage message)
    {
        #region Create the request

        if (message.PipelineRequest.Method is null)
        {
            throw new NotSupportedException("TODO");
        }

        // TODO: optimize?
        HttpMethod method = message.PipelineRequest.Method;

        // TODO: clean up
        if (!message.PipelineRequest.TryGetUri(out Uri? uri))
        {
            throw new NotSupportedException("TODO");
        }

        if (message.PipelineRequest.TryGetContent(out RequestBody? content))
        {
            throw new NotSupportedException("TODO");
        }

        using HttpRequestMessage netRequest = new HttpRequestMessage(method, uri);

        // TODO: CancellationToken
        netRequest.Content = new HttpContentAdapter(content!, CancellationToken.None);

        // TODO: Request Headers

        #endregion

        #region Send the response

        HttpResponseMessage responseMessage;
        Stream? contentStream = null;

        // TODO: Why message.ClearReponse() ?

        try
        {
            // TODO: Why does Azure.Core use HttpCompletionOption.ResponseHeadersRead?
            responseMessage = await _transport.SendAsync(netRequest).ConfigureAwait(false);

            #endregion

            #region Make the message response

            if (responseMessage.Content != null)
            {
                contentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
        }

        // TODO: CancellationToken: catch(OperationCanceledException e) { ... }

        catch (HttpRequestException e)
        {
            throw new RequestErrorException(e.Message, e);
        }

        message.PipelineResponse = new MessagePipelineResponse(responseMessage, contentStream);

        #endregion
    }

    private sealed class MessagePipelineMessage : PipelineMessage
    {
        // TODO: should these be readonly?
        private PipelineRequest _request;
        private ResponseErrorClassifier _classifier;

        private PipelineResponse? _response;

        public MessagePipelineMessage(PipelineRequest request, ResponseErrorClassifier classifier) : base(request, classifier)
        {
            _request = request;
            _classifier = classifier;
        }
        public override PipelineRequest PipelineRequest
        {
            get => _request;
            set => _request = value;
        }

        public override PipelineResponse? PipelineResponse
        {
            get => _response;
            set => _response = value;
        }

        public override ResponseErrorClassifier ResponseErrorClassifier
        {
            get => _classifier;
            set => _classifier = value;
        }

        public override void Dispose()
        {
            // TODO: implement Dispose pattern properly
            _request.Dispose();

            // TODO: should response be disposable?
        }
    }

    private sealed class MessagePipelineRequest : PipelineRequest
    {
        private Uri? _uri;
        private RequestBody? _content;

        public MessagePipelineRequest()
        {
        }

        public override void SetContent(RequestBody content)
            => _content = content;

        public override void SetHeaderValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public override void SetUri(RequestUri uri)
            => _uri = uri.ToUri();

        public override bool TryGetContent(out RequestBody? content)
        {
            if (_content == null)
            {
                content = default;
                return false;
            }

            content = _content;
            return true;
        }

        public override bool TryGetUri(out Uri? uri)
        {
            if (_uri == null)
            {
                uri = default;
                return false;
            }

            uri = _uri;
            return true;
        }

        public override void Dispose()
        {
            // TODO: get this pattern right
            if (_content is not null)
            {
                RequestBody body = _content as RequestBody;
                body.Dispose();
            }
        }
    }

    private sealed class HttpContentAdapter : HttpContent
    {
        private readonly RequestBody _content;
        private readonly CancellationToken _cancellationToken;

        public HttpContentAdapter(RequestBody content, CancellationToken cancellationToken)
        {
            _content = content;
            _cancellationToken = cancellationToken;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            => await _content.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

        protected override bool TryComputeLength(out long length)
            => _content.TryComputeLength(out length);
    }

    private sealed class MessagePipelineResponse : PipelineResponse
    {
        private readonly HttpResponseMessage _netResponse;

        private readonly HttpContent _netContent;

        private Stream? _contentStream;

        public MessagePipelineResponse(HttpResponseMessage netResponse, Stream? contentStream)
        {
            _netResponse = netResponse ?? throw new ArgumentNullException(nameof(netResponse));
            _netContent = _netResponse.Content;

            // TODO: Why do we handle these separately?
            _contentStream = contentStream;
        }

        public override int Status => (int)_netResponse.StatusCode;

        public override BinaryData Content => throw new NotImplementedException();

        public override Stream? ContentStream { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ReasonPhrase => _netResponse.ReasonPhrase ?? string.Empty;

        public override bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value)
        {
            // TODO: headers
            value = default;
            return false;
        }

        // TODO: What about Dispose?
    }
}
