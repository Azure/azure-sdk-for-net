// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.ConstrainedExecution;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public abstract class TransportFunctionalTests : PipelineTestBase
    {
        public TransportFunctionalTests(bool isAsync) : base(isAsync)
        {
        }

        internal static RemoteCertificateValidationCallback certCallback = (_, _, _, _) => true;

        protected abstract HttpPipelineTransport GetTransport(bool https = false, HttpPipelineTransportOptions options = null);

        public static object[] ContentWithLength =>
            new object[]
            {
                new object[] { RequestContent.Create(new byte[10]), 10 },
                new object[] { RequestContent.Create(new byte[10], 5, 5), 5 },
                new object[] { RequestContent.Create(new ReadOnlyMemory<byte>(new byte[10])), 10 },
                new object[] { RequestContent.Create(new ReadOnlyMemory<byte>(new byte[10]).Slice(5)), 5 },
                new object[] { RequestContent.Create(new ReadOnlySequence<byte>(new byte[10])), 10 },
                new object[] { RequestContent.Create(new BinaryData("Hello, world")), 12 },
                new object[] { RequestContent.Create(new BinaryData(new byte[10])), 10 },
            };

        [TestCaseSource(nameof(ContentWithLength))]
        public async Task ContentLengthIsSetForArrayContent(RequestContent content, int expectedLength)
        {
            long contentLength = 0;

            using TestServer testServer = new TestServer(
                context => contentLength = context.Request.ContentLength.Value);

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            request.Content = content;

            await ExecuteRequest(request, transport);

            Assert.That(contentLength, Is.EqualTo(expectedLength));
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultContentLength()
        {
            long contentLength = 0;
            using TestServer testServer = new TestServer(
                context => contentLength = context.Request.ContentLength.Value);

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);

            request.Content = new InvalidSizeContent();
            request.Headers.Add("Content-Length", "50");

            await ExecuteRequest(request, transport);

            Assert.That(request.Content.TryComputeLength(out var cl), Is.True);
            Assert.That(cl, Is.EqualTo(10));
            Assert.That(contentLength, Is.EqualTo(50));
        }

        [Test]
        public async Task CanSetContentLengthOverMaxInt()
        {
            long contentLength = 0;
            using TestServer testServer = new TestServer(
                context =>
                {
                    contentLength = context.Request.ContentLength.Value;
                    context.Abort();
                });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            var infiniteStream = new InfiniteStream();
            request.Content = RequestContent.Create(infiniteStream);

            try
            {
                await ExecuteRequest(request, transport);
            }
            catch (Exception)
            {
                // Sending the request would fail because of length mismatch
            }

            // InfiniteStream has a length of long.MaxValue check that it got sent correctly
            Assert.That(contentLength, Is.EqualTo(infiniteStream.Length));
            Assert.That(infiniteStream.Length, Is.GreaterThan(int.MaxValue));
        }

        [Test]
        public async Task HostHeaderSetFromUri()
        {
            HostString? host = null;
            string uri = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    uri = context.Request.GetDisplayUrl();
                    host = context.Request.GetTypedHeaders().Host;
                });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            await ExecuteRequest(request, transport);

            Assert.That(uri, Is.EqualTo(testServer.Address.ToString()));
            Assert.That(host.ToString(), Is.EqualTo(testServer.Address.Host + ":" + testServer.Address.Port));
        }

        [Test]
        public async Task SettingHeaderOverridesDefaultHost()
        {
            HostString? host = null;
            string uri = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    uri = context.Request.GetDisplayUrl();
                    host = context.Request.GetTypedHeaders().Host;
                });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);
            request.Headers.Add("Host", "example.org");

            await ExecuteRequest(request, transport);

            Assert.That(uri, Is.EqualTo("http://example.org/"));
            Assert.That(host.ToString(), Is.EqualTo("example.org"));
        }

        [Theory]
        [TestCase(200)]
        [TestCase(300)]
        [TestCase(400)]
        [TestCase(500)]
        public async Task ReturnsStatusAndReasonMethod(int code)
        {
            using TestServer testServer = new TestServer(
                context =>
                {
                    context.Response.StatusCode = code;
                });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Uri.Reset(testServer.Address);

            var response = await ExecuteRequest(request, transport);

            Assert.That(response.Status, Is.EqualTo(code));
        }

        public static object[][] Methods => new[]
        {
            new object[] { RequestMethod.Delete, "DELETE", false },
            new object[] { RequestMethod.Get, "GET", false },
            new object[] { RequestMethod.Patch, "PATCH", false },
            new object[] { RequestMethod.Post, "POST", true },
            new object[] { RequestMethod.Put, "PUT", true },
            new object[] { RequestMethod.Head, "HEAD", false },
            new object[] { new RequestMethod("custom"), "CUSTOM", false },
        };

        [Theory]
        [TestCaseSource(nameof(Methods))]
        public async Task CanGetAndSetMethod(RequestMethod method, string expectedMethod, bool content = false)
        {
            string httpMethod = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    httpMethod = context.Request.Method.ToString();
                });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = method;
            request.Uri.Reset(testServer.Address);

            if (content)
            {
                request.Content = RequestContent.Create(Array.Empty<byte>());
            }

            Assert.That(request.Method, Is.EqualTo(method));

            await ExecuteRequest(request, transport);

            Assert.That(httpMethod, Is.EqualTo(expectedMethod));
        }

        public static object[] HeadersWithValues =>
           new object[]
           {
                // Name, value, is content, supports multiple
                new object[] { "Allow", "adcde", true, true },
                new object[] { "Accept", "adcde", true, true },
                new object[] { "Referer", "adcde", true, true },
                new object[] { "User-Agent", "adcde", true, true },
                new object[] { "Content-Disposition", "adcde", true, true },
                new object[] { "Content-Encoding", "adcde", true, true },
                new object[] { "Content-Language", "en-US", true, true },
                new object[] { "Content-Location", "adcde", true, true },
                new object[] { "Content-MD5", "adcde", true, true },
                new object[] { "Content-Range", "adcde", true, true },
                new object[] { "Content-Type", "text/xml", true, true },
                new object[] { "Expires", "11/12/19", true, true },
                new object[] { "Last-Modified", "11/12/19", true, true },
                new object[] { "If-Modified-Since", "Tue, 12 Nov 2019 08:00:00 GMT", false, false },
                new object[] { "Custom-Header", "11/12/19", false, true },
                new object[] { "Expect", "text/json", false, true },
                new object[] { "Host", "example.com", false, false },
                new object[] { "Keep-Alive", "true", false, true },
                new object[] { "Referer", "example.com", false, true },
                new object[] { "WWW-Authenticate", "Basic realm=\"Access to the staging site\", charset=\"UTF-8\"", false, true },
                new object[] { "Custom-Header", "11/12/19", false, true },
                new object[] { "Range", "bytes=0-", false, false },
                new object[] { "Range", "bytes=0-100", false, false },
                new object[] { "Content-Length", "16", true, false },
                new object[] { "Date", "Tue, 12 Nov 2019 08:00:00 GMT", false, false },
            };

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanGetAndAddRequestHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            StringValues httpHeaderValues = default;

            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.That(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues), Is.True);
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, headerValue);

            if (contentHeader)
            {
                request.Content = RequestContent.Create(new byte[16]);
            }

            Assert.That(request.Headers.TryGetValue(headerName, out var value), Is.True);
            Assert.That(value, Is.EqualTo(headerValue));

            Assert.That(request.Headers.TryGetValue(headerName.ToUpper(), out value), Is.True);
            Assert.That(value, Is.EqualTo(headerValue));

            Assert.That(request.Headers, Is.EqualTo(new[]
            {
                 new HttpHeader(headerName, headerValue),
             }).AsCollection);

            await ExecuteRequest(request, transport);

            Assert.That(string.Join(",", (string[])httpHeaderValues), Is.EqualTo(headerValue));
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanGetAndAddRequestHeadersUppercase(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            await CanGetAndAddRequestHeaders(headerName.ToUpperInvariant(), headerValue, contentHeader, supportsMultiple);
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public void TryGetReturnsCorrectValuesWhenNotFound(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            var transport = GetTransport();
            Request request = transport.CreateRequest();

            Assert.That(request.Headers.TryGetValue(headerName, out string value), Is.False);
            Assert.That(value, Is.Null);

            Assert.That(request.Headers.TryGetValues(headerName, out IEnumerable<string> values), Is.False);
            Assert.That(values, Is.Null);
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanAddMultipleValuesToRequestHeader(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            if (!supportsMultiple)
                return;

            var anotherHeaderValue = headerValue + "1";
            var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

            StringValues httpHeaderValues = default;

            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.That(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues), Is.True);
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, headerValue);
            request.Headers.Add(headerName, anotherHeaderValue);

            Assert.That(request.Headers.Contains(headerName), Is.True);

            Assert.That(request.Headers.TryGetValue(headerName, out var value), Is.True);
            Assert.That(value, Is.EqualTo(joinedHeaderValues));

            Assert.That(request.Headers.TryGetValues(headerName, out IEnumerable<string> values), Is.True);
            Assert.That(values, Is.EqualTo(new[] { headerValue, anotherHeaderValue }).AsCollection);

            Assert.That(request.Headers, Is.EqualTo(new[]
            {
                new HttpHeader(headerName, joinedHeaderValues),
            }).AsCollection);

            await ExecuteRequest(request, transport);

            Assert.That(httpHeaderValues.ToString(), Does.Contain(headerValue));
            Assert.That(httpHeaderValues.ToString(), Does.Contain(anotherHeaderValue));
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanGetAndSetResponseHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            using TestServer testServer = new TestServer(
                context =>
                {
                    context.Response.Headers.Add(headerName, headerValue);
                    context.Response.WriteAsync("1234567890123456");
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            Response response = await ExecuteRequest(request, transport);

            Assert.That(response.Headers.Contains(headerName), Is.True, $"response.Headers contains the following headers: {string.Join(", ", response.Headers.Select(h => $"\"{h.Name}\": \"{h.Value}\""))}");

            Assert.That(response.Headers.TryGetValue(headerName, out var value), Is.True);
            Assert.That(value, Is.EqualTo(headerValue));

            Assert.That(response.Headers.TryGetValues(headerName, out IEnumerable<string> values), Is.True);
            Assert.That(values, Is.EqualTo(new[] { headerValue }).AsCollection);

            Assert.That(response.Headers, Has.Member(new HttpHeader(headerName, headerValue)));
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanGetAndSetMultiValueResponseHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            if (!supportsMultiple)
                return;

            var anotherHeaderValue = headerValue + "1";
            var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

            using TestServer testServer = new TestServer(
                context =>
                {
                    context.Response.Headers.Add(headerName,
                        new StringValues(new[]
                        {
                            headerValue,
                            anotherHeaderValue
                        }));
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            Response response = await ExecuteRequest(request, transport);

            Assert.That(response.Headers.Contains(headerName), Is.True);

            Assert.That(response.Headers.TryGetValue(headerName, out var value), Is.True);
            Assert.That(value, Is.EqualTo(joinedHeaderValues));

            Assert.That(response.Headers.TryGetValues(headerName, out IEnumerable<string> values), Is.True);
            Assert.That(values, Is.EqualTo(new[] { headerValue, anotherHeaderValue }).AsCollection);

            Assert.That(response.Headers, Has.Member(new HttpHeader(headerName, joinedHeaderValues)));
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanRemoveHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            // Some headers are required
            bool checkOnServer = headerName != "Content-Length" && headerName != "Host";

            using TestServer testServer = new TestServer(
                context =>
                {
                    if (checkOnServer)
                    {
                        Assert.That(context.Request.Headers.TryGetValue(headerName, out _), Is.False);
                    }
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, headerValue);
            Assert.That(request.Headers.Remove(headerName), Is.True);
            Assert.That(request.Headers.Remove(headerName), Is.False);

            Assert.That(request.Headers.TryGetValue(headerName, out _), Is.False);
            Assert.That(request.Headers.TryGetValue(headerName.ToUpper(), out _), Is.False);
            Assert.That(request.Headers.Contains(headerName.ToUpper()), Is.False);

            await ExecuteRequest(request, transport);
        }

        [TestCaseSource(nameof(HeadersWithValues))]
        public async Task CanSetRequestHeaders(string headerName, string headerValue, bool contentHeader, bool supportsMultiple)
        {
            StringValues httpHeaderValues = default;

            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.That(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues), Is.True);
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, "Random value");
            request.Headers.SetValue(headerName, headerValue);

            if (contentHeader)
            {
                request.Content = RequestContent.Create(new byte[16]);
            }

            Assert.That(request.Headers.TryGetValue(headerName, out var value), Is.True);
            Assert.That(value, Is.EqualTo(headerValue));

            Assert.That(request.Headers.TryGetValue(headerName.ToUpper(), out value), Is.True);
            Assert.That(value, Is.EqualTo(headerValue));

            Assert.That(request.Headers, Is.EqualTo(new[]
            {
                new HttpHeader(headerName, headerValue),
            }).AsCollection);

            await ExecuteRequest(request, transport);

            Assert.That(string.Join(",", (string[])httpHeaderValues), Is.EqualTo(headerValue));
        }

        [Test]
        public async Task CanGetAndSetContent()
        {
            byte[] requestBytes = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    using var memoryStream = new MemoryStream();
                    context.Request.Body.CopyTo(memoryStream);
                    requestBytes = memoryStream.ToArray();
                });

            var bytes = Encoding.ASCII.GetBytes("Hello world");
            var content = RequestContent.Create(bytes);
            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            request.Content = content;

            Assert.That(request.Content, Is.EqualTo(content));

            await ExecuteRequest(request, transport);

            Assert.That(requestBytes, Is.EqualTo(bytes).AsCollection);
        }

        [Test]
        public async Task CanGetAndSetContentStream()
        {
            byte[] requestBytes = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    using var memoryStream = new MemoryStream();
                    context.Request.Body.CopyTo(memoryStream);
                    requestBytes = memoryStream.ToArray();
                });

            var stream = new MemoryStream();
            stream.SetLength(10 * 1024);
            var content = RequestContent.Create(stream);
            var transport = GetTransport();

            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            request.Content = content;

            Assert.That(request.Content, Is.EqualTo(content));

            await ExecuteRequest(request, transport);

            Assert.That(requestBytes, Is.EqualTo(stream.ToArray()).AsCollection);
            Assert.That(requestBytes.Length, Is.EqualTo(10 * 1024));
        }

        public static object[][] RequestMethods => new[]
        {
            new object[] { RequestMethod.Delete },
            new object[] { RequestMethod.Get },
            new object[] { RequestMethod.Patch },
            new object[] { RequestMethod.Post },
            new object[] { RequestMethod.Put },
            new object[] { RequestMethod.Head },
            new object[] { new RequestMethod("custom") },
        };

        [Test]
        [TestCaseSource(nameof(RequestMethods))]
        public async Task ContentLengthSetCorrectlyWhenNoContent(RequestMethod method)
        {
            var transport = GetTransport();

            long? contentLength = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    contentLength = context.Request.ContentLength;
                });

            Request request = transport.CreateRequest();
            request.Method = method;
            request.Content = null;
            request.Uri.Reset(testServer.Address);

            await ExecuteRequest(request, transport);

            // for NET462, HttpClient will include zero content-length for DELETEs
