// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
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

        [Test]
        public async Task BufferedResponsesReadableAfterMessageDisposed()
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
                using (HttpMessage message = httpPipeline.CreateMessage())
                {
                    message.Request.Uri.Reset(testServer.Address);
                    message.BufferResponse = false;

                    await ExecuteRequest(message, httpPipeline);

                    Assert.AreEqual(message.Response.ContentStream.CanSeek, false);

                    response = message.Response;
                }

                var memoryStream = new MemoryStream();
                await response.ContentStream.CopyToAsync(memoryStream);
                Assert.AreEqual(memoryStream.Length, bodySize);
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

            Assert.ThrowsAsync(Is.InstanceOf<TaskCanceledException>(), async () => await task);
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
            Assert.AreEqual(2, i);

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

            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] Starting");
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
            var buffer = new byte[10];
            Assert.AreEqual(1, await responseContentStream.ReadAsync(buffer, 0, 1));
            Assert.That(async () => await responseContentStream.ReadAsync(buffer, 0, 10), Throws.InstanceOf<OperationCanceledException>());

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

        private class TestOptions : ClientOptions
        {
        }
    }
}
