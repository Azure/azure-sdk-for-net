// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Net.Http;
using System.Text.Json;
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
    private const string DevCertIssuer = "CN=localhost";
    private const string FiddlerCertIssuer = "CN=DO_NOT_TRUST_FiddlerRoot, O=DO_NOT_TRUST, OU=Created by http://www.fiddler2.com";
    private readonly string _proxyHost;

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
        bool useFiddler = TestEnvironment.EnableFiddler;
        string certIssuer = useFiddler ? FiddlerCertIssuer : DevCertIssuer;
        _proxyHost = useFiddler ? "ipv4.fiddler" : TestProxyProcess.IpAddress;
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate?.Issuer == certIssuer,
            AllowAutoRedirect = false
        };
        _innerTransport = new HttpClientPipelineTransport(new HttpClient(handler));
    }

    /// <inheritdoc/>
    protected override PipelineMessage CreateMessageCore()
    {
        if (_recording.MismatchException != null)
        {
            throw _recording.MismatchException;
        }

        var message = _innerTransport.CreateMessage();
        _recording.HasRequests = true;
        return message;
    }

    /// <inheritdoc/>
    protected override void ProcessCore(PipelineMessage message)
    {
        ProcessAsyncInternalAsync(message, false).EnsureCompleted();
    }

    /// <inheritdoc/>
    protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        await ProcessAsyncInternalAsync(message, true).ConfigureAwait(false);
    }

    private async Task ProcessAsyncInternalAsync(PipelineMessage message, bool async)
    {
        if (_recording.Mode == RecordedTestMode.Playback && _getRecordingMode() == EntryRecordModel.DoNotRecord)
        {
            throw new InvalidOperationException(
                "Operations that are enclosed in a 'TestRecording.DisableRecordingScope' created with the 'DisableRecording' method should not be executed in Playback mode." +
                "Instead, update the test to skip the operation when in Playback mode by checking the 'Mode' property of 'RecordedTestBase'.");
        }
        try
        {
            RedirectToTestProxy(message);
            if (async)
            {
                await _innerTransport.ProcessAsync(message).ConfigureAwait(false);
            }
            else
            {
                _innerTransport.Process(message);
            }

            await ProcessResponseAsync(message, async).ConfigureAwait(false);
        }
        finally
        {
            // revert the original URI - this is important for tests that rely on aspects of the URI in the pipeline
            // e.g. KeyVault caches tokens based on URI
            message.Request.Headers.TryGetValue("x-recording-upstream-base-uri", out string? original);
            if (original is not null)
            {
                var originalUriBuilder = new UriBuilder(original);
                var requestUriBuilder = new UriBuilder(message.Request.Uri!);
                requestUriBuilder.Scheme = originalUriBuilder.Uri.Scheme;
                requestUriBuilder.Host = originalUriBuilder.Host;
                requestUriBuilder.Port = originalUriBuilder.Port;
                message.Request.Uri = requestUriBuilder.Uri;
            }
        }
    }

    private async Task ProcessResponseAsync(PipelineMessage message, bool async)
    {
        if (message.Response is not null && message.Response.Headers.TryGetValue("x-request-mismatch", out var mismatch))
        {
            var streamReader = new StreamReader(message.Response.ContentStream ?? throw new InvalidOperationException("Content steam is null when headers contain x-request-mismatch."));
            string response;
            if (async)
            {
                response = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
            else
            {
                response = streamReader.ReadToEnd();
            }
            using var doc = JsonDocument.Parse(response);
            throw new TestRecordingMismatchException(doc.RootElement.GetProperty("Message").GetString() ?? string.Empty);
        }
    }

    // copied from https://github.com/Azure/azure-sdk-for-net/blob/main/common/Perf/Azure.Test.Perf/TestProxyPolicy.cs
    private void RedirectToTestProxy(PipelineMessage message)
    {
        if (_recording.Mode == RecordedTestMode.Record)
        {
            switch (_getRecordingMode())
            {
                case EntryRecordModel.Record:
                    break;
                case EntryRecordModel.RecordWithoutRequestBody:
                    message.Request.Headers.Add("x-recording-skip", "request-body");
                    break;
                case EntryRecordModel.DoNotRecord:
                    message.Request.Headers.Add("x-recording-skip", "request-response");
                    break;
            }
        }
        else if (_recording.Mode == RecordedTestMode.Playback)
        {
            if (_getRecordingMode() == EntryRecordModel.RecordWithoutRequestBody)
            {
                message.Request.Content = null;
            }
        }

        var request = message.Request;
        request.Headers.Set("x-recording-id", _recording.RecordingId ?? throw new InvalidOperationException("Recording Id cannot be null"));
        request.Headers.Set("x-recording-mode", _recording.Mode.ToString().ToLower());

        // Intentionally reset the upstream URI in case the request URI changes between retries - e.g. when using GeoRedundant secondary Storage
        Uri baseUri = new($"{request.Uri!.Scheme}://{request.Uri.Host}:{request.Uri.Port}");

        request.Headers.Set("x-recording-upstream-base-uri", baseUri.AbsoluteUri);

        var builder = new UriBuilder(request.Uri)
        {
            Host = _proxyHost,
            Port = (request.Uri.Scheme == "https" ? _proxyProcess.ProxyPortHttps! : _proxyProcess.ProxyPortHttp!).Value
        };
        request.Uri = builder.Uri;
    }
}