// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Xunit;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    public class AttributeHelperTests
    {
        [Fact]
        public void GetUrl_Null()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>(), out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpUrl_NullOrEmpty()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpUrl] = null }, out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpUrl] = string.Empty }, out url, out urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpScheme_NullOrEmpty()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpScheme] = null }, out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpScheme] = string.Empty }, out url, out urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpHost_NullOrEmpty()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpHost] = null }, out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpHost] = string.Empty }, out url, out urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Fact]
        public void GetUrl_With_HttpScheme_And_Null_HttpHost()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
                      { [SemanticConventions.AttributeHttpScheme] = "https",
                        [SemanticConventions.AttributeHttpHost] = null},
                        out var url, out var urlAuthority);

            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Fact]
        public void GetUrl_NetPeerName_NullOrEmpty()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = null,
                [SemanticConventions.AttributeNetPeerPort] = null
            }, out var url, out var urlAuthority);

            Assert.Null(url);
            Assert.Null(urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = string.Empty,
                [SemanticConventions.AttributeNetPeerPort] = null
            }, out url, out urlAuthority);

            Assert.Null(url);
            Assert.Null(urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = "netpeername",
                [SemanticConventions.AttributeNetPeerPort] = null
            }, out url, out urlAuthority);

            Assert.Equal("https://netpeername", url);
            Assert.Equal("netpeername", urlAuthority);
        }

        [Fact]
        public void GetUrl_NetPeerIP_NullOrEmpty()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = null,
                [SemanticConventions.AttributeNetPeerPort] = null
            }, out var url, out var urlAuthority);

            Assert.Null(url);
            Assert.Null(urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = string.Empty,
                [SemanticConventions.AttributeNetPeerPort] = null
            }, out url, out urlAuthority);

            Assert.Null(url);
            Assert.Null(urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = "127.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = null
            }, out url, out urlAuthority);

            Assert.Equal("https://127.0.0.1", url);
            Assert.Equal("127.0.0.1", urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpPort_NullEmptyOrDefault()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = null
            }, out var url, out var urlAuthority);

            Assert.Equal("https://localhost", url);
            Assert.Equal("localhost", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "http",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "80"
            }, out url, out urlAuthority);

            Assert.Equal("http://localhost", url);
            Assert.Equal("localhost", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "443"
            }, out url, out urlAuthority);

            Assert.Equal("https://localhost", url);
            Assert.Equal("localhost", urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpPort_RandomPort_With_HttpTarget()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888"
            }, out var url, out var urlAuthority);

            Assert.Equal("https://localhost:8888", url);
            Assert.Equal("localhost:8888", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "http",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "80",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            }, out url, out urlAuthority);

            Assert.Equal("http://localhost/test", url);
            Assert.Equal("localhost", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "443",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            }, out url, out urlAuthority);

            Assert.Equal("https://localhost/test", url);
            Assert.Equal("localhost", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            }, out url, out urlAuthority);

            Assert.Equal("https://localhost:8888/test", url);
            Assert.Equal("localhost:8888", urlAuthority);
        }

        [Fact]
        public void GetUrl_NetPeerIP_Success()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = "10.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = "443"
            }, out var url, out var urlAuthority);

            Assert.Equal("https://10.0.0.1:443", url);
            Assert.Equal("10.0.0.1:443", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = "10.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = "443",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            }, out url, out urlAuthority);

            Assert.Equal("https://10.0.0.1:443/test", url);
            Assert.Equal("10.0.0.1:443", urlAuthority);
        }

        [Fact]
        public void GetUrl_NetPeerName_Success()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = "localhost",
                [SemanticConventions.AttributeNetPeerPort] = "443"
            }, out var url, out var urlAuthority);

            Assert.Equal("https://localhost:443", url);
            Assert.Equal("localhost:443", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = "localhost",
                [SemanticConventions.AttributeNetPeerPort] = "443",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            }, out url, out urlAuthority);

            Assert.Equal("https://localhost:443/test", url);
            Assert.Equal("localhost:443", urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpHost_Success()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
            }, out var url, out var urlAuthority);

            Assert.Equal("localhost", url);
            Assert.Equal("localhost", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
            }, out url, out urlAuthority);

            Assert.Equal("localhost:8888", url);
            Assert.Equal("localhost:8888", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8080",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            }, out url, out urlAuthority);

            Assert.Equal("localhost:8080/test", url);
            Assert.Equal("localhost:8080", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = null,
                [SemanticConventions.AttributeHttpTarget] = null
            }, out url, out urlAuthority);

            Assert.Equal("localhost", url);
            Assert.Equal("localhost", urlAuthority);

            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = string.Empty,
                [SemanticConventions.AttributeHttpTarget] = string.Empty
            }, out url, out urlAuthority);

            Assert.Equal("localhost", url);
            Assert.Equal("localhost", urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpUrl_Success()
        {
            AttributeHelper.GenerateUrlAndAuthority(new Dictionary<string, string> { [SemanticConventions.AttributeHttpUrl] = "https://www.wiki.com" }, out var url, out var urlAuthority);
            Assert.Equal("https://www.wiki.com", url);
            Assert.Equal("www.wiki.com", urlAuthority);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Invalid Data")]
        [InlineData(SemanticConventions.AttributeHttpStatusCode)]
        public void GetTagValue_Tests(string attributeSemanticsKey)
        {
            Assert.Equal(attributeSemanticsKey == SemanticConventions.AttributeHttpStatusCode ? "200" : null,
                    AttributeHelper.GetTagValue(new Dictionary<string, string> { [SemanticConventions.AttributeHttpStatusCode] = "200" }, attributeSemanticsKey));
        }
    }
}
