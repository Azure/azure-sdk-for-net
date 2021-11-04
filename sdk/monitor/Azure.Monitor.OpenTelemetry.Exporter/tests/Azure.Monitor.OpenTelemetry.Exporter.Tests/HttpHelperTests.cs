// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public class HttpHelperTests
    {
        [Fact]
        public void HttpRequestUrlIsSetUsingHttpUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));

            string url = PartBTags.GetRequestUrl();
            Assert.Equal("https://www.wiki.com", url);
        }

        [Theory]
        [InlineData("http", "80")]
        [InlineData("https", "443")]
        [InlineData("https", "8888")]
        [InlineData("http", "8888")]
        public void HttpRequestUrlIsSetUsing_Scheme_Host_Target(string httpScheme, string port)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:{port}"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://www.httphost.org/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://www.httphost.org:{port}/path";
            }
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpRequestUrlIsSetUsing_Scheme_ServerName_Port_Target(string port)
        {
            var PartBTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, port));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://servername.com/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://servername.com:{port}/path";
            }
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpRequestUrlIsSetUsing_Scheme_NetHostName_Port_Target(string port)
        {
            var PartBTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, port));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://localhost/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://localhost:{port}/path";
            }
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpUrlAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "https://www.wiki.com";
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpHostAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://www.httphost.org/path";
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpServerNameAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://servername.com:8888/path";
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void NetHostNameAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://localhost:8888/path";
            string url = PartBTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpDependencyUrlIsSetUsingHttpUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));

            string url = PartBTags.GetDependencyUrl();
            Assert.Equal("https://www.wiki.com", url);
        }

        [Theory]
        [InlineData("http", "80")]
        [InlineData("https", "443")]
        [InlineData("https", "8888")]
        [InlineData("http", "8888")]
        public void HttpDependencyUrlIsSetUsing_Scheme_Host_Target(string httpScheme, string port)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:{port}"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://www.httphost.org/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://www.httphost.org:{port}/path";
            }
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpDependencyUrlIsSetUsing_Scheme_PeerName_Port_Target(string port)
        {
            var PartBTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, port));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://servername.com/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://servername.com:{port}/path";
            }
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpDependencyUrlIsSetUsing_Scheme_PeerIp_Port_Target(string port)
        {
            var PartBTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, port));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://127.0.0.1/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://127.0.0.1:{port}/path";
            }
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpUrlAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "https://www.wiki.com";
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpHostAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://www.httphost.org/path";
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void NetPeerNameAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://servername.com:8888/path";
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void NetPeerIpAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://127.0.0.1:8888/path";
            string url = PartBTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpUrlIsNullByDefault()
        {
            var PartBTags = AzMonList.Initialize();
            Assert.Null(PartBTags.GetRequestUrl());
            Assert.Null(PartBTags.GetDependencyUrl());
        }

        [Theory]
        [InlineData(PartBType.Http)]
        [InlineData(PartBType.Db)]
        internal void DependencyTargetIsSetUsingPeerService(PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributePeerService, "servicename"));
            string expectedTarget = "servicename";
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("http", "80")]
        [InlineData("https", "443")]
        [InlineData("https", "8888")]
        [InlineData("http", "8888")]
        public void HttpDependencyTargetIsSetUsingHttpHost(string httpScheme, string port)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:{port}"));
            string expectedTarget;
            if (port == "80" || port == "443")
            {
                expectedTarget = "www.httphost.org";
            }
            else
            {
                expectedTarget = $"www.httphost.org:{port}";
            }
            string target = PartBTags.GetDependencyTarget(PartBType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]
        public void HttpDependencyTargetIsSetUsingHttpUrl(string port)
        {
            var PartBTags = AzMonList.Initialize();
            if (port == "80")
            {
                AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:{port}/"));
            }
            else
            {
                AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, $"https://www.wiki.com:{port}/"));
            }
            string expectedTarget;
            if (port == "80" || port == "443")
            {
                expectedTarget = "www.wiki.com";
            }
            else
            {
                expectedTarget = $"www.wiki.com:{port}";
            }
            string target = PartBTags.GetDependencyTarget(PartBType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("http", "80", PartBType.Http)]
        [InlineData("https", "443", PartBType.Http)]
        [InlineData("https", "8888", PartBType.Http)]
        [InlineData("https", "1433", PartBType.Db)]
        [InlineData("https", "8888", PartBType.Db)]
        internal void DependencyTargetIsSetUsingNetPeerName(string httpScheme, string port, PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, port));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, "mssql"));
            string expectedTarget;
            if (port == "80" || port == "443" || port == "1433")
            {
                expectedTarget = "servername.com";
            }
            else
            {
                expectedTarget = $"servername.com:{port}";
            }
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("http", "80", PartBType.Http)]
        [InlineData("https", "443", PartBType.Http)]
        [InlineData("https", "8888", PartBType.Http)]
        [InlineData("https", "1433", PartBType.Db)]
        [InlineData("https", "8888", PartBType.Db)]
        internal void DependencyTargetIsSetUsingNetPeerIp(string httpScheme, string port, PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, port));
            string expectedTarget;
            if (port == "80" || port == "443" || port == "1433")
            {
                expectedTarget = "127.0.0.1";
            }
            else
            {
                expectedTarget = $"127.0.0.1:{port}";
            }
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(PartBType.Http)]
        [InlineData(PartBType.Db)]
        internal void PeerServiceTakesPrecedenceSettingDependencyTarget(PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributePeerService, "servicename"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:8888/"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "servicename";
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Fact]
        public void HttpHostTakesPrecedenceSettingHttpDependencyTarget()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:8888"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:8888/"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "www.httphost.org:8888";
            string target = PartBTags.GetDependencyTarget(PartBType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Fact]
        public void HttpUrlTakesPrecedenceSettingHttpDependencyTarget()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:8888/"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "www.wiki.com:8888";
            string target = PartBTags.GetDependencyTarget(PartBType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(PartBType.Http)]
        [InlineData(PartBType.Db)]
        internal void PeerNameTakesPrecedenceSettingDependencyTarget(PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "servername.com:8888";
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(PartBType.Http)]
        [InlineData(PartBType.Db)]
        internal void PeerIpTakesPrecedenceSettingDependencyTarget(PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "127.0.0.1:8888";
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(PartBType.Http)]
        [InlineData(PartBType.Db)]
        internal void DependencyTargetIsNullByDefault(PartBType type)
        {
            var PartBTags = AzMonList.Initialize();
            string target = PartBTags.GetDependencyTarget(type);
            Assert.Null(target);
        }

        [Theory]
        [InlineData("peerservice", null, null, null)]
        [InlineData(null, "servicename.com", null, "8888")]
        [InlineData(null, null, "127.0.0.1", "8888")]
        public void DbNameIsAppendedToTargetDerivedFromNetAttributesforDBDependencyTarget(string peerService, string netPeerName, string netPeerIp, string netPeerPort)
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributePeerService, peerService));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerName, netPeerName));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerIp, netPeerIp));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeNetPeerPort, netPeerPort));
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbName, "DbName"));
            string hostName = null;
            if (peerService != null)
            {
                hostName = peerService;
            }
            if (netPeerName != null)
            {
                hostName = $"{netPeerName}:{netPeerPort}";
            }
            if (netPeerIp != null)
            {
                hostName = $"{netPeerIp}:{netPeerPort}";
            }
            string expectedTarget = $"{hostName} | DbName";
            string target = PartBTags.GetDbDependencyTarget();
            Assert.Equal(expectedTarget, target);
        }

        [Fact]
        public void DbDependencyTargetIsSetToDbNameWhenNetAttributesAreNotPresent()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbName, "DbName"));
            string target = PartBTags.GetDbDependencyTarget();
            Assert.Equal("DbName", target);
        }

        [Fact]
        public void DbDependencyTargetIsSetToDbSystemWhenNetAndDbNameAttributesAreNotPresent()
        {
            var PartBTags = AzMonList.Initialize();
            AzMonList.Add(ref PartBTags, new KeyValuePair<string, object>(SemanticConventions.AttributeDbSystem, "DbSystem"));
            string target = PartBTags.GetDbDependencyTarget();
            Assert.Equal("DbSystem", target);
        }

        [Fact]
        public void DbDependencyTargetIsSetToNullByDefault()
        {
            var PartBTags = AzMonList.Initialize();
            string target = PartBTags.GetDbDependencyTarget();
            Assert.Null(target);
        }
    }
}
