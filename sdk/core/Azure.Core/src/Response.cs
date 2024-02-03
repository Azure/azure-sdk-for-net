// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents the HTTP response from the service.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Response : PipelineResponse
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Gets the client request id that was sent to the server as <c>x-ms-client-request-id</c> headers.
        /// </summary>
        public abstract string ClientRequestId { get; set; }

        /// <summary>
        /// Get the HTTP response headers.
        /// </summary>
        // TODO: is is possible to not new-slot this?
        public new virtual ResponseHeaders Headers => new ResponseHeaders(this);

        /// <summary>
        /// Gets the contents of HTTP response, if it is available.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException"/> when <see cref="PipelineResponse.ContentStream"/> is not a <see cref="MemoryStream"/>.
        /// </remarks>
        public new virtual BinaryData Content => base.Content;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override PipelineResponseHeaders GetHeadersCore()
        {
            // TODO: we'll need to add an adapter in case someone were to override this.
            throw new NotImplementedException();
        }

        internal HttpMessageSanitizer Sanitizer { get; set; } = HttpMessageSanitizer.Default;

        internal RequestFailedDetailsParser? RequestFailedDetailsParser { get; set; }

        internal void SetIsError(bool value) => SetIsErrorCore(value);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="isError"></param>
        // Azure.Core overrides this only so it can seal it.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override void SetIsErrorCore(bool isError)
            => base.SetIsErrorCore(isError);

        /// <summary>
        /// Returns header value if the header is stored in the collection. If header has multiple values they are going to be joined with a comma.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The reference to populate with value.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        protected internal abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);

        /// <summary>
        /// Returns header values if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="values">The reference to populate with values.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        protected internal abstract bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values);

        /// <summary>
        /// Returns <c>true</c> if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        protected internal abstract bool ContainsHeader(string name);

        /// <summary>
        /// Returns an iterator for enumerating <see cref="HttpHeader"/> in the response.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/> enumerating <see cref="HttpHeader"/> in the response.</returns>
        protected internal abstract IEnumerable<HttpHeader> EnumerateHeaders();

        /// <summary>
        /// Creates a new instance of <see cref="Response{T}"/> with the provided value and HTTP response.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="response">The HTTP response.</param>
        /// <returns>A new instance of <see cref="Response{T}"/> with the provided value and HTTP response.</returns>
        public static Response<T> FromValue<T>(T value, Response response)
            => new AzureCoreResponse<T>(value, response);

        /// <summary>
        /// Returns the string representation of this <see cref="Response"/>.
        /// </summary>
        /// <returns>The string representation of this <see cref="Response"/></returns>
        public override string ToString()
        {
            return $"Status: {Status}, ReasonPhrase: {ReasonPhrase}";
        }

        internal static void DisposeStreamIfNotBuffered(ref Stream? stream)
        {
            // We want to keep the ContentStream readable
            // even after the response is disposed but only if it's a
            // buffered memory stream otherwise we can leave a network
            // connection hanging open
            if (stream is not MemoryStream)
            {
                stream?.Dispose();
                stream = null;
            }
        }

        #region Private implementation subtypes of abstract Response types
        private class AzureCoreResponse<T> : Response<T>
        {
            public AzureCoreResponse(T value, Response response)
                : base(value, response) { }
        }

        internal class AzureCoreDefaultResponse : Response
        {
            private readonly string DefaultMessage = "Types derived from abstract Response<T> must provide an implementation of the virtual GetRawResponse method that returns a non-null Response value.";

            public override string ClientRequestId
            {
                get => throw new NotSupportedException(DefaultMessage);
                set => throw new NotSupportedException(DefaultMessage);
            }

            public override int Status => throw new NotSupportedException(DefaultMessage);

            public override string ReasonPhrase => throw new NotSupportedException(DefaultMessage);

            public override Stream? ContentStream
            {
                get => throw new NotSupportedException(DefaultMessage);
                set => throw new NotSupportedException(DefaultMessage);
            }

            protected override PipelineResponseHeaders GetHeadersCore()
            {
                throw new NotSupportedException(DefaultMessage);
            }

            public override void Dispose()
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override bool ContainsHeader(string name)
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                throw new NotSupportedException(DefaultMessage);
            }
        }
        #endregion
    }
}
