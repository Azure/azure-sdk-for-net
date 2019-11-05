// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportFunctionalTests : PipelineTestBase
    {
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

                    var transport = new HttpClientTransport();
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
                var transport = new HttpClientTransport();
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
                var transport = new HttpClientTransport();
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
                var transport = new HttpClientTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await ExecuteRequest(request, transport));
                Assert.AreEqual("An error occurred while sending the request.", exception.Message);
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
                var transport = new HttpClientTransport();
                Request request = transport.CreateRequest();
                request.Uri.Reset(testServer.Address);
                Response response = await ExecuteRequest(request, transport);

                tcs.SetResult(null);

                Assert.ThrowsAsync<IOException>(async () => await response.ContentStream.CopyToAsync(new MemoryStream()));
            }
        }
    }
}
