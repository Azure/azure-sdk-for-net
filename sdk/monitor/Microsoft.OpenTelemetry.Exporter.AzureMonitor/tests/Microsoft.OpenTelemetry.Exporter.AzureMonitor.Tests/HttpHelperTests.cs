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

            var url = HttpHelper.GetUrl(PartBTags);
            Assert.Null(url);
        }

        [Theory]
        [InlineData(SemanticConventions.AttributeHttpUrl)]
        [InlineData(SemanticConventions.AttributeHttpScheme)]
        [InlineData(SemanticConventions.AttributeHttpHost)]
        public void GetUrl_NullOrEmpty(string attribute)
        {
            var PartBTags = AzMonList.Initialize();
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(attribute, null));

            var url = HttpHelper.GetUrl(PartBTags);
            Assert.Null(url);

           AzMonList.Clear(ref PartBTags);
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(attribute, string.Empty));
            url = HttpHelper.GetUrl(PartBTags);
            Assert.Null(url);
        }

        [Fact]
        public void GetUrl_With_HttpScheme_And_Null_HttpHost()
        {
            var PartBTags = AzMonList.Initialize();
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, null));
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, null));

            var url = HttpHelper.GetUrl(PartBTags);

            Assert.Null(url);
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

            var url = HttpHelper.GetUrl(PartBTags);

            if (string.IsNullOrEmpty(peerName))
            {
                Assert.Null(url);
            }
            else
            {
                Assert.Equal("https://netpeername", url);
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

            var url = HttpHelper.GetUrl(PartBTags);

            Assert.Equal("https://localhost", url);
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

            var url = HttpHelper.GetUrl(PartBTags);

            hostPort = hostPort == "8888" ? ":8888" : null;
            Assert.Equal($"{scheme}://localhost{hostPort}{target}", url);
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

            var url = HttpHelper.GetUrl(PartBTags);

            Assert.Equal($"https://10.0.0.1:443{target}", url);
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

            var url = HttpHelper.GetUrl(PartBTags);
            Assert.Equal($"https://localhost:443{target}", url);
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

            var url = HttpHelper.GetUrl(PartBTags);
            hostPort = hostPort == "8888" ? ":8888" : null;
            Assert.Equal($"localhost{hostPort}{target}", url);
        }

        [Fact]
        public void GetUrl_HttpUrl_Success()
        {
            var PartBTags = AzMonList.Initialize();
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));

            var url = HttpHelper.GetUrl(PartBTags);
            Assert.Equal("https://www.wiki.com/", url);
        }

        // TODO: Order of precedence.

        [Theory]
        [InlineData("200")]
        [InlineData("Ok")]
        [InlineData("500")]
        public void GetHttpStatusCode_Success(string statusCode)
        {
            var PartBTags = AzMonList.Initialize();
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpStatusCode, statusCode));

            Assert.Equal(statusCode, HttpHelper.GetHttpStatusCode(PartBTags));
        }

        [Fact]
        public void GetHttpStatusCode_Failure()
        {
            var PartBTags = AzMonList.Initialize();
            Assert.Equal("0", HttpHelper.GetHttpStatusCode(PartBTags));

           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpStatusCode, null));
            Assert.Equal("0", HttpHelper.GetHttpStatusCode(PartBTags));
        }

        [Theory]
        [InlineData("200")]
        [InlineData("Ok")]
        public void GetSuccessFromHttpStatusCode_Success(string statusCode)
        {
            Assert.True(HttpHelper.GetSuccessFromHttpStatusCode(statusCode));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("500")]
        [InlineData("0")]
        public void GetSuccessFromHttpStatusCode_Failure(string statusCode)
        {
            Assert.False(HttpHelper.GetSuccessFromHttpStatusCode(statusCode));
        }

        [Fact]
        public void GetHostTests()
        {
            var PartBTags = AzMonList.Initialize();
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "test"));
            Assert.Equal("test", HttpHelper.GetHost(PartBTags));

           AzMonList.Clear(ref PartBTags);
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, null));
            Assert.Null(HttpHelper.GetHost(PartBTags));

           AzMonList.Clear(ref PartBTags);
            Assert.Null(HttpHelper.GetHost(PartBTags));
        }

        [Fact]
        public void GetMessagingUrl_Tests()
        {
            var PartBTags = AzMonList.Initialize();
            Assert.Null(HttpHelper.GetMessagingUrl(PartBTags));

           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeMessagingUrl, null));
            Assert.Null(HttpHelper.GetMessagingUrl(PartBTags));

           AzMonList.Clear(ref PartBTags);
           AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeMessagingUrl, "test"));
            Assert.Equal("test", HttpHelper.GetMessagingUrl(PartBTags));
        }
    }
}
