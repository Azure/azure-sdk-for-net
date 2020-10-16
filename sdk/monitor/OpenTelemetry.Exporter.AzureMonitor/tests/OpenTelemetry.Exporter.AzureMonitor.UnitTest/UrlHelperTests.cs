// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class UrlHelperTests
    {
        [Fact]
        public void GetUrl_Null()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>());
            Assert.Null(url);
        }

        [Fact]
        public void GetUrl_HttpUrl_NullOrEmpty()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpUrl] = null });
            Assert.Null(url);
            url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpUrl] = string.Empty });
            Assert.Null(url);
        }

        [Fact]
        public void GetUrl_HttpScheme_NullOrEmpty()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpScheme] = null });
            Assert.Null(url);
            url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpScheme] = string.Empty });
            Assert.Null(url);
        }

        [Fact]
        public void GetUrl_HttpHost_NullOrEmpty()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpHost] = null });
            Assert.Null(url);
            url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpHost] = string.Empty });
            Assert.Null(url);
        }

        [Fact]
        public void GetUrl_With_HttpScheme_And_Null_HttpHost()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
                      { [SemanticConventions.AttributeHttpScheme] = "https",
                        [SemanticConventions.AttributeHttpHost] = null});

            Assert.Null(url);
        }

        [Fact]
        public void GetUrl_NetPeerName_NullOrEmpty()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = null,
                [SemanticConventions.AttributeNetPeerPort] = null
            });

            Assert.Null(url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = string.Empty,
                [SemanticConventions.AttributeNetPeerPort] = null
            });

            Assert.Null(url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = "netpeername",
                [SemanticConventions.AttributeNetPeerPort] = null
            });

            Assert.Equal("https://netpeername", url);
        }

        [Fact]
        public void GetUrl_NetPeerIP_NullOrEmpty()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = null,
                [SemanticConventions.AttributeNetPeerPort] = null
            });

            Assert.Null(url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = string.Empty,
                [SemanticConventions.AttributeNetPeerPort] = null
            });

            Assert.Null(url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = "127.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = null
            });

            Assert.Equal("https://127.0.0.1", url);
        }

        [Fact]
        public void GetUrl_HttpPort_NullEmptyOrDefault()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = null
            });

            Assert.Equal("https://localhost", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "http",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "80"
            });

            Assert.Equal("http://localhost", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "443"
            });

            Assert.Equal("https://localhost", url);
        }

        [Fact]
        public void GetUrl_HttpPort_RandomPort_With_HttpTarget()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888"
            });

            Assert.Equal("https://localhost:8888", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "http",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "80",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            });

            Assert.Equal("http://localhost/test", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "443",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            });

            Assert.Equal("https://localhost/test", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            });

            Assert.Equal("https://localhost:8888/test", url);
        }

        [Fact]
        public void GetUrl_NetPeerIP_Success()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = "10.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = "443"
            });

            Assert.Equal("https://10.0.0.1:443", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerIp] = "10.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = "443",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            });

            Assert.Equal("https://10.0.0.1:443/test", url);
        }

        [Fact]
        public void GetUrl_NetPeerName_Success()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = "localhost",
                [SemanticConventions.AttributeNetPeerPort] = "443"
            });

            Assert.Equal("https://localhost:443", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeNetPeerName] = "localhost",
                [SemanticConventions.AttributeNetPeerPort] = "443",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            });

            Assert.Equal("https://localhost:443/test", url);
        }

        [Fact]
        public void GetUrl_HttpHost_Success()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
            });

            Assert.Equal("localhost", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
            });

            Assert.Equal("localhost:8888", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8080",
                [SemanticConventions.AttributeHttpTarget] = "/test"
            });

            Assert.Equal("localhost:8080/test", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = null,
                [SemanticConventions.AttributeHttpTarget] = null
            });

            Assert.Equal("localhost", url);

            url = UrlHelper.GetUrl(new Dictionary<string, string>
            {
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = string.Empty,
                [SemanticConventions.AttributeHttpTarget] = string.Empty
            });

            Assert.Equal("localhost", url);
        }

        [Fact]
        public void GetUrl_HttpUrl_Success()
        {
            var url = UrlHelper.GetUrl(new Dictionary<string, string> { [SemanticConventions.AttributeHttpUrl] = "https://www.wiki.com" });
            Assert.Equal("https://www.wiki.com", url);
        }

        // TODO: Order of precedence.
    }
}
