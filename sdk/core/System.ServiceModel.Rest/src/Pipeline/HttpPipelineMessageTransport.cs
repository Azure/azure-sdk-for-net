// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.Net.Http;
using System.ServiceModel.Rest.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

// Introduces the dependency on System.Net.Http;

public partial class HttpPipelineMessageTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private readonly HttpClient _httpClient;

    // TODO: remove this when refactor is complete.
    public HttpClient Client => _httpClient;

    private bool _disposed;

    public HttpPipelineMessageTransport() : this(CreateDefaultClient())
    {
    }

    public HttpPipelineMessageTransport(HttpClient client)
    {
        ClientUtilities.AssertNotNull(client, nameof(client));

        _httpClient = client;
    }

    private static HttpClient CreateDefaultClient()
    {
        // TODO:
        //   - SSL settings?
        //   - Proxy settings?
        //   - Cookies?
        //   - MaxConnectionsPerServer?  PooledConnectionLifetime?

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request, classifier);

        // TODO: use options

        return message;
    }

    public override void Process(PipelineMessage message)
    {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().

#if NET6_0_OR_GREATER

        ProcessSyncOrAsync(message, async: false).GetAwaiter().GetResult();

#else

        // We do sync-over-async on netstandard2.0 target.
        // This can cause deadlocks in applications when the threadpool gets saturated.
        // The resolution is for a customer to upgrade to a net6.0+ target,
        // where we are able to provide a code path that calls HttpClient native sync APIs.

        ProcessSyncOrAsync(message, async: true).AsTask().GetAwaiter().GetResult();

#endif

#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public override async ValueTask ProcessAsync(PipelineMessage message)
        => await ProcessSyncOrAsync(message, async: true).ConfigureAwait(false);

#pragma warning disable CA1801 // async parameter unused on netstandard
    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, bool async)
#pragma warning restore CA1801
    {
        using HttpRequestMessage httpRequest = BuildRequestMessage(message);

        OnSendingRequest(message);

        HttpResponseMessage responseMessage;
        Stream? contentStream = null;

        // TODO: enable with retries
        //message.ClearResponse();

        try
        {
#if NET5_0_OR_GREATER
            if (!async)
            {
                // Sync HttpClient.Send is not supported on browser but neither is the sync-over-async
                // HttpClient.Send would throw a NotSupported exception instead of GetAwaiter().GetResult()
                // throwing a System.Threading.SynchronizationLockException: Cannot wait on monitors on this runtime.
#pragma warning disable CA1416 // 'HttpClient.Send(HttpRequestMessage, HttpCompletionOption, CancellationToken)' is unsupported on 'browser'
                responseMessage = Client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken);
#pragma warning restore CA1416
            }
            else
#endif
            {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                // TODO: To make it real we need to pass HttpCompletionOption.ResponseHeadersRead and buffer the content
                responseMessage = await Client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            }

            if (responseMessage.Content != null)
            {
#if NET5_0_OR_GREATER
                if (async)
                {
                    contentStream = await responseMessage.Content.ReadAsStreamAsync(message.CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    contentStream = responseMessage.Content.ReadAsStream(message.CancellationToken);
                }
#else
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                contentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
#endif
            }
        }
        // HttpClient on NET5 throws OperationCanceledException from sync call sites, normalize to TaskCanceledException
        catch (OperationCanceledException e) when (ClientUtilities.ShouldWrapInOperationCanceledException(e, message.CancellationToken))
        {
            throw ClientUtilities.CreateOperationCanceledException(e, message.CancellationToken);
        }
        catch (HttpRequestException e)
        {
            throw new RequestErrorException(e.Message, e);
        }

        // TODO: allow Azure.Core to decorate the response. e.g. with ClientRequestId
        //message.Response = new HttpPipelineResponse(/*message.Request.ClientRequestId,*/ responseMessage, contentStream);
        OnReceivedResponse(message, responseMessage, contentStream);

        //// TODO: this is a quick and dirty buffer response
        //Stream? responseContentStream = message.Response.ContentStream;
        //if (responseContentStream is null) { return; }
        //Stream bufferedStream = new MemoryStream();
        //if (async)
        //{
        //    await CopyToAsync(responseContentStream, bufferedStream, CancellationTokenSource.CreateLinkedTokenSource(CancellationToken.None)).ConfigureAwait(false);
        //}
        //else
        //{
        //    CopyTo(responseContentStream, bufferedStream, CancellationTokenSource.CreateLinkedTokenSource(CancellationToken.None));
        //}
        //responseContentStream.Dispose();
        //bufferedStream.Position = 0;
        //message.Response.ContentStream = bufferedStream;
    }

    /// <summary>
    /// TBD. Needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    protected virtual void OnSendingRequest(PipelineMessage message)
    {
        // TODO: Azure.Core-specific
        //SetPropertiesOrOptions<HttpMessage>(httpRequest, MessageForServerCertificateCallback, message);
    }

    /// <summary>
    /// TBD.  Needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="httpResponse"></param>
    /// <param name="contentStream"></param>
    protected virtual void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse, Stream? contentStream)
        => message.Response = new HttpPipelineResponse(httpResponse, contentStream);

    // TODO: Note WIP - pulled this over from HttpClientTransport, need to finish e2e
    private static HttpRequestMessage BuildRequestMessage(PipelineMessage message)
    {
        if (!(message.Request is HttpPipelineRequest pipelineRequest))
        {
            throw new InvalidOperationException("the request is not compatible with the transport");
        }
        return pipelineRequest.BuildRequestMessage(message.CancellationToken);
    }

    // Same value as Stream.CopyTo uses by default
    private const int DefaultCopyBufferSize = 81920;

    private async Task CopyToAsync(Stream source, Stream destination, CancellationTokenSource cancellationTokenSource)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
        try
        {
            while (true)
            {
                //cancellationTokenSource.CancelAfter(_networkTimeout);
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in all targets
                int bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in all targets
                if (bytesRead == 0) break;
                await destination.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, bytesRead), cancellationTokenSource.Token).ConfigureAwait(false);
            }
        }
        finally
        {
            cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private void CopyTo(Stream source, Stream destination, CancellationTokenSource cancellationTokenSource)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
        try
        {
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                //cancellationTokenSource.CancelAfter(_networkTimeout);
                destination.Write(buffer, 0, read);
            }
        }
        finally
        {
            cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
            ArrayPool<byte>.Shared.Return(buffer);
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
}
