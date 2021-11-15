// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    internal class ProxyPolicy : HttpPipelinePolicy
    {
        private readonly string _recordingId;
        private readonly RecordedTestMode _mode;
        private readonly TestRecording _recording;

        public ProxyPolicy(TestRecording recording)
        {
            _recording = recording;
            _recordingId = recording.RecordingId;
            _mode = recording.Mode;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessInternalAsync(message, pipeline, true);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessInternalAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessInternalAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            RedirectToTestProxy(message);

            if (async)
            {
                await ProcessNextAsync(message, pipeline);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            _recording.HasRequests = true;
            // TODO see if we can get a response header rather than needing to parse the content
            if (message.Response.Status == 404 && message.Response.Content.ToString().Contains("Unable to find a record"))
            {
                throw new TestRecordingMismatchException(message.Response.Content.ToString());
            }
        }

        // copied from https://github.com/Azure/azure-sdk-for-net/blob/main/common/Perf/Azure.Test.Perf/TestProxyPolicy.cs
        private void RedirectToTestProxy(HttpMessage message)
        {
            var request = message.Request;
            request.Headers.SetValue("x-recording-id", _recordingId);
            request.Headers.SetValue("x-recording-mode", _mode.ToString().ToLower());

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

            request.Uri.Host = "127.0.0.1";
            request.Uri.Port = request.Uri.Scheme == "https" ? _recording.ProxyPortHttps : _recording.ProxyPortHttp;

            lock (_recording.Random)
            {
                request.ClientRequestId = _recording.Random.NewGuid().ToString("N");
            }
        }
    }
}