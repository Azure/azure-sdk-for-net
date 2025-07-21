// Copyright (c) Microsoft Corporation. All rights reserved.
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

            await _transport.ProcessAsync(message).ConfigureAwait(false);

            message.Response.RequestFailedDetailsParser = _errorParser;
            message.Response.Sanitizer = _sanitizer;
            message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            _transport.Process(message);

            message.Response.RequestFailedDetailsParser = _errorParser;
            message.Response.Sanitizer = _sanitizer;
            message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
        }
        /// <summary>
        /// Creates a new instance of <see cref="HttpPipelineTransportPolicy"/> with the specified
        /// <paramref name="transport"/>, <paramref name="sanitizer"/>, and <paramref name="errorParser"/>.
        /// </summary>
        /// <param name="transport">The transport to use for processing HTTP messages.</param>
        /// <param name="sanitizer">The sanitizer to use for sanitizing HTTP messages.</param>
        /// <param name="errorParser">The parser to use for extracting error details from HTTP responses.</param>
        /// <returns>A new instance of <see cref="HttpPipelineTransportPolicy"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="transport"/> is null.</exception>
        public HttpPipelineTransportPolicy Clone(HttpPipelineTransport transport, HttpMessageSanitizer? sanitizer = null, RequestFailedDetailsParser? errorParser = null)
        {
            if (transport == null)
            {
                throw new ArgumentNullException(nameof(transport));
            }

            return new HttpPipelineTransportPolicy(transport, sanitizer ?? _sanitizer, errorParser ?? _errorParser);
        }
    }
}
