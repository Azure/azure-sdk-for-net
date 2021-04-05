// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Azure.Core
{
    /// <summary>
    /// An implementation for manipulating headers on <see cref="Request"/>.
    /// </summary>
    internal class DictionaryHeaders
    {
        private readonly Dictionary<string, object> _headers = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes an instance of <see cref="DictionaryHeaders"/>
        /// </summary>
        public DictionaryHeaders()
        { }

        /// <summary>
        /// Adds a header value to the header collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        public void AddHeader(string name, string value)
        {
            if (!_headers.TryGetValue(name, out object objValue))
            {
                _headers[name] = value;
            }
            else
            {
                if (objValue is List<string> values)
                {
                    values.Add(value);
                }
                else
                {
                    // upgrade to a List
                    _headers[name] = new List<string> { objValue as string, value };
                }
            }
        }

        /// <summary>
        /// Returns header value if the header is stored in the collection. If the header has multiple values they are going to be joined with a comma.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The reference to populate with value.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool TryGetHeader(string name, out string value)
        {
            if (_headers.TryGetValue(name, out object objValue))
            {
                if (objValue is List<string> values)
                {
                    value = JoinHeaderValue(values);
                }
                else
                {
                    value = objValue as string;
                }
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Returns header values if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="values">The reference to populate with values.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            if (_headers.TryGetValue(name, out object objValue))
            {
                if (objValue is List<string> valuesList)
                {
                    values = valuesList;
                }
                else
                {
                    values = new List<string> { objValue as string };
                }

                return true;
            }

            values = null;
            return false;
        }

        /// <summary>
        /// Returns <c>true</c> if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        public bool ContainsHeader(string name)
        {
            return _headers.ContainsKey(name);
        }

        /// <summary>
        /// Sets a header value the header collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        public void SetHeader(string name, string value)
        {
            _headers[name] = value;
        }

        /// <summary>
        /// Removes the header from the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        public bool RemoveHeader(string name)
        {
            return _headers.Remove(name);
        }

        /// <summary>
        /// Returns an iterator enumerating <see cref="HttpHeader"/> in the request.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/> enumerating <see cref="HttpHeader"/> in the response.</returns>
        public IEnumerable<HttpHeader> EnumerateHeaders() => _headers.Select(h => new HttpHeader(h.Key, (h.Value is List<string> values) ? JoinHeaderValue(values) : h.Value as string));

        private static string JoinHeaderValue(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }
    }
}
