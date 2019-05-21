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
                throw new ArgumentException(nameof(name));
            }

            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public override int GetHashCode()
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(Name, StringComparer.InvariantCultureIgnoreCase);
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
            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) && Value.Equals(other.Value);
        }

        public static class Names
        {
            public static string Date => "Date";
            public static string ContentType => "Content-Type";
            public static string XMsRequestId => "x-ms-request-id";
            public static string UserAgent => "User-Agent";
            public static string Accept => "Accept";
            public static string Authorization => "Authorization";
        }

        public static class Common
        {
            static readonly string s_applicationJson = "application/json";
            static readonly string s_applicationOctetStream = "application/octet-stream";

            public static readonly HttpHeader JsonContentType = new HttpHeader(Names.ContentType, s_applicationJson);
            public static readonly HttpHeader OctetStreamContentType = new HttpHeader(Names.ContentType, s_applicationOctetStream);
        }
    }
}
