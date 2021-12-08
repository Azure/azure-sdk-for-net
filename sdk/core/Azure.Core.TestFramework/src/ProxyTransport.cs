// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
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

        private static readonly RemoteCertificateValidationCallback ServerCertificateCustomValidationCallback =
            (_, certificate, _, _) => certificate.Issuer == TestProxy.DevCertIssuer;

        public ProxyTransport(TestProxy proxy, HttpPipelineTransport transport, TestRecording recording)
        {
            if (transport is HttpClientTransport)
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (_, certificate, _, _) => certificate.Issuer == TestProxy.DevCertIssuer
                };
                _innerTransport = new HttpClientTransport(handler);
            }
            // HttpWebRequestTransport
            else
            {
                _isWebRequestTransport = true;
                _innerTransport = transport;
            }
            _recording = recording;
            _proxy = proxy;
        }

        public override void Process(HttpMessage message)
        {
            RedirectToTestProxy(message);
            _innerTransport.Process(message);
            ProcessResponseAsync(message, false).EnsureCompleted();
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            RedirectToTestProxy(message);
            await _innerTransport.ProcessAsync(message);
            await ProcessResponseAsync(message, true);
        }

        private async Task ProcessResponseAsync(HttpMessage message, bool async)
        {
            if (message.Response.Headers.Contains("x-request-mismatch"))
            {
                var streamreader = new StreamReader(message.Response.ContentStream);
                string response;
                if (async)
                {
                    response = await streamreader.ReadToEndAsync();
                }
                else
                {
                    response = streamreader.ReadToEnd();
                }
                throw new TestRecordingMismatchException(response);
            }

            // revert the original URI - this is important for tests that rely on aspects of the URI in the pipeline
            // e.g. KeyVault caches tokens based on URI
            message.Request.Headers.TryGetValue("x-recording-upstream-base-uri", out string original);

            var originalBaseUri = new Uri(original);
            message.Request.Uri.Scheme = originalBaseUri.Scheme;
            message.Request.Uri.Host = originalBaseUri.Host;
            message.Request.Uri.Port = originalBaseUri.Port;

            if (_isWebRequestTransport)
            {
                ServicePointManager.ServerCertificateValidationCallback -= ServerCertificateCustomValidationCallback;
            }
        }

        public override Request CreateRequest()
        {
            if (_recording.MismatchException != null)
            {
                throw _recording.MismatchException;
            }

            var request = _innerTransport.CreateRequest();
            lock (_recording.Random)
            {
                // Make sure ClientRequestId are the same across request and response
                request.ClientRequestId = _recording.Random.NewGuid().ToString("N");
            }
            return request;
        }

        // copied from https://github.com/Azure/azure-sdk-for-net/blob/main/common/Perf/Azure.Test.Perf/TestProxyPolicy.cs
        private void RedirectToTestProxy(HttpMessage message)
        {
            var request = message.Request;
            request.Headers.SetValue("x-recording-id", _recording.RecordingId);
            request.Headers.SetValue("x-recording-mode", _recording.Mode.ToString().ToLower());

            // Ensure x-recording-upstream-base-uri header is only set once, since the same HttpMessage will be reused on retries
            if (!request.Headers.Contains("x-recording-upstream-base-uri"))
            {
                var baseUri = new RequestUriBuilder()
                {
                    Scheme = request.Uri.Scheme,
                    Host = request.Uri.Host,
                    Port = request.Uri.Port,
                };
                request.Headers.SetValue("x-recording-upstream-base-uri", baseUri.ToString());
            }

            // for some reason using localhost instead of the ip address causes slowness when combined with SSL callback being specified
            request.Uri.Host = TestProxy.IpAddress;
            request.Uri.Port = request.Uri.Scheme == "https" ? _proxy.ProxyPortHttps.Value : _proxy.ProxyPortHttp.Value;

            if (_isWebRequestTransport)
            {
                ServicePointManager.ServerCertificateValidationCallback += ServerCertificateCustomValidationCallback;
            }
        }
    }
}