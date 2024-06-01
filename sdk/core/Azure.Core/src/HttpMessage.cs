// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents a context flowing through the <see cref="HttpPipeline"/>.
    /// </summary>
    public sealed class HttpMessage : PipelineMessage
    {
        /// <summary>
        /// Creates a new instance of <see cref="HttpMessage"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="responseClassifier">The response classifier.</param>
        public HttpMessage(Request request, ResponseClassifier responseClassifier)
            : base(request)
        {
            Argument.AssertNotNull(request, nameof(request));

            ResponseClassifier = responseClassifier;
            NetworkTimeout = request.NetworkTimeout ?? ClientOptions.DefaultNetworkTimeout;
        }

        /// <summary>
        /// Gets the <see cref="Request"/> associated with this message.
        /// </summary>
        public new Request Request { get => (Request)base.Request; }

        /// <summary>
        /// Gets the <see cref="Response"/> associated with this message. Throws an exception if it wasn't set yet.
        /// To avoid the exception use <see cref="HasResponse"/> property to check.
        /// </summary>
        public new Response Response
        {
            get
            {
                if (base.Response is null)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"""
                        {nameof(Response)} is not set on this message.  This
                        may be because the message was not sent via
                        pipeline.Send, the pipeline transport did not populate
                        the response, or because {nameof(ExtractResponse)} was
                        called. You can check the {nameof(HasResponse)}
                        property to test whether the message has a response
                        value before accessing the {nameof(Response)} property.
                        """);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return (Response)base.Response;
            }

            set => base.Response = value;
        }

        /// <summary>
        /// Gets the value indicating if the response is set on this message.
        /// </summary>
        public bool HasResponse => base.Response is not null;

        internal void ClearResponse() => Response = null!;

        /// <summary>
        /// The <see cref="ResponseClassifier"/> instance to use for response classification during pipeline invocation.
        /// </summary>
        public new ResponseClassifier ResponseClassifier
        {
            get => base.ResponseClassifier switch
            {
                ResponseClassifier responseClassifier => responseClassifier,
                PipelineMessageClassifier messageClassifier => new ResponseClassifier.PipelineMessageClassifierAdapter(messageClassifier)
            };

            set => base.ResponseClassifier = value;
        }

        internal int RetryNumber { get; set; }

        internal DateTimeOffset ProcessingStartTime { get; set; }

        internal void SetCancellationToken(CancellationToken cancellationToken)
            => CancellationToken = cancellationToken;

        /// <summary>
        /// The processing context for the message.
        /// </summary>
        public MessageProcessingContext ProcessingContext => new(this);

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; set; }

        internal static HttpMessage GetHttpMessage(PipelineMessage message, string? errorMessage = default)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for PipelineMessage: '{message?.GetType()}'. {errorMessage}");
            }

            return httpMessage;
        }

        #region Message Properties

        /// <summary>
        /// Gets a property that modifies the pipeline behavior. Please refer to individual policies documentation on what properties it supports.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns><c>true</c> if property exists, otherwise. <c>false</c>.</returns>
        public bool TryGetProperty(string name, out object? value)
        {
            value = null;
            if (!TryGetProperty(typeof(MessagePropertyKey), out var rawValue))
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
            if (!TryGetProperty(typeof(MessagePropertyKey), out var rawValue))
            {
                properties = new Dictionary<string, object>();
                SetProperty(typeof(MessagePropertyKey), properties);
            }
            else
            {
                properties = (Dictionary<string, object>)rawValue!;
            }
            properties[name] = value;
        }

        /// <summary>
        /// Exists as a private key entry into the property bag for stashing string keyed entries in the Type keyed dictionary.
        /// </summary>
        private class MessagePropertyKey { }
        #endregion

        /// <summary>
        /// Returns the response content stream and releases its ownership to the caller.
        /// After this method has been called, any use of the
        /// <see cref="PipelineResponse.ContentStream"/> or <see cref="Response.Content"/>
        /// properties on this message will result in an <see cref="InvalidOperationException"/>
        /// being thrown.
        /// </summary>
        /// <returns>The content stream, or <code>null</code> if <see cref="Response"/>
        /// did not have content set.</returns>
        public Stream? ExtractResponseContent()
        {
            switch (Response?.ContentStream)
            {
                case ResponseShouldNotBeUsedStream responseContent:
                    return responseContent.Original;
                case Stream stream:
                    Response.ContentStream = new ResponseShouldNotBeUsedStream(Response.ContentStream);
                    return stream;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the value of the <see cref="Response"/> property and
        /// transfers dispose ownership of the response to the caller. After
        /// calling this method, the <see cref="Response"/> property will be
        /// null and the caller will be responsible for disposing the returned
        /// value, which may hold a live network stream.
        /// </summary>
        public new Response? ExtractResponse()
            => (Response?)base.ExtractResponse();

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
