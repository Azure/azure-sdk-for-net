// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    public class ProxyTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _innerTransport;
        private readonly TestRecording _recording;
        private readonly TestProxy _proxy;
        private readonly bool _isWebRequestTransport;

        private const string DevCertIssuer = "CN=localhost";
        private const string FiddlerCertIssuer = "CN=DO_NOT_TRUST_FiddlerRoot, O=DO_NOT_TRUST, OU=Created by http://www.fiddler2.com";

        private readonly RemoteCertificateValidationCallback _serverCertificateCustomValidationCallback;

        private readonly Func<EntryRecordModel> _filter;
        private readonly string _proxyHost;

        public ProxyTransport(TestProxy proxy, HttpPipelineTransport transport, TestRecording recording, Func<EntryRecordModel> filter)
        {
            _recording = recording;
            _proxy = proxy;
            _filter = filter;

            bool useFiddler = TestEnvironment.EnableFiddler;
            string certIssuer = useFiddler ? FiddlerCertIssuer : DevCertIssuer;
            _proxyHost = useFiddler ? "ipv4.fiddler" : TestProxy.IpAddress;

            if (transport is HttpClientTransport)
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate.Issuer == certIssuer,
                    // copied from HttpClientTransport - not needed for HttpWebRequestTransport case as cookies are already off by default and can't be turned on
                    UseCookies = AppContextSwitchHelper.GetConfigValue(
                        "Azure.Core.Pipeline.HttpClientTransport.EnableCookies",
                        "AZURE_CORE_HTTPCLIENT_ENABLE_COOKIES"),
                    AllowAutoRedirect = false
                };
                _innerTransport = new HttpClientTransport(handler);
            }
            // HttpWebRequestTransport
            else
            {
                _isWebRequestTransport = true;
                _innerTransport = transport;
                _serverCertificateCustomValidationCallback = (_, certificate, _, _) => certificate.Issuer == certIssuer;
            }
        }

        public override void Process(HttpMessage message) =>
            ProcessAsyncInternalAsync(message, false).EnsureCompleted();

        public override async ValueTask ProcessAsync(HttpMessage message) =>
            await ProcessAsyncInternalAsync(message, true);

        private async Task ProcessAsyncInternalAsync(HttpMessage message, bool async)
        {
            if (_recording.Mode == RecordedTestMode.Playback && _filter() == EntryRecordModel.DoNotRecord)
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
                    await _innerTransport.ProcessAsync(message);
                }
                else
                {
                    _innerTransport.Process(message);
                }

                await ProcessResponseAsync(message, true);
            }
            finally
            {
                // revert the original URI - this is important for tests that rely on aspects of the URI in the pipeline
                // e.g. KeyVault caches tokens based on URI
                message.Request.Headers.TryGetValue("x-recording-upstream-base-uri", out string original);

                var originalBaseUri = new Uri(original);
                message.Request.Uri.Scheme = originalBaseUri.Scheme;
                message.Request.Uri.Host = originalBaseUri.Host;
                message.Request.Uri.Port = originalBaseUri.Port;

                if (_isWebRequestTransport)
                {
#pragma warning disable SYSLIB0014 // ServicePointManager is obsolete and does not affect HttpClient
                    ServicePointManager.ServerCertificateValidationCallback -= _serverCertificateCustomValidationCallback;
#pragma warning restore SYSLIB0014 // ServicePointManager is obsolete and does not affect HttpClient
                }
            }
        }

        private async Task ProcessResponseAsync(HttpMessage message, bool async)
        {
            if (message.HasResponse && message.Response.Headers.Contains("x-request-mismatch"))
            {
                var streamReader = new StreamReader(message.Response.ContentStream);
                string response;
                if (async)
                {
                    response = await streamReader.ReadToEndAsync();
                }
                else
                {
                    response = streamReader.ReadToEnd();
                }
                using var doc = JsonDocument.Parse(response);
                throw new TestRecordingMismatchException(doc.RootElement.GetProperty("Message").GetString());
            }
        }

        public override Request CreateRequest()
        {
            if (_recording.MismatchException != null)
            {
                throw _recording.MismatchException;
            }

            var request = _innerTransport.CreateRequest();
            _recording.HasRequests = true;
            lock (_recording.Random)
            {
                if (_recording.UseDefaultGuidFormatForClientRequestId)
                {
                    // User want the client format to use the default format
                    request.ClientRequestId = _recording.Random.NewGuid().ToString();
                }
                else
                {
                    // Make sure ClientRequestId are the same across request and response
                    request.ClientRequestId = _recording.Random.NewGuid().ToString("N");
                }
            }
            return request;
        }

        // copied from https://github.com/Azure/azure-sdk-for-net/blob/main/common/Perf/Azure.Test.Perf/TestProxyPolicy.cs
        private void RedirectToTestProxy(HttpMessage message)
        {
            if (_recording.Mode == RecordedTestMode.Record)
            {
                switch (_filter())
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
                if (_filter() == EntryRecordModel.RecordWithoutRequestBody)
                {
                    message.Request.Content = null;
                }
            }

            var request = message.Request;
            request.Headers.SetValue("x-recording-id", _recording.RecordingId);
            request.Headers.SetValue("x-recording-mode", _recording.Mode.ToString().ToLower());

            // Intentionally reset the upstream URI in case the request URI changes between retries - e.g. when using GeoRedundant secondary Storage
            var baseUri = new RequestUriBuilder()
            {
                Scheme = request.Uri.Scheme,
                Host = request.Uri.Host,
                Port = request.Uri.Port,
            };
            request.Headers.SetValue("x-recording-upstream-base-uri", baseUri.ToString());

            request.Uri.Host = _proxyHost;
            request.Uri.Port = request.Uri.Scheme == "https" ? _proxy.ProxyPortHttps.Value : _proxy.ProxyPortHttp.Value;

            if (_isWebRequestTransport)
            {
#pragma warning disable SYSLIB0014 // ServicePointManager is obsolete and does not affect HttpClient
                ServicePointManager.ServerCertificateValidationCallback += _serverCertificateCustomValidationCallback;
#pragma warning disable SYSLIB0014 // ServicePointManager is obsolete and does not affect HttpClient
            }
        }
    }
}