#if NET462
            if (transport is HttpClientTransport &&
                method == RequestMethod.Delete)
            {
                Assert.That(contentLength, Is.EqualTo(0));

                return;
            }
#endif

            if (method == RequestMethod.Delete ||
                method == RequestMethod.Get ||
                method == RequestMethod.Head)
            {
                Assert.That(contentLength, Is.Null);
            }
            else
            {
                Assert.That(contentLength, Is.EqualTo(0));
            }
        }

        [Test]
        [TestCaseSource(nameof(RequestMethods))]
        public async Task ContentTypeNullWhenNoContent(RequestMethod method)
        {
            var transport = GetTransport();

            string contentType = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    contentType = context.Request.ContentType;
                });

            Request request = transport.CreateRequest();
            request.Method = method;
            request.Content = null;
            request.Headers.Add("Content-Type", "application/json");
            request.Uri.Reset(testServer.Address);

            await ExecuteRequest(request, transport);
            Assert.That(contentType, Is.Null);
        }

        [Test]
        public async Task RequestAndResponseHasRequestId()
        {
            using TestServer testServer = new TestServer(context => { });
            var transport = GetTransport();
            Request request = transport.CreateRequest();
            Assert.That(request.ClientRequestId, Is.Not.Empty);
            Assert.That(Guid.TryParse(request.ClientRequestId, out _), Is.True);
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            Response response = await ExecuteRequest(request, transport);
            Assert.That(response.ClientRequestId, Is.EqualTo(request.ClientRequestId));
        }

        [Test]
        public async Task RequestIdCanBeOverridden()
        {
            using TestServer testServer = new TestServer(context => { });
            var transport = GetTransport();
            Request request = transport.CreateRequest();

            request.ClientRequestId = "123";
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            Response response = await ExecuteRequest(request, transport);
            Assert.That(response.ClientRequestId, Is.EqualTo(request.ClientRequestId));
        }

        [Test]
        public async Task ReasonPhraseIsExposed()
        {
            using TestServer testServer = new TestServer(context =>
            {
                context.Response
                    .HttpContext
                    .Features
                    .Get<IHttpResponseFeature>()
                    .ReasonPhrase = "Custom ReasonPhrase";
            });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            Response response = await ExecuteRequest(request, transport);

            Assert.That(response.ReasonPhrase, Is.EqualTo("Custom ReasonPhrase"));
        }

        [Test]
        public async Task StreamRequestContentCanBeSentMultipleTimes()
        {
            var requests = new List<long?>();

            using TestServer testServer = new TestServer(context =>
            {
                requests.Add(context.Request.ContentLength);
            });

            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);

            request.Content = RequestContent.Create(new MemoryStream(new byte[] { 1, 2, 3 }));

            await ExecuteRequest(request, transport);
            await ExecuteRequest(request, transport);

            Assert.That(requests, Is.EqualTo(new long[] { 3, 3 }));
        }

        [Test]
        public async Task RequestContentIsNotDisposedOnSend()
        {
            using TestServer testServer = new TestServer(context => { });

            DisposeTrackingContent disposeTrackingContent = new DisposeTrackingContent();
            var transport = GetTransport();

            using (Request request = transport.CreateRequest())
            {
                request.Content = disposeTrackingContent;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);

                await ExecuteRequest(request, transport);
                Assert.That(disposeTrackingContent.IsDisposed, Is.False);
            }

            Assert.That(disposeTrackingContent.IsDisposed, Is.True);
        }
        [Test]
        public void GetIsDefaultMethod()
        {
            var transport = GetTransport();
            var request = transport.CreateRequest();
            Assert.That(request.Method.Method, Is.EqualTo("GET"));
        }

        [Test]
        public void ClientRequestIdSetterThrowsOnNull()
        {
            var transport = GetTransport();
            var request = transport.CreateRequest();
            Assert.Throws<ArgumentNullException>(() => request.ClientRequestId = null);
        }

        [NonParallelizable]
        [Theory]
        [TestCase("HTTP_PROXY", "http://microsoft.com")]
        [TestCase("ALL_PROXY", "http://microsoft.com")]
        public async Task ProxySettingsAreReadFromEnvironment(string envVar, string url)
        {
            try
            {
                using (TestServer testServer = new TestServer(async context =>
                {
                    context.Response.Headers["Via"] = "Test-Proxy";
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                }))
                {
                    Environment.SetEnvironmentVariable(envVar, testServer.Address.ToString());

                    var transport = GetTransport();
                    Request request = transport.CreateRequest();
                    request.Uri.Reset(new Uri(url));
                    Response response = await ExecuteRequest(request, transport);
                    Assert.That(response.Headers.TryGetValue("Via", out var via), Is.True);
                    Assert.That(via, Is.EqualTo("Test-Proxy"));
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable(envVar, null);
            }
        }

#if NET462 // GlobalProxySelection.Select not supported on netcoreapp
        [NonParallelizable]
        [Test]
        public async Task DefaultProxySettingsArePreserved()
        {
#pragma warning disable 618 // Use of obsolete symbol
            var oldGlobalProxySelection = GlobalProxySelection.Select;
#pragma warning restore 618
            try
            {
                using (TestServer testServer = new TestServer(async context =>
                {
                    context.Response.Headers["Via"] = "Test-Proxy";
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                }))
                {
#pragma warning disable 618 // Use of obsolete symbol
                    GlobalProxySelection.Select = new WebProxy(testServer.Address.ToString());
#pragma warning restore 618

                    var transport = GetTransport();
                    Request request = transport.CreateRequest();
                    request.Uri.Reset(new Uri("http://microsoft.com"));
                    Response response = await ExecuteRequest(request, transport);
                    Assert.That(response.Headers.TryGetValue("Via", out var via), Is.True);
                    Assert.That(via, Is.EqualTo("Test-Proxy"));
                }
            }
            finally
            {
#pragma warning disable 618 // Use of obsolete symbol
                GlobalProxySelection.Select = oldGlobalProxySelection;
#pragma warning restore 618
            }
        }
#endif

        [Test]
        public async Task ResponseHeadersAreSplit()
        {
            using (TestServer testServer = new TestServer(
                async context =>
                {
                    context.Response.Headers.Add("Sync-Token", new[] { "A", "B" });
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                Response response = await ExecuteRequest(request, transport);
                Assert.That(response.Headers.TryGetValues("Sync-Token", out System.Collections.Generic.IEnumerable<string> tokens), Is.True);
                Assert.That(tokens.Count(), Is.EqualTo(2));
                Assert.That(tokens, Is.EqualTo(new[] { "A", "B" }).AsCollection);
            }
        }

        [Test]
        public async Task ResponseHeadersAreNotSplit()
        {
            using (TestServer testServer = new TestServer(
                async context =>
                {
                    context.Response.Headers.Add("Sync-Token", "A,B");
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                Response response = await ExecuteRequest(request, transport);
                Assert.That(response.Headers.TryGetValues("Sync-Token", out System.Collections.Generic.IEnumerable<string> tokens), Is.True);
                Assert.That(tokens.Count(), Is.EqualTo(1));
                Assert.That(tokens, Is.EqualTo(new[] { "A,B" }).AsCollection);
            }
        }

        [Test]
        public void TransportExceptionsAreWrapped()
        {
            using (TestServer testServer = new TestServer(
                context =>
                {
                    context.Abort();
                    return Task.CompletedTask;
                }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await ExecuteRequest(request, transport));
                Assert.That(exception.Message, Is.Not.Empty);
                Assert.That(exception.Status, Is.EqualTo(0));
            }
        }

        [Test]
        public void TransportExceptionsAreWrappedAndInnerExceptionIsPopulated()
        {
            using (TestServer testServer = new TestServer(
                context =>
                {
                    context.Abort();
                    return Task.CompletedTask;
                }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await ExecuteRequest(request, transport));
                Assert.That(exception.Message, Is.Not.Empty);
                Assert.That(exception.Status, Is.EqualTo(0));
                Assert.That(exception.InnerException.Message, Is.Not.Empty);
            }
        }

        [Test]
        [Retry(3)] // Sometimes is a victim of timeouts on CI, but usually runs sub 100ms
        public Task ThrowsTaskCanceledExceptionWhenCancelled() => ThrowsTaskCanceledExceptionWhenCancelled(false);

        [Test]
        [Retry(3)] // Sometimes is a victim of timeouts on CI, but usually runs sub 100ms
        public Task ThrowsTaskCanceledExceptionWhenCancelledHttps() => ThrowsTaskCanceledExceptionWhenCancelled(true);

        private async Task ThrowsTaskCanceledExceptionWhenCancelled(bool https)
        {
            var testDoneTcs = new CancellationTokenSource();
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using TestServer testServer = new TestServer(
                async context =>
                {
                    tcs.SetResult(null);
                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                }, https);

            var cts = new CancellationTokenSource();
            var transport = GetTransport(https);
            Request request = transport.CreateRequest();
            request.Uri.Reset(testServer.Address);

            var task = Task.Run(async () => await ExecuteRequest(request, transport, cts.Token));

            try
            {
                // Wait for server to receive a request
                await tcs.Task.TimeoutAfterDefault();
            }
            catch (TimeoutException)
            {
                // Try to observe the request failure
                await task.TimeoutAfterDefault();
            }

            cts.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<TaskCanceledException>(), async () => await task.TimeoutAfterDefault());
            testDoneTcs.Cancel();
        }

        [Test]
        public Task CanCancelContentUpload() => CanCancelContentUpload(false);

        [Test]
        public Task CanCancelContentUploadHttps() => CanCancelContentUpload(true);

        private async Task CanCancelContentUpload(bool https)
        {
            var buffer = new byte[100];
            var testDoneTcs = new CancellationTokenSource();
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using TestServer testServer = new TestServer(
                async context =>
                {
                    // read part of the request
#if NET6_0_OR_GREATER
                    await context.Request.Body.ReadExactlyAsync(buffer, 0, 100);
#else
                    await context.Request.Body.ReadAsync(buffer, 0, 100);
#endif
                    tcs.SetResult(null);
                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                }, https);

            var cts = new CancellationTokenSource();
            var transport = GetTransport(https);
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            // Use infinite request content size to fill the buffers and force the upload to stall
            request.Content = RequestContent.Create(new InfiniteStream());
            request.Uri.Reset(testServer.Address);

            var task = Task.Run(async () => await ExecuteRequest(request, transport, cts.Token));

            try
            {
                // Wait for server to receive a request
                await tcs.Task.TimeoutAfterDefault();
            }
            catch (TimeoutException)
            {
                // Try to observe the request failure
                await task.TimeoutAfterDefault();
            }

            cts.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<TaskCanceledException>(), async () => await task.TimeoutAfterDefault());
            testDoneTcs.Cancel();
        }

        [Test]
        public async Task StreamReadingExceptionsAreIOExceptions()
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            using (TestServer testServer = new TestServer(
                async context =>
                {
                    context.Response.ContentLength = 20;
                    await context.Response.WriteAsync("Hello");
                    await tcs.Task;

                    context.Abort();
                }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                HttpMessage messsage = new(request, ResponseClassifier.Shared);

                // This test is explicitly testing the behavior of a response that
                // holds a live network stream, so we set BufferResponse to false.
                messsage.BufferResponse = false;

                await ProcessAsync(messsage, transport);
                Response response = messsage.Response;

                tcs.SetResult(null);

                Assert.ThrowsAsync(Is.InstanceOf<IOException>(), async () => await response.ContentStream.CopyToAsync(new MemoryStream()));
            }
        }

        [Test]
        public async Task ServerCertificateCustomValidationCallbackIsHonored([Values(true, false)] bool setCertCallback, [Values(true, false)] bool isValidCert)
        {
#if NETFRAMEWORK // ServicePointManager is obsolete and doesn't affect HttpClient
            // This test assumes ServicePointManager.ServerCertificateValidationCallback will be unset.
            ServicePointManager.ServerCertificateValidationCallback = null;
#endif

            using (TestServer testServer = new TestServer(
                async context =>
                {
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                },
                true))
            {
                bool certValidationCalled = false;
                X509Certificate2 cert = null;
                X509Chain chain = null;
                var options = new HttpPipelineTransportOptions();

                if (setCertCallback)
                {
                    options.ServerCertificateCustomValidationCallback = args =>
                    {
                        certValidationCalled = true;
                        cert = args.Certificate;
                        chain = args.CertificateAuthorityChain;
                        return isValidCert;
                    };
                }
                var transport = GetTransport(true, options);
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);

                try
                {
                    await ExecuteRequest(request, transport);
                    Assert.Multiple(
                        () =>
                        {
                            Assert.That(isValidCert, Is.True);
                            Assert.That(setCertCallback, Is.True);
                        });
                }
                catch (Exception ex) when (ex is not AssertionException)
                {
                    Assert.That(setCertCallback && !isValidCert || !setCertCallback);

                    ex = ex.InnerException;
                    while (ex is { } && ex is not AuthenticationException)
                    {
                        ex = ex.InnerException;
                    }
                    if (ex is not AuthenticationException)
                    {
                        throw;
                    }
                    TestContext.WriteLine(ex.Message);
                }
                finally
                {
                    Assert.That(certValidationCalled, Is.EqualTo(setCertCallback));
                    if (certValidationCalled)
                    {
                        Assert.Multiple(
                            () =>
                            {
                                Assert.That(cert, Is.Not.Null, $"{nameof(ServerCertificateCustomValidationArgs)}.{nameof(ServerCertificateCustomValidationArgs.Certificate)} should not be null");
                                Assert.That(chain, Is.Not.Null, $"{nameof(ServerCertificateCustomValidationArgs)}.{nameof(ServerCertificateCustomValidationArgs.CertificateAuthorityChain)} should not be null");
                            });
                    }
                }
            }
        }

        [Test]
        public async Task ClientCertificateIsHonored([Values(true, false)] bool setClientCertificate)
        {
#if NETFRAMEWORK // ServicePointManager is obsolete and doesn't affect HttpClient
            // This test assumes ServicePointManager.ServerCertificateValidationCallback will be unset.
            ServicePointManager.ServerCertificateValidationCallback = null;
#endif
            X509Certificate2 clientCert = GetCertificate(Pfx);

            using (TestServer testServer = new TestServer(
                async context =>
                {
                    var cert = context.Connection.ClientCertificate;
                    if (setClientCertificate)
                    {
                        Assert.That(cert, Is.Not.Null);
                        Assert.That(cert, Is.EqualTo(clientCert));
                    }
                    else
                    {
                        Assert.That(cert, Is.Null);
                    }
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                },
                true))
            {
                var options = new HttpPipelineTransportOptions();

                options.ServerCertificateCustomValidationCallback = args => true;
                if (setClientCertificate)
                {
                    options.ClientCertificates.Add(clientCert);
                }
                var transport = GetTransport(true, options);
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);

                await ExecuteRequest(request, transport);
            }
        }

        [Test]
        public async Task ClientCertificateCanBeRotatedFromEmpty()
        {
#if NETFRAMEWORK // ServicePointManager is obsolete and doesn't affect HttpClient
            // This test assumes ServicePointManager.ServerCertificateValidationCallback will be unset.
            ServicePointManager.ServerCertificateValidationCallback = null;
#endif
            X509Certificate2 clientCert = GetCertificate(Pfx);
            bool setClientCertificate = false;
            bool validatedCert = false;

            using (TestServer testServer = new TestServer(
                async context =>
                {
                    var cert = context.Connection.ClientCertificate;
                    if (setClientCertificate)
                    {
                        Assert.That(cert, Is.Not.Null);
                        Assert.That(cert, Is.EqualTo(clientCert));
                        validatedCert = true;
                    }
                    else
                    {
                        Assert.That(cert, Is.Null);
                    }
                    byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                    await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                },
                true))
            {
                var options = new HttpPipelineTransportOptions();
                options.ServerCertificateCustomValidationCallback = args => true;

                var transport = GetTransport(true, options);

                // Initially no client certificate
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);

                await ExecuteRequest(request, transport);

                // Now set the client certificate and update the transport
                options.ClientCertificates.Add(clientCert);

                transport.Update(options);
                setClientCertificate = true;

                request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);

                await ExecuteRequest(request, transport);
                Assert.That(validatedCert, Is.True, "Client certificate was not validated after transport update.");
            }
        }

        [Test]
        public async Task ClientCertificateCanBeRotatedFromExistingCert()
        {
            try
            {
#if NETFRAMEWORK // ServicePointManager is obsolete and doesn't affect HttpClient
            // This test assumes ServicePointManager.ServerCertificateValidationCallback will be unset.
            ServicePointManager.ServerCertificateValidationCallback -= certCallback;
#endif
                X509Certificate2 clientCert = GetCertificate(Pfx);
                X509Certificate2 anotherCert = GetCertificate(Pfx2);
                bool setClientCertificate = false;
                bool validatedCert = false;

                using (TestServer testServer = new TestServer(
                    async context =>
                    {
                        var cert = context.Connection.ClientCertificate;
                        if (setClientCertificate)
                        {
                            Assert.That(cert, Is.Not.Null);
                            Assert.That(cert, Is.EqualTo(anotherCert));
                            validatedCert = true;
                        }
                        else
                        {
                            Assert.That(cert, Is.Not.Null);
                            Assert.That(cert, Is.EqualTo(clientCert));
                            validatedCert = true;
                        }
                        byte[] buffer = Encoding.UTF8.GetBytes("Hello");
                        await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                    },
                    true))
                {
                    var options = new HttpPipelineTransportOptions();
                    options.ServerCertificateCustomValidationCallback = args => true;
                    options.ClientCertificates.Add(clientCert);

                    var transport = GetTransport(true, options);

                    // Initially the first client certificate
                    Request request = transport.CreateRequest();
                    request.Uri.Reset(testServer.Address);

                    await ExecuteRequest(request, transport);

                    // Now set the client certificate and update the transport
                    options.ClientCertificates.Clear();
                    options.ClientCertificates.Add(anotherCert);

                    transport.Update(options);
                    setClientCertificate = true;

                    request = transport.CreateRequest();
                    request.Uri.Reset(testServer.Address);

                    await ExecuteRequest(request, transport);
                    Assert.That(validatedCert, Is.True, "Client certificate was not validated after transport update.");
                }
            }
            finally
            {
#if NETFRAMEWORK
            ServicePointManager.ServerCertificateValidationCallback += certCallback;
#endif
            }
        }

        [Test]
        public async Task No100ContinueSentByDefault()
        {
            using (TestServer testServer = new TestServer(
                       async context =>
                       {
                           Assert.That(context.Request.Headers["Expect"].Count, Is.Zero);
                           await context.Response.WriteAsync("");
                       }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);
                request.Content = RequestContent.Create("Hello");
                Response response = await ExecuteRequest(request, transport);

                Assert.That(response.Status, Is.EqualTo(200));
            }
        }

        [Test]
        public async Task CanSendExpect100Continue()
        {
            using (TestServer testServer = new TestServer(
                       async context =>
                       {
                           Assert.That(context.Request.Headers["Expect"], Is.EqualTo("100-continue"));
                           context.Response.StatusCode = 444;

                           await context.Response.WriteAsync("Too long");
                       }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);
                request.Headers.Add("Expect", "100-continue");
                request.Content = RequestContent.Create("Hello");
                Response response = await ExecuteRequest(request, transport);

                Assert.That(response.Status, Is.EqualTo(444));
            }
        }

        [Test]
        public async Task CookiesDisabledByDefault()
        {
            using (TestServer testServer = new TestServer(
                context =>
                {
                    Assert.That(context.Request.Headers.ContainsKey("cookie"), Is.False);
                    context.Response.StatusCode = 200;
                    context.Response.Headers.Add(
                        "set-cookie",
                        "stsservicecookie=estsfd; path=/; secure; samesite=none; httponly");
                }))
            {
                var transport = GetTransport();
                Request request = transport.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);
                request.Content = RequestContent.Create("Hello");
                await ExecuteRequest(request, transport);

                // create a second request to verify cookies not set
                request = transport.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);
                request.Content = RequestContent.Create("Hello");
                await ExecuteRequest(request, transport);
            }
        }

        [Test]
        public async Task ResponseSetToNullOnException()
        {
            using (TestServer testServer = new TestServer(
                       context =>
                       {
                           // simulate network failure so no response is returned
                           context.Abort();
                       }))
            {
                var transport = GetTransport();
                var pipeline = new HttpPipeline(transport);
                var message = pipeline.CreateMessage();
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(testServer.Address);
                message.Request.Content = RequestContent.Create("Hello");
                message.Response = new MockResponse(200);

                try
                {
                    await ProcessAsync(message, transport);
                }
                catch (Exception)
                {
                }

                // response should have been cleared by transport
                Assert.That(message.HasResponse, Is.False);
            }
        }

        private static Request CreateRequest(HttpPipelineTransport transport, TestServer server, byte[] bytes = null)
        {
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(server.Address);
            request.Content = RequestContent.Create(bytes ?? Array.Empty<byte>());
            return request;
        }

        public class DisposeTrackingContent : RequestContent
        {
            public override Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                return Task.CompletedTask;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
            }

            public override bool TryComputeLength(out long length)
            {
                length = 0;
                return false;
            }

            public override void Dispose()
            {
                IsDisposed = true;
            }

            public bool IsDisposed { get; set; }
        }

        private class InfiniteStream : ReadOnlyStream
        {
            public override long Seek(long offset, SeekOrigin origin)
            {
                return 0;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return count;
            }

            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; } = true;
            public override long Length => long.MaxValue;
            public override long Position { get; set; } = 0;
        }

        private class InvalidSizeContent : RequestContent
        {
            private static readonly RequestContent _innerContent = RequestContent.Create(new byte[50]);
            public override void Dispose()
            {
            }

            public override bool TryComputeLength(out long length)
            {
                length = 10;
                return true;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellation)
            {
                _innerContent.WriteTo(stream, cancellation);
            }

            public override Task WriteToAsync(Stream stream, CancellationToken cancellation)
            {
                return _innerContent.WriteToAsync(stream, cancellation);
            }
        }
    }
}
