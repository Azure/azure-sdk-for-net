// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Perf
{
    public class TestProxyTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _transport;
        private readonly string _host;
        private readonly int? _port;

        public string RecordingId { get; set; }
        public string Mode { get; set; }

        public TestProxyTransport(HttpPipelineTransport transport, string host, int? port)
        {
            _transport = transport;
            _host = host;
            _port = port;
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
            if (!string.IsNullOrEmpty(_host) && !string.IsNullOrEmpty(RecordingId))
            {
                message.Request.Headers.Add("x-recording-id", RecordingId);
                message.Request.Headers.Add("x-recording-mode", Mode);

                var baseUri = new RequestUriBuilder()
                {
                    Scheme = message.Request.Uri.Scheme,
                    Host = message.Request.Uri.Host,
                    Port = message.Request.Uri.Port,
                };
                message.Request.Headers.Add("x-recording-upstream-base-uri", baseUri.ToString());

                message.Request.Uri.Host = _host;
                if (_port.HasValue)
                {
                    message.Request.Uri.Port = _port.Value;
                }
            }
        }
    }
}
