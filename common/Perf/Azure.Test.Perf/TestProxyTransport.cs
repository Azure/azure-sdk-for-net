// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Test.Perf
{
    public class TestProxyTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _transport;
        private readonly Uri _uri;

        public string RecordingId { get; set; }
        public string Mode { get; set; }

        public TestProxyTransport(HttpPipelineTransport transport, Uri uri)
        {
            _transport = transport;
            _uri = uri;
        }

        public override Request CreateRequest()
        {
            return _transport.CreateRequest();
        }

        public override void Process(HttpMessage message)
        {
            RedirectToTestProxy(message);
            _transport.Process(message);
        }

        public override ValueTask ProcessAsync(HttpMessage message)
        {
            RedirectToTestProxy(message);
            return _transport.ProcessAsync(message);
        }

        private void RedirectToTestProxy(HttpMessage message)
        {
            if (!string.IsNullOrEmpty(RecordingId) && !string.IsNullOrEmpty(Mode))
            {
                message.Request.Headers.Add("x-recording-id", RecordingId);
                message.Request.Headers.Add("x-recording-mode", Mode);
                message.Request.Headers.Add("x-recording-remove", bool.FalseString);

                var baseUri = new RequestUriBuilder()
                {
                    Scheme = message.Request.Uri.Scheme,
                    Host = message.Request.Uri.Host,
                    Port = message.Request.Uri.Port,
                };
                message.Request.Headers.Add("x-recording-upstream-base-uri", baseUri.ToString());

                message.Request.Uri.Scheme = _uri.Scheme;
                message.Request.Uri.Host = _uri.Host;
                message.Request.Uri.Port = _uri.Port;
            }
        }
    }
}
