// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

/// <summary>
/// An implementation of <see cref="PipelineTransport"/> that uses a
/// <see cref="HttpClient"/> to send and receive HTTP requests and responses.
/// </summary>
public partial class HttpClientPipelineTransport : PipelineTransport, IDisposable
{
    private static readonly HttpClient _sharedDefaultClient = CreateDefaultClient();

    /// <summary>
    /// A default instance of <see cref="HttpClientPipelineTransport"/> that can
    /// be shared across pipelines and clients.
    /// </summary>
    public static HttpClientPipelineTransport Shared { get; } = new();

    private readonly HttpClient _httpClient;

    /// <summary>
    /// Create a new instance of <see cref="HttpClientPipelineTransport"/> that
    /// uses a shared default instance of <see cref="HttpClient"/>.
    /// </summary>
    public HttpClientPipelineTransport() : this(_sharedDefaultClient)
    {
    }

    /// <summary>
    /// Create a new instance of <see cref="HttpClientPipelineTransport"/> that
    /// uses the provided <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> that this transport
    /// instance will use to send and receive HTTP requests and responses.
    /// </param>
    public HttpClientPipelineTransport(HttpClient client) : this(client, ClientLoggingOptions.DefaultEnableLogging, null)
    {
        Argument.AssertNotNull(client, nameof(client));
    }

    /// <summary>
    /// Create a new instance of <see cref="HttpClientPipelineTransport"/> that
    /// uses the provided <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> that this transport
    /// instance will use to send and receive HTTP requests and responses. If no <see cref="HttpClient"/>
    /// is passed, a default shared client will be used.
    /// </param>
    /// <param name="enableLogging">If client-wide logging is enabled for this pipeline.</param>
    /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to use to create an <see cref="ILogger"/> instance for logging.</param>
    public HttpClientPipelineTransport(HttpClient? client, bool enableLogging, ILoggerFactory? loggerFactory) : base(enableLogging, loggerFactory)
    {
        _httpClient = client ?? _sharedDefaultClient;
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

    /// <inheritdoc/>
    protected override PipelineMessage CreateMessageCore()
    {
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        return message;
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
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
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="HttpClientPipelineTransport"/> logic.  It is called from
    /// <see cref="ProcessCore(PipelineMessage)"/> prior to sending the HTTP
    /// request.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineRequest"/> resulting from the processing of the
    /// policies in the <see cref="ClientPipeline"/> containing this transport.
    /// </param>
    /// <param name="httpRequest">The <see cref="HttpRequestMessage"/> created
    /// by the transport that will be sent to the service using this transport's
    /// <see cref="HttpClient"/> instance.</param>
    protected virtual void OnSendingRequest(PipelineMessage message, HttpRequestMessage httpRequest) { }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="HttpClientPipelineTransport"/> logic.  It is called from
    /// <see cref="ProcessCore(PipelineMessage)"/> after the transport has
    /// created the <see cref="PipelineResponse"/> and set it on
    /// <see cref="PipelineMessage.Response"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> created by the transport.</param>
    /// <param name="httpResponse">The <see cref="HttpResponseMessage"/>
    /// returned by from the call to Send on <see cref="HttpClient"/> that the
    /// transport used to create <see cref="PipelineMessage.Response"/>.
    /// </param>
    protected virtual void OnReceivedResponse(PipelineMessage message, HttpResponseMessage httpResponse) { }

    #region IDisposable

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the
    /// <see cref="HttpClientPipelineTransport"/> and optionally disposes of
    /// the managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and
    /// unmanaged resources; <c>false</c> to release only unmanaged resources.
    /// </param>
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
