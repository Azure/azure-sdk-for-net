// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class HttpPipelineTransportPolicy : HttpPipelinePolicy
    {
        private volatile HttpPipelineTransport _transport;
        private readonly HttpMessageSanitizer _sanitizer;
        private readonly RequestFailedDetailsParser? _errorParser;

        public HttpPipelineTransport Transport => _transport;

        public HttpPipelineTransportPolicy(HttpPipelineTransport transport, HttpMessageSanitizer sanitizer, RequestFailedDetailsParser? failureContentExtractor = null)
        {
            _transport = transport;
            _sanitizer = sanitizer;
            _errorParser = failureContentExtractor;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            // Capture current transport reference - this ensures that even if _transport
            // is swapped during execution, this call will complete with the original transport
            var currentTransport = _transport;

            await currentTransport.ProcessAsync(message).ConfigureAwait(false);

            message.Response.RequestFailedDetailsParser = _errorParser;
            message.Response.Sanitizer = _sanitizer;
            message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            // Capture current transport reference - this ensures that even if _transport
            // is swapped during execution, this call will complete with the original transport
            var currentTransport = _transport;

            currentTransport.Process(message);

            message.Response.RequestFailedDetailsParser = _errorParser;
            message.Response.Sanitizer = _sanitizer;
            message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
        }
    }
}
