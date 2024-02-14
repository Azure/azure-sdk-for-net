﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class HttpPipelineTransportPolicy : HttpPipelinePolicy
    {
        private readonly HttpPipelineTransport _transport;
        private readonly HttpMessageSanitizer _sanitizer;
        private readonly RequestFailedDetailsParser? _errorParser;

        public HttpPipelineTransportPolicy(HttpPipelineTransport transport, HttpMessageSanitizer sanitizer, RequestFailedDetailsParser? failureContentExtractor = null)
        {
            _transport = transport;
            _sanitizer = sanitizer;
            _errorParser = failureContentExtractor;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            await _transport.ProcessInternalAsync(message).ConfigureAwait(false);

            message.Response.RequestFailedDetailsParser = _errorParser;
            message.Response.Sanitizer = _sanitizer;
            message.Response.SetIsError(message.ResponseClassifier.IsErrorResponse(message));
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            _transport.ProcessInternal(message);

            message.Response.RequestFailedDetailsParser = _errorParser;
            message.Response.Sanitizer = _sanitizer;
            message.Response.SetIsError(message.ResponseClassifier.IsErrorResponse(message));
        }
    }
}
