﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Azure.Core
{
    /// <summary>
    /// Headers received as part of the <see cref="Response"/>.
    /// </summary>
    public readonly struct ResponseHeaders : IEnumerable<HttpHeader>
    {
        private readonly Response _response;

        internal ResponseHeaders(Response response)
        {
            _response = response;
        }

        /// <summary>
        /// Gets the parsed value of "Date" or "x-ms-date" header.
        /// </summary>
        public DateTimeOffset? Date =>
            TryGetValue(HttpHeader.Names.Date, out var value) ||
            TryGetValue(HttpHeader.Names.XMsDate, out value) ?
                (DateTimeOffset?)DateTimeOffset.Parse(value, CultureInfo.InvariantCulture) :
                null;

        /// <summary>
        /// Gets the value of "Content-Type" header.
        /// </summary>
        public string? ContentType => TryGetValue(HttpHeader.Names.ContentType, out string? value) ? value : null;

        /// <summary>
        /// Gets the parsed value of "Content-Length" header.
        /// </summary>
        public int? ContentLength => TryGetValue(HttpHeader.Names.ContentLength, out string? stringValue) ? int.Parse(stringValue, CultureInfo.InvariantCulture) : (int?)null;

        /// <summary>
        /// Gets the parsed value of "ETag" header.
        /// </summary>
        public ETag? ETag => TryGetValue(HttpHeader.Names.ETag, out string? stringValue) ? Azure.ETag.Parse(stringValue) : (ETag?)null;

        /// <summary>
        /// Gets the value of "x-ms-request-id" header.
        /// </summary>
        public string? RequestId => TryGetValue(HttpHeader.Names.XMsRequestId, out string? value) ? value : null;

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ResponseHeaders"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> for the <see cref="ResponseHeaders"/>.</returns>
        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return _response.EnumerateHeaders().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ResponseHeaders"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator"/> for the <see cref="ResponseHeaders"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _response.EnumerateHeaders().GetEnumerator();
        }

        /// <summary>
        /// Returns header value if the header is stored in the collection. If header has multiple values they are going to be joined with a comma.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The reference to populate with value.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool TryGetValue(string name, [NotNullWhen(true)] out string? value)
        {
            return _response.TryGetHeader(name, out value);
        }

        /// <summary>
        /// Returns header values if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="values">The reference to populate with values.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool TryGetValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
            return _response.TryGetHeaderValues(name, out values);
        }

        /// <summary>
        /// Returns <c>true</c> if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool Contains(string name)
        {
            return _response.ContainsHeader(name);
        }
    }
}
