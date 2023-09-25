// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Rest.Core;
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

        _transport = new HttpClient()
        {
            // TODO: Timeouts are handled by the pipeline
            Timeout = Timeout.InfiniteTimeSpan,
        };
    }

    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        throw new NotImplementedException();
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
        if (!message.PipelineRequest.TryGetUri(out Uri uri))
        {
            throw new NotSupportedException("TODO");
        }

        if (message.PipelineRequest.TryGetContent(out RequestBody content))
        {
            throw new NotSupportedException("TODO");
        }

        using HttpRequestMessage netRequest = new HttpRequestMessage(method, uri);

        // TODO: CancellationToken
        netRequest.Content = new HttpContentAdapter(content, CancellationToken.None);

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

        message.PipelineResponse = new MessagePipelineTransportResponse(responseMessage, contentStream);

        #endregion
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

    private sealed class MessagePipelineTransportResponse : PipelineResponse
    {
        private readonly HttpResponseMessage _netResponse;

        private readonly HttpContent _netContent;

        private Stream? _contentStream;

        public MessagePipelineTransportResponse(HttpResponseMessage netResponse, Stream? contentStream)
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
