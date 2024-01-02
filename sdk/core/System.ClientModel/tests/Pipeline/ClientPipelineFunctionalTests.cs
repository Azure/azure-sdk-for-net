// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
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

    //[Test]
    //public async Task BufferedResponseStreamReadableAfterMessageDisposed()
    //{
    //}

    //[Test]
    //public async Task NonBufferedResponseStreamReadableAfterMessageDisposed()
    //{
    //}

    //[Test]
    //public async Task NonBufferedResponseDisposedAfterMessageDisposed()
    //{
    //}

    //[Test]
    //public async Task NonBufferedFailedResponseStreamDisposed()
    //{
    //}

    //[Test]
    //public async Task TimesOutResponseBuffering()
    //{
    //}

    //[Test]
    //public async Task TimesOutBodyBuffering()
    //{
    //}

    //[Test]
    //public async Task TimesOutNonBufferedBodyReads()
    //{
    //}

    #endregion

    #region Test default retry behavior

    //[Test]
    //public async Task RetriesTransportFailures()
    //{
    //}

    //[Test]
    //public async Task RetriesTimeoutsServerTimeouts()
    //{
    //}

    //[Test]
    //public async Task DoesntRetryClientCancellation()
    //{
    //}

    //[Test]
    //public async Task RetriesBufferedBodyTimeout()
    //{
    //}

    #endregion

    #region Test parallel connections

    //[Test]
    //public async Task Opens50ParallelConnections()
    //{
    //}

    #endregion
}
