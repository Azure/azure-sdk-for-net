// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents a context flowing through the <see cref="HttpPipeline"/>.
    /// </summary>
    public sealed class HttpMessage : IDisposable
    {
        private Dictionary<string, object>? _properties;

        private Response? _response;

        /// <summary>
        /// Creates a new instance of <see cref="HttpMessage"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="responseClassifier">The response classifier.</param>
        public HttpMessage(Request request, ResponseClassifier responseClassifier)
        {
            Request = request;
            _responseClassifier = responseClassifier;
            BufferResponse = true;
        }

        /// <summary>
        /// Gets the <see cref="Request"/> associated with this message.
        /// </summary>
        public Request Request { get; }

        /// <summary>
        /// Gets the <see cref="Response"/> associated with this message. Throws an exception if it wasn't set yet.
        /// To avoid the exception use <see cref="HasResponse"/> property to check.
        /// </summary>
        public Response Response
        {
            get
            {
                if (_response == null)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException("Response was not set, make sure SendAsync was called");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _response;
            }
            set => _response = value;
        }

        /// <summary>
        /// Gets the value indicating if the response is set on this message.
        /// </summary>
        public bool HasResponse => _response != null;

        /// <summary>
        /// The <see cref="System.Threading.CancellationToken"/> to be used during the <see cref="HttpMessage"/> processing.
        /// </summary>
        public CancellationToken CancellationToken { get; internal set; }

        private ResponseClassifier _responseClassifier;
        /// <summary>
        /// The <see cref="ResponseClassifier"/> instance to use for response classification during pipeline invocation.
        /// </summary>
        public ResponseClassifier ResponseClassifier
        {
            get
            {
                return _responseClassifier;
            }
            set
            {
                _responseClassifier = value;

                if (TryCustomizeClassifier(out var classifier))
                {
                    _responseClassifier = classifier;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value indicating if response would be buffered as part of the pipeline. Defaults to true.
        /// </summary>
        public bool BufferResponse { get; set; }

        /// <summary>
        /// Gets or sets the network timeout value for this message. If <c>null</c> the value provided in <see cref="RetryOptions.NetworkTimeout"/> would be used instead.
        /// Defaults to <c>null</c>.
        /// </summary>
        public TimeSpan? NetworkTimeout { get; set; }

        private bool _contextApplied;
        internal void ApplyRequestContext(RequestContext? context)
        {
            Debug.Assert(!_contextApplied, "ApplyRequestContext should only be called once.");
            _contextApplied = true;

            if (context == null)
            {
                return;
            }

            context.Freeze();

            if (context.Policies?.Count > 0)
            {
                Policies ??= new(context.Policies.Count);
                Policies.AddRange(context.Policies);
            }

            if (context.StatusCodes != null || context.MessageClassifiers != null)
            {
                _statusCodes = context.StatusCodes;
                _messageClassifiers = context.MessageClassifiers;

                if (TryCustomizeClassifier(out ResponseClassifier classifier))
                {
                    _responseClassifier = classifier;
                }
            }
        }

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; set; }

        private List<(int Status, bool IsError)>? _statusCodes { get; set; }

        private HttpMessageClassifier[]? _messageClassifiers { get; set; }

        private bool TryCustomizeClassifier(out ResponseClassifier classifier)
        {
            classifier = ResponseClassifier;

            // only customize if we have customizations from RequestContext
            if (_statusCodes == null && _messageClassifiers == null)
            {
                return false;
            }

            StatusCodeClassifier? scc = ResponseClassifier as StatusCodeClassifier;
            if (scc != null)
            {
                // don't make modifications to a static shared classifier.
                var custom = scc.Clone();

                if (_statusCodes?.Count > 0)
                {
                    foreach (var classification in _statusCodes)
                    {
                        custom.AddClassifier(classification.Status, classification.IsError);
                    }
                }

                if (_messageClassifiers != null)
                {
                    custom.TryClassifiers = _messageClassifiers;
                }

                classifier = custom;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a property that modifies the pipeline behavior. Please refer to individual policies documentation on what properties it supports.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns><c>true</c> if property exists, otherwise. <c>false</c>.</returns>
        public bool TryGetProperty(string name, out object? value)
        {
            value = null;
            return _properties?.TryGetValue(name, out value) == true;
        }

        /// <summary>
        /// Sets a property that modifies the pipeline behavior. Please refer to individual policies documentation on what properties it supports.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        public void SetProperty(string name, object value)
        {
            _properties ??= new Dictionary<string, object>();

            _properties[name] = value;
        }

        /// <summary>
        /// Returns the response content stream and releases it ownership to the caller. After calling this methods using <see cref="Azure.Response.ContentStream"/> or <see cref="Azure.Response.Content"/> would result in exception.
        /// </summary>
        /// <returns>The content stream or null if response didn't have any.</returns>
        public Stream? ExtractResponseContent()
        {
            switch (_response?.ContentStream)
            {
                case ResponseShouldNotBeUsedStream responseContent:
                    return responseContent.Original;
                case Stream stream:
                    _response.ContentStream = new ResponseShouldNotBeUsedStream(_response.ContentStream);
                    return stream;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Disposes the request and response.
        /// </summary>
        public void Dispose()
        {
            Request?.Dispose();
            _response?.Dispose();
        }

        private class ResponseShouldNotBeUsedStream : Stream
        {
            public Stream Original { get; }

            public ResponseShouldNotBeUsedStream(Stream original)
            {
                Original = original;
            }

            private static Exception CreateException()
            {
                return new InvalidOperationException("The operation has called ExtractResponseContent and will provide the stream as part of its response type.");
            }

            public override void Flush()
            {
                throw CreateException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw CreateException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw CreateException();
            }

            public override void SetLength(long value)
            {
                throw CreateException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw CreateException();
            }

            public override bool CanRead => throw CreateException();
            public override bool CanSeek => throw CreateException();
            public override bool CanWrite => throw CreateException();
            public override long Length => throw CreateException();

            public override long Position
            {
                get => throw CreateException();
                set => throw CreateException();
            }
        }
    }
}
