// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents a context flowing through the <see cref="HttpPipeline"/>.
    /// </summary>
    public sealed class HttpMessage : PipelineMessage
    {
        private ArrayBackedPropertyBag<ulong, object> _propertyBag;
        private Response? _response;

        /// <summary>
        /// Creates a new instance of <see cref="HttpMessage"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="responseClassifier">The response classifier.</param>
        public HttpMessage(Request request, ResponseClassifier responseClassifier)
            : base(ToPipelineRequest(request))
        {
            Argument.AssertNotNull(request, nameof(request));

            _propertyBag = new ArrayBackedPropertyBag<ulong, object>();

            Request = request;
            ResponseClassifier = responseClassifier;
        }

        /// <summary>
        /// Gets the <see cref="Request"/> associated with this message.
        /// </summary>
        public new Request Request { get; }

        /// <summary>
        /// Gets the <see cref="Response"/> associated with this message. Throws an exception if it wasn't set yet.
        /// To avoid the exception use <see cref="HasResponse"/> property to check.
        /// </summary>
        public new Response Response
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

            set
            {
                _response = value;
                base.Response = ToPipelineResponse(value)!;
            }
        }

        /// <summary>
        /// Gets the value indicating if the response is set on this message.
        /// </summary>
        public new bool HasResponse => _response != null || base.HasResponse;

        internal void ClearResponse() => Response = null!;

        /// <summary>
        /// The <see cref="ResponseClassifier"/> instance to use for response classification during pipeline invocation.
        /// </summary>
        // TODO: revisit this per not shadowing anymore
        public ResponseClassifier ResponseClassifier
        {
            get
            {
                if (MessageClassifier is not ResponseClassifier classifier)
                {
                    throw new InvalidOperationException($"Invalid ResponseClassifier set on message: '{base.MessageClassifier}'.");
                }

                return classifier;
            }

            set => MessageClassifier = value;
        }

        /// <summary>
        /// Gets or sets the value indicating if response would be buffered as part of the pipeline. Defaults to true.
        /// </summary>
        public bool BufferResponse
        {
            get => ResponseBufferingPolicy.TryGetBufferResponse(this, out bool bufferResponse) ? bufferResponse : true;
            set => ResponseBufferingPolicy.SetBufferResponse(this, value);
        }

        /// <summary>
        /// Gets or sets the network timeout value for this message. If <c>null</c> the value provided in <see cref="RetryOptions.NetworkTimeout"/> will be used instead.
        /// Defaults to <c>null</c>.
        /// </summary>
        public TimeSpan? NetworkTimeout
        {
            get => ResponseBufferingPolicy.TryGetNetworkTimeout(this, out TimeSpan timeout) ? timeout : null;
            set
            {
                if (value.HasValue)
                {
                    ResponseBufferingPolicy.SetNetworkTimeout(this, value.Value);
                }
            }
        }

        internal int RetryNumber { get; set; }

        internal DateTimeOffset ProcessingStartTime { get; set; }

        /// <summary>
        /// The processing context for the message.
        /// </summary>
        public MessageProcessingContext ProcessingContext => new(this);

        internal void ApplyRequestContext(RequestContext context, ResponseClassifier? classifier)
        {
            context.Freeze();

            // Azure-specific extensibility piece
            if (context.Policies?.Count > 0)
            {
                Policies ??= new(context.Policies.Count);
                Policies.AddRange(context.Policies);
            }

            if (classifier != null)
            {
                ResponseClassifier = context.Apply(classifier);
            }

            context.Apply(this);
        }

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; set; }

        /// <summary>
        /// Gets a property that modifies the pipeline behavior. Please refer to individual policies documentation on what properties it supports.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns><c>true</c> if property exists, otherwise. <c>false</c>.</returns>
        public bool TryGetProperty(string name, out object? value)
        {
            value = null;
            if (_propertyBag.IsEmpty || !_propertyBag.TryGetValue((ulong)typeof(MessagePropertyKey).TypeHandle.Value, out var rawValue))
            {
                return false;
            }
            var properties = (Dictionary<string, object>)rawValue!;
            return properties.TryGetValue(name, out value);
        }

        /// <summary>
        /// Sets a property that modifies the pipeline behavior. Please refer to individual policies documentation on what properties it supports.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        public void SetProperty(string name, object value)
        {
            Dictionary<string, object> properties;
            if (!_propertyBag.TryGetValue((ulong)typeof(MessagePropertyKey).TypeHandle.Value, out var rawValue))
            {
                properties = new Dictionary<string, object>();
                _propertyBag.Set((ulong)typeof(MessagePropertyKey).TypeHandle.Value, properties);
            }
            else
            {
                properties = (Dictionary<string, object>)rawValue!;
            }
            properties[name] = value;
        }

        /// <summary>
        /// Returns the response content stream and releases it ownership to the caller.
        ///
        /// After calling this method, any attempt to use the
        /// <see cref="Response.ContentStream"/> or <see cref="Response.Content"/>
        /// properties on <see cref="Response"/> will result in an exception being thrown.
        /// </summary>
        /// <returns>The content stream, or <code>null</code> if <see cref="Response"/>
        /// did not have content set.</returns>
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

        /// <summary>
        /// Exists as a private key entry into the <see cref="_propertyBag"/> dictionary for stashing string keyed entries in the Type keyed dictionary.
        /// </summary>
        private class MessagePropertyKey { }

        private static MessageRequest ToPipelineRequest(Request request)
        {
            Argument.AssertNotNull(request, nameof(request));

            if (HttpClientTransport.TryGetPipelineRequest(request, out MessageRequest? pipelineRequest))
            {
                return pipelineRequest!;
            }

            // TODO: This may be able to go away when HttpWebTransportRequest inherits from SSMR type.
            return new PipelineRequestAdapter(request);
        }

        private static MessageResponse? ToPipelineResponse(Response response)
        {
            if (response is null)
            {
                return null;
            }

            if (HttpClientTransport.TryGetPipelineResponse(response, out MessageResponse? pipelineResponse))
            {
                return pipelineResponse!;
            }

            // TODO: This may be able to go away when HttpWebTransportResponse inherits from SSMR type.
            return new PipelineResponseAdapter(response);
        }

        /// <summary>
        /// Disposes the request and response.
        /// </summary>
        public override void Dispose()
        {
            Request.Dispose();
            _propertyBag.Dispose();

            var response = _response;
            if (response != null)
            {
                _response = null;
                response.Dispose();
            }

            base.Dispose();
        }
    }
}
