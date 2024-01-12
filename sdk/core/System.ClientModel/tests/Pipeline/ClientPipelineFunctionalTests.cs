// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Pipeline;

public class ClientPipelineFunctionalTests : SyncAsyncTestBase
{
    public ClientPipelineFunctionalTests(bool isAsync) : base(isAsync)
    {
    }

    #region Test default buffering behavior

    [Test]
    public async Task SendRequestBuffersResponse()
    {
        byte[] buffer = { 0 };

        using TestServer testServer = new TestServer(
            async context =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    await context.Response.Body.WriteAsync(buffer, 0, 1);
                }
            });

        ClientPipeline pipeline = ClientPipeline.Create();

        // Make sure we dispose things correctly and not exhaust the connection pool
        for (int i = 0; i < 100; i++)
        {
            using PipelineMessage message = pipeline.CreateMessage();
            message.Request.Uri = testServer.Address;

            await pipeline.SendSyncOrAsync(message, IsAsync);

            using PipelineResponse response = message.Response!;

            Assert.AreEqual(response.ContentStream!.Length, 1000);
            Assert.AreEqual(response.Content.ToMemory().Length, 1000);
        }
    }

    [TestCase(200)]
    [TestCase(404)]
    public async Task BufferedResponseStreamReadableAfterMessageDisposed(int status)
    {
        byte[] buffer = { 0 };

        ClientPipeline pipeline = ClientPipeline.Create();

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
            PipelineResponse response;
            using (PipelineMessage message = pipeline.CreateMessage())
            {
                message.Request.Uri = testServer.Address;
                ResponseBufferingPolicy.SetBufferingEnabled(message, true);

                await pipeline.SendSyncOrAsync(message, IsAsync);

                response = message.Response!;
            }

            MemoryStream memoryStream = new();
            await response.ContentStream!.CopyToAsync(memoryStream);
            Assert.AreEqual(memoryStream.Length, bodySize);
        }
    }

    [Test]
    public async Task NonBufferedResponseDisposedAfterMessageDisposed()
    {
        byte[] buffer = { 0 };

        ClientPipeline pipeline = ClientPipeline.Create();

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
            PipelineResponse response;
            Mock<Stream>? disposeTrackingStream = null;
            using (PipelineMessage message = pipeline.CreateMessage())
            {
                message.Request.Uri = testServer.Address;
                ResponseBufferingPolicy.SetBufferingEnabled(message, false);

                await pipeline.SendSyncOrAsync(message, IsAsync);

                response = message.Response!;
                var originalStream = response.ContentStream;
                disposeTrackingStream = new Mock<Stream>();
                disposeTrackingStream
                    .Setup(s => s.Close())
                    .Callback(originalStream!.Close)
                    .Verifiable();
                response.ContentStream = disposeTrackingStream.Object;
            }

            disposeTrackingStream.Verify();
        }
    }

    #endregion
}
