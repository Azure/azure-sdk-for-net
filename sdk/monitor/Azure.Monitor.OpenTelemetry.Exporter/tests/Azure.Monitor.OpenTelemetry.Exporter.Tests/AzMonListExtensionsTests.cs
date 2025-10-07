// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class AzMonListExtensionsTests
    {
        [Fact]
        public void HttpRequestUrlIsSetUsingHttpUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));

            string? url = mappedTags.GetRequestUrl();
            Assert.Equal("https://www.wiki.com", url);
        }

        [Theory]
        [InlineData("http", "80")]
        [InlineData("https", "443")]
        [InlineData("https", "8888")]
        [InlineData("http", "8888")]
        public void HttpRequestUrlIsSetUsing_Scheme_Host_Target(string httpScheme, string port)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:{port}"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://www.httphost.org/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://www.httphost.org:{port}/path";
            }
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpRequestUrlIsSetUsing_Scheme_ServerName_Port_Target(string port)
        {
            var mappedTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostPort, port));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://servername.com/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://servername.com:{port}/path";
            }
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpRequestUrlIsSetUsing_Scheme_NetHostName_Port_Target(string port)
        {
            var mappedTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostPort, port));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://localhost/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://localhost:{port}/path";
            }
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpUrlAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "https://www.wiki.com";
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpHostAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://www.httphost.org/path";
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpServerNameAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpServerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://servername.com:8888/path";
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void NetHostNameAttributeTakesPrecedenceSettingHttpRequestUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostName, "localhost"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetHostPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://localhost:8888/path";
            string? url = mappedTags.GetRequestUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpDependencyUrlIsSetUsingHttpUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));

            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal("https://www.wiki.com", url);
        }

        [Theory]
        [InlineData("http", "80")]
        [InlineData("https", "443")]
        [InlineData("https", "8888")]
        [InlineData("http", "8888")]
        public void HttpDependencyUrlIsSetUsing_Scheme_Host_Target(string httpScheme, string port)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:{port}"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://www.httphost.org/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://www.httphost.org:{port}/path";
            }
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpDependencyUrlIsSetUsing_Scheme_PeerName_Port_Target(string port)
        {
            var mappedTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, port));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://servername.com/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://servername.com:{port}/path";
            }
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]

        public void HttpDependencyUrlIsSetUsing_Scheme_PeerIp_Port_Target(string port)
        {
            var mappedTags = AzMonList.Initialize();
            string httpScheme;
            if (port == "80")
            {
                httpScheme = "http";
            }
            else
            {
                httpScheme = "https";
            }
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, port));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl;
            if (port == "80" || port == "443")
            {
                expectedUrl = $"{httpScheme}://127.0.0.1/path";
            }
            else
            {
                expectedUrl = $"{httpScheme}://127.0.0.1:{port}/path";
            }
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpUrlAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, "https://www.wiki.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "https://www.wiki.com";
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpHostAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, "www.httphost.org"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://www.httphost.org/path";
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void NetPeerNameAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, "servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://servername.com:8888/path";
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void NetPeerIpAttributeTakesPrecedenceSettingHttpDependencyUrl()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, "127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpTarget, "/path"));
            string expectedUrl = "http://127.0.0.1:8888/path";
            string? url = mappedTags.GetDependencyUrl();
            Assert.Equal(expectedUrl, url);
        }

        [Fact]
        public void HttpUrlIsNullByDefault()
        {
            var mappedTags = AzMonList.Initialize();
            Assert.Null(mappedTags.GetRequestUrl());
            Assert.Null(mappedTags.GetDependencyUrl());
        }

        [Theory]
        [InlineData(OperationType.Http)]
        [InlineData(OperationType.Db)]
        internal void DependencyTargetIsSetUsingPeerService(OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributePeerService, "servicename"));
            string expectedTarget = "servicename";
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("http", "80")]
        [InlineData("https", "443")]
        [InlineData("https", "8888")]
        [InlineData("http", "8888")]
        public void HttpDependencyTargetIsSetUsingHttpHost(string httpScheme, string port)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:{port}"));
            string expectedTarget;
            if (port == "80" || port == "443")
            {
                expectedTarget = "www.httphost.org";
            }
            else
            {
                expectedTarget = $"www.httphost.org:{port}";
            }
            string? target = mappedTags.GetDependencyTarget(OperationType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("80")]
        [InlineData("443")]
        [InlineData("8888")]
        public void HttpDependencyTargetIsSetUsingHttpUrl(string port)
        {
            var mappedTags = AzMonList.Initialize();
            if (port == "80")
            {
                AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:{port}/"));
            }
            else
            {
                AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, $"https://www.wiki.com:{port}/"));
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
            string? target = mappedTags.GetDependencyTarget(OperationType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("http", "80", OperationType.Http)]
        [InlineData("https", "443", OperationType.Http)]
        [InlineData("https", "8888", OperationType.Http)]
        [InlineData("https", "1433", OperationType.Db)]
        [InlineData("https", "8888", OperationType.Db)]
        internal void DependencyTargetIsSetUsingNetPeerName(string httpScheme, string port, OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, port));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, "mssql"));
            string expectedTarget;
            if (port == "80" || port == "443" || port == "1433")
            {
                expectedTarget = "servername.com";
            }
            else
            {
                expectedTarget = $"servername.com:{port}";
            }
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData("http", "80", OperationType.Http)]
        [InlineData("https", "443", OperationType.Http)]
        [InlineData("https", "8888", OperationType.Http)]
        [InlineData("https", "1433", OperationType.Db)]
        [InlineData("https", "8888", OperationType.Db)]
        internal void DependencyTargetIsSetUsingNetPeerIp(string httpScheme, string port, OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, httpScheme));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, port));
            string expectedTarget;
            if (port == "80" || port == "443" || port == "1433")
            {
                expectedTarget = "127.0.0.1";
            }
            else
            {
                expectedTarget = $"127.0.0.1:{port}";
            }
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(OperationType.Http)]
        [InlineData(OperationType.Db)]
        internal void PeerServiceTakesPrecedenceSettingDependencyTarget(OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributePeerService, "servicename"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:8888/"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "servicename";
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Fact]
        public void HttpHostTakesPrecedenceSettingHttpDependencyTarget()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpHost, $"www.httphost.org:8888"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:8888/"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "www.httphost.org:8888";
            string? target = mappedTags.GetDependencyTarget(OperationType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Fact]
        public void HttpUrlTakesPrecedenceSettingHttpDependencyTarget()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, $"http://www.wiki.com:8888/"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "www.wiki.com:8888";
            string? target = mappedTags.GetDependencyTarget(OperationType.Http);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(OperationType.Http)]
        [InlineData(OperationType.Db)]
        internal void PeerNameTakesPrecedenceSettingDependencyTarget(OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, $"servername.com"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "servername.com:8888";
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(OperationType.Http)]
        [InlineData(OperationType.Db)]
        internal void PeerIpTakesPrecedenceSettingDependencyTarget(OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpScheme, "http"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, "mssql"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, $"127.0.0.1"));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, "8888"));

            string expectedTarget = "127.0.0.1:8888";
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Equal(expectedTarget, target);
        }

        [Theory]
        [InlineData(OperationType.Http)]
        [InlineData(OperationType.Db)]
        internal void DependencyTargetIsNullByDefault(OperationType type)
        {
            var mappedTags = AzMonList.Initialize();
            string? target = mappedTags.GetDependencyTarget(type);
            Assert.Null(target);
        }

        [Theory]
        [InlineData("peerservice", null, null, null, null, null, null, "peerservice | DbName")]
        [InlineData(null, "servicename.com", null, "8888", null, null, null, "servicename.com:8888 | DbName")]
        [InlineData(null, null, "127.0.0.1", "8888", null, null, null, "127.0.0.1:8888 | DbName")]
        [InlineData(null, null, null, null, "servername.com", null, "8888", "servername.com:8888 | DbName")]
        [InlineData(null, null, null, null, null, "127.0.0.5", "8888", "127.0.0.5:8888 | DbName")]
        public void DbNameIsAppendedToTargetDerivedFromNetAttributesforDBDependencyTarget(string peerService, string netPeerName, string netPeerIp, string netPeerPort, string serverAddress, string serverSocketAddress, string serverPort, string expectedTarget)
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributePeerService, peerService));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerName, netPeerName));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerIp, netPeerIp));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetPeerPort, netPeerPort));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerPort, serverPort));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerSocketAddress, serverSocketAddress));
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbName, "DbName"));

            Assert.Equal(expectedTarget, mappedTags.GetDbDependencyTargetAndName(false).DbTarget);
        }

        [Fact]
        public void DbDependencyTargetIsSetToDbNameWhenNetAttributesAreNotPresent()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbName, "DbName"));
            Assert.Equal("DbName", mappedTags.GetDbDependencyTargetAndName(false).DbTarget);
        }

        [Fact]
        public void DbDependencyTargetIsSetToDbSystemWhenNetAndDbNameAttributesAreNotPresent()
        {
            var mappedTags = AzMonList.Initialize();
            AzMonList.Add(ref mappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeDbSystem, "DbSystem"));
            Assert.Equal("DbSystem", mappedTags.GetDbDependencyTargetAndName(false).DbTarget);
        }

        [Fact]
        public void DbDependencyTargetIsSetToNullByDefault()
        {
            var mappedTags = AzMonList.Initialize();
            Assert.Null(mappedTags.GetDbDependencyTargetAndName(false).DbTarget);
        }
    }
}
