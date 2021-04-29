// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core
{
    /// <summary>
    /// Headers to be sent as part of the <see cref="Request"/>.
    /// </summary>
    public readonly struct RequestHeaders : IEnumerable<HttpHeader>
    {
        private readonly Request _request;

        internal RequestHeaders(Request request)
        {
            _request = request;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="RequestHeaders"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> for the <see cref="RequestHeaders"/>.</returns>
        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return _request.EnumerateHeaders().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="RequestHeaders"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator"/> for the <see cref="RequestHeaders"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _request.EnumerateHeaders().GetEnumerator();
        }

        /// <summary>
        /// Adds the <see cref="HttpHeader"/> instance to the collection.
        /// </summary>
        /// <param name="header">The header to add.</param>
        public void Add(HttpHeader header)
        {
            _request.AddHeader(header.Name, header.Value);
        }

        /// <summary>
        /// Adds the header to the collection. If a header with this name already exist adds an additional value to the header values.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        public void Add(string name, string value)
        {
            _request.AddHeader(name, value);
        }

        /// <summary>
        /// Returns header value if the headers is stored in the collection. If the header has multiple values they are going to be joined with a comma.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The reference to populate with value.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool TryGetValue(string name, [NotNullWhen(true)] out string? value)
        {
            return _request.TryGetHeader(name, out value);
        }

        /// <summary>
        /// Returns header values if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="values">The reference to populate with values.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool TryGetValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
            return _request.TryGetHeaderValues(name, out values);
        }

        /// <summary>
        /// Returns <c>true</c> if the headers is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool Contains(string name)
        {
            return _request.ContainsHeader(name);
        }

        /// <summary>
        /// Sets the header value name. If a header with this name already exist replaces it's value.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        public void SetValue(string name, string value)
        {
            _request.SetHeader(name, value);
        }

        /// <summary>
        /// Removes the header from the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if the header existed, otherwise <c>false</c>.</returns>
        public bool Remove(string name)
        {
            return _request.RemoveHeader(name);
        }
    }
}
