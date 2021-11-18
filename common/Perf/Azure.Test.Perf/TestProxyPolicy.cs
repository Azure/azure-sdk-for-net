// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public class TestProxyPolicy : HttpPipelinePolicy
    {
        private readonly Uri _uri;

        public string RecordingId { get; set; }
        public string Mode { get; set; }

        public TestProxyPolicy(Uri uri)
        {
            _uri = uri;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!string.IsNullOrEmpty(RecordingId) && !string.IsNullOrEmpty(Mode))
            {
                RedirectToTestProxy(message);
            }
            ProcessNext(message, pipeline);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!string.IsNullOrEmpty(RecordingId) && !string.IsNullOrEmpty(Mode))
            {
                RedirectToTestProxy(message);
            }
            return ProcessNextAsync(message, pipeline);
        }

        protected void RedirectToTestProxy(HttpMessage message)
        {
            message.Request.Headers.SetValue("x-recording-id", RecordingId);
            message.Request.Headers.SetValue("x-recording-mode", Mode);
            message.Request.Headers.SetValue("x-recording-remove", bool.FalseString);

            // Ensure x-recording-upstream-base-uri header is only set once, since the same HttpMessage will be reused on retries
            if (!message.Request.Headers.Contains("x-recording-upstream-base-uri"))
            {
                var baseUri = new RequestUriBuilder()
                {
                    Scheme = message.Request.Uri.Scheme,
                    Host = message.Request.Uri.Host,
                    Port = message.Request.Uri.Port,
                };
                message.Request.Headers.SetValue("x-recording-upstream-base-uri", baseUri.ToString());
            }

            message.Request.Uri.Scheme = _uri.Scheme;
            message.Request.Uri.Host = _uri.Host;
            message.Request.Uri.Port = _uri.Port;
        }
    }
}
