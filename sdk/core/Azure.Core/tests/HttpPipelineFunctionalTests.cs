// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(typeof(HttpClientTransport), true)]
    [TestFixture(typeof(HttpClientTransport), false)]
#if NETFRAMEWORK
    [TestFixture(typeof(HttpWebRequestTransport), true)]
    [TestFixture(typeof(HttpWebRequestTransport), false)]
#endif
    public class HttpPipelineFunctionalTests : PipelineTestBase
    {
        private readonly Type _transportType;

        public HttpPipelineFunctionalTests(Type transportType, bool isAsync) : base(isAsync)
        {
            _transportType = transportType;
        }

        private TestOptions GetOptions()
        {
            var options = new TestOptions();
            options.Transport = (HttpPipelineTransport)Activator.CreateInstance(_transportType);
            return options;
        }

        [Test]
        public async Task SendRequestBuffersResponse()
        {
            byte[] buffer = { 0 };

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());

            using TestServer testServer = new TestServer(
                async context =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });
            // Make sure we dispose things correctly and not exhaust the connection pool
            for (int i = 0; i < 100; i++)
            {
                using Request request = httpPipeline.CreateRequest();
                request.Uri.Reset(testServer.Address);

                using Response response = await ExecuteRequest(request, httpPipeline);

                Assert.AreEqual(response.ContentStream.Length, 1000);
                Assert.AreEqual(response.Content.ToMemory().Length, 1000);
            }
        }

        [Test]
        public async Task NonBufferedExtractedStreamReadableAfterMessageDisposed()
        {
            byte[] buffer = { 0 };

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            TaskCompletionSource<object> blockRequestTsc = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using TestServer testServer = new TestServer(
                async context =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });

            // Make sure we dispose things correctly and not exhaust the connection pool
            for (int i = 0; i < 100; i++)
            {
                Stream extractedStream;
                using (HttpMessage message = httpPipeline.CreateMessage())
                {
                    message.Request.Uri.Reset(testServer.Address);
                    message.BufferResponse = false;

                    await ExecuteRequest(message, httpPipeline);

                    Assert.False(message.Response.ContentStream.CanSeek);
                    Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });

                    extractedStream = message.ExtractResponseContent();
                }

                var memoryStream = new MemoryStream();
                await extractedStream.CopyToAsync(memoryStream);
                Assert.AreEqual(1000, memoryStream.Length);
                extractedStream.Dispose();
            }
        }

        [Test]
        public async Task NonBufferedFailedResponsesAreDisposedOf()
        {
            byte[] buffer = { 0 };

            var clientOptions = new TestOptions();
            clientOptions.Retry.Delay = TimeSpan.FromMilliseconds(2);
            clientOptions.Retry.NetworkTimeout = TimeSpan.FromSeconds(5);

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(clientOptions);

            int bodySize = 1000;
            int reqNum = 0;

            using TestServer testServer = new TestServer(
                async context =>
                {
                    if (Interlocked.Increment(ref reqNum) % 2 == 0)
                    {
                        // Respond with 503 to every other request to force a retry
                        context.Response.StatusCode = 503;
                    }

                    for (int i = 0; i < bodySize; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });

            // Make sure we dispose things correctly and not exhaust the connection pool
            var requestCount = 100;
            for (int i = 0; i < requestCount; i++)
            {
                Stream extractedStream;
                using (HttpMessage message = httpPipeline.CreateMessage())
                {
                    message.Request.Uri.Reset(testServer.Address);
                    message.BufferResponse = false;

                    await ExecuteRequest(message, httpPipeline);

                    Assert.AreEqual(message.Response.ContentStream.CanSeek, false);
                    Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });

                    extractedStream = message.ExtractResponseContent();
                }

                var memoryStream = new MemoryStream();
                await extractedStream.CopyToAsync(memoryStream);
                Assert.AreEqual(memoryStream.Length, bodySize);
                extractedStream.Dispose();
            }

            Assert.Greater(reqNum, requestCount);
        }

        [Test]
        public async Task Opens50ParallelConnections()
        {
            // Running 50 sync requests on the threadpool would cause starvation
            // and the test would take 20 sec to finish otherwise
            ThreadPool.SetMinThreads(100, 100);

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            int reqNum = 0;

            TaskCompletionSource<object> requestsTcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using TestServer testServer = new TestServer(
                async context =>
                {
                    if (Interlocked.Increment(ref reqNum) == 50)
                    {
                        requestsTcs.SetResult(true);
                    }

                    await requestsTcs.Task;
                });

            var requestCount = 50;
            List<Task> requests = new List<Task>();
            for (int i = 0; i < requestCount; i++)
            {
                HttpMessage message = httpPipeline.CreateMessage();
                message.Request.Uri.Reset(testServer.Address);

                requests.Add(Task.Run(() => ExecuteRequest(message, httpPipeline)));
            }

            await Task.WhenAll(requests);
        }

        [Test]
        [Category("Live")]
        public async Task Opens50ParallelConnectionsLive()
        {
            // Running 50 sync requests on the threadpool would cause starvation
            // and the test would take 20 sec to finish otherwise
            ThreadPool.SetMinThreads(100, 100);

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            int reqNum = 0;

            TaskCompletionSource<object> requestsTcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            async Task Connect()
            {
                using HttpMessage message = httpPipeline.CreateMessage();
                message.Request.Uri.Reset(new Uri("https://www.microsoft.com/"));
                message.BufferResponse = false;

                await ExecuteRequest(message, httpPipeline);

                if (Interlocked.Increment(ref reqNum) == 50)
                {
                    requestsTcs.SetResult(true);
                }

                await requestsTcs.Task;
            }

            var requestCount = 50;
            List<Task> requests = new List<Task>();
            for (int i = 0; i < requestCount; i++)
            {
                requests.Add(Task.Run(() => Connect()));
            }

            await Task.WhenAll(requests);
        }

        [TestCase(200)]
        [TestCase(404)]
        public async Task BufferedResponsesReadableAfterMessageDisposed(int status)
        {
            byte[] buffer = { 0 };

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());

            int bodySize = 1000;

            using TestServer testServer = new TestServer(
                async context =>
                {
                    context.Response.StatusCode = status;
                    for (int i = 0; i < bodySize; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });

            var requestCount = 100;
            for (int i = 0; i < requestCount; i++)
            {
                Response response;
                using (HttpMessage message = httpPipeline.CreateMessage())
                {
                    message.Request.Uri.Reset(testServer.Address);
                    message.BufferResponse = true;

                    await ExecuteRequest(message, httpPipeline);

                    response = message.Response;
                }

                var memoryStream = new MemoryStream();
                await response.ContentStream.CopyToAsync(memoryStream);
                Assert.AreEqual(memoryStream.Length, bodySize);
            }
        }

        [Test]
        public async Task UnbufferedResponsesDisposedAfterMessageDisposed()
        {
            byte[] buffer = { 0 };

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());

            int bodySize = 1000;

            using TestServer testServer = new TestServer(
                async context =>
                {
                    for (int i = 0; i < bodySize; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });

            var requestCount = 100;
            for (int i = 0; i < requestCount; i++)
            {
                Response response;
                Mock<Stream> disposeTrackingStream = null;
                using (HttpMessage message = httpPipeline.CreateMessage())
                {
                    message.Request.Uri.Reset(testServer.Address);
                    message.BufferResponse = false;

                    await ExecuteRequest(message, httpPipeline);

                    response = message.Response;
                    var originalStream = response.ContentStream;
                    disposeTrackingStream = new Mock<Stream>();
                    disposeTrackingStream
                        .Setup(s => s.Close())
                        .Callback(originalStream.Close)
                        .Verifiable();
                    response.ContentStream = disposeTrackingStream.Object;
                }

                disposeTrackingStream.Verify();
            }
        }

        [Test]
        public async Task RetriesTransportFailures()
        {
            int i = 0;
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());

            using TestServer testServer = new TestServer(
                context =>
                {
                    if (Interlocked.Increment(ref i) == 1)
                    {
                        context.Abort();
                    }
                    else
                    {
                        context.Response.StatusCode = 201;
                    }
                    return Task.CompletedTask;
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = false;

            await ExecuteRequest(message, httpPipeline);

            Assert.AreEqual(message.Response.Status, 201);
            Assert.AreEqual(2, i);
        }

        [Test]
        public async Task RetriesTimeoutsServerTimeouts()
        {
            var testDoneTcs = new CancellationTokenSource();
            int i = 0;
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions
            {
                Retry =
                {
                    NetworkTimeout = TimeSpan.FromMilliseconds(500)
                }
            });

            using TestServer testServer = new TestServer(
                async context =>
                {
                    if (Interlocked.Increment(ref i) == 1)
                    {
                        await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                    }
                    else
                    {
                        context.Response.StatusCode = 201;
                    }
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = false;

            await ExecuteRequest(message, httpPipeline);

            Assert.AreEqual(message.Response.Status, 201);
            Assert.AreEqual(2, i);

            testDoneTcs.Cancel();
        }

        [Test]
        public async Task DoesntRetryClientCancellation()
        {
            var testDoneTcs = new CancellationTokenSource();
            int i = 0;
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using TestServer testServer = new TestServer(
                async context =>
                {
                    Interlocked.Increment(ref i);
                    tcs.SetResult(null);
                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                });

            var cts = new CancellationTokenSource();
            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = false;

            var task = Task.Run(() => ExecuteRequest(message, httpPipeline, cts.Token));

            // Wait for server to receive a request
            await tcs.Task;

            cts.Cancel();

            var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await task);
            Assert.AreEqual("The operation was canceled.", exception.Message);
            Assert.AreEqual(1, i);

            testDoneTcs.Cancel();
        }

        [Test]
        public async Task RetriesBufferedBodyTimeout()
        {
            var testDoneTcs = new CancellationTokenSource();
            int i = 0;
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions
            {
                Retry =
                {
                    NetworkTimeout = TimeSpan.FromMilliseconds(500)
                }
            });

            using TestServer testServer = new TestServer(
                async context =>
                {
                    if (Interlocked.Increment(ref i) == 1)
                    {
                        context.Response.StatusCode = 200;
                        context.Response.Headers.ContentLength = 10;
                        await context.Response.WriteAsync("1");
                        await context.Response.Body.FlushAsync();

                        await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                    }
                    else
                    {
                        context.Response.StatusCode = 201;
                        await context.Response.WriteAsync("Hello world!");
                    }
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = true;

            await ExecuteRequest(message, httpPipeline);

            Assert.AreEqual(message.Response.Status, 201);
            Assert.AreEqual("Hello world!", await new StreamReader(message.Response.ContentStream).ReadToEndAsync());
            Assert.AreEqual("Hello world!", message.Response.Content.ToString());
            Assert.AreEqual(2, i);

            testDoneTcs.Cancel();
        }

        [Test]
        public void TimeoutsResponseBuffering()
        {
            var testDoneTcs = new CancellationTokenSource();
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions
            {
                Retry =
                {
                    NetworkTimeout = TimeSpan.FromMilliseconds(500),
                    MaxRetries = 0
                }
            });

            using TestServer testServer = new TestServer(
                async _ =>
                {
                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = true;

            var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await ExecuteRequest(message, httpPipeline));
            Assert.AreEqual("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. " +
                            "Network timeout can be adjusted in ClientOptions.Retry.NetworkTimeout.", exception.Message);

            testDoneTcs.Cancel();
        }

        [Test]
        public void TimeoutsBodyBuffering()
        {
            var testDoneTcs = new CancellationTokenSource();
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions
            {
                Retry =
                {
                    NetworkTimeout = TimeSpan.FromMilliseconds(500),
                    MaxRetries = 0
                }
            });

            using TestServer testServer = new TestServer(
                async context =>
                {
                    context.Response.StatusCode = 200;
                    context.Response.Headers.ContentLength = 10;
                    await context.Response.WriteAsync("1");
                    await context.Response.Body.FlushAsync();

                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = true;

            var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await ExecuteRequest(message, httpPipeline));
            Assert.AreEqual("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. " +
                            "Network timeout can be adjusted in ClientOptions.Retry.NetworkTimeout.", exception.Message);

            testDoneTcs.Cancel();
        }

        [Test]
        public async Task TimeoutsUnbufferedBodyReads()
        {
            var testDoneTcs = new CancellationTokenSource();

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions
            {
                Retry =
                {
                    NetworkTimeout = TimeSpan.FromMilliseconds(500)
                }
            });

            using TestServer testServer = new TestServer(
                async context =>
                {
                    context.Response.StatusCode = 200;
                    context.Response.Headers.Add("Connection", "close");
                    await context.Response.WriteAsync("1");
                    await context.Response.Body.FlushAsync();

                    await Task.Delay(Timeout.Infinite, testDoneTcs.Token);
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            message.Request.Uri.Reset(testServer.Address);
            message.BufferResponse = false;

            await ExecuteRequest(message, httpPipeline);

            Assert.AreEqual(message.Response.Status, 200);
            var responseContentStream = message.Response.ContentStream;
            Assert.Throws<InvalidOperationException>(() => { var content = message.Response.Content; });
            var buffer = new byte[10];
            Assert.AreEqual(1, await responseContentStream.ReadAsync(buffer, 0, 1));

#pragma warning disable CA2022 // The return value of ReadAsync is not needed for this test
            var exception = Assert.ThrowsAsync<TaskCanceledException>(async () => await responseContentStream.ReadAsync(buffer, 0, 10));
#pragma warning restore CA2022
            Assert.AreEqual("The operation was cancelled because it exceeded the configured timeout of 0:00:00.5. " +
                            "Network timeout can be adjusted in ClientOptions.Retry.NetworkTimeout.", exception.Message);

            testDoneTcs.Cancel();
        }

        [Test]
        public async Task SendMultipartformData()
        {
            IFormCollection formCollection = null;

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            using TestServer testServer = new TestServer(
                context =>
                {
                    formCollection = context.Request.Form;
                    return Task.CompletedTask;
                });

            using Request request = httpPipeline.CreateRequest();
            request.Method = RequestMethod.Put;
            request.Uri.Reset(testServer.Address);

            var content = new MultipartFormDataContent("test_boundary");
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("John")), "FirstName", "file_name.txt", new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            });
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Doe")), "LastName", "file_name.txt", new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            });

            content.ApplyToRequest(request);

            using Response response = await ExecuteRequest(request, httpPipeline);
            Assert.AreEqual(response.Status, 200);
            Assert.AreEqual(formCollection.Files.Count, 2);

            var formData = formCollection.Files.GetEnumerator();
            formData.MoveNext();
            Assert.AreEqual(formData.Current.Name, "FirstName");
            Assert.AreEqual(formData.Current.FileName, "file_name.txt");
            Assert.AreEqual(formData.Current.Headers.Count, 2);
            Assert.AreEqual(formData.Current.ContentType, "text/plain; charset=utf-8");
            Assert.AreEqual(formData.Current.ContentDisposition, "form-data; name=FirstName; filename=file_name.txt");

            formData.MoveNext();
            Assert.AreEqual(formData.Current.Name, "LastName");
            Assert.AreEqual(formData.Current.FileName, "file_name.txt");
            Assert.AreEqual(formData.Current.Headers.Count, 2);
            Assert.AreEqual(formData.Current.ContentType, "text/plain; charset=utf-8");
            Assert.AreEqual(formData.Current.ContentDisposition, "form-data; name=LastName; filename=file_name.txt");
        }

        [Test]
        public async Task HandlesRedirects([Values(true, false)] bool allowRedirects)
        {
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            Uri testServerAddress = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    if (context.Request.Path.ToString().Contains("/redirected"))
                    {
                        context.Response.StatusCode = 200;
                    }
                    else
                    {
                        context.Response.StatusCode = 300;
                        context.Response.Headers.Add("Location", testServerAddress + "/redirected");
                    }
                    return Task.CompletedTask;
                });

            testServerAddress = testServer.Address;

            using HttpMessage message = httpPipeline.CreateMessage();
            if (allowRedirects)
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
            }
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            using Response response = await ExecuteRequest(message, httpPipeline);
            if (allowRedirects)
            {
                Assert.AreEqual(response.Status, 200);
            }
            else
            {
                Assert.AreEqual(response.Status, 300);
            }
        }

        [Test]
        public async Task HandlesRelativeRedirects([Values(true, false)] bool allowRedirects)
        {
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            using TestServer testServer = new TestServer(
                context =>
                {
                    if (context.Request.Path.ToString().Contains("/redirected"))
                    {
                        context.Response.StatusCode = 200;
                    }
                    else
                    {
                        context.Response.StatusCode = 300;
                        context.Response.Headers.Add("Location", "/redirected");
                    }
                    return Task.CompletedTask;
                });

            using HttpMessage message = httpPipeline.CreateMessage();
            if (allowRedirects)
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
            }
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            using Response response = await ExecuteRequest(message, httpPipeline);
            if (allowRedirects)
            {
                Assert.AreEqual(response.Status, 200);
            }
            else
            {
                Assert.AreEqual(response.Status, 300);
            }
        }

        [Test]
        public async Task PerRetryPolicyObservesRedirect([Values(true, false)] bool allowRedirects)
        {
            List<string> uris = new List<string>();
            var options = GetOptions();
            var perRetryPolicy = new CallbackPolicy(message => uris.Add(message.Request.Uri.ToString()));
            options.AddPolicy(perRetryPolicy, HttpPipelinePosition.PerRetry);
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(options);
            Uri testServerAddress = null;
            using TestServer testServer = new TestServer(
                context =>
                {
                    if (context.Request.Path.ToString().Contains("/redirected"))
                    {
                        context.Response.StatusCode = 200;
                    }
                    else
                    {
                        context.Response.StatusCode = 300;
                        context.Response.Headers.Add("Location", testServerAddress + "/redirected");
                    }
                    return Task.CompletedTask;
                });

            testServerAddress = testServer.Address;

            using HttpMessage message = httpPipeline.CreateMessage();
            if (allowRedirects)
            {
                RedirectPolicy.SetAllowAutoRedirect(message, true);
            }
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            using Response response = await ExecuteRequest(message, httpPipeline);
            if (allowRedirects)
            {
                Assert.AreEqual(response.Status, 200);
                Assert.AreEqual(2, uris.Count);
                Assert.AreEqual(1, uris.Count(u => u.Contains("/redirected")));
            }
            else
            {
                Assert.AreEqual(response.Status, 300);
            }
        }

        [Test]
        public async Task StopsOnMaxRedirects()
        {
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            Uri testServerAddress = null;
            int count = 0;
            using TestServer testServer = new TestServer(
                context =>
                {
                    Interlocked.Increment(ref count);
                    context.Response.StatusCode = 300;
                    context.Response.Headers.Add("Location", testServerAddress + "/redirected");
                });

            testServerAddress = testServer.Address;

            using HttpMessage message = httpPipeline.CreateMessage();
            RedirectPolicy.SetAllowAutoRedirect(message, true);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(testServer.Address);

            using Response response = await ExecuteRequest(message, httpPipeline);
            Assert.AreEqual(300, response.Status);
            Assert.AreEqual(51, count);
        }

        private class CallbackPolicy : HttpPipelineSynchronousPolicy
        {
            private readonly Action<HttpMessage> _callback;

            public CallbackPolicy(Action<HttpMessage> callback)
            {
                _callback = callback;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                base.OnSendingRequest(message);
                _callback(message);
            }
        }
        private class TestOptions : ClientOptions
        {
        }
    }
}
