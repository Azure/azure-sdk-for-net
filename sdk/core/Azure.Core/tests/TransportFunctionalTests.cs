// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
                    //context.Abort();
                });
            var maxValue = 2147483592;
            var transport = GetTransport();
            Request request = transport.CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(testServer.Address);
            request.Content = RequestContent.Create(new byte[10]);
            request.Headers.Add("Content-Length", maxValue.ToString());

            try
            {
                Debug.WriteLine(maxValue);
                var traceListener = new DefaultTraceListener();
                ExecuteWithEnabledSystemNetLogging(SourceLevels.All, default, default, default,
                    () => ExecuteRequest(request, transport).GetAwaiter().GetResult(), traceListener
                );
            }
            catch (Exception)
            {
                // Sending the request would fail because of length mismatch
            }

            Assert.AreEqual(maxValue, contentLength);
            await Task.CompletedTask;
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
            StringValues httpHeaderValues;

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

            StringValues httpHeaderValues;

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

            StringValues httpHeaderValues;

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

        /// <summary>
/// Executes a action with enabled System.Net.Logging with listener(s) at the code-site
///
/// Message from Microsoft:
/// To configure you the listeners and level of logging for a listener you need a reference to the listener that is going to be doing the tracing.
/// A call to create a new TraceSource object creates a trace source with the same name as the one used by the System.Net.Sockets classes,
/// but it's not the same trace source object, so any changes do not have an effect on the actual TraceSource object that System.Net.Sockets is using.
/// </summary>
/// <param name="webTraceSourceLevel">The sourceLevel for the System.Net traceSource</param>
/// <param name="httpListenerTraceSourceLevel">The sourceLevel for the System.Net.HttpListener traceSource</param>
/// <param name="socketsTraceSourceLevel">The sourceLevel for the System.Net.Sockets traceSource</param>
/// <param name="cacheTraceSourceLevel">The sourceLevel for the System.Net.Cache traceSource</param>
/// <param name="actionToExecute">The action to execute</param>
/// <param name="listener">The listener(s) to use</param>
public static void ExecuteWithEnabledSystemNetLogging(SourceLevels webTraceSourceLevel, SourceLevels httpListenerTraceSourceLevel, SourceLevels socketsTraceSourceLevel, SourceLevels cacheTraceSourceLevel, Action actionToExecute, params TraceListener[] listener)
{
    if (listener == null)
    {
        throw new ArgumentNullException("listener");
    }

    if (actionToExecute == null)
    {
        throw new ArgumentNullException("actionToExecute");
    }

    var logging = typeof(WebRequest).Assembly.GetType("System.Net.Logging");
    var isInitializedField = logging.GetField("s_LoggingInitialized", BindingFlags.NonPublic | BindingFlags.Static);
    if (!(bool)isInitializedField.GetValue(null))
    {
        //// force initialization
        HttpWebRequest.Create("http://localhost");
        Thread waitForInitializationThread = new Thread(() =>
        {
            while (!(bool)isInitializedField.GetValue(null))
            {
                Thread.Sleep(100);
            }
        });

        waitForInitializationThread.Start();
        waitForInitializationThread.Join();
    }

    var isEnabledField = logging.GetField("s_LoggingEnabled", BindingFlags.NonPublic | BindingFlags.Static);
    var webTraceSource = (TraceSource)logging.GetField("s_WebTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
    var httpListenerTraceSource = (TraceSource)logging.GetField("s_HttpListenerTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
    var socketsTraceSource = (TraceSource)logging.GetField("s_SocketsTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
    var cacheTraceSource = (TraceSource)logging.GetField("s_CacheTraceSource", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

    bool wasEnabled = (bool)isEnabledField.GetValue(null);
    Dictionary<TraceListener, TraceFilter> originalTraceSourceFilters = new Dictionary<TraceListener, TraceFilter>();

    //// save original Levels
    var originalWebTraceSourceLevel = webTraceSource.Switch.Level;
    var originalHttpListenerTraceSourceLevel = httpListenerTraceSource.Switch.Level;
    var originalSocketsTraceSourceLevel = socketsTraceSource.Switch.Level;
    var originalCacheTraceSourceLevel = cacheTraceSource.Switch.Level;

    //System.Net
    webTraceSource.Listeners.AddRange(listener);
    webTraceSource.Switch.Level = SourceLevels.All;
    foreach (TraceListener tl in webTraceSource.Listeners)
    {
        if (!originalTraceSourceFilters.ContainsKey(tl))
        {
            originalTraceSourceFilters.Add(tl, tl.Filter);
            tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
        }
    }

    //System.Net.HttpListener
    httpListenerTraceSource.Listeners.AddRange(listener);
    httpListenerTraceSource.Switch.Level = SourceLevels.All;
    foreach (TraceListener tl in httpListenerTraceSource.Listeners)
    {
        if (!originalTraceSourceFilters.ContainsKey(tl))
        {
            originalTraceSourceFilters.Add(tl, tl.Filter);
            tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
        }
    }

    //System.Net.Sockets
    socketsTraceSource.Listeners.AddRange(listener);
    socketsTraceSource.Switch.Level = SourceLevels.All;
    foreach (TraceListener tl in socketsTraceSource.Listeners)
    {
        if (!originalTraceSourceFilters.ContainsKey(tl))
        {
            originalTraceSourceFilters.Add(tl, tl.Filter);
            tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
        }
    }

    //System.Net.Cache
    cacheTraceSource.Listeners.AddRange(listener);
    cacheTraceSource.Switch.Level = SourceLevels.All;
    foreach (TraceListener tl in cacheTraceSource.Listeners)
    {
        if (!originalTraceSourceFilters.ContainsKey(tl))
        {
            originalTraceSourceFilters.Add(tl, tl.Filter);
            tl.Filter = new ModifiedTraceFilter(tl, originalWebTraceSourceLevel, webTraceSourceLevel, originalHttpListenerTraceSourceLevel, httpListenerTraceSourceLevel, originalSocketsTraceSourceLevel, socketsTraceSourceLevel, originalCacheTraceSourceLevel, cacheTraceSourceLevel, listener.Contains(tl));
        }
    }

    isEnabledField.SetValue(null, true);

    try
    {
        actionToExecute();
    }
    finally
    {
        //// restore Settings
        webTraceSource.Switch.Level = originalWebTraceSourceLevel;
        httpListenerTraceSource.Switch.Level = originalHttpListenerTraceSourceLevel;
        socketsTraceSource.Switch.Level = originalSocketsTraceSourceLevel;
        cacheTraceSource.Switch.Level = originalCacheTraceSourceLevel;

        foreach (var li in listener)
        {
            webTraceSource.Listeners.Remove(li);
            httpListenerTraceSource.Listeners.Remove(li);
            socketsTraceSource.Listeners.Remove(li);
            cacheTraceSource.Listeners.Remove(li);
        }

        //// restore filters
        foreach (var kvP in originalTraceSourceFilters)
        {
            kvP.Key.Filter = kvP.Value;
        }

        isEnabledField.SetValue(null, wasEnabled);
    }
}
public class ModifiedTraceFilter : TraceFilter
{
    private readonly TraceListener _traceListener;

    private readonly SourceLevels _originalWebTraceSourceLevel;

    private readonly SourceLevels _originalHttpListenerTraceSourceLevel;

    private readonly SourceLevels _originalSocketsTraceSourceLevel;

    private readonly SourceLevels _originalCacheTraceSourceLevel;

    private readonly SourceLevels _modifiedWebTraceTraceSourceLevel;

    private readonly SourceLevels _modifiedHttpListenerTraceSourceLevel;

    private readonly SourceLevels _modifiedSocketsTraceSourceLevel;

    private readonly SourceLevels _modifiedCacheTraceSourceLevel;

    private readonly bool _ignoreOriginalSourceLevel;

    private readonly TraceFilter _filter = null;

    public ModifiedTraceFilter(TraceListener traceListener, SourceLevels originalWebTraceSourceLevel, SourceLevels modifiedWebTraceSourceLevel, SourceLevels originalHttpListenerTraceSourceLevel, SourceLevels modifiedHttpListenerTraceSourceLevel, SourceLevels originalSocketsTraceSourceLevel, SourceLevels modifiedSocketsTraceSourceLevel, SourceLevels originalCacheTraceSourceLevel, SourceLevels modifiedCacheTraceSourceLevel, bool ignoreOriginalSourceLevel)
    {
        _traceListener = traceListener;
        _filter = traceListener.Filter;
        _originalWebTraceSourceLevel = originalWebTraceSourceLevel;
        _modifiedWebTraceTraceSourceLevel = modifiedWebTraceSourceLevel;
        _originalHttpListenerTraceSourceLevel = originalHttpListenerTraceSourceLevel;
        _modifiedHttpListenerTraceSourceLevel = modifiedHttpListenerTraceSourceLevel;
        _originalSocketsTraceSourceLevel = originalSocketsTraceSourceLevel;
        _modifiedSocketsTraceSourceLevel = modifiedSocketsTraceSourceLevel;
        _originalCacheTraceSourceLevel = originalCacheTraceSourceLevel;
        _modifiedCacheTraceSourceLevel = modifiedCacheTraceSourceLevel;
        _ignoreOriginalSourceLevel = ignoreOriginalSourceLevel;
    }

    public override bool ShouldTrace(TraceEventCache cache, string source, TraceEventType eventType, int id, string formatOrMessage, object[] args, object data1, object[] data)
    {
        SourceLevels originalTraceSourceLevel = SourceLevels.Off;
        SourceLevels modifiedTraceSourceLevel = SourceLevels.Off;

        if (source == "System.Net")
        {
            originalTraceSourceLevel = _originalWebTraceSourceLevel;
            modifiedTraceSourceLevel = _modifiedWebTraceTraceSourceLevel;
        }
        else if (source == "System.Net.HttpListener")
        {
            originalTraceSourceLevel = _originalHttpListenerTraceSourceLevel;
            modifiedTraceSourceLevel = _modifiedHttpListenerTraceSourceLevel;
        }
        else if (source == "System.Net.Sockets")
        {
            originalTraceSourceLevel = _originalSocketsTraceSourceLevel;
            modifiedTraceSourceLevel = _modifiedSocketsTraceSourceLevel;
        }
        else if (source == "System.Net.Cache")
        {
            originalTraceSourceLevel = _originalCacheTraceSourceLevel;
            modifiedTraceSourceLevel = _modifiedCacheTraceSourceLevel;
        }

        var level = ConvertToSourceLevel(eventType);
        if (!_ignoreOriginalSourceLevel && (originalTraceSourceLevel & level) == level)
        {
            if (_filter == null)
            {
                return true;
            }
            else
            {
                return _filter.ShouldTrace(cache, source, eventType, id, formatOrMessage, args, data1, data);
            }
        }
        else if (_ignoreOriginalSourceLevel && (modifiedTraceSourceLevel & level) == level)
        {
            if (_filter == null)
            {
                return true;
            }
            else
            {
                return _filter.ShouldTrace(cache, source, eventType, id, formatOrMessage, args, data1, data);
            }
        }

        return false;
    }

    private static SourceLevels ConvertToSourceLevel(TraceEventType eventType)
    {
        switch (eventType)
        {
            case TraceEventType.Critical:
                return SourceLevels.Critical;
            case TraceEventType.Error:
                return SourceLevels.Error;
            case TraceEventType.Information:
                return SourceLevels.Information;
            case TraceEventType.Verbose:
                return SourceLevels.Verbose;
            case TraceEventType.Warning:
                return SourceLevels.Warning;
            default:
                return SourceLevels.ActivityTracing;
        }
    }
}

    }
}
