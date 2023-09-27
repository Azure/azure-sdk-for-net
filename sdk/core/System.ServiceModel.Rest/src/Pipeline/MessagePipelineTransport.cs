// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private readonly HttpClient _transport;

    public MessagePipelineTransport() : this(CreateDefaultClient())
    {
    }

    public MessagePipelineTransport(HttpClient client)
    {
        _transport = client;
    }

    private static HttpClient CreateDefaultClient()
    {
        // TODO:
        //   - SSL settings?
        //   - Proxy settings?
        //   - Cookies?

        HttpClientHandler handler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
        };

        return new HttpClient(handler)
        {
            // TODO: Timeouts are handled by the pipeline
            Timeout = Timeout.InfiniteTimeSpan,
        };
    }

    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        PipelineRequest request = new PipelineRequest();
        PipelineMessage message = new PipelineMessage(request, classifier);

        // TODO: use options

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
        // TODO: Sync over async?
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        ProcessAsync(message).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public override async ValueTask ProcessAsync(PipelineMessage message)
    {
        // TODO: optimize?

        using HttpRequestMessage netRequest = new(message.Request.Method, message.Request.Uri);

        if (message.Request.Content != null)
        {
            // TODO: CancellationToken
            netRequest.Content = new HttpContentAdapter(message.Request.Content, CancellationToken.None);
        }

        message.Request.SetTransportHeaders(netRequest);

        try
        {
            HttpResponseMessage responseMessage;
            Stream? contentStream = null;

            // TODO: we'll need to call message.ClearResponse() when we add retries.

            // TODO: Why does Azure.Core use HttpCompletionOption.ResponseHeadersRead?
            responseMessage = await _transport.SendAsync(netRequest).ConfigureAwait(false);

            if (responseMessage.Content != null)
            {
                contentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }

            message.Response = new PipelineResponse(responseMessage, contentStream);
        }

        // TODO: CancellationToken: catch(OperationCanceledException e) { ... }

        catch (HttpRequestException e)
        {
            throw new RequestErrorException(e.Message, e);
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
}
