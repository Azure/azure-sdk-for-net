// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents the HTTP response from the service.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Response : IDisposable
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public abstract int Status { get; }

        /// <summary>
        /// Gets the HTTP reason phrase.
        /// </summary>
        public abstract string ReasonPhrase { get; }

        /// <summary>
        /// Gets the contents of HTTP response. Returns <c>null</c> for responses without content.
        /// </summary>
        public abstract Stream? ContentStream { get; set; }

        /// <summary>
        /// Gets the client request id that was sent to the server as <c>x-ms-client-request-id</c> headers.
        /// </summary>
        public abstract string ClientRequestId { get; set; }

        /// <summary>
        /// Get the HTTP response headers.
        /// </summary>
        public virtual ResponseHeaders Headers => new ResponseHeaders(this);

        /// <summary>
        /// Gets the contents of HTTP response, if it is available.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException"/> when <see cref="ContentStream"/> is not a <see cref="MemoryStream"/>.
        /// </remarks>
        public virtual BinaryData Content
        {
            get
            {
                if (ContentStream == null)
                {
                    return BinaryData.Empty;
                }

                MemoryStream? memoryContent = ContentStream as MemoryStream;

                if (memoryContent == null)
                {
                    throw new InvalidOperationException($"The response is not fully buffered.");
                }

                if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment))
                {
                    return new BinaryData(segment.AsMemory());
                }
                else
                {
                    return new BinaryData(memoryContent.ToArray());
                }
            }
        }

        /// <summary>
        /// Frees resources held by this <see cref="Response"/> instance.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Indicates whether the status code of the returned response is considered
        /// an error code.
        /// </summary>
        public virtual bool IsError { get; internal set; }

        internal HttpMessageSanitizer Sanitizer { get; set; } = HttpMessageSanitizer.Default;

        internal RequestFailedDetailsParser? RequestFailedDetailsParser { get; set; }

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
        {
            return new ValueResponse<T>(response, value);
        }

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
    }
}
