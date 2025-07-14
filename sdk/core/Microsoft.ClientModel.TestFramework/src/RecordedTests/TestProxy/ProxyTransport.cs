// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A transport that routes HTTP requests through a test proxy for recording and playback.
/// </summary>
public class ProxyTransport : PipelineTransport
{
    private readonly PipelineTransport _innerTransport;
    private readonly TestProxyProcess _proxyProcess;
    private readonly TestRecording _recording;
    private readonly Func<EntryRecordModel> _getRecordingMode;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProxyTransport"/> class.
    /// </summary>
    /// <param name="proxyProcess">The test proxy process.</param>
    /// <param name="innerTransport">The inner transport to wrap.</param>
    /// <param name="recording">The test recording instance.</param>
    /// <param name="getRecordingMode">Function to get the current recording mode.</param>
    public ProxyTransport(
        TestProxyProcess proxyProcess,
        PipelineTransport innerTransport,
        TestRecording recording,
        Func<EntryRecordModel> getRecordingMode)
    {
        _proxyProcess = proxyProcess ?? throw new ArgumentNullException(nameof(proxyProcess));
        _innerTransport = innerTransport ?? throw new ArgumentNullException(nameof(innerTransport));
        _recording = recording ?? throw new ArgumentNullException(nameof(recording));
        _getRecordingMode = getRecordingMode ?? throw new ArgumentNullException(nameof(getRecordingMode));
    }

    /// <inheritdoc/>
    protected override PipelineMessage CreateMessageCore()
    {
        return _innerTransport.CreateMessage();
    }

    /// <inheritdoc/>
    protected override void ProcessCore(PipelineMessage message)
    {
        ProcessCoreAsync(message).AsTask().EnsureCompleted();
    }

    /// <inheritdoc/>
    protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        // Check if recording is disabled for this request
        var recordingMode = _getRecordingMode();
        if (recordingMode == EntryRecordModel.DoNotRecord)
        {
            await _innerTransport.ProcessAsync(message).ConfigureAwait(false);
            return;
        }

        // Mark that we have requests (for validation purposes)
        _recording.HasRequests = true;

        // Route the request through the test proxy
        await RouteRequestThroughProxyAsync(message, recordingMode).ConfigureAwait(false);
    }

    private async ValueTask RouteRequestThroughProxyAsync(PipelineMessage message, EntryRecordModel recordingMode)
    {
        try
        {
            // Add recording headers
            AddRecordingHeaders(message, recordingMode);

            // Route request through proxy
            var originalUri = message.Request.Uri;
            //message.Request.Uri = RewriteUriForProxy(originalUri);

            await _innerTransport.ProcessAsync(message).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Handle proxy-specific errors
            throw new InvalidOperationException($"Test proxy request failed: {ex.Message}", ex);
        }
    }

    private void AddRecordingHeaders(PipelineMessage message, EntryRecordModel recordingMode)
    {
        // Add the recording ID header so the proxy knows which session this request belongs to
        //message.Request.Headers.Add("x-recording-id", _recording.RecordingId);

        // Add mode-specific headers
        switch (recordingMode)
        {
            case EntryRecordModel.RecordWithoutRequestBody:
                message.Request.Headers.Add("x-recording-mode", "record-without-request-body");
                break;
            case EntryRecordModel.Record:
                message.Request.Headers.Add("x-recording-mode", "record");
                break;
            case EntryRecordModel.DoNotRecord:
                // This case is handled earlier
                break;
        }
    }

    private Uri RewriteUriForProxy(Uri originalUri)
    {
        throw new NotImplementedException();
        //// Rewrite the URI to route through the test proxy
        //var proxyUri = _proxyProcess.GetProxyUri();

        //// For HTTP requests, route through the HTTP proxy port
        //var scheme = originalUri.Scheme;
        //var proxyPort = scheme == "https" ? proxyUri.httpsPort : proxyUri.httpPort;

        //// The proxy expects the original URI as the path
        //var proxyUriBuilder = new UriBuilder(scheme, "localhost", proxyPort, originalUri.AbsoluteUri);
        //return proxyUriBuilder.Uri;
    }
}