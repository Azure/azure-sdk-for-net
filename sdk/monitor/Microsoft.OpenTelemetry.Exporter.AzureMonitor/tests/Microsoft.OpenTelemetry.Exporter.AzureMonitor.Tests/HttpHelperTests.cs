// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Xunit;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    public class HttpHelperTests
    {
        [Fact]
        public void GetUrl_Null()
        {
            var PartBTags = AzMonList.Initialize();

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Theory]
        [InlineData(SemanticConventions.AttributeHttpUrl)]
        [InlineData(SemanticConventions.AttributeHttpScheme)]
        [InlineData(SemanticConventions.AttributeHttpHost)]
        public void GetUrl_NullOrEmpty(string attribute)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(attribute, null));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);

            AzMonList.Clear(ref PartBTags);
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(attribute, string.Empty));
            PartBTags.GenerateUrlAndAuthority(out url, out urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Fact]
        public void GetUrl_With_HttpScheme_And_Null_HttpHost()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, null));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, null));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
            Assert.Null(url);
            Assert.Null(urlAuthority);
        }

        [Theory]
        [InlineData("https", null, null)]
        [InlineData("https", "", null)]
        [InlineData("https", "netpeername", null)]
        public void GetUrl_NetPeerName_NullOrEmpty(string scheme, string peerName, string peerPort)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, scheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, peerName));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, peerPort));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);

            if (string.IsNullOrEmpty(peerName))
            {
                Assert.Null(url);
                Assert.Null(urlAuthority);
            }
            else
            {
                Assert.Equal("https://netpeername", url);
                Assert.Equal("netpeername", urlAuthority);
            }
        }

        [Theory]
        [InlineData("https", "localhost", null)]
        [InlineData("https", "localhost", "80")]
        [InlineData("https", "localhost", "443")]
        public void GetUrl_HttpPort_NullEmptyOrDefault(string scheme, string httpHost, string hostPort)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, scheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, httpHost));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, hostPort));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);

            Assert.Equal("https://localhost", url);
            Assert.Equal("localhost", urlAuthority);
        }

        [Theory]
        [InlineData("https", "localhost", "8888", null)]
        [InlineData("http", "localhost", "80", "/test")]
        [InlineData("https", "localhost", "443", "/test")]
        [InlineData("https", "localhost", "8888", "/test")]
        public void GetUrl_HttpPort_RandomPort_With_HttpTarget(string scheme, string httpHost, string hostPort, string target)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, scheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, httpHost));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, hostPort));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, target));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);

            hostPort = hostPort == "8888" ? ":8888" : null;
            Assert.Equal($"{scheme}://localhost{hostPort}{target}", url);
            Assert.Equal($"localhost{hostPort}", urlAuthority);
        }

        [Theory]
        [InlineData("https", "10.0.0.1", "443", null)]
        [InlineData("https", "10.0.0.1", "443", "/test")]
        public void GetUrl_NetPeerIP_Success(string scheme, string peerIp, string peerPort, string target)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, scheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, peerIp));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, peerPort));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, target));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);

            Assert.Equal($"https://10.0.0.1:443{target}", url);
            Assert.Equal("10.0.0.1:443", urlAuthority);
        }

        [Theory]
        [InlineData("https", "localhost", "443", null)]
        [InlineData("https", "localhost", "443", "/test")]
        public void GetUrl_NetPeerName_Success(string scheme, string peerName, string peerPort, string target)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, scheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, peerName));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, peerPort));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, target));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
            Assert.Equal($"https://localhost:443{target}", url);
            Assert.Equal($"localhost:443", urlAuthority);
        }

        [Theory]
        [InlineData("localhost", "", "")]
        [InlineData("localhost", "8888", "")]
        [InlineData("localhost", "8888", "/test")]
        [InlineData("localhost", null, null)]
        public void GetUrl_HttpHost_Success(string httpHost, string hostPort, string target)
        {
            var PartBTags = AzMonList.Initialize();

           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, httpHost));

            if (hostPort != "")
            {
               AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHostPort, hostPort));
            }

            if (target != "")
            {
               AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, target));
            }

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
            hostPort = hostPort == "8888" ? ":8888" : null;
            Assert.Equal($"localhost{hostPort}{target}", url);
            Assert.Equal($"localhost{hostPort}", urlAuthority);
        }

        [Fact]
        public void GetUrl_HttpUrl_Success()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));

            PartBTags.GenerateUrlAndAuthority(out var url, out var urlAuthority);
            Assert.Equal("https://www.wiki.com/", url);
            Assert.Equal("www.wiki.com", urlAuthority);
        }

        // TODO: Order of precedence.
    }
}
