// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Tests.Utils.Pipeline;

/// <summary>
/// A re-implementation of Azure.Core.TestFramework.ProxyTransport but for the new System.ClientModel pipeline types
/// </summary>
public class ProxyTransport : PipelineTransport
{
    private const string DevCertIssuer = "CN=localhost";
    private const string FiddlerCertIssuer = "CN=DO_NOT_TRUST_FiddlerRoot, O=DO_NOT_TRUST, OU=Created by http://www.fiddler2.com";

    private readonly Func<EntryRecordModel> _filter;
    private readonly string _proxyHost;

    // The common test code makes liberal use of internals in several places. That will not stop me... 
    private readonly NonPublic.Accessor<TestRecording, bool> _recordingHasRequests =
        NonPublic.FromProperty<TestRecording, bool>(nameof(TestRecording.HasRequests));
    private readonly NonPublic.Accessor<TestRecording, TestRecordingMismatchException?> _recordingMismatch =
        NonPublic.FromField<TestRecording, TestRecordingMismatchException?>("MismatchException");

    public ProxyTransport(TestProxy proxy, TestRecording recording, Func<EntryRecordModel> filter)
    {
        Proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        Recording = recording ?? throw new ArgumentNullException(nameof(recording));
        _filter = filter ?? throw new ArgumentNullException(nameof(filter));

        string certIssuer;
        if (UseFiddler())
        {
            certIssuer = FiddlerCertIssuer;
            _proxyHost = "ipv4.fiddler";
        }
        else
        {
            certIssuer = DevCertIssuer;
            _proxyHost = TestProxy.IpAddress;
        }

        HttpClientHandler handler = new()
        {
            ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate?.Issuer == certIssuer,
            UseCookies = false,
            AllowAutoRedirect = false
        };

        InnerTransport = new HttpClientPipelineTransport(new HttpClient(handler));
    }

    protected PipelineTransport InnerTransport { get; }

    protected TestProxy Proxy { get; }

    protected TestRecording Recording { get; }

    protected override PipelineMessage CreateMessageCore()
    {
        Exception? ex = _recordingMismatch.Get(Recording);
        if (ex != null)
        {
            throw ex;
        }

        PipelineMessage message = InnerTransport.CreateMessage();
        PipelineRequest request = message.Request;
        _recordingHasRequests.Set(Recording, true);

        string requestId;
        lock (Recording.Random)
        {
            if (Recording.UseDefaultGuidFormatForClientRequestId)
            {
                // User want the client format to use the default format
                requestId = Recording.Random.NewGuid().ToString();
            }
            else
            {
                // Make sure ClientRequestId are the same across request and response
                requestId = Recording.Random.NewGuid().ToString("N");
            }
        }

        // PipelineRequest no longer has a ClientRequestId property, so we need to set it on the headers directly
        request.Headers.Add("x-ms-client-request-id", requestId);

        return message;
    }

    protected override void ProcessCore(PipelineMessage message)
        => ProcessCoreSyncOrAsync(message, async: false).GetAwaiter().GetResult();

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
        => ProcessCoreSyncOrAsync(message, async: true);

    protected virtual async ValueTask ProcessCoreSyncOrAsync(PipelineMessage message, bool async)
    {
        if (Recording.Mode == RecordedTestMode.Playback && _filter() == EntryRecordModel.DoNotRecord)
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
                await InnerTransport.ProcessAsync(message).ConfigureAwait(false);
            }
            else
            {
                InnerTransport.Process(message);
            }

            await ProcessResponseSyncAsync(message, true).ConfigureAwait(false);
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
            throw new TestRecordingMismatchException(doc.RootElement.GetProperty("Message").GetString());
        }
    }

    // copied from https://github.com/Azure/azure-sdk-for-net/blob/main/common/Perf/Azure.Test.Perf/TestProxyPolicy.cs
    protected virtual void RedirectToTestProxy(PipelineMessage message)
    {
        if (Recording.Mode == RecordedTestMode.Record)
        {
            switch (_filter())
            {
                case EntryRecordModel.Record:
                    break;
                case EntryRecordModel.RecordWithoutRequestBody:
                    message.Request.Headers.Set("x-recording-skip", "request-body");
                    break;
                case EntryRecordModel.DoNotRecord:
                    message.Request.Headers.Set("x-recording-skip", "request-response");
                    break;
            }
        }
        else if (Recording.Mode == RecordedTestMode.Playback)
        {
            if (_filter() == EntryRecordModel.RecordWithoutRequestBody)
            {
                message.Request.Content = null;
            }
        }

        var request = message.Request;
        request.Headers.Set("x-recording-id", Recording.RecordingId);
        request.Headers.Set("x-recording-mode", Recording.Mode.ToString().ToLower());

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

        builder = new(request.Uri);
        builder.Host = _proxyHost;
        builder.Port = request.Uri.Scheme == "https" ? Proxy.ProxyPortHttps!.Value : Proxy.ProxyPortHttp!.Value;

        request.Uri = builder.Uri;
    }

    private static bool UseFiddler()
    {
        // Of course TestEnvironment.EnableFiddler is internal only so reproduce the code here
        string? enableFiddlerStr = TestContext.Parameters["EnableFiddler"]
            ?? Environment.GetEnvironmentVariable("AZURE_ENABLE_FIDDLER");

        if (bool.TryParse(enableFiddlerStr, out bool enableFiddler))
        {
            return enableFiddler;
        }

        // Try to detect if there is a current proxy set and it is Fiddler
        try
        {
            Uri dummyUri = new("https://not.a.real.uri.com");

            IWebProxy webProxy = WebRequest.GetSystemWebProxy();
            Uri? proxyUri = webProxy?.GetProxy(dummyUri);
            if (proxyUri == null || proxyUri == dummyUri)
            {
                return false;
            }

            // assume default of 127.0.0.1:8888 with no credentials
            var cred = webProxy?.Credentials?.GetCredential(dummyUri, string.Empty);
            return proxyUri.Host == "127.0.0.1"
                && proxyUri.Port == 8888
                && string.IsNullOrWhiteSpace(cred?.UserName)
                && string.IsNullOrWhiteSpace(cred?.Password);
        }
        catch
        {
            return false;
        }
    }
}
