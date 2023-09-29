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
    private readonly HttpClient _httpClient;

    private bool _disposed;

    public MessagePipelineTransport() : this(CreateDefaultClient())
    {
    }

    public MessagePipelineTransport(HttpClient client)
    {
        _httpClient = client;
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

    public override void Process(PipelineMessage message)
    {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().

#if NET6_0_OR_GREATER

        ProcessSyncOrAsync(message, isAsync: false).GetAwaiter().GetResult();

#else

        // We do sync-over-async on netstandard2.0 target.
        // This can cause deadlocks in applications when the threadpool gets saturated.
        // The resolution is for a customer to upgrade to a net6.0+ target,
        // where we are able to provide a code path that calls HttpClient native sync APIs.

        ProcessSyncOrAsync(message, isAsync: true).AsTask().GetAwaiter().GetResult();

#endif

#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public override async ValueTask ProcessAsync(PipelineMessage message)
        => await ProcessSyncOrAsync(message, isAsync: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, bool isAsync)
    {
        // TODO: optimize?

        using HttpRequestMessage httpRequest = new(message.Request.Method, message.Request.Uri);

        if (message.Request.Content != null)
        {
            // TODO: CancellationToken
            httpRequest.Content = new HttpContentAdapter(message.Request.Content, CancellationToken.None);
        }

        message.Request.SetTransportHeaders(httpRequest);

        try
        {
            HttpResponseMessage responseMessage;
            Stream? contentStream = null;

            // TODO: we'll need to call message.ClearResponse() when we add retries.
            if (isAsync)
            {
                // TODO: Why does Azure.Core use HttpCompletionOption.ResponseHeadersRead?
                responseMessage = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken).ConfigureAwait(false);
            }
            else // sync call
            {
#if NET6_0_OR_GREATER
                responseMessage = _httpClient.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken);
#else
                responseMessage = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken).ConfigureAwait(false);
#endif
            }

            if (responseMessage.Content != null)
            {
                // TODO: sync/async
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

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var httpClient = _httpClient;
            httpClient?.Dispose();
            _disposed = true;
        }
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

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
