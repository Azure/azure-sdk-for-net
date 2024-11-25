// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Text.Json;

namespace OpenAI.TestFramework.Recording.RecordingProxy;

/// <summary>
/// Implements a <see cref="PipelineTransport"/> that will redirect all HTTP/HTTPS requests to the test proxy for recording or playback.
/// Depending on the mode, the test proxy will then either forward the request to the upstream service and record the request and response,
/// or playback the response from a previous recording.
/// </summary>
public class ProxyTransport : PipelineTransport
{
    private const string DevCertIssuer = "CN=localhost";
    private const string FiddlerCertIssuer = "CN=DO_NOT_TRUST_FiddlerRoot, O=DO_NOT_TRUST, OU=Created by http://www.fiddler2.com";
    private const string FiddlerHost = "ipv4.fiddler";

    private readonly ProxyTransportOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProxyTransport"/> class.
    /// </summary>
    /// <param name="options">The options for the proxy transport.</param>
    public ProxyTransport(ProxyTransportOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));

        string certIssuer;
        if (_options.UseFiddler)
        {
            certIssuer = FiddlerCertIssuer;
        }
        else
        {
            certIssuer = DevCertIssuer;
        }

        HttpClientHandler handler = new()
        {
            ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate?.Issuer == certIssuer,
            UseCookies = _options.AllowCookies,
            AllowAutoRedirect = _options.AllowAutoRedirect
        };

        InnerTransport = new HttpClientPipelineTransport(new HttpClient(handler));
    }

    /// <summary>
    /// The actual transport to use for sending requests, and receiving responses.
    /// </summary>
    protected PipelineTransport InnerTransport { get; }

    /// <inheritdoc/>
    protected override PipelineMessage CreateMessageCore()
    {
        Exception? ex = _options.MismatchException?.GetValue();
        if (ex != null)
        {
            throw ex;
        }

        PipelineMessage message = InnerTransport.CreateMessage();
        PipelineRequest request = message.Request;

        // PipelineRequest no longer has a ClientRequestId property, so we need to set it on the headers directly
        request.Headers.Add("x-ms-client-request-id", _options.RequestId);

        return message;
    }

    /// <inheritdoc/>
    protected override void ProcessCore(PipelineMessage message)
        => ProcessCoreSyncOrAsync(message, async: false).GetAwaiter().GetResult();

    /// <inheritdoc/>
    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
        => ProcessCoreSyncOrAsync(message, async: true);

    /// <summary>
    /// Processes the pipeline message synchronously or asynchronously.
    /// </summary>
    /// <param name="message">The pipeline message to process.</param>
    /// <param name="async">A flag indicating whether to process asynchronously.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    protected virtual async ValueTask ProcessCoreSyncOrAsync(PipelineMessage message, bool async)
    {
        try
        {
            RedirectToTestProxy(message);
            if (async)
            {
                await InnerTransport.ProcessAsync(message).ConfigureAwait(false);
            }
            else
            {
                InnerTransport.Process(message);
            }

            await ProcessResponseSyncAsync(message, async).ConfigureAwait(false);
        }
        finally
        {
            // revert the original URI - this is important for tests that rely on aspects of the URI in the pipeline
            // e.g. KeyVault caches tokens based on URI
            message.Request.Headers.TryGetValue("x-recording-upstream-base-uri", out string? original);
            if (message.Request.Uri is null)
            {
                throw new InvalidOperationException("The request cannot have a null URI");
            }
            if (original == null)
            {
                throw new InvalidOperationException("The TestProxy response did not contain the expected \"x-recording-upstream-base-uri\" header");
            }

            var originalBaseUri = new Uri(original);
            var builder = new UriBuilder(message.Request.Uri);
            builder.Scheme = originalBaseUri.Scheme;
            builder.Host = originalBaseUri.Host;
            builder.Port = originalBaseUri.Port;

            message.Request.Uri = builder.Uri;
        }
    }

    /// <summary>
    /// Processes the response synchronously or asynchronously.
    /// </summary>
    /// <param name="message">The pipeline message containing the response.</param>
    /// <param name="async">A flag indicating whether to process asynchronously.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    protected virtual async ValueTask ProcessResponseSyncAsync(PipelineMessage message, bool async)
    {
        if (message.Response?.Headers.TryGetValues("x-request-mismatch", out _) == true)
        {
            if (message.Response.ContentStream == null)
            {
                throw new TestRecordingMismatchException("Detected a mismatch but the response had no body");
            }

            using var doc = async
                ? await JsonDocument.ParseAsync(message.Response.ContentStream).ConfigureAwait(false)
                : JsonDocument.Parse(message.Response.ContentStream);
            throw new TestRecordingMismatchException(doc.RootElement.GetProperty("Message").GetString(), null);
        }
    }

    // copied from https://github.com/Azure/azure-sdk-for-net/blob/main/common/Perf/Azure.Test.Perf/TestProxyPolicy.cs
    /// <summary>
    /// Redirects the pipeline message to the test proxy based on the recording mode.
    /// </summary>
    /// <param name="message">The pipeline message to redirect.</param>
    protected virtual void RedirectToTestProxy(PipelineMessage message)
    {
        if (_options.Mode == RecordedTestMode.Record)
        {
            switch (_options.ShouldRecordRequest(message.Request))
            {
                case RequestRecordMode.Record:
                    break;
                case RequestRecordMode.RecordWithoutRequestBody:
                    message.Request.Headers.Set("x-recording-skip", "request-body");
                    break;
                case RequestRecordMode.DoNotRecord:
                    message.Request.Headers.Set("x-recording-skip", "request-response");
                    break;
            }
        }
        else if (_options.Mode == RecordedTestMode.Playback)
        {
            switch (_options.ShouldRecordRequest(message.Request))
            {
                case RequestRecordMode.Record:
                    break;
                case RequestRecordMode.RecordWithoutRequestBody:
                    // CAUTION: setting the request content to null has the unfortunate side effect of causing any HttpClient backed
                    //          implementation of networking to not send up any Content-??? headers as well which can cause test
                    //          mismatches. Let's work around this by setting some empty content.
                    message.Request.Content = BinaryContent.Create(BinaryData.FromBytes(Array.Empty<byte>()));
                    break;
                case RequestRecordMode.DoNotRecord:
                    throw new InvalidOperationException(
                        "Cannot playback when recording has been disabled. Please make sure to skip the test or request.");
            }
        }

        var request = message.Request;
        request.Headers.Set("x-recording-id", _options.RecordingId);
        request.Headers.Set("x-recording-mode", _options.Mode.ToString().ToLowerInvariant());

        if (request.Uri is null)
        {
            throw new InvalidOperationException("Request URI cannot be null");
        }

        // Intentionally reset the upstream URI in case the request URI changes between retries - e.g. when using GeoRedundant secondary Storage
        var builder = new UriBuilder()
        {
            Scheme = request.Uri.Scheme,
            Host = request.Uri.Host,
            Port = request.Uri.Port,
        };
        request.Headers.Set("x-recording-upstream-base-uri", builder.ToString());

        Uri baseUri = request.Uri.Scheme == "https" ? _options.HttpsEndpoint : _options.HttpEndpoint;

        builder = new(request.Uri);
        builder.Host = _options.UseFiddler ? FiddlerHost : baseUri.Host;
        builder.Port = baseUri.Port;

        request.Uri = builder.Uri;
    }
}
