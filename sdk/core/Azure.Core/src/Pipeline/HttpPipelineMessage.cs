// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Azure.Core.Http;

namespace Azure.Core.Pipeline
{
    public sealed class HttpPipelineMessage : IDisposable
    {
        private Dictionary<string, object>? _properties;

        private Response? _response;

        public HttpPipelineMessage(Request request, ResponseClassifier responseClassifier)
        {
            Request = request;
            ResponseClassifier = responseClassifier;
            BufferResponse = true;
        }

        public Request Request { get; set; }

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

        public bool HasResponse => _response != null;

        public CancellationToken CancellationToken { get; internal set; }

        public ResponseClassifier ResponseClassifier { get; }

        /// <summary>
        /// Gets or sets the value indicating if response would be buffered as part of the pipeline. Defaults to true.
        /// </summary>
        public bool BufferResponse { get; set; }

        public bool TryGetProperty(string name, out object? value)
        {
            value = null;
            return _properties?.TryGetValue(name, out value) == true;
        }

        public void SetProperty(string name, object value)
        {
            _properties ??= new Dictionary<string, object>();

            _properties[name] = value;
        }

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
