// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(typeof(HttpClientTransport))]
    [TestFixture(typeof(HttpWebRequestTransport))]
    public class TransportFunctionalTests : PipelineTestBase
    {
        private readonly Type _transportType;

        public TransportFunctionalTests(Type transportType)
        {
            _transportType = transportType;
        }

        private HttpPipelineTransport GetTransport()
        {
            return (HttpPipelineTransport) Activator.CreateInstance(_transportType);
        }

        public static object[] ContentWithLength =>
            new object[]
            {
                new object[] { RequestContent.Create(new byte[10]), 10 },
                new object[] { RequestContent.Create(new byte[10], 5, 5), 5 },
                new object[] { RequestContent.Create(new ReadOnlyMemory<byte>(new byte[10])), 10 },
                new object[] { RequestContent.Create(new ReadOnlyMemory<byte>(new byte[10]).Slice(5)), 5 },
                new object[] { RequestContent.Create(new ReadOnlySequence<byte>(new byte[10])), 10 },
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

            Assert.AreEqual(expectedLength, contentLength);
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
            request.Content = RequestContent.Create(new byte[10]);
            request.Headers.Add("Content-Length", "50");

            try
            {
                await ExecuteRequest(request, transport);
            }
            catch (Exception)
            {
                // Sending the request would fail because of length mismatch
            }

            Assert.AreEqual(50, contentLength);
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

            Assert.AreEqual(testServer.Address.ToString(), uri);
            Assert.AreEqual(testServer.Address.Host + ":" + testServer.Address.Port, host.ToString());
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

            Assert.AreEqual("http://example.org/", uri);
            Assert.AreEqual("example.org", host.ToString());
        }

        public static object[][] Methods => new[]
        {
            new object[] { RequestMethod.Delete, "DELETE" },
            new object[] { RequestMethod.Get, "GET" },
            new object[] { RequestMethod.Patch, "PATCH" },
            new object[] { RequestMethod.Post, "POST" },
            new object[] { RequestMethod.Put, "PUT" },
            new object[] { RequestMethod.Head, "HEAD" },
            new object[] { new RequestMethod("custom"), "CUSTOM" },
        };

        [Theory]
        [TestCaseSource(nameof(Methods))]
        public async Task CanGetAndSetMethod(RequestMethod method, string expectedMethod)
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

            Assert.AreEqual(method, request.Method);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedMethod, httpMethod);
        }

         public static object[] HeadersWithValuesAndType =>
            new object[]
            {
                new object[] { "Allow", "adcde", true },
                new object[] { "Content-Disposition", "adcde", true },
                new object[] { "Content-Encoding", "adcde", true },
                new object[] { "Content-Language", "en-US", true },
                new object[] { "Content-Length", "16", true },
                new object[] { "Content-Location", "adcde", true },
                new object[] { "Content-MD5", "adcde", true },
                new object[] { "Content-Range", "adcde", true },
                new object[] { "Content-Type", "text/xml", true },
                new object[] { "Expires", "11/12/19", true },
                new object[] { "Last-Modified", "11/12/19", true },
                new object[] { "Date", "11/12/19", false },
                new object[] { "Custom-Header", "11/12/19", false }
            };

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndAddRequestHeaders(string headerName, string headerValue, bool contentHeader)
        {
            StringValues httpHeaderValues;

            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, headerValue);

            Assert.True(request.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(request.Headers.TryGetValue(headerName.ToUpper(), out value));
            Assert.AreEqual(headerValue, value);

            CollectionAssert.AreEqual(new[]
            {
                new HttpHeader(headerName, headerValue),
            }, request.Headers);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(headerValue, string.Join(",", httpHeaderValues));
        }

        private static Request CreateRequest(HttpPipelineTransport transport, TestServer server, byte[] bytes = null)
        {
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(server.Address);
            request.Content = RequestContent.Create(bytes ?? Array.Empty<byte>());
            return request;
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
                    Assert.True(response.Headers.TryGetValue("Via", out var via));
                    Assert.AreEqual("Test-Proxy", via);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable(envVar, null);
            }
        }

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
                Assert.True(response.Headers.TryGetValues("Sync-Token", out System.Collections.Generic.IEnumerable<string> tokens));
                Assert.AreEqual(2, tokens.Count());
                CollectionAssert.AreEqual(new[] { "A", "B" }, tokens);
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
                Assert.True(response.Headers.TryGetValues("Sync-Token", out System.Collections.Generic.IEnumerable<string> tokens));
                Assert.AreEqual(1, tokens.Count());
                CollectionAssert.AreEqual(new[] { "A,B" }, tokens);
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
                Assert.IsNotEmpty(exception.Message);
                Assert.AreEqual(0, exception.Status);
            }
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
                Response response = await ExecuteRequest(request, transport);

                tcs.SetResult(null);

                Assert.ThrowsAsync<IOException>(async () => await response.ContentStream.CopyToAsync(new MemoryStream()));
            }
        }
    }
}
