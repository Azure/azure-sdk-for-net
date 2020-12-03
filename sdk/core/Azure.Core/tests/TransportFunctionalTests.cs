// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(typeof(HttpClientTransport), true)]
    [TestFixture(typeof(HttpClientTransport), false)]
#if NETFRAMEWORK
    [TestFixture(typeof(HttpWebRequestTransport), true)]
    [TestFixture(typeof(HttpWebRequestTransport), false)]
#endif
    public class TransportFunctionalTests : PipelineTestBase
    {
        private readonly Type _transportType;

        public TransportFunctionalTests(Type transportType, bool isAsync) : base(isAsync)
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
        public async Task CanSetContentLenghtOverMaxInt()
        {
            long contentLength = 0;
            using TestServer testServer = new TestServer(
                context =>
                {
                    contentLength = context.Request.ContentLength.Value;
                });

            var requestContentLength = long.MaxValue;
            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            request.Content = RequestContent.Create(new byte[10]);
            request.Headers.Add("Content-Length", requestContentLength.ToString());

            try
            {
                await ExecuteRequest(request, transport);
            }
            catch (Exception)
            {
                // Sending the request would fail because of length mismatch
            }

            Assert.AreEqual(requestContentLength, requestContentLength);
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

            Assert.AreEqual(code, response.Status);
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

            Assert.AreEqual(method, request.Method);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(expectedMethod, httpMethod);
        }

        public static object[] AllHeadersWithValuesAndType =>
            HeadersWithValuesAndType.Concat(SpecialHeadersWithValuesAndType).ToArray();

         public static object[] HeadersWithValuesAndType =>
            new object[]
            {
                new object[] { "Allow", "adcde", true },
                new object[] { "Accept", "adcde", true },
                new object[] { "Referer", "adcde", true },
                new object[] { "User-Agent", "adcde", true },
                new object[] { "Content-Disposition", "adcde", true },
                new object[] { "Content-Encoding", "adcde", true },
                new object[] { "Content-Language", "en-US", true },
                new object[] { "Content-Location", "adcde", true },
                new object[] { "Content-MD5", "adcde", true },
                new object[] { "Content-Range", "adcde", true },
                new object[] { "Content-Type", "text/xml", true },
                new object[] { "Expires", "11/12/19", true },
                new object[] { "Last-Modified", "11/12/19", true },
                new object[] { "Custom-Header", "11/12/19", false },
            };

         public static object[] SpecialHeadersWithValuesAndType =>
             new object[]
             {
                 new object[] { "Range", "bytes=0-", false },
                 new object[] { "Range", "bytes=0-100", false },
                 new object[] { "Content-Length", "16", true },
                 new object[] { "Date", "Tue, 12 Nov 2019 08:00:00 GMT", false }
             };

         [TestCaseSource(nameof(AllHeadersWithValuesAndType))]
         public async Task CanGetAndAddRequestHeaders(string headerName, string headerValue, bool contentHeader)
         {
            StringValues httpHeaderValues = default;

             using TestServer testServer = new TestServer(
                 context =>
                 {
                     Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
                 });

             var transport = GetTransport();
             Request request = CreateRequest(transport, testServer);

             request.Headers.Add(headerName, headerValue);

             if (contentHeader)
             {
                 request.Content = RequestContent.Create(new byte[16]);
             }

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

         [TestCaseSource(nameof(AllHeadersWithValuesAndType))]
         public async Task CanGetAndAddRequestHeadersUppercase(string headerName, string headerValue, bool contentHeader)
         {
             await CanGetAndAddRequestHeaders(headerName.ToUpperInvariant(), headerValue, contentHeader);
         }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public void TryGetReturnsCorrectValuesWhenNotFound(string headerName, string headerValue, bool contentHeader)
        {
            var transport = GetTransport();
            Request request = transport.CreateRequest();

            Assert.False(request.Headers.TryGetValue(headerName, out string value));
            Assert.IsNull(value);

            Assert.False(request.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            Assert.IsNull(values);
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanAddMultipleValuesToRequestHeader(string headerName, string headerValue, bool contentHeader)
        {
            var anotherHeaderValue = headerValue + "1";
            var joinedHeaderValues = headerValue + "," + anotherHeaderValue;

            StringValues httpHeaderValues = default;

            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, headerValue);
            request.Headers.Add(headerName, anotherHeaderValue);

            Assert.True(request.Headers.Contains(headerName));

            Assert.True(request.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(joinedHeaderValues, value);

            Assert.True(request.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, values);

            CollectionAssert.AreEqual(new[]
            {
                new HttpHeader(headerName, joinedHeaderValues),
            }, request.Headers);

            await ExecuteRequest(request, transport);

            StringAssert.Contains(headerValue, httpHeaderValues.ToString());
            StringAssert.Contains(anotherHeaderValue, httpHeaderValues.ToString());
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetResponseHeaders(string headerName, string headerValue, bool contentHeader)
        {
            using TestServer testServer = new TestServer(
                context =>
                {
                    context.Response.Headers.Add(headerName, headerValue);
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            Response response = await ExecuteRequest(request, transport);

            Assert.True(response.Headers.Contains(headerName));

            Assert.True(response.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(headerValue, value);

            Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            CollectionAssert.AreEqual(new[] { headerValue }, values);

            CollectionAssert.Contains(response.Headers, new HttpHeader(headerName, headerValue));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanGetAndSetMultiValueResponseHeaders(string headerName, string headerValue, bool contentHeader)
        {
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

            Assert.True(response.Headers.Contains(headerName));

            Assert.True(response.Headers.TryGetValue(headerName, out var value));
            Assert.AreEqual(joinedHeaderValues, value);

            Assert.True(response.Headers.TryGetValues(headerName, out IEnumerable<string> values));
            CollectionAssert.AreEqual(new[] { headerValue, anotherHeaderValue }, values);

            CollectionAssert.Contains(response.Headers, new HttpHeader(headerName, joinedHeaderValues));
        }

        [TestCaseSource(nameof(HeadersWithValuesAndType))]
        public async Task CanRemoveHeaders(string headerName, string headerValue, bool contentHeader)
        {
            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.False(context.Request.Headers.TryGetValue(headerName, out _));
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, headerValue);
            Assert.True(request.Headers.Remove(headerName));
            Assert.False(request.Headers.Remove(headerName));

            Assert.False(request.Headers.TryGetValue(headerName, out _));
            Assert.False(request.Headers.TryGetValue(headerName.ToUpper(), out _));
            Assert.False(request.Headers.Contains(headerName.ToUpper()));

            await ExecuteRequest(request, transport);
        }

        [TestCaseSource(nameof(AllHeadersWithValuesAndType))]
        public async Task CanSetRequestHeaders(string headerName, string headerValue, bool contentHeader)
        {
            StringValues httpHeaderValues = default;

            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.True(context.Request.Headers.TryGetValue(headerName, out httpHeaderValues));
                });

            var transport = GetTransport();
            Request request = CreateRequest(transport, testServer);

            request.Headers.Add(headerName, "Random value");
            request.Headers.SetValue(headerName, headerValue);

            if (contentHeader)
            {
                request.Content = RequestContent.Create(new byte[16]);
            }

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

            Assert.AreEqual(content, request.Content);

            await ExecuteRequest(request, transport);

            CollectionAssert.AreEqual(bytes, requestBytes);
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
            stream.SetLength(10*1024);
            var content = RequestContent.Create(stream);
            var transport = GetTransport();

            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            request.Content = content;

            Assert.AreEqual(content, request.Content);

            await ExecuteRequest(request, transport);

            CollectionAssert.AreEqual(stream.ToArray(), requestBytes);
            Assert.AreEqual(10*1024, requestBytes.Length);
        }

        [Test]
        public async Task ContentLength0WhenNoContent()
        {
            StringValues contentLengthHeader = default;
            using TestServer testServer = new TestServer(
                context =>
                {
                    Assert.True(context.Request.Headers.TryGetValue("Content-Length", out contentLengthHeader));
                });

            var transport = GetTransport();

            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);

            await ExecuteRequest(request, transport);

            Assert.AreEqual(contentLengthHeader.ToString(), "0");
        }

        [Test]
        public async Task RequestAndResponseHasRequestId()
        {
            using TestServer testServer = new TestServer(context => { });
            var transport = GetTransport();
            Request request = transport.CreateRequest();
            Assert.IsNotEmpty(request.ClientRequestId);
            Assert.True(Guid.TryParse(request.ClientRequestId, out _));
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            Response response = await ExecuteRequest(request, transport);
            Assert.AreEqual(request.ClientRequestId, response.ClientRequestId);
        }

        [Test]
        public async Task RequestIdCanBeOverriden()
        {
            using TestServer testServer = new TestServer(context => { });
            var transport = GetTransport();
            Request request = transport.CreateRequest();

            request.ClientRequestId = "123";
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            Response response = await ExecuteRequest(request, transport);
            Assert.AreEqual(request.ClientRequestId, response.ClientRequestId);
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

            Assert.AreEqual("Custom ReasonPhrase", response.ReasonPhrase);
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

            Assert.AreEqual(new long [] {3, 3}, requests);
        }

        [Test]
        public async Task RequestContentIsNotDisposedOnSend()
        {
            using TestServer testServer = new TestServer(context =>{});

            DisposeTrackingContent disposeTrackingContent = new DisposeTrackingContent();
            var transport = GetTransport();

            using (Request request = transport.CreateRequest())
            {
                request.Content = disposeTrackingContent;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(testServer.Address);

                await ExecuteRequest(request, transport);
                Assert.False(disposeTrackingContent.IsDisposed);
            }

            Assert.True(disposeTrackingContent.IsDisposed);
        }
        [Test]
        public void GetIsDefaultMethod()
        {
            var transport = GetTransport();
            var request = transport.CreateRequest();
            Assert.AreEqual("GET", request.Method.Method);
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
                    Assert.True(response.Headers.TryGetValue("Via", out var via));
                    Assert.AreEqual("Test-Proxy", via);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable(envVar, null);
            }
        }

#if NET461 // GlobalProxySelection.Select not supported on netcoreapp
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
                    Assert.True(response.Headers.TryGetValue("Via", out var via));
                    Assert.AreEqual("Test-Proxy", via);
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
        public async Task ThrowsTaskCanceledExceptionWhenCancelled()
        {
            var testDoneTcs = new CancellationTokenSource();
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using TestServer testServer = new TestServer(
                async context =>
                {
                    tcs.SetResult(null);
                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                });

            var cts = new CancellationTokenSource();
            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Uri.Reset(testServer.Address);

            var task = Task.Run(async () => await ExecuteRequest(request, transport, cts.Token));

            // Wait for server to receive a request
            await tcs.Task;

            cts.Cancel();

            Assert.ThrowsAsync(Is.InstanceOf<TaskCanceledException>(), async () => await task);
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
                Response response = await ExecuteRequest(request, transport);

                tcs.SetResult(null);

                Assert.ThrowsAsync<IOException>(async () => await response.ContentStream.CopyToAsync(new MemoryStream()));
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
    }
}
