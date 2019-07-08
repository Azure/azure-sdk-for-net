// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    public readonly struct RequestMethod : IEquatable<RequestMethod>
    {
        public string Method { get; }

        public static RequestMethod Get { get; } = new RequestMethod("GET");
        public static RequestMethod Post { get; } = new RequestMethod("POST");
        public static RequestMethod Put { get; } = new RequestMethod("PUT");
        public static RequestMethod Patch { get; } = new RequestMethod("PATCH");
        public static RequestMethod Delete { get; } = new RequestMethod("DELETE");
        public static RequestMethod Head { get; } = new RequestMethod("HEAD");

        public RequestMethod(string method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));

            Method = method.ToUpperInvariant();
        }

        public static RequestMethod Parse(string method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

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
            }

            return new RequestMethod(method);
        }

        public bool Equals(RequestMethod other)
        {
            return string.Equals(Method, other.Method, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return obj is RequestMethod other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Method?.GetHashCode() ?? 0;
        }

        public static bool operator ==(RequestMethod left, RequestMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RequestMethod left, RequestMethod right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return Method ?? "<null>";
        }
    }
}
