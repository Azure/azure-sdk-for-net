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
    private static readonly HttpClient SharedDefaultClient = CreateDefaultClient();
    private static readonly HttpClientPipelineTransport _shared = new();

    /// <summary>
    /// A shared instance of <see cref="HttpClientPipelineTransport"/> with default parameters.
    /// </summary>
    public static HttpClientPipelineTransport Shared => _shared;

    private readonly HttpClient _httpClient;

    public HttpClientPipelineTransport() : this(SharedDefaultClient)
    {
    }

    public HttpClientPipelineTransport(HttpClient client)
    {
        Argument.AssertNotNull(client, nameof(client));

        _httpClient = client;
    }

    private static HttpClient CreateDefaultClient()
    {
        // The following settings are added in Azure.Core and are not included
        // in System.ClientModel. If needed, we will migrate them into ClientModel.
        //   - SSL settings
        //   - Proxy settings
        //   - Cookies

        HttpClientHandler handler = new HttpClientHandler()
        {
            AllowAutoRedirect = false
        };

        ServicePointHelpers.SetLimits(handler);

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
#if NET6_0_OR_GREATER

        ProcessSyncOrAsync(message, async: false).EnsureCompleted();

#else

        // We do sync-over-async on netstandard2.0 target.
        // This can cause deadlocks in applications when the threadpool gets saturated.
        // The resolution is for a customer to upgrade to a net6.0+ target,
        // where we are able to provide a code path that calls HttpClient native sync APIs.
        // As such, the following call is intentionally blocking.
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        ProcessSyncOrAsync(message, async: true).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
#endif
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
        message.Response = null;

        try
        {
#if NET6_0_OR_GREATER
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
#if NET6_0_OR_GREATER
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
        catch (OperationCanceledException e) when (CancellationHelper.ShouldWrapInOperationCanceledException(e, message.CancellationToken))
        {
            throw CancellationHelper.CreateOperationCanceledException(e, message.CancellationToken);
        }
        catch (HttpRequestException e)
        {
            throw new ClientResultException(e.Message, response: default, e);
        }

        message.Response = new HttpClientTransportResponse(responseMessage);

        // This extensibility point lets derived types do the following:
        //   1. Set message.Response to an implementation-specific type, e.g. Azure.Core.Response.
        //   2. Make any necessary modifications based on the System.Net.Http.HttpResponseMessage.
        OnReceivedResponse(message, responseMessage);

        // We set derived values on the MessageResponse here, including Content and IsError
        // to ensure these things happen in the transport.  If derived implementations need
        // to override these default transport values, they can do so in pipeline policies.
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
        // We don't dispose the Shared static transport instance, and if the
        // custom HttpClient constructor was called, then it is the caller's
        // responsibility to dispose the passed-in HttpClient.  As such, Dispose
        // for this implementation is a no-op.  We retain the protected method
        // to allow subtypes to provide an implementation.
    }

    #endregion
}
