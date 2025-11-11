// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Projects.Tests;

internal class AgentsProxyTransport : PipelineTransport
{
    private const string DevCertIssuer = "CN=localhost";

    private readonly PipelineTransport _innerTransport;
    private readonly TestRecording _recording;

    public AgentsProxyTransport(TestRecording recording)
    {
        _recording = recording ?? throw new ArgumentNullException(nameof(recording));

        // Create HttpClientHandler with custom certificate validation for test proxy
        HttpClientHandler handler = new()
        {
            ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate?.Issuer == DevCertIssuer,
            UseCookies = false,
            AllowAutoRedirect = false
        };

        _innerTransport = new HttpClientPipelineTransport(new HttpClient(handler));
    }

    protected override PipelineMessage CreateMessageCore() => _innerTransport.CreateMessage();

    protected override void ProcessCore(PipelineMessage message)
    {
        // Redirect the request to the test proxy
        RedirectToTestProxy(message);

        // Process using the inner transport
        _innerTransport.Process(message);
    }

    protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        // Redirect the request to the test proxy
        RedirectToTestProxy(message);

        // Process using the inner transport
        await _innerTransport.ProcessAsync(message).ConfigureAwait(false);
    }

    private void RedirectToTestProxy(PipelineMessage message)
    {
        if (message?.Request?.Uri == null)
        {
            return;
        }

        // Get the test proxy URI from the recording
        Uri proxyUri = GetProxyUri();
        if (proxyUri == null)
        {
            return;
        }

        // Store the original URI
        Uri originalUri = message.Request.Uri;

        // Create the proxied URI by replacing the scheme and authority
        var builder = new UriBuilder(originalUri)
        {
            Scheme = proxyUri.Scheme,
            Host = proxyUri.Host,
            Port = proxyUri.Port
        };

        message.Request.Uri = builder.Uri;

        // Add headers required by test proxy
        message.Request.Headers.Add("x-recording-upstream-base-uri", $"{originalUri.Scheme}://{originalUri.Authority}");
        message.Request.Headers.Add("x-recording-id", _recording.RecordingId);
        message.Request.Headers.Add("x-recording-mode", GetRecordingMode(_recording.Mode));
    }

    private Uri GetProxyUri()
    {
        try
        {
            if (_recording != null)
            {
                // Get the TestProxy object from the TestRecording
                FieldInfo proxyField = typeof(TestRecording).GetField("_proxy", BindingFlags.NonPublic | BindingFlags.Instance);
                if (proxyField != null)
                {
                    var proxy = proxyField.GetValue(_recording);
                    if (proxy != null)
                    {
                        Type proxyType = proxy.GetType();

                        // Get the HTTPS port (default to HTTPS for the proxy)
                        PropertyInfo httpsPortProperty = proxyType.GetProperty("ProxyPortHttps");
                        if (httpsPortProperty != null)
                        {
                            var httpsPort = (int?)httpsPortProperty.GetValue(proxy);
                            if (httpsPort.HasValue)
                            {
                                return new Uri($"https://localhost:{httpsPort.Value}");
                            }
                        }

                        // Fallback to HTTP port if HTTPS is not available
                        PropertyInfo httpPortProperty = proxyType.GetProperty("ProxyPortHttp");
                        if (httpPortProperty != null)
                        {
                            var httpPort = (int?)httpPortProperty.GetValue(proxy);
                            if (httpPort.HasValue)
                            {
                                return new Uri($"http://localhost:{httpPort.Value}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting proxy URI: {ex.Message}");
        }

        // Default fallback - should rarely be used now
        return new Uri("https://localhost:5001");
    }

    private static string GetRecordingMode(RecordedTestMode mode)
    {
        return mode switch
        {
            RecordedTestMode.Record => "record",
            RecordedTestMode.Playback => "playback",
            _ => "live"
        };
    }
}
