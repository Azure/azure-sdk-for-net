// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline
{
    public readonly struct HttpHeader : IEquatable<HttpHeader>
    {
        public HttpHeader(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name shouldn't be null or empty", nameof(name));
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

        public override bool Equals(object obj)
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
            public static string XMsRequestId => "x-ms-request-id";
            public static string UserAgent => "User-Agent";
            public static string Accept => "Accept";
            public static string Authorization => "Authorization";
            public static string Range => "Range";
        }

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1724 // Type name conflicts with standard namespace
        public static class Common
#pragma warning restore CA1034 // Nested types should not be visible
#pragma warning restore CA1724 // Type name conflicts with standard namespace
        {
            const string s_applicationJson = "application/json";
            const string s_applicationOctetStream = "application/octet-stream";
            const string s_applicationFormUrlEncoded = "application/x-www-form-urlencoded";

            public static readonly HttpHeader JsonContentType = new HttpHeader(Names.ContentType, s_applicationJson);
            public static readonly HttpHeader JsonAccept = new HttpHeader(Names.Accept, s_applicationJson);
            public static readonly HttpHeader OctetStreamContentType = new HttpHeader(Names.ContentType, s_applicationOctetStream);
            public static readonly HttpHeader FormUrlEncodedContentType = new HttpHeader(Names.ContentType, s_applicationFormUrlEncoded);
        }
    }
}
