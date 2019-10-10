﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    public readonly struct HttpHeader : IEquatable<HttpHeader>
    {
        public HttpHeader(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} shouldn't be null or empty", nameof(name));
            }

            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public override int GetHashCode()
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(Name, StringComparer.OrdinalIgnoreCase);
            hashCode.Add(Value);
            return hashCode.ToHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is HttpHeader header)
            {
                return Equals(header);
            }
            return false;
        }

        public override string ToString() => $"{Name}:{Value}";

        public bool Equals(HttpHeader other)
        {
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && Value.Equals(other.Value, StringComparison.Ordinal);
        }

#pragma warning disable CA1034 // Nested types should not be visible
        public static class Names
#pragma warning restore CA1034 // Nested types should not be visible
        {
            public static string Date => "Date";
            public static string XMsDate => "x-ms-date";
            public static string ContentType => "Content-Type";
            public static string ContentLength => "Content-Length";
            public static string ETag => "ETag";
            public static string XMsRequestId => "x-ms-request-id";
            public static string UserAgent => "User-Agent";
            public static string Accept => "Accept";
            public static string Authorization => "Authorization";
            public static string Range => "Range";
            public static string XMsRange => "x-ms-range";
            public static string IfMatch => "If-Match";
            public static string IfNoneMatch => "If-None-Match";
            public static string IfModifiedSince => "If-Modified-Since";
            public static string IfUnmodifiedSince => "If-Unmodified-Since";
        }

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1724 // Type name conflicts with standard namespace
        public static class Common
#pragma warning restore CA1034 // Nested types should not be visible
#pragma warning restore CA1724 // Type name conflicts with standard namespace
        {
            private const string ApplicationJson = "application/json";
            private const string ApplicationOctetStream = "application/octet-stream";
            private const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";

            public static readonly HttpHeader JsonContentType = new HttpHeader(Names.ContentType, ApplicationJson);
            public static readonly HttpHeader JsonAccept = new HttpHeader(Names.Accept, ApplicationJson);
            public static readonly HttpHeader OctetStreamContentType = new HttpHeader(Names.ContentType, ApplicationOctetStream);
            public static readonly HttpHeader FormUrlEncodedContentType = new HttpHeader(Names.ContentType, ApplicationFormUrlEncoded);
        }
    }
}
