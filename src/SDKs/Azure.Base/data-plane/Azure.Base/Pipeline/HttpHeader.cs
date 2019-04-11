// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Base.Pipeline
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
            public static string Host => "Host";
            public static string TransferEncoding => "Transfer-Encoding";
            public static string ContentLength => "Content-Length";
            public static string ContentType => "Content-Type";
            public static string UserAgent => "User-Agent";
            public static string Accept => "Accept";
        }

        public static class Common
        {
            static readonly string s_applicationJson = "application/json";
            static readonly string s_applicationOctetStream = "application/octet-stream";

            public static readonly HttpHeader JsonContentType = new HttpHeader(Names.ContentType, s_applicationJson);
            public static readonly HttpHeader OctetStreamContentType = new HttpHeader(Names.ContentType, s_applicationOctetStream);

            static readonly string PlatformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";

            public static HttpHeader CreateUserAgent(string componentName, string componentVersion, string applicationId = default)
            {
                if (applicationId != null)
                {
                    return new HttpHeader(Names.UserAgent, $"{applicationId} azsdk-net-{componentName}/{componentVersion} {PlatformInformation}");
                }

                return new HttpHeader(Names.UserAgent, $"azsdk-net-{componentName}/{componentVersion} {PlatformInformation}");
            }



            public static HttpHeader CreateHost(string hostName)
            {
                return new HttpHeader(Names.Host, hostName);
            }
        }
    }
}
