// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Represents an HTTP header.
    /// </summary>
    public readonly struct HttpHeader : IEquatable<HttpHeader>
    {
        /// <summary>
        /// Creates a new instance of <see cref="HttpHeader"/> with provided name and value.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        public HttpHeader(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} shouldn't be null or empty", nameof(name));
            }

            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets header name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets header value. If the header has multiple values they would be joined with a comma. To get separate values use <see cref="RequestHeaders.TryGetValues"/> or <see cref="ResponseHeaders.TryGetValues"/>.
        /// </summary>
        public string Value { get; }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(Name, StringComparer.OrdinalIgnoreCase);
            hashCode.Add(Value);
            return hashCode.ToHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is HttpHeader header)
            {
                return Equals(header);
            }
            return false;
        }

        /// <inheritdoc/>
        public override string ToString() => $"{Name}:{Value}";

        /// <inheritdoc/>
        public bool Equals(HttpHeader other)
        {
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && Value.Equals(other.Value, StringComparison.Ordinal);
        }

#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary>
        /// Contains names of commonly used headers.
        /// </summary>
        public static class Names
#pragma warning restore CA1034 // Nested types should not be visible
        {
            /// <summary>
            /// Returns. <code>"Date"</code>
            /// </summary>
            public static string Date => "Date";
            /// <summary>
            /// Returns. <code>"x-ms-date"</code>
            /// </summary>
            public static string XMsDate => "x-ms-date";
            /// <summary>
            /// Returns. <code>"Content-Type"</code>
            /// </summary>
            public static string ContentType => "Content-Type";
            /// <summary>
            /// Returns. <code>"Content-Length"</code>
            /// </summary>
            public static string ContentLength => "Content-Length";
            /// <summary>
            /// Returns. <code>"ETag"</code>
            /// </summary>
            public static string ETag => "ETag";
            /// <summary>
            /// Returns. <code>"x-ms-request-id"</code>
            /// </summary>
            public static string XMsRequestId => "x-ms-request-id";
            /// <summary>
            /// Returns. <code>"User-Agent"</code>
            /// </summary>
            public static string UserAgent => "User-Agent";
            /// <summary>
            /// Returns. <code>"Accept"</code>
            /// </summary>
            public static string Accept => "Accept";
            /// <summary>
            /// Returns. <code>"Authorization"</code>
            /// </summary>
            public static string Authorization => "Authorization";
            /// <summary>
            /// Returns. <code>"Range"</code>
            /// </summary>
            public static string Range => "Range";
            /// <summary>
            /// Returns. <code>"x-ms-range"</code>
            /// </summary>
            public static string XMsRange => "x-ms-range";
            /// <summary>
            /// Returns. <code>"If-Match"</code>
            /// </summary>
            public static string IfMatch => "If-Match";
            /// <summary>
            /// Returns. <code>"If-None-Match"</code>
            /// </summary>
            public static string IfNoneMatch => "If-None-Match";
            /// <summary>
            /// Returns. <code>"If-Modified-Since"</code>
            /// </summary>
            public static string IfModifiedSince => "If-Modified-Since";
            /// <summary>
            /// Returns. <code>"If-Unmodified-Since"</code>
            /// </summary>
            public static string IfUnmodifiedSince => "If-Unmodified-Since";
            /// <summary>
            /// Returns. <code>"Referer"</code>
            /// </summary>
            public static string Referer => "Referer";
            /// <summary>
            /// Returns. <code>"Host"</code>
            /// </summary>
            public static string Host => "Host";

            /// <summary>
            /// Returns <code>"Content-Disposition"</code>.
            /// </summary>
            public static string ContentDisposition => "Content-Disposition";

            /// <summary>
            /// Returns <code>"WWW-Authenticate"</code>.
            /// </summary>
            public static string WwwAuthenticate => "WWW-Authenticate";
        }

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1724 // Type name conflicts with standard namespace
        /// <summary>
        /// Commonly defined header values.
        /// </summary>
        public static class Common
#pragma warning restore CA1034 // Nested types should not be visible
#pragma warning restore CA1724 // Type name conflicts with standard namespace
        {
            private const string ApplicationJson = "application/json";
            private const string ApplicationOctetStream = "application/octet-stream";
            private const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";

            /// <summary>
            /// Returns header with name "ContentType" and value "application/json".
            /// </summary>
            public static readonly HttpHeader JsonContentType = new HttpHeader(Names.ContentType, ApplicationJson);
            /// <summary>
            /// Returns header with name "Accept" and value "application/json".
            /// </summary>
            public static readonly HttpHeader JsonAccept = new HttpHeader(Names.Accept, ApplicationJson);
            /// <summary>
            /// Returns header with name "ContentType" and value "application/octet-stream".
            /// </summary>
            public static readonly HttpHeader OctetStreamContentType = new HttpHeader(Names.ContentType, ApplicationOctetStream);
            /// <summary>
            /// Returns header with name "ContentType" and value "application/x-www-form-urlencoded".
            /// </summary>
            public static readonly HttpHeader FormUrlEncodedContentType = new HttpHeader(Names.ContentType, ApplicationFormUrlEncoded);
        }
    }
}
