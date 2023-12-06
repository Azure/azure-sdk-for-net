// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class HttpClientPipelineTransport : PipelineTransport, IDisposable
{
    /// <summary>
    /// A shared instance of <see cref="HttpClientPipelineTransport"/> with default parameters.
    /// </summary>
    internal static readonly HttpClientPipelineTransport Shared = new();

    private readonly bool _ownsClient;
    private readonly HttpClient _httpClient;

    private bool _disposed;

    public HttpClientPipelineTransport() : this(CreateDefaultClient())
    {
        // We will dispose the httpClient.
        _ownsClient = true;
    }

    public HttpClientPipelineTransport(HttpClient client)
    {
        ClientUtilities.AssertNotNull(client, nameof(client));

        _httpClient = client;

        // The caller will dispose the httpClient.
        _ownsClient = false;
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
            // Timeouts are handled by the pipeline
            Timeout = Timeout.InfiniteTimeSpan,
        };
    }

    protected override PipelineMessage CreateMessageCore()
    {
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        return message;
    }

    protected sealed override void ProcessCore(PipelineMessage message)
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

    protected sealed override async ValueTask ProcessCoreAsync(PipelineMessage message)
        => await ProcessSyncOrAsync(message, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, bool async)
    {
        if (message.Request is not PipelineRequest request)
        {
            throw new InvalidOperationException($"The request type is not compatible with the transport: '{message.Request?.GetType()}'.");
        }

        using HttpRequestMessage httpRequest = HttpPipelineRequest.BuildHttpRequestMessage(request, message.CancellationToken);

        OnSendingRequest(message, httpRequest);

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
                responseMessage = _httpClient.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken);
#pragma warning restore CA1416
            }
            else
#endif
            {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                responseMessage = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken).ConfigureAwait(false);
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
            throw new ClientRequestException(e.Message, e);
        }

        message.Response = new HttpPipelineResponse(responseMessage);

        // This extensibility point lets derived types do the following:
        //   1. Set message.Response to an implementation-specific type, e.g. Azure.Core.Response.
        //   2. Make any necessary modifications based on the System.Net.Http.HttpResponseMessage.
        OnReceivedResponse(message, responseMessage);

        // We set derived values on the MessageResponse here, including Content and IsError
        // to ensure these things happen in the transport.  If derived implementations need
        // to override these default transport values, they can do so in pipeline policies.

        // TODO: a possible alternative is to make instantiating the Response a specific
        // extensibilty point and let OnReceivedResponse enable transport-specific logic.
        // Consider which is preferred as part of holistic extensibility-point review.
        if (contentStream is not null)
        {
            message.Response.ContentStream = contentStream;
        }
    }

    /// <summary>
    /// TBD. Needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="httpRequest"></param>
    protected virtual void OnSendingRequest(PipelineMessage message, HttpRequestMessage httpRequest) { }

    /// <summary>
    /// TBD.  Needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="httpResponse"></param>
    protected virtual void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse) { }

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            if (this != Shared && _ownsClient)
            {
                HttpClient httpClient = _httpClient;
                httpClient?.Dispose();
            }

            _disposed = true;
        }
    }

    #endregion
}