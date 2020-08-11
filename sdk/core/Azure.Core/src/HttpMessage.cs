// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents a context flowing through the <see cref="HttpPipeline"/>.
    /// </summary>
    public sealed class HttpMessage: IDisposable
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
            ResponseClassifier = responseClassifier;
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

        /// <summary>
        /// The <see cref="ResponseClassifier"/> instance to use for response classification during pipeline invocation.
        /// </summary>
        public ResponseClassifier ResponseClassifier { get; }

        /// <summary>
        /// Gets or sets the value indicating if response would be buffered as part of the pipeline. Defaults to true.
        /// </summary>
        public bool BufferResponse { get; set; }

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
        /// Returns the response content stream and releases it ownership to the caller. After calling this methods using <see cref="Azure.Response.ContentStream"/> would result in exception.
        /// </summary>
        /// <returns>The content stream or null if response didn't have any.</returns>
        public Stream? ExtractResponseContent()
        {
            switch (_response?.ContentStream)
            {
                case ResponseShouldNotBeUsedStream responseContent:
                    return responseContent.Original;
                case Stream stream :
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

        private class ResponseShouldNotBeUsedStream: Stream
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
