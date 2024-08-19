// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Represents HTTP methods sent as part of a <see cref="Request"/>.
    /// </summary>
    public readonly struct RequestMethod : IEquatable<RequestMethod>
    {
        /// <summary>
        /// Gets the HTTP method.
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for GET method.
        /// </summary>
        public static RequestMethod Get { get; } = new RequestMethod("GET");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for POST method.
        /// </summary>
        public static RequestMethod Post { get; } = new RequestMethod("POST");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for PUT method.
        /// </summary>
        public static RequestMethod Put { get; } = new RequestMethod("PUT");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for PATCH method.
        /// </summary>
        public static RequestMethod Patch { get; } = new RequestMethod("PATCH");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for DELETE method.
        /// </summary>
        public static RequestMethod Delete { get; } = new RequestMethod("DELETE");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for HEAD method.
        /// </summary>
        public static RequestMethod Head { get; } = new RequestMethod("HEAD");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for OPTIONS method.
        /// </summary>
        public static RequestMethod Options { get; } = new RequestMethod("OPTIONS");
        /// <summary>
        /// Gets <see cref="RequestMethod"/> instance for TRACE method.
        /// </summary>
        public static RequestMethod Trace { get; } = new RequestMethod("TRACE");

        /// <summary>
        /// Creates an instance of <see cref="RequestMethod"/> with provided method. Method must be all uppercase.
        /// Prefer <see cref="Parse"/> if <paramref name="method"/> can be one of predefined method names.
        /// </summary>
        /// <param name="method">The method to use.</param>
        public RequestMethod(string method)
        {
            Argument.AssertNotNull(method, nameof(method));

            Method = method.ToUpperInvariant();
        }

        /// <summary>
        /// Parses string to it's <see cref="RequestMethod"/> representation.
        /// </summary>
        /// <param name="method">The method string to parse.</param>
        public static RequestMethod Parse(string method)
        {
            Argument.AssertNotNull(method, nameof(method));

            // Fast-path common values
            if (method.Length == 3)
            {
                if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    return Get;
                }

                if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
                {
                    return Put;
                }
            }
            else if (method.Length == 4)
            {
                if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    return Post;
                }
                if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
                {
                    return Head;
                }
            }
            else
            {
                if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
                {
                    return Patch;
                }
                if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
                {
                    return Delete;
                }
                if (string.Equals(method, "OPTIONS", StringComparison.OrdinalIgnoreCase))
                {
                    return Options;
                }
                if (string.Equals(method, "TRACE", StringComparison.OrdinalIgnoreCase))
                {
                    return Trace;
                }
            }

            return new RequestMethod(method);
        }

        /// <inheritdoc />
        public bool Equals(RequestMethod other)
        {
            return string.Equals(Method, other.Method, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is RequestMethod other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Method.GetHashCodeOrdinal();
        }

        /// <summary>
        /// Compares equality of two <see cref="RequestMethod"/> instances.
        /// </summary>
        /// <param name="left">The method to compare.</param>
        /// <param name="right">The method to compare against.</param>
        /// <returns><c>true</c> if <see cref="Method"/> values are equal for <paramref name="left"/> and <paramref name="right"/>, otherwise <c>false</c>.</returns>
        public static bool operator ==(RequestMethod left, RequestMethod right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares inequality of two <see cref="RequestMethod"/> instances.
        /// </summary>
        /// <param name="left">The method to compare.</param>
        /// <param name="right">The method to compare against.</param>
        /// <returns><c>true</c> if <see cref="Method"/> values are equal for <paramref name="left"/> and <paramref name="right"/>, otherwise <c>false</c>.</returns>
        public static bool operator !=(RequestMethod left, RequestMethod right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Method ?? "<null>";
        }
    }
}
