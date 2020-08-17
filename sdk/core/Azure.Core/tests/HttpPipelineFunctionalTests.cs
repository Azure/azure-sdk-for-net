// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Core.Tests
{

    [TestFixture(typeof(HttpClientTransport), true)]
    [TestFixture(typeof(HttpClientTransport), false)]
    // TODO: Uncomment after release
#if false && NETFRAMEWORK
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

                    Assert.AreEqual(message.Response.ContentStream.CanSeek, false);

                    extractedStream = message.ExtractResponseContent();
                }

                var memoryStream = new MemoryStream();
                await extractedStream.CopyToAsync(memoryStream);
                Assert.AreEqual(memoryStream.Length, 1000);
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

            // Make sure we dispose things correctly and not exhaust the connection pool
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
            content.ApplyToRequest(request);
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("John")), "FirstName", "file_name.txt", new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            });
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Doe")), "LastName", "file_name.txt", new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            });

            request.Content = content;

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
        public async Task SendMultipartData()
        {
            const string ApplicationJson = "application/json";
            const string cteHeaderName = "Content-Transfer-Encoding";
            const string Binary = "binary";
            const string Mixed = "mixed";
            const string ApplicationJsonOdata = "application/json; odata=nometadata";
            const string DataServiceVersion = "DataServiceVersion";
            const string Three0 = "3.0";
            const string Host = "myaccount.table.core.windows.net";

            string requestBody = null;

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(GetOptions());
            using TestServer testServer = new TestServer(
                context =>
                {
                    using var sr = new StreamReader(context.Request.Body, Encoding.UTF8);
                    requestBody = sr.ReadToEnd();
                    return Task.CompletedTask;
                });

            using Request request = httpPipeline.CreateRequest();
            request.Method = RequestMethod.Put;
            request.Uri.Reset(testServer.Address);

            Guid batchGuid = Guid.NewGuid();
            var content = new MultipartContent(Mixed, $"batch_{batchGuid}");
            content.ApplyToRequest(request);

            Guid changesetGuid = Guid.NewGuid();
            var changeset = new MultipartContent(Mixed, $"changeset_{changesetGuid}");
            content.Add(changeset);

            var postReq1 = httpPipeline.CreateMessage().Request;
            postReq1.Method = RequestMethod.Post;
            string postUri = $"https://{Host}/Blogs";
            postReq1.Uri.Reset(new Uri(postUri));
            postReq1.Headers.Add(HttpHeader.Names.ContentType, ApplicationJsonOdata);
            postReq1.Headers.Add(HttpHeader.Names.Accept, ApplicationJson);
            postReq1.Headers.Add(DataServiceVersion, Three0);
            const string post1Body = "{ \"PartitionKey\":\"Channel_19\", \"RowKey\":\"1\", \"Rating\":9, \"Text\":\"Azure...\"}";
            postReq1.Content = RequestContent.Create(Encoding.UTF8.GetBytes(post1Body));
            changeset.Add(new RequestContentContent(postReq1, new Dictionary<string, string> { { cteHeaderName, Binary } }));

            var postReq2 = httpPipeline.CreateMessage().Request;
            postReq2.Method = RequestMethod.Post;
            postReq2.Uri.Reset(new Uri(postUri));
            postReq2.Headers.Add(HttpHeader.Names.ContentType, ApplicationJsonOdata);
            postReq2.Headers.Add(HttpHeader.Names.Accept, ApplicationJson);
            postReq2.Headers.Add(DataServiceVersion, Three0);
            const string post2Body = "{ \"PartitionKey\":\"Channel_17\", \"RowKey\":\"2\", \"Rating\":9, \"Text\":\"Azure...\"}";
            postReq2.Content = RequestContent.Create(Encoding.UTF8.GetBytes(post2Body));
            changeset.Add(new RequestContentContent(postReq2, new Dictionary<string, string> { { cteHeaderName, Binary } }));

            var patchReq = httpPipeline.CreateMessage().Request;
            patchReq.Method = RequestMethod.Patch;
            string mergeUri = $"https://{Host}/Blogs(PartitionKey='Channel_17',%20RowKey='3')";
            patchReq.Uri.Reset(new Uri(mergeUri));
            patchReq.Headers.Add(HttpHeader.Names.ContentType, ApplicationJsonOdata);
            patchReq.Headers.Add(HttpHeader.Names.Accept, ApplicationJson);
            patchReq.Headers.Add(DataServiceVersion, Three0);
            const string patchBody = "{ \"PartitionKey\":\"Channel_19\", \"RowKey\":\"3\", \"Rating\":9, \"Text\":\"Azure Tables...\"}";
            patchReq.Content = RequestContent.Create(Encoding.UTF8.GetBytes(patchBody));
            changeset.Add(new RequestContentContent(patchReq, new Dictionary<string, string> { { cteHeaderName, Binary } }));

            request.Content = content;
            using Response response = await ExecuteRequest(request, httpPipeline);
            Console.WriteLine(requestBody);

            Assert.That(requestBody, Is.EqualTo(@$"--batch_{batchGuid}
{HttpHeader.Names.ContentType}: multipart/mixed; boundary=changeset_{changesetGuid}

--changeset_{changesetGuid}
{HttpHeader.Names.ContentType}: application/http
{cteHeaderName}: {Binary}

POST {postUri} HTTP/1.1
{HttpHeader.Names.Host}: {Host}
{HttpHeader.Names.Accept}: {ApplicationJson}
{DataServiceVersion}: {Three0}
{HttpHeader.Names.ContentType}: {ApplicationJsonOdata}

{post1Body}
--changeset_{changesetGuid}
{HttpHeader.Names.ContentType}: application/http
{cteHeaderName}: {Binary}

POST {postUri} HTTP/1.1
{HttpHeader.Names.Host}: {Host}
{HttpHeader.Names.Accept}: {ApplicationJson}
{DataServiceVersion}: {Three0}
{HttpHeader.Names.ContentType}: {ApplicationJsonOdata}

{post2Body}
--changeset_{changesetGuid}
{HttpHeader.Names.ContentType}: application/http
{cteHeaderName}: {Binary}

PATCH {mergeUri} HTTP/1.1
{HttpHeader.Names.Host}: {Host}
{HttpHeader.Names.Accept}: {ApplicationJson}
{DataServiceVersion}: {Three0}
{HttpHeader.Names.ContentType}: {ApplicationJsonOdata}

{patchBody}
--changeset_{changesetGuid}--

--batch_{batchGuid}--
"));
        }

        private class TestOptions : ClientOptions
        {
        }
    }
}
